using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 角色权限管理
    /// FrmRolePermissionAdmin
    /// 
    /// </summary>
    public partial class FrmRolePermissionAdmin : BaseForm
    {
        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的角色用户关联关系管理
        /// </summary>
        private bool permissionRoleUser = false;

        /// <summary>
        /// 本模块的角色用户批量设置管理
        /// </summary>
        private bool permissionRoleUserBatchSet = false;

        /// <summary>
        /// 本模块的用户角色授权权限
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetRoleId
        {
            get
            {
                DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                string roleId = dataRow[PiRoleTable.FieldId].ToString();
                return roleId;
            }
        }

        /// <summary>
        /// 目标角色名称
        /// </summary>
        public string TargetRoleRealName
        {
            get
            {
                DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                string roleRealName = dataRow[PiRoleTable.FieldRealName].ToString();
                return roleRealName;
            }
        }

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmRolePermissionAdmin()
        {
            InitializeComponent();
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cmbRoleCategory.Items.Count != 0) return;
            var dataTable = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(UserInfo, "RoleCategory");
            var dataRow     = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRoleCategory.DisplayMember  = CiItemDetailsTable.FieldItemName;
            this.cmbRoleCategory.ValueMember    = CiItemDetailsTable.FieldItemValue;
            this.cmbRoleCategory.DataSource     = dataTable.DefaultView;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnRolePermission.Enabled = false;
            this.btnRoleUser.Enabled = false;
            this.btnRoleUserBatchSet.Enabled = false;
            this.btnRoleTableConstraintSet.Enabled = false;
            this.btnTableFieldPermission.Enabled = false;
            this.btnRolePermissionScope.Enabled = false;
            this.btnBatchPermission.Enabled = false;
            this.btnDropDownPermission.Visible = SystemInfo.EnableUserAuthorizationScope || SystemInfo.EnableTableFieldPermission || SystemInfo.EnableTableConstraintPermission;
            this.btnRolePermissionScope.Visible = SystemInfo.EnableUserAuthorizationScope;
            this.btnTableFieldPermission.Visible = SystemInfo.EnableTableFieldPermission;
            this.btnRoleTableConstraintSet.Visible = SystemInfo.EnableTableConstraintPermission;
            // 是否采用了操作权限
            this.btnBatchPermission.Visible = SystemInfo.EnablePermissionItem;

            if ((this.DTRole.DefaultView.Count >= 1))
            {             
                this.btnRolePermission.Enabled = this.permissionAccredit;
                this.btnRoleUser.Enabled = this.permissionRoleUser;
                this.btnRoleUserBatchSet.Enabled = this.permissionRoleUserBatchSet;
                this.btnRoleTableConstraintSet.Enabled = this.permissionAccredit;
                this.btnTableFieldPermission.Enabled = this.permissionAccredit;
                this.btnRolePermissionScope.Enabled = this.permissionAccredit;
                this.btnBatchPermission.Enabled = this.permissionAccredit;
            }         
           
            // 用户组是不需要进行权限配置的
            DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
            if (dataRow != null)
            {
                PiRoleEntity roleEntity = BaseEntity.Create<PiRoleEntity>(dataRow); 
                // 超级管理员没必要设置权限，设置了权限反而增加误解了
                if (roleEntity.Code != null && roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
                {                    
                    this.btnRolePermission.Enabled = false;
                    this.btnRoleTableConstraintSet.Enabled = false;
                    this.btnTableFieldPermission.Enabled = false;
                    this.btnRolePermissionScope.Enabled = false;
                    this.btnBatchPermission.Enabled = false;
                }
                if (((roleEntity.Category != null) && (roleEntity.Category.Equals("UserGroup"))))
                {
                    this.btnRolePermission.Enabled = false;
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
            // 这个是范围权限，对哪些（模块）有模块访问的权限？
            // this.permissionAccess = this.IsModuleAuthorized("FrmRolePermissionAdmin");
            this.permissionAccess = this.IsModuleAuthorized(this.Name);
            // 这个可以是范围权限（这里当操作权限处理），对哪些（组织机构、用户、角色）分配权限的范围权限？
            this.permissionAccredit = this.IsAuthorized("RolePermissionAdmin.Accredit");
            // 当前用户有什么相应的操作权限？            
            this.permissionRoleUser = this.IsAuthorized("RoleManagement.RoleUser");
            //当前用户是否可以进行角色用户批量关联设置
            this.permissionRoleUserBatchSet = this.IsAuthorized("RoleManagement.RoleUserBatchSet");
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            FormOnLoad(true);
        }
        #endregion

        private void FormOnLoad(bool bindItemDetails)
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvInfo);
            // 获取分类列表
            if (bindItemDetails)
            {
                this.BindItemDetails();
            }
            // 获得角色列表
            this.GetList();
            // 设置数据过滤
            this.SetRowFilter();
            // 这里是控制只读属性
            for (int i = 0; i < this.dgvInfo.Rows.Count; i++)
            {
                var dataRowView = this.dgvInfo.Rows[i].DataBoundItem as DataRowView;
                if (dataRowView == null) continue;
                var dataRow = dataRowView.Row;
                if (dataRow[PiRoleTable.FieldAllowEdit].ToString().Equals("0") || dataRow[PiRoleTable.FieldAllowDelete].ToString().Equals("0"))
                {
                    // this.dgvInfo.Rows[i].Cells["colEnabled"].ReadOnly = true;
                    // this.dgvInfo.Rows[i].Cells["colDescription"].ReadOnly = true;
                    this.dgvInfo.Rows[i].Cells[3].ReadOnly = true;
                    this.dgvInfo.Rows[i].Cells[4].ReadOnly = true;
                }
            }
        }

        #region private void DataTableAddColumn() 往DataTable里面添加一列
        /// <summary>
        /// 往DataTable里面添加一列
        /// </summary>
        //private void DataTableAddColumn()
        //{
        //    BasePageLogic.DataTableAddColumn(this.DTRole, "colSelected");
        //}
        #endregion

        #region public override void GetList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public override void GetList()
        {
            // 是否启用了权限范围管理
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            //this.DataTableAddColumn();
            this.dgvInfo.AutoGenerateColumns = false;
            this.DTRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.dgvInfo.DataSource = this.DTRole.DefaultView;          
        }
        #endregion

        private string GetCategoryFilter()
        {
            string returnValue = string.Empty;
            if (this.cmbRoleCategory.SelectedValue != null && this.cmbRoleCategory.SelectedValue.ToString().Length > 0)
            {
                returnValue = PiRoleTable.FieldCategory + " = '" + this.cmbRoleCategory.SelectedValue + "' ";
            }
            return returnValue;
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string rowFilter = string.Empty;
            string search = this.txtSearch.Text;
            search = BusinessLogic.GetSearchString(search);
            if (!string.IsNullOrEmpty(search))
            {
                rowFilter = PiRoleTable.FieldRealName + " LIKE '" + search + "'"
                    + " OR " + PiRoleTable.FieldCode + " LIKE '" + search + "'"
                    + " OR " + PiRoleTable.FieldDescription + " LIKE '" + search + "'";
            }
            var categoryFilter = this.GetCategoryFilter();
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                if (!string.IsNullOrEmpty(rowFilter))
                {
                    rowFilter = categoryFilter + " AND (" + rowFilter + ") ";
                }
                else
                {
                    rowFilter = categoryFilter;
                }
            }
            this.DTRole.DefaultView.RowFilter = rowFilter;
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }

        private void btnRolePermissionScope_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRolePermissionScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermissionScopes = (Form)Activator.CreateInstance(assemblyType, this.TargetRoleId);
            frmRolePermissionScopes.ShowDialog(this);
        }

        private void btnTableFieldPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmTableFieldPermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmTableColumnPermission = (Form)Activator.CreateInstance(assemblyType, PiRoleTable.TableName, this.TargetRoleId);
            frmTableColumnPermission.ShowDialog(this);
        }

        private void btnRoleTableConstraintSet_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmTableConstraint";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, PiRoleTable.TableName, this.TargetRoleId);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnRoleUserBatchSet_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRoleUserBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermissionScopes = (Form)Activator.CreateInstance(assemblyType);
            frmRolePermissionScopes.ShowDialog(this);
        }

        private void btnBatchPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRolePermissionBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.PermissionItemScopeCode);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void cmbRoleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRolePermission";
            if (!SystemInfo.EnablePermissionItem)
            {
                formName = "FrmRoleModulePermission";
            }
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, this.TargetRoleId, this.TargetRoleRealName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnRoleUser_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRoleUserAdmin";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleUserAdmin = (Form)Activator.CreateInstance(assemblyType, this.TargetRoleId, this.TargetRoleRealName);
            frmRoleUserAdmin.ShowDialog(this);
        }
       
        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnRolePermission.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
