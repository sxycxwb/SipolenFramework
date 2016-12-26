using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonLibary
    { 
        public static List<T> GetDataReaderByPage<T>(IDbProvider dbProvider, string tableName, string selectField, int pageIndex, int pageSize, string conditions, string orderBy) where T : new()
        {
            return GetDataReaderByPage(dbProvider, tableName, selectField, pageIndex, pageSize, conditions, orderBy).ToList<T>();
        }

        public static IDataReader GetDataReaderByPage(IDbProvider dbProvider, string tableName, string selectField, int pageIndex, int pageSize, string conditions, string orderBy)
        {
            return GetDataReaderByPage(dbProvider, tableName, selectField, pageIndex, pageSize, conditions, null, orderBy, null);
        }

        public static List<T> GetDataReaderByPage<T>(IDbProvider dbProvider, int recordCount, int pageIndex, int pageSize, string sqlQuery, IDbDataParameter[] dbParameters, string sortExpression = null, string sortDire = null) where T : new()
        {
            return GetDataReaderByPage(dbProvider, recordCount, pageIndex, pageSize, sqlQuery, dbParameters, sortExpression, sortDire).ToList<T>();
        }

        public static IDataReader GetDataReaderByPage(IDbProvider dbProvider, int recordCount, int pageIndex, int pageSize, string sqlQuery, IDbDataParameter[] dbParameters, string sortExpression = null, string sortDire = null)
        {
            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = BusinessLogic.FieldCreateOn;
            }
            if (string.IsNullOrEmpty(sortDire))
            {
                sortDire = " DESC";
            }
            string str4 = ((recordCount - ((pageIndex - 1) * pageSize)) > pageSize) ? pageSize.ToString() : ((recordCount - ((pageIndex - 1) * pageSize))).ToString();
            string str = ((pageIndex - 1) * pageSize).ToString();
            string str2 = (pageIndex * pageSize).ToString();
            string commandText = string.Empty;
            switch (dbProvider.CurrentDbType)
            {
                case CurrentDbType.Oracle:
                    commandText = string.Format("SELECT T.*, ROWNUM RN  FROM ({0} AND ROWNUM <= {1} ORDER BY {2}) T WHERE ROWNUM > {3}", new object[] { sqlQuery, str2, sortExpression, str });
                    break;

                case CurrentDbType.SqlServer:
                case CurrentDbType.DB2:
                    str = ((pageIndex - 1) * pageSize).ToString();
                    str2 = (pageIndex * pageSize).ToString();
                    commandText = "SELECT * FROM ( SELECT ROW_NUMBER() OVER(ORDER BY " + sortExpression + ") AS ROWNUM, " + sqlQuery.Substring(7) + "  ) A  WHERE ROWNUM > " + str + " AND ROWNUM < " + str2;
                    break;

                case CurrentDbType.Access:
                    if (sqlQuery.ToUpper().IndexOf("SELECT") >= 0)
                    {
                        sqlQuery = " (" + sqlQuery + ") ";
                    }
                    commandText = string.Format("SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} * FROM {2} T ORDER BY {3} " + sortDire + ") T1 ORDER BY {4} DESC ) T2 ORDER BY {5} " + sortDire, new object[] { str4, str, sqlQuery, sortExpression, sortExpression, sortExpression });
                    break;

                case CurrentDbType.MySql:
                    if (sqlQuery.ToUpper().IndexOf("SELECT") >= 0)
                    {
                        sqlQuery = " (" + sqlQuery + ") ";
                    }
                    str = ((pageIndex - 1) * pageSize).ToString();
                    str2 = (pageIndex * pageSize).ToString();
                    commandText = string.Format("SELECT * FROM {0} ORDER BY {1} {2} LIMIT {3},{4}", new object[] { sqlQuery, sortExpression, sortDire, str, str2 });
                    break;
            }
            return dbProvider.ExecuteReader(commandText, dbParameters);
        }

        public static IDataReader GetDataReaderByPage(IDbProvider dbProvider, string tableName, string selectField, int pageIndex, int pageSize, string conditions, IDbDataParameter[] dbParameters, string orderBy, string currentIndex = null)
        {
            string str = ((pageIndex - 1) * pageSize).ToString();
            string str2 = (pageIndex * pageSize).ToString();
            if (currentIndex == null)
            {
                currentIndex = string.Empty;
            }
            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }
            string commandText = string.Empty;
            if (dbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    orderBy = " ORDER BY " + orderBy;
                }
                commandText = string.Format("SELECT * FROM (SELECT ROWNUM RN, H.* FROM ((SELECT " + currentIndex + " " + selectField + " FROM {0} {1} {2} )H)) Z WHERE Z.RN <={3} AND Z.RN >{4} ", new object[] { tableName, conditions, orderBy, str2, str });
            }
            else if (dbProvider.CurrentDbType == CurrentDbType.SqlServer)
            {
                commandText = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowIndex, " + selectField + " FROM {1} {2}) AS PageTable WHERE RowIndex <={3} AND RowIndex >{4} ", new object[] { orderBy, tableName, conditions, str2, str });
            }
            else if ((dbProvider.CurrentDbType == CurrentDbType.MySql) || (dbProvider.CurrentDbType == CurrentDbType.SQLite))
            {
                commandText = string.Format("SELECT {0} FROM {1} {2} ORDER BY {3} LIMIT {4}, {5}", new object[] { selectField, tableName, conditions, orderBy, str, pageSize });
            }
            if ((dbParameters != null) && (dbParameters.Length > 0))
            {
                return dbProvider.ExecuteReader(commandText, dbParameters);
            }
            return dbProvider.ExecuteReader(commandText);
        }

        public static List<T> GetDataReaderByPage<T>(IDbProvider dbProvider, out int recordCount, int pageIndex = 0, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereClause = null, string selectField = null) where T : new()
        {
            return GetDataReaderByPage(dbProvider, out recordCount, pageIndex, pageSize, sortExpression, sortDire, tableName, whereClause, selectField).ToList<T>();
        }

        public static IDataReader GetDataReaderByPage(IDbProvider dbProvider, out int recordCount, int pageIndex = 0, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereClause = null, string selectField = null)
        {
            IDataReader reader = null;
            recordCount = 0;
            if (string.IsNullOrEmpty(selectField))
            {
                selectField = "*";
            }
            if (string.IsNullOrEmpty(whereClause))
            {
                whereClause = string.Empty;
            }
            List<IDbDataParameter> list = new List<IDbDataParameter>();
            IDbDataParameter item = dbProvider.MakeParam("RecordCount", (int)recordCount, DbType.Int64, 0, ParameterDirection.Output);
            list.Add(item);
            list.Add(dbProvider.MakeParameter("PageIndex", pageIndex));
            list.Add(dbProvider.MakeParameter("PageSize", pageSize));
            list.Add(dbProvider.MakeParameter("SortExpression", sortExpression));
            list.Add(dbProvider.MakeParameter("SortDire", sortDire));
            list.Add(dbProvider.MakeParameter("TableName", tableName));
            list.Add(dbProvider.MakeParameter("SelectField", selectField));
            list.Add(dbProvider.MakeParameter("WhereConditional", whereClause));
            string commandText = "pGetRecordByPage";
            reader = dbProvider.ExecuteReader(commandText, list.ToArray(), CommandType.StoredProcedure);
            recordCount = int.Parse(item.Value.ToString());
            return reader;
        }

        public static List<T> GetDataReaderByPage<T>(IDbProvider dbProvider, out int recordCount, string tableName, string selectField, int pageIndex, int pageSize, string conditions, IDbDataParameter[] dbParameters, string orderBy) where T : new()
        {
            return GetDataReaderByPage(dbProvider, out recordCount, tableName, selectField, pageIndex, pageSize, conditions, dbParameters, orderBy).ToList<T>();
        }

        public static IDataReader GetDataReaderByPage(IDbProvider dbProvider, out int recordCount, string tableName, string selectField, int pageIndex, int pageSize, string conditions, IDbDataParameter[] dbParameters, string orderBy)
        {
            IDataReader reader = null;
            recordCount = 0;
            if (dbProvider != null)
            {
                recordCount = GetCount(dbProvider, tableName, conditions, dbParameters, null);
                reader = GetDataReaderByPage(dbProvider, tableName, selectField, pageIndex, pageSize, conditions, dbParameters, orderBy, null);
            }
            return reader;
        }
        
        public static List<T> GetDataReaderByPage<T>(IDbProvider dbProvider, string tableName, string selectField, int pageIndex, int pageSize, string conditions, IDbDataParameter[] dbParameters, string orderBy, string currentIndex = null) where T : new()
        {
            return GetDataReaderByPage(dbProvider, tableName, selectField, pageIndex, pageSize, conditions, dbParameters, orderBy, currentIndex).ToList<T>();
        }
    }
}
