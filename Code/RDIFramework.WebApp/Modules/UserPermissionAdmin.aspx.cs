using System;
using System.Text;
using System.Web.UI;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户权限集中设置
    /// 
    /// </summary>
    public partial class UserPermissionAdmin : BasePage
    {
        /// <summary>
        /// 搜索用户
        /// </summary>
        private bool permissionSearch = false;

        /// <summary>
        /// 用户角色
        /// </summary>
        private bool permissionUserRole = false;

        /// <summary>
        /// 用户权限
        /// </summary>
        private bool permissionUserPermission = false;

        /// <summary>
        /// 角色用户批量设置
        /// </summary>
        private bool permissionRoleUserBatchSet = false;

        /// <summary>
        /// 批量权限设置
        /// </summary>
        private bool permissionBatchPermission = false;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionUserAuthorization = false;

        /// <summary>
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

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
            this.permissionAccess            = this.IsModuleAuthorized("UserPermissionAdmin");
            this.permissionUserRole          = this.IsAuthorized("UserPermissionAdmin.UserRole");
            this.permissionUserPermission    = this.IsAuthorized("UserPermissionAdmin.UserPermission");
            this.permissionRoleUserBatchSet  = this.IsAuthorized("UserPermissionAdmin.RoleUserBatchSet");
            this.permissionBatchPermission   = this.IsAuthorized("UserPermissionAdmin.BatchPermission");
            this.permissionUserAuthorization = this.IsAuthorized("UserPermissionAdmin.UserAuthorization");
            this.permissionSearch            = this.IsAuthorized("UserManagement.Search");
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
            sb.Append(string.Format(linkbtnTemplate, "UserPermission", "icon16_user_level_filtering", permissionUserPermission ? "" : "disabled=\"True\"", "用户权限设置", "用户权限"));
            sb.Append(string.Format(linkbtnTemplate, "UserRole", "icon16_group_link", permissionUserRole ? "" : "disabled=\"True\"", "用户角色关联", "用户角色"));
            sb.Append(string.Format(linkbtnTemplate, "UserRoleBatchSet", "icon16_shape_square_key", permissionRoleUserBatchSet ? "" : "disabled=\"True\"", "用户角色集中批量设置", "用户角色批量设置"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "UserBatchPermission", "icon16_lightning", permissionBatchPermission ? "" : "disabled=\"True\"", "用户权限集中批量设置", "用户权限批量设置"));
            if (this.permissionUserAuthorization && SystemInfo.EnableUserAuthorizationScope)
            {
                //sb.Append("<a href=\"javascript:void(0)\" id=\"sb\" onclick=\"javascript:alert('亲，正在开发中...')\">权限设置</a>");
                sb.Append("<a href=\"javascript:void(0)\" id=\"sb\">权限设置</a>");
                sb.Append(GenerateSplitTool());
            }
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "Search", "icon16_filter", permissionSearch ? "" : "disabled=\"True\"", "搜索", "搜索"));
            return sb.ToString();
        }

        private string GenerateSplitTool()
        {
            var sbTool = new StringBuilder();
            sbTool.Append("<div id=\"mm\" style=\"width:100px;\">");
            sbTool.Append("<div id=\"btnUserPermissionScope\" data-options=\"iconCls:'icon16_report_user'\">用户授权范围</div>");
            sbTool.Append("<div id=\"btnUserTableFieldPermission\" data-options=\"iconCls:'icon16_timeline_marker'\">表字段权限设置</div>");
            sbTool.Append("<div id=\"btnUserTableConstraintSet\"  data-options=\"iconCls:'icon16_script_key'\">约束条件权限设置</div>");
            sbTool.Append("</div>");
            return sbTool.ToString();
        }       
    }
}