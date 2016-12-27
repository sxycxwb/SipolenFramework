using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;

    /// <summary>
    /// DBLinkAdminHandler 的摘要说明
    /// 
    /// 修改说明：
    ///     2015-10-27 XuWangBin V3.0版本 重新设计增加与修改代码，直接序列化页面的json，减少大量代码
    /// </summary>
    public class DBLinkAdminHandler : IHttpHandler, IRequiresSessionState
    {
        private string Action
        {
            get
            {
                return PublicMethod.GetString(getObj("action"));
            }
        }
        private object getObj(string key) { return RDIFramework.WebCommon.StringHelper.GetRequestObject(key); }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch(Action)
            {
                case "GetList":
                    GetList(context);
                    break;
                case "GetEntity":
                    GetEntity(context);
                    break;
                case "SubmitForm":
                    SubmitForm(context);
                    break;               
                case "DeleteDBLink":
                    DeleteDBLink(context);
                    break;
            }
        }

        private void GetList(HttpContext ctx)
        {
            string json = "[]";
            var dtDbLink = RDIFrameworkService.Instance.DbLinkDefineService.GetDT(Utils.UserInfo);
            json = JSONhelper.ToJson(dtDbLink);
            ctx.Response.Write(json);
        }

        private void SubmitForm(HttpContext context)
        {
            try
            {
                int IsOk = 1;
                var key = PublicMethod.GetString(getObj("key"));
                var json = PublicMethod.GetString(getObj("json"));
                UserInfo curUser = Utils.UserInfo;
                var entity = JsonHelper.JSONToObject<CiDbLinkDefineEntity>(json);
                if (string.IsNullOrEmpty(key))
                {
                    //增加
                    if (!string.IsNullOrEmpty(entity.LinkData))
                    {
                        entity.LinkData = SecretHelper.AESEncrypt(entity.LinkData);
                    }
                    entity.CreateBy = curUser.RealName;
                    entity.CreateUserId = curUser.Id;
                    string statusCode, statusMessage;
                    RDIFrameworkService.Instance.DbLinkDefineService.Add(curUser, entity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == RDIFramework.Utilities.StatusCode.OKAdd.ToString()
                        ? new JsonMessage { Success = true, Data = IsOk.ToString(), Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
                else
                {
                    var updateEntity = RDIFrameworkService.Instance.DbLinkDefineService.GetEntity(curUser, key);
                    if (updateEntity != null)
                    {
                        updateEntity.LinkName = entity.LinkName;
                        updateEntity.LinkData = entity.LinkData;
                        if (!string.IsNullOrEmpty(entity.LinkData))
                        {
                            updateEntity.LinkData = SecretHelper.AESEncrypt(entity.LinkData);
                        }
                        else
                        {
                            updateEntity.LinkData = null;
                        }
                        updateEntity.LinkType = entity.LinkType;
                        updateEntity.Description = entity.Description;
                        updateEntity.Enabled = entity.Enabled;
                    }

                    if (curUser != null)
                    {
                        updateEntity.ModifiedBy = curUser.RealName;
                        updateEntity.ModifiedUserId = curUser.Id;
                    }
                    string statusCode;
                    string statusMessage;
                    RDIFrameworkService.Instance.DbLinkDefineService.Update(curUser, updateEntity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == RDIFramework.Utilities.StatusCode.OKUpdate.ToString()
                        ? new JsonMessage { Success = true, Data = IsOk.ToString(), Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        private void GetEntity(HttpContext ctx)
        {
            var entity = RDIFrameworkService.Instance.DbLinkDefineService.GetEntity(Utils.UserInfo, PublicMethod.GetString(getObj("key")));
            if (!string.IsNullOrEmpty(entity.LinkData))
            {
                entity.LinkData = SecretHelper.AESDecrypt(entity.LinkData);
            }
            ctx.Response.Write(JSONhelper.ToJson(entity));
        }        

        private void DeleteDBLink(HttpContext ctx)
        {
            string vId = PublicMethod.GetString(getObj("key"));
            int successFlag = 0;

            try
            {
                int returnValue = RDIFrameworkService.Instance.DbLinkDefineService.SetDeleted(Utils.UserInfo, new string[] { vId });

                if (returnValue > 0)
                {
                    successFlag = 1;
                    ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = RDIFrameworkMessage.MSG0013 }.ToString());
                }
                else
                {
                    ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = RDIFrameworkMessage.MSG3020 }.ToString());
                }
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
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