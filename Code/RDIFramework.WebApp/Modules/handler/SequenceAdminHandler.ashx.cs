using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{  
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// SequenceAdminHandler 的摘要说明
    /// </summary>
    public class SequenceAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "add":
                    AddSequence(context);
                    break;
                case "edit":
                    EditSequence(context);
                    break;
                case "delete":
                    DeleteSequence(context);
                    break;
                case "GetSequenceListByPage":
                    GetSequenceListByPage(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.SequenceService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")))));
                    break;
            }
        }

        private CiSequenceEntity GetPageEntity(CiSequenceEntity entity)
        {
            entity.FullName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FullName"));
            entity.Prefix = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Prefix"));
            entity.Separate = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Separate"));
            entity.Sequence = BusinessLogic.ConvertToNullableInt(WebCommon.StringHelper.GetRequestObject("Sequence"));
            entity.Reduction = BusinessLogic.ConvertToNullableInt(WebCommon.StringHelper.GetRequestObject("Reduction"));
            entity.Step = BusinessLogic.ConvertToNullableInt(WebCommon.StringHelper.GetRequestObject("Step"));           
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));           
            return entity;
        }

        private void AddSequence(HttpContext ctx)
        {
            var entity = new CiSequenceEntity { DeleteMark = 0 };
            var vUser = Utils.UserInfo;
            entity = GetPageEntity(entity);           
            var statusCode = string.Empty;
            var statusMessage = string.Empty;
            try
            {
                string keyId = RDIFrameworkService.Instance.SequenceService.Add(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                    ? new JsonMessage { Success = true, Data = keyId, Message = statusMessage }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage + ex.Message }.ToString());
            }
        }

        private void EditSequence(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var entity = RDIFrameworkService.Instance.SequenceService.GetEntity(vUser, vId);
            entity = this.GetPageEntity(entity);
            var statusCode = string.Empty;
            var statusMessage = string.Empty;
            try
            {
                RDIFrameworkService.Instance.SequenceService.Update(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage { Success = true, Data = "1", Message = statusMessage }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage + ex.Message }.ToString());
            }
        }

        private void DeleteSequence(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var vUser = Utils.UserInfo;

            var successFlag = 0;
            try
            {
                var returnValue = RDIFrameworkService.Instance.SequenceService.SetDeleted(Utils.UserInfo, vId);

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

        /// <summary>
        /// 得到分页角色列表
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetSequenceListByPage(HttpContext ctx)
        {
            var pageParam = new PageParam(ctx);
            var recordCount = 0;
            var dtRole = RDIFrameworkService.Instance.SequenceService.GetDTByPage(Utils.UserInfo, out recordCount, pageParam.PageIndex, pageParam.PageSize, pageParam.Filter, (pageParam.SortField + " " + pageParam.Order));
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtRole);
            ctx.Response.Write(json);

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