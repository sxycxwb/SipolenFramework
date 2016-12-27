using System;
using System.Collections.Generic;
using System.Data;
using RDIFramework.Utilities;

namespace RDIFramework.BizLogic
{

    /// <summary>
    /// CiMessageManager
    /// 信息服务管理器
    /// 
    /// 修改纪录
    /// 
    /// 2014-03-01 版本：2.8 创建主键。
    /// 
    /// 版本：2.8
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-03-01</date>
    /// </author>
    /// </summary>
    public partial class CiMessageManager
    {
        private string Query = " SELECT * FROM " + CiMessageTable.TableName;

        #region public int Send(CiMessageEntity messageEntity, bool saveSend = true) 添加短信，只能发给一个人
        /// <summary>
        /// 添加一条短信，只能发给一个人，在数据库中加入两条记录
        /// </summary>
        /// <param name="messageEntity">添加对象</param>
        /// <returns>影响行数</returns>
        public int Send(CiMessageEntity messageEntity, bool saveSend = true)
        {
            string[] receiverIds = new string[1];
            receiverIds[0] = messageEntity.ReceiverId.ToString();
            return this.Send(messageEntity, receiverIds, saveSend);
        }
        #endregion

        #region public int Send(CiMessageEntity messageEntity, string[] receiverIds, bool saveSend = true) 添加短信，可以发给多个人
        /// <summary>
        /// 添加短信，可以发给多个人
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="receiverIds">接收者ID组</param>
        /// <returns>影响行数</returns>
        public int Send(CiMessageEntity messageEntity, string[] receiverIds, bool saveSend = true)
        {
            PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
            // 每发一条短信，数据库中需要记录两条记录，他们的CreateUserId都为创建者ID。
            // 接收者多人的话，不要重复设置创建人的记录了，即对发送者来说，只要记录一条记录就够了  
            int returnValue = 0;
            messageEntity.CategoryCode = MessageCategory.Receiver.ToString();
            messageEntity.IsNew = (int)MessageStateCode.New;
            messageEntity.IPAddress = UserInfo.IPAddress;
            messageEntity.ParentId = null;
            messageEntity.DeleteMark = 0;
            messageEntity.Enabled = 1;
            returnValue++;
            
            PiUserEntity userEntity = null;
            for (int i = 0; i < receiverIds.Length; i++)
            {
                messageEntity.ParentId = null;
                messageEntity.Id = Guid.NewGuid().ToString();
                messageEntity.CategoryCode = MessageCategory.Receiver.ToString();
                messageEntity.ReceiverId = receiverIds[i];
                userEntity = userManager.GetEntity(receiverIds[i]);
                if (userEntity != null && userEntity.Id != null)
                {
                    messageEntity.ReceiverRealName = userEntity.RealName;
                  
                }
                messageEntity.Enabled = 1;
                messageEntity.IsNew = 1;
                if (messageEntity.ReceiverId.Equals(UserInfo.Id))
                {
                    messageEntity.IsNew = (int)MessageStateCode.Old;
                }
                // 接收信息
                string parentId = this.Add(messageEntity, false, false);
                if (saveSend)
                {
                    // 已发送信息
                    messageEntity.Id = Guid.NewGuid().ToString();
                    messageEntity.ParentId = parentId;
                    messageEntity.CategoryCode = MessageCategory.Send.ToString();
                    messageEntity.DeleteMark = 0;
                    messageEntity.Enabled = 0;
                    this.Add(messageEntity, false, false);
                }
                returnValue++;
            }
            return returnValue;
        }
        #endregion

        #region public int Send(CiMessageEntity messageEntity, string organizeId, bool saveSend = true) 按部门群发短信
        /// <summary>
        /// 按部门群发短信
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="organizeId">部门主键</param>
        /// <returns>影响行数</returns>
        public int Send(CiMessageEntity messageEntity, string organizeId, bool saveSend = true)
        {
            int returnValue = 0;
            int i = 0;
            PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
            DataTable dataTable = userManager.GetChildrenUsers(organizeId);
            string[] receiverIds = new string[dataTable.Rows.Count];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                receiverIds[i++] = dataRow[CiMessageTable.FieldId].ToString();
            }
            returnValue = this.Send(messageEntity, receiverIds, saveSend);
            return returnValue;
        }
        #endregion

