using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.WorkFlow.handler
{
    using RDIFramework.WebCommon;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// DailyBizAdminHandler 的摘要说明
    /// </summary>
    public class DailyBizAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetAvailableBizClass":
                    GetAvailableBizClass(context);
                    break;
                case "GetWorkFlowByClassId":
                    GetWorkFlowByClassId(context);
                    break;
            }
        }

        #region GetAvailableBizClass 相关方法
        private bool FatherExist(DataTable dt, string key)
        {
            var filter = "WFCLASSID='" + key + "'";
            var dv = new DataView(dt) { RowFilter = filter };
            return dv.Count > 0;
        }

        StringBuilder result = new StringBuilder();  
        private void GetAvailableBizClass(HttpContext ctx)
        {
            try
            {
                result.Append("[");
                result.Append("{\"id\":\"#\",\"text\":\"日常业务\",\"iconCls\":\"icon16_table_format\",\"attributes\":{ \"url\": \"#\"},\"state\":\"open\"");
                result.Append(",\"children\":[");
                UserInfo vCurrentUser = Utils.UserInfo;
                var dtAvailableBizClass =RDIFrameworkService.Instance.WorkFlowTemplateService.GetAllowStartWorkFlows(vCurrentUser,vCurrentUser.Id);
                if (dtAvailableBizClass != null && dtAvailableBizClass.Rows.Count > 0)
                {
                    var cllevel = "";
                    //Utils.CheckTreeParentId(dtAvailableBizClass, WorkFlowClassTable.FieldWFClassId, WorkFlowClassTable.FieldFatherId);
                    foreach (DataRow dr in dtAvailableBizClass.Rows)
                    {
                        var nowcllevel = dr["CLLEVEL"].ToString();
                        if (nowcllevel == cllevel) continue;
                        var clfathid = dr["FATHERID"].ToString();
                        if (FatherExist(dtAvailableBizClass, clfathid)) continue;
                        LoadWorkflowClass(dtAvailableBizClass, nowcllevel);
                        cllevel = nowcllevel;
                    }
                    result = result.Remove(result.Length - 1, 1);
                    //result.Append("}");
                }

                result.Append("]}]");
                ctx.Response.Write(result);
            }
            catch(Exception ex)
            {
                result.Clear();
                result.Append("[{\"id\":\"#\",\"text\":\"加载业务出错...\",\"iconCls\":\"icon16_table_format\",\"attributes\":{ \"url\": \"#\"},\"state\":\"open\"}]");
                ctx.Response.Write(result);
            }
        }

        /// <summary>
        /// 递归装载流程分类
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key"></param>
        public void LoadWorkflowClass(DataTable dt, string key)
        {
            try
            {
                var filter = "CLLEVEL='" + key + "'";
                var dv = new DataView(dt) { RowFilter = filter };
                var tmpClassId = "###";
                foreach (DataRowView row in dv)
                {
                    var nowClassId = row["WFCLASSID"].ToString();
                    if (tmpClassId == nowClassId) continue;//避免重复添加
                    tmpClassId = nowClassId;
                    result.AppendFormat("{{\"id\":\"{0}\",\"text\":\"{1}\",\"iconCls\":\"icon16_page_white_text\",\"attributes\":{{\"url\":\"{2}\"}},\"state\":\"open\"", tmpClassId, row["Caption"], row["clmgrurl"]);
                    LoadChildClass(dt, tmpClassId);//递归加载子分类
                    result.Append("},");
                }
                //if (dv.Count > 0 && result.Length > 0)
                //{
                //    result = result.Remove(result.Length - 1, 1);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("LoadWorkflowClass函数," + ex.Message);
            }
        }

        public void LoadChildClass(DataTable dt, string key)
        {
            try
            {
                var filter = "FATHERID='" + key + "'";
                var tmpClassId = "###";
                var dv = new DataView(dt) { RowFilter = filter };
                if (dv.Count > 0)
                {
                    result.Append(",\"children\":[");
                }
                foreach (DataRowView row in dv)
                {
                    var nowClassId = row["WFCLASSID"].ToString();
                    if (tmpClassId == nowClassId) continue;//避免重复添加
                    tmpClassId = nowClassId;
                    result.AppendFormat("{{\"id\":\"{0}\",\"text\":\"{1}\",\"iconCls\":\"icon16_page_white_text\",\"attributes\":{{\"url\":\"{2}\"}},\"state\":\"open\"", row["WFCLASSID"], row["Caption"], row["clmgrurl"]);
                    LoadChildClass(dt, row["WFCLASSID"].ToString());
                    result.Append("},");
                }
                if (dv.Count > 0 && result.Length > 0)
                {
                    result = result.Remove(result.Length - 1, 1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadChildClass函数," + ex.Message);
            }
        }
        #endregion

        public void GetWorkFlowByClassId(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var classId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("classId"));
            var writeJson = "[]";
            if (!string.IsNullOrEmpty(classId))
            {
                var dtAvailableBizClass =RDIFrameworkService.Instance.WorkFlowTemplateService.GetAllowStartWorkFlows(vUser, vUser.Id);
                var filter = "WFCLASSID='" + classId + "'";
                var resultDataTable = new DataView(dtAvailableBizClass) {RowFilter = filter}.ToTable();
                if (resultDataTable.Rows.Count > 0)
                {
                    writeJson = JSONhelper.ToJson(resultDataTable);
                }
                ctx.Response.Write(writeJson);
            }
            else
            {
                ctx.Response.Write(writeJson);
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