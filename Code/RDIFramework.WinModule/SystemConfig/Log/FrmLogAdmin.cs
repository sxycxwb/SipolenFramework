/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-5 13:56:14
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
    /// FrmLogAdmin
    /// 日志/系统异常管理
    /// 
    /// 修改记录
    ///     2015-03-07 XuWangBin V2.8 使用新的分页方式。
    ///     2012-06-05 XuWangBin 创建FrmLogAdmin
    /// </summary>
    public partial class FrmLogAdmin : BaseForm
    {
        private DataTable dtLog = new DataTable(CiLogTable.TableName);

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

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnQuery.Enabled       = false;
            this.btnExport.Enabled      = false;
            this.btnDelete.Enabled      = false;
            this.btnDeleteAll.Enabled   = false;
            
            if (this.dtLog.DefaultView.Count >= 1)
            {
                this.btnQuery.Enabled       = this.permissionQuery;
                this.btnExport.Enabled      = this.permissionExport;
                this.btnDelete.Enabled      = this.permissionDelete;
                this.btnDeleteAll.Enabled   = this.permissionDeleteAll;                
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess    = this.IsModuleAuthorized("LogAdmin");
            this.permissionQuery     = this.IsAuthorized("LogAdmin.Query");
            this.permissionExport    = this.IsAuthorized("LogAdmin.Export");
            this.permissionDelete    = this.IsAuthorized("LogAdmin.Delete");
            this.permissionDeleteAll = this.IsAuthorized("LogAdmin.DeleteAll");
        }
        #endregion

        public FrmLogAdmin()
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
            this.txtStartDate.Value = DateTime.Now.AddDays(-7);
            this.txtEndDate.Value = DateTime.Now.AddDays(1);
            this.txtUserName.Text   = UserInfo.RealName;
            QueryLog();
            this.SetControlState();
        }

        private void commandLogAdmin_Executed(object sender, EventArgs e)
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
                    whereStatement += "  and " + CiLogTable.FieldUserRealName + " like '%" + txtUserName.Text.Trim() + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtIPAddress.Text.Trim()))
                {
                    whereStatement += " and " + CiLogTable.FieldIPAddress + "like '%" + txtIPAddress.Text.Trim() + "%'";
                }
                
                if (SystemInfo.RDIFrameworkDbType == CurrentDbType.Oracle)
                {
                    whereStatement += " and " + CiLogTable.FieldCreateOn + ">=" + BusinessLogic.GetOracleDateFormat(txtStartDate.Value);
                    whereStatement += " and " + CiLogTable.FieldCreateOn + "<" + BusinessLogic.GetOracleDateFormat(txtEndDate.Value.AddDays(1));
                }
                else
                {
                    whereStatement += " and " + CiLogTable.FieldCreateOn + ">='" +txtStartDate.Value.ToString("yyyy-MM-dd") + "'";
                    whereStatement += " and " + CiLogTable.FieldCreateOn + "<'" +txtEndDate.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
                }

                var recordCount = 0;
                this.dtLog = RDIFrameworkService.Instance.LogService.GetDTByPage(this.UserInfo, out recordCount,ucPagerEx.PageIndex, ucPagerEx.PageSize, whereStatement, CiLogTable.FieldCreateOn + " DESC");
                ucPagerEx.RecordCount = recordCount;
                ucPagerEx.InitPageInfo();

                this.dgvInfo.AutoGenerateColumns = false;
                this.dgvInfo.DataSource = this.dtLog.DefaultView;
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
                var returnValue = RDIFrameworkService.Instance.LogService.BatchDelete(this.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, CiLogTable.FieldId, "colSelected", true));
                        
                if (returnValue > 0)
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077, returnValue.ToString()));
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
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) != System.Windows.Forms.DialogResult.Yes) return;
            try
            {
                RDIFrameworkService.Instance.LogService.Truncate(this.UserInfo);
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
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) == DialogResult.Yes)
            {
                this.Close();
            }
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
            var frmUserSelect = new FrmUserSelect()
            {
                MultiSelect = false
            };
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
