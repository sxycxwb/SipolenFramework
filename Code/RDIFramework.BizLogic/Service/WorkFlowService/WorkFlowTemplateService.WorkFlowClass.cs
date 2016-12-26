using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 新增流程分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">分类实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertWorkFlowClass(UserInfo userInfo, WorkFlowClassEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkFlowClass);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowClassManager(dbProvider, userInfo);
                returnValue = manager.InsertWorkflowClass(entity);
            });
            return returnValue;
        }
        
        /// <summary>
        /// 修改流程分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">分类实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkFlowClass(UserInfo userInfo, WorkFlowClassEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkFlowClass);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowClassManager(dbProvider, userInfo);
                returnValue = manager.UpdateWorkflowClass(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除指定流程分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowClassId">流程分类Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkFlowClass(UserInfo userInfo, string workflowClassId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkFlowClass);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowClassManager(dbProvider, userInfo);
                returnValue = manager.DeleteWorkflowClass(workflowClassId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得流程分类的所有子分类列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fatherClassId">父分类id</param>
        /// <returns>分类列表</returns>
        public DataTable GetChildWorkFlowClass(UserInfo userInfo, string fatherClassId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetChildWorkFlowClass);
            var dataTable = new DataTable(WorkTaskCommandsTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowClassManager(dbProvider, userInfo);
                dataTable = manager.GetChildWorkflowClass(fatherClassId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得流程分类下的所有流程列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="classId">流程分类Id</param>
        /// <returns>流程分类列表</returns>
        public DataTable GetWorkFlowsByClassId(UserInfo userInfo, string classId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowsByClassId);
            var dataTable = new DataTable(WorkTaskCommandsTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowClassManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowsByClassId(classId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得流程分类实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="classId">流程分类Id</param>
        /// <returns>分类实体</returns>
        public WorkFlowClassEntity GetWorkFlowClassInfo(UserInfo userInfo, string classId)
        {
            WorkFlowClassEntity returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowClassInfo);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowClassManager(dbProvider, userInfo);
                returnValue = manager.GetWorkflowClassInfo(classId);
            });
            return returnValue;
        }
    }
}
