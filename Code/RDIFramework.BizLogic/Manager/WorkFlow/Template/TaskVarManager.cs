using System;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// TaskVarManager
    /// 任务变量处理类
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
    public partial class TaskVarManager
    {
        /// <summary>
        /// 增加任务变量
        /// </summary>
        /// <param name="entity">任务变量实体</param>
        /// <returns></returns>
        public string InsertTaskVar(TaskVarEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.TaskVarId.Trim().Length == 0 || entity.TaskVarId == null)
                throw new Exception("InsertTaskVar方法错误，TaskVarId 不能为空！");
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
        /// 修改任务变量
        /// </summary>
        /// <param name="entity">任务变量实体</param>
        /// <returns></returns>
        public int UpdateTaskVar(TaskVarEntity entity)
        {
            int returnInt = -1;
            if (entity.TaskVarId.Trim().Length == 0 || entity.TaskVarId == null)
                throw new Exception("UpdateTaskVar方法错误，TaskVarId 不能为空！");
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
        /// 删除一个任务变量
        /// </summary>
        /// <param name="taskVarId">任务变量主键</param>
        /// <returns>受影响的行数</returns>
        public int DeleteTaskVar(string taskVarId)
        {
            try
            {
                //string tmpSql = "delete TaskVar where TaskVarId=@taskVarId";
                return this.Delete(TaskVarTable.FieldTaskVarId, taskVarId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得变量信息
        /// </summary>
        /// <param name="taskVarId">变量Id</param>
        /// <returns>数据表table</returns>
        public DataTable GetTaskVarTable(string taskVarId)
        {
            try
            {
                //string tmpStr = "select * from TaskVar where  TaskVarId=@taskVarId";
                return this.GetDT(TaskVarTable.FieldTaskVarId, taskVarId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程变量列表
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowVar(string workflowId)
        {
            try
            {
                //string tmpSql = "select * from TaskVar where workflowId = @workflowId and AccessType=@AccessType";
                return this.GetDT(TaskVarTable.FieldWorkFlowId, workflowId, TaskVarTable.FieldAccessType, WorkFlowConst.Access_WorkFlow);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="taskId">任务模板Id</param>
        /// <returns></returns>
        public DataTable GetTaskVar(string taskId)
        {
            try
            {
                //string tmpSql = "select * from TaskVar where WorkTaskId = @WorkTaskId and AccessType=@AccessType";
                return this.GetDT(TaskVarTable.FieldWorkTaskId, taskId, TaskVarTable.FieldAccessType, WorkFlowConst.Access_WorkTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="varName">变量名</param>
        /// <returns>任务变量列表</returns>
        public DataTable GetTaskVarByName(string workflowId, string varName)
        {
            try
            {
                //string tmpSql = "select * from TaskVar where VarName =@VarName and workflowid=@workflowid";
                return this.GetDT(TaskVarTable.FieldVarName, varName, TaskVarTable.FieldWorkFlowId, workflowId);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程变量列表
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowAllVar(string workflowId)
        {
            try
            {
                //string tmpSql = "select * from TaskVar where workflowId = @workflowId";
                return this.GetDT(TaskVarTable.FieldWorkFlowId, workflowId);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="taskVarId">任务变量Id</param>
        /// <returns></returns>
        public bool Exists(string taskVarId)
        {
            //string tmpSql = "sselect * from taskvar where taskVarId=@taskVarId";
            return this.Exists(TaskVarTable.FieldTaskVarId, taskVarId);           
        }
    }
}
