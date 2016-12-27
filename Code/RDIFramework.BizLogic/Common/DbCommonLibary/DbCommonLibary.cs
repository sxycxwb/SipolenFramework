//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonLibary
    /// 数据库通用基类
    /// 
    /// 修改纪录
    ///     2015-09-17 XuWangBin V3.0 增加大量泛型操作公共类。
    ///	
    /// 版本：3.0 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2011.11.15</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonLibary
    {
        #region public static string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public static string SqlSafe(string value)
        {
            value = value.Replace("'", "''");
            // value = value.Replace("%", "'%");
            return value;
        }
        #endregion

        #region public static string GetWhereString(IDbProvider dbProvider, List<KeyValuePair<string, object>> parameters, string relation) 获得条件语句
        /// <summary>
        /// 获得条件语句
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="parameters"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static string GetWhereString(IDbProvider dbProvider, List<KeyValuePair<string, object>> parameters, string relation)
        {
            string returnValue = string.Empty;
            if (parameters == null)
            {
                return returnValue;
            }
            string subSqlQuery = string.Empty;
            foreach (var parameter in parameters)
            {
                if (!string.IsNullOrEmpty(parameter.Key))
                {
                    if (parameter.Value == null)
                    {
                        subSqlQuery = " (" + parameter.Key + " IS NULL) ";
                    }
                    else
                    {
                        if (parameter.Value is Array)
                        {
                            subSqlQuery = ((Array) parameter.Value).Length > 0
                                ? " (" + parameter.Key + " IN (" + StringHelper.ArrayToList((string[]) parameter.Value, "'") + ")) "
                                : " (" + parameter.Key + " IS NULL) ";
                        }
                        else
                        {
                            subSqlQuery = " (" + parameter.Key + " = " + dbProvider.GetParameter(parameter.Key) + ") ";
                        }
                    }
                    returnValue += subSqlQuery + relation;
                }
            }
            if (returnValue.Length > 0)
            {
                returnValue = returnValue.Substring(0, returnValue.Length - relation.Length - 1);
            }
            return returnValue;
        }
        #endregion

        #region public static string GetWhereString(IDbProvider dbProvider, string[] names, ref Object[] values, string relation) 获得条件语句
        /// <summary>
        /// 获得条件语句
        ///  
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="names">字段名</param>
        /// <param name="values">字段值</param>
        /// <param name="relation">逻辑关系</param>
        /// <returns>字符串</returns>
        public static string GetWhereString(IDbProvider dbProvider, ref string[] names, Object[] values, string relation)
        {
            string returnValue = string.Empty;
            string subSqlQuery = string.Empty;
            for (int i = 0; i < names.Length; i++)
            {
                if ((names[i] != null) && (names[i].Length > 0))
                {
                    if (values[i] == null)
                    {
                        subSqlQuery = " (" + names[i] + " IS NULL) ";
                        // 这里就不需要参数化了
                        names[i] = null;
                    }
                    else
                    {
                        if (values[i] is Array)
                        {
                            subSqlQuery = ((Array) values[i]).Length > 0
                                ? " (" + names[i] + " IN (" + BusinessLogic.ArrayToList((string[]) values[i], "'") + ")) "
                                : String.Format(" ({0} IS NULL) ", names[i]);
                            // 这里就不需要参数化了
                            names[i] = null;
                        }
                        else
                        {
                            subSqlQuery = " (" + names[i] + " = " + dbProvider.GetParameter(names[i]) + ") ";
                        }
                    }
                    returnValue += subSqlQuery + relation;
                }
            }
            if (returnValue.Length > 0)
            {
                returnValue = returnValue.Substring(0, returnValue.Length - relation.Length - 1);
            }
            return returnValue;
        }
        #endregion

        #region public static int UpdateRecord(IDbProvider dbProvider, string tableName, string name, string value, string targetField, object targetValue) 更新记录
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">主键</param>
        /// <param name="value">主键值</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">更新值</param>
        /// <returns>影响行数</returns>
        public static int UpdateRecord(IDbProvider dbProvider, string tableName, string name, string value, string targetField, object targetValue)
        {
            int returnValue = 0;
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            sqlBuilder.SetValue(targetField, targetValue);
            sqlBuilder.SetWhere(name, value);
            returnValue = sqlBuilder.EndUpdate();
            return returnValue;
        }
        #endregion

        #region public static int Insert(IDbProvider dbProvider, string tableName, string[] targetFields, Object[] targetValues) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="targetFields">更新字段</param>
        /// <param name="targetValues">更新值</param>
        /// <returns>影响行数</returns>
        public static int Insert(IDbProvider dbProvider, string tableName, string[] targetFields, Object[] targetValues)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginInsert(tableName);
            for (int i = 0; i < targetFields.Length; i++)
            {
                sqlBuilder.SetValue(targetFields[i], targetValues[i]);
            }
            return sqlBuilder.EndInsert();
        }
        #endregion

        //
        // 读取列表部分 不常用
        //

        #region public static DataTable GetFromProcedure(IDbProvider dbProvider, string procedureName, string tableName) 通过存储过程获取表数据
        /// <summary>
        /// 通过存储过程获取表数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="tableName">填充表</param>
        /// <returns>数据权限</returns>
        public static DataTable GetFromProcedure(IDbProvider dbProvider, string procedureName, string tableName)
        {
            return dbProvider.ExecuteProcedureForDataTable(procedureName, tableName, null);
        }
        #endregion

        #region public static DataTable GetFromProcedure(IDbProvider dbProvider, string procedureName, string tableName, string id) 通过存储过程获取表数据
        /// <summary>
        /// 通过存储过程获取表数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="tableName">填充表</param>
        /// <param name="id">主键值</param>
        /// <returns>数据权限</returns>
        public static DataTable GetFromProcedure(IDbProvider dbProvider, string procedureName, string tableName, string id)
        {
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BusinessLogic.FieldId;
            values[0] = id;
            return dbProvider.ExecuteProcedureForDataTable(procedureName, tableName, dbProvider.MakeParameters(names, values));
        }
        #endregion
    }
}