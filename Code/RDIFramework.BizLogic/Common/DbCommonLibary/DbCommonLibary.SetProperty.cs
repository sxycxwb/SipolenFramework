//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonLibary
    /// 通用基类
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.05 版本：1.0	EricHu 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.05</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonLibary
    {
        //
        // 设置属性部分
        //

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string targetField, object targetValue) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string targetField, object targetValue)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            sqlBuilder.SetValue(targetField, targetValue);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string name, object value, string targetField, object targetValue) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">条件字段</param>
        /// <param name="value">条件值</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string name, object value, string targetField, object targetValue)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            sqlBuilder.SetValue(targetField, targetValue);
            // sqlBuilder.SetDBNow(FieldModifiedOn);
            sqlBuilder.SetWhere(name, value);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string targetField, object targetValue) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">条件字段</param>
        /// <param name="value1">条件值</param>
        /// <param name="name2">条件字段</param>
        /// <param name="value2">条件值</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string targetField, object targetValue)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            sqlBuilder.SetValue(targetField, targetValue);
            // sqlBuilder.SetDBNow(FieldModifiedOn);
            sqlBuilder.SetWhere(name1, value1);
            sqlBuilder.SetWhere(name2, value2);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string name, Object[] values, string targetField, object targetValue) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">条件字段</param>
        /// <param name="values">条件值</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string name, Object[] values, string targetField, object targetValue)
        {
            int returnValue = 0;
            if (values == null)
            {
                returnValue = SetProperty(dbProvider, tableName, name, string.Empty, targetField, targetValue);
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    returnValue += SetProperty(dbProvider, tableName, name, values[i], targetField, targetValue);
                }
            }
            return returnValue;
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string name, object value, string[] targetFields, Object[] targetValues) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">条件字段</param>
        /// <param name="value">条件值</param>
        /// <param name="targetFields">更新字段</param>
        /// <param name="targetValues">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string name, object value, string[] targetFields, Object[] targetValues)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            for (int i = 0; i < targetFields.Length; i++)
            {
                sqlBuilder.SetValue(targetFields[i], targetValues[i]);
            }
            // sqlBuilder.SetDBNow(BusinessLogic.FieldModifiedOn);
            sqlBuilder.SetWhere(name, value);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string name, Object[] value, string[] targetFields, Object[] targetValues) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">条件字段</param>
        /// <param name="value">条件值</param>
        /// <param name="targetFields">更新字段</param>
        /// <param name="targetValues">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string name, Object[] value, string[] targetFields, Object[] targetValues)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            for (int i = 0; i < targetFields.Length; i++)
            {
                sqlBuilder.SetValue(targetFields[i], targetValues[i]);
            }
            // sqlBuilder.SetDBNow(BusinessLogic.FieldModifiedOn);
            sqlBuilder.SetWhere(name, value);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string targetField, object targetValue) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">条件字段</param>
        /// <param name="values">条件值</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string targetField, object targetValue)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            sqlBuilder.SetValue(targetField, targetValue);
            // sqlBuilder.SetDBNow(BusinessLogic.FieldModifiedOn);
            sqlBuilder.SetWhere(names, values);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public static int SetProperty(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters) 设置属性
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="whereParameters">条件字段,条件值</param>
        /// <param name="parameters">更新字段,更新值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(dbProvider);
            sqlBuilder.BeginUpdate(tableName);
            foreach (var parameter in parameters)
            {
                sqlBuilder.SetValue(parameter.Key, parameter.Value);
            }
            sqlBuilder.SetWhere(whereParameters);
            // sqlBuilder.SetDBNow(FieldModifiedOn);
            return sqlBuilder.EndUpdate();
        }
        #endregion

    }
}