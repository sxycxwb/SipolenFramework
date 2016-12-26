using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmViewTaskNode.cs
    /// 查看节点配置
    /// 
    /// </summary>
    public partial class FrmViewTaskNode : BaseForm_Single
    {
        public ViewTask NowTask;

        public string UserId{get;set;}
        /// <summary>
        /// 关联表单id
        /// </summary>
        public string UserControlId { get; set; }

        /// <summary>
        /// 操作人姓名，用作显示。
        /// </summary>
        public string UserName { get; set; }

        public FrmViewTaskNode(ViewTask viewTask, string userId, string userName)
        {
            InitializeComponent();
            NowTask = viewTask;
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

            switch (NowTask.OperRule)
            {
                case "1":
                    rbtShareUser.Checked = true;
                    break;
                case "2":
                    rbtEveryUser.Checked = true;
                    break;
            }

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
            var operTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskOperator(this.UserInfo, NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in operTable.Rows)
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

            //*********表单

            var ctrlTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo, NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["MFULLNAME"].ToString();
                UserControlId = ctrlTable.Rows[0]["USERCONTROLID"].ToString();
            }

            //********* 事件通知
            var ev = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowEventInfo(this.UserInfo, NowTask.TaskId);
            if (ev != null)
            {
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

            //保存事件
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkFlowEvent(this.UserInfo, NowTask.TaskId);
            var ev = new WorkFlowEventEntity
            {
                Guid = BusinessLogic.NewGuid(),
                WorkFlowId = NowTask.WorkFlowId,
                WorkTaskId = NowTask.TaskId
            };
            var us = "";
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
                Text = tmpFrmOperator.OperId;
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

        private void btnRmAdd_Click(object sender, EventArgs e)
        {
            var tmpFrmSelectUser = new FrmSelectUser();
            tmpFrmSelectUser.ShowDialog();
            var dlr = tmpFrmSelectUser.DialogResult;
            if (dlr == DialogResult.OK && tmpFrmSelectUser.lvUser.SelectedItems.Count > 0)
            {
                var userid = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
                var username = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
                lbxRmMsgToUsers.Items.Add(userid + "|" + username);
            }
        }

        private void btnRmDelete_Click(object sender, EventArgs e)
        {
            if (lbxRmMsgToUsers.SelectedItems.Count > 0)
                lbxRmMsgToUsers.Items.Remove(lbxRmMsgToUsers.SelectedItem);
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
    }
}
