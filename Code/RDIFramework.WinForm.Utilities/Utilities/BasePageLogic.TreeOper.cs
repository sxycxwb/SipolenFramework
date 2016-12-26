using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.WinForm.Utilities
{
    public partial class BasePageLogic
    {
        // 已找到的树节点
        public static TreeNode TargetNode = null;

        #region public static bool NodeAllowDelete(TreeNode treeNode) 节点是否允许删除
        /// <summary>
        /// 节点是否允许删除
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        /// <returns>是否允许</returns>
        public static bool NodeAllowDelete(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return false;
            }
            return (treeNode.Nodes.Count == 0);
        }
        #endregion

        #region public static void ExpandTreeNode(TreeView treeView) 展开节点
        /// <summary>
        /// 展开节点
        /// </summary>
        /// <param name="treeView">当前节点</param>
        public static void ExpandTreeNode(TreeView treeView)
        {
            TreeNode treeNode = treeView.SelectedNode;
            while (treeNode != null)
            {
                treeNode.Expand();
                treeNode = treeNode.Parent;
            }
        }
        #endregion

        #region public static void FindTreeNode(TreeView treeView, string id) 查找树节点
        /// <summary>
        /// 查找树节点
        /// </summary>
        /// <param name="treeView">树节点</param>
        /// <param name="id">主键</param>
        public static void FindTreeNode(TreeView treeView, string id)
        {
            TargetNode = null;
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i].Tag is DataRow)
                {
                    if (((DataRow)treeView.Nodes[i].Tag)[BusinessLogic.FieldId].ToString() == id)
                    {
                        TargetNode = treeView.Nodes[i];
                        return;
                    }
                }
                else if (treeView.Nodes[i].Tag.ToString() == id)
                {
                    TargetNode = treeView.Nodes[i];
                    return;
                }
                FindTreeNode(treeView.Nodes[i], id);
            }
        }
        #endregion

        #region private static void FindTreeNode(TreeNode treeNode, string id) 查找树节点
        /// <summary>
        /// 查找树节点
        /// </summary>
        /// <param name="treeNode">节点</param>
        /// <param name="id">主键</param>
        private static void FindTreeNode(TreeNode treeNode, string id)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                if (treeNode.Nodes[i].Tag is DataRow)
                {
                    if (((DataRow)treeNode.Nodes[i].Tag)[BusinessLogic.FieldId].ToString() == id)
                    {
                        TargetNode = treeNode.Nodes[i];
                        return;
                    }
                }

                if (treeNode.Nodes[i].Tag.ToString() == id)
                {
                    TargetNode = treeNode.Nodes[i];
                    break;
                }
                FindTreeNode(treeNode.Nodes[i], id);
            }
        }
        #endregion

        #region public static bool TreeNodeCanMoveTo(TreeNode currentTreeNode, TreeNode targetTreeNode) 当前节点是否允许转移到目标节点
        /// <summary>
        /// 当前节点是否允许转移到目标节点
        /// </summary>
        /// <param name="currentTreeNode">当前节点</param>
        /// <param name="targetTreeNode">目标节点</param>
        /// <returns>允许</returns>
        public static bool TreeNodeCanMoveTo(TreeNode currentTreeNode, TreeNode targetTreeNode)
        {
            if (currentTreeNode != null)
            {
                // 当前节点不能移动到当前节点上
                if (currentTreeNode.Equals(targetTreeNode))
                {
                    return false;
                }
                // 当前节点的父节点也不用移动
                //if (currentTreeNode.Parent == targetTreeNode)
                //{
                //    return false;
                //}

                // 顶级节点也能拖动才对
                // if (currentTreeNode.Parent == null)
                // {
                //    return false;
                // }
                // 有相同名字的，不能移动
                for (int i = 0; i < targetTreeNode.Nodes.Count; i++)
                {
                    if (currentTreeNode.Text.Equals(targetTreeNode.Nodes[i].Text))
                    {
                        return false;
                        // break;
                    }
                }
                // 当前节点不能移动到自己的子节点上去
                while (targetTreeNode.Parent != null)
                {
                    targetTreeNode = targetTreeNode.Parent;
                    if (currentTreeNode.Equals(targetTreeNode))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region public static void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true, int expandLevel = 0, string fieldToolTipText = null, int isloadTreeNum = 1, bool userSettingExpand = false, bool checkEnabledNode = false)
        /// <summary>
        /// 加载树型结构的主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键</param>
        /// <param name="fieldParentId">上级字段</param>
        /// <param name="fieldFullName">全称</param>
        /// <param name="treeView">TreeView控件</param>
        /// <param name="treeNode">当前树结点</param>
        /// <param name="loadTree">是否加载树</param>
        /// <param name="expandLevel">展开层数，默认不展开</param>
        /// <param name="fieldToolTipText"></param>
        /// <param name="isloadTreeNum"></param>
        /// <param name="userSettingExpand">是否按用户配置展开</param>
        /// <param name="checkEnabledNode">是否选中启用的节点</param>
        public static void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true, int expandLevel = 0, string fieldToolTipText = null, int isloadTreeNum = 1, bool userSettingExpand = false, bool checkEnabledNode = false)
        {
            // 加入按用户配置展开功能 
            // 不递归的情况下，实际上还是要递归一层比较好
            // 查找 ParentId 字段的值是否在 Id字段 里
            // 一般情况是简单的数据过滤，就没必要进行严格的检查了，进行了严格的检查，反而降低运行效率
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                    || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                    || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = 0");
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = ''");
                }
            }
            else
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                   || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                   || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                   || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                   || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + "=" + (treeNode.Tag as DataRow)[fieldId].ToString() + "", dataTable.DefaultView.Sort);
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + "='" + (treeNode.Tag as DataRow)[fieldId].ToString() + "'", dataTable.DefaultView.Sort);
                }
            }

            foreach (var dataRow in dataRows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[fieldId] != null) && ((treeNode.Tag as DataRow)[fieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[fieldId].ToString().Equals(dataRow[fieldParentId].ToString())))
                {
                    continue;
                }

                // 当前节点的子节点, 加载根节点
                if (dataRow.IsNull(fieldParentId) || (dataRow[fieldParentId].ToString() == "0") || (dataRow[fieldParentId].ToString().Length == 0) || (((treeNode.Tag as DataRow)[fieldId] != null) || (treeNode.Tag != null) && (treeNode.Tag as DataRow)[fieldId].Equals(dataRow[fieldParentId].ToString())))
                {
                    var newTreeNode = new TreeNode
                    {
                        Text = dataRow[fieldFullName].ToString(),
                        Tag = dataRow
                    };

                    if (!string.IsNullOrEmpty(fieldToolTipText))
                    {
                        newTreeNode.ToolTipText = dataRow[fieldToolTipText].ToString();
                    }
                    // 是否选中启用的节点 
                    if (checkEnabledNode)
                    {
                        newTreeNode.Checked = ((newTreeNode.Tag as DataRow)["Enabled"].ToString().Equals("1"));
                    }

                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[fieldId] == null) || ((treeNode.Tag as DataRow)[fieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        treeView.Nodes.Add(newTreeNode);

                        // 是否按用户配置展开 
                        if (userSettingExpand)
                        {
                            if (((DataRow)newTreeNode.Tag)["Expand"].ToString() == "1")
                            {
                                newTreeNode.Expand();
                            }
                        }
                        else
                        {
                            if (expandLevel > newTreeNode.Level)
                            {
                                newTreeNode.Expand();
                            }
                        }
                    }
                    else
                    {
                        // 节点的子节点加载，第一层节点需要展开                        
                        treeNode.Nodes.Add(newTreeNode);
                        // 是否按用户配置展开
                        if (userSettingExpand)
                        {
                            if ((treeNode.Tag as DataRow)["Expand"].ToString() == "1")
                            {
                                treeNode.Expand();
                            }
                        }
                        else
                        {
                            if (expandLevel > treeNode.Level)
                            {
                                treeNode.Expand();
                            }
                        }
                    }

                    if (loadTree)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree, expandLevel, fieldToolTipText, 1, userSettingExpand, checkEnabledNode);
                    }
                    else if (isloadTreeNum == 1)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree, expandLevel, fieldToolTipText, 2, userSettingExpand, checkEnabledNode);
                    }
                }
            }
        }
        #endregion

        #region public static void AddTreeNode(TreeView treeView, TreeNode newNode, TreeNode parentNode) 添加一个节点，并使其可见
        /// <summary>
        /// 添加一个节点，并使其可见
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="text"></param>
        /// <param name="tag"></param>
        public static void AddTreeNode(TreeView treeView, TreeNode newNode, TreeNode parentNode)
        {
            if (parentNode != null)
            {
                parentNode.Nodes.Add(newNode);
                treeView.SelectedNode = parentNode;
                parentNode.Expand();
                // 让新添加节点可视 
            }
            else
            {
                treeView.Nodes.Add(newNode);
                treeView.SelectedNode = newNode;
                newNode.Expand();
            }
            newNode.EnsureVisible();
        }
        #endregion

        #region  public static void BatchRemoveNode(TreeView treeView,string[] tags) 批量删除树中的节点，并使父节点可见
        /// <summary>
        /// 批量删除树中的节点，并使父节点可见
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="tags"></param>
        public static void BatchRemoveNode(TreeView treeView, string[] tags)
        {
            TreeNode parentNode = null;
            for (int i = 0; i < tags.Length; i++)
            {
                BasePageLogic.FindTreeNode(treeView, tags[i]);
                TreeNode treeNode = BasePageLogic.TargetNode;
                if (i == 0)
                {
                    parentNode = treeNode.Parent;
                }
                treeNode.Remove();
            }
            // 使删除节点的parentNode可见
            if (parentNode != null)
            {
                parentNode.Expand();
                treeView.SelectedNode = parentNode;
                parentNode.EnsureVisible();
            }
        }
        #endregion

        #region public static void MoveTreeNode(TreeView treeView, TreeNode newParentNode)添加一个节点，并使其可见
        /// <summary>
        /// 移动一个节点，并使其可见
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="text"></param>
        /// <param name="tag"></param>
        public static void MoveTreeNode(TreeView treeView, TreeNode selectNode, TreeNode parentNode)
        {
            TreeNode temNode = selectNode;
            // 先删除
            selectNode.Remove();
            if (parentNode != null)
            {
                // 添加到新的父节点下
                parentNode.Nodes.Add(temNode);
                // 展开新的父节点，是新增节点可见
                parentNode.Expand();
                treeView.SelectedNode = parentNode;
            }
            else
            {
                treeView.Nodes.Add(temNode);
                temNode.Expand();
                treeView.SelectedNode = temNode;
            }
            temNode.EnsureVisible();
        }
        #endregion

        #region public static void EditTreeNode(TreeView treeView, TreeNode selectNode,TreeNode parentNode) 编辑节点
        /// <summary>
        /// 编辑节点
        /// </summary>
        public static void EditTreeNode(TreeView treeView, TreeNode selectNode, TreeNode parentNode)
        {
            MoveTreeNode(treeView, selectNode, parentNode);
        }
        #endregion

        #region public static void CheckChild(TreeNode node) 递归检查子节点是否被选中
        /// <summary>
        /// 递归检查子节点是否被选中
        /// </summary>
        /// <param name="node"></param>
        public static void CheckChild(TreeNode node)
        {
            bool childNodeCheck = false;

            if (node.Nodes.Count != 0)
            {
                //如果节点下有已选子节点
                foreach (TreeNode item in node.Nodes)
                {
                    childNodeCheck = item.Checked;
                    if (childNodeCheck)
                        break;
                }

                //1、如果node下有子节点checked，展开或者收缩节点不影响子节点的选择
                //2、如果节点由checked 变为Uncheced  子节点也都 变成unchecked
                if (!childNodeCheck || !node.Checked)
                {
                    foreach (TreeNode item in node.Nodes)
                    {
                        item.Checked = node.Checked;
                        CheckChild(item);
                    }
                }
            }
        }
        #endregion

        #region public static void CheckParent(TreeNode node) 递归检查父节点是否被选中
        /// <summary>
        /// 递归检查父节点，如果父节点下有node是checked，则该父节点是checked
        /// </summary>
        /// <param name="node"></param>
        public static void CheckParent(TreeNode node)
        {
            bool childNodeCheck = false;
            if (node.Parent != null)
            {
                foreach (TreeNode item in node.Parent.Nodes)
                {
                    childNodeCheck = item.Checked;
                    if (childNodeCheck)
                        break;
                }
                node.Parent.Checked = childNodeCheck;
                CheckParent(node.Parent);
            }
        }
        #endregion
    }
}