using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public abstract partial class DbCommonManager
    {
        public virtual IDataReader GetDataReader(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> list = parameters.ToList();
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, list, 0, null);
        }

        public virtual IDataReader GetDataReader(string where)
        {
            return this.GetDataReaderByWhere(where, null, null);
        }

        public virtual IDataReader GetDataReader(string[] ids)
        {
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, BusinessLogic.FieldId, ids, null);
        }

        public virtual IDataReader GetDataReader(KeyValuePair<string, object> parameter, string order)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {
                parameter
            };
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, parameters, 0, order);
        }

        public virtual IDataReader GetDataReader(List<KeyValuePair<string, object>> parameters, string order)
        {
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, parameters, 0, order);
        }

        public virtual IDataReader GetDataReader(int topLimit = 0, string order = null)
        {
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, null, topLimit, order);
        }

        public virtual IDataReader GetDataReader(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string order)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {
                parameter1,
                parameter2
            };
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, parameters, 0, order);
        }

        public virtual IDataReader GetDataReader(KeyValuePair<string, object> parameter, int topLimit = 0, string order = null)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {
                parameter
            };
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, parameters, topLimit, order);
        }

        public virtual IDataReader GetDataReader(List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null)
        {
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, parameters, topLimit, order);
        }

        public virtual IDataReader GetDataReader(string name, object[] values, string order = null)
        {
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, name, values, order);
        }

        public virtual IDataReader GetDataReaderById(string id)
        {
            return this.GetDataReader(new KeyValuePair<string, object>(BusinessLogic.FieldId, id), 0, null);
        }

        public virtual List<T> GetDataReaderByPage<T>(out int recordCount, int pageIndex, int pageSize, string whereClause, IDbDataParameter[] dbParameters, string order) where T : new()
        {
            return this.GetDataReaderByPage(out recordCount, pageIndex, pageSize, whereClause, dbParameters, order).ToList<T>();
        }

        public virtual IDataReader GetDataReaderByPage(out int recordCount, int pageIndex, int pageSize, string whereClause, IDbDataParameter[] dbParameters, string order)
        {
            recordCount = DbCommonLibary.GetCount(this.DBProvider, this.CurrentTableName, whereClause, dbParameters);
            return DbCommonLibary.GetDataReaderByPage(this.DBProvider, this.CurrentTableName, this.SelectField, pageIndex, pageSize, whereClause, dbParameters, order);
        }

        public virtual List<T> GetDataReaderByPage<T>(out int recordCount, int pageIndex = 0, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string conditional = null, IDbDataParameter[] dbParameters = null, string selectField = null) where T : new()
        {
            return this.GetDataReaderByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, tableName, conditional, dbParameters, selectField).ToList<T>();
        }

        public virtual IDataReader GetDataReaderByPage(out int recordCount, int pageIndex = 0, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string conditional = null, IDbDataParameter[] dbParameters = null, string selectField = null)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = this.CurrentTableName;
            }
            if ((tableName.ToUpper().IndexOf("SELECT") < 0) && (this.DBProvider.CurrentDbType != CurrentDbType.MySql))
            {
                return DbCommonLibary.GetDataReaderByPage(this.DBProvider, out recordCount, pageIndex, pageSize, sortExpression, sortDire, tableName, conditional, selectField);
            }
            string str = string.Empty;
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = this.CurrentTableName;
            }
            string str2 = string.Empty;
            if (!string.IsNullOrEmpty(conditional))
            {
                str2 = string.Format(" WHERE {0} ", conditional);
            }
            str = tableName;
            if (tableName.ToUpper().IndexOf("SELECT") >= 0)
            {
                str = "(" + tableName + ") T ";
            }
            str = string.Format("SELECT COUNT(1) AS recordCount FROM {0} {1}", str, str2);
            object obj2 = this.DBProvider.ExecuteScalar(str, dbParameters);
            recordCount = obj2 != null ? int.Parse(obj2.ToString()) : 0;
            return DbCommonLibary.GetDataReaderByPage(this.DBProvider, recordCount, pageIndex, pageSize, tableName, dbParameters, sortExpression, sortDire);
        }

        public virtual IDataReader GetDataReaderByParent(string parentId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>(BusinessLogic.FieldParentId, parentId)
            };
            return DbCommonLibary.GetDataReader(this.DBProvider, this.CurrentTableName, parameters, 0, BusinessLogic.FieldSortCode);
        }

        public virtual IDataReader GetDataReaderByWhere(string where = null, IDbDataParameter[] dbParameters = null, string order = null)
        {
            string commandText = "SELECT *   FROM " + this.CurrentTableName;
            if (!string.IsNullOrEmpty(where))
            {
                commandText = commandText + "  WHERE " + where + " ";
            }
            if (!string.IsNullOrWhiteSpace(order))
            {
                commandText = commandText + "ORDER BY " + order;
            }
            return this.DBProvider.ExecuteReader(commandText, dbParameters);
        }

    }
}