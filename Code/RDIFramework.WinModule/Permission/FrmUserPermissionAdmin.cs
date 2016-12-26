/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-4 9:52:43
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
    /// FrmUserPermissionAdmin.cs
    /// 用户权限管理
    /// 
    /// </summary>
    public partial class FrmUserPermissionAdmin : BaseForm
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 组织机构 DataTable
        /// </summary>
        private DataTable DTOrganize = new DataTable(PiOrganizeTable.TableName);

        /// <summary>
        /// 组织机构 DataTable
        /// </summary>
        private DataTable DTOrganizeList = new DataTable(PiOrganizeTable.TableName);

        /// <summary>
        /// 用户角色
        /// </summary>
        private bool permissionUserRole = false;

        /// <summary>
        /// 用户权限
        /// </summary>
        private bool permissionUserPermission = false;

        /// <summary>
        /// 角色用户批量设置
        /// </summary>
        private bool permissionRoleUserBatchSet = false;

        /// <summary>
        /// 批量权限设置
        /// </summary>
        private bool permissionBatchPermission = false;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionUserAuthorization = false;

        /// <summary>
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmUserPermissionAdmin()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad()
        private void FormOnLoad(bool loadUser, string searchValue)
        {
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);

            if (this.DTOrganize != null && this.DTOrganize.Rows.Count > 0)
            {
                this.LoadTreeOrganize();
                if (!UserInfo.IsAdministrator && SystemInfo.EnableUserAuthorizationScope &&
                    this.tvOrganize.Nodes.Count > 0)
                {
                    this.tvOrganize.SelectedNode = tvOrganize.Nodes[0];
                }

                this.Search(true);
                this.SetRowFilter();
            }
        }

        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvInfo);
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            this.FormOnLoad(SystemInfo.LoadAllUser, string.Empty);
            // 若有过滤条件，要进行数据过滤
            this.SetRowFilter();
        }
        #endregion

        #region public override string EntityId 用户主键
        /// <summary>
        /// 用户主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiUserTable.FieldId);
            }
        }
        #endregion

        #region public string CurrentEntityId 当前选种的ID
        /// <summary>
        /// 当前选种的ID
        /// </summary>
        private string entityId = string.Empty;
        public string CurrentEntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }
        #endregion

        #region public string OrganizeId 组织机构主键
        private string organizeId = string.Empty;
        /// <summary>
        /// 组织机构主键
        /// </summary>
        public string OrganizeId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    if (this.tvOrganize.SelectedNode.Tag is DataRow)
                    {
                        this.organizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[PiOrganizeTable.FieldId].ToString();
                    }
                    else
                    {
                        this.organizeId = this.tvOrganize.SelectedNode.Tag.ToString();
                    }
                }
                else
                {
                    this.organizeId = string.Empty;
                }
                return this.organizeId;
            }
            set
            {
                this.organizeId = value;
            }
        }
        #endregion

        #region public override void SetHelp() 设置帮助信息
        /// <summary>
        /// 设置帮助信息
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region public override void GetPermission() 获得权限
        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {
            this.IsModuleAuthorized("UserPermissionAdmin");
            this.permissionUserRole          = this.IsAuthorized("UserPermissionAdmin.UserRole");
            this.permissionUserPermission    = this.IsAuthorized("UserPermissionAdmin.UserPermission");
            this.permissionRoleUserBatchSet  = this.IsAuthorized("UserPermissionAdmin.RoleUserBatchSet");
            this.permissionBatchPermission   = this.IsAuthorized("UserPermissionAdmin.BatchPermission");
            this.permissionUserAuthorization = this.IsAuthorized("UserPermissionAdmin.UserAuthorization");
        }
        #endregion

        #region public override void SetControlState() 按钮的状态设置
        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {
            this.btnUserRole.Enabled         = false;
            this.btnPermission.Enabled       = false;
            this.btnRoleUserBatchSet.Enabled = false;
            this.btnBatchPermission.Enabled  = false;           
            this.btnTableFieldPermission.Enabled = false;
            this.btnUserTableConstraintSet.Enabled = false;
            this.btnDropDownPermission.Visible = SystemInfo.EnableUserAuthorizationScope || SystemInfo.EnableTableFieldPermission || SystemInfo.EnableTableConstraintPermission;
            this.btnUserPermissionScope.Visible = SystemInfo.EnableUserAuthorizationScope;
            this.btnTableFieldPermission.Visible = SystemInfo.EnableTableFieldPermission;
            this.btnUserTableConstraintSet.Visible = SystemInfo.EnableTableConstraintPermission;
            // 是否有数据的判断
            if (this.DTUser.DefaultView.Count > 0)
            {
                this.btnUserRole.Enabled         = permissionUserRole;
                this.btnPermission.Enabled       = permissionUserPermission;
                this.btnRoleUserBatchSet.Enabled = permissionRoleUserBatchSet;
                this.btnBatchPermission.Enabled  = permissionBatchPermission;
                this.btnUserPermissionScope.Enabled = permissionUserAuthorization;
                this.btnUserTableConstraintSet.Enabled = permissionUserAuthorization;
                this.btnTableFieldPermission.Enabled = permissionUserAuthorization;
            }
            
            // 超级管理员不需要设置权限
            DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
            if (dataRow != null)
            {
                PiUserEntity userEntity = BaseEntity.Create<PiUserEntity>(dataRow); 
                // 超级管理员没必要设置权限，以免增加误解
                if (userEntity.Code != null && userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
                {
                    this.btnUserPermissionScope.Enabled = false;
                    this.btnBatchPermission.Enabled = false;
                    this.btnPermission.Enabled = false;
                    this.btnRoleUserBatchSet.Enabled = false;
                    this.btnUserTableConstraintSet.Enabled = false;
                    this.btnTableFieldPermission.Enabled = false;
                }
            }
        }
        #endregion       

        #region private void BindData() 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            this.dgvInfo.AutoGenerateColumns = false;
            if (this.DTUser.Columns.Count > 0)
            {
                this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            }

            this.dgvInfo.DataSource = this.DTUser.DefaultView;
            if (this.CurrentEntityId.Length > 0)
            {
                this.dgvInfo.FirstDisplayedScrollingRowIndex = BasePageLogic.GetRowIndex(this.DTUser, PiUserTable.FieldId, this.CurrentEntityId);
            }
            this.SetControlState();
        }

        private void Search(bool? enabled)
        {
            var recordCount = 0;
            if (!string.IsNullOrEmpty(this.OrganizeId))
            {
                this.DTUser = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize, enabled);
            }
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.BindData();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize, bool? enabled = true)
        {
            var searchValue = this.txtSearch.Text;
            return RDIFrameworkService.Instance.UserService.GetUserPageDTByDepartment(UserInfo, this.PermissionItemScopeCode, searchValue, enabled, string.Empty, null, true, true, out recordCount, pageIndex, pageSize, PiUserTable.FieldSortCode, OrganizeId);
        }
        #endregion

        #region private void LoadTreeOrganize() 加载组织机构树
        /// <summary>
        /// 加载组织机构树
        /// </summary>
        private void LoadTreeOrganize()
        {
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            var treeNode = new TreeNode { ImageIndex = 0, SelectedImageIndex = 0 };
            this.LoadTreeOrganize(treeNode);
            if (this.tvOrganize.Nodes.Count > 0)
            {
                this.tvOrganize.Nodes[0].Expand();
            }
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode, !SystemInfo.OrganizeDynamicLoading);
        }

        private void OrganzieTreeImange(TreeNode tNode, string organizeCategory)
        {
            switch (organizeCategory.ToLower())
            {
                case "compay":
                    tNode.ImageIndex = 0;
                    tNode.SelectedImageIndex = 0;
                    break;
                case "subcompay":
                    tNode.ImageIndex = 1;
                    tNode.SelectedImageIndex = 1;
                    break;
                case "department":
                    tNode.ImageIndex = 2;
                    tNode.SelectedImageIndex = 2;
                    break;
                case "subdepartment":
                    tNode.ImageIndex = 3;
                    tNode.SelectedImageIndex = 3;
                    break;
                case "workgroup":
                    tNode.ImageIndex = 4;
                    tNode.SelectedImageIndex = 4;
                    break;
                default:
                    tNode.ImageIndex = 5;
                    tNode.SelectedImageIndex = 5;
                    break;
            }
        }
        #endregion

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            this.tvOrganize.BeginUpdate();
            this.DTOrganizeList = RDIFrameworkService.Instance.OrganizeService.GetDTByParent(UserInfo, this.OrganizeId);
            this.DTOrganizeList.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                foreach (DataRow dr in this.DTOrganizeList.Rows)
                {
                    var treeNode = new TreeNode
                    {
                        Text = dr[PiOrganizeTable.FieldFullName].ToString(),
                        Tag = dr[PiOrganizeTable.FieldId].ToString()
                    };
                    OrganzieTreeImange(treeNode, dr[PiOrganizeTable.FieldCategory].ToString());
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
            }
            this.tvOrganize.EndUpdate();
            this.tvOrganize.SelectedNode.Expand();
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            var search = this.txtSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Columns.Count > 1)
                {
                    search = BusinessLogic.GetSearchString(search);
                    this.DTUser.DefaultView.RowFilter = PiUserTable.FieldUserName + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldRealName + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldCode + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldDepartmentName + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldDescription + " LIKE '" + search + "'";
                }
            }
        }
        #endregion

        private void btnTableFieldPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmTableFieldPermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmTableColumnPermission = (Form)Activator.CreateInstance(assemblyType, PiUserTable.TableName, this.TargetUserId);
            frmTableColumnPermission.ShowDialog(this);
        }

        private void btnUserTableConstraintSet_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmTableConstraint";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, PiUserTable.TableName, this.TargetUserId);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnRoleUserBatchSet_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserRoleBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserRoleBatchSet = (Form)Activator.CreateInstance(assemblyType);
            frmUserRoleBatchSet.ShowDialog(this);
        }

        private void btnBatchPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserPermissionBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }
      
        public string TargetUserId
        {
            get
            {
                DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                string userId = dataRow[PiUserTable.FieldId].ToString();
                return userId;
            }
        }

        public string TargetUserRealName
        {
            get
            {
                DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                return dataRow[PiUserTable.FieldRealName].ToString();
            }
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
            string id = dataRow[PiUserTable.FieldId].ToString();
            string realName = dataRow[PiUserTable.FieldRealName].ToString();

            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserRoleAdmin";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, id, realName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        protected virtual void btnPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserPermission";
            // 若不采用操作权限，直接设置模块权限
            if (!SystemInfo.EnablePermissionItem)
            {
                formName = "FrmUserModulePermission";
            }
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.TargetUserId, this.TargetUserRealName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnUserPermissionScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserPermissionScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionScopes = (Form)Activator.CreateInstance(assemblyType, this.TargetUserId);
            frmUserPermissionScopes.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.tvOrganize.SelectedNode != null)
            {
                tvOrganize.PathSeparator = ">";
                lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
            }
            if (this.FormLoaded)
            {
                this.GetOrganizeList();
                this.Search(null);
            }
            this.Cursor = holdCursor;
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Search(null);
            this.Cursor = holdCursor;
        }

        private void dgvInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置按钮状态
                this.SetControlState();
            }
        }
    }
}
