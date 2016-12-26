using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.WebCommon;
    using RDIFramework.BizLogic;

    /// <summary>
    /// ExceptionAdminHandler 的摘要说明
    /// </summary>
    public class ExceptionAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(StringHelper.GetRequestObject("action")))
            {
                case "GetList":
                    GetDataList(context);
                    break;
                case "BatchDelete":
                    BatchDeleteData(context);
                    break;
                case "ClearException":
                    ClearExceptionData(context);
                    break;
                default:
                    context.Response.Write("");
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void GetDataList(HttpContext context)
        {
            string json = "[]";
            var pageParam = new PageParam(context);
            var recordCount = 0;
            var dtException = RDIFrameworkService.Instance.ExceptionService.GetDTByPage(Utils.UserInfo, out recordCount, pageParam.PageIndex, pageParam.PageSize, pageParam.Filter, (pageParam.SortField + " " + pageParam.Order));
            if (dtException != null && dtException.Rows.Count > 0)
            {
                json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtException);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write(json);
            }
        }

        private void BatchDeleteData(HttpContext ctx)
        {
            object ids = PublicMethod.GetString(StringHelper.GetRequestObject("ids"));
            if (ids == null || ids.ToString().Length <= 0)
            {
                ctx.Response.Write("请选择待删除的数据～！");
                return;
            }

            try
            {
                ctx.Response.Write(
                    RDIFrameworkService.Instance.ExceptionService.BatchDelete(Utils.UserInfo, ids.ToString().Split(',')) > 0
                        ? "1"
                        : "删除所选异常记录失败！");
            }
            catch (Exception ex)
            {
                ctx.Response.Write("删除所选异常记录失败，错误信息：" + ex.Message);
            }
        }

        private void ClearExceptionData(HttpContext ctx)
        {
            try
            {
                RDIFrameworkService.Instance.ExceptionService.Truncate(Utils.UserInfo);
                ctx.Response.Write("1");
            }
            catch
            {
                ctx.Response.Write("清空异常数据失败！");
            }
        }
    }
}