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
    /// 角色权限集中设置
    /// 
    /// </summary>
    public partial class RolePermissionAdmin : BasePage
    {
        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        //private bool permissionAccess = false;

        /// <summary>
        /// 本模块的角色用户关联关系管理
        /// </summary>
        private bool permissionRoleUser = false;

        /// <summary>
        /// 本模块的角色用户批量设置管理
        /// </summary>
        private bool permissionRoleUserBatchSet = false;

        /// <summary>
        /// 本模块的用户角色授权权限
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        //private string PermissionItemScopeCode = "Resource.ManagePermission";

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
            // 这个可以是范围权限（这里当操作权限处理），对哪些（组织机构、用户、角色）分配权限的范围权限？
            this.permissionAccredit = this.IsAuthorized("RolePermissionAdmin.Accredit");
            // 当前用户有什么相应的操作权限？            
            this.permissionRoleUser = this.IsAuthorized("RoleManagement.RoleUser");
            //当前用户是否可以进行角色用户批量关联设置
            this.permissionRoleUserBatchSet = this.IsAuthorized("RoleManagement.RoleUserBatchSet");
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
            sb.Append(string.Format(linkbtnTemplate, "RolePermission", "icon16_group_key", permissionAccredit ? "" : "disabled=\"True\"", "角色权限设置", "角色权限"));
            sb.Append(string.Format(linkbtnTemplate, "RoleUser", "icon16_group_link", permissionRoleUser ? "" : "disabled=\"True\"", "角色用户关联", "角色用户"));
            sb.Append(string.Format(linkbtnTemplate, "RoleUserBatchSet", "icon16_folder_user", permissionRoleUserBatchSet ? "" : "disabled=\"True\"", "角色用户集中批量设置", "角色用户批量设置"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "RoleBatchPermission", "icon16_shape_square_key", permissionRoleUserBatchSet ? "" : "disabled=\"True\"", "角色权限集中批量设置", "角色权限批量设置"));
            if (SystemInfo.EnableUserAuthorizationScope)
            {
                sb.Append("<a href=\"javascript:void(0)\" id=\"sb\">权限设置</a>");
                sb.Append(GenerateSplitTool());
            }
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "Search", "icon16_filter","", "搜索", "搜索"));
            return sb.ToString();
        }

        private string GenerateSplitTool()
        {
            var sbTool = new StringBuilder();
            sbTool.Append("<div id=\"mm\" style=\"width:100px;\">");
            sbTool.Append("<div id=\"btnRolePermissionScope\" data-options=\"iconCls:'icon16_report_user'\">角色授权范围</div>");
            sbTool.Append("<div id=\"btnRoleTableFieldPermission\" data-options=\"iconCls:'icon16_timeline_marker'\">表字段权限设置</div>");
            sbTool.Append("<div id=\"btnRoleTableConstraintSet\" data-options=\"iconCls:'icon16_script_key'\">约束条件权限设置</div>");
            sbTool.Append("</div>");
            return sbTool.ToString();
        }

    }
}