using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.WebCommon;
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;

    /// <summary>
    /// LogAdminHandler 的摘要说明
    /// </summary>
    public class LogAdminHandler : IHttpHandler, IRequiresSessionState
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
                case "GetList":
                    GetDataList(context);
                    break;
                case "clearalllog":
                    ClearLog(context);
                    break;
                case "deletelog":
                    DeleteLog(context);
                    break;
                case "GetPageListLogByUser":
                    GetPageListLogByUser(context);
                    break;
                case "GetPageListLogByGeneral":
                    GetPageListLogByGeneral(context);
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
            string where = pageParam.FilterEx;
            if (SystemInfo.RDIFrameworkDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(pageParam.FilterEx))
            {
                where = pageParam.FilterEx.Replace("CREATEON", "TO_CHAR(CREATEON, 'yyyy-mm-dd')");
            }

            int recordCount = 0;
            var dtData = RDIFrameworkService.Instance.LogService.GetDTByPage(Utils.UserInfo, out recordCount, pageParam.PageIndex, pageParam.PageSize, where, (pageParam.SortField + " " + pageParam.Order));
            if (dtData != null && dtData.Rows.Count > 0)
            {
                json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtData);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write(json);
            }
        }

        private void GetPageListLogByUser(HttpContext context)
        {
            string json = "[]";
            var pageParam = new PageParam(context);
            string where = pageParam.FilterEx;
            if (SystemInfo.RDIFrameworkDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(pageParam.FilterEx))
            {
                where = pageParam.FilterEx.Replace("CREATEON", "TO_CHAR(CREATEON, 'yyyy-mm-dd')");
            }

            int recordCount = 0;
            var dtData = RDIFrameworkService.Instance.LogService.GetDTByPage(Utils.UserInfo, out recordCount, pageParam.PageIndex, pageParam.PageSize, where, (pageParam.SortField + " " + pageParam.Order));
            if (dtData != null && dtData.Rows.Count > 0)
            {
                json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtData);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write(json);
            }
        }

        private void GetPageListLogByGeneral(HttpContext context)
        {
            string json = "[]";
            var pageParam = new PageParam(context);
            string where = pageParam.FilterEx;
            if (SystemInfo.RDIFrameworkDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(pageParam.FilterEx))
            {
                where = pageParam.FilterEx.Replace("CREATEON", "TO_CHAR(CREATEON, 'yyyy-mm-dd')");
            }

            int recordCount = 0;
            var dtLogByGeneral = RDIFrameworkService.Instance.UserService.GetDTByPage(Utils.UserInfo, where, null, null, out recordCount, pageParam.PageIndex, pageParam.PageSize, PiUserTable.FieldSortCode);
            if (dtLogByGeneral != null && dtLogByGeneral.Rows.Count > 0)
            {
                json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtLogByGeneral);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write(json);
            }
        }

        private void ClearLog(HttpContext context)
        {
            try
            {
                RDIFrameworkService.Instance.LogService.Truncate(Utils.UserInfo);
                context.Response.Write("1");
            }
            catch
            {
                context.Response.Write("清空日志数据失败！");
            }
        }

        private void DeleteLog(HttpContext context)
        {
            object ids = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("ids"));
            if (ids == null || ids.ToString().Length <= 0)
            {
                context.Response.Write("请选择待删除的数据～！");
                return;
            }

            try
            {
                context.Response.Write(
                    RDIFrameworkService.Instance.LogService.BatchDelete(Utils.UserInfo, ids.ToString().Split(',')) > 0
                        ? "1"
                        : "删除所选日志记录失败！");
            }
            catch (Exception ex)
            {
                context.Response.Write("删除所选日志记录失败，错误信息：" + ex.Message);
            }
        }
    }
}