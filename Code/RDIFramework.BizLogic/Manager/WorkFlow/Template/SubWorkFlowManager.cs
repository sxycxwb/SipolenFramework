using System;
using System.Data;

namespace RDIFramework.BizLogic
{

    /// <summary>
    /// SubWorkFlowManager
    /// 子流程节点配置表
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-04 版本：1.0 XuWangBin 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class SubWorkFlowManager
    {
        /// <summary>
        /// 新建一个子流程模板
        /// </summary>
        /// <param name="entity">子流程节点配置实体</param>
        public string InsertSubWorkFlow(SubWorkFlowEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.SubId.Trim().Length == 0 || entity.SubId == null)
            {
                throw new Exception("InsertSubWorkFlow方法错误，SubId 不能为空！");
            }

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
        /// 修改一个子流程设置
        /// </summary>
        /// <param name="entity">子流程节点配置实体</param>
        public int UpdateSubWorkFlow(SubWorkFlowEntity entity)
        {
            int returnInt = -1;

            if (entity.SubId.Trim().Length == 0 || entity.SubId == null)
                throw new Exception("UpdateWorkFlow方法错误，SubId 不能为空！");

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
        /// 删除指定子流程配置
        /// </summary>
        /// <param name="workFlowId">工作流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns></returns>
        public int DeleteSubWorkFlow(string workFlowId, string taskId)
        {
            try
            {
                //string sqlStr = "delete from SubWorkFlow where WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId";
                return this.Delete(SubWorkFlowTable.FieldWorkFlowId, workFlowId, SubWorkFlowTable.FieldWorkTaskId, taskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获得子流程配置信息
        /// </summary>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns></returns>
        public DataTable GetSubWorkflowTable(string workFlowId, string taskId)
        {
            try
            {
                //string sqlStr = "select * from SubWorkFlow where WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId";
                return this.GetDT(SubWorkFlowTable.FieldWorkFlowId, workFlowId, SubWorkFlowTable.FieldWorkTaskId, taskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程的所有子流程
        /// </summary>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowAllSub(string workFlowId)
        {
            try
            {
                //string sqlStr = "select * from SubWorkFlow where WorkFlowId=@WorkFlowId ";
                return this.GetDT(SubWorkFlowTable.FieldWorkFlowId, workFlowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断子流程配置信息是否存在
        /// </summary>
        /// <param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns></returns>
        public bool ExistsSubWorkFlow(string workFlowId, string taskId)
        {
            //string sqlStr = "select * from SubWorkFlow where  WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId";
            return this.Exists(SubWorkFlowTable.FieldWorkFlowId, workFlowId, SubWorkFlowTable.FieldWorkTaskId, taskId);
        }

        /// <summary>
        /// 判断子流程是否存在
        /// </summary>
        /// <param name="subId"></param>
        /// <returns></returns>
        public bool Exists(string subId)
        {
           // string sqlStr = "select * from SubWorkFlow where  subId=@subId";
            return this.Exists(SubWorkFlowTable.FieldSubId, subId);           
        }
    }
}
