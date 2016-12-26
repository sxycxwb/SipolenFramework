using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using RDIFramework.Controls;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmMyParticipantTask.cs
    /// 我参与的任务
    /// 
    /// </summary>
    public partial class FrmMyParticipantTask : BaseForm
    {
        private DataTable MyParticipantTaskList = new DataTable(WorkFlowInstanceTable.TableName);

        public FrmMyParticipantTask()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvToDoTask);
            this.dgvToDoTask.AutoGenerateColumns = false;
            this.dtFromStartDate.Value = DateTime.Now.AddMonths(-6);
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
                    queryExpression += @" AND FLOWINSCAPTION LIKE '%" + txtWFInsFullName.Text.Trim() + @"%' ";
                }
                else
                {
                    queryExpression += @" AND FLOWINSCAPTION = '" + txtWFInsFullName.Text.Trim() + @"' ";
                }
            }

            return queryExpression;
        }

        private void Search()
        {
            var recordCount = 0;
            this.MyParticipantTaskList = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvToDoTask.DataSource = this.MyParticipantTaskList.DefaultView;
            this.SetControlState();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize)
        {
            var searchValue = this.GetQueryExpression();
            return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkFlowAllTaskByPage(this.UserInfo,this.UserInfo.Id, out recordCount, pageIndex, pageSize,"All", searchValue);
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
                WorkFlowId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkFlowId]) ?? "",
                WorkFlowInsId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkFlowInsId]) ?? "",
                WorkTaskId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkTaskId]) ?? "",
                WorkTaskInsId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldWorkTaskInsId]) ?? "",
                OperatorInsId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkTaskInstanceTable.FieldOperatorInsId]) ?? "",
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
            string workFlowId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldWorkFlowId]) ?? "";
            string workFlowInsId = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldWorkFlowInsId]) ?? "";
            string title = BusinessLogic.ConvertToString(MyParticipantTaskList.Rows[dgvToDoTask.SelectedRows[0].Index][WorkFlowInstanceTable.FieldFlowInsCaption]) ?? "";
            var frmViewWFChart = new FrmViewWorkFlowChart(workFlowId, workFlowInsId, title);
            frmViewWFChart.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvToDoTask_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is UcDataGridView))
            {
                return;
            }

            object originalValue = e.Value;
            if (((UcDataGridView)sender).Columns[e.ColumnIndex].DataPropertyName == "PRIORITY" && originalValue != null)
            {
                switch (BusinessLogic.ConvertToString(originalValue))
                {
                    case "1":
                        e.Value = "普通";
                        e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                        break;
                    case "2":
                        e.Value = "紧急";
                        e.CellStyle.ForeColor = Color.FromArgb(204, 51, 102);
                        break;
                    case "3":
                        e.Value = "特急";
                        e.CellStyle.ForeColor = Color.FromArgb(255, 0, 51);
                        break;
                    default:
                        e.Value = "未知";
                        e.CellStyle.ForeColor = Color.FromArgb(102, 102, 102);
                        break;
                }
            }

            if (((UcDataGridView)sender).Columns[e.ColumnIndex].DataPropertyName == "STATUS" && originalValue != null)
            {
                switch (BusinessLogic.ConvertToString(originalValue))
                {
                    case "0":
                        e.Value = "保留";
                        e.CellStyle.ForeColor = Color.FromArgb(204, 204, 102);
                        break;
                    case "1":
                        e.Value = "未执行";
                        e.CellStyle.ForeColor = Color.FromArgb(102, 0, 51);
                        break;
                    case "2":
                        e.Value = "执行中";
                        e.CellStyle.ForeColor = Color.FromArgb(204, 102, 0);
                        break;
                    case "3":
                        e.Value = "执行完毕";
                        e.CellStyle.ForeColor = Color.FromArgb(204, 204, 0);
                        break;
                    case "4":
                        e.Value = "异常终止";
                        e.CellStyle.ForeColor = Color.FromArgb(255, 0, 51);
                        break;
                    default:
                        e.Value = "未知";
                        e.CellStyle.ForeColor = Color.FromArgb(204, 204, 255);
                        break;
                }
            }
        }
    }
}
