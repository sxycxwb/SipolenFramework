using System;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json.Linq;

namespace RDIFramework.WebApp.demo.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// ProductIn 的摘要说明
    /// </summary>
    public class ProductIn : IHttpHandler, IRequiresSessionState
    {
        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        private object getObj(string key) { return RDIFramework.WebCommon.StringHelper.GetRequestObject(key); }

        public CommonJsonModel DeSerialize(string json)
        {
            return new CommonJsonModel(json);
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var json = HttpContext.Current.Request["json"];

            string action = PublicMethod.GetString(getObj("action"));
            string jsonStr = string.Empty;
            string keyId = string.Empty;
            if (string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(json))
            {
                CommonJsonModel model = DeSerialize(json);
                action = model.GetValue("action");
                keyId = model.GetValue("id");
                jsonStr = model.GetModel("jsonEntity").Rawjson;
               // model = DeSerialize(json1);
            }

            switch (action)
            {        
                case "GetProductMainEntity":
                    this.GetProductMainEntity(context);
                    break;
                case "add":
                    this.AddProductInfo(context, jsonStr);
                    break;
                case "edit":
                    this.EditProductInfo(context, jsonStr,keyId);
                    break;
                case "delete":
                    this.DelProductInfo(context);
                    break;
                case "mx":
                    context.Response.Write(GetMxJson());
                    break;
                case "GetMultiPage": //多表联合查询分页
                    var jsonData1 = GetProductMultiPage(context);
                    context.Response.Write(jsonData1);
                    break;
                default:
                    var jsonData = GetProductInMainJson(context);
                    context.Response.Write(jsonData);
                    break;
            }
        }

        private void GetProductMainEntity(HttpContext ctx)
        {
            var returnJson = "[]";
            var vId = PublicMethod.GetString(getObj("keyid"));
            var manager = new CASE_PRODUCTIN_MAINManager(this.dbHelper);
            var entity = manager.GetEntity(vId);
            if (entity != null)
            {
                returnJson = JSONhelper.ToJson(entity);
            }
            ctx.Response.Write(returnJson);
        }

        IDbProvider dbHelper
        {
            get
            {
                /* //暂时取消方便演示
               var dbDefine = RDIFrameworkService.Instance.DbLinkDefineService.GetEntityByLinkName(Utils.UserInfo, "RDIFrameworkDBLink");
               return dbDefine != null ? DbFactoryProvider.GetProvider((CurrentDbType)Enum.Parse(typeof(CurrentDbType), dbDefine.LinkType, true), SecretHelper.AESDecrypt(dbDefine.LinkData))
                                       : DbFactoryProvider.GetProvider(SystemInfo.BusinessDbType, SystemInfo.BusinessDbConnectionString);
                */
                return DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString);
            }
        }

        private string GetMxJson()
        {
            var returnJson = "[]";
            var vId = PublicMethod.GetString(getObj("keyid"));
            var sql = "SELECT * FROM CASE_PRODUCTIN_DETAIL WHERE CASE_PRODUCTIN_MAIN_ID = '"+ vId + "'";


            //得到指定DB数据访问类
            //string[] fieldName = { CiDbLinkDefineTable.FieldLinkName };
            //string[] fieldValue = { "你定义的DB连接名称" };
            //CiDbLinkDefineEntity DbDefine = new CiDbLinkDefineEntity(RDIFrameworkService.Instance.DbLinkDefineService.GetDTByValues(Utils.UserInfo, fieldName, fieldValue));
            //IDbProvider DBHelper = DbFactoryProvider.GetProvider(CurrentDbType.SqlServer, RDIFramework.Utilities.SecretHelper.AESDecrypt(DbDefine.LinkData));
            //
            var dtProductInDetail = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(Utils.UserInfo, sql);
            if (dtProductInDetail != null && dtProductInDetail.Rows.Count > 0)
            {
                returnJson = JSONhelper.ToJson(dtProductInDetail);
            }

            return returnJson;
        }

        private string GetProductMultiPage(HttpContext context)
        {
            var returnJson = "[]";
            var managerMain = new CASE_PRODUCTIN_MAINManager(this.dbHelper, Utils.UserInfo);
            var pageParam = new PageParam(context);
            int recordCount;
            managerMain.CurrentTableName = @"(SELECT tab1.ID,tab1.CODE,tab1.INDATE,tab1.INTYPE,tab1.CUSTODIAN,tab1.CREATEON,tab2.FULLNAME,tab2.AMOUNT,tab2.UNITPRICE 
                                                FROM CASE_PRODUCTIN_MAIN tab1 
                                                INNER JOIN CASE_PRODUCTIN_DETAIL tab2
                                                ON tab1.ID = tab2.CASE_PRODUCTIN_MAIN_ID) pageData";

            managerMain.SelectField = "*";
            var dtProductIn = managerMain.GetDTByPage(out recordCount, pageParam.PageIndex, pageParam.PageSize, null, "CREATEON DESC");
            if (dtProductIn != null && dtProductIn.Rows.Count > 0)
            {
                returnJson = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtProductIn);
            }

            return returnJson;
        }

        private string GetProductInMainJson(HttpContext context)
        {
            var returnJson = "[]";
            var managerMain = new CASE_PRODUCTIN_MAINManager(this.dbHelper, Utils.UserInfo);

            var where = "DELETEMARK = 0";
            var pageParam = new PageParam(context);
            if (!string.IsNullOrEmpty(pageParam.Filter))
            {
                where = pageParam.Filter;
            }
            int recordCount;
            var dtProductIn = managerMain.GetDTByPage(out recordCount, pageParam.PageIndex, pageParam.PageSize, where, pageParam.SortField + " " + pageParam.Order); //RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(Utils.UserInfo, sql);
            
            if (dtProductIn != null && dtProductIn.Rows.Count > 0)
            {
                returnJson = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount,dtProductIn);
            }

            return returnJson;
        }

        private void AddProductInfo(HttpContext ctx,string jsonStr)
        {
            var jobj = JObject.Parse(jsonStr.Replace("\\", ""));
            if (jobj == null)
            {
                ctx.Response.Write("-1");
                return;
            }
            string reutrnId = string.Empty;
            var vUser = Utils.UserInfo;
            var entityMain = new CASE_PRODUCTIN_MAINEntity
            {
                CODE = PublicMethod.GetString(jobj["CODE"]),
                INDATE = PublicMethod.GetDateTime(jobj["INDATE"]),
                INTYPE = PublicMethod.GetString(jobj["INTYPE"]),
                DEPOT = PublicMethod.GetString(jobj["DEPOT"]),
                CUSTODIAN = PublicMethod.GetString(jobj["CUSTODIAN"]),
                SUPPLIERNAME = PublicMethod.GetString(jobj["SUPPLIERNAME"]),
                CREATEBY = PublicMethod.GetString(jobj["CREATEBY"]) == "" ? vUser.UserName : PublicMethod.GetString(jobj["CREATEBY"]),
                CREATEUSERID = vUser.Id,
                CREATEON = PublicMethod.GetDateTime(jobj["CREATEON"]) ?? DateTime.Now,
                DESCRIPTION = PublicMethod.GetString(jobj["DESCRIPTION"])
            };
            var managerMain = new CASE_PRODUCTIN_MAINManager(this.dbHelper,vUser);
            
            reutrnId = managerMain.AddEntity(entityMain);
            if (!string.IsNullOrEmpty(reutrnId))
            {
                var products = jobj["products"];
                var subdatas = products.Select(data => new
                {
                    FullName = data["FULLNAME"],
                    UnitPrice = data["UNITPRICE"],
                    State = data["STATE"],
                    CategoryName = data["categoryName"],
                    Category = data["CATEGORY"]
                });

                foreach (var data in subdatas)
                {
                    var entityDetail = new CASE_PRODUCTIN_DETAILEntity
                    {
                        CASE_PRODUCTIN_MAIN_ID = reutrnId,
                        FULLNAME = PublicMethod.GetString(data.FullName),
                        UNITPRICE = BusinessLogic.ConvertToNullableDecimal(data.UnitPrice),
                        STATE = PublicMethod.GetString(data.State),
                        CATEGORY = PublicMethod.GetString(data.Category),
                    };

                    var managerDetail = new CASE_PRODUCTIN_DETAILManager(this.dbHelper, vUser);
                    managerDetail.AddEntity(entityDetail);
                }
                ctx.Response.Write("1");
            }
            else
            {
                ctx.Response.Write("0");
            }
        }

        private void EditProductInfo(HttpContext ctx, string jsonStr,string keyId)
        {
            var jobj = JObject.Parse(jsonStr.Replace("\\", ""));
            if (jobj == null)
            {
                ctx.Response.Write("-1");
                return;
            }
            var reutrnId = 0;
            var vUser = Utils.UserInfo;
            var managerMain = new CASE_PRODUCTIN_MAINManager(this.dbHelper, vUser);
            var entityMain = managerMain.GetEntity(keyId);
            if (entityMain == null)
            {
                ctx.Response.Write("-1");
                return;
            }

            entityMain.CODE = PublicMethod.GetString(jobj["CODE"]);
            entityMain.INDATE = PublicMethod.GetDateTime(jobj["INDATE"]);
            entityMain.INTYPE = PublicMethod.GetString(jobj["INTYPE"]);
            entityMain.DEPOT = PublicMethod.GetString(jobj["DEPOT"]);
            entityMain.CUSTODIAN = PublicMethod.GetString(jobj["CUSTODIAN"]);
            entityMain.SUPPLIERNAME = PublicMethod.GetString(jobj["SUPPLIERNAME"]);
            entityMain.DESCRIPTION = PublicMethod.GetString(jobj["DESCRIPTION"]);
            reutrnId = managerMain.UpdateEntity(entityMain);
            if (reutrnId > 0)
            {
                var products = jobj["products"];
                var subdatas = products.Select(data => new
                {
                    Id = data["ID"],
                    ReferId = data["CASE_PRODUCTIN_MAIN_ID"],
                    FullName = data["FULLNAME"],
                    UnitPrice = data["UNITPRICE"],
                    State = data["STATE"],
                    CategoryName = data["categoryName"],
                    Category = data["CATEGORY"]
                });
                var managerDetail = new CASE_PRODUCTIN_DETAILManager(this.dbHelper, vUser);
                foreach (var data in subdatas)
                {
                    //TODO:情形一、新增的产品明细
                    if (string.IsNullOrEmpty(PublicMethod.GetString(data.Id))) 
                    {
                        //增加
                        var entity = new CASE_PRODUCTIN_DETAILEntity
                        {
                            CASE_PRODUCTIN_MAIN_ID = entityMain.ID,
                            FULLNAME = PublicMethod.GetString(data.FullName),
                            UNITPRICE = BusinessLogic.ConvertToNullableDecimal(data.UnitPrice),
                            STATE = PublicMethod.GetString(data.State),
                            CATEGORY = PublicMethod.GetString(data.Category),
                        };
                        managerDetail.AddEntity(entity);
                    }

                    //TODO:情形二、删除的产品明细、暂不处理....

                    //TODO:情形三、实行修改操作
                    var entityDetail = managerDetail.GetEntity(PublicMethod.GetString(data.Id));
                    if (entityDetail == null)
                    {
                        continue;
                    }
                    entityDetail.FULLNAME = PublicMethod.GetString(data.FullName);
                    entityDetail.UNITPRICE = BusinessLogic.ConvertToNullableDecimal(data.UnitPrice);
                    entityDetail.STATE = PublicMethod.GetString(data.State);
                    entityDetail.CATEGORY = PublicMethod.GetString(data.Category);
                    managerDetail.UpdateEntity(entityDetail);
                }
                ctx.Response.Write("1");
            }
            else
            {
                ctx.Response.Write("0");
            }
        }

        private void DelProductInfo(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(getObj("keyid"));
            var managerMain = new CASE_PRODUCTIN_MAINManager(this.dbHelper, vUser);
            var managerDetail = new CASE_PRODUCTIN_DETAILManager(this.dbHelper, vUser);
            var returnValue = managerMain.SetDeleted(vId);
            string[] names = {CASE_PRODUCTIN_DETAILTable.FieldCASE_PRODUCTIN_MAIN_ID,CASE_PRODUCTIN_DETAILTable.FieldDELETEMARK};
            object[] values = {vId, 0};
            var ids = managerDetail.GetIds(names, values, CASE_PRODUCTIN_DETAILTable.FieldID);
            managerDetail.SetDeleted(ids as object[]);
            ctx.Response.Write(returnValue > 0 ? "1" : "0");
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