using System;

namespace RDIFramework.WebApp.ajax
{
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;

    public partial class ExportExcel : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.UserInfo != null && !string.IsNullOrEmpty(this.UserInfo.Id))
            {
                string fields = PublicMethod.GetString(Request["fields"]);
                string filters = PublicMethod.GetString(Request["filters"]);
                string tableName = PublicMethod.GetString(Request["tableName"]);
                string sortField = PublicMethod.GetString(Request["sortField"]);
                if (string.IsNullOrEmpty(sortField))
                {
                    sortField = "SORTCODE";
                }
                var dt = DbCommonLibary.GetDTByPage(this.RDIFrameworkDbProvider, tableName, filters, sortField, fields,1, 99999);
                GridViewExportUtil.Export("DataExport-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls", dt);
            }
            else
            {
                Response.Write("<h1>亲，你还没有登录哟～！</h1>");
            }
        }
    }
}