using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// WorkOutTimeManager
    /// 工作任务超时设置
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 EricHu 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>EricHu</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkOutTimeManager
    {
        /// <summary>
        /// 增加工作任务超时设置
        /// </summary>
        /// <param name="entity">工作任务超时实体</param>
        /// <returns>成功返回主键</returns>
        public string InsertWorkOutTime(WorkOutTimeEntity entity)
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
        /// 更新工作任务超时设置
        /// </summary>
        /// <param name="entity">工作任务超时实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkOutTime(WorkOutTimeEntity entity)
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
        /// 根据工作任务模版主键删除超时设置记录
        /// </summary>
        /// <param name="workTaskId">任务id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkOutTime(string workTaskId)
        {
            try
            {
                //string sqlStr = "delete from WorkOutTime where WorkTaskId=@workTaskId";
                return this.Delete(WorkOutTimeTable.FieldWorkTaskId, workTaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 依据工作任务模版Id获得超时设置列表
        /// </summary>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>超时设置列表</returns>
        public DataTable GetWorkOutTimeTable(string workTaskId)
        {
            try
            {
                //string sqlStr = "select * from WorkOutTime where WorkTaskId=@workTaskId";
                return this.GetDT(WorkOutTimeTable.FieldWorkTaskId, workTaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定流程模版所有的超时设置列表
        /// </summary>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>超时设置列表</returns>
        public DataTable GetWorkFlowAllOutTimeTable(string workFlowId)
        {
            try
            {
                //string sqlStr = "select * from WorkOutTime where workFlowId=@workFlowId";
                return this.GetDT(WorkOutTimeTable.FieldWorkFlowId, workFlowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到超时设置实体
        /// </summary>
        /// <param name="worktaskid">任务id</param>
        /// <returns>超时设置实体</returns>
        public WorkOutTimeEntity GetWorkOutTimeInfo(string worktaskid)
        {
            WorkOutTimeEntity entity = null;
            DataTable dt = GetWorkOutTimeTable(worktaskid);
            if (dt != null && dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<WorkOutTimeEntity>(dt);
            }
            return entity;
        }
    }
}
