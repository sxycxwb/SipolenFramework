using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 模块（菜单）管理
    /// 
    /// </summary>
    public partial class ModuleAdminV28 : BasePage
    {
        private bool permissionUserModulePermission = false;
        private bool permissionRoleModulePermission = false;
        private bool permissionOrganizeModulePermission = false;
        private bool permissionModuleConfig = false;

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
            this.permissionAdd = this.IsAuthorized("ModuleManagement.Add");
            this.permissionEdit = this.IsAuthorized("ModuleManagement.Edit");
            this.permissionDelete = this.IsAuthorized("ModuleManagement.Delete");
            this.permissionExport = this.IsAuthorized("ModuleManagement.Export");
            //this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");
            this.permissionUserModulePermission = this.IsAuthorized("ModuleManagement.UserModulePermission");
            this.permissionRoleModulePermission = this.IsAuthorized("ModuleManagement.RoleModulePermission");
            this.permissionOrganizeModulePermission = this.IsAuthorized("ModuleManagement.OrganizeModulePermission") &&
                                                      SystemInfo.EnableOrganizePermission;
            this.permissionModuleConfig = this.IsAuthorized("ModuleManagement.ModuleConfig");
        }

        /// <summary>
        /// 加载工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate ="<a id=\"a_{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"a_refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_tab_add", permissionAdd ? "" : "disabled=\"True\"", "新增模块（菜单）", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_tab_edit", permissionEdit ? "" : "disabled=\"True\"","修改选中的模块（菜单）", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_tab_delete",permissionDelete ? "" : "disabled=\"True\"", "删除选中的模块（菜单）", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            //sb.Append(string.Format(linkbtn_template, "move", "icon16_arrow_switch", permissionMove ? "" : "disabled=\"True\"", "移动选中的模块（菜单）", "移动"));
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_tab_go",permissionExport ? "" : "disabled=\"True\"", "导出模块（菜单）数据", "导出"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "setusermodulepermission", "icon16_user_level_filtering",permissionUserModulePermission ? "" : "disabled=\"True\"", "设置用户的模块（菜单）访问权限", "用户模块权限"));
            sb.Append(string.Format(linkbtnTemplate, "setrolemodulepermission", "icon16_group_key",permissionRoleModulePermission ? "" : "disabled=\"True\"", "设置角色的模块（菜单）访问权限", "角色模块权限"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "moduleconfig", "icon16_tab_content_vertical",permissionRoleModulePermission ? "" : "disabled=\"True\"", "设置模块的可用性", "模块配置"));
            return sb.ToString();
        }
    }
}