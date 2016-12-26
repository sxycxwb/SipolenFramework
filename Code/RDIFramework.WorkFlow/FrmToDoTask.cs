using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.WinForm.Utilities;
    using RDIFramework.BizLogic;

    /// <summary>
    /// FrmToDoTask.cs
    /// 代办任务
    /// 
    /// </summary>
    public partial class FrmToDoTask : BaseForm
    {
        private DataTable DTToDoList = new DataTable(WorkFlowInstanceTable.TableName);

        public FrmToDoTask()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvToDoTask);
            this.dgvToDoTask.AutoGenerateColumns = false;
            this.dtFromStartDate.Value = DateTime.Now.AddYears(-1);
            this.dtToStartDate.Value = DateTime.Now.AddDays(1);
            this.Search();
        }

        public override void SetControlState()
        {
            btnHandleTask.Enabled = btnViewWFChart.Enabled = btnProcessStep.Enabled = btnUnClaim.Enabled = dgvToDoTask.Rows.Count > 0; 
        }

        private string GetQueryExpression()
        {
            string queryExpression = string.Empty;

            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle)
            {
                queryExpression += @"TaskStartTime>=" + BusinessLogic.GetOracleDateFormat(dtFromStartDate.Value);
                queryExpression += @" AND TaskStartTime<=" + BusinessLogic.GetOracleDateFormat(dtToStartDate.Value);
            }
            else
            {
                queryExpression += @"TaskStartTime>='" + DateTimeHelper.GetFormatTime(dtFromStartDate.Value, "yyyy-MM-dd HH:mm:ss") + "'";
                queryExpression += @" AND TaskStartTime<='" + DateTimeHelper.GetFormatTime(dtToStartDate.Value, "yyyy-MM-dd HH:mm:ss") + "'";
            }

            if (!string.IsNullOrEmpty(txtWFInsFullName.Text))
            {
                if (rbLikeSearch.Checked)
                {
                    queryExpression += @" AND FlowInsCaption LIKE '%" + txtWFInsFullName.Text.Trim() + @"%' ";
                }
                else
                {
                    queryExpression += @" AND FlowInsCaption = '" + txtWFInsFullName.Text.Trim() + @"' ";
                }
            }

            return queryExpression;
        }

        private void Search()
        {
            var recordCount = 0;
            this.DTToDoList = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvToDoTask.DataSource = this.DTToDoList.DefaultView;
            this.SetControlState();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize)
        {
            var searchValue = this.GetQueryExpression();
            return RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowClaimedTaskByPage(this.UserInfo, this.UserInfo.Id, searchValue, out recordCount, pageIndex, pageSize);
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Search();
            this.Cursor = holdCursor;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnHandleTask_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (dgvToDoTask.SelectedRows.Count < 1) return;
            string operatorId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["OPERATORINSID"]) ?? "";
            string workTaskInsId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["WORKTASKINSID"]) ?? "";
            string status = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["STATUS"]) ?? "";
            if (status == "1")//如果是新任务首先要认领任务
            {
                var wfRuntime = new WorkFlowRuntime
                {
                    UserId = UserInfo.Id,
                    WorkTaskInstanceId = workTaskInsId,
                    OperatorInstanceId = operatorId,
                    CurrentUser=this.UserInfo
                };
                wfRuntime.TaskClaim();
            }

            //根据流程模板中配置的表单加载业务表单，如销售单。这里先固定的加载销售单。
            //var frm = new FrmCommTestAuditWF {operatorInsId = operatorId};
            //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    Search(); //刷新列表
            //}

            var frmProcessTask = new FrmProcessingTask
            {
                WorkFlowId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["WorkFlowId"]) ?? "",
                WorkFlowInsId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["WorkFlowInsId"]) ?? "",
                WorkTaskId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["WorkTaskId"]) ?? "",
                WorkTaskInsId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["WorkTaskInsId"]) ?? "",
                OperatorInsId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["operatorInsId"]) ?? "",
                PageState = WorkConst.STATE_MOD,
                OperStatus = "3"
            };

            if (frmProcessTask.ShowDialog() == DialogResult.OK)
            {
                Search(); //刷新列表
            }
        }

        //放弃认领
        private void btnUnClaim_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var wfRuntime = new WorkFlowRuntime
                {
                    UserId = UserInfo.Id,
                    WorkTaskInstanceId =BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["WORKTASKINSID"]) ?? "",
                    OperatorInstanceId =BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index]["OPERATORINSID"]) ?? "",
                    CurrentUser = this.UserInfo
                };
                string statusCode = wfRuntime.TaskUnClaim();
                if (statusCode != WorkFlowConst.SuccessCode)
                {
                    MessageBoxHelper.ShowWarningMsg("放弃任务认领错误");
                }
                else
                {
                    MessageBoxHelper.ShowSuccessMsg("放弃任务认领成功！");
                    this.Search();
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
        }

        private void btnViewWFChart_Click(object sender, EventArgs e)
        {
            string workFlowId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldWorkFlowId]) ?? "";
            string workFlowInsId = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldWorkFlowInsId]) ?? "";
            string title = BusinessLogic.ConvertToString(DTToDoList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldFlowInsCaption]) ?? "";
            var frmViewWFChart = new FrmViewWorkFlowChart(workFlowId, workFlowInsId,title);
            frmViewWFChart.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
