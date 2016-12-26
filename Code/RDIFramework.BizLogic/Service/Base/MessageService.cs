using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// MessageService
    /// 消息服务
    /// 
    /// 修改记录
    /// 
    ///     2016-01-03 版本：3.0 增加SetDeleted接口方法。
    ///		2014-02-27 版本：2.8 EricHu 建立。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2014-02-27</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MessageService : System.MarshalByRefObject, IMessageService
    {
        private readonly string serviceName = RDIFrameworkMessage.MessageService;

        /// <summary>
        /// 是否有信息被发过来
        /// </summary>
        public static bool MessageSend = true;                 
        
        /// <summary>
        /// 最后检查在线状态时间
        /// </summary>
        public static DateTime LastCheckOnLineState = DateTime.MinValue;  
        
        // 当前的锁
        private static object locker = new Object();

        /// <summary>
        /// 内部组织机构表
        /// </summary>
        public static DataTable InnerOrganizeDT = null;

        /// <summary>
        /// 最后检查组织机构时间
        /// </summary>
        public static DateTime LastCheckOrgTime = DateTime.MinValue;

        /// <summary>
        /// 在线状态表
        /// </summary>
        public static DataTable OnLineStateDT = null;

        #region public DataTable GetInnerOrganize(UserInfo userInfo) 获取内部组织机构
        /// <summary>
        /// 获取内部组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetInnerOrganizeDT(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter, locker, (dbProvider, getOnLine) =>
            {
                var organizeManager = new PiOrganizeManager(dbProvider, userInfo);
                if (MessageService.LastCheckOrgTime == DateTime.MinValue)
                {
                    getOnLine = true;
                }
                else
                {
                    TimeSpan timeSpan = DateTime.Now - MessageService.LastCheckOrgTime;
                    if ((timeSpan.Minutes * 60 + timeSpan.Seconds) >= SystemInfo.OnLineCheck * 100)
                    {
                        getOnLine = true;
                    }
                }
                if (OnLineStateDT == null || getOnLine)
                {
                    string commandText = " SELECT * "
                                        + " FROM " + PiOrganizeTable.TableName
                                        + " WHERE " + PiOrganizeTable.FieldDeleteMark + " = 0 "
                                        + " AND " + PiOrganizeTable.FieldIsInnerOrganize + " = 1 "
                                        + " AND " + PiOrganizeTable.FieldEnabled + " = 1 "
                                        + " ORDER BY " + PiOrganizeTable.FieldSortCode;
                    InnerOrganizeDT = organizeManager.Fill(commandText);
                    InnerOrganizeDT.TableName = PiOrganizeTable.TableName;
                    MessageService.LastCheckOrgTime = DateTime.Now;
                }
                return getOnLine;
            });
          
            return InnerOrganizeDT;
        }
        #endregion

        #region public DataTable GetUserDTByOrganize(UserInfo userInfo, string organizeId) 按组织机构获取用户列表
        /// <summary>
        /// 按组织机构获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDTByOrganize(UserInfo userInfo, string organizeId)
        {
            var dataTable = new DataTable(PiUserTable.TableName);

            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_GetUserDTByOrganize);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);

                string sqlQuery = " SELECT " + PiUserTable.TableName + ".* "
                  + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldUserOnLine
                             + " FROM PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID "
                             + " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 "
                                    + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1  "
                                    + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldIsVisible + " = 1 ) ";

                if (!String.IsNullOrEmpty(organizeId))
                {
                    // 绑定在工作组上的
                    sqlQuery += " AND ((" + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " = '" + organizeId + "') ";
                    // 绑定在部门上的
                    sqlQuery += " OR (" + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " = '" + organizeId + "' AND " + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IS NULL) ";
                    // 绑定在公司上的
                    sqlQuery += " OR (" + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " = '" + organizeId + "' AND " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IS NULL AND " + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IS NULL)) ";
                }
                sqlQuery += " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
                dataTable = userManager.Fill(sqlQuery);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetUserDTByRole(UserInfo userInfo, string roleId) 按角色获取用户列表
        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDTByRole(UserInfo userInfo, string roleId)
        {
            var dataTable = new DataTable(PiUserTable.TableName);

            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_GetUserDTByRole);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);

                //string sqlQuery = " SELECT *"  + " FROM " + PiUserTable.TableName;

                string sqlQuery = " SELECT " + PiUserTable.TableName + ".* "
                                  + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldUserOnLine
                                  + " FROM PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID ";

                sqlQuery += " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 "
                            + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1  "
                            + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldIsVisible + " = 1 ) ";

                if (!String.IsNullOrEmpty(roleId))
                {
                    // 从用户默认角色
                    sqlQuery += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldRoleId + " = '" + roleId + "') ";
                    sqlQuery += " OR " + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN ("
                            + " SELECT " + PiUserRoleTable.FieldUserId
                            + "   FROM " + PiUserRoleTable.TableName
                            + "  WHERE " + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldDeleteMark + " = 0  "
                            + "       AND " + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldEnabled + " = 1  "
                            + "       AND " + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldRoleId + " = '" + roleId + "') ";
                }
                sqlQuery += " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;

                dataTable = userManager.Fill(sqlQuery);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string Send(UserInfo userInfo, string receiverId, string contents) 发送消息
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        public string Send(UserInfo userInfo, string receiverId, string contents)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_Send);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var messageEntity = new CiMessageEntity
                {
                    Id = BusinessLogic.NewGuid(),
                    CategoryCode = MessageCategory.Send.ToString(),
                    FunctionCode = MessageFunction.UserMessage.ToString(),
                    ReceiverId = receiverId,
                    MSGContent = contents,
                    IsNew = (int)MessageStateCode.New,
                    ReadCount = 0,
                    DeleteMark = 0,
                    Enabled = 1
                };
                var messageManager = new CiMessageManager(dbProvider, userInfo);
                messageManager.Send(messageEntity);
            });
            return returnValue;
        }
        #endregion

        #region public string SendGroupMessage(UserInfo userInfo, string organizeId, string roleId, string contents) 发送组消息
        /// <summary>
        /// 发送组消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="contents">内容</param>
        /// <returns></returns>
        public string SendGroupMessage(UserInfo userInfo, string organizeId, string roleId, string contents)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var messageEntity = new CiMessageEntity
                {
                    Id = BusinessLogic.NewGuid(),
                    CategoryCode = MessageCategory.Send.ToString(),
                    MSGContent = contents,
                    IsNew = (int)MessageStateCode.New,
                    ReadCount = 0,
                    DeleteMark = 0,
                    Enabled = 1
                };
                if (!string.IsNullOrEmpty(organizeId))
                {
                    messageEntity.FunctionCode = MessageFunction.OrganizeMessage.ToString();
                    messageEntity.ObjectId = organizeId;
                }
                if (!string.IsNullOrEmpty(roleId))
                {
                    messageEntity.FunctionCode = MessageFunction.RoleMessage.ToString();
                    messageEntity.ObjectId = roleId;
                }

                var messageManager = new CiMessageManager(dbProvider, userInfo);
                returnValue = messageManager.BatchSend(string.Empty, organizeId, roleId, messageEntity, false);
            });
            return returnValue.ToString();
        }
        #endregion

        #region public string Remind(UserInfo userInfo, string receiverId, string contents) 发送系统提示消息
        /// <summary>
        /// 发送系统提示消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        public string Remind(UserInfo userInfo, string receiverId, string contents)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "发送系统提示消息");

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var entity = new CiMessageEntity
                {
                    Id = BusinessLogic.NewGuid(),
                    CategoryCode = MessageCategory.Receiver.ToString(),
                    FunctionCode = MessageFunction.Remind.ToString(),
                    ReceiverId = receiverId,
                    MSGContent = contents,
                    IsNew = (int)MessageStateCode.New,
                    ReadCount = 0,
                    DeleteMark = 0,
                    Enabled = 1
                };
                var manager = new CiMessageManager(dbProvider, userInfo);
                returnValue = manager.Add(entity);
            });

            return returnValue;
        }
        #endregion

        #region public int BatchSend(UserInfo userInfo, string[] receiverIds, string[] organizeIds, string[] roleIds, CiMessageEntity messageEntity)  批量发送站内信息
        /// <summary>
        /// 批量发送站内信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverIds">接受者主键数组</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="messageEntity">消息内容</param>
        /// <returns>影响行数</returns>
        public int BatchSend(UserInfo userInfo, string[] receiverIds, string[] organizeIds, string[] roleIds, CiMessageEntity messageEntity)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_BatchSend);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var messageManager = new CiMessageManager(dbProvider, userInfo);
                returnValue = messageManager.BatchSend(receiverIds, organizeIds, roleIds, messageEntity, true);
            });
            return returnValue;
        }
        #endregion

        #region public int Broadcast(UserInfo userInfo, string message) 广播消息
        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="message">消息内容</param>
        /// <returns>主键</returns>
        public int Broadcast(UserInfo userInfo, string message)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "广播消息");

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                string[] receiverIds = null;
                var userManager = new PiUserManager(dbProvider, userInfo);
                receiverIds = userManager.GetIds(new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1), new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0));
                var messageManager = new CiMessageManager(dbProvider, userInfo);
                var messageEntity = new CiMessageEntity
                {
                    Id = BusinessLogic.NewGuid(),
                    FunctionCode = MessageFunction.Remind.ToString(),
                    MSGContent = message,
                    IsNew = 1,
                    ReadCount = 0,
                    Enabled = 1,
                    DeleteMark = 0
                };
                returnValue = messageManager.BatchSend(receiverIds, string.Empty, string.Empty, messageEntity, false);
            });
            return returnValue;
        }
        #endregion

        #region public string[] MessageChek(UserInfo userInfo, string lastChekDate) 获取消息状态
        /// <summary>
        /// 获取消息状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <param name="lastChekDate">最后检查日期</param>
        /// <returns>消息状态数组</returns>
        public string[] MessageChek(UserInfo userInfo, int onLineState, string lastChekDate)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_MessageChek);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            { 
                // 设置为在线状态
                var manager = new PiUserLogOnManager(dbProvider, userInfo);
                manager.OnLine(userInfo.Id, onLineState);
                // 读取信息状态
                var messageManager = new CiMessageManager(dbProvider, userInfo);
                returnValue = messageManager.MessageChek();
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetDTNew(UserInfo userInfo, out string openId) 获取用户的新信息
        /// <summary>
        /// 获取用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">单点登录标识</param>
        /// <returns>数据表</returns>
        public DataTable GetDTNew(UserInfo userInfo, out string openId)
        {
            var dataTable = new DataTable(CiMessageTable.TableName);
            string myOpenId = userInfo.OpenId;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                if (!SystemInfo.CheckOnLine)
                {
                    var manager = new PiUserLogOnManager(dbProvider, userInfo);
                    myOpenId = manager.GetProperty(userInfo.Id, PiUserLogOnTable.FieldOpenId);
                }

                if (userInfo.OpenId.Equals(myOpenId))
                {
                    var messageManager = new CiMessageManager(dbProvider, userInfo);
                    dataTable = messageManager.GetDTNew();
                    dataTable.TableName = CiMessageTable.TableName;
                }
            });
            openId = myOpenId;
            return dataTable;
        }
        #endregion

        #region public DataTable ReadFromReceiver(UserInfo userInfo, string receiverId) 获取特定用户的新信息
        /// <summary>
        /// 获取特定用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">当前交互的用户</param>
        /// <returns>数据表</returns>
        public DataTable ReadFromReceiver(UserInfo userInfo, string receiverId)
        {
            var dataTable = new DataTable(CiMessageTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_ReadFromReceiver);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var messageManager = new CiMessageManager(dbProvider, userInfo);
                dataTable = messageManager.ReadFromReceiver(receiverId);
                dataTable.TableName = CiMessageTable.TableName;
            });

            return dataTable;
        }
        #endregion

        #region public void Read(UserInfo userInfo, string id) 阅读消息
        /// <summary>
        /// 阅读消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        public void Read(UserInfo userInfo, string id)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_Read);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider => new CiMessageManager(dbProvider, userInfo).Read(id));
        }
        #endregion

        #region public int CheckOnLine(UserInfo userInfo, int onLineState) 检查在线状态
        /// <summary>
        /// 检查在线状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <returns>离线人数</returns>
        public int CheckOnLine(UserInfo userInfo, int onLineState)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserLogOnManager(dbProvider);
                // 设置为在线状态
                manager.OnLine(userInfo.Id, onLineState);
                returnValue = manager.CheckOnLine();
            });
            return returnValue;
        }
        #endregion
        
        #region public DataTable GetOnLineState(UserInfo userInfo) 获取在线用户列表
        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetOnLineState(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter, locker, (dbProvider, getOnLine) =>
            {
                var manager = new PiUserLogOnManager(dbProvider);
                // 设置为在线状态
                manager.OnLine(userInfo.Id);
                if (MessageService.LastCheckOnLineState == DateTime.MinValue)
                {
                    getOnLine = true;
                }
                else
                {
                    TimeSpan timeSpan = DateTime.Now - MessageService.LastCheckOnLineState;
                    if ((timeSpan.Minutes * 60 + timeSpan.Seconds) >= SystemInfo.OnLineCheck)
                    {
                        getOnLine = true;
                    }
                }

                if (OnLineStateDT == null || getOnLine)
                {
                    // 检查用户在线状态(服务器专用)
                    manager.CheckOnLine();
                    // 获取在线状态列表
                    OnLineStateDT = manager.GetOnLineStateDT();
                    OnLineStateDT.TableName = PiUserTable.TableName;
                    MessageService.LastCheckOnLineState = DateTime.Now;
                }
                return getOnLine;
            });
            return OnLineStateDT;
        }
        #endregion

        #region public DataTable GetUserSentMessagesByPage(UserInfo userInfo,string userId, string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null) 得到指定用户已发送的消息
        /// <summary>
        /// 得到指定用户已发送的消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">指定用户主键</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetUserSentMessagesByPage(UserInfo userInfo,string userId,string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_GetMySentMessagesByPage);
            int myrecordCount = 0;
            var dataTable = new DataTable(CiMessageTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbProvider) =>
            {
                if (string.IsNullOrEmpty(userId)) 
                {
                    userId = userInfo.Id;
                }

                var messageManager = new CiMessageManager(dbProvider, userInfo);
                dataTable = messageManager.GetUserSentMessagesByPage(whereConditional,out myrecordCount, userId, pageIndex, pageSize, order);
                dataTable.TableName = CiMessageTable.TableName;

            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable GetUserReceivedMessagesByPage(UserInfo userInfo, string userId, string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null) 得到指定用户收到的消息
        /// <summary>
        /// 得到指定用户收到的消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">指定用户主键</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetUserReceivedMessagesByPage(UserInfo userInfo, string userId, string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_GetUserReceivedMessagesByPage);
            int myrecordCount = 0;
            var dataTable = new DataTable(CiMessageTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbProvider) =>
            {
                if (string.IsNullOrEmpty(userId))
                {
                    userId = userInfo.Id;
                }

                var messageManager = new CiMessageManager(dbProvider, userInfo);
                dataTable = messageManager.GetUserReceivedMessagesByPage(whereConditional,out myrecordCount, userId, pageIndex, pageSize, order);
                dataTable.TableName = CiMessageTable.TableName;

            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable GetMessagesByConditional(UserInfo userInfo,string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null) 通过指定条件得到消息
        /// <summary>
        /// 通过指定条件得到消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="whereConditional">指定条件表达式</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetMessagesByConditional(UserInfo userInfo,string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_GetMessagesByConditional);
            int myrecordCount = 0;
            var dataTable = new DataTable(CiMessageTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbProvider) =>
            {
                var messageManager = new CiMessageManager(dbProvider, userInfo);              
                dataTable = messageManager.GetMessagesByConditional(whereConditional,userInfo.IsAdministrator, out myrecordCount, pageIndex, pageSize, order);
                dataTable.TableName = CiMessageTable.TableName;

            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids):批量逻辑删除消息
        /// <summary>
        ///  批量逻辑删除消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        public int SetDeleted(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.MessageService_SetDeleted);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new CiMessageManager(dbProvider, userInfo).SetDeleted(ids);
            });

            return returnValue;
        }
        #endregion

        #region public CiMessageEntity GetEntity(UserInfo userInfo, string id):取得实体
        /// <summary>
        /// 取得实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiMessageEntity GetEntity(UserInfo userInfo, string id)
        {
            CiMessageEntity entity = null;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entity = new CiMessageManager(dbProvider, userInfo).GetEntity(id);
            });
            return entity;
        }
        #endregion
    }
}