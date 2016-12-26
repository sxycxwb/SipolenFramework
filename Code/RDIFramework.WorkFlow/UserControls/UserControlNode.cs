using System;
using System.Windows.Forms;
using System.Data;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

	/// <summary>
    /// UserControlNode
    /// 
	/// </summary>
    public class UserControlNode : BaseUserControlTreeNode
	{
        //子表单属性字段
        public string UserCtrlPath = string.Empty;
        public string Description = string.Empty;
        public string ControlId = string.Empty;
	    public string FormName = string.Empty;
	    public string AssemblyName = string.Empty;
	    public string Type = string.Empty;

	    public static void DeleteUserControl(string NodeId)
        {
            RDIFrameworkService.Instance.WorkFlowUserControlService.SetDeletedUserControl(SystemInfo.UserInfo, NodeId);
        }
        
		/// <summary>
		/// 加载所以子表单列表
		/// </summary>
        /// <param name="startNodes"></param>
        public static void LoadAllUserControlsNode( TreeNodeCollection startNodes)
		{
			if (startNodes==null)
                throw new Exception("LoadAllUserControlsNode的参数startNotes不能为空！");

            var table = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllChildUserControls(SystemInfo.UserInfo);
            startNodes.Clear();
			foreach(DataRow row in table.Rows)
			{
                var tmpNode = new UserControlNode
                {
                    NodeId = BusinessLogic.ConvertToString(row[UserControlsTable.FieldId]) ?? "",
                    ImageIndex = 1,
                    SelectedImageIndex = 3,
                    ToolTipText = "子表单",
                    Text = BusinessLogic.ConvertToString(row[UserControlsTable.FieldFullName]) ?? "",
                    UserCtrlPath = BusinessLogic.ConvertToString(row[UserControlsTable.FieldPath]) ?? "",
                    Description = BusinessLogic.ConvertToString(row[UserControlsTable.FieldDescription]) ?? "",
                    NodeType = WorkConst.WORKFLOW_FLOW,
                    ControlId = BusinessLogic.ConvertToString(row[UserControlsTable.FieldControlId]) ?? "",
                    FormName = BusinessLogic.ConvertToString(row[UserControlsTable.FieldFormName]) ?? "",
                    AssemblyName = BusinessLogic.ConvertToString(row[UserControlsTable.FieldAssemblyName]) ?? "",
                    Type = BusinessLogic.ConvertToString(row[UserControlsTable.FieldType]) ?? ""
                };
			    startNodes.Add(tmpNode);
			}
		}

        public void InsertUserControlNode()
        {
            try
            {
                var entity= new UserControlsEntity
                {
                    Id = NodeId,
                    FullName = Text,
                    Path = UserCtrlPath,
                    Description = Description,
                    ControlId = ControlId,
                    FormName = FormName,
                    AssemblyName = AssemblyName,
                    Type = Type
                };
                RDIFrameworkService.Instance.WorkFlowUserControlService.InsertUserControl(SystemInfo.UserInfo, entity);
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
                var entity = new UserControlsEntity
                {
                    Id = NodeId,
                    FullName = Text,
                    Path = UserCtrlPath,
                    Description = Description,
                    ControlId = ControlId,
                    Type = Type,
                    FormName = FormName,
                    AssemblyName = AssemblyName
                };
                RDIFrameworkService.Instance.WorkFlowUserControlService.UpdateUserControl(SystemInfo.UserInfo, entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
