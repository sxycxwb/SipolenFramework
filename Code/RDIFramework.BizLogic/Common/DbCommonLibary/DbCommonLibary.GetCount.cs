using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    { 

        #region public static int GetCount(IDbProvider dbProvider, string tableName, string whereConditional = null) 读取记录个数
        /// <summary>
        /// 读取记录个数
        /// </summary>
        /// <param name="dbProvider">数据提供者</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <returns>bool</returns>
        public static int GetCount(IDbProvider dbProvider, string tableName, string whereConditional = null)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(*) "
                            + " FROM " + tableName;
            if (!string.IsNullOrEmpty(whereConditional))
            {
                sqlQuery += " WHERE " + whereConditional;
            }
            object returnObject = dbProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        #region public static int GetCount(IDbProvider dbProvider, string tableName, string whereConditional, List<IDbDataParameter> dbParameters) 读取记录个数
        /// <summary>
        /// 读取记录个数
        /// </summary>
        /// <param name="dbProvider">数据提供者</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="dbParameters">db参数</param>
        /// <returns>bool</returns>
        public static int GetCount(IDbProvider dbProvider, string tableName, string whereConditional, List<IDbDataParameter> dbParameters)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(*) "
                            + " FROM " + tableName;
            if (!string.IsNullOrEmpty(whereConditional))
            {
                sqlQuery += " WHERE " + whereConditional;
            }
            object returnObject = null;

            returnObject = dbParameters != null && dbParameters.Count > 0
                ? dbProvider.ExecuteScalar(sqlQuery, dbParameters.ToArray())
                : dbProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        #region public static int GetCount(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>()) 获取个数
        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="dbProvider">数据提供者</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">目标字段,值</param>
        /// <returns>行数</returns>
        public static int GetCount(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>())
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(1) "
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional);

            if (!string.IsNullOrEmpty(parameter.Key))
            {
                switch (DBProvider.DbType)
                {
                    case CurrentDbType.Access:
                        // CISEQUENCE表的ID 是字符类型
                        if (tableName == "CISEQUENCE")
                            sqlQuery += BusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> '" + parameter.Value + "' ) ";
                        else if (parameter.Value == null)
                            sqlQuery += BusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> 0 ) ";
                        else
                            sqlQuery += BusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> " + parameter.Value + " ) ";
                        break;
                    default:
                        sqlQuery += BusinessLogic.SQLLogicConditional + "( " + parameter.Key + " <> '" + parameter.Value + "' ) ";
                        break;
                }
            }

            object returnObject = null;
            returnObject = parameters != null ? dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(parameters)) : dbProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        #region public static int GetCount(IDbProvider dbProvider, string tableName, string whereConditional = null, IDbDataParameter[] dbParameters = null, string currentIndex = null) 读取记录个数
        /// <summary>
        /// 读取记录个数
        /// </summary>
        /// <param name="dbProvider">数据提供者</param>
        /// <param name="tableName">表名</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="dbParameters">db参数</param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        public static int GetCount(IDbProvider dbProvider, string tableName, string whereConditional = null, IDbDataParameter[] dbParameters = null, string currentIndex = null)
        {
            int num = 0;
            if (currentIndex == null)
            {
                currentIndex = string.Empty;
            }
            string commandText = "SELECT " + currentIndex + " COUNT(1)  FROM " + tableName;
            if (!string.IsNullOrEmpty(whereConditional))
            {
                commandText = commandText + " WHERE " + whereConditional;
            }
            object obj2 = null;
            obj2 = dbProvider.ExecuteScalar(commandText, dbParameters);
            if (obj2 != null)
            {
                num = int.Parse(obj2.ToString());
            }
            return num;
        }
        #endregion
    }
}
