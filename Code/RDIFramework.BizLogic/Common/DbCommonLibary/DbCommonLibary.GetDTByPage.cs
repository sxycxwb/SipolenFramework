//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
    
    /// <summary>
    ///	DbCommonLibary
    /// 通用基类
    /// 
    /// 修改纪录
    ///     2015-01-08 V3.0 XuWangBin  修改Oracle分页起始页少一条数据的问题。
    ///     2015-11-12 V3.0 胡勇    修改针对Mysql分页，第一页的数据范围应从0开始。
    ///     2015-03-24 V2.9 胡勇    修改分页起始页不精确的问题。
    ///     2015-01-07 V2.9 王进    修正对MySql分页的方法。
    ///     2014-03-15 V2.8 XuWangBin  修改GetDTByPage方法的异常情况。
    ///		2013.02.05 版本：2.0	XuWangBin 分离程序。
    ///	
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.02.05</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonLibary
    {
        // SqlServer By StoredProcedure

        #region  public static DataTable GetDTByPage(IDbProvider dbProvider, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereConditional = null, string selectField = null)
        /// <summary>
        /// 使用存储过程获取分页数据(SqlServer)
        /// </summary>
        /// <param name="dbProvider">数据源</param>
        /// <param name="recordCount">返回的记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序</param>
        /// <param name="tableName">表名</param>
        /// <param name="whereConditional">查询条件</param>
        /// <param name="selectField">查询字段</param>
        /// <returns></returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereConditional = null, string selectField = null)
        {
            DataTable dataTable = null;
            recordCount = 0;
            if (string.IsNullOrEmpty(selectField))
            {
                selectField = "*";
            }
            if (string.IsNullOrEmpty(whereConditional))
            {
                whereConditional = string.Empty;
            }
            var dbParameters = new List<IDbDataParameter>();
            var dbDataParameter = DBProvider.MakeParameters("RecordCount", recordCount, DbType.Int64, 8, ParameterDirection.Output);
            dbParameters.Add(dbDataParameter);
            dbParameters.Add(DBProvider.MakeParameter("PageIndex", pageIndex));
            dbParameters.Add(DBProvider.MakeParameter("PageSize", pageSize));
            dbParameters.Add(DBProvider.MakeParameter("SortExpression", sortExpression));
            dbParameters.Add(DBProvider.MakeParameter("SortDire", sortDire));
            dbParameters.Add(DBProvider.MakeParameter("TableName", tableName));
            dbParameters.Add(DBProvider.MakeParameter("SelectField", selectField));
            dbParameters.Add(DBProvider.MakeParameter("WhereConditional", whereConditional));
            var commandText = "pGetRecordByPage";
            dataTable = dbProvider.Fill(commandText, dbParameters.ToArray(), CommandType.StoredProcedure);
            recordCount = int.Parse(dbDataParameter.Value.ToString());
            return dataTable;
        }
        #endregion  

        #region public static DataTable GetDTByPage(IDbProvider dbProvider, int recordCount, int pageIndex, int pageSize, string sqlQuery, string sortExpression = null, string sortDire = null) 分页获取指定数量的数据
        /// <summary>
        ///  分页获取指定数量的数据
        /// </summary>
        /// <param name="dbProvider">数据源</param>
        /// <param name="recordCount">获取多少条</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="sqlQuery"></param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序</param>
        /// <returns></returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, int recordCount, int pageIndex, int pageSize, string sqlQuery, string sortExpression = null, string sortDire = null)
        {
            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = BusinessLogic.FieldCreateOn;
            }
            if (string.IsNullOrEmpty(sortDire))
            {
                sortDire = " DESC";
            }
            var sqlCount = recordCount - ((pageIndex - 1) * pageSize) > pageSize ? pageSize.ToString() : (recordCount - ((pageIndex - 1) * pageSize)).ToString();
            var sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();
            var sqlEnd = (pageIndex  * pageSize).ToString();
            var commandText = string.Empty;

            switch (dbProvider.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                case CurrentDbType.DB2:
                    sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();
                    sqlEnd = (pageIndex * pageSize).ToString();
                    commandText = " SELECT * FROM ( "
                               + " SELECT ROW_NUMBER() OVER(ORDER BY " + sortExpression + ") AS ROWNUM, "
                               + sqlQuery.Substring(7) + "  ) A "
                               + " WHERE ROWNUM > " + sqlStart + " AND ROWNUM <= " + sqlEnd;
                    break;
                case CurrentDbType.Access:
                    if (sqlQuery.IndexOf("SELECT", System.StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        sqlQuery = " (" + sqlQuery + ") ";
                    }
                    commandText = string.Format("SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} * FROM {2} T ORDER BY {3} " + sortDire + ") T1 ORDER BY {4} DESC ) T2 ORDER BY {5} " + sortDire
                                    , sqlCount, sqlStart, sqlQuery, sortExpression, sortExpression, sortExpression);
                    break;
                case CurrentDbType.Oracle:
                    sqlStart = ((pageIndex - 1) * pageSize).ToString();
                    commandText = string.Format(@"SELECT T.*, ROWNUM RN  FROM ({0} AND ROWNUM <= {1} ORDER BY {2}) T WHERE ROWNUM > {3}", sqlQuery, sqlEnd, sortExpression, sqlStart);
                    break;
                case CurrentDbType.MySql:
                case CurrentDbType.SQLite:
                    if (sqlQuery.IndexOf("SELECT",System.StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        sqlQuery = " (" + sqlQuery + ") ";
                    }
                    sqlStart = ((pageIndex - 1) * pageSize).ToString();
                    sqlEnd = (pageIndex * pageSize).ToString();
                    commandText = string.Format("SELECT * FROM {0} ORDER BY {1} {2} LIMIT {3},{4}", sqlQuery, sortExpression, sortDire, sqlStart, sqlEnd);
                    break;
            }
            return dbProvider.Fill(commandText);
        }
        #endregion

        
        // Oracle GetDTByPage

        #region public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, int pageIndex, int pageSize, string conditions, string orderby) 获取分页数据
        /// <summary>
        /// Oracle/SqlServer/mysql 获取分页数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, int pageIndex, int pageSize, string conditions, string orderby)
        {
            var sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();
            var sqlEnd = (pageIndex * pageSize).ToString();

            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }
            var sqlQuery = string.Empty;

            if (dbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlStart = ((pageIndex - 1) * pageSize).ToString();
                sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                    , tableName, conditions, orderby, sqlEnd, sqlStart);
            }
            else if (dbProvider.CurrentDbType == CurrentDbType.SqlServer)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowIndex, * FROM {1} {2}) AS PageTable WHERE RowIndex BETWEEN {3} AND {4} ORDER BY {5}"
                    , orderby, tableName, conditions, sqlStart, sqlEnd, orderby);
            }
            else if ((dbProvider.CurrentDbType == CurrentDbType.MySql) || (dbProvider.CurrentDbType == CurrentDbType.SQLite))
            {
                sqlStart = ((pageIndex - 1) * pageSize).ToString(); //mysql的分页起始位置是从0开始的
                sqlQuery = string.Format("SELECT * FROM {0} {1} ORDER BY {2} LIMIT {3}, {4}", new object[] { tableName, conditions, orderby, sqlStart, pageSize });
            }
            var dataTable = new DataTable(tableName);
            dataTable = dbProvider.Fill(sqlQuery);
            return dataTable;
        }

        /// <summary>
        /// Oracle/SqlServer/mysql 获取分页数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="selectField">查询字段</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, string conditions, string orderby, string selectField = "*", int pageIndex = 1,int pageSize= 20)
        {
            var sqlStart = ((pageIndex - 1) * pageSize).ToString();
            var sqlEnd = (pageIndex * pageSize).ToString();

            if (string.IsNullOrEmpty(selectField))
            {
                selectField = "*";
            }

            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }
            var sqlQuery = string.Empty;

            if (dbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlQuery = string.Format("SELECT {0} FROM (SELECT T.{1}, ROWNUM RN FROM (SELECT {2} FROM {3} {4} ORDER BY {5}) T WHERE ROWNUM <= {6}) WHERE RN > {7}",
                    selectField,selectField,selectField, tableName, conditions, orderby, sqlEnd, sqlStart);
            }
            else if (dbProvider.CurrentDbType == CurrentDbType.SqlServer)
            {
                sqlQuery = string.Format("SELECT {0} FROM (SELECT ROW_NUMBER() OVER(ORDER BY {1}) AS RowIndex, {2} FROM {3} {4}) AS PageTable WHERE RowIndex BETWEEN {5} AND {6}",
                    selectField, orderby, selectField,tableName, conditions, sqlStart, sqlEnd);
            }
            else if ((dbProvider.CurrentDbType == CurrentDbType.MySql) || (dbProvider.CurrentDbType == CurrentDbType.SQLite))
            {
                sqlStart = ((pageIndex - 1) * pageSize).ToString(); //mysql的分页起始位置是从0开始的
                sqlQuery = string.Format("SELECT {0} FROM {1} {2} ORDER BY {3} LIMIT {4}, {5}", new object[] { selectField, tableName, conditions, orderby, sqlStart, pageSize });
            }

            var dataTable = new DataTable(tableName);
            dataTable = dbProvider.Fill(sqlQuery);
            return dataTable;
        }

        #endregion

        #region public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, int pageIndex, int pageSize, string conditions, List<IDbDataParameter> dbParameters, string orderby) 分页获取数据
        /// <summary>
        /// Oracle 获取数据表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <returns>数据表</returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, int pageIndex, int pageSize, string conditions, List<IDbDataParameter> dbParameters, string orderby)
        {
            var sqlCount = (pageIndex * pageSize).ToString();
            var sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();

            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }

            var sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                , tableName, conditions, orderby, sqlCount, sqlStart);

            var dataTable = new DataTable(tableName);
            if (dbParameters != null && dbParameters.Count > 0)
            {
                dataTable = dbProvider.Fill(sqlQuery, dbParameters.ToArray());
            }
            else
            {
                dataTable = dbProvider.Fill(sqlQuery);
            }
            return dataTable;
        }
        #endregion

        #region public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, string selectField, int pageIndex, int pageSize, string conditions, string orderby) 获取分页数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby"></param>
        /// <returns>数据表</returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, string selectField, int pageIndex, int pageSize, string conditions, string orderby)
        {
            var sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();
            var sqlEnd = (pageIndex * pageSize).ToString();
            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }
            var sqlQuery = string.Empty;

            if (dbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlStart = ((pageIndex - 1) * pageSize).ToString();
                //sqlQuery = string.Format("SELECT " + selectField + " FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                //    , tableName, conditions, orderby, sqlEnd, sqlStart);

                sqlQuery = string.Format("SELECT " + selectField + " FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ) T WHERE ROWNUM <= {2} ORDER BY {3}) WHERE RN > {4}"
                    , tableName, conditions, sqlEnd, orderby, sqlStart);
            }
            else if (dbProvider.CurrentDbType == CurrentDbType.SqlServer)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowIndex, " + selectField + " FROM {1} {2}) AS PageTable WHERE RowIndex BETWEEN {3} AND {4}"
                    , orderby, tableName, conditions, sqlStart, sqlEnd);
            }
            else if ((dbProvider.CurrentDbType == CurrentDbType.MySql) || (dbProvider.CurrentDbType == CurrentDbType.SQLite))
            {
                sqlStart = ((pageIndex - 1) * pageSize).ToString(); //mysql的分页起始位置是从0开始的
                sqlQuery = string.Format("SELECT {0} FROM {1} {2} ORDER BY {3} LIMIT {4}, {5}", new object[] { selectField, tableName, conditions, orderby, sqlStart, pageSize });
            }

            var dt = new DataTable(tableName);
            dt = dbProvider.Fill(sqlQuery);
            return dt;
        }
        #endregion

        //Mysql分页获取指定数量的数据

        #region public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, int recordCount, int pageIndex, int pageSize, string conditions, string sortExpression = null, string sortDire = null) Mysql分页获取指定数量的数据
        /// <summary>
        /// Mysql分页获取指定数量的数据
        /// </summary>
        /// <param name="dbProvider">数据源</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="recordCount">获取多少条</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序</param>
        /// <returns></returns>
        public static DataTable GetDTByPage(IDbProvider dbProvider, string tableName, int recordCount, int pageIndex, int pageSize, string conditions, string sortExpression = null, string sortDire = null)
        {
            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = BusinessLogic.FieldCreateOn;
            }
            if (string.IsNullOrEmpty(sortDire))
            {
                sortDire = " DESC";
            }
            string sqlCount = recordCount - ((pageIndex - 1) * pageSize) > pageSize ? pageSize.ToString() : (recordCount - ((pageIndex - 1) * pageSize)).ToString();
            string sqlStart = ((pageIndex - 1) * pageSize).ToString();
            string sqlEnd = pageSize.ToString();
            string commandText = string.Empty;
            if (tableName.IndexOf("SELECT", System.StringComparison.OrdinalIgnoreCase) >= 0)
            {
                tableName = " (" + tableName + ") ";
            }
            string whereConditional = string.Empty;
            if (!string.IsNullOrEmpty(conditions))
            {
                whereConditional = string.Format(" WHERE {0}", conditions);
            }
            commandText = string.Format("SELECT * FROM {0} {1} ORDER BY {2} {3} LIMIT {4},{5}", tableName, whereConditional, sortExpression, sortDire, sqlStart, sqlEnd);
            return dbProvider.Fill(commandText);
        }
        #endregion
    }
}