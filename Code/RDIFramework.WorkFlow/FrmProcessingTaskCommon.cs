using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmProcessingTaskCommon : FrmBaseBizeForm
    {
        public FrmProcessingTaskCommon()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.InitUIData();
        }

        private void InitUIData()
        {
            if (string.IsNullOrEmpty(this.OperatorInsId))
            {
                return;
            }

            DataTable dtOperatorIns = RDIFrameworkService.Instance.WorkFlowInstanceService.GetOperatorInstance(this.UserInfo, OperatorInsId);
            if (dtOperatorIns != null && dtOperatorIns.Rows.Count > 0)
            {
                WorkFlowId = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["WorkflowId"]) ?? "";
                WorkTaskId = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["WorktaskId"]) ?? "";
                WorkFlowInsId = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["WorkflowInsId"]) ?? "";
                WorkTaskInsId = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["WorkTaskInsId"]) ?? "";
                txtBizWorkFlowName.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["FLOWINSCAPTION"]) ?? "";
                txtBizWorkFlowNo.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["WORKFLOWNO"]) ?? "";
                txtBizWorkFlowDescription.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["DESCRIPTION"]) ?? "";
                txtBizTaskCaption.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["TASKINSCAPTION"]) ?? "";

                txtBizUser.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["POPERATEDDES"]) ?? "";
                txtBizTime.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["TASKSTARTTIME"]) ?? "";
                if ((BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["PRIORITY"]) ?? "").Trim().Length > 0)
                {
                    if (BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["PRIORITY"]) == "1")
                    {
                        txtBizPriority.Text = @"普通";
                    }
                    if (BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["PRIORITY"]) == "2")
                    {
                        txtBizPriority.Text = @"紧急";
                    }
                    if (BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["PRIORITY"]) == "3")
                    {
                        txtBizPriority.Text = @"特急";
                    }
                }

                txtWorkFlowName.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["FlowCaption"]) ?? "";
                txtTaskName.Text = BusinessLogic.ConvertToString(dtOperatorIns.Rows[0]["TaskCaption"]) ?? "";
                //绑定流程历史
                GetWorkFlowHistory(WorkFlowInsId);
            }
        }

        /// <summary>
        /// 绑定流程历史与退回
        /// </summary>
        /// <param name="workflowinsid"></param>
        private void GetWorkFlowHistory(string workflowinsid)
        {
            DataTable dtWFHistory = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowHistory(this.UserInfo, WorkFlowInsId);
            dgvAuditHistory.AutoGenerateColumns = false;
            dgvAuditHistory.DataSource = dtWFHistory;
            DataTable dtWFBackCause = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowBack(this.UserInfo, WorkFlowInsId);
            dgvBackCause.AutoGenerateColumns = false;
            dgvBackCause.DataSource = dtWFBackCause;
        }
    }
}
