using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">处理者实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertOperator(UserInfo userInfo, OperatorEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_InsertOperator);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                returnValue = manager.InsertOperator(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">处理者实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateOperator(UserInfo userInfo, OperatorEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_UpdateOperator);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                returnValue = manager.UpdateOperator(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者主键</param>
        /// <returns>大于0成功</returns>
        public int DeleteOperator(UserInfo userInfo, string operatorId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_DeleteOperator);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                returnValue = manager.DeleteOperator(operatorId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得处理者信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operId">处理者主键</param>
        /// <returns>处理者信息</returns>
        public DataTable GetOperatorTable(UserInfo userInfo, string operId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                dataTable = manager.GetOperatorTable(operId);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到指定流程模版所有的处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>指定流程模版所有的处理者列表</returns>
        public DataTable GetWorkFlowAllOperator(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllOperator(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得模板中的处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>处理者</returns>
        public string GetOperContent(UserInfo userInfo, string operatorId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var returnValue = string.Empty;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                returnValue = manager.GetOperContent(operatorId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得指定处理者策略
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>处理者策略</returns>
        public string GetOperRelation(UserInfo userInfo, string operatorId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var returnValue = string.Empty;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                returnValue = manager.GetOperRelation(operatorId);
            });
            return returnValue;
        }

        /// <summary>
        /// 是否存在指定处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>true存在</returns>
        public bool ExistsOperator(UserInfo userInfo, string operatorId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorManager(dbProvider, userInfo);
                returnValue = manager.Exists(operatorId);
            });
            return returnValue;
        }
    }
}
