//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

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
        // 锁定表记录
        //

        #region public static int LockNoWait(IDbProvider dbProvider, string tableName, string id) 锁定表记录
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="id">字段值</param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbProvider dbProvider, string tableName, string id)
        {
            return LockNoWait(dbProvider, tableName, BusinessLogic.FieldId, id);
        }
        #endregion

        #region public static int LockNoWait(IDbProvider dbProvider, string tableName, string[] ids) 锁定表记录
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="ids">字段值</param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbProvider dbProvider, string tableName, string[] ids)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += LockNoWait(dbProvider, tableName, BusinessLogic.FieldId, ids[i]);
            }
            return returnValue;
        }
        #endregion

        #region public static int LockNoWait(IDbProvider dbProvider, string tableName, string name, object value) 锁定表记录
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">目标字段名</param>
        /// <param name="value">目标字段值</param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbProvider dbProvider, string tableName, string name, object value)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT " + BusinessLogic.FieldId + " FROM " + tableName;
            sqlQuery += name == null
                ? " WHERE (" + name + " IS NULL ) "
                : " WHERE (" + name + " = " + dbProvider.GetParameter(name) + ")";
            sqlQuery += " FOR UPDATE NOWAIT ";
            try
            {
                DataSet dataSet = new DataSet();
                dbProvider.Fill(dataSet, sqlQuery, "ForUpdateNoWait", new IDbDataParameter[] { dbProvider.MakeParameter(name, value)});
                returnValue = dataSet.Tables["ForUpdateNoWait"].Rows.Count;
            }
            catch
            {
                returnValue = -1;
            }
            return returnValue;
        }
        #endregion

        #region public static int LockNoWait(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2) 记录是否存在
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2)
        {
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            names[1] = name2;
            values[0] = value1;
            values[1] = value2;
            return LockNoWait(dbProvider, tableName, names, values);
        }
        #endregion

        #region public static int LockNoWait(IDbProvider dbProvider, string tableName, string[] names, Object[] values) 记录是否存在
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbProvider dbProvider, string tableName, string[] names, Object[] values)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT " + BusinessLogic.FieldId
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbProvider, ref names, values, BusinessLogic.SQLLogicConditional);
            sqlQuery += " FOR UPDATE NOWAIT ";
            try
            {
                DataSet dataSet = new DataSet();
                dbProvider.Fill(dataSet, sqlQuery, "ForUpdateNoWait", dbProvider.MakeParameters(names, values));
                returnValue = dataSet.Tables["ForUpdateNoWait"].Rows.Count;
            }
            catch
            {
                returnValue = -1;
            }
            return returnValue;
        }
        #endregion

        public static int LockNoWait(IDbProvider dbProvider, string tableName, params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return LockNoWait(dbProvider, tableName, parametersList);
        }

        #region public static int LockNoWait(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters) 记录是否存在
        /// <summary>
        /// 锁定表记录
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters"></param>
        /// <returns>锁定的行数</returns>
        public static int LockNoWait(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT " + BusinessLogic.FieldId
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional);
            sqlQuery += " FOR UPDATE NOWAIT ";
            try
            {
                DataTable dataTable = new DataTable("ForUpdateNoWait");
                dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(parameters));
                returnValue = dataTable.Rows.Count;
            }
            catch
            {
                returnValue = -1;
            }
            return returnValue;
        }
        #endregion
    }
}