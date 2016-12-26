using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// WorkTaskCommandsManager
    /// 任务命令管理器
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
    public partial class WorkTaskCommandsManager
    { 
        /// <summary>
        /// 增加任务命令
        /// </summary>
        /// <param name="entity">任务命令实体</param>
        /// <returns>主键</returns>
        public string InsertWorkTaskCommands(WorkTaskCommandsEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.CommandId.Trim().Length == 0 || entity.CommandId == null)
                throw new Exception("InsertWorkTaskCommands方法错误，commandId 不能为空！");
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
        /// 修改任务命令
        /// </summary>
        /// <param name="entity">任务命令实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkTaskCommands(WorkTaskCommandsEntity entity)
        {
            int returnInt = -1;
            if (entity.CommandId.Trim().Length == 0 || entity.CommandId == null)
                throw new Exception("UpdateWorkTaskCommands方法错误，commandId 不能为空！");
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
        /// 删除一个任务命令
        /// </summary>
        /// <param name="commandId">主键</param>
        /// <returns></returns>
        public int DeleteWorkTaskCommands(string commandId)
        {
            try
            {
                //string sqlStr = "delete WorkTaskCommands where CommandId=@commandId";
                return this.Delete(WorkTaskCommandsTable.FieldCommandId, commandId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定流程模版的所有任务命令
        /// </summary>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>任务命令列表</returns>
        public DataTable GetWorkFlowAllCommands(string workFlowId)
        {
            try
            {
                //string tmpStr = "select * from WorkTaskCommands where  WorkflowId=@workFlowId";
                return this.GetDT(WorkTaskCommandsTable.FieldWorkFlowId, workFlowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到任务命令通过任务命令Id
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public DataTable GetTaskCommandsTable(string commandId)
        {
            try
            {
                //string tmpStr = "select * from WorkTaskCommands where  CommandId=@commandId";
                return this.GetDT(WorkTaskCommandsTable.FieldCommandId, commandId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否存在指定任务命令
        /// </summary>
        /// <param name="commandId">任务命令Id</param>
        /// <returns></returns>
        public bool Exists(string commandId)
        {
            //string tmpSql = "select * from WorkTaskCommands where CommandId=@commandId";
            return this.Exists(WorkTaskCommandsTable.FieldCommandId, commandId);
        }
    }
}
