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
    /// FrmBeDoneTask.cs
    /// 已完成的任务
    /// 
    /// </summary>
    public partial class FrmBeDoneTask : BaseForm
    {
        private DataTable DTBeDownTaskList = new DataTable(WorkFlowInstanceTable.TableName);

        public FrmBeDoneTask()
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
            btnViewTask.Enabled = btnViewWFChart.Enabled = dgvToDoTask.Rows.Count > 0;
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
            this.DTBeDownTaskList = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvToDoTask.DataSource = this.DTBeDownTaskList.DefaultView;
            this.SetControlState();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize)
        {
            var searchValue = this.GetQueryExpression();
            return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkFlowCompletedTaskByPage(this.UserInfo,this.UserInfo.Id, searchValue, out recordCount, pageIndex, pageSize);
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

        private void btnViewTask_Click(object sender, EventArgs e)
        {
            if (dgvToDoTask.SelectedRows.Count < 1) return;
            var frmProcessTask = new FrmProcessingTask
            {
                WorkFlowId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkFlowId]) ?? "",
                WorkFlowInsId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkFlowInsId]) ?? "",
                WorkTaskId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkTaskId]) ?? "",
                WorkTaskInsId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkTaskInsId]) ?? "",
                OperatorInsId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldOperatorInsId]) ?? "",
                PageState = WorkConst.STATE_VIEW,
                OperStatus = "1"
            };
            if (frmProcessTask.ShowDialog() == DialogResult.OK)
            {
                Search(); //刷新列表
            }
        }

        private void btnViewWFChart_Click(object sender, EventArgs e)
        {
            string workFlowId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldWorkFlowId]) ?? "";
            string workFlowInsId = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldWorkFlowInsId]) ?? "";
            string title = BusinessLogic.ConvertToString(DTBeDownTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldFlowInsCaption]) ?? "";
            var frmViewWFChart = new FrmViewWorkFlowChart(workFlowId, workFlowInsId, title);
            frmViewWFChart.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
