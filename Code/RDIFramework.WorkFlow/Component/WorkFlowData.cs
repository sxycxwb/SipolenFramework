using System;
using System.Collections;
using System.Data;
using System.Drawing;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

	/// <summary>
	/// 工作流模板的类 的摘要说明。
    /// 操作工作流模板的所有方法。
	/// </summary>
	public class WorkFlowData
	{
        /// <summary>
        /// 工作流程模版主键
        /// </summary>
        public string WorkFlowId { get; set; }

        /// <summary>
        /// 工作流程模版标题
        /// </summary>
        public string WorkFlowCaption { get; set; }

        /// <summary>
        /// 流程分类的主键
        /// </summary>
        public string WorkFlowClassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSignOut { get; set; }

		/// <summary>
        /// 修改、新建、查看三种状态
		/// </summary>
        public string State { get; set; }

		/// <summary>
		/// 节点集合
		/// </summary>
		public ArrayList TaskItems = new ArrayList();

		/// <summary>
		/// 连线集合
		/// </summary>
		public ArrayList LineItems = new ArrayList();	

		public WorkFlowData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 生成工作流模板的类
		/// </summary>
		/// <param name="workflowId">工作流id</param>
		/// <param name="state">读写状态：新建\修改\浏览</param>
		/// <param name="taskItems"></param>
		/// <param name="lineItems"></param>
        public WorkFlowData(string workflowId, string state, ArrayList taskItems, ArrayList lineItems)
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("初始化WorkFlowData类错误，State 不能为空！");
			if (State.Trim().Length==0||State==null)
                throw new Exception("初始化WorkFlowData类错误，State 不能为空！");
			if (TaskItems==null)
                throw new Exception("初始化WorkFlowData类错误，TaskItems 不能为空！");
			if (LineItems==null)
				throw new Exception("初始化WorkFlowData类错误，LineItems 不能为空！");

			WorkFlowId = workflowId;
			TaskItems = taskItems;
			LineItems = lineItems;
			State = state;
		}
        
		/// <summary>
		/// 读取流程模板
		/// </summary>
		public void ReadWorkFlow( )
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
				throw new Exception("ReadWorkFlow方法错误，WorkFlowId 不能为空！");

			int taskType; 
			Point p = new Point(0, 0);
			TaskItems.Clear();
			LineItems.Clear();
			BaseComponent startTask=null, endTask=null;	

			#region 读取任务节点
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
						case 1://启动节点
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
						case 2://结束节点
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
						case 3://交互节点
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
						case 4://判断节点
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
						case 5://查看节点
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
						
						case 6://子流程节点
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
			#endregion **********读取任务节点end

			#region 读取连线

            table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkLinks(SystemInfo.UserInfo,WorkFlowId);
			if (table!=null&&table.Rows.Count > 0 )
			{
				foreach (DataRow dr in table.Rows)
				{
					for (int j = 0; j < TaskItems.Count; j++ )	//查找起止点
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
		/// 保存流程模板
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
				throw new Exception("SaveWorkFlow方法错误，WorkFlowId 不能为空！");
			if (State.Trim().Length==0||State==null)
				throw new Exception("SaveWorkFlow方法错误，State 不能为空！");
			if (TaskItems==null)
				throw new Exception("SaveWorkFlow方法错误，TaskItems 不能为空！");
			if (LineItems==null)
				throw new Exception("SaveWorkFlow方法错误，LineItems 不能为空！");

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
