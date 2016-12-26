using System;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json.Linq;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    /// <summary>
    /// SysConfigHandler 的摘要说明
    /// </summary>
    public class SysConfigHandler : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var json = context.Request["json"];
            switch (context.Request["action"])
            {
                case "js":
                    GetDefaultConfig(context);
                    break;
                default:
                    UpdateUserConfig(context,json);
                    break;
            }
        }

        private void GetDefaultConfig(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var curTheme = RDIFrameworkService.Instance.ParameterService.GetParameter(vUser, "User", vUser.Id, "WebTheme");
            var curPageSize = RDIFrameworkService.Instance.ParameterService.GetParameter(vUser, "User", vUser.Id,"WebPageSize");
            var curNavType = RDIFrameworkService.Instance.ParameterService.GetParameter(vUser, "User", vUser.Id, "NavType");
            if (!string.IsNullOrEmpty(curTheme)) 
            {
                HttpContext.Current.Session["theme"] = curTheme;
            }
            var outJson = "var sys_config ={";
            outJson += string.IsNullOrEmpty(curTheme)
                    ? "\"theme\":{\"title\":\"默认皮肤\",\"name\":\"default\",\"selected\":true}"
                    : "\"theme\":{\"title\":\"默认皮肤\",\"name\":\"" + curTheme + "\",\"selected\":true}";
            outJson += string.IsNullOrEmpty(curPageSize)
                    ? ",\"gridRows\":20"
                    : ",\"gridRows\":" + curPageSize;
            outJson += string.IsNullOrEmpty(curNavType)
                    ? ",\"navType\":\"AccordionTree\"}"
                    : ",\"navType\":\""+curNavType + "\"}";
            ctx.Response.Write(outJson);
        }

        private void UpdateUserConfig(HttpContext ctx,string jsonStr)
        {
            UserInfo vUser = Utils.UserInfo;
            if (!string.IsNullOrEmpty(jsonStr))
            {
                //"{\"theme\":{\"title\":\"Metro\",\"name\":\"metro\"},\"gridRows\":\"20\"}"
                var jobj = JObject.Parse(jsonStr);
                var pageSize = BusinessLogic.ConvertToString(jobj["gridRows"]);
                var themeName = BusinessLogic.ConvertToString(jobj["theme"]["name"]);
                var navType = BusinessLogic.ConvertToString(jobj["navType"]);
                var returnValue = 0;
                if (!string.IsNullOrEmpty(pageSize))
                {
                    returnValue += RDIFrameworkService.Instance.ParameterService.SetParameter(vUser, "User", vUser.Id,"WebPageSize", pageSize);
                }
                if (!string.IsNullOrEmpty(themeName))
                {
                    returnValue += RDIFrameworkService.Instance.ParameterService.SetParameter(vUser, "User", vUser.Id,"WebTheme", themeName);
                    HttpContext.Current.Session["theme"] = themeName;
                    HttpCookie cookie = new HttpCookie("theme", themeName) {Expires = DateTime.Now.AddDays(10)};
                    ctx.Response.Cookies.Add(cookie);//将cookie写入客户端

                }
                if (!string.IsNullOrEmpty(navType))
                {
                    returnValue += RDIFrameworkService.Instance.ParameterService.SetParameter(vUser, "User", vUser.Id, "NavType", navType);
                }
                ctx.Response.Write(returnValue > 0 ? "1" : "保存失败！");
            }
            else
            {
                ctx.Response.Write("无保存数据！");
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