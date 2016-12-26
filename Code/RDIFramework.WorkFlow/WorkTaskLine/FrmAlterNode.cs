using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmAlterNode.cs
    /// 交互节点配置
    /// 
    /// </summary>
    public partial class FrmAlterNode : BaseForm_Single
    {
        public AlternateTask NowTask;
        /// <summary>
        /// 操作人账号，用作权限判断。
        /// </summary>
        public string UserId { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// 关联表单id
        /// </summary>
        public string UserControlId { get; set; }

        public FrmAlterNode(AlternateTask alterTask, string userId, string userName)
        {
            InitializeComponent();
            NowTask = alterTask;
            this.UserId = userId;
            this.UserName = userName;
        }

        public override void FormOnLoad()
        {
            InitData();
        }

        private void InitData()
        {
            tbxTaskName.Text = NowTask.TaskName;
            tbxTaskDes.Text = NowTask.Description;
            cbxJumpSelf.Checked = NowTask.IsJumpSelf;
            if (NowTask.OperRule == "1")
                rbtShareUser.Checked = true;
            else
                if (NowTask.OperRule == "2")
                    rbtEveryUser.Checked = true;

            //*********任务命令
            lvExCommand.Columns.Add("处理命令", 200, HorizontalAlignment.Left);
            lvExCommand.Columns.Add("CommandId", 0, HorizontalAlignment.Left);
            lvExCommand.Columns.Add("描述", 100, HorizontalAlignment.Left);
            var taskCommand = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCommands(this.UserInfo, NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in taskCommand.Rows)
            {
                var lvi1 = new ListViewItem(dr[WorkTaskCommandsTable.FieldCommandName].ToString(), 0);
                lvi1.SubItems.Add(dr[WorkTaskCommandsTable.FieldCommandId].ToString());
                lvi1.SubItems.Add(dr[WorkTaskCommandsTable.FieldDescription].ToString());
                lvExCommand.Items.Add(lvi1);
            }

            //*********处理者
            lvExOper.Columns.Add("处理者信息", 200, HorizontalAlignment.Left);
            lvExOper.Columns.Add("OperatorId", 0, HorizontalAlignment.Left);
            lvExOper.Columns.Add("包含/排除", 100, HorizontalAlignment.Left);
            lvExOper.Columns.Add("处理类型", 0, HorizontalAlignment.Left);
            lvExOper.Columns.Add("处理策略", 0, HorizontalAlignment.Left);
            lvExOper.Columns.Add("处理者", 0, HorizontalAlignment.Left);
            lvExOper.Columns.Add("operDisplay", 0, HorizontalAlignment.Left);
            var OperTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskOperator(this.UserInfo, NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in OperTable.Rows)
            {
                var lvi1 = new ListViewItem(dr[OperatorTable.FieldDescription].ToString(), 0);
                lvi1.SubItems.Add(dr[OperatorTable.FieldOperatorId].ToString());
                lvi1.SubItems.Add(Convert.ToBoolean(dr[OperatorTable.FieldInorExclude]) ? "包含" : "排除");
                lvi1.SubItems.Add(dr[OperatorTable.FieldOperType].ToString());
                lvi1.SubItems.Add(dr[OperatorTable.FieldRelation].ToString());
                lvi1.SubItems.Add(dr[OperatorTable.FieldOperContent].ToString());
                lvi1.SubItems.Add(dr[OperatorTable.FieldOperDisplay].ToString());
                lvExOper.Items.Add(lvi1);
            }

            //*********变量
            lvExVar.Columns.Add("变量名", 200, HorizontalAlignment.Left);
            lvExVar.Columns.Add("TaskVarId", 0, HorizontalAlignment.Left);
            lvExVar.Columns.Add("变量类型", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("变量模式", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("数据库名", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("数据表名", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("字段名", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("初始值", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("访问类型", 100, HorizontalAlignment.Left);
            lvExVar.Columns.Add("排序", 100, HorizontalAlignment.Left);
            var sysVarItem = SystemVarData.GetSystemVarItems();
            foreach (var var in sysVarItem)
            {
                var lvi1 = new ListViewItem(var.VarName, 0);
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add(var.VarType);
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.ForeColor = Color.Red;
                lvExVar.Items.Add(lvi1);
            }
            var VarTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskVar(this.UserInfo, NowTask.TaskId);
            foreach (DataRow dr in VarTable.Rows)
            {
                var lvi1 = new ListViewItem(dr[TaskVarTable.FieldVarName].ToString(), 0);
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTaskVarId].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldVarType].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldVarModule].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldDataBaseName].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTableName].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTableField].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldInitValue].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldAccessType].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldSortField].ToString());
                lvExVar.Items.Add(lvi1);
            }
            //*********表单
            var ctrlTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo, NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["MFULLNAME"].ToString();
                UserControlId = ctrlTable.Rows[0]["USERCONTROLID"].ToString();
            }
            //*********控制权限
            var powerTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskPower(this.UserInfo, NowTask.WorkFlowId, NowTask.TaskId);
            var powerStr = powerTable.Rows.Cast<DataRow>().Aggregate("", (current, dr) => current + dr["PowerName"].ToString() + ",");
            cbxReturn.Checked = powerStr.IndexOf(WorkConst.WorkTask_Return) > -1;//退回
            cbxAssign.Checked = powerStr.IndexOf(WorkConst.WorkTask_Assign) > -1;//指派
            cbxReturnry.Checked = powerStr.IndexOf(WorkConst.WorkTask_Returnry) > -1;//任意退回
            cbxDyAssignNext.Checked = powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext) > -1;//动态指定下一任务处理人
            //********* 超时配置
            var ot = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkOutTimeInfo(this.UserInfo, NowTask.TaskId);
            if (ot != null)
            {
                tbxDay1.Value = decimal.Parse(ot.Days.ToString());
                tbxDay2.Value = decimal.Parse(ot.Days1.ToString());
                tbxDay3.Value = decimal.Parse(ot.Days2.ToString());
                tbxHour1.Value = decimal.Parse(ot.Hours.ToString());
                tbxHour2.Value = decimal.Parse(ot.Hours1.ToString());
                tbxHour3.Value = decimal.Parse(ot.Hours2.ToString());
                tbxMinute1.Value = decimal.Parse(ot.Minutes.ToString());
                tbxMinute2.Value = decimal.Parse(ot.Minutes1.ToString());
                tbxMinute3.Value = decimal.Parse(ot.Minutes2.ToString());
                chkEnableTimeOut.Checked = ot.OverTime == 1;
            }

            //********* 事件通知
            var ev = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowEventInfo(this.UserInfo, NowTask.TaskId);
            if (ev != null)
            {
                cbxOtMail.Checked = BusinessLogic.ConvertIntToBoolean(ev.OtEmail);
                cbxOtMessage.Checked = BusinessLogic.ConvertIntToBoolean(ev.OtMsg);
                cbxOtSms.Checked = BusinessLogic.ConvertIntToBoolean(ev.OtSms);
                if (ev.OtToUsers != null)
                {
                    var us = ev.OtToUsers.Split(',');
                    foreach (var usr in us.Where(usr => usr.Length > 0))
                    {
                        lbxOtMsgToUsers.Items.Add(usr);
                    }
                }

                cbxRmMail.Checked = BusinessLogic.ConvertIntToBoolean(ev.RmEmail);
                cbxRmMessage.Checked = BusinessLogic.ConvertIntToBoolean(ev.RmMsg);
                cbxRmSms.Checked = BusinessLogic.ConvertIntToBoolean(ev.RmSms);
                if (ev.RmToUsers != null)
                {
                    var us = ev.RmToUsers.Split(',');
                    foreach (var usr in us.Where(usr => usr.Length > 0))
                    {
                        lbxRmMsgToUsers.Items.Add(usr);
                    }
                }
            }
        }

        private void SaveData()
        {
            //保存任务
            NowTask.TaskName = tbxTaskName.Text;
            NowTask.Description = tbxTaskDes.Text;
            NowTask.IsJumpSelf = cbxJumpSelf.Checked;
            if (rbtShareUser.Checked)
                NowTask.OperRule = "1";
            else
                if (rbtEveryUser.Checked)
                    NowTask.OperRule = "2";
            NowTask.SaveUpdateTask();
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTaskAllOperator(this.UserInfo, NowTask.TaskId);
            //保存处理者
            foreach (ListViewItem lt in lvExOper.Items)
            {
                var oper = new OperatorEntity
                {
                    OperatorId = lt.SubItems[1].Text,
                    WorkFlowId = NowTask.WorkFlowId,
                    WorkTaskId = NowTask.TaskId,
                    Description = lt.Text,
                    OperType = Convert.ToInt16(lt.SubItems[3].Text),
                    Relation = Convert.ToInt16(lt.SubItems[4].Text),
                    OperContent = lt.SubItems[5].Text,
                    OperDisplay = lt.SubItems[6].Text
                };

                switch (lt.SubItems[2].Text)
                {
                    case "包含":
                        oper.InorExclude = 1;
                        break;
                    case "排除":
                        oper.InorExclude = 0;
                        break;
                }
                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertOperator(this.UserInfo, oper);
            }
            //保存任务变量
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTaskAllTaskVar(this.UserInfo, NowTask.TaskId);
            foreach (ListViewItem lt in lvExVar.Items)
            {
                var isSysVar = SystemVarData.IsSystemVar(lt.Text);
                if (isSysVar) continue;//跳过系统变量

                var tmpTaskVar = new TaskVarEntity
                {
                    VarName = lt.Text,
                    WorkFlowId = NowTask.WorkFlowId,
                    WorkTaskId = NowTask.TaskId,
                    TaskVarId = lt.SubItems[1].Text,
                    VarType = lt.SubItems[2].Text,
                    VarModule = lt.SubItems[3].Text,
                    DataBaseName = lt.SubItems[4].Text,
                    TableName = lt.SubItems[5].Text,
                    TableField = lt.SubItems[6].Text,
                    InitValue = lt.SubItems[7].Text,
                    AccessType = lt.SubItems[8].Text,
                    SortField = lt.SubItems[9].Text
                };

                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertTaskVar(this.UserInfo, tmpTaskVar);
            }

            //保存任务命令
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTaskAllCommands(this.UserInfo, NowTask.TaskId);

            foreach (ListViewItem lt in lvExCommand.Items)
            {
                var taskCommand = new WorkTaskCommandsEntity
                {
                    WorkFlowId = NowTask.WorkFlowId,
                    WorkTaskId = NowTask.TaskId,
                    CommandName = lt.Text,
                    CommandId = lt.SubItems[1].Text,
                    Description = lt.SubItems[2].Text
                };

                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkTaskCommands(this.UserInfo, taskCommand);
            }

            //保存关联表单
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTaskAllControls(this.UserInfo, NowTask.TaskId);
            RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkTaskUserCtrls(this.UserInfo, UserControlId, NowTask.WorkFlowId, NowTask.TaskId);

            //保存控制权限
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTaskAllPower(this.UserInfo, NowTask.WorkFlowId, NowTask.TaskId);

            if (cbxReturn.Checked)
                RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkTaskPower(this.UserInfo, WorkConst.WorkTask_Return, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxReturnry.Checked)//任意退回
                RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkTaskPower(this.UserInfo, WorkConst.WorkTask_Returnry, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxAssign.Checked)
                RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkTaskPower(this.UserInfo, WorkConst.WorkTask_Assign, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxDyAssignNext.Checked)
                RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkTaskPower(this.UserInfo, WorkConst.WorkTask_DyAssignNext, NowTask.WorkFlowId, NowTask.TaskId);

            //保存超时配置
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkOutTime(this.UserInfo, NowTask.TaskId);

            var ot = new WorkOutTimeEntity
            {
                Guid = BusinessLogic.NewGuid(),
                WorkFlowId = NowTask.WorkFlowId,
                WorkTaskId = NowTask.TaskId,
                Days = Convert.ToInt16(tbxDay1.Value),
                Days1 = Convert.ToInt16(tbxDay2.Value),
                Days2 = Convert.ToInt16(tbxDay3.Value),
                Hours = Convert.ToInt16(tbxHour1.Value),
                Hours1 = Convert.ToInt16(tbxHour2.Value),
                Hours2 = Convert.ToInt16(tbxHour3.Value),
                Minutes = Convert.ToInt16(tbxMinute1.Value),
                Minutes1 = Convert.ToInt16(tbxMinute2.Value),
                Minutes2 = Convert.ToInt16(tbxMinute3.Value),
                OverTime = chkEnableTimeOut.Checked ? 1 : 0
            };
            RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkOutTime(this.UserInfo, ot);
            //保存事件
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkFlowEvent(this.UserInfo, NowTask.TaskId);

            var ev = new WorkFlowEventEntity
            {
                Guid = BusinessLogic.NewGuid(),
                WorkFlowId = NowTask.WorkFlowId,
                WorkTaskId = NowTask.TaskId,
                OtMsg = cbxOtMessage.Checked ? 1 : 0,
                OtSms = cbxOtSms.Checked ? 1 : 0,
                OtEmail = cbxOtMail.Checked ? 1 : 0
            };
            var us = "";
            if (lbxOtMsgToUsers.Items.Count > 0)
            {
                for (var i = 0; i < lbxOtMsgToUsers.Items.Count - 1; i++)
                {
                    us = us + lbxOtMsgToUsers.Items[i].ToString() + ",";
                }
                us = us + lbxOtMsgToUsers.Items[lbxOtMsgToUsers.Items.Count - 1];
            }
            ev.OtToUsers = us;
            ev.RmMsg = cbxRmMessage.Checked ? 1 : 0;
            ev.RmEmail = cbxRmMail.Checked ? 1 : 0;
            ev.RmSms = cbxRmSms.Checked ? 1 : 0;

            us = "";
            if (lbxRmMsgToUsers.Items.Count > 0)
            {
                for (var i = 0; i < lbxRmMsgToUsers.Items.Count - 1; i++)
                {
                    us = us + lbxRmMsgToUsers.Items[i].ToString() + ",";
                }
                us = us + lbxRmMsgToUsers.Items[lbxRmMsgToUsers.Items.Count - 1];
            }
            ev.RmToUsers = us;
            RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkFlowEvent(this.UserInfo, ev);
        }

        private void btnAddOpr_Click(object sender, EventArgs e)
        {
            var tmpFrmOperator = new FrmOperator(WorkConst.STATE_ADD)
            {
                OperId = BusinessLogic.NewGuid(),
                WorkflowId = NowTask.WorkFlowId
            };
            tmpFrmOperator.ShowDialog();
            var dlr = tmpFrmOperator.DialogResult;
            if (dlr == DialogResult.OK)
            {
                if (tmpFrmOperator.OperDisplay.Length <= 0)
                {
                    MessageBoxHelper.ShowWarningMsg("没有选择处理者!!");
                    return;
                }
                //Text = tmpFrmOperator.OperId;
                var lvi1 = new ListViewItem(tmpFrmOperator.Description, 0);
                lvi1.SubItems.Add(tmpFrmOperator.OperId);
                lvi1.SubItems.Add(tmpFrmOperator.InorExclude ? "包含" : "排除");
                lvi1.SubItems.Add(tmpFrmOperator.OperType.ToString());
                lvi1.SubItems.Add(tmpFrmOperator.Relation.ToString());
                lvi1.SubItems.Add(tmpFrmOperator.OperContent);
                lvi1.SubItems.Add(tmpFrmOperator.OperDisplay);
                lvExOper.Items.Add(lvi1);
            }
        }

        private void btnModifyOpr_Click(object sender, EventArgs e)
        {
            if (lvExOper.SelectedItems.Count > 0)
            {
                var lvi1 = lvExOper.SelectedItems[0];
                var tmpFrmOperator = new FrmOperator(WorkConst.STATE_MOD)
                {
                    Description = lvi1.Text,
                    WorkflowId = NowTask.WorkFlowId,
                    OperId = lvi1.SubItems[1].Text
                };
                switch (lvi1.SubItems[2].Text)
                {
                    case "包含":
                        tmpFrmOperator.InorExclude = true;
                        break;
                    case "排除":
                        tmpFrmOperator.InorExclude = false;
                        break;
                }
                tmpFrmOperator.OperType = Convert.ToInt16(lvi1.SubItems[3].Text);
                tmpFrmOperator.Relation = Convert.ToInt16(lvi1.SubItems[4].Text);
                tmpFrmOperator.OperContent = lvi1.SubItems[5].Text;
                tmpFrmOperator.OperDisplay = lvi1.SubItems[6].Text;
                tmpFrmOperator.ShowDialog();
                var dlr = tmpFrmOperator.DialogResult;
                if (dlr == DialogResult.OK)
                {
                    lvi1.Text = tmpFrmOperator.Description;
                    lvi1.SubItems[1].Text = tmpFrmOperator.OperId;
                    lvi1.SubItems[2].Text = tmpFrmOperator.InorExclude ? "包含" : "排除";
                    lvi1.SubItems[3].Text = tmpFrmOperator.OperType.ToString();
                    lvi1.SubItems[4].Text = tmpFrmOperator.Relation.ToString();
                    lvi1.SubItems[5].Text = tmpFrmOperator.OperContent;
                    lvi1.SubItems[6].Text = tmpFrmOperator.OperDisplay;
                }
            }
        }

        private void btnDeleteOpr_Click(object sender, EventArgs e)
        {
            if (lvExOper.SelectedItems.Count > 0)
            {
                lvExOper.Items.Remove(lvExOper.SelectedItems[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool varExists(string varName)
        {
            if (lvExVar.Items.Count > 0)
            {
                return lvExVar.Items.Cast<ListViewItem>().Any(lt => varName == lt.Text);
            }
            return false;
        }

        private void btnAddVar_Click(object sender, EventArgs e)
        {
            var tmpFrmTaskVar = new FrmTaskVar(WorkConst.STATE_ADD)
            {
                TaskVarId = BusinessLogic.NewGuid(),
                VarDataBaseName = "",
                VarDataTableName = "",
                VarTableColumnName = ""
            };
            tmpFrmTaskVar.ShowDialog();
            var dlr = tmpFrmTaskVar.DialogResult;
            if (dlr == DialogResult.OK)
            {
                if (varExists(tmpFrmTaskVar.tbxVarName.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("变量" + tmpFrmTaskVar.tbxVarName.Text + "已存在,不能填加!");
                    return;
                }

                var lvi1 = new ListViewItem(tmpFrmTaskVar.tbxVarName.Text, 0);
                lvi1.SubItems.Add(tmpFrmTaskVar.TaskVarId);
                lvi1.SubItems.Add(tmpFrmTaskVar.cbxVarType.SelectedItem.ToString());
                lvi1.SubItems.Add(tmpFrmTaskVar.cbxVarModule.SelectedItem.ToString());
                lvi1.SubItems.Add(tmpFrmTaskVar.VarDataBaseName);
                lvi1.SubItems.Add(tmpFrmTaskVar.cbxDataTable.Text);
                lvi1.SubItems.Add(tmpFrmTaskVar.cbxTableColumns.Text);
                lvi1.SubItems.Add(tmpFrmTaskVar.tbxIniValue.Text);
                lvi1.SubItems.Add(tmpFrmTaskVar.cbxAccessType.SelectedIndex.ToString());
                lvi1.SubItems.Add(tmpFrmTaskVar.comboBoxbx.Text);
                lvExVar.Items.Add(lvi1);
            }
        }

        private void btnModifyVar_Click(object sender, EventArgs e)
        {
            if (lvExVar.SelectedItems.Count > 0)
            {

                var lvi1 = lvExVar.SelectedItems[0];
                var isSysVar = SystemVarData.IsSystemVar(lvi1.Text);
                if (isSysVar) return;//跳过系统变量

                var tmpFrmTaskVar = new FrmTaskVar(WorkConst.STATE_MOD)
                {
                    tbxVarName = { Text = lvi1.Text },
                    TaskVarId = lvi1.SubItems[1].Text,
                    cbxVarType = { Text = lvi1.SubItems[2].Text },
                    cbxVarModule = { Text = lvi1.SubItems[3].Text },
                    VarDataBaseName = lvi1.SubItems[4].Text,
                    VarDataTableName = lvi1.SubItems[5].Text,
                    VarTableColumnName = lvi1.SubItems[6].Text,
                    tbxIniValue = { Text = lvi1.SubItems[7].Text },
                    comboBoxbx = { Text = lvi1.SubItems[9].Text },
                    SortField = lvi1.SubItems[9].Text
                };
                var accessType = lvi1.SubItems[8].Text;
                if (accessType.Trim().Length == 0)
                {
                    tmpFrmTaskVar.cbxAccessType.SelectedIndex = 0;
                }
                else
                {
                    if (char.IsNumber(accessType[0]))
                        tmpFrmTaskVar.cbxAccessType.SelectedIndex = Convert.ToInt16(accessType);
                }
                tmpFrmTaskVar.ShowDialog();
                var dlr = tmpFrmTaskVar.DialogResult;
                if (dlr == DialogResult.OK)
                {
                    if (lvi1.Text != tmpFrmTaskVar.tbxVarName.Text && varExists(tmpFrmTaskVar.tbxVarName.Text))
                    {
                        MessageBoxHelper.ShowWarningMsg("变量" + tmpFrmTaskVar.tbxVarName.Text + "已存在,请使用其他名称!");
                        return;
                    }

                    lvi1.Text = tmpFrmTaskVar.tbxVarName.Text;
                    lvi1.SubItems[1].Text = tmpFrmTaskVar.TaskVarId;
                    lvi1.SubItems[2].Text = tmpFrmTaskVar.cbxVarType.SelectedItem.ToString();
                    lvi1.SubItems[3].Text = tmpFrmTaskVar.cbxVarModule.SelectedItem.ToString();
                    lvi1.SubItems[4].Text = tmpFrmTaskVar.VarDataBaseName;
                    lvi1.SubItems[5].Text = tmpFrmTaskVar.cbxDataTable.Text;
                    lvi1.SubItems[6].Text = tmpFrmTaskVar.cbxTableColumns.Text;
                    lvi1.SubItems[7].Text = tmpFrmTaskVar.tbxIniValue.Text;
                    lvi1.SubItems[8].Text = tmpFrmTaskVar.cbxAccessType.SelectedIndex.ToString();
                    lvi1.SubItems[9].Text = tmpFrmTaskVar.comboBoxbx.Text;
                }
            }
        }

        private void btnDeleteVar_Click(object sender, EventArgs e)
        {
            if (lvExVar.SelectedItems.Count > 0)
            {
                lvExVar.Items.Remove(lvExVar.SelectedItems[0]);
            }
        }

        private void btnAddCmd_Click(object sender, EventArgs e)
        {
            var tmpfmCommand = new FrmAddCommands(WorkConst.STATE_ADD) { CommandId = BusinessLogic.NewGuid() };
            tmpfmCommand.ShowDialog();
            var dlr = tmpfmCommand.DialogResult;
            if (dlr == DialogResult.OK)
            {

                var lvi1 = new ListViewItem(tmpfmCommand.tbxCommandName.Text, 0);
                lvi1.SubItems.Add(tmpfmCommand.CommandId);
                lvi1.SubItems.Add(tmpfmCommand.tbxDes.Text);
                lvExCommand.Items.Add(lvi1);
            }
        }

        private void btnModifyCmd_Click(object sender, EventArgs e)
        {
            if (lvExCommand.SelectedItems.Count > 0)
            {
                var lvi1 = lvExCommand.SelectedItems[0];
                var tmpfmCommand = new FrmAddCommands(WorkConst.STATE_MOD)
                {
                    tbxCommandName = { Text = lvi1.Text },
                    CommandId = lvi1.SubItems[1].Text,
                    tbxDes = { Text = lvi1.SubItems[2].Text }
                };

                tmpfmCommand.ShowDialog();
                var dlr = tmpfmCommand.DialogResult;
                if (dlr == DialogResult.OK)
                {
                    lvi1.Text = tmpfmCommand.tbxCommandName.Text;
                    lvi1.SubItems[1].Text = tmpfmCommand.CommandId;
                    lvi1.SubItems[2].Text = tmpfmCommand.tbxDes.Text;
                }
            }
        }

        private void btnDeleteCmd_Click(object sender, EventArgs e)
        {
            if (lvExCommand.SelectedItems.Count > 0)
            {
                lvExCommand.Items.Remove(lvExCommand.SelectedItems[0]);
            }
        }

        private void btnSelectCtrls_Click(object sender, EventArgs e)
        {
            var tmpfmSelectCtrl = new FrmSelectMainUserCtrl(tbxFormName.Text);
            tmpfmSelectCtrl.ShowDialog();
            var dlr = tmpfmSelectCtrl.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectCtrl.lvMainUserCtrl.SelectedItems.Count > 0)
            {
                UserControlId = tmpfmSelectCtrl.lvMainUserCtrl.SelectedItems[0].SubItems[1].Text;
                tbxFormName.Text = tmpfmSelectCtrl.lvMainUserCtrl.SelectedItems[0].Text;
            }
        }

        private void btnOtDelete_Click(object sender, EventArgs e)
        {
            if (lbxOtMsgToUsers.SelectedItems.Count > 0)
                lbxOtMsgToUsers.Items.Remove(lbxOtMsgToUsers.SelectedItem);
        }

        private void btnRmDelete_Click(object sender, EventArgs e)
        {
            if (lbxRmMsgToUsers.SelectedItems.Count > 0)
                lbxRmMsgToUsers.Items.Remove(lbxRmMsgToUsers.SelectedItem);
        }

        private void btnOtAdd_Click(object sender, EventArgs e)
        {
            var frmUserSelect = new FrmUserSelect { MultiSelect = false };
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                var username = frmUserSelect.SelectedFullName;
                var userid = frmUserSelect.SelectedId;
                lbxOtMsgToUsers.Items.Add(userid + "|" + username);
            }

            //FrmSelectUser tmpFrmSelectUser = new FrmSelectUser();
            //tmpFrmSelectUser.ShowDialog();
            //DialogResult dlr = tmpFrmSelectUser.DialogResult;
            //if (dlr == DialogResult.OK && tmpFrmSelectUser.lvUser.SelectedItems.Count > 0)
            //{
            //    string userid = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
            //    string username = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
            //    lbxOtMsgToUsers.Items.Add(userid + "|" + username);
            //}
        }

        private void btnRmAdd_Click(object sender, EventArgs e)
        {
            var frmUserSelect = new FrmUserSelect { MultiSelect = false };
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                var username = frmUserSelect.SelectedFullName;
                var userid = frmUserSelect.SelectedId;
                lbxRmMsgToUsers.Items.Add(userid + "|" + username);
            }

            //FrmSelectUser tmpFrmSelectUser = new FrmSelectUser();
            //tmpFrmSelectUser.ShowDialog();
            //DialogResult dlr = tmpFrmSelectUser.DialogResult;
            //if (dlr == DialogResult.OK && tmpFrmSelectUser.lvUser.SelectedItems.Count > 0)
            //{
            //    string userid = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
            //    string username = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
            //    lbxRmMsgToUsers.Items.Add(userid + "|" + username);
            //}
        }

        private void lvExVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvExVar.SelectedItems.Count > 0)
            {
                var lvi1 = lvExVar.SelectedItems[0];
                var isSysVar = SystemVarData.IsSystemVar(lvi1.Text);
                btnModifyVar.Enabled = !isSysVar;
                btnDeleteVar.Enabled = !isSysVar;
            }
        }
    }
}
