using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    public partial class SequenceAdmin : BasePage
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
            this.permissionAdd = this.IsAuthorized("SequenceAdmin.Add");
            this.permissionEdit = this.IsAuthorized("SequenceAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("SequenceAdmin.Delete");
            this.permissionExport = this.IsAuthorized("SequenceAdmin.Export");
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
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_table_add", permissionAdd ? "" : "disabled=\"True\"", "新增序列", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_table_edit", permissionEdit ? "" : "disabled=\"True\"", "修改选中序列", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "del", "icon16_table_delete", permissionDelete ? "" : "disabled=\"True\"", "删除选中序列", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_table_export", permissionExport ? "" : "disabled=\"True\"", "导出序列数据", "导出"));
            return sb.ToString();
        }       
    }
}