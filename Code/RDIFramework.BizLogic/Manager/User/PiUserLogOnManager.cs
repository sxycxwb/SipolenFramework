using System.Data;
using RDIFramework.Utilities;

namespace RDIFramework.BizLogic
{

    /// <summary>
    /// PiUserLogOnManager
    /// 系统用户表登录信息
    ///
    /// 修改纪录
    ///
    ///		2014-03-26 版本：1.0 XuWangBin 创建主键。
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-03-26</date>
    /// </author>
    /// </summary>
    public partial class PiUserLogOnManager
    {
        /// <summary>
        /// 获取在线人数
        /// </summary>
        public string GetOnLineCount()
        {
            string sqlQuery = "SELECT COUNT(Id) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE USERONLINE = 1";
            return DBProvider.ExecuteScalar(sqlQuery).ToString();
        }

        public string GetLogOnCount(int days)
        {
            string sqlQuery = "SELECT COUNT(Id) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE ENABLED = 1 AND (DATEADD(d, " + days.ToString() + ", " + PiUserLogOnTable.FieldLastVisit + ") > " + DBProvider.GetDBNow() + ")";
            return DBProvider.ExecuteScalar(sqlQuery).ToString();
        }

        #region private int ResetVisitInfo(string id) 重置访问情况
        /// <summary>
        /// 重置访问情况
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        private int ResetVisitInfo(string id)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetNull(PiUserLogOnTable.FieldFirstVisit);
            sqlBuilder.SetNull(PiUserLogOnTable.FieldPreviousVisit);
            sqlBuilder.SetNull(PiUserLogOnTable.FieldLastVisit);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldLogOnCount, 0);
            sqlBuilder.SetWhere(PiUserLogOnTable.FieldId, id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public int ResetVisitInfo(string[] ids) 重置
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int ResetVisitInfo(string[] ids)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].Length > 0)
                {
                    returnValue += this.ResetVisitInfo(ids[i]);
                }
            }
            return returnValue;
        }
        #endregion

        #region public int ResetVisitInfo() 重置访问情况
        /// <summary>
        /// 重置访问情况
        /// </summary>
        /// <returns>影响行数</returns>
        public int ResetVisitInfo()
        {
            int returnValue = 0;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetNull(PiUserLogOnTable.FieldFirstVisit);
            sqlBuilder.SetNull(PiUserLogOnTable.FieldPreviousVisit);
            sqlBuilder.SetNull(PiUserLogOnTable.FieldLastVisit);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldLogOnCount, 0);
            returnValue = sqlBuilder.EndUpdate();
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 更新访问当前访问状态
        /// </summary>
        /// <param name="userLogOnEntity">实体</param>
        /// <param name="createOpenId">是否每次都产生新的OpenId</param>
        /// <returns>OpenId</returns>
        public string UpdateVisitDate(PiUserLogOnEntity userLogOnEntity, bool createOpenId = false)
        {
            string result = string.Empty;
            string sqlQuery = string.Empty;

            // 是否更新访问日期信息
            if (SystemInfo.UpdateVisit)
            {
                // 第一次登录时间
                if (userLogOnEntity.FirstVisit == null)
                {
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                                + " SET " + PiUserLogOnTable.FieldUserOnLine + " = 1," + PiUserLogOnTable.FieldFirstVisit + " = " + DBProvider.GetDBNow();

                    switch (DBProvider.CurrentDbType)
                    {
                        case CurrentDbType.Access:
                            sqlQuery = sqlQuery + "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userLogOnEntity.Id + "') AND " + PiUserLogOnTable.FieldFirstVisit + " IS NULL";
                            break;
                        default:
                            sqlQuery = sqlQuery + "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userLogOnEntity.Id + "') AND " + PiUserLogOnTable.FieldFirstVisit + " IS NULL";
                            break;
                    }

                    DBProvider.ExecuteNonQuery(sqlQuery);
                }
                else
                {
                    // 最后一次登录时间
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                                + " SET " + PiUserLogOnTable.FieldPreviousVisit + " = " + PiUserLogOnTable.FieldLastVisit + " , "
                                + PiUserLogOnTable.FieldUserOnLine + " = 1 , "
                                + PiUserLogOnTable.FieldLastVisit + " = " + DBProvider.GetDBNow() + " , "
                                + PiUserLogOnTable.FieldLogOnCount + " = " + PiUserLogOnTable.FieldLogOnCount + " + 1 ";
                    if (createOpenId)
                    {
                        result = BusinessLogic.NewGuid();
                        sqlQuery += "       , " + PiUserLogOnTable.FieldOpenId + " = '" + result + "'";
                    }
                    switch (DBProvider.CurrentDbType)
                    {
                        case CurrentDbType.Access:
                            sqlQuery += "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userLogOnEntity.Id + "')";
                            break;
                        default:
                            sqlQuery += "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userLogOnEntity.Id + "')";
                            break;
                    }
                    DBProvider.ExecuteNonQuery(sqlQuery);
                }
            }
            else
            {
                // 实现单点登录功能，每次都更换Guid
                if (createOpenId)
                {
                    result = BusinessLogic.NewGuid();
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                             + "    SET " + PiUserLogOnTable.FieldPasswordErrorCount + " = 0 "
                             + "       , " + PiUserLogOnTable.FieldOpenId + " = '" + result + "'"
                             + " WHERE (" + PiUserLogOnTable.FieldId + " = '" + userLogOnEntity.Id + "')";
                    DBProvider.ExecuteNonQuery(sqlQuery);
                }
            }
            return result;
        }

        #region public string UpdateVisitDate(string userId, bool createOpenId = false) 更新访问当前访问状态
        /// <summary>
        /// 更新访问当前访问状态
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="createOpenId">是否每次都产生新的OpenId</param>
        /// <returns>OpenId</returns>
        public string UpdateVisitDate(string userId, bool createOpenId = false)
        {
            PiUserLogOnEntity userLogOnEntity = this.GetEntity(userId);
            return UpdateVisitDate(userLogOnEntity, createOpenId);
        }
        #endregion

        #region public int OnLine(string userId, int onLineState = 1) 用户在线
        /// <summary>
        /// 用户在线
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <returns>影响行数</returns>
        public int OnLine(string userId, int onLineState = 1)
        {
            int returnValue = 0;
            // 是否更新访问日期信息
            if (!SystemInfo.UpdateVisit)
            {
                return returnValue;
            }
            string sqlQuery = string.Empty;
            // 最后一次登录时间
            sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                       + "    SET " + PiUserLogOnTable.FieldUserOnLine + " = " + onLineState.ToString();
                       //+ " , " + PiUserLogOnTable.FieldLastVisit + " = " + DBProvider.GetDBNow()
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                    sqlQuery += "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userId + "')";
                    break;
                default:
                    sqlQuery += "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userId + "')";
                    break;
            }
            returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
            return returnValue;
        }
        #endregion

        #region public int OnExit(string userId) 用户退出
        /// <summary>
        /// 用户退出
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int OnExit(string userId)
        {
            int returnValue = 0;
            // 是否更新访问日期信息
            if (!SystemInfo.UpdateVisit)
            {
                return returnValue;
            }

            string sqlQuery = string.Empty;
            // 最后一次登录时间
            sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                        + " SET " + PiUserLogOnTable.FieldPreviousVisit + " = " + PiUserLogOnTable.FieldLastVisit
                        + " , " + PiUserLogOnTable.FieldOpenId + " = '" + BusinessLogic.NewGuid() + "'"
                        + " , " + PiUserLogOnTable.FieldUserOnLine + " = 0 "
                        + " , " + PiUserLogOnTable.FieldLastVisit + " = " + DBProvider.GetDBNow();
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                    sqlQuery += "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userId + "')";
                    break;
                default:
                    sqlQuery += "  WHERE (" + PiUserLogOnTable.FieldId + " = '" + userId + "')";
                    break;
            }
            returnValue += DBProvider.ExecuteNonQuery(sqlQuery);

            return returnValue;
        }
        #endregion

        // 2分钟不在线，表示用户离开

        #region public int CheckOnLine() 检查用户在线状态(服务器专用)
        /// <summary>
        /// 检查用户在线状态(服务器专用)
        /// </summary>
        /// <returns>影响行数</returns>
        public int CheckOnLine()
        {
            int returnValue = 0;
            // 是否更新访问日期信息
            if (!SystemInfo.UpdateVisit)
            {
                return returnValue;
            }

            string sqlQuery = string.Empty;

            // 最后一次登录时间
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                            + "     SET " + PiUserLogOnTable.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + PiUserLogOnTable.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + PiUserLogOnTable.FieldUserOnLine + " > 0) AND (" + PiUserLogOnTable.FieldLastVisit + " IS NOT NULL) AND (DATEADD (s, " + SystemInfo.OnLineTime0ut.ToString() + ", " + PiUserLogOnTable.FieldLastVisit + ") < " + DBProvider.GetDBNow() + "))";
                    returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                            + "     SET " + PiUserLogOnTable.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + PiUserLogOnTable.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + PiUserLogOnTable.FieldUserOnLine + " > 0) AND (" + PiUserLogOnTable.FieldLastVisit + " IS NOT NULL) AND ((SYSDATE - " + PiUserLogOnTable.FieldLastVisit + ") * 24 * 60 * 60 > " + SystemInfo.OnLineTime0ut.ToString() + "))";
                    returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.MySql:
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                            + "     SET " + PiUserLogOnTable.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + PiUserLogOnTable.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + PiUserLogOnTable.FieldUserOnLine + " > 0) AND (" + PiUserLogOnTable.FieldLastVisit + " IS NOT NULL) AND (DATE_ADD(" + PiUserLogOnTable.FieldLastVisit + ", Interval " + SystemInfo.OnLineTime0ut.ToString() + " SECOND) < " + DBProvider.GetDBNow() + "))";
                    returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.DB2:
                    sqlQuery = " UPDATE " + PiUserLogOnTable.TableName
                            + "     SET " + PiUserLogOnTable.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + PiUserLogOnTable.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + PiUserLogOnTable.FieldUserOnLine + " > 0) AND (" + PiUserLogOnTable.FieldLastVisit + " IS NOT NULL) AND (" + PiUserLogOnTable.FieldLastVisit + " + " + SystemInfo.OnLineTime0ut.ToString() + " SECONDS < " + DBProvider.GetDBNow() + "))";
                    returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.Access:
                    break;
            }

            return returnValue;
        }
        #endregion

        #region public bool CheckOnLineLimit()
        /// <summary>
        /// 同时在线用户数量限制
        /// </summary>
        /// <returns>是否符合限制</returns>
        public bool CheckOnLineLimit()
        {
            bool returnValue = false;

            this.CheckOnLine();

            string sqlQuery = string.Empty;
            // 最后一次登录时间
            sqlQuery = " SELECT COUNT(*) "
                     + "   FROM " + PiUserLogOnTable.TableName
                     + "  WHERE " + PiUserLogOnTable.FieldUserOnLine + " > 0 ";
            object userOnLine = DBProvider.ExecuteScalar(sqlQuery);
            if (userOnLine != null && SystemInfo.OnLineLimit <= int.Parse(userOnLine.ToString()))
            {
                returnValue = true;
            }

            return returnValue;
        }
        #endregion

        #region public DataTable GetOnLineStateDT() 获取列表
        /// <summary>
        /// 获取在线状态列表
        /// </summary>	
        /// <returns>数据表</returns>
        public DataTable GetOnLineStateDT()
        {
            string sqlQuery = string.Empty;

            sqlQuery = " SELECT " + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldId
                                  + ", " + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldUserOnLine
                                  + " FROM " + PiUserLogOnTable.TableName
                                  + " WHERE " + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLastVisit + " IS NOT NULL ";

            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                    sqlQuery += " AND (DATEADD (s, " + (SystemInfo.OnLineTime0ut + 5).ToString() + ", " + PiUserLogOnTable.FieldLastVisit + ") > " + DBProvider.GetDBNow() + ")";
                    break;
            }
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public int ChangeOnLine(string id) 登录、重新登录、扮演时的在线状态进行更新
        /// <summary>
        /// 登录、重新登录、扮演时的在线状态进行更新
        /// </summary>
        /// <param name="id">当前用户</param>
        /// <returns>是否在线</returns>
        public int ChangeOnLine(string id)
        {
            int returnValue = 0;
            // 是自己在线，然后重新登录为别人时，需要把自己注销掉
            if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id))
            {
                if (!string.IsNullOrEmpty(UserInfo.OpenId) && !UserInfo.Id.Equals(id))
                {
                    // 要设置为下线状态，这里要判断游客状态
                    returnValue += this.OnExit(UserInfo.Id);
                }
            }
            // 用户在线
            returnValue += this.OnLine(id);

            return returnValue;
        }
        #endregion
    }
}
