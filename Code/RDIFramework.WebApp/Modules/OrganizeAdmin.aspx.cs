using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDIFramework.Utilities;

namespace RDIFramework.WebApp.Modules
{
    public partial class OrganizeAdmin : BasePage
    { 
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        //private string PermissionItemScopeCode = "Resource.ManagePermission";

        private bool permissionMove = false;
        private bool permissionUserOrganizePermission = false;
        private bool permissionRolerOrganizePermission = false;

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
            this.permissionAdd = this.IsAuthorized("OrganizeManagement.Add");
            this.permissionEdit = this.IsAuthorized("OrganizeManagement.Edit");
            this.permissionMove = this.IsAuthorized("OrganizeManagement.Move");
            this.permissionDelete = this.IsAuthorized("OrganizeManagement.Delete");
            this.permissionExport = this.IsAuthorized("OrganizeManagement.Export");
            //this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");
            this.permissionUserOrganizePermission = this.IsAuthorized("OrganizeManagement.UserOrganizePermission");
            this.permissionRolerOrganizePermission = this.IsAuthorized("OrganizeManagement.RolerOrganizePermission");
        }

        /// <summary>
        /// 加载工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"btn{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"a_refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "Add", "icon16_add", permissionAdd ? "" : "disabled=\"True\"", "新增组织机构", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "Edit", "icon16_edit_button", permissionEdit ? "" : "disabled=\"True\"", "修改选中的组织机构", "修改"));                      
            sb.Append(string.Format(linkbtnTemplate, "Delete", "icon16_delete", permissionDelete ? "" : "disabled=\"True\"", "删除选中组织机构", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "MoveTo", "icon16_arrow_switch", permissionMove ? "" : "disabled=\"True\"", "移动选中的组织机构", "移动"));
            sb.Append(string.Format(linkbtnTemplate, "Export", "icon16_table_export", permissionExport ? "" : "disabled=\"True\"", "导出组织机构数据", "导出"));
            if (SystemInfo.EnableOrganizePermission)
            {
                sb.Append("<div class='datagrid-btn-separator'></div> ");
                sb.Append(string.Format(linkbtnTemplate, "UserOrganizePermission", "icon16_key",permissionUserOrganizePermission ? "" : "disabled=\"True\"", "设置用户组织机构权限", "用户组织机构权限"));
                sb.Append(string.Format(linkbtnTemplate, "RoleOrganizePermission", "icon16_lightning",permissionRolerOrganizePermission ? "" : "disabled=\"True\"", "设置角色组织机构权限", "角色组织机构权限"));
            }
            return sb.ToString();
        }
    }
}