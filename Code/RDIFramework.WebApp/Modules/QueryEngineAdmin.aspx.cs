using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 查询引擎管理
    /// </summary>
    public partial class QueryEngineAdmin : BasePage
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
        private void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("QueryEngineAdmin.Add");
            this.permissionEdit = this.IsAuthorized("QueryEngineAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("QueryEngineAdmin.Delete");
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
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_tab_add", permissionAdd ? "" : "disabled=\"True\"", "新增", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_tab_edit", permissionEdit ? "" : "disabled=\"True\"", "修改", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_tab_delete", permissionDelete ? "" : "disabled=\"True\"", "删除", "删除"));
            return sb.ToString();
        }
    }
}