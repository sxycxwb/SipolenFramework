/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-13 9:16:52
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmRoleAdmin
    /// 角色综合管理界面
    /// 
    /// 修改记录
    ///     2012-08-12 EricHu 增加界面数据排序功能。
    ///     2012-07-23 EricHu 修改查询方式。
    ///     2012-04-13 EricHu 创建FrmRoleAdmin。
    /// </summary>
    public partial class FrmRoleAdmin : BaseForm
    {
        ITableColumnsService tableColumnService = RDIFrameworkService.Instance.TableColumnsService;
        IRoleService roleService = RDIFrameworkService.Instance.RoleService;

        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 本模块的导出数据
        /// </summary>
        private bool permissionExport = false;

        /// <summary>
        /// 本模块的角色用户关联关系管理
        /// </summary>
        private bool permissionRoleUser = false;

        /// <summary>
        /// 本模块的用户角色授权权限
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

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
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
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
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                string roleRealName = dataRow[PiRoleTable.FieldRealName].ToString();
                return roleRealName;
            }
        }

        public event SetControlStateEventHandler OnButtonStateChange;
        public void SetSortButton(bool enabled)
        {
            this.ucSortControl.SetSortButton(enabled);
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            //this.btnExport.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnUsers.Enabled = false;
            this.btnBatchSave.Enabled = false;

            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd;
            if ((this.DTRole.DefaultView.Count >= 1))
            {
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                //this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnUsers.Enabled = this.permissionRoleUser;
                this.btnBatchSave.Enabled = this.permissionEdit;
            }
            // 位置顺序改变按钮部分
            if (this.DTRole.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }

            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                bool setTop = this.ucSortControl.SetTopEnabled;
                bool setUp = this.ucSortControl.SetUpEnabled;
                bool setDown = this.ucSortControl.SetDownEnabled;
                bool setBottom = this.ucSortControl.SetBottomEnabled;
                bool add = this.btnAdd.Enabled;
                bool edit = this.btnEdit.Enabled;
                bool batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchSave);
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
            this.permissionAccess   = this.IsModuleAuthorized("RoleManagement");
            // 这个可以是范围权限（这里当操作权限处理），对哪些（组织机构、用户、角色）分配权限的范围权限？
            this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");

            // 这些是操作权限，当前用户有什么相应的操作权限？
            this.permissionAdd      = this.IsAuthorized("RoleManagement.Add");
            this.permissionEdit     = this.IsAuthorized("RoleManagement.Edit");
            this.permissionExport   = this.IsAuthorized("RoleManagement.Export");
            this.permissionDelete   = this.IsAuthorized("RoleManagement.Delete");
            this.permissionRoleUser = this.IsAuthorized("RoleManagement.RoleUser");
        }
        #endregion
       
        public FrmRoleAdmin()
        {
            InitializeComponent();
        }

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
        }
      

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cboRoleCategory.Items.Count != 0) return;
            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(base.UserInfo, "RoleCategory");
            if (dtItemDetail == null || dtItemDetail.Rows.Count <= 0) return;
            cboRoleCategory.Items.Clear();
            cboRoleCategory.Items.Insert(0, string.Empty);
            cboRoleCategory.Items.AddRange(BusinessLogic.FieldToArray(dtItemDetail, CiItemDetailsTable.FieldItemValue));
        }
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
            // 设置排序按钮
            this.ucSortControl.DataBind(this.dgvInfo, this.permissionEdit);
        }
        #endregion       

        #region private void SetRowFilter() 设置数据过滤
        private string GetCategoryFilter()
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(this.cboRoleCategory.Text) && this.cboRoleCategory.Text.Length > 0)
            {
                returnValue = PiRoleTable.FieldCategory + " = '" + this.cboRoleCategory.Text + "' ";
            }
            return returnValue;
        }

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
            string categoryFilter = this.GetCategoryFilter();
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

        private void dgvInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn dgvColumn in dgvInfo.Columns.Cast<DataGridViewColumn>().Where(dgvColumn => !dgvColumn.Name.Contains("colSelected")))
            {
                dgvColumn.ReadOnly = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != DialogResult.Yes)
            {
                return;
            }
                   
            this.Close();           
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgvInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            // 用户组是不需要进行权限配置的
            var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
            if (dataRow == null) return;
            var roleEntity = BaseEntity.Create<PiRoleEntity>(dataRow);
           // 超级管理员没必要设置权限，设置了权限反而增加误解了
            if (roleEntity.Code != null && roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
            {
                this.btnEdit.Enabled = btnDelete.Enabled = false;
            }
            else
            {
                this.SetControlState();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }

        private void cboRoleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.FormLoaded) return;
            // 设置数据过滤
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmRoleAdd = new FrmEditRole();
            if (frmRoleAdd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // 获得角色列表
                this.GetList();
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //var frmRoleEdit = new FrmEditRole(this.TargetRoleId);
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiRoleTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }
            var frmRoleEdit = new FrmEditRole(tmpId);
            if (frmRoleEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.FormOnLoad(false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (!CheckInput())
            {
                return;
            }

            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0075) == DialogResult.Yes)
            {
                try
                {
                    var returnValue = roleService.SetDeleted(base.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, PiUserTable.FieldId, "colSelected", true));
                    if (returnValue > 0 && SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077,returnValue.ToString()));
                        this.FormOnLoad(false);
                    }
                }
                catch (Exception exception)
                {
                    this.ProcessException(exception);
                }
            }
        }

        #region private int BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int BatchSave()
        {            
            var returnValue = 0;
            // 这里需要把没有变动的数据删除掉，这样可以提高效率
            // 去掉未修改的数据，提高运行速度
            for (int i = this.DTRole.Rows.Count - 1; i >= 0; i--)
            {
                if (this.DTRole.Rows[i].RowState == DataRowState.Unchanged)
                {
                    this.DTRole.Rows.RemoveAt(i);
                }
            }

            var roleEntites = new List<PiRoleEntity>();
            for (int i = 0; i < this.DTRole.Rows.Count; i++)
            {
                var roleEntity = BaseEntity.Create<PiRoleEntity>(this.DTRole.Rows[i]);
                roleEntites.Add(roleEntity);
            }
            // 调用后台的批量保存功能
            returnValue = RDIFrameworkService.Instance.RoleService.BatchSave(this.UserInfo, roleEntites);
            // 绑定屏幕数据
            this.FormOnLoad(false);
            if (SystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
            }
            return returnValue;
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (!BasePageLogic.CheckInputModifyAnyOne(this.DTRole)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                this.BatchSave();                  
                this.DTRole.AcceptChanges();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var frmRoleUserAdmin = new FrmRoleUserAdmin(this.TargetRoleId, this.TargetRoleRealName);
            frmRoleUserAdmin.ShowDialog(this);
        }
    }
}
