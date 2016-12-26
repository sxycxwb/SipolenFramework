using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.Modules
{
    public partial class MessageAdmin : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BuildToolBarButtons();
            }
        }

        /// <summary>
        /// 加载工具栏
        /// </summary>
        /// <returns>工具栏HTML</returns>
        public override string BuildToolBarButtons()
        {
            var sb = new StringBuilder();
            const string linkbtnTemplate = "<a id=\"{0}\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"{1}\"  {2} title=\"{3}\">{4}</a>";
            sb.Append("<a id=\"refresh\" class=\"easyui-linkbutton\" style=\"float:left\"  plain=\"true\" href=\"javascript:;\" icon=\"icon16_arrow_refresh\"  title=\"重新加载\">刷新</a> ");
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "sendMessage", "icon16_comment_edit", IsAuthorized("Resource.ManagePermission") ? "" : "disabled=\"True\"", "发送消息", "发消息"));
            if (this.UserInfo.IsAdministrator)
            {
                sb.Append(string.Format(linkbtnTemplate, "broadcastMessage", "icon16_comments_add", IsAuthorized("Resource.ManagePermission") ? "" : "disabled=\"True\"", "广播消息", "广播消息"));
            }
            sb.Append(string.Format(linkbtnTemplate, "readMessage", "icon16_email_at_sign", IsAuthorized("Resource.ManagePermission") ? "" : "disabled=\"True\"", "标志为已读", "已读"));
            sb.Append("<div class='datagrid-btn-separator'></div> ");
            sb.Append(string.Format(linkbtnTemplate, "delMessage", "icon16_comment_delete", IsAuthorized("Resource.ManagePermission") ? "" : "disabled=\"True\"", "删除选中的消息", "删除"));
            //sb.Append(string.Format(linkbtnTemplate, "exportMessage", "icon16_table_export", IsAuthorized("Resource.ManagePermission") ? "" : "disabled=\"True\"", "导出消息列表", "导出"));
            return sb.ToString();
        }
    }
}