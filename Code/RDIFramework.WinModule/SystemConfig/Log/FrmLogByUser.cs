using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmLogByUser
    /// 日志－访问情况按用户查询
    /// 
    /// </summary>
    public partial class FrmLogByUser : BaseForm
    {
        private DataTable dtLog = new DataTable(CiLogTable.TableName);

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

        // 用户主键
        private string TargetUserId
        {
            set
            {
                this.ucUserSelect.SelectedId = value;
            }
            get
            {
                return this.ucUserSelect.SelectedId;
            }
        }

        // 用户名称     
        private string TargetUserFullName
        {
            set
            {
                this.ucUserSelect.SelectedFullName = value;
            }
            get
            {
                return this.ucUserSelect.SelectedFullName;
            }
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnQuery.Enabled = this.permissionQuery;
            this.btnExport.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnDeleteAll.Enabled = false;

            if (this.dtLog.DefaultView.Count >= 1)
            {
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
            this.permissionQuery = this.IsAuthorized("LogAdmin.Query");
            this.permissionExport = this.IsAuthorized("LogAdmin.Export");
            this.permissionDelete = this.IsAuthorized("LogAdmin.Delete");
            this.permissionDeleteAll = this.IsAuthorized("LogAdmin.DeleteAll");
        }
        #endregion

        public FrmLogByUser()
        {
            InitializeComponent();
        }

        public FrmLogByUser(string userId, string userRealname)
            : this()
        {
            this.TargetUserId = userId;
            this.TargetUserFullName = userRealname;
        }

        public override void FormOnLoad()
        {
            base.QueryStatement = string.Empty;
            this.LoadUserParameters = false;
            this.DataGridViewOnLoad(dgvInfo);
            dgvInfo.AutoGenerateColumns = false;
            txtEndDate.Format = txtStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            txtEndDate.CustomFormat = txtStartDate.CustomFormat = @"yyyy-MM-dd";
            this.txtStartDate.Value = DateTime.Now.AddDays(-60);
            this.txtEndDate.Value = DateTime.Now.AddDays(1);
            QueryLog();
            this.SetControlState();
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
                var whereStatement = " 1 = 1";

                if (this.ucUserSelect.SelectedIds != null && this.ucUserSelect.SelectedIds.Length > 0)
                {
                    whereStatement += "  and " + CiLogTable.FieldCreateUserId + " IN (" + BusinessLogic.ArrayToList(ucUserSelect.SelectedIds, "'") + ")";
                }
                else if (this.ucUserSelect.SelectedId != null)
                {
                    whereStatement += "  and " + CiLogTable.FieldCreateUserId + " ='" + this.ucUserSelect.SelectedId + "'";
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
                this.dtLog = RDIFrameworkService.Instance.LogService.GetDTByPage(this.UserInfo, out recordCount, ucPagerEx.PageIndex, ucPagerEx.PageSize, whereStatement, CiLogTable.FieldCreateOn + " DESC");
                ucPagerEx.RecordCount = recordCount;
                ucPagerEx.InitPageInfo();
                this.dgvInfo.AutoGenerateColumns = false;
                this.dgvInfo.DataSource = this.dtLog.DefaultView;
                SetControlState();
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ucPagerEx_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            QueryLog();
            this.Cursor = holdCursor;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryLog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, @"\Modules\Export\", exportFileName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnDeleteAll_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
