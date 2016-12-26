using System;
using System.Text;
using System.Web.UI;

namespace RDIFramework.WebApp.Modules
{
    /// <summary>
    /// 系统参数配置管理
    /// </summary>
    public partial class ParameterAdmin : BasePage
    {
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
            this.permissionAdd = this.IsAuthorized("ParameterAdmin.Add");
            this.permissionEdit = this.IsAuthorized("ParameterAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("ParameterAdmin.Delete");
            this.permissionExport = this.IsAuthorized("ParameterAdmin.Export");
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
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_cog_add", permissionAdd ? "" : "disabled=\"True\"", "新增序列", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_cog_edit", permissionEdit ? "" : "disabled=\"True\"", "修改选中序列", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "del", "icon16_cog_delete", permissionDelete ? "" : "disabled=\"True\"", "删除选中序列", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_cog_go", permissionExport ? "" : "disabled=\"True\"", "导出序列数据", "导出"));
            return sb.ToString();
        }    
    }
}