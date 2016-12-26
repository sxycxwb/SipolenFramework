using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// 岗位管理
    /// </summary>
    public partial class PostAdmin : BasePage
    {
        /// <summary>
        /// 新增岗位权限
        /// </summary>
        public bool PermissionAdd = false;

        /// <summary>
        /// 编辑岗位权限
        /// </summary>
        public bool PermissionEdit = false;

        /// <summary>
        /// 删除权限
        /// </summary>
        public bool PermissionDelete = false;

        /// <summary>
        /// 岗位权限
        /// </summary>
        public bool PermissionSetPermission = false;

        /// <summary>
        /// 岗位用户权限
        /// </summary>
        public bool PermissionSetUser = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GetPermission();
            }
        }

        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"post_{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_brick_add", permissionAdd ? "" : "disabled=\"True\"", "添加岗位", "添加"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_brick_edit", permissionEdit ? "" : "disabled=\"True\"", "修改岗位", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_brick_delete", permissionDelete ? "" : "disabled=\"True\"", "删除岗位", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "moveTo", "icon16_arrow_switch", permissionEdit ? "" : "disabled=\"True\"", "移动选中的岗位", "移动"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "setUser", "icon16_key", PermissionSetUser ? "" : "disabled=\"True\"", "设置选中岗位所包含的用户", "设置用户"));
            sb.Append(string.Format(linkbtnTemplate, "setPermission", "icon16_lightning", PermissionSetPermission ? "" : "disabled=\"True\"", "设置选中岗位所拥有的权限", "设置权限"));
            return sb.ToString();
        }

        /// <summary>
        /// 获得权限
        /// </summary>
        private void GetPermission()
        {
            this.PermissionAdd = this.IsAuthorized("PostAdmin.Add");
            this.PermissionEdit = this.IsAuthorized("PostAdmin.Edit");
            this.PermissionDelete = this.IsAuthorized("PostAdmin.Delete");
            this.PermissionSetPermission = this.IsAuthorized("PostAdmin.Permission");
            this.PermissionSetUser = this.IsAuthorized("PostAdmin.User");
        }
    }
}