using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUnClaimedTask.cs
    /// 未认领任务
    /// 
    /// </summary>
    public partial class FrmUnClaimedTask : BaseForm
    {
        private DataTable DTUnClaimedTaskList = new DataTable(WorkFlowInstanceTable.TableName);

        public FrmUnClaimedTask()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvUnClaimedTask);
            this.dgvUnClaimedTask.AutoGenerateColumns = false;
            this.dtFromStartDate.Value = DateTime.Now.AddYears(-1);
            this.dtToStartDate.Value = DateTime.Now.AddDays(1);
            this.Search();
        }

        public override void SetControlState()
        {
            btnClaimTask.Enabled = dgvUnClaimedTask.Rows.Count > 0;
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
            this.DTUnClaimedTaskList = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvUnClaimedTask.DataSource = this.DTUnClaimedTaskList.DefaultView;
            this.SetControlState();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize)
        {
            var searchValue = this.GetQueryExpression();
            return RDIFrameworkService.Instance.WorkFlowInstanceService.GetUnClaimedTaskByPage(this.UserInfo, this.UserInfo.Id, searchValue, out recordCount, pageIndex, pageSize);
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

        private void btnClaimTask_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string operatorId =BusinessLogic.ConvertToString(DTUnClaimedTaskList.Rows[dgvUnClaimedTask.SelectedRows[0].Index]["OPERATORINSID"]) ?? "";
                string workTaskInsId =BusinessLogic.ConvertToString(DTUnClaimedTaskList.Rows[dgvUnClaimedTask.SelectedRows[0].Index]["WORKTASKINSID"]) ?? "";
                var wfruntime = new WorkFlowRuntime
                {
                    UserId = UserInfo.Id,
                    WorkTaskInstanceId = workTaskInsId,
                    OperatorInstanceId = operatorId,
                    CurrentUser = this.UserInfo
                };
                if (wfruntime.TaskClaim() == WorkFlowConst.SuccessCode)
                {
                    MessageBoxHelper.ShowSuccessMsg("认领成功！");
                }
                this.Search();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
