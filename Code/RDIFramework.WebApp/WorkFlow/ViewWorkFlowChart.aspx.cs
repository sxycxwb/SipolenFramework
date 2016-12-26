using System;
using System.Data;
using System.Globalization;

namespace RDIFramework.WebApp.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class ViewWorkFlowChart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["workFlowId"] != null && Request["workFlowInsId"] != null)
            {
                string workflowId = Request["workflowId"].ToString(CultureInfo.InvariantCulture);
                string workflowInsId = Request["workflowInsId"].ToString(CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(workflowInsId))
                {
                    DataTable dtWFIns = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowInstance(this.UserInfo,workflowInsId);
                    if (dtWFIns != null && dtWFIns.Rows.Count > 0)
                    {
                        var wfInsEntity = BaseEntity.Create<WorkFlowInstanceEntity>(dtWFIns);
                        tbxFlowNo.Text = wfInsEntity.WorkFlowNo ?? "";
                        tbxWorkflowCaption.Text = wfInsEntity.FlowInsCaption ?? "";
                        tbxWorkflowDes.Text = wfInsEntity.Description ?? "";
                        if ((BusinessLogic.ConvertToString(wfInsEntity.Priority ?? "").Trim().Length > 0))
                        {
                            if (wfInsEntity.Priority == "1")
                            {
                                tbxPriority.Text = @"普通";
                            }
                            if (wfInsEntity.Priority == "2")
                            {
                                tbxPriority.Text = @"紧急";
                            }
                            if (wfInsEntity.Priority == "3")
                            {
                                tbxPriority.Text = @"特急";
                            }
                        }
                    }
                }

                string sb1 = "/WorkFlow/WorkFlowChart.aspx?WorkFlowId=" + workflowId + "&workFlowInsId=" + workflowInsId;
                Image1.ImageUrl = sb1;
                Image1.DataBind();
            }
        }
    }
}