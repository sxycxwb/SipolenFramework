using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmIncomingCallAdmin
    /// 来电登记管理
    /// 
    /// </summary>
    public partial class FrmIncomingCallAdmin : BaseForm
    {
        private DataTable DTIncomingCall = new DataTable(IncomingCallTable.TableName);
        IIncomingCallService incomingCallService = null;

        #region 权限控制部分
        /// <summary>
        /// 访问权限
        /// </summary>
        private bool permissionAccess = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 导出权限
        /// </summary>
        private bool permissionExport = false;

        /// <summary>
        /// 查询权限
        /// </summary>
        private bool permissionSearch = false;

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled     = this.permissionAdd;
            this.btnEdit.Enabled    = false;
            this.btnDelete.Enabled  = false;
            this.btnExport.Enabled  = false;
            this.btnSearch.Enabled  = false;

            if ((this.dgvInfo.DataSource != null) && (this.dgvInfo.RowCount > 0))
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnExport.Enabled = this.permissionExport;
                this.btnSearch.Enabled = this.permissionSearch;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("IncomingCallAdmin");
            this.permissionAdd = this.IsAuthorized("IncomingCallAdmin.Add");
            this.permissionEdit = this.IsAuthorized("IncomingCallAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("IncomingCallAdmin.Delete");
            this.permissionExport = this.IsAuthorized("IncomingCallAdmin.Export");
            this.permissionSearch = this.IsAuthorized("IncomingCallAdmin.Search");           
        }
        #endregion

        #endregion

        public FrmIncomingCallAdmin()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            incomingCallService = new IncomingCallService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            this.DataGridViewOnLoad(dgvInfo);
            GetList();
        }

        /// <summary>
        /// 获得数据列表绑定界面
        /// </summary>
        public override void GetList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTIncomingCall = incomingCallService.GetDataTable(base.UserInfo);
            if (this.DTIncomingCall != null && this.DTIncomingCall.Rows.Count > 0)
            {
                this.DTIncomingCall.DefaultView.Sort = IncomingCallTable.FieldSortCode;
                this.dgvInfo.AutoGenerateColumns = false;
                this.dgvInfo.DataSource = null;
                this.dgvInfo.ReadOnly = true;
                this.dgvInfo.DataSource = DTIncomingCall.DefaultView;
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            this.SetControlState();
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            int handled = 1;
            if (rbNotHandled.Checked)
            {
                handled = 0;
            }

            string search = this.txtCustomSearchValue.Text;
           
            if (this.DTIncomingCall.Columns.Count > 1)
            {
                search = BusinessLogic.GetSearchString(search);

                string operatorString = " LIKE ";
                if (rbCustomerExactSearch.Checked)
                {
                    operatorString = " = ";
                }

                if (rbAll.Checked)
                {
                    if (string.IsNullOrEmpty(search))
                    {
                        this.DTIncomingCall.DefaultView.RowFilter = IncomingCallTable.FieldHandled + " = " + handled.ToString();
                    }
                    else
                    {
                        this.DTIncomingCall.DefaultView.RowFilter = "(" + IncomingCallTable.FieldCustomerName + operatorString + " '" + search + "'"
                                                                    + " OR " + IncomingCallTable.FieldCallType + operatorString + "  '" + search + "'"
                                                                    + " OR " + IncomingCallTable.FieldCallNumber + operatorString + "  '" + search + "'"
                                                                    + " OR " + IncomingCallTable.FieldCallRecord + operatorString + "  '" + search + "')"
                                                                    + " AND " + IncomingCallTable.FieldHandled + " = " + handled.ToString();
                    }
                }
                else
                {
                    string filter = string.Empty;
                    filter = rbSalesOpp.Checked ? IncomingCallTable.FieldCallType + operatorString + " '" + rbSalesOpp.Text + "'" : filter;
                    filter = rbAfterService.Checked ? IncomingCallTable.FieldCallType + operatorString + " '" + rbAfterService.Text + "'" : filter;
                    filter = rbComplain.Checked ? IncomingCallTable.FieldCallType + operatorString + "  '" + StringHelper.RemoveSpaces(rbComplain.Text) + "'" : filter;
                    filter = rbCooperate.Checked ? IncomingCallTable.FieldCallType + operatorString + "  '" + StringHelper.RemoveSpaces(rbCooperate.Text) + "'" : filter;
                    filter = rbOther.Checked ? IncomingCallTable.FieldCallType + operatorString + "  '" + StringHelper.RemoveSpaces(rbOther.Text) + "'" : filter;
                    if (string.IsNullOrEmpty(search))
                    {
                        this.DTIncomingCall.DefaultView.RowFilter = filter + " AND " + IncomingCallTable.FieldHandled + " = " + handled.ToString();
                    }
                    else
                    {
                        this.DTIncomingCall.DefaultView.RowFilter = filter + " AND " + IncomingCallTable.FieldHandled + " = " + handled.ToString()
                                                                  + " AND (" + IncomingCallTable.FieldCustomerName + operatorString + " '" + search + "'"
                                                                    + " OR " + IncomingCallTable.FieldCallType + operatorString + "  '" + search + "'"
                                                                    + " OR " + IncomingCallTable.FieldCallNumber + operatorString + "  '" + search + "'"
                                                                    + " OR " + IncomingCallTable.FieldCallRecord + operatorString + "  '" + search + "')";
                    }
                }
            }
          
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRowFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmIncomingCallEdit frmIncomingCallEdit = new FrmIncomingCallEdit {DbLinks = this.DbLinks};
            if (frmIncomingCallEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.GetList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmIncomingCallEdit frmIncomingCallEdit = new FrmIncomingCallEdit(BasePageLogic.GetDataGridViewEntityId(dgvInfo,IncomingCallTable.FieldId))
            {
                DbLinks = this.DbLinks
            };
            if (frmIncomingCallEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.GetList();
            }
        }

        private void DeleteData()
        {
            if (dgvInfo.CurrentCell == null)
            {
                MessageBoxHelper.ShowWarningMsg("请选择要删除的数据！");
                return;
            }

            if (MessageBoxHelper.Show("确定当前来电登录？") == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            
            try
            {
                int returnValue = incomingCallService.SetDeleted(base.UserInfo, new string[] { BasePageLogic.GetDataGridViewEntityId(dgvInfo, IncomingCallTable.FieldId) });
                if (returnValue > 0)
                {
                    MessageBoxHelper.ShowSuccessMsg("删除成功！");
                    this.GetList();
                }
                else
                {
                    MessageBoxHelper.ShowSuccessMsg("删除失败！");
                }
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, @"\Modules\Export\", exportFileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定关闭吗？") != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            this.Close();   
        }

    }
}
