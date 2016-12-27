using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowHelperService
    /// 
    /// 
    /// 修改记录
    ///     
    ///     
    ///		2014-06-12 版本：2.8 XuWangBin 建立。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-06-12</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class WorkFlowHelperService : System.MarshalByRefObject, IWorkFlowHelperService
    {
        private readonly string serviceName = "WorkFlowHelperService";

        #region public string CreateNextTaskInstance(UserInfo userInfo, string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string workTaskInstanceId, string operatorInstanceId, string commandName) 创建所有符合条件的任务实例
        /// <summary>
        /// 创建所有符合条件的任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">处理人Id</param>
        /// <param name="workFlowId">工作流模板id</param>
        /// <param name="workTaskId">当前任务Id</param>
        /// <param name="workFlowInstanceId">工作流实例Id</param>
        /// <param name="workTaskInstanceId">原任务实例Id</param>
        /// <param name="operatorInstanceId">处理者实例Id</param>
        /// <param name="commandName">命令</param>
        /// <returns>
        /// 000002：没有配置后续任务
        /// 000000：操作成功 
        /// </returns>
        public string CreateNextTaskInstance(UserInfo userInfo, string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string workTaskInstanceId, string operatorInstanceId, string commandName)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowHelperManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.CreateNextTaskInstance(userId, workFlowId, workTaskId, workFlowInstanceId,workTaskInstanceId, operatorInstanceId, commandName);
            });
            return returnValue;
        }
        #endregion

        #region public bool IsPassJudge(UserInfo userInfo, string workFlowId, string workFlowInstanceId, string judgeTaskId, string taskTypeAndOr) 判断节点实例是否都完成
        /// <summary>
        /// 判断节点实例是否都完成
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workFlowInstanceId">工作流实例Id</param>
        /// <param name="judgeTaskId">待判断力的节点Id</param>
        /// <param name="taskTypeAndOr">节点类型：and、or</param>
        /// <returns></returns>
        public bool IsPassJudge(UserInfo userInfo, string workFlowId, string workFlowInstanceId, string judgeTaskId, string taskTypeAndOr)
        {
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowHelperManager(dbProvider, userInfo);
                returnValue = manager.IsPassJudge(workFlowId, workFlowInstanceId, judgeTaskId, taskTypeAndOr);
            });
            return returnValue;
        }
        #endregion

        #region public bool IsTaskInsCompleted(UserInfo userInfo,string worktaskInsId) 判断任务实例是否已完成,以此来判断避免重复提交
        /// <summary>
        /// 判断任务实例是否已完成,以此来判断避免重复提交
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskInsId">任务实例Id</param>
        /// <returns></returns>
        public bool IsTaskInsCompleted(UserInfo userInfo,string worktaskInsId)
        {
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowHelperManager(dbProvider, userInfo);
                returnValue = manager.IsTaskInsCompleted(worktaskInsId);
            });
            return returnValue;
        }
        #endregion
    }
}
