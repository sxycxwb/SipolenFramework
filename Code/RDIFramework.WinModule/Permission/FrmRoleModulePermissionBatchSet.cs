/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-19 15:04:05
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
    /// 角色模块（菜单）权限集中设置（FrmRoleModulePermissionBatchSet）
    /// 
    /// </summary>
    public partial class FrmRoleModulePermissionBatchSet : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(PiModuleTable.TableName);

        private string[] ModuleIds = null;

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetRoleId
        {
            get
            {
                string roleId = string.Empty;
                if (this.lbRoleList.SelectedItem != null)
                {
                    roleId = this.lbRoleList.SelectedValue.ToString();
                }
                return roleId;
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmRoleModulePermissionBatchSet()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("roleModulePermission");
            //this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            // 这里需要只把有效的模块显示出来
            BusinessLogic.SetFilter(this.DTModule, PiModuleTable.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BusinessLogic.SetFilter(this.DTModule, BaseModuleEntity.FieldDeletionStateCode, "0");

            this.LoadTree();

            // 获得角色列表
            this.GetRoleList();
            this.isUserClick = true;
        }
        #endregion

        #region private void GetRoleList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoleList()
        {
            // 是否启用了权限范围管理
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            // 对超级管理员不用设置权限
            BusinessLogic.SetFilter(this.DTRole, PiUserTable.FieldCode, DefaultRole.Administrators.ToString(), true);
            this.DTRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.lbRoleList.ValueMember = PiRoleTable.FieldId;
            this.lbRoleList.DisplayMember = PiRoleTable.FieldRealName;
            this.lbRoleList.DataSource = this.DTRole.DefaultView;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModuleList.BeginUpdate();
            this.tvModuleList.Nodes.Clear();
            this.LoadTreeModule();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModuleList.EndUpdate();
        }
        #endregion

        private void LoadTreeModule()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
        }

        #region private void LoadTreeModule(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId, PiModuleTable.FieldFullName, this.tvModuleList, treeNode,true,2);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetRolePermission();

            this.isUserClick = true;

            //this.btnClearPermission.Enabled = true;
            //this.btnCopy.Enabled = true;

            // 这些空间可以用了
            this.tvModuleList.Enabled = true;
        }

        private void lbRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.GetCurrentPermission();
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetRolePermission()
        {
            // 获取模块访问权限
            this.ModuleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByRoleId(UserInfo, this.TargetRoleId, "Resource.AccessPermission");
            if (this.ModuleIds == null || this.ModuleIds.Length <= 0) return;
            this.tvModuleList.BeginUpdate();
            this.ModuleCheck();
            this.tvModuleList.EndUpdate();
        }

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
            treeNode.Checked = false;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ClearCheck(treeNode.Nodes[i]);
            }
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {
            // 模块菜单选中状态被取消
            for (int i = 0; i < this.tvModuleList.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvModuleList.Nodes[i]);
            }
        }


        private void ModuleCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvModuleList.Nodes.Count; i++)
            {
                this.ModuleCheck(this.tvModuleList.Nodes[i]);
            }
        }

        private void ModuleCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
            string permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            treeNode.Checked = Array.IndexOf(this.ModuleIds, permissionItemId) >= 0;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModuleCheck(treeNode.Nodes[i]);
            }
        }

        [Serializable]
        private class RoleModulePermission
        {
            public string[] GrantModuleIds = null;
        }

        /// <summary>
        /// 授权的模块访问权限
        /// </summary>
        private string GrantModules = string.Empty;

        private void ModuleEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantModules += moduleId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModuleEntityToArray(treeNode.Nodes[i]);
            }
        }

        private void tvModuleListList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BasePageLogic.CheckChild(e.Node);
            BasePageLogic.CheckParent(e.Node);
        }

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
                    if (Array.IndexOf(this.ModuleIds, moduleId) < 0)
                    {
                        this.GrantModules += moduleId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.ModuleIds, moduleId) >= 0)
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

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool DoBatchSave()
        {
            bool returnValue = true;
            for (int i = 0; i < this.tvModuleList.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvModuleList.Nodes[i]);
            }
            string[] grantModuleIds = null;
            string[] revokeModuleIds = null;
            if (this.GrantModules.Length >= 2)
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

            if (grantModuleIds != null)
            {
                RDIFrameworkService.Instance.PermissionService.GrantRoleModuleScope(UserInfo, this.TargetRoleId,"Resource.AccessPermission", grantModuleIds);
            }

            if (revokeModuleIds != null)
            {
                RDIFrameworkService.Instance.PermissionService.RevokeRoleModuleScope(UserInfo, this.TargetRoleId,"Resource.AccessPermission", revokeModuleIds);
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.BatchSave();
        }

        private void tvModuleList_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                if (MessageBoxHelper.Show("数据已发生变化，是否保存（是/否）？") == System.Windows.Forms.DialogResult.OK)
                {
                    this.BatchSave();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
