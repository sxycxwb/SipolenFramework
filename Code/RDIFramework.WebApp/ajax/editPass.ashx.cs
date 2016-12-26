using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.ajax
{
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;
    using RDIFramework.Utilities;

    /// <summary>
    /// editPass 的摘要说明
    /// </summary>
    public class editPass : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo cUser = Utils.UserInfo;
            string newPassword = PublicMethod.GetString(context.Request["newPassword"]);
            string oldPassword = PublicMethod.GetString(context.Request["oldPassword"]);           
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                //输入的旧密码是否与当前登录的密码一至（服务端已做验证，此处可不做验证）
                /*
                if(!oldPassword.Equals(SecretHelper.AESDecrypt(cUser.Password)))
                {
                    context.Response.Write("输入的“原密码”不正确！");
                    return;
                }
                */

                RDIFrameworkService.Instance.LogOnService.ChangePassword(Utils.UserInfo, oldPassword.Trim(), newPassword.Trim(), out statusCode, out statusMessage);

                context.Response.Write(statusCode == StatusCode.ChangePasswordOK.ToString() ? "1" : statusMessage);
            }
            catch (Exception ex)
            {
                context.Response.Write("发生系统错误，请调试修改。" + ex.Message);
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