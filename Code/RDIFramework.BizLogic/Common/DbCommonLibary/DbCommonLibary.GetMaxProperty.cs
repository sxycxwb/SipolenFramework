using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    {
        #region public static int GetMax(IDbProvider dbProvider, string tableName,string maxFieldName, string whereConditional = null) 读取指定字段的最大值
        /// <summary>
        /// 读取指定字段的最大值
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="maxFieldName">最大值所在字段</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <returns>bool</returns>
        public static int GetMax(IDbProvider dbProvider, string tableName, string maxFieldName, string whereConditional = null)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT MAX( "
                            + maxFieldName
                            + " ) FROM " + tableName;
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

        #region public static int GetMax(IDbProvider dbProvider, string tableName, string maxFieldName, string whereConditional, List<IDbDataParameter> dbParameters) 读取指定字段的最大值
        /// <summary>
        /// 读取指定字段的最大值
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="maxFieldName">最大值所在字段</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>bool</returns>
        public static int GetMax(IDbProvider dbProvider, string tableName, string maxFieldName, string whereConditional, List<IDbDataParameter> dbParameters)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT MAX( "
                            + maxFieldName
                            + " ) FROM " + tableName;
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

        #region public static int GetMax(IDbProvider dbProvider, string tableName, string maxFieldName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>()) 读取指定字段的最大值
        /// <summary>
        /// 读取指定字段的最大值
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="maxFieldName">最大值所在字段</param>
        /// <param name="parameters">目标字段,值</param>
        /// <param name="parameter"></param>
        /// <returns>行数</returns>
        public static int GetMax(IDbProvider dbProvider, string tableName, string maxFieldName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>())
        {
            int returnValue = 0;
            string sqlQuery = " SELECT MAX( "
                            + maxFieldName
                            + " ) FROM " 
                            + tableName
                            + " WHERE " 
                            + GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional);

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
	}
}
