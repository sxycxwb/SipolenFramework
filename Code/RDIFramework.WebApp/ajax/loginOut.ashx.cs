using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.ajax
{
    /// <summary>
    /// loginOut 的摘要说明
    /// </summary>
    public class loginOut : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Utils.LogOut();
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