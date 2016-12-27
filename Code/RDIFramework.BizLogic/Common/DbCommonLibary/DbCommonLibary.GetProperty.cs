//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
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
        // 读取属性部分
        //


        #region public static string GetProperty(IDbProvider dbProvider, string tableName, string name, string value, string targetField) 读取属性
        /// <summary>
        /// 读取属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">键值</param>
        /// <param name="targetField">获取字段</param>
        /// <returns>属性</returns>
        public static string GetProperty(IDbProvider dbProvider, string tableName, string name, object value, string targetField)
        {
            string returnValue = string.Empty;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            returnValue = GetProperty(dbProvider, tableName, names, values, targetField);
            return returnValue;
        }
        #endregion

        #region public static string GetProperty(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string targetField) 读取属性
        /// <summary>
        /// 读取属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <param name="targetField">获取字段</param>
        /// <returns>String</returns>
        public static string GetProperty(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string targetField)
        {
            string returnValue = string.Empty;
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            names[1] = name2;
            values[0] = value1;
            values[1] = value2;
            returnValue = GetProperty(dbProvider, tableName, names, values, targetField);
            return returnValue;
        }
        #endregion

        #region public static string GetProperty(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string targetField) 读取属性
        /// <summary>
        /// 读取属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <param name="targetField">获取字段</param>
        /// <returns>属性</returns>
        public static string GetProperty(IDbProvider dbProvider, string tableName, string[] names, Object[] values, string targetField)
        {
            string returnValue = string.Empty;
            string sqlQuery = " SELECT " + targetField
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbProvider, ref names, values, BusinessLogic.SQLLogicConditional);
            object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = returnObject.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public static string GetProperty(IDBProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, string targetField) 读取属性
        /// <summary>
        /// 读取属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">字段名,键值</param>
        /// <param name="targetField">获取字段</param>
        /// <returns>属性</returns>
        public static string GetProperty(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, string targetField)
        {
           string returnValue = string.Empty;
           string sqlQuery = " SELECT " + targetField
               + " FROM " + tableName
               + " WHERE " + GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional);
           object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(parameters));
           if (returnObject != null)
           {
              returnValue = returnObject.ToString();
           }
           return returnValue;
        }
        #endregion
    

        #region public static string GetId(IDbProvider dbProvider, string tableName, string name, object value) 获得ID属性
        /// <summary>
        /// 获得ID属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="value">键值</param>
        /// <returns>属性</returns>
        public static string GetId(IDbProvider dbProvider, string tableName, string name, object value)
        {
            return GetProperty(dbProvider, tableName, name, value, BusinessLogic.FieldId);
        }
        #endregion

        #region public static string GetId(IDbProvider dbProvider, string tableName, string name1, string value1, string name2, string value2) 获得ID属性
        /// <summary>
        /// 获得ID属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <returns>String</returns>
        public static string GetId(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2)
        {
            string returnValue = string.Empty;
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            names[1] = name2;
            values[0] = value1;
            values[1] = value2;
            returnValue = GetProperty(dbProvider, tableName, names, values, BusinessLogic.FieldId);
            return returnValue;
        }
        #endregion

        #region public static string GetId(IDbProvider dbProvider, string tableName, string[] names, Object[] values) 获得ID属性
        /// <summary>
        /// 获得Id属性
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <returns>属性</returns>
        public static string GetId(IDbProvider dbProvider, string tableName, string[] names, Object[] values)
        {
            return GetProperty(dbProvider, tableName, names, values, BusinessLogic.FieldId);
        }
        #endregion
    }
}