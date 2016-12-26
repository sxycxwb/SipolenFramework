using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

	/// <summary>
    /// WorkFlowTreeNode.cs
    /// 
	/// </summary>
    public class WorkFlowTreeNode : BaseTreeNode
	{
        //������ģ��������ֶ�
        public string WorkFlowClassId = "";
        public string Description = "";
        public string Status = "";

        public WorkFlowTreeNode()
		{
		}

        public static void DeleteSelectWorkflowNode(string nodeId)
        {
           RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkFlow(SystemInfo.UserInfo,nodeId);
        }
        
		/// <summary>
		/// ѡ��װ�������б�
		/// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadWorkFlowSelectNode(string key, TreeNodeCollection startNodes)
		{
			if (startNodes==null)
                throw new Exception("LoadWorkFlowSelectNode�Ĳ���startNotes����Ϊ�գ�");

            var table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowsByClassId(SystemInfo.UserInfo,key);
			foreach(DataRow row in table.Rows)
			{
                var tmpNode = new WorkFlowTreeNode
                {
                    NodeId = row["WorkFlowId"].ToString(),
                    WorkFlowClassId = row["WFClassId"].ToString(),
                    ImageIndex = 2,
                    SelectedImageIndex = 2,
                    ToolTipText = "����",
                    Status = row["Status"].ToString(),
                    Text = row["FlowCaption"].ToString(),
                    MgrUrl = row["mgrurl"].ToString(),
                    Description = row["Description"].ToString(),
                    NodeType = WorkConst.WORKFLOW_FLOW
                };
			    if (!string.IsNullOrEmpty(tmpNode.Status) && tmpNode.Status == "0")
			    {
			        tmpNode.ForeColor = System.Drawing.Color.DarkGray;
			    }

			    startNodes.Add(tmpNode);
            }
		}

        public void InsertWorkflowNode()
        {
            try
            {
                var workflowTemplate = new WorkFlowTemplateEntity
                {
                    WorkFlowId = NodeId,
                    WFClassId = WorkFlowClassId,
                    FlowCaption = Text,
                    Status = Status,
                    MgrUrl = MgrUrl,
                    Description = Description
                };
                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkFlow(SystemInfo.UserInfo,workflowTemplate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWorkflowNode()
        {
            try
            {
                var workflowTemplate = new WorkFlowTemplateEntity
                {
                    WorkFlowId = NodeId,
                    WFClassId = WorkFlowClassId,
                    FlowCaption = Text,
                    Status = Status,
                    MgrUrl = MgrUrl,
                    Description = Description
                };
                RDIFrameworkService.Instance.WorkFlowTemplateService.UpdateWorkFlow(SystemInfo.UserInfo,workflowTemplate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
	}
}
