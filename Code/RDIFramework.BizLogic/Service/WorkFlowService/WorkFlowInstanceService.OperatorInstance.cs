using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowInstanceService
    {
        #region public string CreateOperatorInstance(UserInfo userInfo, OperatorInstanceEntity entity) 创建处理者实例
        /// <summary>
        /// 创建处理者实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">创建处理者实例实体</param>
        /// <returns>主键</returns>
        public string CreateOperatorInstance(UserInfo userInfo, OperatorInstanceEntity entity)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_CreateOperatorInstance);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.Create(entity);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetOperatorInstance(UserInfo userInfo, string operatorInsId) 获得一个要处理的信息
        /// <summary>
        /// 获得一个要处理的信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        public DataTable GetOperatorInstance(UserInfo userInfo, string operatorInsId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetOperatorInstance);
            var dataTable = new DataTable(OperatorInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetOperatorInstance(operatorInsId);
            });
            return dataTable;
        }
        #endregion

        #region public int SetOperatorInstanceOver(UserInfo userInfo, string userId, string operatorInsId) 设定处理者实例正常结束
        /// <summary>
        /// 设定处理者实例正常结束
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">操作者实例id</param>
        /// <returns>大于0成功</returns>
        public int SetOperatorInstanceOver(UserInfo userInfo, string userId, string operatorInsId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetOperatorInstanceOver);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new OperatorInstanceManager(dbProvider, userInfo);
                returnValue = manager.SetOperatorInstanceOver(userId, operatorInsId);
            });
            return returnValue;
        }
        #endregion
    }
}
