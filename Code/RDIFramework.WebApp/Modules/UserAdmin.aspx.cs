using System;
using System.Data;
using System.Web.UI;
using System.Text;

namespace RDIFramework.WebApp.Modules
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// 用户管理
    /// </summary>
    public partial class UserAdmin : BasePage
    {
        DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 设置密码
        /// </summary>
        private bool permissionSetPassword = false;

        /// <summary>
        /// 删除用户
        /// </summary>
        private bool permissionDelete = false;


        /// <summary>
        /// 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// 
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

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
            const string linkbtnTemplate = "<a id=\"a_{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"a_refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "add", "icon16_user_add", permissionAdd ? "" : "disabled=\"True\"", "添加用户", "添加"));
            sb.Append(string.Format(linkbtnTemplate, "edit", "icon16_user_edit", permissionEdit ? "" : "disabled=\"True\"", "修改用户", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "delete", "icon16_user_delete", permissionDelete ? "" : "disabled=\"True\"", "删除用户", "删除"));
            //sb.Append("<div class='datagrid-btn-separator'></div> ");
            //sb.Append(string.Format(linkbtnTemplate, "search", "icon16_filter", "", "查询", "查询"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "editpassword", "icon16_user_level_filtering", permissionSetPassword ? "" : "disabled=\"True\"", "设置选中用户密码", "设置密码"));
            sb.Append(string.Format(linkbtnTemplate, "dimission", "icon16_aol_messenger", IsAuthorized("UserManagement.Dimission") ? "" : "disabled=\"True\"", "离职", "离职"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "export", "icon16_user_level_filtering", permissionExport ? "" : "disabled=\"True\"", "导出用户数据", "导出"));
            sb.Append("<a href=\"javascript:void(0)\" id=\"sb\">访问日志</a>");
            sb.Append(GenerateSplitTool());
            return sb.ToString();
        }

        private string GenerateSplitTool()
        {
            var sbTool = new StringBuilder();
            sbTool.Append("<div id=\"mm\" style=\"width:100px;\">");
            sbTool.Append("<div id=\"btnLogByUser\" data-options=\"iconCls:'icon16_cheque'\">用户访问详情</div>");
            sbTool.Append("<div id=\"btnLogByGeneral\" data-options=\"iconCls:'icon16_blogs'\">用户访问情况</div>");
            sbTool.Append("</div>");
            return sbTool.ToString();
        }

        /// <summary>
        /// 获得权限
        /// </summary>
        private void GetPermission()
        { 
            this.permissionAdd = this.IsAuthorized("UserManagement.Add");
            this.permissionEdit = this.IsAuthorized("UserManagement.Edit");
            this.permissionSetPassword = this.IsAuthorized("UserManagement.SetUserPassword");
            this.permissionDelete = this.IsAuthorized("UserManagement.Delete");
        }
    }
}