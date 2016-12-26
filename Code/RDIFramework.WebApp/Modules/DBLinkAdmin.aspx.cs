using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.Utilities;

    public partial class DBLinkAdmin : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GetPermission();
            }
        }

        private void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("DBLinkManagement");
            this.permissionAdd = this.IsAuthorized("DBLinkManagement.Add");
            this.permissionEdit = this.IsAuthorized("DBLinkManagement.Edit");
            this.permissionDelete = this.IsAuthorized("DBLinkManagement.Delete");
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
            sb.Append(string.Format(linkbtnTemplate, "Add", "icon16_database_add", permissionAdd ? "" : "disabled=\"True\"", "新增数据库连接", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "Edit", "icon16_database_edit", permissionEdit ? "" : "disabled=\"True\"", "修改数据库连接", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "Delete", "icon16_database_delete", permissionDelete ? "" : "disabled=\"True\"", "删除数据库连接", "删除"));           
            return sb.ToString();
        }
    }
}