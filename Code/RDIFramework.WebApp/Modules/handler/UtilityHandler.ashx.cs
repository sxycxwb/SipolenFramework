using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;

    /// <summary>
    /// UtilityHandler 的摘要说明
    /// </summary>
    public class UtilityHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "OptionUserJson":
                    OptionUserJson(context);
                    break;
            }
        }

        public void OptionUserJson(HttpContext ctx)
        {
            var keyword = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyword"));
            DataTable ListData = RDIFrameworkService.Instance.UserService.Search(Utils.UserInfo, keyword, "", null);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (ListData != null && ListData.Rows.Count > 0)
            {
                foreach (DataRow item in ListData.Rows)
                {
                    sb.Append("{");
                    sb.Append("\"id\":\"" + item["Id"] + "\",");
                    sb.Append("\"text\":\"" + item["RealName"] + "（" + item["UserName"] + "）\",");
                    string Genderimg = "user_female";
                    if (item["Gender"].ToString() == "男")
                    {
                        Genderimg = "user_green";
                    }
                    sb.Append("\"iconCls\":\"icon16_" + Genderimg + "\",");
                    sb.Append("\"username\":\"" + item["UserName"] + "\",");
                    sb.Append("\"code\":\"" + item["Code"] + "\",");
                    sb.Append("\"realname\":\"" + item["RealName"] + "\",");
                    sb.Append("\"hasChildren\":false");
                    sb.Append("},");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            ctx.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}