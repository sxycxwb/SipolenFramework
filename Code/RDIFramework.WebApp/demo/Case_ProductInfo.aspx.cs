using System;
using System.Text;
using System.Web.UI;

namespace RDIFramework.WebApp
{
    public partial class Case_ProductInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GetPermission();
            }
        }

        private bool permissionFind = false;
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        private void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("ProductAdmin.Add");
            this.permissionEdit = this.IsAuthorized("ProductAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("ProductAdmin.Delete");
            this.permissionFind = this.IsAuthorized("ProductAdmin.Find");
            this.permissionExport = this.IsAuthorized("ProductAdmin.Export");
        }

        /// <summary>
        /// 加载工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"a_{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"a_refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_add", permissionAdd ? "" : "disabled=\"True\"", "新增产品数据", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_table_edit", permissionEdit ? "" : "disabled=\"True\"", "修改选中的产品数据", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_table_delete", permissionDelete ? "" : "disabled=\"True\"", "删除选中的产品数据", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_table_export", permissionExport ? "" : "disabled=\"True\"", "导出产品数据", "导出数据"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "search", "icon16_table_filter", permissionFind ? "" : "disabled=\"True\"", "查询", "查询"));
            return sb.ToString();
        }
    }
}