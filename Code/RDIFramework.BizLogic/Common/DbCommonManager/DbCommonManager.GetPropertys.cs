using System;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    public partial class DbCommonManager
    {    
        public virtual string[] GetProperties(string targetField)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, null, 0, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, 0, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter, int topLimit, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, topLimit, targetField);
        }

        public virtual string[] GetProperties(int topLimit, string targetField)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, null, topLimit, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, 0, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, int topLimit, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, topLimit, targetField);
        }

        public virtual string[] GetProperties(string name, Object[] values, string targetField)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, name, values, targetField);
        }

        public virtual string[] GetProperties(List<KeyValuePair<string, object>> parameters, string targetField)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, 0, targetField);
        }

        public virtual string[] GetProperties(List<KeyValuePair<string, object>> parameters, int topLimit = 0, string targetField = null)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, topLimit, targetField);
        }
    }
}
