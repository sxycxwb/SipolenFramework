using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.BizLogic;

    public partial class RoleAdmin : BasePage
    {
        /// <summary>
        /// 本模块的角色用户关联关系管理
        /// </summary>
        protected bool permissionRoleUser = false;


        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

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
            this.permissionAdd = this.IsAuthorized("RoleManagement.Add");
            this.permissionEdit = this.IsAuthorized("RoleManagement.Edit");
            this.permissionExport = this.IsAuthorized("RoleManagement.Export");
            this.permissionDelete = this.IsAuthorized("RoleManagement.Delete");
            this.permissionRoleUser = this.IsAuthorized("RoleManagement.RoleUser");
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
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_group_add", permissionAdd ? "" : "disabled=\"True\"", "新增角色", "新增"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_group_edit", permissionEdit ? "" : "disabled=\"True\"", "修改选中角色", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "del", "icon16_group_delete", permissionDelete ? "" : "disabled=\"True\"", "删除选中角色", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "roleuser", "icon16_group_link", permissionRoleUser ? "" : "disabled=\"True\"", "设置当前角色拥有的用户", "角色用户设置"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_group_go", permissionExport ? "" : "disabled=\"True\"", "导出角色数据", "导出"));
            sb.Append(string.Format(linkbtnTemplate, "print", "icon16_printer", permissionExport ? "" : "disabled=\"True\"", "打印", "打印"));
            return sb.ToString(); 
        }       
    }
}