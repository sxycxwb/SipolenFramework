/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-5 17:11:55
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using DevComponents.DotNetBar;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmExceptionAdmin
    /// 系统异常情况记录
    /// 
    /// 修改记录
    ///     2015-03-07 EricHu V2.8 使用新的分页方式。
    ///     2012-06-06 EricHu 新增各功能(查询、删除等)。
    ///     2012-06-05 EricHu 创建：FrmExceptionAdmin
    /// </summary>
    public partial class FrmExceptionAdmin : BaseForm
    {
        private DataTable dtException = new DataTable(CiLogTable.TableName);
        string currentQueryCondition = " where 1=1";

        #region 权限定义
        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的查询权限
        /// </summary>
        private bool permissionQuery = false;

        /// <summary>
        /// 本模块的导出权限
        /// </summary>
        private bool permissionExport = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 本模块的清空日志表权限
        /// </summary>
        private bool permissionDeleteAll = false;
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnQuery.Enabled = true;
            this.btnExport.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnDeleteAll.Enabled = false;
            
            if (this.dtException.DefaultView.Count >= 1)
            {
                this.btnQuery.Enabled = this.permissionQuery;
                this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnDeleteAll.Enabled = this.permissionDeleteAll;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess    = this.IsModuleAuthorized("ExceptionAdmin");
            this.permissionQuery     = this.IsAuthorized("ExceptionAdmin.Query");
            this.permissionExport    = this.IsAuthorized("ExceptionAdmin.Export");
            this.permissionDelete    = this.IsAuthorized("ExceptionAdmin.Delete");
            this.permissionDeleteAll = this.IsAuthorized("ExceptionAdmin.DeleteAll");
        }
        #endregion

        public FrmExceptionAdmin()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            base.QueryStatement = string.Empty;
            this.LoadUserParameters = false;
            this.DataGridViewOnLoad(dgvInfo);
            dgvInfo.AutoGenerateColumns = false;           
            txtEndDate.Format = txtStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            txtEndDate.CustomFormat = txtStartDate.CustomFormat = @"yyyy-MM-dd";
            this.txtStartDate.Value = DateTime.Now.AddYears(-1);
            this.txtEndDate.Value = DateTime.Now.AddDays(1);
            this.txtUserName.Text = UserInfo.RealName;
            QueryLog();
            this.SetControlState();
        }

        private void commandExceptionAdmin_Executed(object sender, EventArgs e)
        {
            var source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                switch (source.CommandParameter.ToString())
                {
                    case "Query":
                        QueryLog();
                        break;                    
                }
            }
        }

        private void QueryLog()
        {
            if (txtStartDate.Value > txtEndDate.Value)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0208);
                txtStartDate.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;              
                SplashForm.StartSplash();
                var whereStatement = " 1 = 1";
                if (!string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
                {
                    whereStatement += " and " + CiExceptionTable.FieldCreateBy + " like '%" + txtUserName.Text.Trim() + "%'";
                }

                if (SystemInfo.RDIFrameworkDbType == CurrentDbType.Oracle)
                {
                    whereStatement += " and " + CiLogTable.FieldCreateOn + ">=" + BusinessLogic.GetOracleDateFormat(txtStartDate.Value);
                    whereStatement += " and " + CiLogTable.FieldCreateOn + "<" + BusinessLogic.GetOracleDateFormat(txtEndDate.Value.AddDays(1));
                }
                else
                {
                    whereStatement += " and " + CiLogTable.FieldCreateOn + ">='" + txtStartDate.Value.ToString("yyyy-MM-dd") + "'";
                    whereStatement += " and " + CiLogTable.FieldCreateOn + "<'" + txtEndDate.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
                }
                var recordCount = 0;
                this.dtException = RDIFrameworkService.Instance.ExceptionService.GetDTByPage(this.UserInfo, out recordCount, ucPagerEx.PageIndex, ucPagerEx.PageSize, whereStatement, CiLogTable.FieldCreateOn + " DESC");
                ucPagerEx.RecordCount = recordCount;
                ucPagerEx.InitPageInfo();

                this.dgvInfo.AutoGenerateColumns = false;
                this.dgvInfo.DataSource = this.dtException.DefaultView;
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
            finally
            {
                 SplashForm.CloseSplash();
                 this.Cursor = Cursors.Default;
            }
        }


        private void SelectAll()
        {
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void InvertSelect()
        {
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }

        private void ExportData()
        {
            var exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, @"\Modules\Export\", exportFileName);
        }

        private void Delete()
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) != DialogResult.Yes) return;
            try
            {
                var statusMessage = string.Empty;
                var returnValue = RDIFrameworkService.Instance.ExceptionService.BatchDelete(this.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, CiLogTable.FieldId, "colSelected", true));

                if (returnValue > 0)
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077,returnValue.ToString()));
                        this.QueryLog();
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

        private void DeleteAll()
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0239) != DialogResult.Yes) return;
            try
            {
                RDIFrameworkService.Instance.ExceptionService.Truncate(this.UserInfo);
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0014);
                this.QueryLog();
            }
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
        }

        private void CloseForm()
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != DialogResult.Yes)
            {
                return;
            }
            this.Close();
        }

        private void ViewExceptionDetail()
        {
            if (dgvInfo.Rows.Count <= 0 || dgvInfo.CurrentCell == null) return;
            var exceptionEntity = new CiExceptionEntity
            {
                Message = dgvInfo.CurrentRow.Cells[CiExceptionTable.FieldMessage].Value.ToString(),
                FormattedMessage = dgvInfo.CurrentRow.Cells[CiExceptionTable.FieldFormattedMessage].Value.ToString(),
                CreateOn = BusinessLogic.ConvertToNullableDateTime(dgvInfo.CurrentRow.Cells[CiExceptionTable.FieldCreateOn].Value),
                CreateBy = dgvInfo.CurrentRow.Cells[CiExceptionTable.FieldCreateBy].Value.ToString()
            };
            var frmException = new FrmException(exceptionEntity);
            frmException.ShowDialog();
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewExceptionDetail();
        }

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void cmnuInvertSelect_Click(object sender, EventArgs e)
        {
            InvertSelect();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            ViewExceptionDetail();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void txtUserName_DoubleClick(object sender, EventArgs e)
        {
            var frmUserSelect = new FrmUserSelect {MultiSelect = false};
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                this.txtUserName.Text = frmUserSelect.SelectedFullName;
            }
        }

        private void ucPagerEx_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            QueryLog();
            this.Cursor = holdCursor;
        }
    }
}
