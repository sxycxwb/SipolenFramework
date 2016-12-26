using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class DbCommonManager
    {
        public virtual List<T> GetListById<T>(string id) where T : BaseEntity, new()
        {
            return this.GetList<T>(new KeyValuePair<string, object>(BusinessLogic.FieldId, id));
        }

        public virtual List<T> GetListByCategory<T>(string categoryId) where T : BaseEntity, new()
        {
            return GetList<T>(new KeyValuePair<string, object>(BusinessLogic.FieldCategoryId, categoryId));
        }

        public virtual List<T> GetList<T>(int topLimit = 0, string order = null) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, null, topLimit, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(string[] ids) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, ids))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(string name, Object[] values, string order = null) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, name, values, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(KeyValuePair<string, object> parameter, string order) where T : BaseEntity, new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, parameters, 0, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string order) where T : BaseEntity, new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, parameters, 0, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(KeyValuePair<string, object> parameter, int topLimit, string order) where T : BaseEntity, new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, parameters, topLimit, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, string order) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, parameters, 0, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, int topLimit, string order) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, parameters, topLimit, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(params KeyValuePair<string, object>[] parameters) where T : BaseEntity, new()
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, parametersList))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(string where) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader(DBProvider, this.CurrentTableName, where))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public virtual List<T> GetList<T>(string where, int topLimit = 0, string order = null) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            using (IDataReader dr = DbCommonLibary.GetDataReader2(DBProvider, this.CurrentTableName, where, topLimit, order))
            {
                list = GetList<T>(dr);
            }
            return list;
        }

        public List<T> GetList<T>(IDataReader dr) where T : BaseEntity, new()
        {
            List<T> list = new List<T>();
            while (dr.Read())
            {
                list.Add(BaseEntity.Create<T>(dr));
            }
            dr.Close();
            return list;
        }
    }
}
