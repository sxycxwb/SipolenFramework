using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eWorld.UI;

namespace RDIFramework.WebApp.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class StartWorkFlow : BasePage
    {
        string workflowId = "";
        string worktaskId = "";
        string workflowInsId = "";
        string worktaskInsId = "";
        string pageState = "";//新建,修改,查看
        ArrayList UserCtrlList = new ArrayList();//控件列表

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    InitData();
            //}
            InitData();
        }

        private void InitData()
        {
            if (Request["workFlowId"] != null && Request["workTaskId"] != null)
            {
                workflowId = Request["workFlowId"];
                worktaskId = Request["workTaskId"];

                DataTable dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskTable(this.UserInfo,worktaskId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lbWorkflowCaption.Text = dt.Rows[0]["FLOWCAPTION"].ToString();
                    lbStartTaskCaption.Text = dt.Rows[0]["TASKCAPTION"].ToString();
                }
            }
            /*
            if (Request["workTaskInsId"] != null)
            {
                string worktaskIns = Request["workTaskInsId"];
                DataTable dt = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskInsTable(this.UserInfo, worktaskIns);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lbWorkflowCaption.Text = dt.Rows[0]["FLOWCAPTION"].ToString();
                    lbStartTaskCaption.Text = dt.Rows[0]["TASKCAPTION"].ToString();
                }
            }
             */
            tbxFlowNo.Text = "WF-" + DateTime.Now.ToString("yyyymmddhhmmss");//--流程号
            var entity = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowInfo(this.UserInfo, workflowId);
            tbxWorkflowCaption.Text = entity.FlowCaption + tbxFlowNo.Text;
            workflowInsId = BusinessLogic.NewGuid();
            worktaskInsId = BusinessLogic.NewGuid();
            //加载用户控件
            DataTable dtUserContorl = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo, worktaskId);
            var dataRows = dtUserContorl.Select("ISNULL(PATH,NULL) IS NOT NULL", "CONTROLORDER");
            string ctrlPath = "";
            string ctrlState = "";
            string ctrlID = "";
            pageState = WorkConst.STATE_ADD;
            foreach (DataRow dr in dataRows)
            {
                var panel = new CollapsablePanel
                {
                    CollapseImageUrl = "../Content/images/collapse.png",
                    ExpandImageUrl = "../Content/images/expand.png",
                    ExpandText = "展开",
                    CollapseText = "关闭",
                    Visible = true,
                    BorderStyle = BorderStyle.Dotted,
                    BorderWidth = 1,
                    TitleText = dr[UserControlsTable.FieldFullName].ToString(),
                    BorderColor =System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (153)))),((int) (((byte) (102))))),
                    CollapserAlign = HorizontalAlignment.Left
                };
                panel.ExpandText = dr[UserControlsTable.FieldFullName].ToString();
                ctrlPath = dr[UserControlsTable.FieldPath].ToString();
                string filename = Server.MapPath(@"..\" + ctrlPath);//用户控件文件名
                ctrlState = dr["CONTROLSTATE"].ToString();
                ctrlID = dr[UserControlsTable.FieldId].ToString();
                if (FileHelper.Exists(filename))
                {
                    var baseUc = (BaseUserControl)this.LoadControl(@"..\" + ctrlPath);
                    baseUc.ID = ctrlID;
                    baseUc.WorkFlowId = workflowId;
                    baseUc.PageState = pageState;
                    baseUc.CtrlState = ctrlState;
                    baseUc.WorkFlowInsId = workflowInsId;
                    baseUc.WorkTaskId = worktaskId;
                    baseUc.WorkTaskInsId = worktaskInsId;
                    baseUc.InitUserControl();//执行控件的初始化事件
                    UserCtrlList.Add(baseUc);//加到用户控件列表中
                    panel.Controls.Add(baseUc);
                }
                else
                {
                    var l = new Label {ForeColor = Color.Red, Text = filename + "业务表单文件不存在或者没有配置表单,无法加载表单!"};
                    panel.Controls.Add(l);
                }
                ctrlPlace.Controls.Add(panel);
            }
            //加载命令按钮
            GenerateButton();
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns>工具栏HTML</returns>
        private void GenerateButton()
        {
            DataTable taskCommand =RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCommands(this.UserInfo, workflowId,worktaskId);
            foreach (DataRow dr in taskCommand.Rows)
            {
                string cmdName = dr["CommandName"].ToString();
                var btnCommand = new Button {Text = cmdName};
                btnCommand.Click += RunButtonEvent;
                cmdBtnPlace.Controls.Add(btnCommand);
                var lab1 = new Literal {Text = "&nbsp;&nbsp;"};
                cmdBtnPlace.Controls.Add(lab1);
            }
        }
        
        /// <summary>
        /// 控制流程流转的命令按钮，如提交等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RunButtonEvent(object sender, EventArgs e)
        {
            if (SaveUserControl(false))
            {
                string command = (sender as Button).Text;
                var wfruntime = new WorkFlowRuntime
                {
                    UserId = UserInfo.Id,
                    WorkFlowId = workflowId,
                    WorkTaskId = worktaskId,
                    WorkFlowInstanceId = workflowInsId,
                    WorkTaskInstanceId = worktaskInsId,
                    WorkFlowNo = tbxFlowNo.Text,
                    CommandName = command,
                    Priority = drpPriority.SelectedValue,
                    WorkflowInsCaption = tbxWorkflowCaption.Text,
                    Description = tbxWorkflowDes.Text,
                    IsDraft = false,
                    CurrentUser = this.UserInfo
                };
                //wfruntime.RunSuccess += WFRuntime_RunSuccess;//流程成功启动时执行的事件
                //wfruntime.RunFail += WFRuntime_RunFail;//流程启动失败时执行的事件
                string returnStatusCode =  wfruntime.Start();
                //if (returnStatusCode == WorkFlowConst.SuccessCode)
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('提交成功，请关闭窗体！');window.close();", true);
                //}
                Response.Redirect("OperTips.aspx?worktaskInsId=" + worktaskInsId);
            }
        }

        /// <summary>
        /// 保存表单业务数据
        /// </summary>
        private bool SaveUserControl(bool isDraft)
        {
            if (pageState == WorkConst.STATE_VIEW) return true;

            if (tbxWorkflowCaption.Text.Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('流程业务名不能为空！');", true);
                tbxWorkflowCaption.Focus();
                return false;
            }
            try
            {
                foreach (BaseUserControl bc in UserCtrlList)
                {
                    if (bc.CtrlState == WorkConst.STATE_VIEW) continue;//查看状态不执行保存
                    bc.SaveUserControl(isDraft);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.close();", true);
        }
    }
}