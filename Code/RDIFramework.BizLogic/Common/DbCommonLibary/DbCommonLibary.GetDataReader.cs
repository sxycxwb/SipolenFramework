using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    { 
        //
        // 读取列表部分 填充IDataReader 常用
        //      

        private static string AddWhere(string where, string appendWhere)
        {
            if (string.IsNullOrEmpty(where)) return appendWhere;
            return where + BusinessLogic.SQLLogicConditional + appendWhere;
        }

        public static List<T> GetDataReader<T>(IDbProvider dbProvider, string tableName, string where) where T : new()
        {
            return GetDataReader(dbProvider, tableName, where).ToList<T>();
        }

        public static IDataReader GetDataReader(IDbProvider dbProvider, string tableName, string where)
        {
            return GetDataReader2(dbProvider, tableName, where);
        }

        public static List<T> GetDataReader2<T>(IDbProvider dbProvider, string tableName, string where, int topLimit = 0, string order = null) where T : new()
        {
            return GetDataReader2(dbProvider, tableName, where, topLimit, order).ToList<T>();
        }

        public static IDataReader GetDataReader2(IDbProvider dbProvider, string tableName, string where, int topLimit = 0, string order = null)
        {
            string sqlQuery = GetDataReaderQueryString(dbProvider, tableName,"*", where, topLimit, order);
            return dbProvider.ExecuteReader(sqlQuery);
        }

        public static string GetDataReaderQueryString(IDbProvider dbProvider, string tableName, string selectField, string where, int topLimit, string order)
        {
            string str = "SELECT " + selectField + " FROM " + tableName;
            if (tableName.Trim().IndexOf(" ") > 0)
            {
                str = "SELECT " + selectField + " FROM  (" + tableName + ")";
            }
            string str2 = where;
            if (topLimit != 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.Oracle:
                        if (string.IsNullOrEmpty(order))
                        {
                            str2 = AddWhere(str2, " ROWNUM < = " + topLimit);
                        }
                        break;

                    case CurrentDbType.SqlServer:
                    case CurrentDbType.Access:
                        str = "SELECT TOP " + topLimit.ToString() + " " + selectField + " FROM " + tableName;
                        break;
                }
            }
            if (!string.IsNullOrEmpty(str2))
            {
                str = str + " WHERE " + str2;
            }
            if (!string.IsNullOrEmpty(order))
            {
                str = str + " ORDER BY " + order;
            }
            if (topLimit != null &&  topLimit > 0)
            {
                CurrentDbType currentDbType = dbProvider.CurrentDbType;
                if (currentDbType != CurrentDbType.Oracle)
                {
                    if (currentDbType == CurrentDbType.MySql)
                    {
                        str = str + " LIMIT 0, " + topLimit;
                    }
                    return str;
                }
                if (!string.IsNullOrEmpty(order))
                {
                    str = string.Concat(new object[] { "SELECT * FROM (", str, ") WHERE ROWNUM < = ", topLimit });
                }
            }
            return str;
        }

        public static List<T> GetDataReader<T>(IDbProvider dbProvider, string tableName, string name, object[] values, string order = null) where T : new()
        {
            return GetDataReader(dbProvider, tableName, name, values, order).ToList<T>();
        }

        #region public static IDataReader GetDataReader(IDbProvider dbProvider, string tableName, string name, object[] values, string order = null) 获取数据表 一参 参数为数组
        /// <summary>
        /// 获取数据表 一参 参数为数组
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static IDataReader GetDataReader(IDbProvider dbProvider, string tableName, string name, object[] values, string order = null)
        {
            string sqlQuery = "SELECT * "
                            + "   FROM " + tableName;
            if (values == null || values.Length == 0)
            {
                sqlQuery += "  WHERE " + name + " IS NULL";
            }
            else
            {
                sqlQuery += "  WHERE " + name + " IN (" + BusinessLogic.ObjectsToList(values) + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            return dbProvider.ExecuteReader(sqlQuery);
        }
        #endregion

        public static List<T> GetDataReader<T>(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null) where T : new()
        {
            return GetDataReader(dbProvider, tableName, parameters, topLimit, order).ToList<T>();
        }

        public static IDataReader GetDataReader(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null)
        {
            string sqlQuery = GetDataReaderQueryString(dbProvider, tableName, "*", GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional), topLimit, order);
            if (parameters != null && parameters.Count > 0)
            {
                return dbProvider.ExecuteReader(sqlQuery, dbProvider.MakeParameters(parameters));
            }
            else
            {
                return dbProvider.ExecuteReader(sqlQuery);
            }
        }

        public static List<T> GetDataReader<T>(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, string conditions, int topLimit = 0, string order = null, string selectField = " * ") where T : new()
        {
            return GetDataReader(dbProvider, tableName, parameters, conditions, topLimit, order, selectField).ToList<T>();
        }

        public static IDataReader GetDataReader(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, string conditions, int topLimit = 0, string order = null, string selectField = " * ")
        {
            string commandText = "SELECT " + selectField + " FROM " + tableName;
            string str2 = string.Empty;
            if (topLimit != 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.Oracle:
                        if (string.IsNullOrEmpty(order))
                        {
                            str2 = AddWhere(str2, " ROWNUM < = " + topLimit);
                        }
                        break;

                    case CurrentDbType.SqlServer:
                    case CurrentDbType.Access:
                        commandText = "SELECT TOP " + topLimit.ToString() + selectField + " FROM " + tableName;
                        break;
                }
            }
            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = " WHERE " + conditions;
            }
            commandText = commandText + conditions + str2;
            if (!string.IsNullOrEmpty(order))
            {
                commandText = commandText + " ORDER BY " + order;
            }
            if (topLimit != null && topLimit > 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.Oracle:
                        if (!string.IsNullOrEmpty(order))
                        {
                            commandText = string.Concat(new object[] { "SELECT * FROM (", commandText, ") WHERE ROWNUM < = ", topLimit });
                        }
                        break;

                    case CurrentDbType.MySql:
                        commandText = commandText + " LIMIT 0, " + topLimit;
                        break;
                }
            }
            if ((parameters != null) && (parameters.Count > 0))
            {
                return dbProvider.ExecuteReader(commandText, dbProvider.MakeParameters(parameters));
            }
            return dbProvider.ExecuteReader(commandText);
        }

        public static List<T> GetDataReader<T>(IDbProvider dbProvider, string tableName, string selectField, string name, object[] values, string order = null) where T : new()
        {
            return GetDataReader(dbProvider, tableName, selectField, name, values, order).ToList<T>();
        }

        public static IDataReader GetDataReader(IDbProvider dbProvider, string tableName, string selectField, string name, object[] values, string order = null)
        {
            string commandText = "SELECT " + selectField + "   FROM " + tableName;
            if ((values != null) && (values.Length != 0))
            {
                string str2 = commandText;
                commandText = str2 + "  WHERE " + name + " IN (" + string.Join(",", values) + ")";
            }
            else
            {
                commandText = commandText + "  WHERE " + name + " IS NULL";
            }
            if (!string.IsNullOrEmpty(order))
            {
                commandText = commandText + " ORDER BY " + order;
            }
            return dbProvider.ExecuteReader(commandText);
        }
    }
}
