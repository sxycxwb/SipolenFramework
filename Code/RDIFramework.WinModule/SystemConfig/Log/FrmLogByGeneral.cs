using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmLogByGeneral
    /// 日志－用户访问情况
    /// 
    /// </summary>
    public partial class FrmLogByGeneral : BaseForm
    {
        private DataTable dtUser = new DataTable(PiUserTable.TableName);

        private string PermissionScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 本模块的查询权限
        /// </summary>
        private bool permissionQuery = false;

        /// <summary>
        /// 本模块的导出权限
        /// </summary>
        private bool permissionExport = false;

        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiUserTable.FieldId);
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

            if (this.dtUser.DefaultView.Count >= 1)
            {
                this.btnExport.Enabled = this.permissionExport;
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
        }
        #endregion

        public FrmLogByGeneral()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            base.QueryStatement = string.Empty;
            this.LoadUserParameters = false;
            this.DataGridViewOnLoad(dgvInfo);
            dgvInfo.AutoGenerateColumns = false;
            QueryLog();
            this.SetControlState();
        }

        private void QueryLog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var whereStatement = " 1 = 1";
                if (this.ucUserSelect.SelectedIds != null && this.ucUserSelect.SelectedIds.Length > 0)
                {
                    whereStatement += "  and " + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN (" + BusinessLogic.ArrayToList(ucUserSelect.SelectedIds, "'") + ")";
                }
                
                var recordCount = 0;
                this.dtUser = RDIFrameworkService.Instance.UserService.GetDTByPage(UserInfo, whereStatement,ucOrganizeSelect.SelectedId, null, out recordCount, ucPagerEx.PageIndex, ucPagerEx.PageSize, PiUserTable.FieldSortCode);
                ucPagerEx.RecordCount = recordCount;
                ucPagerEx.InitPageInfo();
                this.dgvInfo.AutoGenerateColumns = false;
                this.dgvInfo.DataSource = this.dtUser.DefaultView;
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
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            QueryLog(); 
            this.Cursor = holdCursor;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, @"\Modules\Export\", exportFileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnVisitDetail_Click(object sender, EventArgs e)
        {
            var logByUser = new FrmLogByUser(this.EntityId, RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.EntityId).RealName) { DbLinks = this.DbLinks };
            this.ShowFormInMainTab(logByUser, "FrmLogByUser", btnVisitDetail.Image);
        }
    }
}
