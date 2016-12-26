using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    public partial class LogAdmin : BasePage
    {
        /// <summary>
        /// 本模块的查询权限
        /// </summary>
        private bool permissionQuery = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDeleteAll = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GetPermission();
            }
        }

        /// <summary>
        /// 获得页面的权限
        /// </summary>
        private void GetPermission()
        {
            this.permissionQuery = this.IsAuthorized("LogAdmin.Query");
            this.permissionExport = this.IsAuthorized("LogAdmin.Export");
            this.permissionDelete = this.IsAuthorized("LogAdmin.Delete");
            //this.permissionDeleteAll = this.IsAuthorized("LogAdmin.DeleteAll");
        }

        /// <summary>
        /// 加载工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"btn{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"btnRefresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "Export", "icon16_table_export", permissionExport ? "" : "disabled=\"True\"", "导出系统操作日志", "导出"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "Delete", "icon16_table_delete", permissionDelete ? "" : "disabled=\"True\"", "删除系统操作日志", "删除"));
            sb.Append(string.Format(linkbtnTemplate, "DeleteAll", "icon16_DeleteRed", permissionDeleteAll ? "" : "disabled=\"True\"", "清除全部系统操作日志", "清除"));

            return sb.ToString();
        }
    }
}