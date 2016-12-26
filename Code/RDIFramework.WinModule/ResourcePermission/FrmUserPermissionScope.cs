﻿using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserPermissionScopes
    /// 用户授权管理范围明细
    /// 
    /// </summary>
    public partial class FrmUserPermissionScope : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

        /// <summary>
        /// 组织机构列表 DataTable
        /// </summary>
        private DataTable DTOrganize = new DataTable(PiOrganizeTable.TableName);

        private string[] OrganizeIds = null;

        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(PiModuleTable.TableName);

        private string[] ModuleIds = null;

        /// <summary>
        /// 操作权限项数据
        /// </summary>
        public DataTable DTPermissionItem = new DataTable(PiPermissionItemTable.TableName);

        private string[] PermissionItemIds = null;

        /// <summary>
        /// 目标用户主键
        /// </summary>
        public string TargetUserId
        {
            get
            {
                string userId = string.Empty;
                if (this.txtUser.Tag != null)
                {
                    userId = this.txtUser.Tag.ToString();
                }
                return userId;
            }
            set
            {
                this.txtUser.Tag = value;
                // 用户名称
                if (!string.IsNullOrEmpty(this.txtUser.Tag.ToString()))
                {
                    var RDIFrameworkService = new RDIFrameworkService();
                    var userEntity = RDIFrameworkService.UserService.GetEntity(UserInfo, this.txtUser.Tag.ToString());
                    if (RDIFrameworkService.UserService is ICommunicationObject)
                    {
                        ((ICommunicationObject)RDIFrameworkService.UserService).Close();
                    }

                    this.txtUser.Text = userEntity != null ? userEntity.RealName : string.Empty;
                }
                else
                {
                    this.txtUser.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmUserPermissionScope()
        {
            InitializeComponent();
        }

        public FrmUserPermissionScope(string userId)
            : this()
        {
            this.TargetUserId = userId;
        }

        #region private void GetUserList() 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void GetUserList()
        {
            // 是否启用了权限范围管理
            if (SystemInfo.EnableUserAuthorizationScope && !this.UserInfo.IsAdministrator)
            {
                this.DTUser = RDIFrameworkService.Instance.PermissionService.GetUserDTByPermissionScope(this.UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            else
            {
                this.DTUser = RDIFrameworkService.Instance.UserService.GetDT(this.UserInfo);
            }
            this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            this.cklstUser.DataSource = this.DTUser.DefaultView;
            this.cklstUser.ValueMember = PiUserTable.FieldId;
            this.cklstUser.DisplayMember = PiUserTable.FieldRealName;
        }
        #endregion

        #region private void GetRoleList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoleList()
        {
            // 是否启用了权限范围管理
            if (SystemInfo.EnableUserAuthorizationScope && !this.UserInfo.IsAdministrator)
            {
                this.DTRole = RDIFrameworkService.Instance.PermissionService.GetRoleDTByPermissionScope(this.UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            else
            {
                this.DTRole = RDIFrameworkService.Instance.RoleService.GetDT(this.UserInfo);
            }
            this.DTRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.cklstRole.DataSource = this.DTRole.DefaultView;
            this.cklstRole.ValueMember = PiRoleTable.FieldId;
            this.cklstRole.DisplayMember = PiRoleTable.FieldRealName;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("permissionScopes");
            this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            
            var permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemScopeCode);
            this.txtPermissionScope.Tag           = permissionItemEntity.Id.ToString();
            this.txtPermissionScope.Text          = permissionItemEntity.Code;

            // 获得用户列表
            this.GetUserList();

            // 获得角色列表
            this.GetRoleList();

            this.DTOrganize = RDIFrameworkService.Instance.OrganizeService.GetDTByValues(UserInfo, new string[] { PiOrganizeTable.FieldIsInnerOrganize, PiOrganizeTable.FieldEnabled, PiOrganizeTable.FieldDeleteMark }, new object[] { 1, 1, 0 });//RDIFrameworkService.Instance.MessageService.GetInnerOrganizeDT(UserInfo);

            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);

            this.DTModule = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);

            this.LoadTree();

            // 获取用户的权限
            this.GetCurrentPermission();

            this.isUserClick = true;
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            this.LoadTreeOrganize();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();

            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            this.LoadTreeModule();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();

            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermissionItem.BeginUpdate();
            this.tvPermissionItem.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermissionItem.EndUpdate();
        }
        #endregion

        private void LoadTreeOrganize()
        {
            var treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
        }

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
            BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode,true,2);
        }
        #endregion

        private void LoadTreeModule()
        {
            var treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
        }

        #region private void LoadTreeModule(TreeNode treeNode) 加载模块菜单树
        /// <summary>
        /// 加载模块菜单树
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId, PiModuleTable.FieldFullName, this.tvModule, treeNode,true,1);
        }
        #endregion

        private void LoadTreePermissionItem()
        {
            var treeNode = new TreeNode();
            this.LoadTreePermissionItem(treeNode);
        }

        #region private void LoadTreePermissionItem(TreeNode treeNode) 加载操作权限树
        /// <summary>
        /// 加载操作权限树
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermissionItem(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTPermissionItem, PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldParentId, PiPermissionItemTable.FieldFullName, this.tvPermissionItem, treeNode,true,2);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            // this.ClearCheck();
            // 获取角色的权限
            this.GetUserPermission();

            // 这些空间可以用了
            this.cklstUser.Enabled = true;
            this.cklstRole.Enabled = true;
            this.tvOrganize.Enabled = true;
            this.tvModule.Enabled = true;
            this.tvPermissionItem.Enabled = true;
            this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
        }

        /// <summary>
        /// 获取当权角色中的用户列表
        /// </summary>
        private void GetUserUsers()
        {
            // 获取当前角色中的用户
            string[] userIds = RDIFrameworkService.Instance.PermissionService.GetScopeUserIdsByUserId(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            // 把当前的用户设置为选中状态
            if (userIds == null || userIds.Length <= 0) return;
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                string userId = ((System.Data.DataRowView)this.cklstUser.Items[i])[PiUserTable.FieldId].ToString();
                if (Array.IndexOf(userIds, userId) >= 0)
                {
                    this.cklstUser.SetItemChecked(i, true);
                }
            }
        }

        /// <summary>
        /// 获取当权角色中的角色列表
        /// </summary>
        private void GetUserRoles()
        {
            // 获取当前角色中的用户
            var roleIds = RDIFrameworkService.Instance.PermissionService.GetScopeRoleIdsByUserId(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            // 把当前的用户设置为选中状态
            if (roleIds == null || roleIds.Length <= 0) return;
            for (int i = 0; i < this.cklstRole.Items.Count; i++)
            {
                var roleId = ((System.Data.DataRowView)this.cklstRole.Items[i])[PiRoleTable.FieldId].ToString();
                if (Array.IndexOf(roleIds, roleId) >= 0)
                {
                    this.cklstRole.SetItemChecked(i, true);
                }
            }
        }

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetUserPermission()
        {
            // 获取当权角色中的用户列表
            this.GetUserUsers();
            this.GetUserRoles();

            this.OrganizeIds = RDIFrameworkService.Instance.PermissionService.GetScopeOrganizeIdsByUserId(UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            if (this.OrganizeIds != null && this.OrganizeIds.Length > 0)
            {
                this.tvOrganize.BeginUpdate();
                this.OrganizeCheck();
                this.tvOrganize.EndUpdate();
            }

            // 获取模块访问权限
            this.ModuleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByUserId(UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            if (this.ModuleIds != null && this.ModuleIds.Length > 0)
            {
                this.tvModule.BeginUpdate();
                this.ModuleCheck();
                this.tvModule.EndUpdate();
            }
            // 获得用户的权限主键数组
            this.PermissionItemIds = RDIFrameworkService.Instance.PermissionService.GetScopePermissionItemIdsByUserId(UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            if (this.PermissionItemIds != null && this.PermissionItemIds.Length > 0)
            {
                this.tvPermissionItem.BeginUpdate();
                this.PermissionItemCheck();
                this.tvPermissionItem.EndUpdate();
            }
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
            // 用户被选中状态取消
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                this.cklstUser.SetItemChecked(i, false);
            }
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvOrganize.Nodes[i]);
            }
            // 模块菜单选中状态被取消
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvModule.Nodes[i]);
            }
            // 操作权限项被选中状态取消
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void OrganizeCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.OrganizeCheck(this.tvOrganize.Nodes[i]);
            }
        }

        private void OrganizeCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null) || (treeNode.Tag as DataRow) == null) return;
            var permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            treeNode.Checked = Array.IndexOf(this.OrganizeIds, permissionItemId) >= 0;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.OrganizeCheck(treeNode.Nodes[i]);
            }
        }

        private void ModuleCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleCheck(this.tvModule.Nodes[i]);
            }
        }

        private void ModuleCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null) || (treeNode.Tag as DataRow) == null) return;
            string permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            treeNode.Checked = Array.IndexOf(this.ModuleIds, permissionItemId) >= 0;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModuleCheck(treeNode.Nodes[i]);
            }
        }

        private void PermissionItemCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionItemCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void PermissionItemCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
            string permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            treeNode.Checked = Array.IndexOf(this.PermissionItemIds, permissionItemId) >= 0;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.PermissionItemCheck(treeNode.Nodes[i]);
            }
        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            RDIFrameworkService.Instance.PermissionService.ClearUserPermissionScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode);
            // 获取用户的权限
            this.GetCurrentPermission();
            this.isUserClick = true;
        }

        private string GrantUsers = string.Empty;
        private string GrantRoles = string.Empty;

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var permissionScopes = new PermissionScopes();
            // 模块访问权限复制到剪切板
            for (int i = 0; i < this.cklstUser.CheckedItems.Count; i++)
            {
                var userEntity = BaseEntity.Create<PiUserEntity>(((System.Data.DataRowView)this.cklstUser.CheckedItems[i]).Row); 
                this.GrantUsers += userEntity.Id.ToString() + ";";
            }
            var grantUserIds = this.GrantUsers.Split(';');
            permissionScopes.GrantUserIds = grantUserIds;

            for (int i = 0; i < this.cklstRole.CheckedItems.Count; i++)
            {
                var roleEntity = BaseEntity.Create<PiRoleEntity>(((System.Data.DataRowView)this.cklstRole.CheckedItems[i]).Row);
                this.GrantRoles += roleEntity.Id.ToString() + ";";
            }
            string[] grantRoleIds = this.GrantRoles.Split(';');
            permissionScopes.GrantRoleIds = grantRoleIds;

            string[] grantOrganizeIds = this.GetGrantOrganizeIds();
            permissionScopes.GrantOrganizeIds = grantOrganizeIds;
            string[] grantModuleIds = this.GetGrantModuleIds();
            permissionScopes.GrantModuleIds = grantModuleIds;
            string[] grantPermissionIds = this.GetGrantPermissionIds();
            permissionScopes.GrantPermissionIds = grantPermissionIds;
            Clipboard.SetData("permissionScopes", permissionScopes);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("permissionScopes");
            if (clipboardData != null)
            {
                PermissionScopes permissionScopes = (PermissionScopes)clipboardData;
                string[] grantUserIds = permissionScopes.GrantUserIds;
                RDIFrameworkService.Instance.PermissionService.GrantUserUserScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantUserIds);
                string[] grantRoleIds = permissionScopes.GrantRoleIds;
                RDIFrameworkService.Instance.PermissionService.GrantUserRoleScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantRoleIds);
                string[] grantOrganizeIds = permissionScopes.GrantOrganizeIds;
                RDIFrameworkService.Instance.PermissionService.GrantUserOrganizeScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantOrganizeIds);
                string[] grantModuleIds = permissionScopes.GrantModuleIds;
                RDIFrameworkService.Instance.PermissionService.GrantUserModuleScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantModuleIds);
                string[] grantPermissionIds = permissionScopes.GrantPermissionIds;
                RDIFrameworkService.Instance.PermissionService.GrantUserPermissionItemScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantPermissionIds);

                this.GetCurrentPermission();
            }
        }

        private void cklstUser_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!this.isUserClick) return;
            var itemChecked = this.cklstUser.GetItemChecked(this.cklstUser.SelectedIndex);
            var userId = ((System.Data.DataRowView)this.cklstUser.Items[e.Index])[PiUserTable.FieldId].ToString();
            if (itemChecked)
            {
                // 被撤销了
                RDIFrameworkService.Instance.PermissionService.RevokeUserUserScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, new string[] { userId });
            }
            else
            {
                RDIFrameworkService.Instance.PermissionService.GrantUserUserScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, new string[] { userId });
            }
        }

        private void cklstRole_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!this.isUserClick) return;
            bool itemChecked = this.cklstRole.GetItemChecked(this.cklstRole.SelectedIndex);
            string roleId = ((System.Data.DataRowView)this.cklstRole.Items[e.Index])[PiRoleTable.FieldId].ToString();
            if (itemChecked)
            {
                // 被撤销了
                RDIFrameworkService.Instance.PermissionService.RevokeUserRoleScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, new string[] { roleId });
            }
            else
            {
                RDIFrameworkService.Instance.PermissionService.GrantUserRoleScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, new string[] { roleId });
            }
        }

        private void tvOrganize_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.isUserClick) return;
            if (e.Node.Checked)
            {
                string[] grantOrganizeIds = new string[] { (e.Node.Tag as DataRow)[PiOrganizeTable.FieldId].ToString() };
                // 授予操作权限
                RDIFrameworkService.Instance.PermissionService.GrantUserOrganizeScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantOrganizeIds);
            }
            else
            {
                string[] revokeOrganizeIds = new string[] { (e.Node.Tag as DataRow)[PiOrganizeTable.FieldId].ToString() };
                // 撤销操作权限
                RDIFrameworkService.Instance.PermissionService.RevokeUserOrganizeScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, revokeOrganizeIds);
            }
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvModule_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.isUserClick) return;
            if (e.Node.Checked)
            {
                // 授予操作权限
                string[] grantModuleIds = new string[] { (e.Node.Tag as DataRow)[PiModuleTable.FieldId].ToString() };
                RDIFrameworkService.Instance.PermissionService.GrantUserModuleScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantModuleIds);
            }
            else
            {
                string[] revokeModuleIds = new string[] { (e.Node.Tag as DataRow)[PiModuleTable.FieldId].ToString() };
                // 撤销操作权限
                RDIFrameworkService.Instance.PermissionService.RevokeUserModuleScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, revokeModuleIds);
            }
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }
        }

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvPermissionItem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.isUserClick) return;
            if (e.Node.Checked)
            {
                // 授予操作权限
                string[] grantPermissionIds = new string[] { (e.Node.Tag as DataRow)[PiPermissionItemTable.FieldId].ToString() };
                RDIFrameworkService.Instance.PermissionService.GrantUserPermissionItemScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, grantPermissionIds);
            }
            else
            {
                string[] revokePermissionIds = new string[] { (e.Node.Tag as DataRow)[PiPermissionItemTable.FieldId].ToString() };
                // 撤销操作权限
                RDIFrameworkService.Instance.PermissionService.RevokeUserPermissionItemScope(this.UserInfo, this.TargetUserId, this.PermissionItemScopeCode, revokePermissionIds);
            }

            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }
        }

        private void tvPermissionItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvPermissionItem.GetNodeAt(e.X, e.Y) != null)
            {
                tvPermissionItem.SelectedNode = tvPermissionItem.GetNodeAt(e.X, e.Y);
            }
        }


        /// <summary>
        /// 授权的组织机构权限
        /// </summary>
        private string GrantOrganizes = string.Empty;

        private void OrganizeEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                var organizeId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantOrganizes += organizeId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.OrganizeEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantOrganizeIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantOrganizeIds()
        {
            for (int i = 0; i < this.tvOrganize.Nodes.Count; i++)
            {
                this.OrganizeEntityToArray(this.tvOrganize.Nodes[i]);
            }
            string[] grantOrganizeIds = null;
            if (this.GrantOrganizes.Length > 2)
            {
                this.GrantOrganizes = this.GrantOrganizes.Substring(0, this.GrantPermissions.Length - 1);
                grantOrganizeIds = this.GrantOrganizes.Split(';');
            }
            this.GrantOrganizes = string.Empty;
            return grantOrganizeIds;
        }
        #endregion

        /// <summary>
        /// 授权的模块访问权限
        /// </summary>
        private string GrantModules = string.Empty;

        private void ModuleEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                var moduleId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    var grantModules = this.GrantModules;
                    if (grantModules != null) this.GrantModules += moduleId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ModuleEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantModuleIds() 批量获取模块访问权限选中状态
        /// <summary>
        /// 批量获取模块访问权限选中状态
        /// </summary>
        private string[] GetGrantModuleIds()
        {
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleEntityToArray(this.tvModule.Nodes[i]);
            }
            string[] grantModuleIds = null;
            if (this.GrantModules.Length > 2)
            {
                this.GrantModules = this.GrantModules.Substring(0, this.GrantModules.Length - 1);
                grantModuleIds = this.GrantModules.Split(';');
            }
            this.GrantModules = string.Empty;
            return grantModuleIds;
        }
        #endregion

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantPermissions = string.Empty;

        private void PermissionEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                // 提高运行速度
                var permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantPermissions += permissionItemId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.PermissionEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantPermissionIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantPermissionIds()
        {
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionEntityToArray(this.tvPermissionItem.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            return grantPermissionIds;
        }
        #endregion 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
