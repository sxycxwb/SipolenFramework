using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    public partial class PermissionItemAdmin : BasePage
    { 
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        //private string PermissionItemScopeCode = "Resource.ManagePermission";
        private bool permissionMove = false;
        private bool permissionRolePermissionItem = false;
        private bool permissionUserPermissionItem = false;
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
            this.permissionAdd = this.IsAuthorized("PermissionItemManagement.Add");        // 新增权限
            //this.permissionAddRoot      = this.IsAuthorized("PermissionItemManagement.AddRoot");    // 添加根权限
            this.permissionEdit = this.IsAuthorized("PermissionItemManagement.Edit");       // 编辑权限
            this.permissionMove = this.IsAuthorized("PermissionItemManagement.Move");       // 移动权限
            this.permissionDelete = this.IsAuthorized("PermissionItemManagement.Delete");     // 删除权限
            this.permissionExport = this.IsAuthorized("PermissionItemManagement.Export");     // 导出数据
            //this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");
            this.permissionRolePermissionItem = this.IsAuthorized("PermissionItemManagement.RolePermissionItem");
            this.permissionUserPermissionItem = this.IsAuthorized("PermissionItemManagement.UserPermissionItem");
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
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_layout_add", permissionAdd ? "" : "disabled=\"True\"", "新增操作权限", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_layout_edit", permissionEdit ? "" : "disabled=\"True\"", "修改操作权限", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_layout_delete", permissionDelete ? "" : "disabled=\"True\"", "删除操作权限", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "move", "icon16_arrow_switch", permissionMove ? "" : "disabled=\"True\"", "移动选中的操作权限", "移动"));
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_table_export", permissionExport ? "" : "disabled=\"True\"", "导出操作权限列表", "导出"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "setuserpermissionitemepermission", "icon16_user_level_filtering", permissionUserPermissionItem ? "" : "disabled=\"True\"", "设置用户的操作权限项访问权限", "用户操作权限"));
            sb.Append(string.Format(linkbtnTemplate, "setrolepermissionitemepermission", "icon16_group_key", permissionRolePermissionItem ? "" : "disabled=\"True\"", "设置角色的操作权限项访问权限", "角色操作权限"));
            return sb.ToString();
        }
    }
}