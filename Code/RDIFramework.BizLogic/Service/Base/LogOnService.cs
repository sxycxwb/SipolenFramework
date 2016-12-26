/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-19 16:42:19
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// LogOnService
    /// 登录服务
    /// 
    ///修改纪录
    ///     2016-01-30 版本：3.0 新增UserDimission 用户离职接口
    ///     2016-01-16 版本：3.0 增加LockUser、UnLockUser的接口
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.04.19</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class LogOnService : System.MarshalByRefObject, ILogOnService
    {
        private readonly string serviceName = RDIFrameworkMessage.LogOnService;

        // 当前的锁
        private static object locker = new Object();
        /// <summary>
        /// 单例模式、来提高程序的运行速度
        /// </summary>
        private static readonly PiUserLogOnManager userLogOnManager = new PiUserLogOnManager();

        /// <summary>
        /// RDIFramework.NET框架数据库连接
        /// </summary>
        private readonly string RDIFrameworkDbConection = SystemInfo.RDIFrameworkDbConection;

        #region public UserInfo LogOnByOpenId(UserInfo userInfo, string openId, out string statusCode, out string statusMessage):按唯一识别码登录
        /// <summary>
        /// 按唯一识别码登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public UserInfo LogOnByOpenId(UserInfo userInfo, string openId, out string returnStatusCode, out string returnStatusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            UserInfo returnUserInfo = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                // 先侦测是否在线
                userLogOnManager.CheckOnLine();
                // 再进行登录
                returnUserInfo = userManager.LogOnByOpenId(openId, null, null);
                returnCode = userManager.ReturnStatusCode;
                returnMessage = userManager.GetStateMessage(userManager.ReturnStatusCode);
            });
            returnStatusCode = returnCode;
            returnStatusMessage = returnMessage;
            return returnUserInfo;
        }
        #endregion

        #region public UserInfo LogOnByUserName(UserInfo userInfo, string userName, out string returnStatusCode, out string returnStatusMessage):按唯一识别码登录
        /// <summary>
        /// 按用户名登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public UserInfo LogOnByUserName(UserInfo userInfo, string userName, out string returnStatusCode, out string returnStatusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            UserInfo returnUserInfo = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                // 先侦测是否在线
                userLogOnManager.CheckOnLine();
                // 再进行登录
                returnUserInfo = userManager.LogOnByUserName(userName, userInfo.IPAddress, userInfo.MACAddress);
                returnCode = userManager.ReturnStatusCode;
                returnMessage = userManager.GetStateMessage();
            });
            returnStatusCode = returnCode;
            returnStatusMessage = returnMessage;
            return returnUserInfo;
            return returnUserInfo;
        }
        #endregion

        #region public UserInfo UserLogOn(UserInfo userInfo, string userName, string password,string openId, bool createOpenId, out string returnStatusCode, out string returnStatusMessage) 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="openId">单点登录标识</param>
        /// <param name="createOpenId">重新创建单点登录标识</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public UserInfo UserLogOn(UserInfo userInfo, string userName, string password, string openId, bool createOpenId, out string returnStatusCode, out string returnStatusMessage)
        {
            returnStatusCode = StatusCode.DbError.ToString();
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            UserInfo returnUserInfo = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter,locker,dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo); 
                // 先侦测是否在线
                //userLogOnManager.CheckOnLine();
                // 再进行登录
                returnUserInfo = userManager.LogOn(userName, password, openId, createOpenId);
                returnCode = userManager.ReturnStatusCode;
                returnMessage = userManager.GetStateMessage(returnCode);
            });
            returnStatusCode = returnCode;
            returnStatusMessage = returnMessage;
            return returnUserInfo;
        }
        #endregion

        #region public PiUserLogOnEntity GetEntity(UserInfo userInfo, string id) 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public PiUserLogOnEntity GetEntity(UserInfo userInfo, string id)
        {
            PiUserLogOnEntity entity = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserLogOnManager(dbProvider, userInfo);
                entity = manager.GetEntity(id);
            });
            return entity;
        }
        #endregion

        #region public int Update(UserInfo userInfo, PiUserLogOnEntity entity) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, PiUserLogOnEntity entity)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiUserLogOnManager(dbProvider, userInfo);
                returnValue = manager.Update(entity);
            });

            return returnValue;
        }
        #endregion

        #region public DataTable GetUserDT(UserInfo userInfo):获得用户列表
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_GetUserDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 检查用户在线状态(服务器专用)
                var userManager = new PiUserManager(dbProvider, userInfo);
                userLogOnManager.CheckOnLine();
                // 获取允许登录列表
                string[] names = { PiUserTable.FieldEnabled, PiUserTable.FieldDeleteMark };
                Object[] values = { 1, 0 };
                dataTable = userManager.GetDT(names, values, PiUserTable.FieldSortCode);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetStaffUserDT(UserInfo userInfo):获得内部员工列表
        /// <summary>
        /// 获得内部员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetStaffUserDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_GetStaffUserDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 检查用户在线状态(服务器专用)
                var userManager = new PiUserManager(dbProvider);
                userLogOnManager.CheckOnLine();
                // 获取允许登录列表
                string[] names = { PiUserTable.FieldEnabled, PiUserTable.FieldDeleteMark, PiUserTable.FieldIsStaff };
                Object[] values = { 1, 0, 1 };
                dataTable = userManager.GetDT(names, values, PiStaffTable.FieldSortCode);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public UserInfo AccountActivation(UserInfo userInfo, string openId, out string statusCode, out string statusMessage):激活用户
        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        public UserInfo AccountActivation(UserInfo userInfo, string openId, out string statusCode, out string statusMessage)
        {
            UserInfo returnUserInfo = null;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "激活用户");

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                // 先侦测是否在线
                userLogOnManager.CheckOnLine();
                // 再进行登录
                returnUserInfo = userManager.AccountActivation(openId, out returnCode);
                returnMessage = userManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnUserInfo;
        }
        #endregion

        #region public void OnLine(UserInfo userInfo):用户在线
        /// <summary>
        /// 用户在线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        public void OnLine(UserInfo userInfo, int onLineState = 1)
        {
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter,locker, dbProvider =>
            {
                var manager = new PiUserLogOnManager(dbProvider, userInfo);
                manager.OnLine(userInfo.Id, onLineState);       
            });
        }
        #endregion

        #region public void OnExit(UserInfo userInfo)：用户离线
        /// <summary>
        /// 用户离线
        /// </summary>
        /// <param name="userInfo">用户</param>
        public void OnExit(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_OnExit);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiUserLogOnManager(dbProvider, userInfo);
                manager.OnExit(userInfo.Id);
            });
        }
        #endregion

        #region public int ServerCheckOnLine()：服务器端检查在线状态
        /// <summary>
        /// 服务器端检查在线状态
        /// </summary>
        /// <returns>离线人数</returns>
        public int ServerCheckOnLine()
        {
            int returnValue = 0;

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    dbProvider.Open(RDIFrameworkDbConection);
                    returnValue = userLogOnManager.CheckOnLine();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteException(ex);
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }
            return returnValue;
        }
        #endregion

        #region public int SetPassword(UserInfo userInfo, string[] userIds, string password, out string returnStatusCode, out string returnStatusMessage):设置用户密码
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">被设置的员工主键列表</param>
        /// <param name="password">新密码</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int SetPassword(UserInfo userInfo, string[] userIds, string password, out string returnStatusCode, out string returnStatusMessage)
        {
            int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_SetPassword);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.BatchSetPassword(userIds, password);
                returnCode = userManager.ReturnStatusCode;
                // 获得状态消息
                returnMessage = userManager.GetStateMessage(returnCode);
            });
            returnStatusCode = returnCode;
            returnStatusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int ChangePassword(UserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage):用户修改密码
        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int ChangePassword(UserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage)
        {
            int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_ChangePassword);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.ChangePassword(oldPassword, newPassword, out returnCode);
                // 获得状态消息
                returnMessage = userManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion
        
        #region public static bool UserIsLogOn(UserInfo userInfo):用户是否已经登录了系统？
        /// <summary>
        /// 用户是否已经登录了系统？
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>是否登录</returns>
        public static bool UserIsLogOn(UserInfo userInfo)
        {
            // 加强安全验证防止未授权匿名调用
            if (!SystemInfo.IsAuthorized(userInfo))
            {
                throw new Exception(RDIFrameworkMessage.MSG0800);
            }
            // 这里表示是没登录过的用户
            /*
            if (string.IsNullOrEmpty(userInfo.OpenId))
            {
                throw new Exception(RDIFrameworkMessage.MSG0900);
            }
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);

                if (!userManager.UserIsLogOn(userInfo))
                {
                    throw new Exception(RDIFrameworkMessage.MSG0900);
                }

                returnValue = true;
            });
            return returnValue;
             */
            return true;
        }
        #endregion

        #region public int LockUser(UserInfo userInfo, string userName) 锁定指定用户
        /// <summary>
        /// 锁定指定用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">登录名（用户名）</param>
        /// <returns>大于0锁定成功</returns>
        public int LockUser(UserInfo userInfo, string userName)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_LockUser);
            int result = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(userInfo);
                var parameters = new List<KeyValuePair<string, object>> {
                    new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName),
                    new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1),
                    new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                };
                var entity = BaseEntity.Create<PiUserEntity>(manager.GetDT(parameters, 0, null));
                if ((entity != null) && !string.IsNullOrEmpty(entity.Id))
                {
                    var longOnmanager = new PiUserLogOnManager();
                    PiUserLogOnEntity lonOnentity = longOnmanager.GetEntity(entity.Id);
                    lonOnentity.LockStartDate = DateTime.Now;
                    lonOnentity.LockEndDate = DateTime.Now.AddMinutes(SystemInfo.PasswordErrorLockCycle);
                    result = longOnmanager.Update(lonOnentity);
                }
            });
            return result;
        }
        #endregion

        #region public int UnLockUser(UserInfo userInfo, string userName) 解锁指定用户
        /// <summary>
        /// 解锁指定用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">登录名（用户名）</param>
        /// <returns>大于0解锁成功</returns>
        public int UnLockUser(UserInfo userInfo, string userName)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_UnLockUser);
            int result = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(userInfo);
                var parameters = new List<KeyValuePair<string, object>> {
                    new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName),
                    new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1),
                    new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                };
                var entity = BaseEntity.Create<PiUserEntity>(manager.GetDT(parameters, 0, null));
                if ((entity != null) && !string.IsNullOrEmpty(entity.Id))
                {
                    var longOnmanager = new PiUserLogOnManager();
                    PiUserLogOnEntity lonOnentity = longOnmanager.GetEntity(entity.Id);
                    lonOnentity.LockStartDate = null;
                    lonOnentity.LockEndDate = null;
                    result = longOnmanager.Update(lonOnentity);
                }
            });
            return result;
        }
        #endregion

        #region public int UserDimission(UserInfo userInfo, string userName, string dimissionCause, DateTime? dimissionDate, string dimissionWhither = null) 用户离职
        /// <summary>
        /// 用户离职
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">离职人员用户名</param>
        /// <param name="dimissionCause">离职原因</param>
        /// <param name="dimissionDate">离职日期</param>
        /// <param name="dimissionWhither">离职去向</param>
        /// <returns>大于0操作成功</returns>
        public int UserDimission(UserInfo userInfo, string userName, string dimissionCause, DateTime? dimissionDate, string dimissionWhither = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogOnService_UserDimission);
            int result = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(userInfo);
                var parameters = new List<KeyValuePair<string, object>> {
                    new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName),
                    new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1),
                    new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                };
                var entity = BaseEntity.Create<PiUserEntity>(manager.GetDT(parameters, 0, null));
                if ((entity != null) && !string.IsNullOrEmpty(entity.Id))
                {
                    entity.Enabled = 0;
                    entity.IsDimission = 1;
                    entity.DimissionCause = dimissionCause;
                    entity.DimissionWhither = dimissionWhither;
                    entity.DimissionDate = dimissionDate ?? DateTime.Now;
                    result = manager.Update(entity);
                    //离职的员工就不能登录系统了，应该锁定了
                    var longOnmanager = new PiUserLogOnManager();
                    PiUserLogOnEntity lonOnentity = longOnmanager.GetEntity(entity.Id);
                    lonOnentity.LockStartDate = DateTime.Now;
                    result += longOnmanager.Update(lonOnentity);
                }
            });
            return result;
        }
        #endregion
    }
}
