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

    /// <summary>
    /// FrmStartTask.cs
    /// 启动节点
    /// 
    /// </summary>
    public partial class FrmStartNode : BaseForm_Single
    {
        public string UserId = "";//操作人账号，用作权限判断。
        public string UserName = "";
        public string UserControlId = "";

        /// <summary>
        /// 当前的任务节点
        /// </summary>
        public StartTask NowTask { get; set; }

        public FrmStartNode(StartTask startTask, string userId, string userName)
        {
            InitializeComponent();
            NowTask = startTask;
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
            lvExOper.Columns.Add("处理类型", 100, HorizontalAlignment.Left);
            lvExOper.Columns.Add("处理策略", 100, HorizontalAlignment.Left);
            lvExOper.Columns.Add("处理者", 100, HorizontalAlignment.Left);
            lvExOper.Columns.Add("operDisplay", 100, HorizontalAlignment.Left);
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
            //加载系统变量
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
            var varTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskVar(this.UserInfo, NowTask.TaskId);
            foreach (DataRow dr in varTable.Rows)
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
            //表单
            var ctrlTable = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskControls(this.UserInfo, NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["MFULLNAME"].ToString();
                UserControlId = ctrlTable.Rows[0]["USERCONTROLID"].ToString();
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

            //保存任务处理者
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTaskAllOperator(this.UserInfo, NowTask.TaskId);
            foreach (ListViewItem lt in lvExOper.Items)
            {
                var oper = new OperatorEntity
                {
                    OperatorId = lt.SubItems[1].Text,
                    WorkFlowId = NowTask.WorkFlowId,
                    WorkTaskId = NowTask.TaskId,
                    Description = lt.Text
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

                oper.OperType = Convert.ToInt16(lt.SubItems[3].Text);
                oper.Relation = Convert.ToInt16(lt.SubItems[4].Text);
                oper.OperContent = lt.SubItems[5].Text;
                oper.OperDisplay = lt.SubItems[6].Text;
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
            MessageBoxHelper.ShowSuccessMsg("保存成功！");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
