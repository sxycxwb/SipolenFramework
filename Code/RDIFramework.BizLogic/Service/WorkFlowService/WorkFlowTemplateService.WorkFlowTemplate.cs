using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 新建 一个流程模板
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程模板实体</param>
        /// <returns>增加成功后的主键</returns>
        public string InsertWorkFlow(UserInfo userInfo, WorkFlowTemplateEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkFlow);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                returnValue = manager.InsertWorkFlow(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改一个流程模板
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程模板实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkFlow(UserInfo userInfo, WorkFlowTemplateEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkFlow);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                returnValue = manager.UpdateWorkFlow(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除一个流程模板
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkFlow(UserInfo userInfo, string workflowId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkFlow);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                returnValue = manager.DeleteWorkFlow(workflowId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得工作流模板信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns></returns>
        public DataTable GetWorkFlowTable(UserInfo userInfo, string workflowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowTable);
            var dataTable = new DataTable(WorkFlowTemplateTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowTable(workflowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到指定工作流程所有的任务表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns>指定工作流程所有的任务表单</returns>
        public DataTable GetWorkFlowAllControlsTable(UserInfo userInfo, string workflowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowAllControlsTable);
            var dataTable = new DataTable(WorkFlowTemplateTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllControlsTable(workflowId);
            });
            return dataTable;
        }
        
        /// <summary>
        /// 得到流程模板实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns>流程模板实体</returns>
        public WorkFlowTemplateEntity GetWorkFlowInfo(UserInfo userInfo, string workflowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowInfo);
            WorkFlowTemplateEntity entity = null;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                entity = manager.GetWorkflowInfo(workflowId);
            });
            return entity;
        }

        /// <summary>
        /// 获得有权限启动的流程
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <returns>有权启动的流程列表</returns>
        public DataTable GetAllowStartWorkFlows(UserInfo userInfo, string userId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetAllowsStartWorkFlows);
            var dataTable = new DataTable(WorkFlowTemplateTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                dataTable = manager.GetAllowStartWorkFlows(userId);
            });
            return dataTable;
        }

        /// <summary>
        /// 依据流程模版名称获得流程模板列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowCaption">流程模板名称</param>
        /// <returns>流程模板列表</returns>
        public DataTable GetWorkFlowsByCaption(UserInfo userInfo, string workflowCaption)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowsByCaption);
            var dataTable = new DataTable(WorkFlowTemplateTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowsByCaption(workflowCaption);
            });
            return dataTable;
        }

        /// <summary>
        /// 是否存在指定流程模版
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowid">流程模版id</param>
        /// <returns>true:存在,false:不存在</returns>
        public bool WorkFlowExists(UserInfo userInfo, string workFlowid)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_WorkFlowExists);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                returnValue = manager.Exists(workFlowid);
            });
            return returnValue;
        }

        /// <summary>
        /// 设置工作流模板状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="status">
        /// 启用：status=1 
        /// 禁用：status=0 
        /// </param>
        /// <returns>大于0设置成功</returns>
        public int SetWorkFlowStatus(UserInfo userInfo, string workflowId, string status)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_SetWorkFlowStatus);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                returnValue = manager.SetWorkflowStatus(workflowId, status);
            });
            return returnValue;
        }

        /// <summary>
        /// 设置流程模版分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="wfclassid">流程分类Id</param>
        /// <returns>大于0设置成功</returns>
        public int SetWorkFlowClass(UserInfo userInfo, string workflowId, string wfclassid)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_SetWorkFlowClass);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowTemplateManager(dbProvider, userInfo);
                returnValue = manager.SetWorkflowClass(workflowId, wfclassid);
            });
            return returnValue;
        }

    }
}
