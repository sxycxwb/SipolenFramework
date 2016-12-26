using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowHelperService
    {
        #region public string InsertAccreditUser(UserInfo userInfo, AccreditUserEntity entity) 增加任务授权
        /// <summary>
        /// 增加任务授权
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        public string InsertAccreditUser(UserInfo userInfo, AccreditUserEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                returnValue = manager.Insert(entity);
            });
            return returnValue;
        }
        #endregion

        #region public bool IsTaskOperator(UserInfo userInfo, string userId, string workFlowId, string workTaskId) 判断用户是否是该任务节点的操作者
        /// <summary>
        /// 判断用户是否是该任务节点的操作者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns></returns>
        public bool IsTaskOperator(UserInfo userInfo, string userId, string workFlowId, string workTaskId)
        {
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                returnValue = manager.IsTaskOperator(userId, workFlowId, workTaskId);
            });
            return returnValue;
        }
        #endregion

        #region public int UpdateAccreditUser(UserInfo userInfo, AccreditUserEntity entity) 更新任务授权
        /// <summary>
        /// 更新任务授权
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateAccreditUser(UserInfo userInfo, AccreditUserEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                returnValue = manager.UpdateAccreditUser(entity);
            });
            return returnValue;
        }
        #endregion

        #region  public DataTable GetAccreditUserTable(UserInfo userInfo, string auserId) 依据主键获得任务授权列表
        /// <summary>
        /// 依据主键获得任务授权列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="auserId">主键</param>
        /// <returns>任务授权列表</returns>
        public DataTable GetAccreditUserTable(UserInfo userInfo, string auserId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(AccreditUserTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                dataTable = manager.GetAccreditUserTable(auserId);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetToAccreditTable(UserInfo userInfo, string userId) 已授出的任务授权列表
        /// <summary>
        /// 已授出的任务授权列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <returns>已授出的任务授权列表</returns>
        public DataTable GetToAccreditTable(UserInfo userInfo, string userId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(AccreditUserTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                dataTable = manager.GetToAccreditTable(userId);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetHaveAccreditTable(UserInfo userInfo, string userId) 被授予的任务授权列表
        /// <summary>
        /// 被授予的任务授权列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <returns>被授予的任务授权列表</returns>
        public DataTable GetHaveAccreditTable(UserInfo userInfo, string userId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(AccreditUserTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                dataTable = manager.GetHaveAccreditTable(userId);
            });
            return dataTable;
        }
        #endregion

        #region public int MoveAccredit(UserInfo userInfo, string auserId) 移除任务授权
        /// <summary>
        /// 移除任务授权
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="auserId">主键</param>
        /// <returns>大于0成功</returns>
        public int MoveAccredit(UserInfo userInfo, string auserId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                returnValue = manager.MoveAccredit(auserId);
            });
            return returnValue;
        }
        #endregion

        #region public int DeleteAccreditUser(UserInfo userInfo, string auserId) 根据主键删除任务授权记录
        /// <summary>
        /// 根据主键删除任务授权记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="auserId">主键</param>
        /// <returns>大于0成功</returns>
        public int DeleteAccreditUser(UserInfo userInfo, string auserId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AccreditUserManager(dbProvider, userInfo);
                returnValue = manager.DeleteAccreditUser(auserId);
            });
            return returnValue;
        }
        #endregion
    }
}
