using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// “系统参数管理”业务处理程序
    /// 
    /// </summary>
    public class ParameterAdminHandler : IHttpHandler, IRequiresSessionState
    {
        private string Action
        {
            get
            {
                return PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action"));
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (Action)
            {
                case "add":
                    AddParameter(context);
                    break;
                case "edit":
                    EditParameter(context);
                    break;
                case "delete":
                    DeleteParameter(context);
                    break;
                case "GetParameterListByPage":
                    GetParameterListByPage(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.ParameterService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")))));
                    break;
            }
        }

        private CiParameterEntity GetPageEntity(CiParameterEntity entity)
        {
            entity.CategoryKey = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("CategoryKey"));
            entity.ParameterId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("ParameterId"));
            entity.ParameterCode = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("ParameterCode"));            
            entity.ParameterContent = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("ParameterContent"));
            entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            entity.AllowEdit = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AllowEdit")) == "on" ? 1 : 0;
            entity.AllowDelete = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AllowDelete")) == "on" ? 1 : 0;
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            return entity;
        }

        private void AddParameter(HttpContext ctx)
        {
            var entity = new CiParameterEntity { DeleteMark = 0 };
            entity = GetPageEntity(entity);
            try
            {
                int returnValue = RDIFrameworkService.Instance.ParameterService.SetParameter(Utils.UserInfo, entity.CategoryKey, entity.ParameterId, entity.ParameterCode, entity.ParameterContent, entity.AllowEdit ?? 0, entity.AllowDelete ?? 0);

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "新增成功" }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = "新增失败" }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = ex.Message }.ToString());
            }
        }

        private void EditParameter(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var entity = RDIFrameworkService.Instance.ParameterService.GetEntity(Utils.UserInfo, vId);
            entity = this.GetPageEntity(entity);
            try
            {
                int returnValue = RDIFrameworkService.Instance.ParameterService.SetParameter(Utils.UserInfo, entity.CategoryKey, entity.ParameterId, entity.ParameterCode, entity.ParameterContent, entity.AllowEdit ?? 0, entity.AllowDelete ?? 0);

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "修改成功" }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = "修改失败" }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = ex.Message }.ToString());
            }
        }

        private void DeleteParameter(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));

            var successFlag = 0;
            try
            {
                var returnValue = RDIFrameworkService.Instance.ParameterService.SetDeleted(Utils.UserInfo, vId);

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
        private void GetParameterListByPage(HttpContext ctx)
        {
            var pageParam = new PageParam(ctx);
            var recordCount = 0;
            var dtRole = RDIFrameworkService.Instance.ParameterService.GetDTByPage(Utils.UserInfo, out recordCount, pageParam.PageIndex, pageParam.PageSize, pageParam.Filter, (pageParam.SortField + " " + pageParam.Order));
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