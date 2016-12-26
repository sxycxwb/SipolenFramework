using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.Utilities;

    public partial class DataItemAdminV28 : BasePage
    {
        private bool permissionItemDetail = false;
        private bool permissionUserPermission = false;
        private bool permissionRolePermission = false;
        private bool permissionItemDetailAdd = false;
        private bool permissionItemDetailEdit = false;
        private bool permissionItemDetailDelete = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GetPermission();                
            }           
        }

        private void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("DataDictionaryManagement.Add");
            this.permissionEdit = this.IsAuthorized("DataDictionaryManagement.Edit");
            this.permissionDelete = this.IsAuthorized("DataDictionaryManagement.Delete");
            this.permissionExport = this.IsAuthorized("DataDictionaryManagement.Export");
            this.permissionItemDetail = this.IsAuthorized("DataDictionaryManagement.ItemDetail");
            this.permissionUserPermission = this.IsAuthorized("DataDictionaryManagement.UserPermission");
            this.permissionRolePermission = this.IsAuthorized("DataDictionaryManagement.RolePermission");

            //数据字典明细项管理
            this.permissionItemDetailAdd = this.IsAuthorized("DictionaryDetail.Add");
            this.permissionItemDetailEdit = this.IsAuthorized("DictionaryDetail.Edit");
            this.permissionItemDetailDelete = this.IsAuthorized("DictionaryDetail.Delete");
        }

        /// <summary>
        /// 加载字典明细工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        protected string BuildItemDetailToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"a_{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append(string.Format(linkbtnTemplate, "itemdetailadd", "icon16_table_add", permissionItemDetailAdd ? "" : "disabled=\"True\"", "新增字典明细项", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "itemdetailedit", "icon16_table_edit", permissionItemDetailEdit ? "" : "disabled=\"True\"", "修改选中的字典明细项", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "itemdetaildelete", "icon16_table_delete", permissionItemDetailDelete ? "" : "disabled=\"True\"", "删除选中的字典明细项", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append("<a id=\"a_refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            return sb.ToString();
        }
    }
}