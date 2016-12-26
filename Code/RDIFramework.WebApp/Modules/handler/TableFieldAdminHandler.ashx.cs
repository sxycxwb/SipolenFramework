using System;
using System.Web.SessionState;
using System.Web;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// TableFieldAdminHandler 的摘要说明
    /// </summary>
    public class TableFieldAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetTableNameAndCode":
                    GetTableNameAndCode(context);
                    break;
                case "GetTableNameAndCodeForPermission":
                    GetTableNameAndCodeForPermission(context);
                    break;
                case "GetTablePermissionScopeList":
                    GetTablePermissionScopeList(context);
                    break;
                case "AddTablePermissionScope":
                    AddTablePermissionScope(context);
                    break;
                case "DeleteTablePermissionScope":
                    DeleteTablePermissionScope(context);
                    break;
                case "GetDTByTable":
                    GetDTByTable(context);
                    break;
                case "GetDTForEditByTable":
                    GetDTForEditByTable(context);
                    break;
                case "TableFieldBatchSet":
                    TableFieldBatchSet(context);
                    break;
            }
        }

        private void GetTableNameAndCode(HttpContext ctx)
        {
            var dtTableList = RDIFrameworkService.Instance.TableColumnsService.GetTableNameAndCode(Utils.UserInfo);
            ctx.Response.Write(JSONhelper.ToJson(dtTableList));
        }

        private void GetTableNameAndCodeForPermission(HttpContext ctx)
        {
            var dtTableListLeft = RDIFrameworkService.Instance.TableColumnsService.GetTableNameAndCode(Utils.UserInfo);
            var dtTableListRight = RDIFrameworkService.Instance.TableColumnsService.GetTablePermissionScope(Utils.UserInfo);
            //根据右表数据清除左表已有的数据列表（让其不要重复选择）。
            if (dtTableListRight != null && dtTableListRight.Rows.Count > 0)
            {
                for (var index = 0; index < dtTableListRight.Rows.Count; index++)
                {
                    var dataRows = dtTableListLeft.Select(CiTableColumnsTable.FieldTableCode + "='" + dtTableListRight.Rows[index][PiTablePermissionScopeTable.FieldItemCode].ToString().Trim() + "'");
                    if (dataRows.Length > 0)
                    {
                        foreach (var dataRow in dataRows)
                        {
                            dtTableListLeft.Rows.Remove(dataRow);
                        }
                        dtTableListLeft.AcceptChanges();
                    }
                }
            }
            var jsonStr = "[]";
            if (dtTableListRight != null)
            {
                jsonStr = JSONhelper.ToJson(dtTableListLeft);
            }
            ctx.Response.Write(jsonStr);
        }

        private void GetTablePermissionScopeList(HttpContext ctx)
        {
            var dtTableListRight = RDIFrameworkService.Instance.TableColumnsService.GetTablePermissionScope(Utils.UserInfo);
            var jsonStr = "[]";
            if (dtTableListRight != null)
            {
                jsonStr = JSONhelper.ToJson(dtTableListRight);
            }
            ctx.Response.Write(jsonStr);
        }

        private void AddTablePermissionScope(HttpContext ctx)
        {
            var tableName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableName"));
            //var itemName = tableName.Substring(tableName.IndexOf('［') + 1, tableName.Length - tableName.IndexOf('［') - 2);
            //var itemValue = tableName.Substring(0, tableName.IndexOf('［'));
            var itemName = tableName;
            var itemValue = tableName;
            var entity = new PiTablePermissionScopeEntity
            {
                ItemCode = itemValue,
                ItemName = itemName,
                Enabled = 1,
                DeleteMark = 0
            };
            entity.ItemValue = entity.ItemCode;
            string statusCode;
            string statusMessage;
            RDIFrameworkService.Instance.TableColumnsService.AddTablePermissionScope(Utils.UserInfo, entity, out statusCode, out statusMessage);
            ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString() ? "1" : "0");
        }

        private void DeleteTablePermissionScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var itemvalue = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("itemvalue"));
            var returnValue = RDIFrameworkService.Instance.TableColumnsService.SetTablePermissionScopeDeleted(vUser,
                                 new string[] { RDIFrameworkService.Instance.TableColumnsService.GetTablePermissionScopeEntity(vUser, PiTablePermissionScopeTable.FieldItemValue, itemvalue).Id.ToString() });
            ctx.Response.Write(returnValue > 0 ? "1" : "0");
        }

        private void GetDTByTable(HttpContext ctx)
        {
            var tableCode = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableCode"));
            var dtTableColumns = RDIFrameworkService.Instance.TableColumnsService.GetDTByTable(Utils.UserInfo, tableCode);
            ctx.Response.Write(JSONhelper.ToJson(dtTableColumns));
        }

        private void GetDTForEditByTable(HttpContext ctx)
        {
            var tableCode = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableCode"));
            var jsonValue = "[]";
            var dtTableColumns = RDIFrameworkService.Instance.TableColumnsService.GetDTByTable(Utils.UserInfo, tableCode);
            if (dtTableColumns != null && dtTableColumns.Rows.Count > 0)
            {
                jsonValue = JSONhelper.ToJson(dtTableColumns);
                jsonValue = jsonValue.Replace(".0","").Replace("\"ISPUBLIC\":1", "\"ISPUBLIC\":\"√\"").Replace("\"ISPUBLIC\":0", "\"ISPUBLIC\":\"x\"");
                jsonValue = jsonValue.Replace("\"COLUMNACCESS\":1", "\"COLUMNACCESS\":\"√\"").Replace("\"COLUMNACCESS\":0", "\"COLUMNACCESS\":\"x\"");
                jsonValue = jsonValue.Replace("\"COLUMNEDIT\":1", "\"COLUMNEDIT\":\"√\"").Replace("\"COLUMNEDIT\":0", "\"COLUMNEDIT\":\"x\"");
                jsonValue = jsonValue.Replace("\"COLUMNDENEY\":1", "\"COLUMNDENEY\":\"√\"").Replace("\"COLUMNDENEY\":0", "\"COLUMNDENEY\":\"x\"");
                jsonValue = jsonValue.Replace("\"USECONSTRAINT\":1", "\"USECONSTRAINT\":\"√\"").Replace("\"USECONSTRAINT\":0", "\"USECONSTRAINT\":\"x\"");
                jsonValue = jsonValue.Replace("\"ISSEARCHCOLUMN\":1", "\"ISSEARCHCOLUMN\":\"√\"").Replace("\"ISSEARCHCOLUMN\":0", "\"ISSEARCHCOLUMN\":\"x\"");
                jsonValue = jsonValue.Replace("\"ISEXHIBITCOLUMN\":1", "\"ISEXHIBITCOLUMN\":\"√\"").Replace("\"ISEXHIBITCOLUMN\":0", "\"ISEXHIBITCOLUMN\":\"x\"");
                jsonValue = jsonValue.Replace("\"ALLOWEDIT\":1", "\"ALLOWEDIT\":\"√\"").Replace("\"ALLOWEDIT\":0", "\"ALLOWEDIT\":\"x\"");
                jsonValue = jsonValue.Replace("\"ALLOWDELETE\":1", "\"ALLOWDELETE\":\"√\"").Replace("\"ALLOWDELETE\":0", "\"ALLOWDELETE\":\"x\"");
                jsonValue = jsonValue.Replace("\"ENABLED\":1", "\"ENABLED\":\"√\"").Replace("\"ENABLED\":0", "\"ENABLED\":\"x\"");
            }
          
            ctx.Response.Write(jsonValue);
        }

        private void TableFieldBatchSet(HttpContext ctx)
        {
            var jsonData = PublicMethod.GetString(ctx.Request["data"]);
            
            if (string.IsNullOrEmpty(jsonData))
            {
                ctx.Response.Write("-1");
                return;
            }

            var jobj = JObject.Parse(jsonData);
            //var tableCode = jobj["TableCode"];
            var datas = jobj["data"];
            var subdatas = datas.Select(data => new
            {
                KeyId = data["keyId"],
                subdata = data["subdata"],
            });
            var vUser = Utils.UserInfo;
            var returnValue = 0;
            foreach (var sdata in subdatas)
            {
                try
                {
                    var id = sdata.KeyId.ToString();
                    var entity = RDIFrameworkService.Instance.TableColumnsService.GetEntity(vUser, id);
                    if (entity == null)
                    {
                        continue;
                    }
                    //"ISPUBLIC","COLUMNACCESS","COLUMNEDIT","COLUMNDENEY","USECONSTRAINT","ISSEARCHCOLUMN","ISEXHIBITCOLUMN","ENABLED","ALLOWEDIT","ALLOWDELETE"
                    entity.IsPublic = sdata.subdata.ToArray().Contains("ISPUBLIC") ? 1 : 0;
                    entity.ColumnAccess = sdata.subdata.ToArray().Contains("COLUMNACCESS") ? 1 : 0;
                    entity.ColumnEdit = sdata.subdata.ToArray().Contains("COLUMNEDIT") ? 1 : 0;
                    entity.ColumnDeney = sdata.subdata.ToArray().Contains("COLUMNDENEY") ? 1 : 0;
                    entity.UseConstraint = sdata.subdata.ToArray().Contains("USECONSTRAINT") ? 1 : 0;
                    entity.IsSearchColumn = sdata.subdata.ToArray().Contains("ISSEARCHCOLUMN") ? 1 : 0;
                    entity.IsExhibitColumn = sdata.subdata.ToArray().Contains("ISEXHIBITCOLUMN") ? 1 : 0;
                    entity.Enabled = sdata.subdata.ToArray().Contains("ENABLED") ? 1 : 0;
                    entity.AllowEdit = sdata.subdata.ToArray().Contains("ALLOWEDIT") ? 1 : 0;
                    entity.AllowDelete = sdata.subdata.ToArray().Contains("ALLOWDELETE") ? 1 : 0;
                    string statusCode;
                    string statusMessage;
                    returnValue += RDIFrameworkService.Instance.TableColumnsService.Update(vUser, entity, out statusCode,out statusMessage);
                }
                catch(Exception ex)
                {
                    continue;
                }
            }

            ctx.Response.Write(returnValue);
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