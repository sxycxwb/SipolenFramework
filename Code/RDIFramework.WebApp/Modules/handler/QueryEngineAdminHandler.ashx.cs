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
    /// QueryEngineAdminHandler 的摘要说明
    /// </summary>
    public class QueryEngineAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetQueryEngineTreeJson":
                    GetQueryEngineTreeJson(context);
                    break;   
                case "GetQueryEngineByIds":
                    GetQueryEngineByIds(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key")))));
                    break;
                case "SubmitForm":
                    SubmitForm(context);
                    break;
                case "Delete":
                    Delete(context);
                    break;
            }
        }

        #region private void GetQueryEngineTreeJson(HttpContext context) 得到JsonTree数据
        private void GetQueryEngineTreeJson(HttpContext context)
        {
            string isTree = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("isTree"));
            var dtQueryEngine = new DataTable(QueryEngineTable.TableName);
            dtQueryEngine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDT(Utils.UserInfo);
            Utils.CheckTreeParentId(dtQueryEngine, QueryEngineTable.FieldId, QueryEngineTable.FieldParentId);
            var list = (from DataRow drow in dtQueryEngine.Rows select BaseEntity.Create<QueryEngineEntity>(drow)).ToList();
            string treeJosn = "[" + GroupJsondata(list, "#") + "]";
            if (!string.IsNullOrEmpty(isTree))
            {
                context.Response.Write(treeJosn.Replace("FullName", "text").Replace("Id", "id"));
            }
            else
            {
                context.Response.Write(treeJosn);
            }
        }

        private string GetJsonData(DataTable dtQueryEngine)
        {
            Utils.CheckTreeParentId(dtQueryEngine, QueryEngineTable.FieldId, QueryEngineTable.FieldParentId);
            var list = (from DataRow drow in dtQueryEngine.Rows select BaseEntity.Create<QueryEngineEntity>(drow)).ToList();
            return "[" + GroupJsondata(list, "#") + "]";
        }

        private int treeLevel = 0;
        private string GroupJsondata(List<QueryEngineEntity> groups, string parentId)
        {
            var sb = new StringBuilder();
            var list = groups.FindAll(gm => gm.ParentId == parentId);
            foreach (var gm in list)
            {
                treeLevel++;
                var json = RDIFramework.Utilities.JsonHelper.ObjectToJSON(gm);
                json = json.TrimEnd('}');
                sb.Append(json);
                sb.Append(",");
                if (treeLevel >= 2 && groups.FindAll(permissionItem => permissionItem.ParentId == gm.Id).Count > 0)
                {
                    sb.Append("\"state\":\"closed\",");
                }
                sb.Append("\"children\":[");
                if (gm.Id != null) sb.Append(GroupJsondata(groups, gm.Id));
                sb.Append("]},");
            }

            return sb.ToString().TrimEnd(',');
        }
        #endregion

        private void GetQueryEngineByIds(HttpContext context)
        {
            var queryEngineIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("queryEngineIds"));
            DataTable dtQueryEngine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDTByIds(Utils.UserInfo, queryEngineIds.Split(','));
            string treeData = GetJsonData(dtQueryEngine);
            context.Response.Write(treeData);
        }

        private void SubmitForm(HttpContext context)
        {
            try
            {
                int IsOk = 1;
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                UserInfo curUser = Utils.UserInfo;
                QueryEngineEntity entity = JsonHelper.JSONToObject<QueryEngineEntity>(json);
                if (string.IsNullOrEmpty(key))
                {
                    //增加       
                    entity.ParentId = entity.ParentId == "0" ? null : entity.ParentId;
                    entity.CreateBy = curUser.RealName;
                    entity.CreateUserId = curUser.Id;
                    string statusCode, statusMessage, returnKey;
                    returnKey = RDIFrameworkService.Instance.QueryEngineService.AddQueryEngine(curUser, entity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                        ? new JsonMessage { Success = true, Data = returnKey, Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
                else
                {
                    var updateEntity = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineEntity(curUser, key);
                    if (updateEntity != null)
                    {
                        updateEntity.Code = entity.Code;
                        updateEntity.FullName = entity.FullName;
                        updateEntity.ParentId = entity.ParentId == "0" ? null : entity.ParentId; ;
                        if (string.IsNullOrEmpty(updateEntity.ParentId))
                        {
                            updateEntity.ParentId = null;
                        }

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
                    RDIFrameworkService.Instance.QueryEngineService.UpdateQueryEngine(curUser, updateEntity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                        ? new JsonMessage { Success = true, Data = IsOk.ToString(), Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        private void Delete(HttpContext context)
        {
            try
            {
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                DataTable dtQueryEngineDefine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineDTByEngineId(Utils.UserInfo, key);
                if (dtQueryEngineDefine != null && dtQueryEngineDefine.Rows.Count > 0) //当前引擎上有定义则不能删除。
                {
                    context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG0225 }.ToString());
                }
                else
                {
                    var vReturnValue = RDIFrameworkService.Instance.QueryEngineService.SetDeletedQueryEngine(Utils.UserInfo, new string[] { key });
                    context.Response.Write(vReturnValue > 0
                        ? new JsonMessage { Success = true, Data = "1", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG0013 }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG3020 }.ToString());
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFramework.Utilities.RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
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