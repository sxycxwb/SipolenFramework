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
    /// 查询引擎定义
    /// </summary>
    public partial class QueryEngineDefineAdmin : BasePage
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
            this.permissionAdd = this.IsAuthorized("QueryEngineDefine.Add");
            this.permissionEdit = this.IsAuthorized("QueryEngineDefine.Edit");
            this.permissionDelete = this.IsAuthorized("QueryEngineDefine.Delete");
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
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_table_add", permissionAdd ? "" : "disabled=\"True\"", "新增", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_table_edit", permissionEdit ? "" : "disabled=\"True\"", "修改", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_table_delete", permissionDelete ? "" : "disabled=\"True\"", "删除", "删除"));
            sb.Append(string.Format(linkbtnTemplate, "prviewData", "icon16_table_export", true ? "" : "disabled=\"True\"", "预览数据", "预览数据"));
            return sb.ToString();
        }
    }
}