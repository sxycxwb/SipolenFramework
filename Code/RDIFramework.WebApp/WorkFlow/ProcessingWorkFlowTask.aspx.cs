using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using eWorld.UI;

namespace RDIFramework.WebApp.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class ProcessingWorkFlowTask : BasePage
    {
        string workUserId = "";//流程操作人员
        string workFlowId = "";
        string workTaskId = "";
        string workFlowInsId = "";
        string workTaskInsId = "";
        string operatorInsId = "";
        string eorr = "";//显示错误
        string taskInsCaption = "";
        string pageState = "";//新建,修改,查看
        string operStatus = "";//操作状态,0 未处理未认领，1处理完成，2指派他人，3认领未处理
        ArrayList UserCtrlList = new ArrayList();//控件列表

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    InitPageData();
            //}
            InitPageData();
        }

        private void InitPageData()
        {
            if (Request["state"] != null)
            {
                pageState = Request["state"].ToString(CultureInfo.InvariantCulture);
            }
            string tmpWorkTaskId = Request["workTaskId"].ToString(CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(tmpWorkTaskId))
            {
                DataTable dtWorkTask =RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskTable(this.UserInfo, tmpWorkTaskId);
                if (dtWorkTask != null && dtWorkTask.Rows.Count > 0)
                {
                    lbWorkflowCaption.Text = dtWorkTask.Rows[0]["FLOWCAPTION"].ToString();
                    lbStartTaskCaption.Text = dtWorkTask.Rows[0]["TASKCAPTION"].ToString();
                }
            }

            if (Request["operatorInsId"] != null)
            {
                operatorInsId = Request["operatorInsId"].ToString(CultureInfo.InvariantCulture);

                DataTable dt = RDIFrameworkService.Instance.WorkFlowInstanceService.GetOperatorInstance(this.UserInfo, operatorInsId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    workFlowId = dt.Rows[0]["WORKFLOWID"].ToString();
                    workFlowInsId = dt.Rows[0]["WORKFLOWINSID"].ToString();
                    workTaskId = dt.Rows[0]["WORKTASKID"].ToString();
                    workTaskInsId = dt.Rows[0]["WORKTASKINSID"].ToString();
                    lbFlowInsCaption.Text = dt.Rows[0]["FLOWINSCAPTION"].ToString();
                    lbFlowNo.Text = dt.Rows[0]["WORKFLOWNO"].ToString();
                    lbWorkflowDes.Text = dt.Rows[0]["DESCRIPTION"].ToString();
                    lbTaskCaption.Text = dt.Rows[0]["TASKINSCAPTION"].ToString();
                    //lbTitle.Text = lbTaskCaption.Text;

                    lbUser.Text = dt.Rows[0]["POPERATEDDES"].ToString();
                    lbTime.Text = dt.Rows[0]["TASKSTARTTIME"].ToString();
                    string tmpPriority = BusinessLogic.ConvertToString(dt.Rows[0]["PRIORITY"]);
                    if (!string.IsNullOrEmpty(tmpPriority) && tmpPriority.Trim().Length > 0)
                    {
                        drpPriority.SelectedIndex = Convert.ToInt16(dt.Rows[0]["PRIORITY"]) - 1;
                    }

                    operStatus = dt.Rows[0]["OPERSTATUS"].ToString();
                    taskInsCaption = dt.Rows[0]["TASKINSCAPTION"].ToString();
                    workUserId = dt.Rows[0]["USERID"].ToString();
                    string msg = dt.Rows[0]["POPERATEDDES"].ToString();
                    String[] str = msg.Split(',');
                    btn1.Value = "退回给[" + str[0] + "]修改";

                    //加载用户控件
                    DataTable dtUserContorl = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo, workTaskId);
                    var dataRows = dtUserContorl.Select("ISNULL(PATH,NULL) IS NOT NULL", "CONTROLORDER");
                    string ctrlPath = "";
                    string ctrlState = "";
                    string ctrlID = "";
                    //pageState = WorkConst.STATE_ADD;
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
                            BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102))))),
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
                            baseUc.WorkFlowId = workFlowId;
                            baseUc.PageState = pageState;
                            //如果全页只读，每个UserControl的ctrlSate失效
                            baseUc.CtrlState = pageState == WorkConst.STATE_VIEW ? WorkConst.STATE_VIEW : ctrlState;
                            baseUc.WorkFlowInsId = workFlowInsId;
                            baseUc.WorkTaskId = workTaskId;
                            baseUc.WorkTaskInsId = workTaskInsId;
                            baseUc.OperatorInsId = operatorInsId;
                            baseUc.InitUserControl();//执行控件的初始化事件
                            UserCtrlList.Add(baseUc);//加到用户控件列表中
                            panel.Controls.Add(baseUc);
                        }
                        else
                        {
                            var l = new Label { ForeColor = Color.Red, Text = filename + "业务表单文件不存在或者没有配置表单,无法加载表单!" };
                            panel.Controls.Add(l);
                        }
                        ctrlPlace.Controls.Add(panel);
                    }
                }
                if (pageState == WorkConst.STATE_VIEW)
                {
                    var btnCommand = new Button { Text = "撤回修改", ID = "btnRevokeTask" };
                    btnCommand.Click += RevokeTaskButtonEvent;
                    btnCommand.Enabled = (pageState == WorkConst.STATE_VIEW);
                    cmdBtnPlace.Controls.Add(btnCommand);
                    var lab1 = new Literal {Text = "&nbsp;&nbsp;"};
                    cmdBtnPlace.Controls.Add(lab1);
                } 
                GeneralCommonButton();//常用的按钮
                string worktaskInsid = Request["WORKTASKINSID"].ToString(CultureInfo.InvariantCulture);
                //查看是否是当前用户可以操作
                bool isCurrentUserOper = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskpd(this.UserInfo, worktaskInsid, this.UserInfo.Id);
                if (isCurrentUserOper)
                {
                    GeneratePowerButton();//根据控制权限创建的按钮
                }
            }
        }

        /// <summary>
        /// 根据控制权限创建的按钮
        /// </summary>
        private void GeneratePowerButton()
        {
            DataTable dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskPower(this.UserInfo, workFlowId, workTaskId);
            string powerStr = dt.Rows.Cast<DataRow>().Aggregate("", (current, dr) => current + dr["PowerName"].ToString() + ",");

            if (powerStr.IndexOf(WorkConst.WorkTask_Returnry, System.StringComparison.Ordinal) > -1 || 
                powerStr.IndexOf(WorkConst.WorkTask_Return, System.StringComparison.Ordinal) > -1)//允许（任意）退回
            {
                btn1.Visible = true;
            }

            if (powerStr.IndexOf(WorkConst.WorkTask_Assign, System.StringComparison.Ordinal) > -1)//允许指派
            {
                var btnCommand = new Button
                {
                    Text = "指派",
                    Enabled = (pageState != WorkConst.STATE_VIEW && operStatus != "0"),
                    ID = "btnAssignTask",
                    OnClientClick = "return assignTask();"
                };
                //btnCommand.Click += new EventHandler(taskAssignButtonEvent); //指派他人执行
                cmdBtnPlace.Controls.Add(btnCommand);
                var lab1 = new Literal {Text = "&nbsp;&nbsp;"};
                cmdBtnPlace.Controls.Add(lab1);
            }
            if (powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext, System.StringComparison.Ordinal) > -1)//允许动态指定下一步处理人
            {
                var c = (BaseUserControl)this.LoadControl(@"Common\DyAssignNext.ascx");
                c.WorkFlowId = workFlowId;
                c.ID = "nextCtrl";//必须指定名称。js代码才能取到
                c.PageState = pageState;
                c.CtrlState = WorkConst.STATE_MOD;
                c.WorkFlowInsId = workFlowInsId;
                c.WorkTaskId = workTaskId;
                c.WorkTaskInsId = workTaskInsId;
                c.OperatorInsId = operatorInsId;
                c.InitUserControl();//执行控件的初始化事件
                UserCtrlList.Add(c);//加到用户控件列表中
                DyAssignPlace.Controls.Add(c);
            }
            InitButton();//流程按钮
        }

        private void InitButton()
        {
            DataTable taskCommand = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCommands(this.UserInfo, workFlowId, workTaskId);
            foreach (DataRow dr in taskCommand.Rows)
            {
                string cmdName = dr["CommandName"].ToString();
                var btnCommand = new Button
                {
                    Text = cmdName,
                    Enabled = (pageState != WorkConst.STATE_VIEW && operStatus != "0")
                };
                btnCommand.Click += RunButtonEvent;
                cmdBtnPlace.Controls.Add(btnCommand);
                var lab1 = new Literal { Text = "&nbsp;&nbsp;" };
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
                    CurrentUser = this.UserInfo
                };

                string returnStatusCode = wfruntime.Run(this.UserInfo.Id, operatorInsId, command);
              
                Response.Redirect("OperTips.aspx?worktaskInsId=" + workTaskInsId);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('您好！出现以下错误未能提交流程。" + eorr + "');", true);
            }
        }

        #region 常用按钮,认领,草稿,放弃
        /// <summary>
        /// 常用按钮,认领,草稿,放弃
        /// </summary>
        private void GeneralCommonButton()
        {
            var btnCommand = new Button { Text = "认领", ID = "btnClaim" };
            btnCommand.Click += ClaimButtonEvent;
            btnCommand.OnClientClick = "return(confirm('确认认领当前任务吗?'));";
            btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && operStatus == "0");
            cmdBtnPlace.Controls.Add(btnCommand);
            var lab1 = new Literal {Text = "&nbsp;&nbsp;"};
            cmdBtnPlace.Controls.Add(lab1);

            btnCommand = new Button {Text = "草稿", ID="btnDraft"};
            btnCommand.Click += SaveButtonEvent;
            btnCommand.OnClientClick = "return(confirm('是否保存为草稿?'));";
            btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && operStatus != "0");
            cmdBtnPlace.Controls.Add(btnCommand);
            lab1 = new Literal {Text = "&nbsp;&nbsp;"};
            cmdBtnPlace.Controls.Add(lab1);

            btnCommand = new Button { Text = "放弃认领", ID = "btnUnClaim" };
            btnCommand.Click += TaskAbnegateButtonEvent;
            btnCommand.OnClientClick = "return(confirm('确认放弃认领当前任务吗?'));";
            btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && operStatus != "0" && operStatus != "1" && workUserId == this.UserInfo.Id);
            cmdBtnPlace.Controls.Add(btnCommand);

            lab1 = new Literal {Text = "&nbsp;&nbsp;"};
            cmdBtnPlace.Controls.Add(lab1);
        }

        /// <summary>
        /// 草稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButtonEvent(object sender, EventArgs e)
        {
            if (SaveUserControl(true))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('保存草稿成功！');", true);
            }
        }

        /// <summary>
        /// 任务放弃认领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskAbnegateButtonEvent(object sender, EventArgs e)
        {
            var wfruntime = new WorkFlowRuntime
            {
                UserId = this.UserInfo.Id,
                OperatorInstanceId = operatorInsId,
                CurrentUser = this.UserInfo
            };
            wfruntime.TaskUnClaim();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('放弃认领成功！');", true);
            Response.Redirect(Request.RawUrl);//刷新页面
        }

        /// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClaimButtonEvent(object sender, EventArgs e)
        {
            var wfruntime = new WorkFlowRuntime
            {
                UserId = this.UserInfo.Id,
                OperatorInstanceId = operatorInsId,
                CurrentUser = this.UserInfo
            };
            wfruntime.TaskClaim();
            Response.Redirect(Request.RawUrl);//刷新页面
        }
        #endregion

        /// <summary>
        /// 撤回任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RevokeTaskButtonEvent(object sender, EventArgs e)
        {
            var wfruntime = new WorkFlowRuntime
            {
                UserId = this.UserInfo.Id,
                MainWorktaskInsId = workTaskInsId,
                CurrentUser = this.UserInfo
            };
            string msg = wfruntime.TaskRevoke();
            if (msg == "1")
            {
                Response.Redirect("OperTips.aspx?worktaskInsId=" + workTaskInsId);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('您好,对方已认领的任务不能撤回！');", true);
            }
        }

        /// <summary>
        /// 保存表单业务数据
        /// </summary>
        private bool SaveUserControl(bool isDraft)
        {
            try
            {
                if (pageState == WorkConst.STATE_VIEW) return true;
                bool lczc = true;
                foreach (BaseUserControl bc in UserCtrlList)
                {
                    if (bc.CtrlState == WorkConst.STATE_VIEW) continue;
                    bc.SaveUserControl(isDraft);
                    eorr = bc.WorkFlowError;
                    lczc = bc.WorkFlowIsOk;
                }
                if (lczc) { return true; } else { return false; }

            }
            catch(Exception ex)
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