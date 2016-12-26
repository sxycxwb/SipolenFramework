using System;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    { 
        #region public static bool Exists(IDbProvider dbProvider, string tableName, object id) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="id">字段值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, object id)
        {
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BusinessLogic.FieldId;
            values[0] = id;
            return Exists(dbProvider, tableName, names, values);
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string name, object value) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">目标字段名</param>
        /// <param name="value">目标字段值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string name, object value)
        {
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = name;
            values[0] = value;
            return Exists(dbProvider, tableName, names, values);
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, object[] ids) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="ids">字段值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, object[] ids)
        {
            bool returnValue = false;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue = Exists(dbProvider, tableName, BusinessLogic.FieldId, ids[i]);
                if (returnValue)
                {
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string name, object[] values) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string name, object[] values)
        {
            bool returnValue = false;
            for (int i = 0; i < values.Length; i++)
            {
                returnValue = Exists(dbProvider, tableName, name, values[i]);
                if (returnValue)
                {
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string name, object value, object id) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name">目标字段名</param>
        /// <param name="value">目标字段值</param>
        /// <param name="id">主键值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string name, object value, object id)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT COUNT(*) FROM " + tableName;
            sqlQuery += name == null
                ? " WHERE (" + name + " IS NULL ) "
                : " WHERE (" + name + " = " + dbProvider.GetParameter(name) + ") ";
            if (id != null)
            {
                sqlQuery += BusinessLogic.SQLLogicConditional + "( " + BusinessLogic.FieldId + " <> " + dbProvider.GetParameter(BusinessLogic.FieldId) + " ) ";
            }
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name;
            values[0] = value;
            if (id != null)
            {
                names[1] = BusinessLogic.FieldId;
                values[1] = id;
            }
            object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString()) > 0;
            }
            return returnValue;
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2)
        {
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = name1;
            names[1] = name2;
            values[0] = value1;
            values[1] = value2;
            return Exists(dbProvider, tableName, names, values);
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, object id) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <param name="id">主键值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, object id)
        {
            return Exists(dbProvider, tableName, name1, value1, name2, value2, BusinessLogic.FieldId, id);
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string primaryKey, object id) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="name1">目标字段名1</param>
        /// <param name="value1">目标字段值1</param>
        /// <param name="name2">目标字段名2</param>
        /// <param name="value2">目标字段值2</param>
        /// <param name="primaryKey"></param>
        /// <param name="id">主键值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string name1, object value1, string name2, object value2, string primaryKey, object id)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT COUNT(*) FROM " + tableName;
            sqlQuery += value1 == null
                ? " WHERE (" + name1 + " IS NULL) "
                : " WHERE (" + name1 + " = " + dbProvider.GetParameter(name1) + ") ";
            sqlQuery += value2 == null
                ? BusinessLogic.SQLLogicConditional + "(" + name2 + " IS NULL) "
                : BusinessLogic.SQLLogicConditional + "(" + name2 + " = " + dbProvider.GetParameter(name2) + ") ";
            if (id != null)
            {
                sqlQuery += BusinessLogic.SQLLogicConditional + "( " + primaryKey + " <> " + dbProvider.GetParameter(primaryKey) + ") ";
            }
            string[] names = new string[3];
            Object[] values = new Object[3];
            names[0] = name1;
            values[0] = value1;
            names[1] = name2;
            values[1] = value2;
            if (id != null)
            {
                names[2] = primaryKey;
                values[2] = id;
            }
            object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString()) > 0;
            }
            return returnValue;
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string[] names, object[] values) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string[] names, object[] values)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT COUNT(*) "
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbProvider, ref names, values, BusinessLogic.SQLLogicConditional);
            object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString()) > 0;
            }
            return returnValue;
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, string[] names, object[] values, string primaryKey, object id) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="names">字段名数组</param>
        /// <param name="values">键值数组</param>
        /// <param name="primaryKey">目标字段名</param>
        /// <param name="id">目标字段值</param>
        /// <returns>bool</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, string[] names, object[] values, string primaryKey, object id)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT COUNT(*) "
                + " FROM " + tableName
                + " WHERE " + GetWhereString(dbProvider, ref names, values, BusinessLogic.SQLLogicConditional);
            sqlQuery += BusinessLogic.SQLLogicConditional + "( " + primaryKey + " <> '" + id + "' ) ";
            object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString()) > 0;
            }
            return returnValue;
        }
        #endregion

        #region public static bool Exists(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = null) 记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="parameters">参数</param>
        /// <param name="parameter"></param>
        /// <returns>存在</returns>
        public static bool Exists(IDbProvider dbProvider, string tableName, List<KeyValuePair<string, object>> parameters, KeyValuePair<string, object> parameter = new KeyValuePair<string, object>())
        {
            return GetCount(dbProvider, tableName, parameters, parameter) > 0;
        }
        #endregion
    }
}
