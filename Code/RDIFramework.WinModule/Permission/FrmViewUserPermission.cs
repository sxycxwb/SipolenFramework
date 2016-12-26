using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmViewUserPermission
    /// 用户权限-查看指定用户所拥有的所有相关权限
    /// 
    /// </summary>
    public partial class FrmViewUserPermission : BaseForm
    {
        public string TargetUserId = string.Empty;

        private DataTable DTModule = new DataTable(PiModuleTable.TableName);

        private DataTable DTPermissionItem = new DataTable(PiPermissionItemTable.TableName);

        private string[] ModuleIds = null;

        private string[] PermissionItemIds = null;

        public FrmViewUserPermission()
        {
            InitializeComponent();
        }

        public FrmViewUserPermission(string userId)
            : this()
        {
            this.TargetUserId = userId;
        }

        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty(this.TargetUserId))
            {
                this.TargetUserId = this.UserInfo.Id;
            }

            // 显示用户信息
            this.ShowUserEntity();

            // 显示角色列表
            this.ShowRoleList();

            // 显示菜单权限
            this.ShowModule();

            // 显示操作权限
            this.ShowPermissionItem();

            // 显示数据集权限
            //this.GetTableScope();
        }

        public override void SetControlState()
        {
            this.btnShowRolePermission.Enabled = this.dgvInfo.RowCount > 0;
        }

        #region private void ShowUserEntity() 显示内容
        /// <summary>
        /// 显示用户信息
        /// </summary>
        private void ShowUserEntity()
        {
            var userEntity = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.TargetUserId);
            // 绑定用户信息
            this.txtUserName.Text = userEntity.UserName;
            this.txtRealName.Text = userEntity.RealName;
            if (userEntity.RoleId == null) return;
            var roleEntity = RDIFrameworkService.Instance.RoleService.GetEntity(this.UserInfo, userEntity.RoleId.ToString());
            this.txtRole.Text = roleEntity.RealName;
        }
        #endregion

        #region private void ShowRoleList() 显示角色
        private void ShowRoleList()
        {
            var roleIds = RDIFrameworkService.Instance.UserService.GetUserRoleIds(UserInfo, this.TargetUserId);
            var DTRole = RDIFrameworkService.Instance.RoleService.GetDTByIds(UserInfo, roleIds);
            DTRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.DataSource = DTRole;
        }
        #endregion

        private void btnShowRolePermission_Click(object sender, EventArgs e)
        {
            var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
            var id = dataRow[PiRoleTable.FieldId].ToString();
            var realName = dataRow[PiRoleTable.FieldRealName].ToString();

            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmRoleModulePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermission = (Form)Activator.CreateInstance(assemblyType, id, realName, true);
            frmRolePermission.ShowDialog(this);
        }

        #region 显示菜单权限

        #region  private void ShowModule() 显示菜单权限
        private void ShowModule()
        {
            this.ModuleIds = RDIFrameworkService.Instance.PermissionService.GetModuleIdsByUserId(UserInfo, this.TargetUserId);
            this.DTModule = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);
            BusinessLogic.SetFilter(this.DTModule, PiModuleTable.FieldEnabled, "1");
            this.BindModule(true);
        }
        #endregion

        #region private void BindModule(bool reloadTree) 绑定菜单权限
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载模块树</param>
        private void BindModule(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                this.LoadModuleTree();
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
            this.CheckModule();
        }
        #endregion

        #region private void LoadModuleTree() 加载树的
        /// <summary>
        /// 加载树的
        /// </summary>
        private void LoadModuleTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModuleItem(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModuleItem(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModuleItem(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId, PiModuleTable.FieldFullName, this.tvModule, treeNode, true, 1, PiModuleTable.FieldCode);
        }
        #endregion

        private void CheckModule()
        {
            // 获得用户的权限主键数组
            this.ModuleIds = RDIFrameworkService.Instance.PermissionService.GetModuleIdsByUserId(UserInfo, this.TargetUserId);
            if (this.ModuleIds != null && this.ModuleIds.Length > 0)
            {
                this.tvModule.BeginUpdate();
                this.ModuleCheck();
                this.tvModule.EndUpdate();
            }
        }

        private void ModuleCheck()
        {
            // 如果是管理员拥有所有权限
            if (this.UserInfo.IsAdministrator)
            {
                // 递归调用到所有的子节点 
                for (int i = 0; i < this.tvModule.Nodes.Count; i++)
                {
                    this.tvModule.Nodes[i].Checked = true;
                    BasePageLogic.CheckChild(this.tvModule.Nodes[i]);
                }
                return;
            }
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.ModuleCheck(this.tvModule.Nodes[i]);
            }
        }

        private void ModuleCheck(TreeNode treeNode)
        {
            if (treeNode != null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                string moduleId = (treeNode.Tag as DataRow)[PiModuleTable.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.ModuleIds, moduleId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.ModuleCheck(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        #region 显示操作权限

        #region   private void ShowPermissionItem() 显示操作权限
        private void ShowPermissionItem()
        {
            this.PermissionItemIds = RDIFrameworkService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.TargetUserId);
            this.DTPermissionItem = RDIFrameworkService.Instance.PermissionItemService.GetDT(this.UserInfo);
            BusinessLogic.SetFilter(this.DTModule, PiModuleTable.FieldEnabled, "1");
            this.BindPermissionItem(true);
        }
        #endregion

        #region private void BindPermissionItem(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载模块树</param>
        private void BindPermissionItem(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                this.LoadPermissionTree();
            }
            if (this.tvPermissionItem.SelectedNode == null && this.tvPermissionItem.Nodes.Count > 0)
            {
                this.tvPermissionItem.SelectedNode = this.tvPermissionItem.Nodes[0];
            }
            if (this.tvPermissionItem.SelectedNode != null)
            {
                // 让选中的节点可视，并用展开方式
                this.tvPermissionItem.SelectedNode.Expand();
                this.tvPermissionItem.SelectedNode.EnsureVisible();
            }
            this.CheckPemissionItem();
        }
        #endregion

        #region private void LoadPermissionTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadPermissionTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermissionItem.BeginUpdate();
            this.tvPermissionItem.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermissionItem(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermissionItem.EndUpdate();
        }
        #endregion

        #region private void LoadTreePermissionItem(TreeNode treeNode) 加载操作权限树的主键

        /// <summary>
        /// 加载操作权限树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermissionItem(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTPermissionItem, PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldParentId, PiPermissionItemTable.FieldFullName, this.tvPermissionItem, treeNode, true, 2, PiPermissionItemTable.FieldCode);
        }
        #endregion

        private void CheckPemissionItem()
        {
            // 如果是管理员拥有所有权限
            if (this.UserInfo.IsAdministrator)
            {
                // 递归调用到所有的子节点 
                for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
                {
                    this.tvPermissionItem.Nodes[i].Checked = true;
                    BasePageLogic.CheckChild(this.tvPermissionItem.Nodes[i]);
                }
                return;
            }
            // 获得用户的权限主键数组
            this.PermissionItemIds = RDIFrameworkService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.TargetUserId);
            if (this.PermissionItemIds != null && this.PermissionItemIds.Length > 0)
            {
                this.tvPermissionItem.BeginUpdate();
                this.PermissionItemCheck();
                this.tvPermissionItem.EndUpdate();
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
            if (treeNode != null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                string permissionItemId = (treeNode.Tag as DataRow)[PiModuleTable.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.PermissionItemIds, permissionItemId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.PermissionItemCheck(treeNode.Nodes[i]);
                }
            }
        }

        #endregion

        #region 显示数据集权限
        //private void GetTableScope()
        //{
        //    string resourceCategory = PiUserTable.TableName;
        //    string resourceId = this.TargetUserId;

        //    DataTable dataTableScope = RDIFrameworkService.Instance.TableColumnsService.GetConstraintDT(this.UserInfo, resourceCategory, resourceId);
        //    this.grdTable.AutoGenerateColumns = false;
        //    dataTableScope.DefaultView.Sort = CiItemDetailsTable.FieldSortCode;
        //    this.grdTable.DataSource = dataTableScope.DefaultView;
        //}
        #endregion

        private void tvModule_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            // 窗体已经加载完毕
            if (this.FormLoaded)
            {
                e.Cancel = true;
            }
        }

        private void tvPermissionItem_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.FormLoaded)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {          
            this.Close();
        }     
    }
}
