using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmAuditForm.cs
    /// 审批信息
    /// 
    /// </summary>
    public partial class FrmAuditForm : FrmBaseBizeForm
    {
        private AuditMessageEntity messageEntity = null;
        public FrmAuditForm()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            base.FormOnLoad();
            this.InitData();
            this.SetControlState();
        }

        public override void SetControlState()
        {
            if (!string.IsNullOrEmpty(this.PageState))
            {
                this.pnlTool.Enabled = this.PageState != WorkConst.STATE_VIEW;
                return;
            }

            if (!string.IsNullOrEmpty(this.CtrlState))
            {
                btnSave.Enabled = this.CtrlState != "查看";
            }
            else
            {
                pnlTool.Enabled = false;
            }
        }

        private void InitData()
        {
            DataTable dt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAuditMessageTableByOper(this.UserInfo, OperatorInsId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string result = "";
                messageEntity = BaseEntity.Create<AuditMessageEntity>(dt);
                txtUserId.Text = dt.Rows[0][AuditMessageTable.FieldAuditUserId].ToString();
                txtUserName.Text = dt.Rows[0][AuditMessageTable.FieldAuditUserName].ToString();
                txtDepartment.Text = dt.Rows[0][AuditMessageTable.FieldAuditArch].ToString();
                txtDuty.Text = dt.Rows[0][AuditMessageTable.FieldAuditDuty].ToString();
                result = dt.Rows[0][AuditMessageTable.FieldAuditResult].ToString();
                if (result == "同意")
                {
                    rbAggree.Checked = true;
                }
                else
                {
                    rbDisAggree.Checked = true;
                }
                txtAuditMessage.Text = dt.Rows[0][AuditMessageTable.FieldMessage].ToString();
                CtrlState = WorkConst.STATE_MOD;
            }
            else
            {
                txtUserId.Text = UserId;
                txtUserName.Text = UserName;
                txtDepartment.Text = ArchCaption;
                txtDuty.Text = DutyCaption;
                CtrlState = WorkConst.STATE_ADD;
            }
        }

        public override void SaveFormData(bool isDraft)
        {
            base.SaveFormData(isDraft);
            AuditMessageEntity amEntity = null;
            if (CtrlState == WorkConst.STATE_ADD)
            {
                amEntity = new AuditMessageEntity
                {
                    AuditId = BusinessLogic.NewGuid(),
                    WorkflowId = WorkFlowId,
                    WorkflowInsId = WorkFlowInsId,
                    WorktaskId = WorkTaskId,
                    WorktaskInsId = WorkTaskInsId,
                    OperatorInsId = OperatorInsId
                };
            }
            else
            {
                amEntity = messageEntity;
            }

            amEntity.AuditUserId = txtUserId.Text;
            amEntity.AuditUserName = txtUserName.Text;
            amEntity.AuditArch = txtDepartment.Text;
            amEntity.AuditDuty = txtDuty.Text;
            amEntity.AuditResult = rbAggree.Checked ? "同意" : "拒绝";
            amEntity.Message = txtAuditMessage.Text;
            amEntity.AuditTime = DateTime.Now;
            if (CtrlState == WorkConst.STATE_ADD)
            {
                RDIFrameworkService.Instance.WorkFlowHelperService.InsertAuditMessage(this.UserInfo, amEntity);
            }
            else if(CtrlState == WorkConst.STATE_MOD)
            {
                RDIFrameworkService.Instance.WorkFlowHelperService.UpdateAuditMessage(this.UserInfo, amEntity);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveFormData(false);
                MessageBoxHelper.ShowSuccessMsg("保存成功！");
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
        }
    }
}
