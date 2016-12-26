using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    { 
        //
        // 读取列表部分 填充DataTable 常用
        //

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object value) 读取列表部分
        /// <summary>
        /// 读取列表部分
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object value)
        {
            string order = string.Empty;
            int topLimit = 0;
            string[] names = new string[1];
            object[] values = new object[1];
            names[0] = name;
            values[0] = value;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, Object[] values) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, Object[] values)
        {
            return GetDT(dbProvider, tableName, name, values, string.Empty);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName)
        {
            string order = string.Empty;
            int topLimit = 0;
            string[] names = new string[0];
            Object[] values = new Object[0];
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string order)
        {
            int topLimit = 0;
            string[] names = new string[0];
            Object[] values = new Object[0];
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, Object[] ids) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, Object[] ids)
        {
            return GetDT(dbProvider, tableName, BusinessLogic.FieldId, ids);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, Object[] ids, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="ids">主键数组</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, Object[] ids, string order)
        {
            return GetDT(dbProvider, tableName, BusinessLogic.FieldId, ids, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, int topLimit, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, int topLimit, string order)
        {
            string[] names = new string[0];
            Object[] values = new Object[0];
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object value, int topLimit, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">目标字段名</param>
        /// <param name="value">目标字段值</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object value, int topLimit, string order)
        {
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2)
        {
            int topLimit = 0;
            string order = string.Empty;
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string order)
        {
            const int topLimit = 0;
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, int topLimit, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, int topLimit, string order)
        {
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object value, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object value, string order)
        {
            DataTable dataTable = new DataTable(tableName);
            string sqlQuery = " SELECT * "
                            + "   FROM " + tableName;
            if (value == null)
            {
                sqlQuery += "  WHERE " + name + " IS NULL";
            }
            else
            {
                sqlQuery += "  WHERE " + name + " = " + dbProvider.GetParameter(name);
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            if (value == null)
            {
                dataTable = dbProvider.Fill(sqlQuery);
            }
            else
            {
                dataTable = dbProvider.Fill(sqlQuery, new IDbDataParameter[] { dbProvider.MakeParameter(name, value) });
            }
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object[] values, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string name, object[] values, string order)
        {
            string sqlQuery = " SELECT * "
                            + "   FROM " + tableName;
            if (values == null)
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
            return dbProvider.Fill(sqlQuery);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string[] names, Object[] values) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">填充目标表名</param>
        /// <param name="names">字段名</param>
        /// <param name="values">字段值</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string[] names, Object[] values)
        {
            string fillTableName = tableName;
            string order = string.Empty;
            int topLimit = 0;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string order) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">填充目标表名</param>
        /// <param name="names">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="order">排序</param>
        /// <returns>数据权限</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string order)
        {
            int topLimit = 0;
            return GetDT(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, string[] names, Object[] values, int topLimit, string order) 获取数据权限
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="names">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, string[] names, Object[] values, int topLimit, string order)
        {
            // 这里是需要完善的功能，完善了这个，是一次重大突破           
            string sqlQuery = " SELECT * FROM " + tableName;
            string whereSql = string.Empty;
            if (topLimit != 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = " SELECT TOP " + topLimit.ToString() + " * FROM " + tableName;
                        break;
                    case CurrentDbType.Oracle:
                        whereSql = " ROWNUM < = " + topLimit;
                        break;
                }
            }
            string subSql = GetWhereString(dbProvider, ref names, values, BusinessLogic.SQLLogicConditional);
            if (subSql.Length > 0)
            {
                whereSql = whereSql.Length > 0 ? whereSql + BusinessLogic.SQLLogicConditional + subSql : subSql;
            }
            if (whereSql.Length > 0)
            {
                sqlQuery += " WHERE " + whereSql;
            }
            if ((order != null) && (order.Length > 0))
            {
                sqlQuery += " ORDER BY " + order;
            }
            if (topLimit != null && topLimit > 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.MySql:
                        sqlQuery += " LIMIT 0, " + topLimit;
                        break;
                }
            }
            DataTable dataTable = new DataTable(tableName);
            if ((names != null) && (values != null) && (names.Length > 0) && (values.Length > 0))
            {
                dataTable = dbProvider.Fill(sqlQuery, dbProvider.MakeParameters(names, values));
            }
            else
            {
                dataTable = dbProvider.Fill(sqlQuery);
            }
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, int currentPage, int numPerPage, string conditions, string orderby) 获取数据权限
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="numPerPage">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, int currentPage, int numPerPage, string conditions, string orderby)
        {

            string sqlCount = (currentPage * numPerPage).ToString();
            string sqlStart = ((currentPage - 1) * numPerPage).ToString();

            string sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} where {1} order by {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                , tableName, conditions, orderby, sqlCount, sqlStart);

            DataTable dataTable = new DataTable(tableName);
            dataTable = dbProvider.Fill(sqlQuery);
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDT(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null, string conditions = null, string fields = " * ") 参数化查询数据表
        /// <summary>
        /// 参数化查询数据表
        /// </summary>
        /// <param name="dbProvider">数据库提供者</param>
        /// <param name="tableName">表名</param>
        /// <param name="parameters">查询的参数</param>
        /// <param name="topLimit">前多少条</param>
        /// <param name="order">排序</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="fields">查询的字段</param>
        /// <returns>数据表</returns>
        public static DataTable GetDT(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null, string conditions = null, string fields = " * ")
        {
            string sqlQuery = "SELECT " + fields + " FROM " + tableName;
            string whereSql = string.Empty;
            if (topLimit != 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = " SELECT TOP " + topLimit.ToString() + " " + fields +" FROM " + tableName;
                        break;
                    case CurrentDbType.Oracle:
                        whereSql = " ROWNUM < = " + topLimit;
                        break;
                }
            }
            if (string.IsNullOrEmpty(conditions))
            {
                conditions = BusinessLogic.SQLLogicConditional;
            }
            string subSql = GetWhereString(dbProvider, parameters, conditions);
            if (!string.IsNullOrEmpty(subSql))
            {
                whereSql = whereSql.Length > 0 ? whereSql + conditions + subSql : subSql;
            }

            if (whereSql.Length > 0)
            {
                sqlQuery += " WHERE " + whereSql;
            }

            if (!string.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }

            if (topLimit != null && topLimit > 0)
            {
                switch (dbProvider.CurrentDbType)
                {
                    case CurrentDbType.MySql:
                        sqlQuery += " LIMIT 0, " + topLimit;
                        break;
                }
            }
            DataTable dataTable = new DataTable(tableName);
            dataTable = parameters != null && parameters.Count > 0
                ? dbProvider.Fill(sqlQuery, dbProvider.MakeParameters(parameters))
                : dbProvider.Fill(sqlQuery);
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDataTable(IDbProvider dbProvider, string tableName, IDbDataParameter[] dbParameters, string conditions, int topLimit = 0, string order = null, string selectField = " * ") 参数化查询数据表
        /// <summary>
        /// 参数化查询数据表
        /// </summary>
        /// <param name="dbProvider">数据库提供者</param>
        /// <param name="tableName">表名</param>
        /// <param name="dbParameters">参数列表</param>
        /// <param name="conditions">条件</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="order">排序字段</param>
        /// <param name="selectField">返回的列</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTable(IDbProvider dbProvider, string tableName, IDbDataParameter[] dbParameters, string conditions, int topLimit = 0, string order = null, string selectField = " * ")
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
            DataTable table = new DataTable(tableName);
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
            if ((dbParameters != null) && (dbParameters.Length > 0))
            {
                return dbProvider.Fill(commandText, dbParameters);
            }
            return dbProvider.Fill(commandText);
        }
        #endregion
    }
}
