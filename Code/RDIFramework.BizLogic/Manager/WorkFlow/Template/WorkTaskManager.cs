using System;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkTaskManager
    /// 流程任务管理器
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
    public partial class WorkTaskManager
    {
        /// <summary>
        ///增加任务节点
        /// </summary>
        ///<param name="entity">流程任务实体</param>
        ///<returns>主键</returns>
        public string InsertTask(WorkTaskEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.WorkTaskId.Trim().Length == 0 || entity.WorkTaskId == null)
                throw new Exception("InsertTask方法错误，TaskId 不能为空！");
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
        /// 修改任务节点
        /// </summary>
        /// <param name="entity">流程任务实体</param>
        public int UpdateTask(WorkTaskEntity entity)
        {
            int returnInt = -1;
            if (entity.WorkTaskId.Trim().Length == 0 || entity.WorkTaskId == null)
                throw new Exception("UpdateTask方法错误，TaskId 不能为空！");
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
        /// 删除一个任务节点
        /// </summary>
        /// <param name="workflowId">流程模版Id</param>
        /// <param name="worktaskId">任务模板Id</param>
        public int DeleteTask(string workflowId, string worktaskId)
        {
            try
            {
                //string tmpStr = "delete WorkTask where workflowid=@workflowId and WorkTaskId=@worktaskId";
                return this.Delete(WorkTaskTable.FieldWorkFlowId, workflowId, WorkTaskTable.FieldWorkTaskId, worktaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除指定任务的所有处理人
        /// </summary>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns></returns>
        public int DeleteAllOperator(string worktaskId)
        {
            try
            {
                //string sqlStr = "delete Operator where  WorkTaskId=@worktaskId";
                return new OperatorManager(this.DBProvider).Delete(OperatorTable.FieldWorkTaskId, worktaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除指定任务的所有任务变量
        /// </summary>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns></returns>
        public int DeleteAllTaskVar(string worktaskId)
        {
            try
            {
                //string sqlStr = "delete TaskVar where  WorkTaskId=@worktaskId";
                return new TaskVarManager(this.DBProvider).Delete(TaskVarTable.FieldWorkTaskId, worktaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除指定任务的所有任务命令
        /// </summary>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns></returns>
        public int DeleteAllCommands(string worktaskId)
        {
            try
            {
                //string sqlStr = "delete WorkTaskCommands where  WorkTaskId=@worktaskId";
                return new WorkTaskCommandsManager(this.DBProvider).Delete(WorkTaskCommandsTable.FieldWorkTaskId, worktaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除指定任务的所有控制权限
        /// </summary>
        /// <param name="workflowId">流程模版id</param>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns></returns>
        public int DeleteAllPower(string workflowId, string worktaskId)
        {
            try
            {
                //string sqlStr = "delete WorkTaskPower where  workflowId=@workflowId  and  WorkTaskId=@worktaskId";
                return new WorkTaskPowerManager(this.DBProvider).Delete(WorkTaskPowerTable.FieldWorkFlowId, workflowId, WorkTaskPowerTable.FieldWorkTaskId, worktaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除指定任务的所有表单
        /// </summary>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns></returns>
        public int DeleteAllControls(string worktaskId)
        {
            try
            {
                //string sqlStr = "delete WorkTaskControls where  WorkTaskId=@worktaskId";
                return new WorkTaskControlsManager(this.DBProvider).Delete(WorkTaskControlsTable.FieldWorkTaskId, worktaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务列表
        /// </summary>
        /// <param name="workflowId">流程模版Id</param>
        /// <returns></returns>
        public DataTable GetWorkTasks(string workflowId)
        {
            try
            {
                //string sqlStr = "select * from WorkTask where WorkFlowId = @workflowId order by TaskCaption";
                return this.GetDT(WorkTaskTable.FieldWorkFlowId, workflowId, WorkTaskTable.FieldTaskCaption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务处理者列表
        /// </summary>
        /// <param name="workflowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns></returns>
        public DataTable GetTaskOperator(string workflowId, string workTaskId)
        {
            try
            {
                //string sqlStr = "select * from Operator where WorkTaskId =@workTaskId and workflowId=@workflowId";
                return new OperatorManager(this.DBProvider).GetDT(OperatorTable.FieldWorkTaskId, workTaskId, OperatorTable.FieldWorkFlowId, workflowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务命令列表
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务命令列表</returns>
        public DataTable GetTaskCommands(string workFlowId, string workTaskId)
        {
            try
            {
                //string sqlStr = "select * from WorkTaskCommands where WorkTaskId = @workTaskId and workflowId=@workFlowId";
                return new WorkTaskCommandsManager(this.DBProvider).GetDT(WorkTaskCommandsTable.FieldWorkTaskId, workTaskId, WorkTaskCommandsTable.FieldWorkFlowId, workFlowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得控制权限列表
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>控制权限列表</returns>
        public DataTable GetTaskPower(string workFlowId, string workTaskId)
        {
            try
            {
                //string sqlStr = "select * from WorkTaskPower where WorkTaskId =@workTaskId and workflowId=@workFlowId";
                return new WorkTaskPowerManager(this.DBProvider).GetDT(WorkTaskPowerTable.FieldWorkTaskId, workTaskId, WorkTaskPowerTable.FieldWorkFlowId, workFlowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得开始任务节点
        /// </summary>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>开始任务节点列表</returns>
        public DataTable GetStartTask(string workFlowId)
        {
            try
            {
                string sqlStr = string.Format("SELECT * FROM WORKTASK WHERE TASKTYPEID = '1' AND WORKFLOWID={0}", DBProvider.GetParameter(WorkTaskTable.FieldWorkFlowId));
                return this.Fill(sqlStr, new IDbDataParameter[] { DBProvider.MakeParameter(WorkTaskTable.FieldWorkFlowId, workFlowId) }); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断节点是否存在
        /// </summary>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>true:存在</returns>
        public bool ExistTask(string workTaskId)
        {
            try
            {
                if (workTaskId.Trim().Length == 0)
                    throw new Exception("ExistTask方法错误，workTaskId 不能为空!");

                //string sqlStr = "select * from WorkTask where WorkTaskId=@workTaskId";
                return this.Exists(WorkTaskTable.FieldWorkTaskId, workTaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务名称
        /// </summary>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns></returns>
        public string GetTaskCaption(string workTaskId)
        {
            try
            {
                //string sqlStr = "select TaskCaption from WorkTask where WorkTaskId=@workTaskId";
                return this.GetProperty(WorkTaskTable.FieldWorkTaskId, workTaskId, WorkTaskTable.FieldTaskCaption);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务模版列表
        /// </summary>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务模版列表</returns>
        public DataTable GetTaskTable(string workTaskId)
        {
            try
            {
                string sqlStr = string.Format("SELECT * FROM WORKTASKVIEW WHERE WORKTASKID={0}", DBProvider.GetParameter(WorkTaskTable.FieldWorkTaskId));
                return this.Fill(sqlStr, new IDbDataParameter[] { DBProvider.MakeParameter(WorkTaskTable.FieldWorkTaskId, workTaskId) });   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得一个任务模板在流程实例中的所有任务实例
        /// </summary>
        /// <param name="workflowId">流程模版Id</param>
        /// <param name="workflowInsId">流程实例Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务模板在流程实例中的所有任务实例列表</returns>
        public DataTable GetTaskInstance(string workflowId, string workflowInsId, string workTaskId)
        {
            try
            {
                //string sqlStr = "select * from WorkTaskInstance where workflowId=@workflowId and workflowInsId=@workflowInsId and worktaskid=@worktaskid";
                string[] names = {WorkTaskInstanceTable.FieldWorkFlowId,WorkTaskInstanceTable.FieldWorkFlowInsId,WorkTaskInstanceTable.FieldWorkTaskId};
                string[] values = { workflowId, workflowInsId, workTaskId };
                return new WorkTaskInstanceManager(this.DBProvider).GetDT(names, values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="workaskId">任务模板Id</param>
        /// <returns>任务变量列表</returns>
        public DataTable GetTaskVar(string workaskId)
        {
            try
            {
                //string sqlStr = "select * from TaskVar where WorkTaskId = @worktaskid";
                return new TaskVarManager(this.DBProvider).GetDT(TaskVarTable.FieldWorkTaskId, workaskId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务节点绑定的表单列表
        /// </summary>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns></returns>
        public DataTable GetTaskControls(string workTaskId)
        {
            try
            {
                string sqlStr = string.Format("SELECT * FROM WORKTASKCONTROLSVIEW WHERE WORKTASKID ={0} ORDER BY CONTROLORDER", DBProvider.GetParameter(WorkTaskTable.FieldWorkTaskId));
                return this.Fill(sqlStr, new IDbDataParameter[] { DBProvider.MakeParameter(WorkTaskTable.FieldWorkTaskId, workTaskId) });   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务节点绑定表单
        /// </summary>
        /// <param name="userCtrlId">表单id</param>
        /// <param name="workflowid">流程模版Id</param>
        /// <param name="worktaskId">任务节点id</param>
        /// <returns>绑定成功返回主键</returns>
        public string SetTaskUserCtrls(string userCtrlId, string workflowid, string worktaskId)
        {
            string returnStr = string.Empty;
            try
            {
                //string sqlStr = "insert WorkTaskControls(UserControlId,workflowid,WorktaskId) values (@UserControlId,@workflowid,@WorktaskId)";
                var entity = new WorkTaskControlsEntity
                {
                    UserControlId = userCtrlId,
                    WorkflowId = workflowid,
                    WorkTaskId = worktaskId
                };
                returnStr = new WorkTaskControlsManager(this.DBProvider).AddEntity(entity);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }

        /// <summary>
        /// 设置任务节点的控制权限
        /// </summary>
        /// <param name="powerName">权限名</param>
        /// <param name="workflowid">workflowid</param>
        /// <param name="worktaskId">worktaskId</param>
        public string SetTaskPower(string powerName, string workflowid, string worktaskId)
        {
            string returnStr = string.Empty;
            try
            {
                //string sqlStr = "insert WorkTaskPower(PowerName,workflowid,WorktaskId) values (@powerName,@workflowid,@WorktaskId)";
                var entity = new WorkTaskPowerEntity
                {
                    PowerName = powerName,
                    WorkFlowId = workflowid,
                    WorkTaskId = worktaskId
                };
                returnStr = new WorkTaskPowerManager(this.DBProvider).AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }
    }
}
