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
        //工作流模板的属性字段
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
		/// 选中装载流程列表
		/// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadWorkFlowSelectNode(string key, TreeNodeCollection startNodes)
		{
			if (startNodes==null)
                throw new Exception("LoadWorkFlowSelectNode的参数startNotes不能为空！");

            var table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowsByClassId(SystemInfo.UserInfo,key);
			foreach(DataRow row in table.Rows)
			{
                var tmpNode = new WorkFlowTreeNode
                {
                    NodeId = row["WorkFlowId"].ToString(),
                    WorkFlowClassId = row["WFClassId"].ToString(),
                    ImageIndex = 2,
                    SelectedImageIndex = 2,
                    ToolTipText = "流程",
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