        public int BatchSend(string[] receiverIds, string organizeId, string roleId, CiMessageEntity messageEntity, bool saveSend = true)
        {
            string[] organizeIds = null;
            string[] roleIds = null;
            if (!string.IsNullOrEmpty(organizeId))
            {
                organizeIds = new string[] { organizeId };
            }
            if (!string.IsNullOrEmpty(roleId))
            {
                roleIds = new string[] { roleId };
            }
            return BatchSend(receiverIds, organizeIds, roleIds, messageEntity, saveSend);
        }

        public int BatchSend(string receiverId, string organizeId, string roleId, CiMessageEntity messageEntity, bool saveSend = true)
        {
            string[] receiverIds = null;
            string[] organizeIds = null;
            string[] roleIds = null;
            if (!string.IsNullOrEmpty(receiverId))
            {
                receiverIds = new string[] { receiverId };
            }
            if (!string.IsNullOrEmpty(organizeId))
            {
                organizeIds = new string[] { organizeId };
            }
            if (!string.IsNullOrEmpty(roleId))
            {
                roleIds = new string[] { roleId };
            }
            return BatchSend(receiverIds, organizeIds, roleIds, messageEntity, saveSend);
        }

        #region public int BatchSend(string[] receiverIds, string[] organizeIds, string[] roleIds, CiMessageEntity messageEntity, bool saveSend  = true) 批量发送消息
        /// <summary>
        /// 批量发送消息
        /// </summary>
        /// <param name="receiverIds">接收者主键组</param>
        /// <param name="organizeIds">组织机构主键组</param>
        /// <param name="roleIds">角色主键组</param>
        /// <param name="messageEntity">实体</param>
        /// <returns>影响行数</returns>
        public int BatchSend(string[] receiverIds, string[] organizeIds, string[] roleIds, CiMessageEntity messageEntity, bool saveSend = true)
        {
            PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
            receiverIds = userManager.GetUserIds(receiverIds, organizeIds, roleIds);
            return this.Send(messageEntity, receiverIds, saveSend);
        }
        #endregion

        #region public int GetNewCount() 获取新信息个数
        /// <summary>
        /// 获取新信息个数
        /// </summary>
        /// <returns>记录个数</returns>
        public int GetNewCount()
        {
            return this.GetNewCount(MessageFunction.Message);
        }
        #endregion

        #region public int GetNewCount(MessageFunction messageFunction) 获取新信息个数
        /// <summary>
        /// 获取新信息个数，类别应该是收的信息，不是发的信息
        /// </summary>
        /// <returns>记录个数</returns>
        public int GetNewCount(MessageFunction messageFunction)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(*) "
                            + "   FROM " + CiMessageTable.TableName
                            + "  WHERE (" + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + "        AND (" + CiMessageTable.FieldCategoryCode + " = 'Receiver' )"
                            + "        AND (" + CiMessageTable.FieldReceiverId + " = '" + UserInfo.Id + "' )"
                            + "        AND (" + CiMessageTable.FieldDeleteMark + " = 0 )"
                            + "        AND (" + CiMessageTable.FieldFunctionCode + " = '" + messageFunction.ToString() + "' )";
            object returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        #region public CiMessageEntity GetNewOne() 获取最新一条信息
        /// <summary>
        /// 获取最新一条信息
        /// </summary>
        /// <returns>记录个数</returns>
        public CiMessageEntity GetNewOne()
        {
            //CiMessageEntity messageEntity = new CiMessageEntity();
            string sqlQuery = " SELECT * "
                            + "   FROM (SELECT * FROM " + CiMessageTable.TableName + " WHERE (" + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + "         AND (" + CiMessageTable.FieldReceiverId + " = '" + UserInfo.Id + "') "
                            + " ORDER BY " + CiMessageTable.FieldCreateOn + " DESC) "
                            + " WHERE ROWNUM = 1 ";
            DataTable dataTable = DBProvider.Fill(sqlQuery);            
            //return messageEntity.GetFrom(dataTable);
            return BaseEntity.Create<CiMessageEntity>(dataTable);
        }
        #endregion

