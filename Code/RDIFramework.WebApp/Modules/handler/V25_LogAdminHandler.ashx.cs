using System;
using System.Collections.Generic;
using System.Data;
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
    public class V25_LogAdminHandler : IHttpHandler, IRequiresSessionState
    {
        private string action
        {
            get
            {
                return PublicMethod.GetString(getObj("action"));
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (action)
            {
                case "getlist":
                    GetDataList(context);
                    break;
                case "clearalllog":
                    ClearLog(context);
                    break;
                case "deletelog":
                    DeleteLog(context);
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

        private object getObj(string key) { return RDIFramework.WebCommon.StringHelper.GetRequestObject(key); }
        //每页的记录数
        private int pagesize { get { return RDIFramework.WebCommon.PublicMethod.GetInt(getObj("rows")); } }
        //当前请求第几页
        private int pageindex { get { return RDIFramework.WebCommon.PublicMethod.GetInt(getObj("page")); } }
        //排序字段
        public string sortName { get { return RDIFramework.WebCommon.PublicMethod.GetString(getObj("sidx")); } }
        //排序方式
        public string sortType { get { return RDIFramework.WebCommon.PublicMethod.GetString(getObj("sord")); } }

        private void GetDataList(HttpContext context)
        {
            string where = "";
            string filters = RDIFramework.WebCommon.PublicMethod.GetString(getObj("filters"));
            if (filters != "")
            {
                string grouptype;
                IList<SearchFilter> list = SearchFilter.GetSearchList(filters, out grouptype);
                where = SearchFilter.ToSql(list, grouptype);
            }


            int _pageindex = 1;
            int _pagesize = 20;

            if (pageindex > 0)
                _pageindex = pageindex;
            if (pagesize > 0)
                _pagesize = pagesize;
            int recordCount = 0;
            DataTable dtException = RDIFrameworkService.Instance.LogService.GetDTByPage(Utils.UserInfo, out recordCount, _pageindex, _pagesize, where, (sortName + " " + sortType));
            if (dtException != null && dtException.Rows.Count > 0)
            {
                string json = RDIFramework.WebCommon.JSONhelper.FormatJSONForJQgrid(RDIFramework.WebCommon.DbHelper.SqlServer.SqlEasy.GetDataPages(_pagesize, recordCount), _pageindex, recordCount, dtException);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write("系统无异常数据！");
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
            object ids = PublicMethod.GetString(getObj("ids"));
            if (ids != null && ids.ToString().Length > 0)
            {
                try
                {
                    if (RDIFrameworkService.Instance.LogService.BatchDelete(Utils.UserInfo, ids.ToString().Split(',')) > 0)
                    {
                        context.Response.Write("1");
                    }
                    else
                    {
                        context.Response.Write("删除所选日志记录失败！");
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write("删除所选日志记录失败，错误信息：" + ex.Message);
                }
            }
        }
    }
}