using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;


namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmProcessingTask : BaseForm
    {
        /// <summary>
        /// 工作流模板Id
        /// </summary>
        public virtual string WorkFlowId { get; set; }

        /// <summary>
        /// 任务模板Id
        /// </summary>
        public virtual string WorkTaskId { get; set; }

        /// <summary>
        /// 工作流实例Id
        /// </summary>
        public virtual string WorkFlowInsId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public virtual string WorkTaskInsId { get; set; }

        /// <summary>
        /// 操作实例Id
        /// </summary>
        public virtual string OperatorInsId { get; set; }

        /// <summary>
        /// 页面状态（新建,修改,查看）
        /// </summary>
        public string PageState { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        /// <remarks>
        /// 0: 未处理未认领，1:处理完成，2:指派他人，3:认领未处理
        /// </remarks>
        public string OperStatus{ get; set; }

        string userId = "";
        string workUserid = "";//流程操作人员
        string taskinscaption = "";
        ArrayList UserContrlList = new ArrayList();//用户控件列表

        public FrmProcessingTask()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            userId = this.UserInfo.Id;
            DataTable dtOperatorIns = RDIFrameworkService.Instance.WorkFlowInstanceService.GetOperatorInstance(this.UserInfo,OperatorInsId);
            if (dtOperatorIns != null && dtOperatorIns.Rows.Count > 0)
            {
                OperStatus = dtOperatorIns.Rows[0]["OperStatus"].ToString();
                taskinscaption = dtOperatorIns.Rows[0]["TaskInsCaption"].ToString();
                workUserid = dtOperatorIns.Rows[0]["userid"].ToString();
                string msg = dtOperatorIns.Rows[0]["pOperatedDes"].ToString();
                String[] str = msg.Split(',');
                btnBackUp.Text = @"退回给[" + str[0] + @"]修改";
            }

            DataTable dtControls = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo,WorkTaskId);

            var buttomItemCommon = new ButtonItem
            {
                ButtonStyle = eButtonStyle.ImageAndText,
                ImagePosition = eImagePosition.Top,
                ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))),
                Name = @"FrmProcessingTaskCommon",
                Text = @"流程处理情况"
            };

            buttomItemCommon.Click += this.buttomItemCommon_Click;
            sideBarPanelItemDefault.SubItems.Add(buttomItemCommon);
            buttomItemCommon_Click(null, null); //加载第一个界面

            if (dtControls != null && dtControls.Rows.Count > 0)
            {
                var dataRows = dtControls.Select("ISNULL(FORMNAME,NULL) IS NOT NULL", "CONTROLORDER");
                if (dataRows.Length > 0)
                {
                    foreach (DataRow dataRow in dataRows)
                    {
                        var buttomItem = new ButtonItem
                        {
                            ButtonStyle = eButtonStyle.ImageAndText,
                            ImagePosition = eImagePosition.Top,
                            ForeColor =Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192))))),
                            Name = dataRow["WORKTASKID"].ToString(),
                            Text = dataRow["FULLNAME"].ToString(),
                            Tag = dataRow
                        };
                        buttomItem.Click += this.sideBarItem_Click;
                        sideBarPanelItemDefault.SubItems.Add(buttomItem);
                    }
                }
            }

            if (PageState == WorkConst.STATE_VIEW)
            {
                //撤回修改
                tsSeparatorTaskRevoke.Visible = btnTaskRevoke.Visible = PageState == WorkConst.STATE_VIEW;
                btnTaskRevoke.Enabled = PageState == WorkConst.STATE_VIEW;
                btnTaskRevoke.Click += RevokeTaskButtonEvent;
            }
            GeneralCmdButton();
           
            //查看是否是当前用户可以操作
            bool generatedButton = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskpd(this.UserInfo, WorkTaskInsId, userId);

            if (generatedButton)
            {
                PowerButton();//根据控制权限创建的按钮
            }
            if (tsToolButton.Items.Count > 0)
            {
                tsToolButton.Items.Add(new ToolStripSeparator());
            }
            var btnClose = new ToolStripButton("关闭") { DisplayStyle = ToolStripItemDisplayStyle.Text };
            btnClose.Click += delegate { this.Close(); };
            tsToolButton.Items.Add(btnClose);
        }


        #region 动态加载任务命令按钮,退回,指派，动态指定下一任务处理人按钮
        /// <summary>
        /// 根据权限加载 退回,指派，动态指定下一任务处理人按钮
        /// </summary>
        private void PowerButton()
        {
            string powerStr = "";
            DataTable dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskPower(this.UserInfo, WorkFlowId, WorkTaskId);
            foreach (DataRow dr in dt.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString() + ",";
            }

            if (powerStr.IndexOf(WorkConst.WorkTask_Returnry, System.StringComparison.Ordinal) > -1 || powerStr.IndexOf(WorkConst.WorkTask_Return, System.StringComparison.Ordinal) > -1)//允许（任意）退回
            {
                btnBackUp.Visible = true;
                btnTaskAnyBack.Visible = true;
                var dtComboSource = new DataTable();
                dtComboSource.Columns.Add("Text", typeof(string));
                dtComboSource.Columns.Add("Value", typeof(string));
                btnTaskAnyBack.Click += delegate
                {
                    if (powerStr.IndexOf(WorkConst.WorkTask_Returnry, System.StringComparison.Ordinal) > -1)
                    {
                        DataTable dtComplateTask = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkCompleteWorkTask(this.UserInfo, WorkFlowInsId, taskinscaption);

                        if (dtComplateTask.Rows.Count <= 0)
                        {
                            dtComboSource.Rows.Add("退回到上一步", "退回到上一步");
                        }
                        else
                        {
                            foreach (DataRow dRow in dtComplateTask.Rows)
                            {
                                dtComboSource.Rows.Add(BusinessLogic.ConvertToString(dRow["TaskInsCaption"]), BusinessLogic.ConvertToString(dRow["WorkTaskInsId"]));
                            }
                        }
                    }
                    else
                    {
                        dtComboSource.Rows.Add("退回到上一步", "退回到上一步");
                    }

                    var frmReturn = new FrmTaskReturn {DTWorkFlowStepSource = dtComboSource,OperatorInstanceId = this.OperatorInsId};
                    if (frmReturn.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                };
            }

            if (powerStr.IndexOf(WorkConst.WorkTask_Assign, System.StringComparison.Ordinal) > -1)//允许指派
            {
                btnTaskAssign.Visible = true;
                btnTaskAssign.Click += TaskAssignButtonEvent;
                btnTaskAssign.Enabled = (PageState != WorkConst.STATE_VIEW && OperStatus != "1");
            }

            if (powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext, System.StringComparison.Ordinal) > -1)//允许动态指定下一步处理人
            {
                btnDyAssignNextOper.Visible = true;
                btnDyAssignNextOper.Enabled = (PageState != WorkConst.STATE_VIEW && OperStatus != "1");
                btnDyAssignNextOper.Click += DyAssignNextOperButtonEvent;
            }
            this.InitButton(); //流程按钮
        }
        #endregion
      
        private void buttomItemCommon_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = @"流程处理情况";
                pnlMainArea.Controls.Clear();
                var frmPTaskCommon = new FrmProcessingTaskCommon
                {
                    WorkFlowId = this.WorkFlowId,
                    WorkTaskId = this.WorkTaskId,
                    WorkFlowInsId = this.WorkFlowInsId,
                    WorkTaskInsId = this.WorkTaskInsId,
                    OperatorInsId = this.OperatorInsId,
                    Stringlist = base.Stringlist,
                    DbLinks = base.DbLinks,
                    PageState = this.PageState,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false
                };
                pnlMainArea.Controls.Add(frmPTaskCommon);
                frmPTaskCommon.Show();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void InitButton()
        {
            DataTable taskCommand = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCommands(this.UserInfo, WorkFlowId, WorkTaskId);
            if (taskCommand == null || taskCommand.Rows.Count <= 0)
            {
                return;
            }
            tsToolButton.Items.Add(new ToolStripSeparator());
            foreach (DataRow dr in taskCommand.Rows)
            {
                string cmdName = dr["CommandName"].ToString();
                var tsButton = new ToolStripButton
                {
                    DisplayStyle = ToolStripItemDisplayStyle.Text,
                    ImageTransparentColor = Color.Magenta,
                    Name = cmdName,
                    Text = cmdName
                };
                tsButton.Click += new EventHandler(RunToolStriptButtonEvent);
                tsToolButton.Items.Add(tsButton);
            }
        }

        #region private void RunToolStriptButtonEvent(object sender, EventArgs e) 控制流程流转的命令按钮，如提交等
        /// <summary>
        /// 控制流程流转的命令按钮，如提交等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunToolStriptButtonEvent(object sender, EventArgs e)
        {
            this.SaveDyAssignNextOper();
            string command = (sender as ToolStripButton).Text;
            var wfRuntime = new WorkFlowRuntime
            {
                UserId = UserInfo.Id,
                WorkFlowId = WorkFlowId,
                WorkTaskId = WorkTaskId,
                WorkFlowInstanceId = WorkFlowInsId,
                WorkTaskInstanceId = WorkTaskInsId,
                CurrentUser = this.UserInfo
            };
            wfRuntime.RunSuccess += WFRuntime_RunSuccess;
            wfRuntime.RunFail += WFRuntime_RunFail;
            wfRuntime.Run(UserInfo.Id, OperatorInsId, command);
        }
        #endregion

        #region private void WFRuntime_RunSuccess(object sender, WorkFlowEventArgs e) 流程流转成功时触发的事件，保存草稿时不触发
        private void WFRuntime_RunSuccess(object sender, WorkFlowEventArgs e)
        {
            string taskToWhoMsg = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskToWhoMsg(this.UserInfo, WorkTaskInsId);
            string resultMsg = e.ResultMsg; //WorkTaskInstance.GetResultMsg(WorkTaskInsId);

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
            MessageBoxHelper.ShowWarningMsg("提交成功!" + taskToWhoMsg);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region private void WFRuntime_RunFail(object sender, WorkFlowEventArgs e) 流程流转失败时触发的事件，保存草稿时不触发
        private void WFRuntime_RunFail(object sender, WorkFlowEventArgs e)
        {
            MessageBoxHelper.ShowWarningMsg("提交失败!" + e.ResultMsg);
        }
        #endregion

        #region private void OpenForm(ButtonItem buttomItem) 打开新窗体
        /// <summary>
        /// 左侧的SildeBar点击事件
        /// </summary>
        private void sideBarItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm(sender as ButtonItem);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        /// <summary>
        /// 打开新窗体
        /// </summary>
        /// <param name="buttomItem"></param>
        private void OpenForm(ButtonItem buttomItem)
        {
            var dataRow = buttomItem.Tag as DataRow;
            if (string.IsNullOrEmpty(dataRow["FORMNAME"].ToString())&& string.IsNullOrEmpty(dataRow["ASSEMBLYNAME"].ToString()))
            {
                return;
            }

            if (!string.IsNullOrEmpty(dataRow["FORMNAME"].ToString()))
            {
                string assembly = dataRow["ASSEMBLYNAME"].ToString();

                if (dataRow["ASSEMBLYNAME"].ToString().ToLower().Contains(".dll"))
                {
                    assembly = assembly.Substring(0, assembly.LastIndexOf('.'));
                }
                // 通过数据库的值获得要打开的模块对应的窗体类型。
                System.Type type = System.Type.GetType(dataRow["FORMNAME"].ToString().Trim() + "," + assembly);
                if (type == null)
                {
                    MessageBoxHelper.ShowStopMsg(RDIFrameworkMessage.MSG1000);
                    return;
                }
                pnlMainArea.Controls.Clear();
                lblTitle.Text = dataRow["FULLNAME"].ToString();
                var obj = (object)Activator.CreateInstance(type, null);
                var bizForm = obj as FrmBaseBizeForm;
                bizForm.WorkFlowId = this.WorkFlowId;
                bizForm.WorkTaskId = this.WorkTaskId;
                bizForm.WorkFlowInsId = this.WorkFlowInsId;
                bizForm.WorkTaskInsId = this.WorkFlowInsId;
                bizForm.OperatorInsId = this.OperatorInsId;
                bizForm.UserId = this.UserInfo.Id;
                bizForm.UserName = this.UserInfo.RealName;
                bizForm.ArchCaption = this.UserInfo.DepartmentName;
                bizForm.Stringlist = base.Stringlist;
                bizForm.CtrlState = BusinessLogic.ConvertToString(dataRow["CONTROLSTATE"]) ?? "";
                bizForm.PageState = this.PageState;
                bizForm.DbLinks = base.DbLinks;
                bizForm.FormBorderStyle = FormBorderStyle.None;
                bizForm.TopLevel = false;
                pnlMainArea.Controls.Add(bizForm);
                bizForm.Show();
            }
        }
        #endregion

        #region private void RevokeTaskButtonEvent(object sender, EventArgs e) 撤回任务事件代码
        /// <summary>
        /// 撤回任务事件代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RevokeTaskButtonEvent(object sender, EventArgs e)
        {
            var wfruntime = new WorkFlowRuntime { UserId = userId, MainWorktaskInsId = WorkTaskInsId, CurrentUser = this.UserInfo };
            var msg = wfruntime.TaskRevoke();
            if (msg == "1")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("对方已认领的任务不能撤回！");
            }
        }
        #endregion

        #region private void TaskAssignButtonEvent(object sender, EventArgs e) 任务指派事件代码
        /// <summary>
        /// 任务指派按钮事件代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskAssignButtonEvent(object sender, EventArgs e)
        {
            var frmAssign = new FrmTaskAssign {OperatorInstanceId = this.OperatorInsId};
            if (frmAssign.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region private void DyAssignNextOperButtonEvent(object sender, EventArgs e) 动态指定下一处理人按钮事件代码
        private string DyAssignNextOperator = string.Empty;
        /// <summary>
        /// 动态指定下一处理人按钮事件代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DyAssignNextOperButtonEvent(object sender, EventArgs e)
        {
            var frmDyAssignNextOper = new FrmDyAssignNextOper
            {
                WorkFlowId = this.WorkFlowId,
                PageState = this.PageState,
                WorkFlowInsId = this.WorkFlowInsId,
                WorkTaskId = this.WorkTaskId,
                WorkTaskInsId = this.WorkTaskInsId,
                OperatorInsId = this.OperatorInsId
            };

            if (frmDyAssignNextOper.ShowDialog() == DialogResult.OK)
            {
                DyAssignNextOperator = frmDyAssignNextOper.SelectedId;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 保存动态指定的处理人
        /// </summary>
        private void SaveDyAssignNextOper()
        {
            try
            {
                if (string.IsNullOrEmpty(this.DyAssignNextOperator))
                {
                    return;
                }

                var taskInsNextOperEntity = new WorkTaskInsNextOperEntity
                {
                    UserId = this.DyAssignNextOperator,
                    UserName = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.DyAssignNextOperator).RealName,
                    WorkFlowId = WorkFlowId,
                    WorkTaskId = WorkTaskId,
                    WorkFlowInsId = WorkFlowInsId,
                    WorkTaskInsId = WorkTaskInsId
                };
                string returnMessage = RDIFrameworkService.Instance.WorkFlowInstanceService.CreateWorkTaskInsNextOper(this.UserInfo, taskInsNextOperEntity);
                if (!string.IsNullOrEmpty(returnMessage))
                {
                    MessageBoxHelper.ShowSuccessMsg("指定成功!");
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
        }
        #endregion

        #region 常用按钮,认领,草稿,放弃

        /// <summary>
        /// 常用按钮,认领,草稿,放弃
        /// </summary>
        private void GeneralCmdButton()
        {
            btnClaimTask.Click += ClaimButtonEvent;
            btnClaimTask.Enabled = (PageState != WorkConst.STATE_VIEW && OperStatus == "0");
            btnDraft.Click += SaveDraftButtonEvent;
            btnDraft.Enabled = (PageState != WorkConst.STATE_VIEW && OperStatus != "0");
            btnTaskAbnegate.Click += TaskAbnegateButtonEvent;
            btnTaskAbnegate.Enabled = (PageState != WorkConst.STATE_VIEW && OperStatus != "0" && OperStatus != "1" && workUserid == userId);
        }

        /// <summary>
        /// 草稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDraftButtonEvent(object sender, EventArgs e)
        {
            //if (SaveUserControl(true))
            //{
            //    MessageBoxHelper.ShowSuccessMsg("保存草稿成功。");
            //}
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
                UserId = userId,
                OperatorInstanceId = OperatorInsId,
                CurrentUser = this.UserInfo
            };
            wfruntime.TaskUnClaim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClaimButtonEvent(object sender, EventArgs e)
        {
            var wfRuntime = new WorkFlowRuntime { UserId = userId, OperatorInstanceId = OperatorInsId };
            wfRuntime.TaskClaim();
            wfRuntime.CurrentUser = this.UserInfo;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
