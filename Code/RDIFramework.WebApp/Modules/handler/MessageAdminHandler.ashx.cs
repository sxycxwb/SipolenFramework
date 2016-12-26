using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;
using RDIFramework.WebCommon;

namespace RDIFramework.WebApp.Modules.handler
{
    /// <summary>
    /// MessageAdminHandler 的摘要说明
    /// “消息管理”处理器
    /// </summary>
    public class MessageAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetMessageListByFunctionCode":
                    GetMessageListByFunctionCode(context);
                    break;
                case "SendMessage":
                    SendMessage(context);
                    break;
                case "BroadcastMessage":
                    BroadcastMessage(context);
                    break;
                case "ReadMessage":
                    ReadMessage(context);
                    break;
                case "Delete":
                    Delete(context);
                    break;
            }
        }

        private void GetMessageListByFunctionCode(HttpContext ctx)
        {
            var pageParam = new PageParam(ctx);
            string searchValue = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("searchValue"));
            string functionCode = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("functionCode"));
            searchValue = !string.IsNullOrEmpty(searchValue) ? HttpUtility.UrlDecode(searchValue) + " AND " : "";
            UserInfo curUser = Utils.UserInfo;
            if (!string.IsNullOrEmpty(functionCode))
            {
                searchValue += CiMessageTable.FieldFunctionCode + " = '" + functionCode + "'";
            }

            searchValue = !string.IsNullOrEmpty(searchValue) ? searchValue + " AND " : "";
            /*
             SELECT * FROM dbo.CIMESSAGE 
                WHERE FUNCTIONCODE = 'UserMessage' 
                AND ((RECEIVERID = '26F43BC9-AE6D-42D2-BAC9-F4237A949484' AND CATEGORYCODE = 'Receiver') 
                OR  (CREATEUSERID = '26F43BC9-AE6D-42D2-BAC9-F4237A949484' AND CATEGORYCODE = 'Send'))
                ORDER BY CREATEON DESC
             */
            searchValue += "((" + CiMessageTable.FieldReceiverId + " = '" + curUser.Id + "' AND " + CiMessageTable.FieldCategoryCode + " ='Receiver') "
                        + " OR  (" + CiMessageTable.FieldCreateUserId + " = '" + curUser.Id + "' AND " + CiMessageTable.FieldCategoryCode + " ='Send'))"; //只显示自己发送的与自己授收的数据
            int recordCount;
            var dtMessage = RDIFrameworkService.Instance.MessageService.GetMessagesByConditional(curUser, searchValue, out recordCount, pageParam.PageIndex, pageParam.PageSize);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtMessage);
            ctx.Response.Write(json);
        }

        private void SendMessage(HttpContext ctx)
        {
            try
            {
                CiMessageEntity message = new CiMessageEntity();
                string AddresseeJson = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AddresseeJson"));
                message.MSGContent = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("MSGContent"));
                message.Title = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Title"));
                RDIFramework.Utilities.UserInfo curUser = Utils.UserInfo;

                List<CiMessageEntity> AddresseeList = JsonHelper.JonsToList<CiMessageEntity>(AddresseeJson);
                message.FunctionCode = MessageFunction.UserMessage.ToDescription();
                string reciveIds = string.Empty;
                if (AddresseeList != null && AddresseeList.Count > 0)
                {
                    foreach (CiMessageEntity entity in AddresseeList)
                    {
                        reciveIds += entity.Id + ",";
                    }
                    reciveIds = reciveIds.TrimEnd(',');
                }
                if (curUser != null)
                {
                    message.ModifiedBy = curUser.RealName;
                    message.ModifiedUserId = curUser.Id;
                }

                int returnValue = 0;
                if (!string.IsNullOrEmpty(reciveIds))
                {
                    returnValue = RDIFrameworkService.Instance.MessageService.BatchSend(curUser, reciveIds.Split(new char[] { ',' }), null, null, message);
                }

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "发送成功。" }.ToString()
                    : new JsonMessage { Success = true, Data = "0", Message = "发送失败。" }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "发送失败，错误：" + ex.Message }.ToString());
            }
        }

        private void BroadcastMessage(HttpContext ctx)
        {
            string message = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("message"));
            try
            {
                int returnValue = 0;
                if (!string.IsNullOrEmpty(message))
                {
                    returnValue = RDIFrameworkService.Instance.MessageService.Broadcast(Utils.UserInfo, message);
                }

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "发送成功。" }.ToString()
                    : new JsonMessage { Success = true, Data = "0", Message = "发送失败。" }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "发送失败，错误：" + ex.Message }.ToString());
            }
        }

        private void ReadMessage(HttpContext ctx)
        {
            try
            {
                string key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                RDIFrameworkService.Instance.MessageService.Read(Utils.UserInfo, key);
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG3010 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage {Success = true, Data = "0", Message =RDIFramework.Utilities.RDIFrameworkMessage.MSG3020 + ex.Message}.ToString());
            }
        }

        private void Delete(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
            var vReturnValue = RDIFrameworkService.Instance.MessageService.SetDeleted(vUser, new string[] { key });
            ctx.Response.Write(vReturnValue > 0
                ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013 }.ToString()
                : new JsonMessage { Success = true, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
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