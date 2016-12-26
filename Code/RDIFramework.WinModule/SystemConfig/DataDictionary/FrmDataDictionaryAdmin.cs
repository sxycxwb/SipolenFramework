using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.Controls;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmDataDictionaryAdmin
    /// 数据字典综合管理窗体
    /// 
    /// 修改记录
    ///     2013-10-22 EricHu V2.7 修改选择分类后进行修改界面保存修改，刷新主界面不保留当前分类的问题。
    ///     
    /// 
    /// </summary>
    public partial class FrmDataDictionaryAdmin : BaseForm
    {
        ITableColumnsService tableColumnService = RDIFrameworkService.Instance.TableColumnsService;
        IItemsService itemsService              = RDIFrameworkService.Instance.ItemsService;
        private DataTable DTItems               = new DataTable(CiItemsTable.TableName);
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
        /// 本模块的字典明细权限
        /// </summary>
        private bool permissionItemDetail = false;

        /// <summary>
        /// 本模块的用户权限
        /// </summary>
        private bool permissionUserPermission = false;

        /// <summary>
        /// 本模块的角色权限
        /// </summary>
        private bool permissionRolePermission = false;

        private string parentId = "CiItems";
        /// <summary>
        /// 父亲节点
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        public FrmDataDictionaryAdmin()
        {
            InitializeComponent();           
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnItemDetail.Enabled = false;
            this.btnUserResourcePermission.Visible = false;
            this.btnRoleResourcePermission.Visible = false;
            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd;
            if (DTItems.DefaultView.Count >= 1)
            {
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnExport.Enabled      = this.permissionExport;
                this.btnItemDetail.Enabled  = this.permissionItemDetail;
                this.btnUserResourcePermission.Visible = this.permissionUserPermission;
                this.btnRoleResourcePermission.Visible = this.permissionRolePermission;
            }

            this.separatorPermission.Visible = this.btnUserResourcePermission.Visible || this.btnRoleResourcePermission.Visible;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess         = this.IsModuleAuthorized("DataDictionaryManagement");
            this.permissionAdd            = this.IsAuthorized("DataDictionaryManagement.Add");
            this.permissionEdit           = this.IsAuthorized("DataDictionaryManagement.Edit");
            this.permissionDelete         = this.IsAuthorized("DataDictionaryManagement.Delete");
            this.permissionExport         = this.IsAuthorized("DataDictionaryManagement.Export");
            this.permissionItemDetail     = this.IsAuthorized("DataDictionaryManagement.ItemDetail");
            this.permissionUserPermission = this.IsAuthorized("DataDictionaryManagement.UserPermission");
            this.permissionRolePermission = this.IsAuthorized("DataDictionaryManagement.RolePermission");
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.dgvInfo.AutoGenerateColumns = false;
            this.DTItems.DefaultView.Sort = CiItemsTable.FieldSortCode;

            var rowFilter = string.Empty;

            this.dgvInfo.DataSource = this.DTItems.DefaultView;           
            
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void GetList() 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public override void GetList()
        {
            this.DTItems = !String.IsNullOrEmpty(this.ParentId) ? RDIFrameworkService.Instance.ItemsService.GetDT(UserInfo) : RDIFrameworkService.Instance.ItemsService.GetDTByParent(UserInfo, this.ParentId);
            // 绑定屏幕数据
            this.BindData();
            // 设置按钮状态
            this.SetControlState();         
        }
        #endregion

        #region public override void FormOnLoad()
        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvInfo);
            BindItemDetails();
            this.GetList();
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cboCategory.Items.Count == 0)
            {
                var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(base.UserInfo, "DataDictionaryCategory");
                if (dtItemDetail != null && dtItemDetail.Rows.Count > 0)
                {
                    cboCategory.Items.Clear();
                    cboCategory.Items.Insert(0, string.Empty);
                    cboCategory.Items.AddRange(BusinessLogic.FieldToArray(dtItemDetail, CiItemDetailsTable.FieldItemValue));
                }
            }
        }
        #endregion

        /// <summary>
        /// 刷新窗体
        /// </summary>
        public override void RefreshForm()
        {
            this.GetList();
            // 设置数据过滤
            this.SetRowFilter();
        }       

        private void btnAddData_Click(object sender, EventArgs e)
        {
            var addDataDictionary = new FrmEditDataDictionary {Owner = this};
            addDataDictionary.ShowDialog();
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            if (dgvInfo.CurrentRow == null)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC024);
            }

            var dataRow = (dgvInfo.CurrentRow.DataBoundItem as DataRowView).Row;

            var frmEditDataDictionary = new FrmEditDataDictionary(dataRow) {Owner = this};
            frmEditDataDictionary.ShowDialog();
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (MessageBoxHelper.Show("你确定删除所选数据字典吗？（是/否）\n注意：会同步删除对应的字典明细。") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    var statusMessage = string.Empty;
                    var returnValue = itemsService.SetDeleted(this.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, CiItemsTable.FieldId, "colSelected", true));
                    if (returnValue > 0)
                    {
                        if (SystemInfo.ShowSuccessMsg)
                        {
                            MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077,returnValue.ToString()));
                            this.GetList();
                        }
                    }
                    else
                    {
                        MessageBoxHelper.ShowWarningMsg(statusMessage);
                    }
                }
                catch (Exception exception)
                {
                    this.ProcessException(exception);
                }
            }
        }

        private void btnItemDetail_Click(object sender, EventArgs e)
        {
            if (dgvInfo.Rows.Count <= 0 || dgvInfo.CurrentCell == null)
            {
                return;
            }

            var itemDetailManagement = new FrmItemsDetailAdmin((dgvInfo.CurrentRow.DataBoundItem as DataRowView).Row["Id"].ToString());
            itemDetailManagement.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            this.ExportToExcel(dgvInfo, "ExportFile", "数据字典");
        }


        private void btnUserResourcePermission_Click(object sender, EventArgs e)
        {
            // 用户资源管理权限
            var permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = CiItemsTable.TableName;
            var targetResourceSQL = "SELECT " + CiItemsTable.FieldId + " AS Id, "
                                        + CiItemsTable.FieldFullName + " AS RealName, "
                                        + CiItemsTable.FieldDescription + " AS Description FROM "
                                        + CiItemsTable.TableName
                                        + " WHERE " + CiItemsTable.FieldDeleteMark + " = 0 AND " + CiItemsTable.FieldEnabled + " = 1 ORDER BY " + CiItemsTable.FieldSortCode;

            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmUserResourcePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnRoleResourcePermission_Click(object sender, EventArgs e)
        {
            // 角色资源管理权限
            var permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = CiItemsTable.TableName;
            var targetResourceSQL = "SELECT " + CiItemsTable.FieldId + " AS Id, "
                                        + CiItemsTable.FieldFullName + " AS RealName, "
                                        + CiItemsTable.FieldDescription + " AS Description FROM "
                                        + CiItemsTable.TableName
                                        + " WHERE " + CiItemsTable.FieldDeleteMark + " = 0 AND " + CiItemsTable.FieldEnabled + " = 1 ORDER BY " + CiItemsTable.FieldSortCode;

            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmRoleResourcePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
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
            this.btnItemDetail_Click(sender, e);
        }

        private void dgvInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn dgvColumn in dgvInfo.Columns)
            {
                if (!dgvColumn.Name.Contains("colSelected"))
                {
                    dgvColumn.ReadOnly = true;
                }
            }
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            var rowFilter = string.Empty;

            if (!string.IsNullOrEmpty(this.cboCategory.Text))
            {
                if (this.cboCategory.Text.Length > 0)
                {
                    rowFilter = CiItemsTable.FieldCategory + " = '" + this.cboCategory.Text + "' ";
                }
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //SplashForm.StartSplash();
                this.DTItems.DefaultView.RowFilter = rowFilter;
            }
            catch (Exception ex)
            {
                //SplashForm.CloseSplash();
                
                MessageBoxHelper.ShowErrorMsg(ex.Message);
            }
            finally
            {
                //SplashForm.CloseSplash();
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }   
    }
}
