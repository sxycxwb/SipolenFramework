using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加子流程节点配置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子流程节点配置实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertSubWorkFlow(UserInfo userInfo, SubWorkFlowEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_InsertSubWorkFlow);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                returnValue = manager.InsertSubWorkFlow(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改子流程节点配置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子流程节点配置实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateSubWorkFlow(UserInfo userInfo, SubWorkFlowEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_UpdateSubWorkFlow);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                returnValue = manager.UpdateSubWorkFlow(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除子流程节点配置
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns>大于0成功</returns>
        public int DeleteSubWorkFlow(UserInfo userInfo, string workFlowId, string taskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_DeleteSubWorkFlow);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                returnValue = manager.DeleteSubWorkFlow(workFlowId, taskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得子流程配置信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns>子流程配置信息</returns>
        public DataTable GetSubWorkflowTable(UserInfo userInfo, string workFlowId, string taskId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                dataTable = manager.GetSubWorkflowTable(workFlowId,taskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得流程的所有子流程
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>指定流程的所有子流程列表</returns>
        public DataTable GetWorkFlowAllSub(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowAllSub(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 判断子流程配置信息是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns>true存在</returns>
        public bool ExistsSubWorkFlow(UserInfo userInfo, string workFlowId, string taskId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                returnValue = manager.ExistsSubWorkFlow(workFlowId,taskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 判断子流程配置信息是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="subId">子流程主键</param>
        /// <returns>true存在</returns>
        public bool ExistsSubWorkFlowBySubId(UserInfo userInfo, string subId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new SubWorkFlowManager(dbProvider, userInfo);
                returnValue = manager.Exists(subId);
            });
            return returnValue;
        }
    }
}
