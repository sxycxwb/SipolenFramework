using System;
using System.Globalization;


namespace RDIFramework.WebApp.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class OperTips : BasePage
    {
        string worktaskInsId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }
        private void InitData()
        {
            if (Request["worktaskInsId"] != null)
            {
                worktaskInsId = Request["worktaskInsId"].ToString(CultureInfo.InvariantCulture);
                string taskToWhoMsg = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskToWhoMsg(this.UserInfo, worktaskInsId);
                string resultMsg = RDIFrameworkService.Instance.WorkFlowInstanceService.GetResultMsg(this.UserInfo, worktaskInsId);
                string title = "操作结果:" + resultMsg;
                if (taskToWhoMsg.Length <= 0)
                {
                    taskToWhoMsg = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";
                    if (resultMsg == WorkFlowConst.WorkflowOverMsg)//流程结束
                    {
                        taskToWhoMsg = "流程结束!";
                    }
                    if (resultMsg == WorkFlowConst.TaskBackMsg)
                    {
                        taskToWhoMsg = WorkFlowConst.TaskBackMsg;
                    }
                }

                taskToWhoMsg = "成功提交至:" + taskToWhoMsg + "。你已完成该任务处理,可以关闭该窗口。";

                var builder = new System.Text.StringBuilder();
                builder.Append("<script>\r\n");
                builder.Append("setTimeout('Finish();',1000);\r\n");
                builder.Append("function Finish(){\r\n");
                builder.Append("document.all('Image2').src='/Content/images/rdiframework.ico';\r\n");
                builder.Append("document.all('" + this.lbTitle.ClientID + "').innerText='" + title + "';\r\n");
                builder.Append("document.all('" + this.lbDescription.ClientID + "').innerText='" + taskToWhoMsg + "';\r\n");
                //builder.Append("alert('ok');\r\n");
                //  builder.Append("clearTimeout();\r\n");
                builder.Append("}\r\n");
                builder.Append("</script>\r\n");
                this.Page.RegisterClientScriptBlock("test", builder.ToString());
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string title = "ok";
            string description = "yes";
            var builder = new System.Text.StringBuilder();
            builder.Append("<script>\r\n");
            builder.Append("setTimeout('Finish();',1000);\r\n");
            builder.Append("function Finish(){\r\n");
            builder.Append("document.all('Image2').src='/Content/images/rdiframework.ico';\r\n");
            builder.Append("document.all('" + this.lbTitle.ClientID + "').innerText='" + title + "';\r\n");
            builder.Append("document.all('" + this.lbDescription.ClientID + "').innerText='" + description + "';\r\n");
            // builder.Append("alert('ok');\r\n");
            //  builder.Append("clearTimeout();\r\n");
            builder.Append("}\r\n");
            builder.Append("</script>\r\n");
            this.Page.RegisterClientScriptBlock("test", builder.ToString());
        }
    }
}