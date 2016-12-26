//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    /// <summary>
    ///	DbCommonManager
    /// 通用基类部分
    /// 
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.0 EricHu 进行提炼，把代码进行分组。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonManager
    {
        //
        // 判断数据是否存在
        //
        public virtual bool Exists(object id)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, this.PrimaryKey, id);
        }

        public virtual bool Exists(object[] ids)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, this.PrimaryKey, ids);
        }

        public virtual bool Exists(string name, object value)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, name, value);
        }

        public virtual bool Exists(string name, object value, object id)
        {
            string[] names = { name };
            Object[] values = { value };
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, names, values, this.PrimaryKey, id);
        }

        public virtual bool Exists(string name1, object value1, string name2, object value2)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, name1, value1, name2, value2);
        }

        public virtual bool Exists(string name1, object value1, string name2, object value2, object id)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, name1, value1, name2, value2, this.PrimaryKey, id);
        }

        public virtual bool Exists(string[] names, object[] values)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, names, values);
        }

        public virtual bool Exists(string[] names, object[] values, object id)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, names, values, this.PrimaryKey, id);
        }

        public virtual bool Exists(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, parametersList);
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, parameters);
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, object id)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, parameters, new KeyValuePair<string, object>(this.PrimaryKey, id));
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, parameters, parameter);
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter, object id)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, parameters, new KeyValuePair<string, object>(this.PrimaryKey, id));
        }

        public virtual bool Exists(List<KeyValuePair<string, object>> parameters, object id = null)
        {
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, parameters, new KeyValuePair<string, object>(this.PrimaryKey, id));
        }
    }
}