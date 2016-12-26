using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public class MainUserControlNode : BaseUserControlTreeNode
    {
        /// <summary>
        /// ����������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// װ��ȫ������
        /// </summary>
        /// <param name="startNodes"></param>
        public static void LoadAllMainUserControls(TreeNodeCollection startNodes)
        {
            try
            {
                var table = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllMainUserControls(SystemInfo.UserInfo);
                startNodes.Clear();
                foreach (DataRow row in table.Rows)
                {
                    var tmpNode = new MainUserControlNode
                    {
                        NodeId = row[MainUserControlTable.FieldId].ToString(),
                        ImageIndex = 2,
                        ToolTipText = "����",
                        SelectedImageIndex = 3,
                        Text = row[MainUserControlTable.FieldFullName].ToString(),
                        Description = row[MainUserControlTable.FieldDescription].ToString(),
                        NodeType = WorkConst.UserControl_Main
                    };
                    startNodes.Add(tmpNode);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public void InsertMainUserControlNode()
        {
            try
            {
                var mainUserctrl = new MainUserControlEntity
                {
                    Id = NodeId,
                    FullName = Text,
                    Description = Description
                };

                RDIFrameworkService.Instance.WorkFlowUserControlService.InsertMainUserCtrl(SystemInfo.UserInfo,mainUserctrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMainUserControlNode()
        {
            try
            {
                var mainUserctrl = new MainUserControlEntity
                {
                    Id = NodeId,
                    FullName = Text,
                    Description = Description
                };
                RDIFrameworkService.Instance.WorkFlowUserControlService.UpdateMainUserCtrl(SystemInfo.UserInfo,mainUserctrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteMainUserControlNode(string nodeId)
        {
            RDIFrameworkService.Instance.WorkFlowUserControlService.SetDeletedMainUserCtrl(SystemInfo.UserInfo, nodeId);
        }
    }
}
