using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// WorkFlowEventManager
    /// 事件通知
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkFlowEventManager
    {
        /// <summary>
        /// 增加事件通知
        /// </summary>
        /// <param name="entity">事件通知实体</param>
        /// <returns>增加成功后的主键</returns>
        public string Insert(WorkFlowEventEntity entity)
        {
            string returnStr = string.Empty;
            try
            {
                returnStr = this.AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }

        /// <summary>
        /// 更新事件通知
        /// </summary>
        /// <param name="entity">事件通知实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkFlowEvent(WorkFlowEventEntity entity)
        {
            int returnInt = -1;
            if (entity.WorkTaskId.Trim().Length == 0 || entity.WorkTaskId == null)
                throw new Exception("Update方法错误，WorkTaskId不能为空！");
            try
            {
                returnInt = this.UpdateEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnInt;
        }

        /// <summary>
        /// 根据任务模版主键删除事件通知记录
        /// </summary>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkFlowEvent(string worktaskid)
        {
            if (string.IsNullOrEmpty(worktaskid))
                throw new Exception("Delete方法错误，worktaskid不能为空！");
            try
            {
                //string tmpSql = "delete from WorkFlowEvent where WorkTaskId=@worktaskid";
                return this.Delete(WorkFlowEventTable.FieldWorkTaskId, worktaskid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得指定任务模版事件通知列表
        /// </summary>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>事件通知列表</returns>
        public DataTable GetWorkFlowEventTable(string worktaskid)
        {
            if (string.IsNullOrEmpty(worktaskid))
                throw new Exception("GetWorkFlowEventTable方法错误，worktaskid不能为空！");

            try
            {
                //string tmpStr = "select * from WorkFlowEvent where WorkTaskId=@worktaskid";
                return this.GetDT(WorkFlowEventTable.FieldWorkTaskId, worktaskid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定流程模版所有的事件通知列表
        /// </summary>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>事件通知列表</returns>
        public DataTable GetWorkFlowAllEventTable(string workFlowId)
        {
            if (string.IsNullOrEmpty(workFlowId))
                throw new Exception("GetWorkFlowAllEventTable方法错误，workFlowId不能为空！");
            try
            {
                //string tmpStr = "select * from WorkFlowEvent where workFlowId=@workFlowId";
                return this.GetDT(WorkFlowEventTable.FieldWorkFlowId, workFlowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到事件通知列表实体
        /// </summary>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>事件通知列表实体</returns>
        public WorkFlowEventEntity GetWorkFlowEventInfo(string worktaskid)
        {
            if (string.IsNullOrEmpty(worktaskid))
                throw new Exception("GetWorkFlowEventInfo方法错误，worktaskid不能为空！");
            DataTable dt = GetWorkFlowEventTable(worktaskid);
            WorkFlowEventEntity entity = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<WorkFlowEventEntity>(dt);
            }
            return entity;
        }
    }
}
