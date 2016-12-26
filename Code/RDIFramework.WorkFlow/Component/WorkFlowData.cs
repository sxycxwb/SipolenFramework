using System;
using System.Collections;
using System.Data;
using System.Drawing;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

	/// <summary>
	/// ������ģ����� ��ժҪ˵����
    /// ����������ģ������з�����
	/// </summary>
	public class WorkFlowData
	{
        /// <summary>
        /// ��������ģ������
        /// </summary>
        public string WorkFlowId { get; set; }

        /// <summary>
        /// ��������ģ�����
        /// </summary>
        public string WorkFlowCaption { get; set; }

        /// <summary>
        /// ���̷��������
        /// </summary>
        public string WorkFlowClassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSignOut { get; set; }

		/// <summary>
        /// �޸ġ��½����鿴����״̬
		/// </summary>
        public string State { get; set; }

		/// <summary>
		/// �ڵ㼯��
		/// </summary>
		public ArrayList TaskItems = new ArrayList();

		/// <summary>
		/// ���߼���
		/// </summary>
		public ArrayList LineItems = new ArrayList();	

		public WorkFlowData()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ���ɹ�����ģ�����
		/// </summary>
		/// <param name="workflowId">������id</param>
		/// <param name="state">��д״̬���½�\�޸�\���</param>
		/// <param name="taskItems"></param>
		/// <param name="lineItems"></param>
        public WorkFlowData(string workflowId, string state, ArrayList taskItems, ArrayList lineItems)
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("��ʼ��WorkFlowData�����State ����Ϊ�գ�");
			if (State.Trim().Length==0||State==null)
                throw new Exception("��ʼ��WorkFlowData�����State ����Ϊ�գ�");
			if (TaskItems==null)
                throw new Exception("��ʼ��WorkFlowData�����TaskItems ����Ϊ�գ�");
			if (LineItems==null)
				throw new Exception("��ʼ��WorkFlowData�����LineItems ����Ϊ�գ�");

			WorkFlowId = workflowId;
			TaskItems = taskItems;
			LineItems = lineItems;
			State = state;
		}
        
		/// <summary>
		/// ��ȡ����ģ��
		/// </summary>
		public void ReadWorkFlow( )
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
				throw new Exception("ReadWorkFlow��������WorkFlowId ����Ϊ�գ�");

			int taskType; 
			Point p = new Point(0, 0);
			TaskItems.Clear();
			LineItems.Clear();
			BaseComponent startTask=null, endTask=null;	

			#region ��ȡ����ڵ�
            DataTable table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTasks(SystemInfo.UserInfo, WorkFlowId);
			if (table!=null&&table.Rows.Count > 0 )
			{
				foreach (DataRow dr in table.Rows)
				{
                    taskType = Convert.ToInt32(dr[WorkTaskTable.FieldTaskTypeId].ToString());
                    p.X = Convert.ToInt32(dr[WorkTaskTable.FieldIXPosition].ToString());
                    p.Y = Convert.ToInt32(dr[WorkTaskTable.FieldIYPosition].ToString());
                    
					switch (taskType)
					{
						case 1://�����ڵ�
							var st = new StartTask(p,0)
							{
                                TaskName = dr[WorkTaskTable.FieldTaskCaption].ToString(),
							    TaskId = dr[WorkTaskTable.FieldWorkTaskId].ToString(),
							    TaskType = taskType,
                                OperRule = dr[WorkTaskTable.FieldOperRule].ToString(),
                                WorkFlowId = dr[WorkTaskTable.FieldWorkFlowId].ToString(),
                                Description = dr[WorkTaskTable.FieldDescription].ToString()
							};
					        TaskItems.Add(st);
							break;
						case 2://�����ڵ�
							var edTask=new EndTask(p,0)
							{
							    TaskName = dr[WorkTaskTable.FieldTaskCaption].ToString(),
                                TaskId = dr[WorkTaskTable.FieldWorkTaskId].ToString(),
							    TaskType = taskType,
                                WorkFlowId = dr[WorkTaskTable.FieldWorkFlowId].ToString(),
                                Description = dr[WorkTaskTable.FieldDescription].ToString()
							};
					        TaskItems.Add(edTask);
							break;
						case 3://�����ڵ�
							var alterTask=new AlternateTask(p,0)
							{
							    TaskName = dr[WorkTaskTable.FieldTaskCaption].ToString(),
							    TaskId = dr[WorkTaskTable.FieldWorkTaskId].ToString(),
							    TaskType = taskType,
                                OperRule = dr[WorkTaskTable.FieldOperRule].ToString(),
                                WorkFlowId = dr[WorkTaskTable.FieldWorkFlowId].ToString(),
                                IsJumpSelf = Convert.ToBoolean(dr[WorkTaskTable.FieldIsJumpSelf]),
                                Description = dr[WorkTaskTable.FieldDescription].ToString()
							};
					        TaskItems.Add(alterTask);
							break;
						case 4://�жϽڵ�
							var judgeTask=new JudgeTask(p,0)
							{
							    TaskName = dr[WorkTaskTable.FieldTaskCaption].ToString(),
							    TaskId = dr[WorkTaskTable.FieldWorkTaskId].ToString(),
							    TaskType = taskType,
                                WorkFlowId = dr[WorkTaskTable.FieldWorkFlowId].ToString(),
                                TaskTypeAndOr = dr[WorkTaskTable.FieldTaskTypeAndOr].ToString(),
                                Description = dr[WorkTaskTable.FieldDescription].ToString()
							};
					        TaskItems.Add(judgeTask);
							break;
						case 5://�鿴�ڵ�
							var viewTask=new ViewTask(p,0)
							{
							    TaskName = dr[WorkTaskTable.FieldTaskCaption].ToString(),
							    TaskId = dr[WorkTaskTable.FieldWorkTaskId].ToString(),
							    TaskType = taskType,
                                WorkFlowId = dr[WorkTaskTable.FieldWorkFlowId].ToString(),
                                IsJumpSelf = Convert.ToBoolean(dr[WorkTaskTable.FieldIsJumpSelf]),
                                OperRule = dr[WorkTaskTable.FieldOperRule].ToString(),
                                Description = dr[WorkTaskTable.FieldDescription].ToString()
							};
					        TaskItems.Add(viewTask);
							break;
						
						case 6://�����̽ڵ�
							var subFlowTask=new SubFlowTask(p,0)
							{
							    TaskName = dr[WorkTaskTable.FieldTaskCaption].ToString(),
							    TaskId = dr[WorkTaskTable.FieldWorkTaskId].ToString(),
							    TaskType = taskType,
                                WorkFlowId = dr[WorkTaskTable.FieldWorkFlowId].ToString(),
                                Description = dr[WorkTaskTable.FieldDescription].ToString()
							};
					        TaskItems.Add(subFlowTask);
							break;
					}
				}
			}
			#endregion **********��ȡ����ڵ�end

			#region ��ȡ����

            table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkLinks(SystemInfo.UserInfo,WorkFlowId);
			if (table!=null&&table.Rows.Count > 0 )
			{
				foreach (DataRow dr in table.Rows)
				{
					for (int j = 0; j < TaskItems.Count; j++ )	//������ֹ��
					{
						if(startTask==null || endTask==null)
						{
                            if (startTask == null && ((BaseComponent)TaskItems[j]).TaskId.Equals(dr[WorkLinkTable.FieldStartTaskId].ToString()) == true)
							{
								startTask = (BaseComponent)TaskItems[j];						
							}
                            if (endTask == null && ((BaseComponent)TaskItems[j]).TaskId.Equals(dr[WorkLinkTable.FieldEndTaskId].ToString()) == true)
							{
								endTask = (BaseComponent)TaskItems[j];						
							}
						}
					}

					var lnk = new Link(startTask, endTask)
					{
                        linkGuid = dr[WorkLinkTable.FieldWorkLinkId].ToString(),
                        flowGuid = dr[WorkLinkTable.FieldWorkFlowId].ToString(),
                        CommandName = dr[WorkLinkTable.FieldCommandName].ToString(),
                        Condition = dr[WorkLinkTable.FieldCondition].ToString(),
                        Des = dr[WorkLinkTable.FieldDescription].ToString()
					};
				    if(startTask!=endTask)
					{
                        if (dr[WorkLinkTable.FieldBreakX].ToString() != "")
						{
                            string[] xx = dr[WorkLinkTable.FieldBreakX].ToString().Split(',');
                            string[] yy = dr[WorkLinkTable.FieldBreakY].ToString().Split(',');						
							for(int mm=0;mm<xx.Length;mm++)
							{
								lnk.breakPointX.Insert(lnk.breakPointX.Count-1,xx[mm]);
								lnk.breakPointY.Insert(lnk.breakPointY.Count-1,yy[mm]);
							}
						}
					}
					LineItems.Add(lnk);
					startTask=null;
					endTask=null;
				}
			}
			#endregion
		}    
   
		/// <summary>
		/// ��������ģ��
		/// </summary>	
		public void SaveWorkFlow()
		{
			SaveWorkFlow(WorkFlowId,TaskItems,LineItems,State);
		}

		public void SaveWorkFlow(string workFlowId,ArrayList taskItems,ArrayList lineItems,string state)
		{
			TaskItems=taskItems;
			LineItems=lineItems;
			WorkFlowId=workFlowId;
			State=state;
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
				throw new Exception("SaveWorkFlow��������WorkFlowId ����Ϊ�գ�");
			if (State.Trim().Length==0||State==null)
				throw new Exception("SaveWorkFlow��������State ����Ϊ�գ�");
			if (TaskItems==null)
				throw new Exception("SaveWorkFlow��������TaskItems ����Ϊ�գ�");
			if (LineItems==null)
				throw new Exception("SaveWorkFlow��������LineItems ����Ϊ�գ�");

			switch (this.State)
			{
			    case WorkConst.STATE_ADD:
			        foreach (BaseComponent bc in TaskItems)
			        {
			            if (bc.TaskExist())
			                bc.SaveUpdateTask();
			            else
			                bc.SaveInsertTask();

			        }
			        foreach (Link lk in LineItems)
			        {
			            if (lk.LinkExist())
			                lk.SaveUpdateLink();
			            else
			                lk.SaveInsertLink();
			        }
			        break;
			    case WorkConst.STATE_MOD:
			        foreach (BaseComponent bc in TaskItems)
			        {
			            if (bc.TaskExist())
			                bc.SaveUpdateTask();
			            else
			                bc.SaveInsertTask();

			        }
			        foreach (Link lk in LineItems)
			        {
			            if (lk.LinkExist())
			                lk.SaveUpdateLink();
			            else
			                lk.SaveInsertLink();
			        }
			        break;
			}
		}
	}
}
