using System;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmSubWorkFlowNode.cs
    /// 子流程节点配置
    /// 
    /// 
    /// </summary>
    public partial class FrmSubWorkFlowNode : BaseForm_Single
    {
        public SubFlowTask NowTask;
        public string UserId = "";
        public string fmState = "";
        public string UserName = "";//操作人姓名，用作显示。
        public string WorkflowId = "";
        public string SubId = "";
        public string WorkTaskId = "";
        public string SubWorkflowId = "";
        public string SubWorkflowCaption = "";
        public string SubStartTaskId = "";
        public string Description = "";

        public FrmSubWorkFlowNode(SubFlowTask subTask, string userId, string userName)
        {
            InitializeComponent();
            NowTask = subTask;
            this.UserId = userId;
            this.UserName = userName;
        }

        public override void FormOnLoad()
        {
            InitData();
        }

        private void InitData()
        {
            var dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetSubWorkflowTable(this.UserInfo, NowTask.WorkFlowId, NowTask.TaskId);
            if (dt != null && dt.Rows.Count > 0)
            {
                fmState = WorkConst.STATE_MOD;//修改
                SubId = dt.Rows[0]["SubId"].ToString();
                WorkflowId = dt.Rows[0]["WorkflowId"].ToString();
                WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                SubWorkflowId = dt.Rows[0]["subWorkflowId"].ToString();
                SubStartTaskId = dt.Rows[0]["subStartTaskId"].ToString();
                SubWorkflowCaption = dt.Rows[0]["SubWorkflowCaption"].ToString();
                Description = dt.Rows[0]["Description"].ToString();

                tbxWorkflowCaption.Text = SubWorkflowCaption;
                var dt1 = RDIFrameworkService.Instance.WorkFlowTemplateService.GetStartTask(this.UserInfo, SubWorkflowId);
                cbxStartTasks.DisplayMember = "TaskCaption";
                cbxStartTasks.ValueMember = "WorkTaskId";
                cbxStartTasks.DataSource = dt1;
                cbxStartTasks.SelectedValue = SubStartTaskId;
                tbxTaskDes.Text = Description;
                this.Text = @"新建子流程配置";
            }
            else
            {
                fmState = WorkConst.STATE_ADD;
                SubId = BusinessLogic.NewGuid();
                WorkflowId = NowTask.WorkFlowId;
                WorkTaskId = NowTask.TaskId;
                this.Text = @"修改子流程配置";
            }
        }

        private void btnSelectWf_Click(object sender, EventArgs e)
        {
            var tmpfmSelectWf = new FrmSelectWorkFlow();
            tmpfmSelectWf.ShowDialog();
            var dlr = tmpfmSelectWf.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectWf.lvWorkflow.SelectedItems.Count > 0)
            {
                tbxWorkflowCaption.Text = tmpfmSelectWf.lvWorkflow.SelectedItems[0].Text;
                SubWorkflowId = tmpfmSelectWf.lvWorkflow.SelectedItems[0].SubItems[1].Text;
                var dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetStartTask(this.UserInfo, SubWorkflowId);
                cbxStartTasks.DisplayMember = "TaskCaption";
                cbxStartTasks.ValueMember = "WorkTaskId";
                cbxStartTasks.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxWorkflowCaption.Text.Length < 0)
            {
                MessageBoxHelper.ShowWarningMsg("请选择子流程!");
                return;
            }
            if (cbxStartTasks.SelectedItem == null)
            {
                MessageBoxHelper.ShowWarningMsg("请选择子流程的接入节点!");
                return;
            }
            Description = tbxTaskDes.Text;
            SubWorkflowCaption = tbxWorkflowCaption.Text;
            SubStartTaskId = cbxStartTasks.SelectedValue.ToString();

            var subworkflow = new SubWorkFlowEntity
            {
                SubId = SubId,
                WorkFlowId = WorkflowId,
                WorkTaskId = WorkTaskId,
                SubWorkFlowId = SubWorkflowId,
                SubWorkFlowCaption = SubWorkflowCaption,
                SubStartTaskId = SubStartTaskId,
                Description = Description
            };

            if (fmState == WorkConst.STATE_ADD)
            {
                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertSubWorkFlow(this.UserInfo, subworkflow);
            }
            else
            {
                RDIFrameworkService.Instance.WorkFlowTemplateService.UpdateSubWorkFlow(this.UserInfo, subworkflow);
            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
