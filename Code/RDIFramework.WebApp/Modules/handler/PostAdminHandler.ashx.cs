using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// PostAdminHandler 的摘要说明
    /// </summary>
    public class PostAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "AddPost":
                    AddPost(context);
                    break;
                case "EditPost":
                    EditPost(context);
                    break;
                case "DeletePost":
                    DeletePost(context);
                    break;
                case "MoveTo":
                    MoveTo(context);
                    break;
            }
        }

        private void AddPost(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var entity = new PiRoleEntity
            {
                OrganizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("OrganizeId")),
                Code = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Code")),
                RealName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("RealName")),
                Category = "Duty",
                Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0,
                Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description")),
                DeleteMark = 0,
                AllowDelete = 1,
                AllowEdit = 1
            };

            try
            {
                string statusCode;
                string statusMessage;
                RDIFrameworkService.Instance.RoleService.Add(vUser, entity, out statusCode, out statusMessage);
                ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                    ? new JsonMessage { Success = true, Data = "1", Message = statusMessage }.ToString()
                    : new JsonMessage { Success = true, Data = "0", Message = statusMessage }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "新增岗位失败，错误信息为：" + ex.Message }.ToString());
            }  
        }

        private void EditPost(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var entity = RDIFrameworkService.Instance.RoleService.GetEntity(vUser, vId);
            if (entity != null)
            {
                entity.Code = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Code"));
                entity.RealName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("RealName"));
                entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on"? 1: 0;
                entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            }
            if (vUser != null && entity != null)
            {
                entity.ModifiedBy = vUser.RealName;
                entity.ModifiedUserId = vUser.Id;
            }

            try
            {
                string statusCode;
                string statusMessage;
                RDIFrameworkService.Instance.RoleService.Update(vUser, entity, out statusCode, out statusMessage);
                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage { Success = true, Data = "1", Message = statusMessage }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "修改岗位失败，错误信息为：" + ex.Message }.ToString());
            }
        }

        private void DeletePost(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var vReturnValue = RDIFrameworkService.Instance.RoleService.SetDeleted(vUser, new string[] { vId });
            ctx.Response.Write(vReturnValue > 0
                ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013 }.ToString()
                : new JsonMessage { Success = true, Data = "0", Message = "删除岗位失败！" }.ToString());
        }

        private void MoveTo(HttpContext ctx)
        {
            var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("OrganizeId"));
            var id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            try
            {
                var returnValue = RDIFrameworkService.Instance.RoleService.MoveTo(Utils.UserInfo, id, organizeId);
                ctx.Response.Write(returnValue > 0 ? "1" : "0");
            }
            catch (Exception ex)
            {
                ctx.Response.Write("-1");
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