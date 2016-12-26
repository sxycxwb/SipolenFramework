using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.Controls;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmWorkFlowMonitor.cs
    /// 流程监控
    /// 
    /// 
    /// </summary>
    public partial class FrmWorkFlowMonitor : BaseForm
    {
        private DataTable DTWorkFlowMonitor = new DataTable(WorkFlowInstanceTable.TableName);

        public string WorkFlowInsId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvWorkFlowMonitor, WorkFlowInstanceTable.FieldWorkFlowInsId);
            }
        }

        public FrmWorkFlowMonitor()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvWorkFlowMonitor);
            this.dgvWorkFlowMonitor.AutoGenerateColumns = false;
            this.dtStartTime.Value = DateTime.Now.AddYears(-1);
            this.dtEndTime.Value = DateTime.Now.AddDays(1);
            this.Search();
        }

        public override void SetControlState()
        {
            btnProcessStep.Enabled = btnViewWFStatus.Enabled = dgvWorkFlowMonitor.Rows.Count > 0;
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Search();
            this.Cursor = holdCursor;
        }

        private string GetQueryExpression()
        {
            string queryExpression = string.Empty;
            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle)
            {
                queryExpression += WorkFlowInstanceTable.FieldStartTime + @">=" + BusinessLogic.GetOracleDateFormat(dtStartTime.Value);
                queryExpression += " AND " + WorkFlowInstanceTable.FieldStartTime + @"<=" + BusinessLogic.GetOracleDateFormat(dtEndTime.Value);
            }
            else
            {
                queryExpression += WorkFlowInstanceTable.FieldStartTime + @">='" + DateTimeHelper.GetFormatTime(dtStartTime.Value, "yyyy-MM-dd HH:mm:ss") + "'";
                queryExpression += " AND " + WorkFlowInstanceTable.FieldStartTime + @"<='" + DateTimeHelper.GetFormatTime(dtEndTime.Value, "yyyy-MM-dd HH:mm:ss") + "'";
            }
           
            if (!string.IsNullOrEmpty(txtWFFullName.Text))
            {
                if (rbLikeSearch.Checked)
                {
                    queryExpression += " AND " + WorkFlowInstanceTable.FieldFlowInsCaption + @" LIKE '%" +txtWFFullName.Text.Trim() + @"%' ";
                }
                else
                {
                    queryExpression += " AND " + WorkFlowInstanceTable.FieldFlowInsCaption + @" = '" +txtWFFullName.Text.Trim() + @"' ";
                }
            }

            if (rbWFRunning.Checked)
            {
                queryExpression += " AND " + WorkFlowInstanceTable.FieldStatus + @" = '2' ";
            }

            if (rbWFCompleted.Checked)
            {
                queryExpression += " AND " + WorkFlowInstanceTable.FieldStatus + @" = '3' ";
            }

            if (rbWFAll.Checked)
            {
                
            }

            return queryExpression;
        }

        private void Search()
        {
            var recordCount = 0;
            this.DTWorkFlowMonitor = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvWorkFlowMonitor.DataSource = this.DTWorkFlowMonitor.DefaultView;
            this.SetControlState();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize)
        {
            var searchValue = this.GetQueryExpression();
            return  RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowInstanceDTByPage(this.UserInfo, searchValue,out recordCount, pageIndex, pageSize, WorkFlowInstanceTable.FieldStartTime + " DESC ");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnViewWFStatus_Click(object sender, EventArgs e)
        {
            if (dgvWorkFlowMonitor.Rows.Count <= 0 || dgvWorkFlowMonitor.CurrentCell == null)
            {
                return;
            }

            string workFlowId = BusinessLogic.ConvertToString(DTWorkFlowMonitor.Rows[dgvWorkFlowMonitor.CurrentCell.RowIndex][WorkFlowInstanceTable.FieldWorkFlowId]) ?? "";
            string workFlowInsId = BusinessLogic.ConvertToString(DTWorkFlowMonitor.Rows[dgvWorkFlowMonitor.CurrentCell.RowIndex][WorkFlowInstanceTable.FieldWorkFlowInsId]) ?? "";
            string title = BusinessLogic.ConvertToString(DTWorkFlowMonitor.Rows[dgvWorkFlowMonitor.CurrentCell.RowIndex][WorkFlowInstanceTable.FieldFlowInsCaption]) ?? "";
            var frmViewWFChart = new FrmViewWorkFlowChart(workFlowId, workFlowInsId, title);
            frmViewWFChart.ShowDialog();
        }

        private void btnProcessStep_Click(object sender, EventArgs e)
        {
            if (dgvWorkFlowMonitor.Rows.Count <= 0)
            {
                return;
            }

            var frmHistory = new FrmProcessStep(this.WorkFlowInsId);
            frmHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvWorkFlowMonitor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || 
                e.Value == null || 
                !(sender is UcDataGridView) || 
                ((UcDataGridView)sender).Columns[e.ColumnIndex].DataPropertyName != "STATUS")
            {
                return;
            }
           
            switch (BusinessLogic.ConvertToString(e.Value))
            {
                case "1":
                    e.Value = "还未执行";
                    this.dgvWorkFlowMonitor.Rows[e.RowIndex].DefaultCellStyle.BackColor = lblStatus1.BackColor;
                    break;
                case "2":
                    e.Value = "正在办理";
                    this.dgvWorkFlowMonitor.Rows[e.RowIndex].DefaultCellStyle.BackColor = lblStatus2.BackColor;
                    break;
                case "3":
                    e.Value = "正常结束";
                    this.dgvWorkFlowMonitor.Rows[e.RowIndex].DefaultCellStyle.BackColor = lblStatus3.BackColor;
                    break;
                case "4":
                    e.Value = "流程废弃";
                    break;
                case "5":
                    e.Value = "流程挂起";
                    break;
                default:
                    e.Value = "未知状态";
                    break;
            }
        }
    }
}
