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

    public partial class FrmCommTestWF : BaseForm
    {
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public string WorkFlowInsId = "";
        public string WorkTaskInsId = "";
        public string WorkFlowNo = "";

        public FrmCommTestWF()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            //获取流程信息
            DataTable dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskTable(this.UserInfo,WorkTaskId);
            WorkFlowId = dt.Rows[0]["workflowId"].ToString();//流程Id
            txtWFTemplateName.Text = dt.Rows[0]["FlowCaption"].ToString();//流程名称
            txtTaskTemplateName.Text = dt.Rows[0]["TaskCaption"].ToString();//任务名称
            WorkFlowNo = BusinessLogic.NewGuid().Substring(0,13);
            txtWFInstanceName.Text = "流程实例" + WorkFlowNo;
            //因为是启动节点所以流程实例需要在这里创建
            WorkFlowInsId = Guid.NewGuid().ToString();
            WorkTaskInsId = Guid.NewGuid().ToString();
        }

        #region 流程流转成功时触发的事件，保存草稿时不触发
        private void WFRuntime_RunSuccess(object sender, WorkFlowEventArgs e)
        {
            string TaskToWhoMsg = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskToWhoMsg(this.UserInfo, WorkTaskInsId);
            string ResultMsg = e.ResultMsg; //WorkTaskInstance.GetResultMsg(WorkTaskInsId);

            string title = "操作结果:" + ResultMsg;
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
            MessageBoxHelper.ShowWarningMsg("提交成功!" + TaskToWhoMsg);
        }
        #endregion

        #region 流程流转失败时触发的事件，保存草稿时不触发
        private void WFRuntime_RunFail(object sender, WorkFlowEventArgs e)
        {
            MessageBoxHelper.ShowWarningMsg("提交失败!" + e.ResultMsg);
        }
        #endregion

        private void saveData()
        {
            bool result = false;
            SQLBuilder sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginInsert("TestSaleRetail");
            sqlBuilder.SetValue("WorkFlowId", WorkFlowId);
            sqlBuilder.SetValue("WorkTaskId", WorkTaskId);
            sqlBuilder.SetValue("WorkFlowInsId", WorkFlowInsId);
            sqlBuilder.SetValue("WorkTaskInsId", WorkTaskInsId);
            sqlBuilder.SetValue("ID", BusinessLogic.NewGuid());
            sqlBuilder.SetValue("Bill_Caption", txtWFTemplateName.Text);
            sqlBuilder.SetValue("Bill_sMoney", txtBill_sMoney.Text);
            string flag = "0";
            switch (cboBill_AuditFlag.Text)
            {
                case "出库确认":
                    flag = "2";
                    break;
                case "直接出库":
                    flag = "1";
                    break;
                case "不同意出库":
                    flag = "3";
                    break;
                default:
                    flag = "0";
                    break;
            }
            sqlBuilder.SetValue("Bill_AuditFlag", flag);
            sqlBuilder.SetValue("Bill_CreateID", this.UserInfo.Id);
            sqlBuilder.SetValue("Bill_CreateName", this.UserInfo.RealName);
            result = sqlBuilder.EndInsert() > 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //保存数据到数据库
            if (string.IsNullOrEmpty(txtBillName.Text))
            {
                MessageBoxHelper.ShowInformationMsg("单据名称不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtWFInstanceName.Text))
            {
                MessageBoxHelper.ShowInformationMsg("流程实例名称不能为空!");
                return;
            }

            if (string.IsNullOrEmpty(txtBill_sMoney.Text) || string.IsNullOrEmpty(cboBill_AuditFlag.Text))
            {
                MessageBoxHelper.ShowInformationMsg("单据金额与出库方式都不能为空!");
                return;
            }

            saveData();

            //下面是提交流程的代码
            var wfRunTime = new WorkFlowRuntime();
            wfRunTime.RunSuccess += WFRuntime_RunSuccess;//流程成功启动时执行的事件
            wfRunTime.RunFail += WFRuntime_RunFail;//流程启动失败时执行的事件
            wfRunTime.UserId = UserInfo.Id;//当前操作人id
            wfRunTime.WorkFlowInstanceId = WorkFlowInsId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkTaskInstanceId = WorkTaskInsId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkFlowId = WorkFlowId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkTaskId = WorkTaskId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkFlowNo = WorkFlowNo;//流程编号，可以自定义
            wfRunTime.CommandName = "提交";//命令分支，必须与建模中的命令定义名相同，否则无法流转
            wfRunTime.WorkflowInsCaption = txtWFInstanceName.Text;//可以自定义
            wfRunTime.IsDraft = true;// 表示保存草稿,执行start方法的时候流程不流转
            wfRunTime.CurrentUser = this.UserInfo; //传递当前用户
            label2.Text = wfRunTime.Start();//启动流程
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            //保存数据到数据库
            if (string.IsNullOrEmpty(txtBillName.Text))
            {
                MessageBoxHelper.ShowInformationMsg("单据名称不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtWFInstanceName.Text))
            {
                MessageBoxHelper.ShowInformationMsg("流程实例名称不能为空!");
                return;
            }
            saveData();
            var wfRunTime = new WorkFlowRuntime();
            wfRunTime.RunSuccess += WFRuntime_RunSuccess;//流程成功启动时执行的事件
            wfRunTime.RunFail += WFRuntime_RunFail;//流程启动失败时执行的事件
            wfRunTime.UserId = UserInfo.Id;//当前操作人id
            wfRunTime.WorkFlowInstanceId = WorkFlowInsId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkTaskInstanceId = WorkTaskInsId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkFlowId = WorkFlowId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkTaskId = WorkTaskId;//必须保持与业务数据中的该值相同
            wfRunTime.WorkFlowNo = WorkFlowNo;//流程编号，可以自定义
            wfRunTime.CommandName = "提交";//命令分支，必须与建模中的命令定义名相同，否则无法流转
            wfRunTime.WorkflowInsCaption = txtWFInstanceName.Text;//可以自定义
            wfRunTime.IsDraft = false;// 表示保存草稿,执行start方法的时候流程不流转
            wfRunTime.CurrentUser = this.UserInfo; //传递当前用户
            label2.Text = wfRunTime.Start();//启动流程
        }
    }
}
