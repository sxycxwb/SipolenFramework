using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.WorkFlow.Common
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// UCAuditForm
    /// 审批表单
    /// 
    /// </summary>
    public partial class UCAuditForm : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load();
            InitData();
        }

        private void InitData()
        {
            DataTable dt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAuditMessageTableByOper(Utils.UserInfo, OperatorInsId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string result = "";
                lbAuditId.Text = dt.Rows[0][AuditMessageTable.FieldAuditId].ToString();
                lbWorkflowId.Text = dt.Rows[0][AuditMessageTable.FieldWorkflowId].ToString();
                lbWorkflowInsId.Text = dt.Rows[0][AuditMessageTable.FieldWorkflowInsId].ToString();
                lbWorktaskId.Text = dt.Rows[0][AuditMessageTable.FieldWorktaskId].ToString();
                lbWorktaskInsId.Text = dt.Rows[0][AuditMessageTable.FieldWorktaskInsId].ToString();
                lbOperatorInsId.Text = dt.Rows[0][AuditMessageTable.FieldOperatorInsId].ToString();
                lbUserId.Text = dt.Rows[0][AuditMessageTable.FieldAuditUserId].ToString();
                lbUserName.Text = dt.Rows[0][AuditMessageTable.FieldAuditUserName].ToString();
                lbArch.Text = dt.Rows[0][AuditMessageTable.FieldAuditArch].ToString();
                lbDuty.Text = dt.Rows[0][AuditMessageTable.FieldAuditDuty].ToString();

                result = dt.Rows[0][AuditMessageTable.FieldAuditResult].ToString();
                if (result == "同意")
                {
                    rbtOk.Checked = true;
                }
                else
                {
                    rbtNo.Checked = true;
                }

                lbAuditTime.Text = dt.Rows[0][AuditMessageTable.FieldAuditTime].ToString();
                tbxMessage.Text = dt.Rows[0][AuditMessageTable.FieldMessage].ToString();
                CtrlState = WorkConst.STATE_MOD;
            }
            else
            {
                lbAuditId.Text = Guid.NewGuid().ToString();
                lbWorkflowId.Text = WorkFlowId;
                lbWorkflowInsId.Text = WorkFlowInsId;
                lbWorktaskId.Text = WorkTaskId;
                lbWorktaskInsId.Text = WorkTaskInsId;
                lbOperatorInsId.Text = OperatorInsId;
                lbUserId.Text = UserId;
                lbUserName.Text = UserName;
                lbArch.Text = ArchCaption;
                lbDuty.Text = DutyCaption;
                CtrlState = WorkConst.STATE_ADD;
                lbAuditTime.Text = DateTime.Now.ToShortDateString();
            }
        }

        public override void SaveUserControl(bool IsDraft)
        {
            base.SaveUserControl(IsDraft);
            var amEntity = new AuditMessageEntity
            {
                AuditId = lbAuditId.Text,
                WorkflowId = lbWorkflowId.Text,
                WorkflowInsId = lbWorkflowInsId.Text,
                WorktaskId = lbWorktaskId.Text,
                WorktaskInsId = lbWorktaskInsId.Text,
                OperatorInsId = lbOperatorInsId.Text,
                AuditUserId = lbUserId.Text,
                AuditUserName = lbUserName.Text,
                AuditArch = lbArch.Text,
                AuditDuty = lbDuty.Text
            };

            if (rbtOk.Checked)
                amEntity.AuditResult = "同意";
            else if (rbtNo.Checked)
                amEntity.AuditResult = "拒绝";
            amEntity.Message = tbxMessage.Text;
            switch (CtrlState)
            {
                case WorkConst.STATE_ADD:
                    RDIFrameworkService.Instance.WorkFlowHelperService.InsertAuditMessage(Utils.UserInfo, amEntity);
                    break;
                case WorkConst.STATE_MOD:
                    RDIFrameworkService.Instance.WorkFlowHelperService.UpdateAuditMessage(Utils.UserInfo, amEntity);
                    break;
            }
        }
    }
}