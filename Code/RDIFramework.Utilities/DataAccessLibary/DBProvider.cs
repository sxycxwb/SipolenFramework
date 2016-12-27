//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// DBProvider
    /// 有关数据库连接的方法。
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.18 版本：2.0 XuWangBin 采用默认参数技术,把一些方法进行简化。
    ///		2010.09.03 版本：1.0 XuWangBin 创建。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.09.03</date>
    /// </author> 
    /// </summary>
    public class DBProvider
    {
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string DbConnection = SystemInfo.BusinessDbConnection;

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static CurrentDbType DbType = SystemInfo.BusinessDbType;
       
        private static readonly IDbProvider dbProvider = DbFactoryProvider.GetProvider(DbType, DbConnection);

        /// <summary> 
        /// DbProviderFactory实例
        /// </summary>
        private static DbProviderFactory factory = null;

        /// <summary> 
        /// DbProviderFactory实例
        /// </summary>
        public static DbProviderFactory Factory
        {
            get { return factory ?? (factory = dbProvider.GetInstance()); }
        }

        /// <summary> 
        /// 构造方法
        /// </summary>
        private DBProvider()
        {
        }

        /// <summary> 
        /// 当前数据库类型
        /// </summary>
        public CurrentDbType CurrentDbType
        {
            get
            {
                return dbProvider.CurrentDbType;
            }
        }

        #region public static string GetDBNow() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public static string GetDBNow()
        {
            return dbProvider.GetDBNow();
        }
        #endregion

        #region public static string GetDBDateTime() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public static string GetDBDateTime()
        {
            return dbProvider.GetDBDateTime();
        }
        #endregion

        #region public static string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public static string SqlSafe(string value)
        {
            return dbProvider.SqlSafe(value);
        }
        #endregion

        #region string PlusSign() 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <returns>字符加</returns>
        public static string PlusSign()
        {
            return dbProvider.PlusSign();
        }
        #endregion

        #region string PlusSign(params string[] values) 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <param name="values">参数值</param>
        /// <returns>字符加</returns>
        public static string PlusSign(params string[] values)
        {
            return dbProvider.PlusSign(values);
        }
        #endregion

        #region public static string GetParameter(string parameter) 获得参数Sql表达式
        /// <summary>
        /// 获得参数Sql表达式
        /// </summary>
        /// <param name="parameter">参数名称</param>
        /// <returns>字符串</returns>
        public static string GetParameter(string parameter)
        {
            return dbProvider.GetParameter(parameter);
        }
        #endregion

        #region public static IDbDataParameter MakeParameter(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public static IDbDataParameter MakeParameter(string targetFiled, object targetValue)
        {
            return dbProvider.MakeParameter(targetFiled, targetValue);
        }
        #endregion

        #region public static IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFileds">目标字段</param>
        /// <param name="targetValues">值</param>
        /// <returns>参数集</returns>
        public static IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            return dbProvider.MakeParameters(targetFileds, targetValues);
        }
        #endregion

        #region public static IDbDataParameter MakeParameters(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="parameterValue">值</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="parameterSize">大小</param>
        /// <param name="parameterDirection">输出方向</param>
        /// <returns>参数集</returns>
        public static IDbDataParameter MakeParameters(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
        {
            return dbProvider.MakeParam(parameterName, parameterValue, dbType, parameterSize, parameterDirection);
        }
        #endregion

        #region public static int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text) 执行查询返回受影响的行数
        /// <summary>
        /// 执行查询返回受影响的行数
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            int returnValue = 0;
            dbProvider.Open(DbConnection);
            returnValue = dbProvider.ExecuteNonQuery(commandText, dbParameters, commandType);
            dbProvider.Close();
            return returnValue;
        }
        #endregion

        #region public static object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text) 执行查询返回受首行首列
        /// <summary>
        /// 执行查询返回受首行首列
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            object returnValue = null;
            dbProvider.Open(DbConnection);
            returnValue = dbProvider.ExecuteScalar(commandText, dbParameters, commandType);
            dbProvider.Close();
            return returnValue;
        }
        #endregion

        #region public static IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text) 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>结果集流</returns>
        public static IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            dbProvider.Open(DbConnection);
            dbProvider.AutoOpenClose = true;
            return dbProvider.ExecuteReader(commandText, dbParameters, commandType);
        }
        #endregion

        #region public static DataTable Fill(string commandText, IDbDataParameter[] dbParameters, CommandType commandType = CommandType.Text) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(string commandText, IDbDataParameter[] dbParameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dataTable = new DataTable("RDIFramework"); 
            dbProvider.Open(DbConnection);
            dbProvider.Fill(dataTable, commandText, dbParameters, commandType);
            dbProvider.Close();
            return dataTable;
        }
        #endregion

        /// <summary>
        /// Oracle/SqlServer 获取分页数据
        /// </summary>
        /// <param name="recordCount">记录条数</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDTByPage(out int recordCount, string tableName, int pageIndex, int pageSize, string conditions, string orderby)
        {
            recordCount = 0;
            string sqlQuery = " SELECT COUNT(*) " + " FROM " + tableName;
            if (tableName.IndexOf("SELECT", System.StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (tableName.IndexOf("ORDER BY", System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    tableName = tableName.Substring(0, tableName.IndexOf("ORDER BY", System.StringComparison.OrdinalIgnoreCase) - 1);
                }
                tableName = "(" + tableName + ") AS T ";
                sqlQuery = " SELECT COUNT(*) " + " FROM " + tableName;
            }    
            if (!string.IsNullOrEmpty(conditions))
            {
                sqlQuery += " WHERE " + conditions;
            }
            object returnObject = dbProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                recordCount = int.Parse(returnObject.ToString());
            }

            var sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();
            var sqlEnd = (pageIndex * pageSize).ToString();

            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }

            sqlQuery = string.Empty;

            if (dbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                    , tableName, conditions, orderby, sqlEnd, sqlStart);
            }
            if (dbProvider.CurrentDbType == CurrentDbType.SqlServer)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowIndex, * FROM {1} {2}) AS PageTable WHERE RowIndex BETWEEN {3} AND {4} ORDER BY {5}"
                    , orderby, tableName, conditions, sqlStart, sqlEnd, orderby);
            }
            var dataTable = new DataTable(tableName);
            dataTable = dbProvider.Fill(sqlQuery);
            return dataTable;
        }
    }
}