using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.WorkFlow.handler
{
    using RDIFramework.WebCommon;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowCommonBizHandler 的摘要说明
    /// </summary>
    public class WorkFlowCommonBizHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetWorkFlowInstanceDTByPage":
                    GetWorkFlowInstanceDTByPage(context);
                    break;
                case "GetMyUnClaimedTaskList":
                    GetMyUnClaimedTaskList(context);
                    break;
                case "GetMyClaimedTaskList":
                    GetMyClaimedTaskList(context);
                    break;
                case "GetMyCompletedTaskList":
                    GetMyCompletedTaskList(context);
                    break;
                case "GetWorkFlowHistory":
                    GetWorkFlowHistory(context);
                    break;
                case "GetWorkFlowBack":
                    GetWorkFlowBack(context);
                    break;
                case "GetWorkFlowAllTaskByPage": //得到所有我参与的任务
                    GetWorkFlowAllTaskByPage(context);
                    break;
                case "ClaimTask":
                    ClaimTask(context);
                    break;
                case "GiveupClaimTask":
                    GiveupClaimTask(context);
                    break;
                case "BindTaskBackStep":
                    BindTaskBackStep(context);
                    break;
                case "TaskBack":
                    TaskBack(context);
                    break;
                case "AssignTask": //指派
                    AssignTask(context);
                    break;
                case "UploadAttachment":
                    UploadAttachment(context);
                    break;
            }
        }

        public void GetWorkFlowInstanceDTByPage(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            }

            var pageParam = new PageParam(ctx);
            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(where))
            {
                where = where.Replace("STARTTIME", "TO_CHAR(STARTTIME, 'yyyy-mm-dd')");
            }

            where = string.IsNullOrEmpty(where) ? "" : System.Web.HttpUtility.UrlDecode(where); 
            int recordCount;
            var dtUnClaimedTask = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowInstanceDTByPage(Utils.UserInfo, where, out recordCount, pageParam.PageIndex, pageParam.PageSize, WorkFlowInstanceTable.FieldStartTime + " DESC ");
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtUnClaimedTask);
            ctx.Response.Write(json);
        }

        public void GetMyUnClaimedTaskList(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            }
            var pageParam = new PageParam(ctx);
            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(where))
            {
                where = where.Replace("TASKSTARTTIME", "TO_CHAR(TASKSTARTTIME, 'yyyy-mm-dd')");
            }
            where = string.IsNullOrEmpty(where) ? "" : System.Web.HttpUtility.UrlDecode(where); 

            int recordCount;
            var dtUnClaimedTask = RDIFrameworkService.Instance.WorkFlowInstanceService.GetUnClaimedTaskByPage(Utils.UserInfo, Utils.UserInfo.Id, where, out recordCount, pageParam.PageIndex, pageParam.PageSize);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtUnClaimedTask);
            ctx.Response.Write(json);
        }

        public void GetMyClaimedTaskList(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            } 
            var pageParam = new PageParam(ctx);
            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(where))
            {
                where = where.Replace("TASKSTARTTIME", "TO_CHAR(TASKSTARTTIME, 'yyyy-mm-dd')");
            }

            where = string.IsNullOrEmpty(where) ? "" : System.Web.HttpUtility.UrlDecode(where); 

            int recordCount;
            var dtUnClaimedTask = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowClaimedTaskByPage(Utils.UserInfo, Utils.UserInfo.Id, where, out recordCount, pageParam.PageIndex, pageParam.PageSize);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtUnClaimedTask);
            ctx.Response.Write(json);
        }

        public void GetMyCompletedTaskList(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            }

            var pageParam = new PageParam(ctx);
            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(where))
            {
                where = where.Replace("TASKSTARTTIME", "TO_CHAR(TASKSTARTTIME, 'yyyy-mm-dd')");
            }
            where = string.IsNullOrEmpty(where) ? "" : System.Web.HttpUtility.UrlDecode(where); 
            int recordCount;
            var dtUnClaimedTask = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkFlowCompletedTaskByPage(Utils.UserInfo, Utils.UserInfo.Id, where, out recordCount, pageParam.PageIndex, pageParam.PageSize);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtUnClaimedTask);
            ctx.Response.Write(json);
        }

        private void GetWorkFlowHistory(HttpContext ctx)
        {
            string workFlowInsId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workFlowInsId"));
            var dtWorkFlowHistory = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowHistory(Utils.UserInfo, workFlowInsId);
            var json = JSONhelper.ToJson(dtWorkFlowHistory);
            ctx.Response.Write(json);
        }

        private void GetWorkFlowBack(HttpContext ctx)
        {
            string workFlowInsId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workFlowInsId"));
            var dtWorkFlowHistory = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowBack(Utils.UserInfo, workFlowInsId);
            var json = JSONhelper.ToJson(dtWorkFlowHistory);
            ctx.Response.Write(json);
        }
        
        /// <summary>
        /// 得到我参与的任务列表
        /// </summary>
        /// <param name="ctx"></param>
        private void GetWorkFlowAllTaskByPage(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            }

            var pageParam = new PageParam(ctx);
            if (SystemInfo.WorkFlowDbType == CurrentDbType.Oracle && !string.IsNullOrEmpty(where))
            {
                where = where.Replace("TASKSTARTTIME", "TO_CHAR(TASKSTARTTIME, 'yyyy-mm-dd')");
            }
            where = string.IsNullOrEmpty(where) ? "" : System.Web.HttpUtility.UrlDecode(where); 
            int recordCount;
            var dtAllMyTask = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkFlowAllTaskByPage(Utils.UserInfo, Utils.UserInfo.Id, out recordCount, pageParam.PageIndex, pageParam.PageSize, "All", where);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtAllMyTask);
            ctx.Response.Write(json);
        }

        private void ClaimTask(HttpContext ctx)
        {
            var operatorId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operatorId"));
            var workTaskInsId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workTaskInsId"));
            var vUser = Utils.UserInfo;
            try
            {
                var wfruntime = new WorkFlowRuntime
                {
                    UserId = vUser.Id,
                    WorkTaskInstanceId = workTaskInsId,
                    OperatorInstanceId = operatorId,
                    CurrentUser = vUser
                };

                ctx.Response.Write(wfruntime.TaskClaim() == WorkFlowConst.SuccessCode
                    ? new JsonMessage {Success = true, Data = "1", Message = "认领成功！"}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = "认领失败！"}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        private void GiveupClaimTask(HttpContext ctx)
        {
            var operatorId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operatorId"));
            var workTaskInsId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workTaskInsId"));
            var vUser = Utils.UserInfo;
            try
            {
                var wfruntime = new WorkFlowRuntime
                {
                    UserId = vUser.Id,
                    WorkTaskInstanceId = workTaskInsId,
                    OperatorInstanceId = operatorId,
                    CurrentUser = vUser
                };

                ctx.Response.Write(wfruntime.TaskUnClaim() == WorkFlowConst.SuccessCode
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG3010 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }


        private void BindTaskBackStep(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var workFlowInsId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workFlowInsId"));
            var workTaskId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workTaskId"));
            var workFlowId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workFlowId"));
            var taskInsCaption = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("taskInsCaption"));
            DataTable dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskPower(vUser, workFlowId, workTaskId);
            string powerStr = dt.Rows.Cast<DataRow>().Aggregate("", (current, dr) => current + dr["PowerName"].ToString() + ",");

            if (powerStr.IndexOf(WorkConst.WorkTask_Returnry, System.StringComparison.Ordinal) > -1 ||
                powerStr.IndexOf(WorkConst.WorkTask_Return, System.StringComparison.Ordinal) > -1) //允许（任意）退回
            {
                var dataSource = new DataTable();
                dataSource.Columns.Add("TASKINSCAPTION", typeof (string));
                dataSource.Columns.Add("WORKTASKINSID", typeof (string));
                if (powerStr.IndexOf(WorkConst.WorkTask_Returnry) > -1)
                {
                    DataTable dtth = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkCompleteWorkTask(vUser,workFlowInsId, taskInsCaption);
                    if (dtth.Rows.Count <= 0)
                    {
                        DataRow tmpRow = dataSource.NewRow();
                        tmpRow["TASKINSCAPTION"] = "退回到上一步";
                        tmpRow["WORKTASKINSID"] = "退回到上一步";
                        dataSource.Rows.Add(tmpRow);
                    }
                    else
                    {
                        foreach (DataRow dr in dtth.Rows)
                        {
                            DataRow tmpRow = dataSource.NewRow();
                            tmpRow["TASKINSCAPTION"] = BusinessLogic.ConvertToString(dr["TASKINSCAPTION"]);
                            tmpRow["WORKTASKINSID"] = BusinessLogic.ConvertToString(dr["WORKTASKINSID"]);
                            dataSource.Rows.Add(tmpRow);
                        }
                    }
                }
                else
                {
                    DataRow tmpRow = dataSource.NewRow();
                    tmpRow["TASKINSCAPTION"] = "退回到上一步";
                    tmpRow["WORKTASKINSID"] = "退回到上一步";
                    dataSource.Rows.Add(tmpRow);
                }
                ctx.Response.Write(JSONhelper.ToJson(dataSource));
            }
            else
            {
                ctx.Response.Write("[]");
            }
        }

        /// <summary>
        /// 任务退回
        /// </summary>
        /// <param name="ctx"></param>
        private void TaskBack(HttpContext ctx)
        {
            try
            {
                var vUser = Utils.UserInfo;
                var workFlowInsId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("workFlowInsId"));
                var backCause = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("backCause"));
                var operatorInstanceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operatorInsId"));
                if (!string.IsNullOrEmpty(operatorInstanceId) && !string.IsNullOrEmpty(backCause) && workFlowInsId == "退回到上一步")
                {
                    var wfruntime = new WorkFlowRuntime
                    {
                        UserId = vUser.Id,
                        backyy = backCause,
                        OperatorInstanceId = operatorInstanceId,
                        CurrentUser = vUser
                    };
                    ctx.Response.Write(wfruntime.TaskBack() == WorkFlowConst.SuccessCode
                        ? new JsonMessage { Success = true, Data = "1", Message = "退回成功！" }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = "退回失败！" }.ToString());
                }

                //任意退回
                if (!string.IsNullOrEmpty(operatorInstanceId) && !string.IsNullOrEmpty(backCause) && !string.IsNullOrEmpty(workFlowInsId) && workFlowInsId != "退回到上一步")
                {
                    var wfRuntime = new WorkFlowRuntime
                    {
                        UserId = vUser.Id,
                        backyy = backCause,
                        OperatorInstanceId = operatorInstanceId,
                        //WorkTaskId = selectWorkFlowInsId,
                        WorkFlowInstanceId = workFlowInsId,
                        CurrentUser = vUser
                    };
                    ctx.Response.Write(wfRuntime.TaskBackry() == WorkFlowConst.SuccessCode
                        ? new JsonMessage { Success = true, Data = "1", Message = "任意退回成功！" }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = "任意退回失败！" }.ToString());
                }
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 任务指派
        /// </summary>
        /// <param name="ctx"></param>
        private void AssignTask(HttpContext ctx)
        {
            try
            {
                var vUser = Utils.UserInfo;
                var operatorInstanceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operatorInsId"));
                var assginUserId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("assginUserId"));
                if (!string.IsNullOrEmpty(operatorInstanceId))
                {
                    var wfRuntime = new WorkFlowRuntime
                    {
                        UserId = vUser.Id,
                        AssignUserId = assginUserId,
                        OperatorInstanceId = operatorInstanceId,
                        CurrentUser = vUser
                    };
                    ctx.Response.Write(wfRuntime.TaskAssign() == WorkFlowConst.SuccessCode
                        ? new JsonMessage { Success = true, Data = "1", Message = "指派成功！" }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = "指派失败！" }.ToString());
                }
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        private void UploadAttachment(HttpContext ctx)
        {
            HttpPostedFile file = ctx.Request.Files["Filedata"];
            string uploadPath = HttpContext.Current.Server.MapPath(@ctx.Request["UploadFiles"]) + "\\";

            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + file.FileName);
                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                ctx.Response.Write("1");
            }
            else
            {
                ctx.Response.Write("0");
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