using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.Test
{
    public partial class ReportCommonTool : BaseForm
    {
        private DataTable dtReportData = new DataTable("dsProductInfo");
      
        public ReportCommonTool(DataTable dtData)
        {
            InitializeComponent();
            this.dtReportData = dtData;
        }
        
        private void Fm_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void ReportCommonTool_Load(object sender, EventArgs e)
        {
            this.reportViewer2.ProcessingMode = ProcessingMode.Local;
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsProductInfo", dtReportData));
            
            reportViewer2.RefreshReport();
        }
    }
}