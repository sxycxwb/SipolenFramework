using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmStartWorkFlow : BaseForm
    {
        /// <summary>
        /// 工作流模板Id
        /// </summary>
        public virtual string WorkFlowId { get; set;}

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

        public FrmStartWorkFlow()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            DataTable dtControls = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo,WorkTaskId);
            if (dtControls != null && dtControls.Rows.Count > 0)
            {
                var dataRows = dtControls.Select("ISNULL(FORMNAME,NULL) IS NOT NULL", "CONTROLORDER");
                if (dataRows.Length > 0)
                {
                    for (int rowIndex = 0; rowIndex < dataRows.Length; rowIndex++)
                    {
                        var buttomItem = new ButtonItem
                        {
                            ButtonStyle = eButtonStyle.ImageAndText,
                            ImagePosition = eImagePosition.Top,
                            ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))),
                            Name = dataRows[rowIndex]["WORKTASKID"].ToString(),
                            Text = dataRows[rowIndex]["FULLNAME"].ToString(),
                            Tag = dataRows[rowIndex]
                        };
                        buttomItem.Click += this.sideBarItem_Click;
                        sideBarPanelItemDefault.SubItems.Add(buttomItem);
                        if (rowIndex == 0)
                        {
                            this.sideBarItem_Click(buttomItem, null);
                        }
                    }
                }
                this.InitButton(); //有业务表单才能新建相应的按钮.
            }
            this.InitData();
        }

        private void InitData()
        {
            if (!string.IsNullOrEmpty(WorkFlowId) && !string.IsNullOrEmpty(WorkTaskId))
            {
                DataTable dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskTable(this.UserInfo, WorkTaskId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtWorkFlowName.Text = BusinessLogic.ConvertToString(dt.Rows[0]["FlowCaption"]) ?? "";
                    txtTaskName.Text = BusinessLogic.ConvertToString(dt.Rows[0]["TaskCaption"]) ?? "";
                }

                var entity = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowInfo(this.UserInfo, WorkFlowId);
                txtBizWorkFlowName.Text = entity.FlowCaption;
                txtBizWorkFlowNo.Text = DateTime.Now.ToString("yyyymmddhhmmss");
            }
        }

        private void InitButton()
        {
            DataTable taskCommand = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCommands(this.UserInfo, WorkFlowId, WorkTaskId);
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
            if (tsToolButton.Items.Count > 0)
            {
                tsToolButton.Items.Add(new ToolStripSeparator());
            }
            var btnClose = new ToolStripButton("关闭") {DisplayStyle = ToolStripItemDisplayStyle.Text};
            btnClose.Click += delegate { this.Close(); };
            tsToolButton.Items.Add(btnClose);
        }

        /// <summary>
        /// 控制流程流转的命令按钮，如提交等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunToolStriptButtonEvent(object sender, EventArgs e)
        {
            //if (SaveFormData(false))
            //{
            string command = (sender as ToolStripButton).Text;
            string priority = "1";
            switch (BusinessLogic.ConvertToString(cboPriority.SelectedItem))
            {
                case "普通":
                    priority = "1";
                    break;
                case "紧急":
                    priority = "2";
                    break;
                case "特急":
                    priority = "3";
                    break;
                default:
                    priority = "1";
                    break;
            }
          
            var wfruntime = new WorkFlowRuntime
            {
                UserId = UserInfo.Id,
                WorkFlowId = WorkFlowId,
                WorkTaskId = WorkTaskId,
                WorkFlowInstanceId = WorkFlowInsId,
                WorkTaskInstanceId = WorkTaskInsId,
                WorkFlowNo = txtBizWorkFlowNo.Text,
                CommandName = command,
                Priority = priority,
                WorkflowInsCaption = txtBizWorkFlowName.Text,
                Description = txtBizWorkFlowDescription.Text,
                IsDraft = false,
                CurrentUser = this.UserInfo
            };
            wfruntime.RunSuccess += WFRuntime_RunSuccess;//流程成功启动时执行的事件
            wfruntime.RunFail += WFRuntime_RunFail;//流程启动失败时执行的事件
            wfruntime.Start();
            //}
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
            this.Close();
        }
        #endregion

        #region 流程流转失败时触发的事件，保存草稿时不触发
        private void WFRuntime_RunFail(object sender, WorkFlowEventArgs e)
        {
            MessageBoxHelper.ShowWarningMsg("提交失败!" + e.ResultMsg);
        }
        #endregion

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
                bizForm.CtrlState = BusinessLogic.ConvertToString(dataRow["CONTROLSTATE"]) ?? "";
                bizForm.Stringlist = base.Stringlist;
                bizForm.DbLinks = base.DbLinks;
                bizForm.FormBorderStyle = FormBorderStyle.None;
                bizForm.TopLevel = false;
                pnlMainArea.Controls.Add(bizForm);
                bizForm.Show();
            }
        }
    }
}
