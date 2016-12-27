using System;
using System.Web.SessionState;
using System.Web;

namespace RDIFramework.WebApp.demo.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;
    using RDIFramework.Utilities;

    /// <summary>
    /// CaseProductInfo.ashx
    /// 产品管理一般处理程序
    /// 
    /// 修改纪录
    ///     2016-03-08 版本：3.0 XuWangBin 全面重构代码，精简60%的代码量。
    ///     2015-12-18 版本：1.0 创建。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    /// <name></name>
    /// <date>2015-12-18</date>
    /// </author>
    /// </summary>
    public class CaseProductInfo : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "SubmitForm":
                    SubmitForm(context);
                    break;
                case "GetEntity":
                    this.GetEntity(context);
                    break;                
                case "Delete":
                    this.Delete(context);
                    break;       
                default:
                    GetPageData(context);      
                    break;
            }
        }

        IDbProvider dbProvider
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

        private void GetPageData(HttpContext context)
        {
            var pageParam = new PageParam(context);
            var manager = new CASE_PRODUCTINFOManager(this.dbProvider);
            int recordCount = 0;
            string sort = pageParam.SortField;
            string order = pageParam.Order;
            if (string.IsNullOrEmpty(sort))
            {
                sort = CASE_PRODUCTINFOTable.FieldCREATEON;
            }
            
            if (string.IsNullOrEmpty(order))
            {
                order = "DESC";
            }

            string filter = pageParam.Filter;
            if (string.IsNullOrEmpty(filter))
            {
                filter = CASE_PRODUCTINFOTable.FieldDELETEMARK + " = 0 ";
            }
            UserInfo cUser = Utils.UserInfo;
            //string userConstraintExpress = RDIFrameworkService.Instance.TableColumnsService.GetConstraint(cUser, PiUserTable.TableName, cUser.Id, CASE_PRODUCTINFOTable.TableName); //按表约束条件获得数据（按当前用户）。
            string userConstraintExpress = RDIFrameworkService.Instance.TableColumnsService.GetUserConstraint(cUser, CASE_PRODUCTINFOTable.TableName); //按表约束条件获得数据(得到用户与角色的约束条件)。

            if (!string.IsNullOrEmpty(userConstraintExpress))
            {
                filter += " AND " + userConstraintExpress;
            }
            
            var dtTemp = manager.GetDTByPage(out recordCount, pageParam.PageIndex, pageParam.PageSize, filter, (sort + " " + order));
            context.Response.Write(JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtTemp));
        }

        private void GetEntity(HttpContext context)
        {
            var manager = new CASE_PRODUCTINFOManager(this.dbProvider, Utils.UserInfo);
            string keyId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
            var entity = manager.GetEntity(keyId);
            context.Response.Write(JSONhelper.ToJson(entity));
        }

        private void SubmitForm(HttpContext context)
        {
            try
            {
                string returnValue = string.Empty;
                string msg = RDIFrameworkMessage.MSG3020;
                var isSuccess = false;
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                UserInfo curUser = Utils.UserInfo;
                var entity = JsonHelper.JSONToObject<CASE_PRODUCTINFOEntity>(json);
                if (string.IsNullOrEmpty(key))  //增加   
                {
                    var manager = new CASE_PRODUCTINFOManager(this.dbProvider, curUser);
                    returnValue = manager.Add(entity);
                    if (!string.IsNullOrEmpty(returnValue))
                    {
                        msg = RDIFrameworkMessage.MSG0009;
                        isSuccess = true;
                    }

                    context.Response.Write(new JsonMessage { Success = isSuccess, Data = returnValue, Message = msg }.ToString());
                }
                else
                {
                    var manager = new CASE_PRODUCTINFOManager(this.dbProvider, curUser);
                    var updateEntity = manager.GetEntity(key);
                    if (updateEntity != null)
                    {
                        updateEntity.PRODUCTCODE = entity.PRODUCTCODE;
                        updateEntity.PRODUCTNAME = entity.PRODUCTNAME;
                        updateEntity.PRODUCTMODEL = entity.PRODUCTMODEL;
                        updateEntity.PRODUCTSTANDARD = entity.PRODUCTSTANDARD;
                        updateEntity.PRODUCTCATEGORY = entity.PRODUCTCATEGORY;
                        updateEntity.PRODUCTUNIT = entity.PRODUCTUNIT;
                        updateEntity.MIDDLERATE = entity.MIDDLERATE;
                        updateEntity.REFERENCECOEFFICIENT = entity.REFERENCECOEFFICIENT;
                        updateEntity.PRODUCTPRICE = entity.PRODUCTPRICE;
                        updateEntity.WHOLESALEPRICE = entity.WHOLESALEPRICE;
                        updateEntity.PROMOTIONPRICE = entity.PROMOTIONPRICE;
                        updateEntity.INTERNALPRICE = entity.INTERNALPRICE;
                        updateEntity.SPECIALPRICE = entity.SPECIALPRICE;
                        updateEntity.ENABLED = entity.ENABLED;
                        updateEntity.PRODUCTDESCRIPTION = entity.PRODUCTDESCRIPTION;
                    }

                    int value = manager.Update(updateEntity);
                    if (value > 0)
                    {
                        msg = RDIFrameworkMessage.MSG0010;
                        isSuccess = true;
                        returnValue = value.ToString();
                    }
                    context.Response.Write(new JsonMessage { Success = isSuccess ,Data = returnValue, Message = msg}.ToString());
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        private void Delete(HttpContext context)
        {
            string returnValue = string.Empty;
            string msg = RDIFrameworkMessage.MSG3020;
            var isSuccess = false;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
            if (!string.IsNullOrEmpty(vId))
            {
                var manager = new CASE_PRODUCTINFOManager(this.dbProvider, Utils.UserInfo);
                int returnData = manager.SetDeleted(vId);
                if (returnData > 0)
                {
                    msg = RDIFrameworkMessage.MSG0013;
                    isSuccess = true;
                    returnValue = returnData.ToString();
                }
            }
            context.Response.Write(new JsonMessage { Success = isSuccess, Data = returnValue, Message = msg }.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //以下为测试代码：一个可以兼容各种数据库事务的使用范例

        //1、传入实体执行执行事务测试
        private bool InEntityTransactionTest(string mainId,string detailId)
        {
            //可以支持任意流行数据库类型，指定相关的数据库提供者即可（OracleProvider、SqlProvider、SqLiteProvider、MySqlProvider、DB2Provider、OleDbProvider）
            IDbProvider dbProvider = new OracleProvider(SystemInfo.BusinessDbConnectionString);
            bool result = true;
            try
            {
                dbProvider.BeginTransaction();
                //主表
                CASE_PRODUCTIN_MAINManager manager = new CASE_PRODUCTIN_MAINManager(dbProvider, Utils.UserInfo);
                CASE_PRODUCTIN_MAINEntity mainEntity = manager.GetEntity(dbProvider.SqlSafe(mainId));
                manager.Delete(mainEntity);
                //子表
                CASE_PRODUCTIN_DETAILManager detailManager = new CASE_PRODUCTIN_DETAILManager(dbProvider, Utils.UserInfo);
                CASE_PRODUCTIN_DETAILEntity detailEntity = detailManager.GetEntity(dbProvider.SqlSafe(detailId));
                detailManager.Delete(detailEntity);
                //事务提交　
                dbProvider.CommitTransaction();
            }
            catch (Exception ex)
            {
                //事务回滚
                dbProvider.RollbackTransaction();
                result = false;
            }
            return result;
        }

        //传入Sql语句事务测试
        private bool InSqlTransactionTest(string mainId, string detailId)
        {
            //可以支持任意流行数据库类型，指定相关的数据库提供者即可（OracleProvider、SqlProvider、SqLiteProvider、MySqlProvider、DB2Provider、OleDbProvider）

            IDbProvider dbProvider = new SqlProvider(SystemInfo.BusinessDbConnectionString);
            bool result = true;
            try
            {
                dbProvider.BeginTransaction();
                //主表
                string sqlMain = string.Format("DELETE FROM CASE_PRODUCTIN_MAIN WHERE ID = {0}", mainId);
                dbProvider.ExecuteNonQuery(sqlMain);
                //子表
                string sqlDetail = string.Format("DELETE FROM CASE_PRODUCTIN_DETAIL WHERE ID = {0}", detailId);
                dbProvider.ExecuteNonQuery(sqlMain);
                //事务提交　
                dbProvider.CommitTransaction();
            }
            catch (Exception ex)
            {
                //事务回滚
                dbProvider.RollbackTransaction();
                result = false;
            }
            return result;
        }

        //增加实体语句事务测试
        private bool InAddEntityTransactionTest()
        {
            //可以支持任意流行数据库类型，指定相关的数据库提供者即可（OracleProvider、SqlProvider、SqLiteProvider、MySqlProvider、DB2Provider、OleDbProvider）
            IDbProvider dbProvider = new SqlProvider(SystemInfo.RDIFrameworkDbConectionString);
            bool result = true;
            try
            {
                dbProvider.BeginTransaction();
                //主表
                CASE_PRODUCTIN_MAINManager manager = new CASE_PRODUCTIN_MAINManager(dbProvider, Utils.UserInfo);

                CASE_PRODUCTIN_MAINEntity mainEntity = new CASE_PRODUCTIN_MAINEntity
                {
                    ID = BusinessLogic.NewGuid(),
                    INDATE = BusinessLogic.ConvertToNullableDateTime(DateTime.Now),
                    SUPPLIERNAME = "Test"
                };
                string key = manager.AddEntity(mainEntity);
               
                //子表
                CASE_PRODUCTIN_DETAILManager detailManager = new CASE_PRODUCTIN_DETAILManager(dbProvider, Utils.UserInfo);
                CASE_PRODUCTIN_DETAILEntity detailEntity = new CASE_PRODUCTIN_DETAILEntity
                {
                    ID = BusinessLogic.NewGuid(),
                    CASE_PRODUCTIN_MAIN_ID = key
                };
                string key1 = detailManager.AddEntity(detailEntity);
                //事务提交　
                dbProvider.CommitTransaction();
            }
            catch (Exception ex)
            {
                //事务回滚
                dbProvider.RollbackTransaction();
                result = false;
            }
            return result;
        }
    }
}