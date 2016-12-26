using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDIFramework.BizLogic;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.Utilities;
    public partial class FrmTaskReturn : BaseForm
    {
        public FrmTaskReturn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定的退回步骤
        /// </summary>
        public DataTable DTWorkFlowStepSource { get; set; }

        /// <summary>
        /// 操作者实例Id
        /// </summary>
        public string OperatorInstanceId { get;set;}

        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string WorkFlowInsId { get; set; }

        public override void FormOnLoad()
        {
            this.BindWorkFlowStepCombo();
        }

        private void BindWorkFlowStepCombo()
        {
            if (this.DTWorkFlowStepSource != null && this.DTWorkFlowStepSource.Rows.Count > 0)
            {
                this.cboWorkStep.DataSource = this.DTWorkFlowStepSource;
                this.cboWorkStep.ValueMember = "Value";
                this.cboWorkStep.DisplayMember = "Text";
                this.cboWorkStep.SelectedIndex = 0;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(this.txtBackCause.Text))
            {
                MessageBoxHelper.ShowWarningMsg("请填写退回原因!");
                this.txtBackCause.Focus();
                return false;
            }
            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string selectWorkFlowInsId = BusinessLogic.ConvertToString(cboWorkStep.SelectedValue);
            if (!this.CheckInput())
            {
                return;
            }

            if (this.OperatorInstanceId != null && selectWorkFlowInsId == "退回到上一步")
            {
                OperatorInstanceId = this.OperatorInstanceId;
                var wfRuntime = new WorkFlowRuntime
                {
                    UserId = this.UserInfo.Id,
                    backyy = txtBackCause.Text,
                    OperatorInstanceId = OperatorInstanceId,
                    CurrentUser = this.UserInfo
                };
                wfRuntime.TaskBack();
                MessageBoxHelper.ShowSuccessMsg("退回成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            //任意退回
            if (this.OperatorInstanceId != null && !string.IsNullOrEmpty(txtBackCause.Text) && selectWorkFlowInsId != "退回到上一步")
            {
                OperatorInstanceId = this.OperatorInstanceId;
                WorkFlowInsId = selectWorkFlowInsId;
                var wfRuntime = new WorkFlowRuntime
                {
                    UserId = this.UserInfo.Id,
                    backyy = txtBackCause.Text,
                    OperatorInstanceId = OperatorInstanceId,
                    //WorkTaskId = selectWorkFlowInsId,
                    WorkFlowInstanceId = WorkFlowInsId,
                    CurrentUser = this.UserInfo
                };
                wfRuntime.TaskBackry();
                MessageBoxHelper.ShowSuccessMsg("任意退回成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
