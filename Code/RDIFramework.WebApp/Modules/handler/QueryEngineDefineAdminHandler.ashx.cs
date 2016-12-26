using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// QueryEngineDefineAdminHandler 的摘要说明
    /// </summary>
    public class QueryEngineDefineAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetEngineDefinePageDTByEngineIds":
                    GetEngineDefinePageDTByEngineIds(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key")))));
                    break;
                case "Delete":
                    Delete(context);
                    break;
                case "GetDataBaseLink":
                    GetDataBaseLink(context);
                    break;
                case "GetDynamicJsonByQueryEngineDefineId":
                    GetDynamicJsonByQueryEngineDefineId(context);
                    break;
                case "SubmitForm":
                    SubmitForm(context);
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

        private void Delete(HttpContext context)
        {
            var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
            try
            {
                var vReturnValue = RDIFrameworkService.Instance.QueryEngineService.SetDeletedQueryEngineDefine(Utils.UserInfo, new string[] { key });
                context.Response.Write(vReturnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG0013 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 得到数据库连接定义
        /// </summary>
        private void GetDataBaseLink(HttpContext context)
        {
            List<CiDbLinkDefineEntity> listDbLink = RDIFrameworkService.Instance.DbLinkDefineService.GetList(Utils.UserInfo);
            var result = listDbLink.Where(p => p.Enabled == 1).OrderByDescending(p => p.SortCode).ToList();
            context.Response.Write(JsonHelper.ObjectToJSON(result));
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

        private void SubmitForm(HttpContext context)
        {
            try
            {
                int IsOk = 1;
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                string Message = key == "" ? "新增成功。" : "修改成功。";
                RDIFramework.Utilities.UserInfo curUser = Utils.UserInfo;
                QueryEngineDefineEntity entity = JsonHelper.JSONToObject<QueryEngineDefineEntity>(json);
                if (string.IsNullOrEmpty(key))
                {
                    //增加             
                    entity.CreateBy = curUser.RealName;
                    entity.CreateUserId = curUser.Id;
                    string statusCode, statusMessage, returnKey;
                    returnKey = RDIFrameworkService.Instance.QueryEngineService.AddQueryEngineDefine(curUser, entity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == RDIFramework.Utilities.StatusCode.OKAdd.ToString()
                        ? new JsonMessage { Success = true, Data = returnKey, Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
                else
                {
                    var updateEntity = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineEntity(curUser, key);
                    if (updateEntity != null)
                    {
                        updateEntity.QueryEngineId = entity.QueryEngineId;
                        updateEntity.Code = entity.Code;
                        updateEntity.FullName = entity.FullName;
                        updateEntity.DataBaseLinkName = entity.DataBaseLinkName;
                        updateEntity.DataSourceType = entity.DataSourceType;
                        updateEntity.DataSourceName = entity.DataSourceName;
                        updateEntity.QueryStringKey = entity.QueryStringKey;
                        updateEntity.QueryString = entity.QueryString;
                        updateEntity.SelectedField = entity.SelectedField;
                        updateEntity.OrderByField = entity.OrderByField;
                        updateEntity.Enabled = entity.Enabled;
                        updateEntity.AllowEdit = entity.AllowEdit;
                        updateEntity.AllowDelete = entity.AllowDelete;
                        updateEntity.Description = entity.Description;
                    }

                    if (curUser != null)
                    {
                        updateEntity.ModifiedBy = curUser.RealName;
                        updateEntity.ModifiedUserId = curUser.Id;
                    }
                    string statusCode;
                    string statusMessage;
                    RDIFrameworkService.Instance.QueryEngineService.UpdateQueryEngineDefine(curUser, updateEntity, out statusCode, out statusMessage);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}