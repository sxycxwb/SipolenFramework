using System.Data;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// FrmAuditList.cs
    /// 审批列表
    /// 
    /// </summary>
    public partial class FrmAuditList : FrmBaseBizeForm
    {
        public FrmAuditList()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            base.FormOnLoad();
            this.DataGridViewOnLoad(dgvAuditList);
            this.dgvAuditList.AutoGenerateColumns = false;
            this.InitData();
        }

        private void InitData()
        {
            DataTable dt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAuditMessageTableByFlow(this.UserInfo, WorkFlowInsId);
            if (dt.Rows.Count > 0)
            {
                dgvAuditList.DataSource = dt;
            }
        }
    }
}