        #region public string[] MessageChek() 检查信息状态
        /// <summary>
        /// 检查信息状态
        /// </summary>
        /// <returns>信息状态数组</returns>
        public string[] MessageChek()
        {
            string[] returnValue = new string[6];
            // 0.新信息的个数
            int messageCount = this.GetNewCount();
            returnValue[0] = messageCount.ToString();
            if (messageCount > 0)
            {
                CiMessageEntity messageEntity = this.GetNewOne();
                DateTime lastChekDate = DateTime.MinValue;
                if (messageEntity.CreateOn != null)
                {
                    // 1.最后检查时间
                    lastChekDate = Convert.ToDateTime(messageEntity.CreateOn);
                    returnValue[1] = lastChekDate.ToString(SystemInfo.DateTimeFormat);
                }
                returnValue[2] = messageEntity.CreateUserId; // 2.最新消息的发出者
                returnValue[3] = messageEntity.CreateBy; // 3.最新消息的发出者名称
                returnValue[4] = messageEntity.Id;            // 4.最新消息的主键
                returnValue[5] = messageEntity.MSGContent;       // 5.最新信息的内容
            }
            return returnValue;
        }
        #endregion

        #region public DataTable Read(string id) 阅读短信
        /// <summary>
        /// 阅读短信
        /// </summary>
        /// <param name="id">短信ID</param>
        /// <returns>数据权限</returns>
        public DataTable Read(string id)
        {
            // 这里需要改进一下，运行一个高性能的sql语句就可以了，效率会高一些
            DataTable dataTable = this.GetDTById(id);
            CiMessageEntity messageEntity = BaseEntity.Create<CiMessageEntity>(dataTable); 
            this.OnRead(messageEntity, id);
            dataTable = this.GetDTById(id);
            return dataTable;
        }
        #endregion

        #region private int OnRead(CiMessageEntity messageEntity, string id) 阅读短信后设置状态值和阅读次数
        /// <summary>
        /// 阅读短信后设置状态值和阅读次数
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="id">短信主键</param>
        /// <returns>影响的条数</returns>
        private int OnRead(CiMessageEntity messageEntity, string id)
        {
            int returnValue = 0;
            // 针对“已发送”的情况
            if (messageEntity.ReceiverId == UserInfo.Id)
            {
                // 针对“删除的信息”的情况
                if (messageEntity.IsNew == (int)MessageStateCode.New)
                {
                    SQLBuilder sqlBuilder = new SQLBuilder(this.DBProvider);
                    sqlBuilder.BeginUpdate(this.CurrentTableName);
                    sqlBuilder.SetValue(CiMessageTable.FieldIsNew, ((int)MessageStateCode.Old).ToString());
                    sqlBuilder.SetDBNow(CiMessageTable.FieldReadDate);
                    sqlBuilder.SetWhere(CiMessageTable.FieldId, id);
                    sqlBuilder.EndUpdate();
                }
            }
            // 增加阅读次数
            messageEntity.ReadCount++;
            this.SetProperty(id, CiMessageTable.FieldReadCount, messageEntity.ReadCount.ToString());
           
            returnValue++;
            return returnValue;
        }
        #endregion

