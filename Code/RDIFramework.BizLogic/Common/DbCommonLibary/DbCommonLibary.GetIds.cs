//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonLibary
    /// 通用基类
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.05 版本：1.0	XuWangBin 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.02.05</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonLibary
    {
        //
        // 获取ID部分 获得主键数组 string[] 常用
        //

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, object value) 读取列表部分
        /// <summary>
        /// 读取列表部分
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, object value)
        {
            string order = string.Empty;
            int topLimit = 0;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            return GetIds(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, Object[] values) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, Object[] values)
        {
            return GetIds(dbProvider, tableName, name, values, BusinessLogic.FieldId);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, Object[] values, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, Object[] values, string targetField)
        {
            string sqlQuery = " SELECT " + targetField
                            + "   FROM " + tableName
                            + "  WHERE " + name + " IN (" + BusinessLogic.ObjectsToList(values) + ")";
            DataTable dataTable = dbProvider.Fill(sqlQuery);
            return BusinessLogic.FieldToArray(dataTable, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName)
        {
            string order = string.Empty;
            int topLimit = 0;
            string[] names = new string[0];
            Object[] values = new Object[0];
            return GetIds(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string targetField)
        {
            int topLimit = 0;
            string[] names = new string[0];
            Object[] values = new Object[0];
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, int topLimit, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="targetField"></param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, int topLimit, string targetField)
        {
            string[] names = new string[0];
            Object[] values = new Object[0];
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, object value, int topLimit, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">目标字段名</param>
        /// <param name="value">目标字段值</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="targetField">排序</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, object value, int topLimit, string targetField)
        {
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2) 获取数据表
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
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2)
        {
            int topLimit = 0;
            string order = string.Empty;
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            return GetIds(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <param name="targetField">排序</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string targetField)
        {
            int topLimit = 0;
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, int topLimit, string targetField) 获取数据表
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
        /// <param name="targetField">排序</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, int topLimit, string targetField)
        {
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, object value, string targetField) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string name, object value, string targetField)
        {
            int topLimit = 0;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }
        #endregion

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string[] names, Object[] values) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">填充目标表名</param>
        /// <param name="names">字段名</param>
        /// <param name="values">字段值</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string[] names, Object[] values)
        {
            string fillTableName = tableName;
            string order = string.Empty;
            int topLimit = 0;
            return GetIds(dbProvider, tableName, names, values, topLimit, order);
        }
        #endregion

        public static string[] GetIds(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string targetField = null)
        {
            int topLimit = 0;
            return GetIds(dbProvider, tableName, names, values, topLimit, targetField);
        }

        #region public static string[] GetIds(IDbProvider dbProvider, string tableName, string[] names, Object[] values, int? topLimit = null, string targetField = null) 获取数据权限
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="names">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="topLimit">前几个记录</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>数据表</returns>
        public static string[] GetIds(IDbProvider dbProvider, string tableName, string[] names, Object[] values, int? topLimit = null, string targetField = null)
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
            dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(names, values));
            return BusinessLogic.FieldToArray(dataTable, targetField);
        }
        #endregion
    }
}