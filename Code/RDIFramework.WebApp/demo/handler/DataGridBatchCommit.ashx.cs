using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace RDIFramework.WebApp.demo.handler
{
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// DataGridBatchCommit 的摘要说明
    /// </summary>
    public class DataGridBatchCommit : IHttpHandler, IRequiresSessionState
    {
        private object getObj(string key) { return RDIFramework.WebCommon.StringHelper.GetRequestObject(key); }

        IDbProvider dbHelper
        {
            get
            {
                //var DbDefine = RDIFrameworkService.Instance.DbLinkDefineService.GetEntityByLinkName(Utils.UserInfo, "RDIFrameworkDBLink");
                //return DbDefine != null ? DbFactoryProvider.GetProvider((CurrentDbType)Enum.Parse(typeof(CurrentDbType), DbDefine.LinkType, true), SecretHelper.AESDecrypt(DbDefine.LinkData))
                //                        : DbFactoryProvider.GetProvider(SystemInfo.BusinessDbType, SystemInfo.BusinessDbConnectionString);

                return DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString);
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = PublicMethod.GetString(getObj("action"));
            switch (action)
            {
                case "GridListJson":
                    this.GridListJson(context);
                    break;
                case "SubmitForm":
                    SubmitForm(context);
                    break;
            }
        }

        private void GridListJson(HttpContext ctx)
        {
            var returnJson = "[]";
            var manager = new CASE_PRODUCTINFOManager(this.dbHelper, Utils.UserInfo);
            var dtTemp = manager.GetDT(20, CASE_PRODUCTINFOTable.FieldMODIFIEDON + " desc");

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                returnJson = JSONhelper.FormatJSONForEasyuiDataGrid(20, dtTemp);
            }

            ctx.Response.Write(returnJson);
        }

        private void SubmitForm(HttpContext ctx) 
        {
            try
            {
                string deleted = PublicMethod.GetString(getObj("deleted"));
                string inserted = PublicMethod.GetString(getObj("inserted"));
                string updated = PublicMethod.GetString(getObj("updated"));

                int returnInsertValue = 0;
                int returnUpdateValue = 0;
                int returnDeleteValue = 0;
                var manager = new CASE_PRODUCTINFOManager(this.dbHelper, Utils.UserInfo);
                if (deleted != null)
                {
                    //把json字符串转换成对象
                    List<CASE_PRODUCTINFOEntity> listDeleted = JsonDeserialize<List<CASE_PRODUCTINFOEntity>>(deleted);
                    if (listDeleted != null && listDeleted.Count > 0)
                    {
                        foreach (CASE_PRODUCTINFOEntity entity in listDeleted)
                        {
                            returnDeleteValue += manager.SetDeleted(entity.ID);
                        }
                    }
                }

                if (inserted != null)
                {
                    //把json字符串转换成对象
                    List<CASE_PRODUCTINFOEntity> listInserted = JsonDeserialize<List<CASE_PRODUCTINFOEntity>>(inserted);
                    if (listInserted != null && listInserted.Count > 0)
                    {
                        foreach (CASE_PRODUCTINFOEntity entity in listInserted)
                        {
                            returnInsertValue += string.IsNullOrEmpty(manager.Add(entity)) == true ? 0 : 1;
                        }
                    }
                }

                if (updated != null)
                {
                    //把json字符串转换成对象
                    List<CASE_PRODUCTINFOEntity> listUpdated = JsonDeserialize<List<CASE_PRODUCTINFOEntity>>(updated);
                    if (listUpdated != null && listUpdated.Count > 0)
                    {
                        foreach (CASE_PRODUCTINFOEntity entity in listUpdated)
                        {
                            returnUpdateValue += manager.UpdateEntity(entity);
                        }
                    }
                }
                string message = "操作提示： <br>增加:" + returnInsertValue.ToString() + "条。"
                                + " <br>修改:" + returnUpdateValue.ToString() + "条。"
                                + " <br>删除:" + returnDeleteValue.ToString() + "条。";
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = message }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        private T JsonDeserialize<T>(string jsonString)
        {           
            T obj = (T)JsonConvert.DeserializeObject(jsonString, typeof(T));
            return obj;
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