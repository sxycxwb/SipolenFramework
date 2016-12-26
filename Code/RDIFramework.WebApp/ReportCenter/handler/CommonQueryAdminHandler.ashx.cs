using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.ReportCenter.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// CommonQueryAdminHandler 的摘要说明
    /// </summary>
    public class CommonQueryAdminHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetEngineDefinePageDTByEngineIds":
                    GetEngineDefinePageDTByEngineIds(context);
                    break;               
                case "GetDynamicJsonByQueryEngineDefineId":
                    GetDynamicJsonByQueryEngineDefineId(context);
                    break;
            }
        }

        private void GetEngineDefinePageDTByEngineIds(HttpContext context)
        {
            string queryEngineId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("queryEngineId"));
            var where = "";
            var pageParam = new PageParam(context);
            where = pageParam.Filter;
            if (string.IsNullOrEmpty(where))
            {
                where += QueryEngineDefineTable.FieldQueryEngineId + "='" + queryEngineId + "'";
            }
            else
            {
                where += " AND " + QueryEngineDefineTable.FieldQueryEngineId + "='" + queryEngineId + "'";
            }

            var recordCount = 0;
            var dtQueryEngineDefine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineDTByPage(Utils.UserInfo, where, out recordCount, pageParam.PageIndex, pageParam.PageSize, (pageParam.SortField + " " + pageParam.Order));
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtQueryEngineDefine);
            context.Response.Write(json);
        }

        /// <summary>
        /// 按查询引擎主键列表得到对应的查询引擎定义列表
        /// </summary>
        private void GetDynamicJsonByQueryEngineDefineId(HttpContext context)
        {
            try
            {
                var queryEngineDefineId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("queryEngineDefineId"));
                int pageSize = Convert.ToInt32(WebCommon.StringHelper.GetRequestObject("pageSize"));
                int pageIndex = Convert.ToInt32(WebCommon.StringHelper.GetRequestObject("pageNumber"));
                //排序字段
                string sortName = RDIFramework.Utilities.BusinessLogic.ConvertToString(WebCommon.StringHelper.GetRequestObject("sort"));
                //排序方式
                string sortType = RDIFramework.Utilities.BusinessLogic.ConvertToString(WebCommon.StringHelper.GetRequestObject("order"));

                var where = "";
                var filters = RDIFramework.Utilities.BusinessLogic.ConvertToString(WebCommon.StringHelper.GetRequestObject("filter"));
                if (!string.IsNullOrEmpty(filters))
                {
                    string grouptype;
                    var list = SearchFilter.GetSearchList(filters, out grouptype);
                    where = SearchFilter.ToSql(list, grouptype);
                }

                var _pageindex = pageIndex > 0 ? pageIndex : 1;
                var _pagesize = pageSize > 0 ? pageSize : 10;
                var recordCount = 0;
                UserInfo vUser = Utils.UserInfo;
                QueryEngineDefineEntity queryEngineDefineEntity = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineEntity(vUser, queryEngineDefineId);
                CiDbLinkDefineEntity dblinkEntity = null;
                IDbProvider dbProvider = null;
                if (queryEngineDefineEntity != null && !string.IsNullOrEmpty(queryEngineDefineEntity.DataBaseLinkName))
                {
                    dblinkEntity = RDIFrameworkService.Instance.DbLinkDefineService.GetEntity(vUser, queryEngineDefineEntity.DataBaseLinkName);
                }

                if (dblinkEntity != null)
                {
                    var DbDefine = RDIFrameworkService.Instance.DbLinkDefineService.GetEntityByLinkName(vUser, dblinkEntity.LinkName);
                    dbProvider = DbDefine != null ? DbFactoryProvider.GetProvider((CurrentDbType)Enum.Parse(typeof(CurrentDbType), DbDefine.LinkType, true), SecretHelper.AESDecrypt(DbDefine.LinkData))
                                            : DbFactoryProvider.GetProvider(SystemInfo.BusinessDbType, SystemInfo.BusinessDbConnectionString);
                }

                var dtDynamicJsonDt = dbProvider.GetDTByPage(out recordCount, queryEngineDefineEntity.QueryString, _pageindex, _pagesize, string.Empty, queryEngineDefineEntity.OrderByField);


                var JsonData = new
                {
                    page = _pageindex,
                    total = recordCount,
                    rows = dtDynamicJsonDt
                };
                string returnJson = Newtonsoft.Json.JsonConvert.SerializeObject(JsonData);
                //{ "columns":"[[ {"field":"field1","title":"title1"},{...} ]]",data:[{page:"pageIndex",total:"totalNum",rows:[{name1:value,name2:value},{...}]}]}
                returnJson = "{\"columns\":" + CreateDataGridColumnModel(dtDynamicJsonDt) + ",\"data\":[" + returnJson + "]}";

                //TODO:待处理，处理异常情况（如：数据库连接失败等），前端应该提示
                context.Response.Write(returnJson);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 创建DataGrid的列(实现动态生成列)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string CreateDataGridColumnModel(DataTable dt)
        {
            StringBuilder columns = new StringBuilder("[[");
            int width = 0;
            foreach (DataColumn col in dt.Columns)
            {
                //控制列的宽度 第一列日期宽度为139,其余列为列名的汉字长度*20px  
                if (col.ColumnName == "日期")
                {
                    width = 139;
                }
                else
                {
                    width = col.ColumnName.Length * 20;
                }
                columns.AppendFormat("{{\"field\":\"{0}\",\"title\":\"{1}\",\"align\":\"center\",\"width\":{2}}},", col.ColumnName, col.ColumnName, width);
            }
            if (dt.Columns.Count > 0)
            {
                columns.Remove(columns.Length - 1, 1);//去除多余的','号  
            }
            columns.Append("]]");
            return columns.ToString();
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