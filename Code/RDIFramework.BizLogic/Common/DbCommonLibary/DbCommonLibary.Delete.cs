using System;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    { 
        // 删除数据库方法
        //

        #region public static int Delete(IDbProvider dbProvider, string tableName) 删除表中的所有数据
        /// <summary>
        /// 删除表中的所有数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName)
        {
            return Delete(dbProvider, tableName, new string[0], new Object[0]);
        }
        #endregion

        #region public static int Delete(IDbProvider dbProvider, string tableName, object id) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表</param>
        /// <param name="id">字段值</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, object id)
        {
            return Delete(dbProvider, tableName, BusinessLogic.FieldId, id);
        }
        #endregion

        #region public static int Delete(IDbProvider dbProvider, string tableName, object[] ids) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表</param>
        /// <param name="ids">字段值</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, object[] ids)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += Delete(dbProvider, tableName, BusinessLogic.FieldId, ids[i]);
            }
            return returnValue;
        }
        #endregion

        #region public static int Delete(IDbProvider dbProvider, string tableName, string name, Object[] values) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表</param>
        /// <param name="name">目标字段名</param>
        /// <param name="values">目标字段值</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, string name, Object[] values)
        {
            int returnValue = 0;
            for (int i = 0; i < values.Length; i++)
            {
                returnValue += Delete(dbProvider, tableName, name, values[i]);
            }
            return returnValue;
        }
        #endregion

        #region public static int Delete(IDbProvider dbProvider, string tableName, string name, object value) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表格名</param>
        /// <param name="name">主键</param>
        /// <param name="value">主键值</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, string name, object value)
        {
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            return Delete(dbProvider, tableName, names, values);
        }
        #endregion

        #region public static int Delete(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2)
        {
            var names = new string[2];
            var values = new Object[2];
            names[0] = name1;
            names[1] = name2;
            values[0] = value1;
            values[1] = value2;
            return Delete(dbProvider, tableName, names, values);
        }
        #endregion

        #region public int static Delete(IDbProvider dbProvider, string tableName, string[] names, Object[] values) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, string[] names, Object[] values)
        {
            string sqlQuery = " DELETE " + " FROM " + tableName;
            string whereString = GetWhereString(dbProvider, ref names, values, BusinessLogic.SQLLogicConditional);
            if (whereString.Length > 0)
            {
                sqlQuery += " WHERE " + whereString;
            }
            return dbProvider.ExecuteNonQuery(sqlQuery, dbProvider.MakeParameters(names, values));
        }
        #endregion

        #region public int static Delete(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters = null) 删除表格数据
        /// <summary>
        /// 删除表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">删除条件</param>
        /// <returns>影响行数</returns>
        public static int Delete(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters = null)
        {
            string sqlQuery = " DELETE " + " FROM " + tableName;
            string whereString = GetWhereString(dbProvider, parameters, BusinessLogic.SQLLogicConditional);
            if (whereString.Length > 0)
            {
                sqlQuery += " WHERE " + whereString;
            }
            return dbProvider.ExecuteNonQuery(sqlQuery, dbProvider.MakeParameters(parameters));
        }
        #endregion

        #region public static int Truncate(IDbProvider dbProvider, string tableName) 截断表格数据
        /// <summary>
        /// 截断表格数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表格</param>
        /// <returns>是否成功</returns>
        public static int Truncate(IDbProvider dbProvider, string tableName)
        {
            string sqlQuery = " TRUNCATE TABLE " + tableName;
            // DB2 V9.7 以上支持该语句
            if (dbProvider.CurrentDbType == CurrentDbType.DB2)
            {
                sqlQuery = " ALTER TABLE " + tableName + " ACTIVATE NOT LOGGED INITIALLY WITH EMPTY TABLE ";
            }
            return dbProvider.ExecuteNonQuery(sqlQuery);
        }
        #endregion
    }
}
