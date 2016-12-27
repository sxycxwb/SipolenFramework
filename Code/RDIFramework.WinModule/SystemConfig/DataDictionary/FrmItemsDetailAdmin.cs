using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.Controls;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmItemsDetailAdmin
    /// 数据字典明细管理
    /// 
    /// 修改记录
    ///     XuWangBin 2012-05-31 新增对于权限的判断。
    ///     XuWangBin 2012-03-29 创建数据字典明细管理。
    ///     
    /// </summary>
    public partial class FrmItemsDetailAdmin : BaseForm
    {
        IItemDetailsService itemDetailService = RDIFrameworkService.Instance.ItemDetailsService;
        string itemsId = string.Empty;

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

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnEdit.Enabled        = false;
            this.btnDelete.Enabled      = false;
            // 检查添加组织机构
            this.btnAdd.Enabled         = this.permissionAdd;
            if (pageDataTable.DefaultView.Count >= 1)
            {
                this.btnAdd.Enabled     = this.permissionAdd;
                this.btnEdit.Enabled    = this.permissionEdit;
                this.btnDelete.Enabled  = this.permissionDelete;              
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAdd    = this.IsAuthorized("DictionaryDetail.Add");
            this.permissionEdit   = this.IsAuthorized("DictionaryDetail.Edit");
            this.permissionDelete = this.IsAuthorized("DictionaryDetail.Delete");
        }
        #endregion


        public FrmItemsDetailAdmin(string currentItemsId)
        {
            InitializeComponent();
            itemsId = currentItemsId;
            base.QueryStatement = "ITEMID = '" + currentItemsId + "' AND DELETEMARK = 0";
        }

        #region public override void FormOnLoad()
        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvInfo);
            
            this.pageDataDictionaryManagement.PageCurrent = 1;
            this.pageDataDictionaryManagement.Bind();
            GetPermission();
            SetControlState();
        }
        #endregion

        /// <summary>
        /// 刷新窗体
        /// </summary>
        public override void RefreshForm()
        {
            pageDataDictionaryManagement.Bind();
            SetControlState();
        }

        private int pageDataDictionaryManagement_EventPaging(EventPagingArg e)
        {
            return BindPageData(dgvInfo, pageDataDictionaryManagement, CiItemDetailsTable.TableName,SystemInfo.RDIFrameworkDbType, CiItemDetailsTable.FieldId, CiItemDetailsTable.FieldSortCode,base.QueryStatement, "*", SystemInfo.RDIFrameworkDbConection);
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

        private void btnAddData_Click(object sender, EventArgs e)
        {
            var addDictionaryDetail = new FrmEditDictionaryDetail(itemsId) {Owner = this};
            addDictionaryDetail.ShowDialog();
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            if (dgvInfo.CurrentRow == null)
            {
                MessageBoxHelper.ShowWarningMsg("请选择待修改的数据！");
                return;
            }

            var dataRow = (dgvInfo.CurrentRow.DataBoundItem as DataRowView).Row;

            var editDictionaryDetail = new FrmEditDictionaryDetail(dataRow) {Owner = this};
            editDictionaryDetail.ShowDialog();
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    var statusMessage = string.Empty;
                    var returnValue = itemDetailService.SetDeleted(this.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo,CiItemDetailsTable.FieldId, "colSelected", true));
                    if (returnValue > 0)
                    {
                        if (SystemInfo.ShowSuccessMsg)
                        {
                            MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077,returnValue.ToString()));
                            pageDataDictionaryManagement.Bind();
                        }
                    }
                    else
                    {
                        MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG3020);
                    }
                }
                catch (Exception exception)
                {
                    this.ProcessException(exception);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInfo.Rows.Count <= 0 || dgvInfo.CurrentCell == null)
            {
                return;
            }

            if (btnEdit.Enabled)
            {
                this.btnEdit.PerformClick();
            }
        }
    }
}
