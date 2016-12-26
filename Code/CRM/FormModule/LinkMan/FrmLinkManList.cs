using System;
using System.Data;
using System.Windows.Forms;

namespace CRM
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmLinkManList
    /// 联系人列表
    /// 
    /// 修改记录
    ///     2012-06-17 EricHu 创建FrmLinkManList。
    /// </summary>
    public partial class FrmLinkManList : BaseForm
    {
        ILinkManService linkMainService = null;
        DataTable DTLinkManList = new DataTable(LinkManTable.TableName);
       
        public FrmLinkManList()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            linkMainService = new LinkManService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            this.DataGridViewOnLoad(dgvLinkMain);
            this.GetLinkManData();            
        }

        private void GetLinkManData()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            DTLinkManList = linkMainService.GetDataTable(base.UserInfo);
            if (DTLinkManList != null & DTLinkManList.Rows.Count > 0)
            {
                this.DTLinkManList.DefaultView.Sort = LinkManTable.FieldSortCode;
                this.dgvLinkMain.AutoGenerateColumns = false;
                this.dgvLinkMain.DataSource = null;
                this.dgvLinkMain.ReadOnly = true;
                this.dgvLinkMain.DataSource = DTLinkManList.DefaultView;
            }         
           
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                this.DTLinkManList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTLinkManList.Columns.Count > 1)
                {
                    search = BusinessLogic.GetSearchString(search);
                    this.DTLinkManList.DefaultView.RowFilter = CustomerTable.FieldShortName + " LIKE '" + search + "'"
                        + " OR " + CustomerTable.FieldCompanyName + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldName + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldSex + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldPostion + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldDepartment + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldMobilePhone + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldTelephone + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldOfficeAddress + " LIKE '" + search + "'"
                        + " OR " + LinkManTable.FieldInterest + " LIKE '" + search + "'";
                }
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }

        private void GetFindFilter(string customerId)
        {
            string search = this.txtSearch.Text;
            if (String.IsNullOrEmpty(customerId))
            {
                this.DTLinkManList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTLinkManList.Columns.Count > 1 && this.DTLinkManList.Columns.Contains(LinkManTable.FieldCustomerId))
                {
                    this.DTLinkManList.DefaultView.RowFilter = LinkManTable.FieldCustomerId + " =" + customerId ;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FrmCustomerSelect frmCustomerSelect = new FrmCustomerSelect {DbLinks = this.DbLinks};
            if (frmCustomerSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.GetFindFilter(frmCustomerSelect.SelectedId);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportLinkManToExcel_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvLinkMain, @"\Modules\Export\", exportFileName);
        }

        private void btnExportLinkManToTxt_Click(object sender, EventArgs e)
        {
            string exportFileName = this.Text + ".txt";
            this.ExportToText(this.dgvLinkMain, @"\Modules\Export\", exportFileName);
        }
    }
}
