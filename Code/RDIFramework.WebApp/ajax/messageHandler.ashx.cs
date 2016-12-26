using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.ajax
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// messageHandler 的摘要说明
    /// </summary>
    public class messageHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int messageCount = 0;
            if (Utils.UserInfo != null)
            {
                string openId;
                var dataTable = RDIFrameworkService.Instance.MessageService.GetDTNew(Utils.UserInfo, out openId);
                if ((dataTable != null) && (dataTable.Rows.Count > 0))
                {
                    messageCount = dataTable.Rows.Count;
                }
            }
            context.Response.Write(messageCount);
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