        #region public DataTable ReadFromReceiver(string receiverId) 获取当前即时聊天者的所有新信息
        /// <summary>
        /// 获取当前即时聊天者的所有新信息
        /// </summary>
        /// <param name="receiverId">目标聊天者</param>
        /// <returns>数据表</returns>
        public DataTable ReadFromReceiver(string receiverId)
        {
            // 读取发给我的信息
            string sqlQuery = this.Query
                            + " WHERE (" + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + " AND (" + CiMessageTable.FieldReceiverId + " = '" + UserInfo.Id + "' ) "
                            + " AND (" + CiMessageTable.FieldCreateUserId + " = '" + receiverId + "' ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            DataTable dataTable = DBProvider.Fill(sqlQuery);
            // 标记为已读
            string id = string.Empty;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 这是别人发过来的信息
                if (dataRow[CiMessageTable.FieldReceiverId].ToString() == UserInfo.Id)
                {
                    id = dataRow[CiMessageTable.FieldId].ToString();
                    this.SetProperty(id, CiMessageTable.FieldIsNew, (int)MessageStateCode.Old);
                }
            }
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTNew() 获取我的未读短信列表
        /// <summary>
        /// 获取我的未读短信列表
        /// </summary>		
        /// <returns>数据表</returns>
        public DataTable GetDTNew()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(CiMessageTable.FieldReceiverId, this.UserInfo.Id),
                new KeyValuePair<string, object>(CiMessageTable.FieldCategoryCode, "Receiver"),
                new KeyValuePair<string, object>(CiMessageTable.FieldIsNew, (int) MessageStateCode.New),
                new KeyValuePair<string, object>(CiMessageTable.FieldDeleteMark, 0),
                new KeyValuePair<string, object>(CiMessageTable.FieldEnabled, 1)
            };
            return this.GetDT(parameters, 20, CiMessageTable.FieldCreateUserId + "," + CiMessageTable.FieldCreateOn);

            /*
            string sqlQuery = "   SELECT TOP 10 * "
                            + "     FROM " + CiMessageTable.TableName
                            + "    WHERE " + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString()
                            + "          AND " + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId)
                            + "          AND " + CiMessageTable.FieldDeleteMark + " = 0 "
                            + "          AND " + CiMessageTable.FieldEnabled + " = 1 "
                            + " ORDER BY " + CiMessageTable.FieldCreateUserId
                            + "          ," + CiMessageTable.FieldCreateOn;
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            DBProvider.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(CiMessageTable.FieldReceiverId, UserInfo.Id) });
            return dataTable;
            */
        }
        #endregion

        #region public DataTable SearchNewList(string searchValue) 查询我的未读短信列表
        /// <summary>
        /// 查询我的未读短信列表
        /// </summary>
        /// <param name="searchValue">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchNewList(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetDTNew();
            }
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + CiMessageTable.FieldMSGContent + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldMSGContent) + " ) "
                            + " OR ( " + CiMessageTable.FieldTitle + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " ) "
                            + " OR ( " + CiMessageTable.FieldReceiverRealName + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " )) "
                            + " AND (" + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + " AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            for (int i = 0; i < 3; i++)
            {
                names[i] = CiMessageTable.FieldMSGContent;
                values[i] = searchValue;
            }
            names[3] = CiMessageTable.FieldReceiverId;
            values[3] = UserInfo.Id;
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetOldDT() 获取我的已读短信列表
        /// <summary>
        /// 获取我的已读短信列表
        /// </summary>		
        /// <returns>数据权限</returns>
        public DataTable GetOldDT()
        {
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            string sqlQuery = this.Query
                            + " WHERE (" + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.Old).ToString() + " ) "
                            + " AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = CiMessageTable.FieldReceiverId;
            values[0] = UserInfo.Id;
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable SearchOldDT(string searchValue) 查询我的已读短信列表
        /// <summary>
        /// 查询我的已读短信列表
        /// </summary>
        /// <param name="searchValue">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchOldDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetOldDT();
            }
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + CiMessageTable.FieldMSGContent + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldMSGContent) + " ) "
                            + " OR (" + CiMessageTable.FieldReceiverRealName + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " ) "
                            + " OR (" + CiMessageTable.FieldCreateOn + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldCreateOn) + " )) "
                            + " AND (" + CiMessageTable.FieldIsNew + " = " + ((int)MessageStateCode.Old).ToString() + " ) "
                            + " AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            for (int i = 0; i < 3; i++)
            {
                names[i] = CiMessageTable.FieldMSGContent;
                values[i] = searchValue;
            }
            names[3] = CiMessageTable.FieldReceiverId;
            values[3] = UserInfo.Id;
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByFunction(string categoryId, string functionId, string userId) 按消息功能获取消息列表
        /// <summary>
        /// 按消息功能获取消息列表
        /// </summary>
        /// <param name="categoryCode">消息分类</param>
        /// <param name="functionCode">消息功能</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByFunction(string categoryCode, string functionCode, string userId)
        {
            string sqlQuery = this.Query
                            + "    WHERE (" + CiMessageTable.FieldDeleteMark + " = 0 ) "
                            + "          AND (" + CiMessageTable.FieldCategoryCode + " = '" + categoryCode + "') ";
            if (!String.IsNullOrEmpty(functionCode))
            {
                sqlQuery += "          AND (" + CiMessageTable.FieldFunctionCode + " = '" + functionCode + "' ) ";
            }
            if (categoryCode.Equals(MessageCategory.Send.ToString()))
            {
                // 已经发送出去的信息
                sqlQuery += "          AND (" + CiMessageTable.FieldCreateUserId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + ") ";
            }
            else
            {
                // 已收到的信息
                sqlQuery += "          AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + ") ";
            }

            sqlQuery += " ORDER BY " + CiMessageTable.FieldIsNew + " DESC "
                     + "          ," + CiMessageTable.FieldCreateOn;
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            DBProvider.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(CiMessageTable.FieldReceiverId, userId) });
            return dataTable;
        }
        #endregion

        public DataTable GetReceiveDT()
        {
            return this.GetDTByFunction(MessageCategory.Receiver.ToString(), MessageFunction.Message.ToString(), UserInfo.Id);
        }

        public DataTable SearchReceiveDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetReceiveDT();
            }
            searchValue = StringHelper.GetSearchString(searchValue);

            string sqlQuery = this.Query
                            + "    WHERE (" + CiMessageTable.FieldDeleteMark + " = 0 ) "
                            + "          AND (" + CiMessageTable.FieldCategoryCode + " = '" + MessageCategory.Receiver.ToString() + "') ";
            sqlQuery += "          AND (" + CiMessageTable.FieldFunctionCode + " = '" + MessageFunction.Message.ToString() + "' ) ";
            // 已收到的信息
            sqlQuery += "          AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + ") ";

            sqlQuery += " AND ((" + CiMessageTable.FieldTitle + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldTitle) + " ) "
                      + " OR (" + CiMessageTable.FieldMSGContent + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldMSGContent) + " ) "
                      + " OR (" + CiMessageTable.FieldCreateBy + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldCreateBy) + " )) ";


            sqlQuery += " ORDER BY " + CiMessageTable.FieldIsNew + " DESC "
                     + "          ," + CiMessageTable.FieldCreateOn + " DESC "
                     + "          ," + CiMessageTable.FieldCreateUserId;
            DataTable dataTable = new DataTable(CiMessageTable.TableName);

            string[] names = new string[4];
            Object[] values = new Object[4];
            names[0] = CiMessageTable.FieldReceiverId;
            values[0] = UserInfo.Id;
            names[1] = CiMessageTable.FieldTitle;
            values[1] = searchValue;
            names[2] = CiMessageTable.FieldMSGContent;
            values[2] = searchValue;
            names[3] = CiMessageTable.FieldCreateBy;
            values[3] = UserInfo.Id;
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            return dataTable;
        }

        public DataTable GetWarningDT()
        {
            return this.GetDTByFunction(MessageCategory.Receiver.ToString(), MessageFunction.Warning.ToString(), UserInfo.Id);
        }

        public DataTable GetWarningDT(string userId)
        {
            return this.GetDTByFunction(MessageCategory.Receiver.ToString(), MessageFunction.Warning.ToString(), userId);
        }

        public DataTable GetWarningDT(string userId, int topN)
        {
            return this.SearchWarningDT(string.Empty, userId, topN);
        }

        public DataTable SearchWarningDT(string searchValue)
        {
            return this.SearchWarningDT(searchValue, UserInfo.Id);
        }

        public DataTable SearchWarningDT(string search, string userId)
        {
            return SearchWarningDT(search, userId, 0);
        }

        public DataTable SearchWarningDT(string search, string userId, int topN)
        {
            if (search.Length == 0 && topN == 0)
            {
                return this.GetWarningDT();
            }
            search = StringHelper.GetSearchString(search);

            string sqlQuery = " SELECT ";
            if (topN != 0)
            {
                sqlQuery += " TOP " + topN.ToString();
            }
            sqlQuery += " * FROM " + CiMessageTable.TableName

                            + "    WHERE (" + CiMessageTable.FieldDeleteMark + " = 0 ) "
                            + "          AND (" + CiMessageTable.FieldCategoryCode + " = '" + MessageCategory.Receiver.ToString() + "') ";
            sqlQuery += "          AND (" + CiMessageTable.FieldFunctionCode + " = '" + MessageFunction.Warning.ToString() + "' ) ";
            // 已收到的信息
            sqlQuery += "          AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + ") ";

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>
            {
                DBProvider.MakeParameter(CiMessageTable.FieldReceiverId, userId)
            };

            if (!String.IsNullOrEmpty(search))
            {
                sqlQuery += " AND ((" + CiMessageTable.FieldTitle + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldTitle) + " ) "
                          + " OR (" + CiMessageTable.FieldMSGContent + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldMSGContent) + " ) "
                          + " OR (" + CiMessageTable.FieldCreateBy + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldCreateBy) + " )) ";

                dbParameters.Add(DBProvider.MakeParameter(CiMessageTable.FieldTitle, search));
                dbParameters.Add(DBProvider.MakeParameter(CiMessageTable.FieldMSGContent, search));
                dbParameters.Add(DBProvider.MakeParameter(CiMessageTable.FieldCreateBy, search));
            }

            sqlQuery += " ORDER BY " + CiMessageTable.FieldIsNew + " DESC "
                     + "          ," + CiMessageTable.FieldCreateOn + " DESC ";
            DataTable dataTable = new DataTable(CiMessageTable.TableName);

            DBProvider.Fill(dataTable, sqlQuery, dbParameters.ToArray());
            return dataTable;
        }

        #region public DataTable GetSendDT() 获取我的已发送短信列表
        /// <summary>
        /// 获取我的已发送短信列表
        /// </summary>		
        /// <returns>数据权限</returns>
        public DataTable GetSendDT()
        {
            string sqlQuery = this.Query
                            + " WHERE (" + CiMessageTable.FieldCategoryCode + " = '" + (MessageCategory.Send).ToString() + "') "
                            + " AND (" + CiMessageTable.FieldDeleteMark + " = 0) "
                            + " AND (" + CiMessageTable.FieldCreateUserId + " = '" + UserInfo.Id + "') "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable SearchSendDT(string searchValue) 查询我的已发送短信列表
        /// <summary>
        /// 查询我的已发送短信列表
        /// </summary>
        /// <param name="searchValue">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchSendDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetSendDT();
            }
            searchValue = StringHelper.GetSearchString(searchValue);
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + CiMessageTable.FieldMSGContent + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldMSGContent) + " ) "
                            + " OR (" + CiMessageTable.FieldReceiverRealName + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldReceiverRealName) + " ) "
                            + " OR (" + CiMessageTable.FieldCreateOn + " LIKE " + DBProvider.GetParameter(CiMessageTable.FieldCreateOn) + " )) "
                            + " AND (" + CiMessageTable.FieldDeleteMark + " = 0) "
                            + " AND (" + CiMessageTable.FieldCategoryCode + " = '" + (MessageCategory.Send).ToString() + "') "
                            + " AND (" + CiMessageTable.FieldCreateUserId + " = " + DBProvider.GetParameter(CiMessageTable.FieldCreateUserId) + " ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            names[0] = CiMessageTable.FieldMSGContent;
            values[0] = searchValue;
            names[1] = CiMessageTable.FieldReceiverRealName;
            values[1] = searchValue;
            names[2] = CiMessageTable.FieldCreateOn;
            values[2] = searchValue;
            names[3] = CiMessageTable.FieldCreateUserId;
            values[3] = UserInfo.Id;
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetDeletedDT() 获取我的删除的短信列表
        /// <summary>
        /// 获取我的删除的短信列表
        /// </summary>		
        /// <returns>数据权限</returns>
        public DataTable GetDeletedDT()
        {
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            string sqlQuery = this.Query
                            + " WHERE (" + CiMessageTable.FieldDeleteMark + " = 1 ) "
                            + " AND (" + CiMessageTable.FieldReceiverId + " = " + DBProvider.GetParameter(CiMessageTable.FieldReceiverId) + " ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            DBProvider.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(CiMessageTable.FieldReceiverId, UserInfo.Id) });
            return dataTable;
        }
        #endregion

        #region public DataTable SearchDeletedDT(string searchValue) 查询我的已删除短信列表
        /// <summary>
        /// 查询我的已删除短信列表
        /// </summary>
        /// <param name="searchValue">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchDeletedDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetDeletedDT();
            }
            DataTable dataTable = new DataTable(CiMessageTable.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + CiMessageTable.FieldMSGContent + " LIKE ? ) "
                            + " OR ( " + CiMessageTable.FieldReceiverRealName + " LIKE ? ) "
                            + " OR (" + CiMessageTable.FieldCreateOn + " LIKE ? )) "
                            + " AND (" + CiMessageTable.FieldDeleteMark + " = 1 ) "
                            + " AND (" + CiMessageTable.FieldReceiverId + " = ? ) "
                            + " ORDER BY " + CiMessageTable.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            for (int i = 0; i < 3; i++)
            {
                names[i] = CiMessageTable.FieldMSGContent;
                values[i] = searchValue;
            }
            names[3] = CiMessageTable.FieldReceiverId;
            values[3] = UserInfo.Id;
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        /// <summary>
        /// 得到指定用户已发送的消息
        /// </summary>      
        public DataTable GetUserSentMessagesByPage(string whereConditional,out int recordCount,string userId, int pageIndex, int pageSize, string order)
        {
            if (!string.IsNullOrEmpty(whereConditional))
            {
                whereConditional += " AND ";
            }

            whereConditional += CiMessageTable.FieldDeleteMark + " = 0 AND "
                                + CiMessageTable.FieldEnabled + " = 1 AND "
                                + CiMessageTable.FieldCreateUserId + " = '" + userId + "'";

            if (string.IsNullOrEmpty(order))
            {
                order = CiMessageTable.FieldCreateOn + " DESC ";
            }
            return this.GetDTByPage(out recordCount, pageIndex, pageSize, whereConditional, order);
        }

        /// <summary>
        /// 得到指定用户收到的消息
        /// </summary>      
        public DataTable GetUserReceivedMessagesByPage(string whereConditional, out int recordCount, string userId, int pageIndex, int pageSize, string order)
        {
            if (!string.IsNullOrEmpty(whereConditional))
            {
                whereConditional += " AND ";
            }

            whereConditional    +=  CiMessageTable.FieldDeleteMark + " = 0 AND " 
                                    + CiMessageTable.FieldEnabled + " = 1 AND "  
                                    + CiMessageTable.FieldReceiverId + " = '" + userId + "'";
            if (string.IsNullOrEmpty(order))
            {
                order = CiMessageTable.FieldCreateOn + " DESC ";
            }
            return this.GetDTByPage(out recordCount, pageIndex, pageSize, whereConditional, order);
        }

        /// <summary>
        /// 通过指定条件得到消息
        /// </summary>     
        public DataTable GetMessagesByConditional(string whereConditional,bool isAdministrator, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null)
        {
            if (string.IsNullOrEmpty(order))
            {
                order = CiMessageTable.FieldCreateOn + " DESC ";
            }
            //非超级管理只得到自己发送与接收的消息
            if (!isAdministrator) 
            {
                if (!string.IsNullOrEmpty(whereConditional))
                {
                    whereConditional += " AND (" + CiMessageTable.FieldReceiverId + "='" + base.UserInfo.Id + "' OR "
                                     + CiMessageTable.FieldCreateUserId + "='" + base.UserInfo.Id + "')";
                }
                else
                {
                    whereConditional += CiMessageTable.FieldReceiverId + "='" + base.UserInfo.Id + "' OR "
                                     + CiMessageTable.FieldCreateUserId + "='" + base.UserInfo.Id + "'";
                }
            }

            if (!string.IsNullOrEmpty(whereConditional))
            {
                whereConditional += " AND " + CiMessageTable.FieldDeleteMark + " = 0";
            }
            else
            {
                whereConditional += CiMessageTable.FieldDeleteMark + " = 0";
            }

            return this.GetDTByPage(out recordCount, pageIndex, pageSize, whereConditional, order);
        }
    }
}
