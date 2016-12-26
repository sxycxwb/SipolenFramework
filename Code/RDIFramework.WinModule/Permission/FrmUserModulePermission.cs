/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:54:57
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserModulePermission
    /// 模块管理-模块配置
    /// 
    /// </summary>
    public partial class FrmUserModulePermission : BaseForm
    {
        private DataTable DTModule = new DataTable(PiModuleTable.TableName);
        private string[] moduleIds = null;

        private bool permissionAccess = false;   // 访问权限
        private bool permissionEdit = false;   // 编辑权限

        private bool isUserClick = false;    // 是否是用户点击了复选框

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmUserModulePermission()
        {
            InitializeComponent();
        }

        public FrmUserModulePermission(string userId, string userRealame)
            : this()
        {
            this.txtUser.Tag = userId;
            this.txtUser.Text = userRealame;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            // 公开的就没必要显示了
            // BusinessLogic.SetFilter(this.DTModule, PiModuleTable.FieldIsPublic, "0");
            // 只有有效的才可以显示出来
            BusinessLogic.SetFilter(this.DTModule, PiModuleTable.FieldEnabled, "1");
            this.DTModule.DefaultView.Sort = PiModuleTable.FieldSortCode;
            // 查找 ParentId 字段的值是否在 ID字段 里
            // BaseInterfaceLogic.CheckTreeParentId(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId);
            this.moduleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByUserId(UserInfo, this.txtUser.Tag.ToString(), "Resource.AccessPermission");
            // 设置鼠标默认状态，原来的光标状态
            this.BindData(true);
            // 有效性过滤，这个千万不能过滤的，这个过滤了，有效就设置不回来了
            // BUBusinessLogic.SetFilter(this.DSModule.Tables[PiModuleTable.TableName], PiModuleTable.FieldEnabled, "1");
            // this.DSModule.Tables[PiModuleTable.TableName].AcceptChanges();
            //this.tvModule.ExpandAll();
            this.isUserClick = true;
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载模块树</param>
        private void BindData(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvModule.SelectedNode == null)
            {
                if (this.tvModule.Nodes.Count > 0)
                {
                    this.tvModule.SelectedNode = this.tvModule.Nodes[0];

                }
            }
            if (this.tvModule.SelectedNode != null)
            {
                // 让选中的节点可视，并用展开方式
                this.tvModule.SelectedNode.Expand();
                this.tvModule.SelectedNode.EnsureVisible();
            }
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            foreach (DataRow dataRow in this.DTModule.Rows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && (treeNode.Tag as DataRow) != null && ((treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString().Equals(dataRow[PiModuleTable.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(PiModuleTable.FieldParentId) 
                    || (dataRow[PiModuleTable.FieldParentId].ToString().Length == 0) 
                    || (dataRow[PiModuleTable.FieldParentId].ToString().Equals("0")) 
                    || (dataRow[PiModuleTable.FieldParentId].ToString().Equals(SystemInfo.RootMenuCode)) 
                    || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString().Equals(dataRow[PiModuleTable.FieldParentId].ToString()))))
                {
                    var newTreeNode = new TreeNode
                    {
                        Text = dataRow[PiModuleTable.FieldFullName].ToString(),
                        Tag = dataRow
                    };
                    // 是否已经有这个权限
                    newTreeNode.Checked = Array.IndexOf(this.moduleIds, (newTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString()) >= 0;

                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow) == null) || ((treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvModule.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                    }
                    //展开
                    if (newTreeNode.Level < 2)
                    {
                        newTreeNode.Expand();
                    }
                    // 递归调用本函数
                    this.LoadTreeModule(newTreeNode);
                }
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("UserModulePermission");    // 访问权限
            this.permissionEdit   = this.IsModuleAuthorized("UserModulePermission");      // 编辑权限
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.DTModule.DefaultView.Count == 0)
            {
                this.cmnuSelectAll.Enabled = false;
                this.cmnuInvertSelect.Enabled = false;
                this.btnSave.Enabled = false;
            }
            else
            {
                this.cmnuSelectAll.Enabled = this.permissionEdit;
                this.cmnuInvertSelect.Enabled = this.permissionEdit;
                this.btnSave.Enabled = this.permissionEdit;
            }
        }
        #endregion

        #region private void SetTreeNodesSelected(TreeNode treeNode, bool selected) 递规设置树的选择状态
        /// <summary>
        /// 递规设置树的选择状态
        /// </summary>
        /// <param name="TreeNode">树节点</param>
        /// <param name="selected">选择</param>
        private void SetTreeNodesSelected(TreeNode treeNode, bool selected)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
            treeNode.Checked = selected;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.SetTreeNodesSelected(treeNode.Nodes[i], selected);
            }
        }
        #endregion

        private void tvModule_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        //private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        // 是用户点了复选框。改用在tvModule_NodeMouseClick函数中处理了，edit by EricHu on 2011-10-31
        //if (this.isUserClick)
        //{
        //    for (int i = 0; i < e.Node.Nodes.Count; i++)
        //    {
        //        e.Node.Nodes[i].Checked = e.Node.Checked;
        //    }
        //}
        //}

        private void tvModule_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BasePageLogic.CheckChild(e.Node);
            BasePageLogic.CheckParent(e.Node);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvModule.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        #region private void SetTreeNodesTurnSelected(TreeNode treeNode) 递规设置树的反选状态
        /// <summary>
        /// 递规设置树的反选状态
        /// </summary>
        /// <param name="TreeNode">树节点</param>
        private void SetTreeNodesTurnSelected(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
            treeNode.Checked = !treeNode.Checked;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.SetTreeNodesTurnSelected(treeNode.Nodes[i]);
            }
        }
        #endregion

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvModule.Nodes[i]);
            }
            this.isUserClick = true;
        }

        /// <summary>
        /// 授权的权限
        /// </summary>
        private string GrantModules = string.Empty;

        /// <summary>
        /// 撤销的权限
        /// </summary>
        private string RevokeModules = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.moduleIds, moduleId) < 0)
                    {
                        this.GrantModules += moduleId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.moduleIds, moduleId) >= 0)
                    {
                        this.RevokeModules += moduleId + ";";
                    }
                }
            }

            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToArray(treeNode.Nodes[i]);
            }
        }

        private void CheckParentChecked(TreeNode treeNode)
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.CheckParentChecked(treeNode.Nodes[i]);
            }
            // 检查父节点的选中状态
            while (treeNode.Parent != null)
            {
                if (treeNode.Checked)
                {
                    treeNode.Parent.Checked = treeNode.Checked;
                    treeNode = treeNode.Parent;
                }
                else
                {
                    break;
                }
            }
        }

        public void CheckParentChecked()
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                TreeNode treeNode = this.tvModule.Nodes[i];
                this.CheckParentChecked(treeNode);
            }
        }

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool DoBatchSave()
        {
            bool returnValue = true;
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvModule.Nodes[i]);
            }
            string[] grantModuleIds = null;
            string[] revokeModuleIds = null;
            if (this.GrantModules.Length > 2)
            {
                this.GrantModules = this.GrantModules.Substring(0, this.GrantModules.Length - 1);
                grantModuleIds = this.GrantModules.Split(';');
            }
            if (this.RevokeModules.Length > 1)
            {
                this.RevokeModules = this.RevokeModules.Substring(0, this.RevokeModules.Length - 1);
                revokeModuleIds = this.RevokeModules.Split(';');
            }
            this.GrantModules = string.Empty;
            this.RevokeModules = string.Empty;
            RDIFrameworkService.Instance.PermissionService.GrantUserModuleScope(UserInfo, this.txtUser.Tag.ToString(), "Resource.AccessPermission", grantModuleIds);
            RDIFrameworkService.Instance.PermissionService.GrantUserModuleScope(UserInfo, this.txtUser.Tag.ToString(), "Resource.AccessPermission", revokeModuleIds);
            if (SystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0012);
            }
            return returnValue;
        }
        #endregion

        public void BatchSave()
        {
            // 批量保存
            // this.CheckParentChecked();
            if (this.DoBatchSave())
            {
                // 关闭窗口
                this.Close();
            }
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.BatchSave();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }
    }
}
