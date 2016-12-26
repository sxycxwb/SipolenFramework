using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public class WorkFlowClassTreeNode : BaseTreeNode
    {
        /// <summary>
        /// 流程父分类Id
        /// </summary>
        public string WorkflowFatherClassId;
        /// <summary>
        /// 流程分类的描述
        /// </summary>
        public string Description;
        /// <summary>
        /// 分类等级
        /// </summary>
        public int clLevel;

        /// <summary>
        /// 递归装载全部流程类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadWorkFlowClass(string key, TreeNodeCollection startNodes)
        {
            try
            {
                var table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetChildWorkFlowClass(SystemInfo.UserInfo, key);
                startNodes.Clear();
                foreach (DataRow row in table.Rows)
                {
                    var tmpNode = new WorkFlowClassTreeNode
                    {
                        NodeId = row[WorkFlowClassTable.FieldWFClassId].ToString(),
                        ImageIndex = 0,
                        ToolTipText = "分类",
                        clLevel = Convert.ToInt16(row[WorkFlowClassTable.FieldClLevel]),
                        SelectedImageIndex = 1,
                        Text = row[WorkFlowClassTable.FieldCaption].ToString(),
                        WorkflowFatherClassId = row[WorkFlowClassTable.FieldFatherId].ToString(),
                        Description = row[WorkFlowClassTable.FieldDescription].ToString(),
                        MgrUrl = row[WorkFlowClassTable.FieldClMgrUrl].ToString(),
                        NodeType = WorkConst.WORKFLOW_CLASS
                    };
                    startNodes.Add(tmpNode);
                    LoadWorkFlowClass(tmpNode.NodeId, tmpNode.Nodes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 选中装载流程类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadWorkFlowClassSelectNode(string key, TreeNodeCollection startNodes)
        {
            try
            {
                var table = RDIFrameworkService.Instance.WorkFlowTemplateService.GetChildWorkFlowClass(SystemInfo.UserInfo, key);
                foreach (DataRow row in table.Rows)
                {
                    var tmpNode = new WorkFlowClassTreeNode
                    {
                        NodeId = row[WorkFlowClassTable.FieldWFClassId].ToString(),
                        ImageIndex = 0,
                        ToolTipText = "分类",
                        SelectedImageIndex = 1,
                        clLevel = Convert.ToInt16(row[WorkFlowClassTable.FieldClLevel]),
                        Text = row[WorkFlowClassTable.FieldCaption].ToString(),
                        WorkflowFatherClassId = row[WorkFlowClassTable.FieldFatherId].ToString(),
                        Description = row[WorkFlowClassTable.FieldDescription].ToString(),
                        MgrUrl = row[WorkFlowClassTable.FieldClMgrUrl].ToString(),
                        NodeType = WorkConst.WORKFLOW_CLASS
                    };
                    startNodes.Add(tmpNode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertWorkflowClassNode()
        {
            try
            {
                var workflowClass = new WorkFlowClassEntity
                {
                    WFClassId = NodeId,
                    FatherId = WorkflowFatherClassId,
                    Caption = Text,
                    Description = Description,
                    ClLevel = clLevel,
                    ClMgrUrl = MgrUrl
                };
                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkFlowClass(SystemInfo.UserInfo,workflowClass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWorkflowClassNode()
        {
            try
            {
                var workflowClass = new WorkFlowClassEntity
                {
                    WFClassId = NodeId,
                    FatherId = WorkflowFatherClassId,
                    Caption = Text,
                    Description = Description,
                    ClLevel = clLevel,
                    ClMgrUrl = MgrUrl
                };
                RDIFrameworkService.Instance.WorkFlowTemplateService.UpdateWorkFlowClass(SystemInfo.UserInfo,workflowClass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteSelectClassNode(string nodeId)
        {
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkFlowClass(SystemInfo.UserInfo, nodeId);
        }
    }
}
