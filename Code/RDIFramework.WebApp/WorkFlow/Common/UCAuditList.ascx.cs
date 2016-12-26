using System;
using System.Data;

namespace RDIFramework.WebApp.WorkFlow.Common
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// UCAuditList
    /// 审批列表
    /// 
    /// </summary>
    public partial class UCAuditList : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                InitData();
        }

        private void InitData()
        {
            DataTable dt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAuditMessageTableByFlow(Utils.UserInfo, WorkFlowInsId);
            gvAuditMessage.DataSource = dt;
            gvAuditMessage.DataBind();

        }
    }
}