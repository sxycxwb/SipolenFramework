using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    public partial class TableFieldAdmin : BasePage
    {
        /// <summary>
        /// 本模块的保存权限
        /// </summary>
        private bool permissionBatchSave = false;

        /// <summary>
        /// 本模块的表字段权限控制权限
        /// </summary>
        private bool permissionSetTablePermission = false;

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
        protected void GetPermission()
        {
            this.permissionBatchSave            = this.IsAuthorized("TableFieldAdmin.BatchSave");
            this.permissionExport               = this.IsAuthorized("TableFieldAdmin.Export");
            this.permissionSetTablePermission   = this.IsAuthorized("TableFieldAdmin.SetTablePermission");

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
            sb.Append(string.Format(linkbtnTemplate, "BatchSave", "icon16_save_data", permissionBatchSave ? "" : "disabled=\"True\"", "批量保存", "批量保存"));
            sb.Append(string.Format(linkbtnTemplate, "BatchSet", "icon16_table_format", permissionBatchSave ? "" : "disabled=\"True\"", "批量设置", "批量设置"));
            sb.Append(string.Format(linkbtnTemplate, "Export", "icon16_table_export", permissionExport ? "" : "disabled=\"True\"", "导出", "导出"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "SetTablePermission", "icon16_table_lightning", permissionSetTablePermission ? "" : "disabled=\"True\"", "设置权限控制表", "设置权限控制表"));
            return sb.ToString();
        }
    }
}