using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using RDIFramework.Utilities;

namespace RDIFramework.WebApp.demo
{
    public partial class PrintProductInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dtReportData = new DataTable("dsProductInfo");
                IDbProvider dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbConection);
                dtReportData =
                    dbProvider.Fill(
                        "SELECT TOP 100 PRODUCTCODE,PRODUCTNAME,PRODUCTMODEL,PRODUCTSTANDARD,PRODUCTUNIT,PRODUCTPRICE,PRODUCTDESCRIPTION FROM " +
                        CASE_PRODUCTINFOTable.TableName);
                ReportDataSource rds = new ReportDataSource("dtCaseProductInfo", dtReportData);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}