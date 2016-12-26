using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    {
        #region public static string[] GetProperties(IDbProvider dbProvider, string tableName, string name, Object[] values, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetProperties(IDbProvider dbProvider, string tableName, string name, Object[] values, string targetField)
        {
            string sqlQuery = " SELECT " + targetField
                            + "   FROM " + tableName
                            + "  WHERE " + name + " IN (" + BusinessLogic.ObjectsToList(values) + ")";
            DataTable dataTable = dbProvider.Fill(sqlQuery);
            return BusinessLogic.FieldToArray(dataTable, targetField);
        }
        #endregion

        #region public static string[] GetProperties(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, int? topLimit = null, string targetField = null) 获取数据权限
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="parameters">字段名,字段值</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetProperties(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, int? topLimit = null, string targetField = null)
        {
            if (string.IsNullOrEmpty(targetField))
            {
                targetField = BusinessLogic.FieldId;
            }
            // 这里是需要完善的功能，完善了这个，是一次重大突破           
            string sqlQuery = " SELECT " + targetField + " FROM " + tableName;
            string whereSql = string.Empty;
            if (topLimit != null && topLimit > 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = " SELECT TOP " + topLimit.ToString() + targetField + " FROM " + tableName;
                        break;
                    case CurrentDbType.Oracle:
                        whereSql = " ROWNUM < = " + topLimit;
                        break;
                    case CurrentDbType.MySql:
                        sqlQuery = sqlQuery + " LIMIT 0, " + topLimit;
                        break;

                }
            }
            string subSql = GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional);
            if (subSql.Length > 0)
            {
                whereSql = whereSql.Length > 0 ? whereSql + BusinessLogic.SQLLogicConditional + subSql : subSql;
            }

            if (whereSql.Length > 0)
            {
                sqlQuery += " WHERE " + whereSql;
            }

            DataTable dataTable = new DataTable(tableName);
            dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(parameters));
            return BusinessLogic.FieldToArray(dataTable, targetField);
        }
        #endregion
    }
}
