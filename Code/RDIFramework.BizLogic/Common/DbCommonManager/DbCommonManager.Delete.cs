//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

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
        // 删除数据部分
        // force 是否强制删除关联数据
        //
        public virtual int Delete()
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName);
        }

        public virtual int Delete(object id)
        {
            return DeleteEntity(id);
        }

        public virtual int Delete(object id, bool force)
        {
            // 这个函数需要覆盖
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, id);
        }

        public virtual int Delete(string name, object value)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, name, value);
        }

        public virtual int Delete(string name, object value, bool force)
        {
            // 这个函数需要覆盖
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, name, value);
        }

        public virtual int Delete(string name1, object value1, string name2, object value2)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, name1, value1, name2, value2);
        }

        public virtual int Delete(string name1, object value1, string name2, object value2, bool force)
        {
            // 这个函数需要覆盖
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, name1, value1, name2, value2);
        }

        public virtual int Delete(object[] ids)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, ids);
        }

        public virtual int Delete(object[] ids, bool force)
        {
            // 这个函数需要覆盖
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, ids);
        }

        public virtual int Delete(string name, object[] values)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, name, values);
        }

        public virtual int Delete(string[] names, object[] values)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, names, values);
        }

        public virtual int Delete(string[] names, object[] values, bool force)
        {
            // 这个函数需要覆盖
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, names, values);
        }

        public virtual int Delete(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, parametersList);
        }

        public virtual int Delete(List<KeyValuePair<string, object>> parameters)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, parameters);
        }

        public virtual int Truncate()
        {
            return DbCommonLibary.Truncate(DBProvider, this.CurrentTableName);
        }
    }
}