using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.ajax
{
    using RDIFramework.WebCommon;
    using RDIFramework.Utilities;

    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //if (DateTime.Now.Month == 11 && DateTime.Now.Day > 30)
            //{
            //    context.Response.Write("<h1>试用期到啦，请联系QQ：406590790，获取正版，谢谢。</h2>");
            //    context.Response.End();
            //}

            try
            {
                var username   = PublicMethod.GetString(context.Request["uName"]);
                var password   = PublicMethod.GetString(context.Request["uPwd"]);
                var systemType = PublicMethod.GetString(context.Request["systemType"]);
                var savedays   = PublicMethod.GetInt(context.Request["cookieDay"]);
                var theme      = PublicMethod.GetString(context.Request["theme"]); //皮肤

                if (theme == "")
                    theme = "gray"; //默认皮肤

                HttpContext.Current.Session["theme"] = theme;
                var cook = new HttpCookie("theme") {Value = theme, Expires = DateTime.Now.AddDays(30)};
                HttpContext.Current.Response.Cookies.Add(cook);
                string returnStatusCode = string.Empty;
                string returnStatusMessage = string.Empty;
                string permissionItemCode = string.Empty;


                // 登录验证
                var userModel = Utils.LogOn(username, password,string.Empty, permissionItemCode, true, false, out returnStatusCode, out returnStatusMessage);
                if (userModel != null && returnStatusCode.Equals(StatusCode.OK.ToString()))
                {
                    context.Response.Write("1");
                }
                else if (userModel == null || !returnStatusCode.Equals(StatusCode.OK.ToString()))
                {
                    context.Response.Write(!string.IsNullOrEmpty(returnStatusMessage)
                        ? returnStatusMessage
                        : "请检查您的用户名或密码！或者与管理员联系（QQ：406590790）。");
                }                
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
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