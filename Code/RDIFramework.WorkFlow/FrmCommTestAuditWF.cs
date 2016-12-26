using System;
using System.Data;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmCommTestAuditWF : BaseForm
    {
        public string operatorInsId = "";
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public string WorkFlowInsId = "";
        public string WorkTaskInsId = "";

        public FrmCommTestAuditWF()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            //取流程信息
            var dt = RDIFrameworkService.Instance.WorkFlowInstanceService.GetOperatorInstance(this.UserInfo, operatorInsId);
            textBox2.Text = dt.Rows[0]["FlowCaption"].ToString();//流程名称
            textBox3.Text = dt.Rows[0]["TaskCaption"].ToString();//任务名称
            textBox4.Text = dt.Rows[0]["FlowInsCaption"].ToString();//流程实例名称
            WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();//流程实例Id
            WorkFlowId = dt.Rows[0]["workflowId"].ToString();//流程Id
            WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();//任务Id
            WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();//任务实例Id
            //取业务信息
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginSelect("TestSaleRetail");
            sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
            var saledt = sqlBuilder.EndSelect();
            if (saledt != null && saledt.Rows.Count > 0)
            {
                textBox1.Text = saledt.Rows[0]["Bill_Caption"].ToString();
                txtBill_sMoney.Text =BusinessLogic.ConvertToString(saledt.Rows[0]["Bill_sMoney"].ToString());
                string flag = BusinessLogic.ConvertToString(saledt.Rows[0]["Bill_AuditFlag"].ToString());
                if (!string.IsNullOrEmpty(flag))
                {
                    switch (flag)
                    {
                        case "1":
                            txtBill_AuditFlag.Text = "直接出库";
                            break;
                        case "2":
                            txtBill_AuditFlag.Text = "出库确认";
                            break;
                        case "3":
                            txtBill_AuditFlag.Text = "不同意出库";
                            break;
                        case "0":
                            txtBill_AuditFlag.Text = "不确定出库类型";
                            break;
                    }
                }
            }
            else
            {

            }
            //取审批列表
            dataGridView1.AutoGenerateColumns = false;
            DataTable auditDt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAuditMessageTableByFlow(this.UserInfo, WorkFlowInsId);
            dataGridView1.DataSource = auditDt;
        }

        private void saveData()
        {
            var am = new AuditMessageEntity
            {
                AuditId = Guid.NewGuid().ToString(),
                WorkflowId = WorkFlowId,
                WorkflowInsId = WorkFlowInsId,
                WorktaskId = WorkTaskId,
                WorktaskInsId = WorkTaskInsId,
                Message = textBox5.Text,
                AuditUserId = UserInfo.Id,
                AuditUserName = UserInfo.UserName,
                AuditResult = radioButton1.Checked ? radioButton1.Text : radioButton2.Text
            };
            RDIFrameworkService.Instance.WorkFlowHelperService.InsertAuditMessage(this.UserInfo, am);
        }

        #region 流程流转成功时触发的事件，保存草稿时不触发
        private void wfruntime_RunSuccess(object sender, WorkFlowEventArgs e)
        {
            var TaskToWhoMsg = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskToWhoMsg(this.UserInfo,WorkTaskInsId);
            var ResultMsg = e.ResultMsg; //RDIFrameworkService.Instance.WorkFlowInstanceService.GetResultMsg(this.UserInfo,WorkTaskInsId);

            var title = "操作结果:" + ResultMsg;
            if (TaskToWhoMsg.Length <= 0)
            {
                TaskToWhoMsg = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";
                if (ResultMsg == WorkFlowConst.WorkflowOverMsg)//流程结束
                {
                    TaskToWhoMsg = "流程结束!";
                }
                if (ResultMsg == WorkFlowConst.TaskBackMsg)
                {
                    TaskToWhoMsg = WorkFlowConst.TaskBackMsg;
                }
            }

            TaskToWhoMsg = "成功提交至:" + TaskToWhoMsg + "。你已完成该任务处理,可以关闭该窗口。";
            MessageBoxHelper.ShowSuccessMsg("提交成功!" + TaskToWhoMsg);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion

        #region 流程流转失败时触发的事件，保存草稿时不触发
        private void wfruntime_RunFail(object sender, WorkFlowEventArgs e)
        {
            MessageBoxHelper.ShowWarningMsg("提交失败!" + e.ResultMsg);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion

        private void ucButton1_Click(object sender, EventArgs e)
        {
            //保存数据到数据库
            saveData();
            var wfruntime = new WorkFlowRuntime();
            wfruntime.RunSuccess += wfruntime_RunSuccess;
            wfruntime.RunFail += wfruntime_RunFail;
            wfruntime.IsDraft = false;//true 表示保存草稿,执行Run方法的时候流程不流转
            wfruntime.CurrentUser = this.UserInfo;
            wfruntime.Run(UserInfo.Id, operatorInsId, "提交");//命令分支，必须与建模中的命令定义名相同，否则无法流转
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保存数据到数据库
            saveData();
            var wfruntime = new WorkFlowRuntime();
            wfruntime.RunSuccess += wfruntime_RunSuccess;
            wfruntime.RunFail += wfruntime_RunFail;
            wfruntime.IsDraft = false;//true 表示保存草稿,执行Run方法的时候流程不流转
            wfruntime.CurrentUser = this.UserInfo;
            wfruntime.Run(UserInfo.Id, operatorInsId, "提交");//命令分支，必须与建模中的命令定义名相同，否则无法流转
        }
    }
}
