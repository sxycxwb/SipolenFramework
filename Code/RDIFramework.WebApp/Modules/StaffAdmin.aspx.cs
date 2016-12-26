using System;
using System.Text;
using System.Web.UI;

namespace RDIFramework.WebApp.Modules
{
    public partial class StaffAdmin : BasePage
    {
        protected string organizeJSON = string.Empty;

        /// <summary>
        /// 移动员工权限
        /// </summary>
        private bool permissionMoveTo = false;


        /// <summary>
        /// 删除员工权限
        /// </summary>
        private bool permissionDelete = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GetPermission();                
            }
        }       

        /// <summary>
        /// 获得权限
        /// </summary>
        private void GetPermission()
        {
            this.permissionAdd      = this.IsAuthorized("StaffAdmin.Add");
            this.permissionEdit     = this.IsAuthorized("StaffAdmin.Edit");
            this.permissionMoveTo   = this.IsAuthorized("StaffAdmin.Move");
            this.permissionDelete   = this.IsAuthorized("StaffAdmin.Delete");
            this.permissionExport   = this.IsAuthorized("StaffAdmin.Export");           
        }

        /// <summary>
        /// 加载工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"btn{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"btnRefresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "AddStaff", "icon16_vcard_add", permissionAdd ? "" : "disabled=\"True\"", "添加员工", "添加"));
            sb.Append(string.Format(linkbtnTemplate, "EditStaff", "icon16_vcard_edit", permissionEdit ? "" : "disabled=\"True\"", "修改员工", "修改"));
            sb.Append(string.Format(linkbtnTemplate, "DeleteStaff", "icon16_vcard_delete", permissionDelete ? "" : "disabled=\"True\"", "删除员工", "删除"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "MoveTo", "icon16_arrow_switch", permissionMoveTo ? "" : "disabled=\"True\"", "移动选中的员工", "移动"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "Export", "icon16_user_go", permissionExport ? "" : "disabled=\"True\"", "导出员工数据", "导出"));
            return sb.ToString();
        }
    }
}