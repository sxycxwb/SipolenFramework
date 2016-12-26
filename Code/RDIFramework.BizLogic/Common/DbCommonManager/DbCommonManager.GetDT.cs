//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;
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
        // 获取一些列表的常用方法
        //

        #region public virtual DataTable GetDTById(string id) 通过主键获取数据列表
        /// <summary>
        /// 通过主键获取数据列表
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDTById(string id)
        {
            return this.GetDT(BusinessLogic.FieldId, id);
        }
        #endregion

        #region public virtual DataTable GetDTByCategory(string categoryId) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="categoryId">类别主键</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDTByCategory(string categoryId)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, BusinessLogic.FieldCategoryId, categoryId, BusinessLogic.FieldSortCode);
        }
        #endregion

        #region public virtual DataTable GetDTByParent(string parentId) 按父亲节点获取数据
        /// <summary>
        /// 按父亲节点获取数据
        /// </summary>
        /// <param name="parentId">父节点主键</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDTByParent(string parentId)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, BusinessLogic.FieldParentId, parentId, BusinessLogic.FieldSortCode);
        }
        #endregion

        /// <summary>
        /// 读取多条记录
        /// </summary>
        /// <returns>数据表</returns>
        public virtual DataTable GetDT()
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName);
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="recordCount">记录总数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="perPage">每页显示多少条</param>
        /// <param name="whereConditional">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDT(out int recordCount, int currentPage, int perPage, string whereConditional, string order)
        {
            recordCount = DbCommonLibary.GetCount(DBProvider, this.CurrentTableName, whereConditional);
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, currentPage, perPage, whereConditional, order);
        }

        public virtual DataTable GetDT(string name, Object[] values)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name, values);
        }

        public virtual DataTable GetDT(string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, order);
        }

        public virtual DataTable GetDT(string[] ids)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, ids);
        }

        public virtual DataTable GetDT(string name, object value)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name, value);
        }

        public virtual DataTable GetDT(string name1, object value1, string name2, object value2)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name1, value1, name2, value2);
        }

        public virtual DataTable GetDT(string name1, object value1, string name2, object value2, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name1, value1, name2, value2, order);
        }

        public virtual DataTable GetDT(string name1, object value1, string name2, object value2, int topLimit, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name1, value1, name2, value2, topLimit, order);
        }

        public virtual DataTable GetDT(string name, object value, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name, value, order);
        }

        public virtual DataTable GetDT(string name, Object[] values, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name, values, order);
        }

        public virtual DataTable GetDT(int topLimit, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, topLimit, order);
        }

        public virtual DataTable GetDT(string name, object value, int topLimit, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, name, value, topLimit, order);
        }

        public virtual DataTable GetDT(string[] names, Object[] values)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, names, values);
        }

        public virtual DataTable GetDT(string[] names, Object[] values, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, names, values, order);
        }

        public virtual DataTable GetDT(string[] names, Object[] values, int topLimit, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, names, values, topLimit, order);
        }

        public virtual DataTable GetDT(KeyValuePair<string, object> parameter, string order)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, parameters, 0, order);
        }

        public virtual DataTable GetDT(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string order)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, parameters, 0, order);
        }

        public virtual DataTable GetDT(KeyValuePair<string, object> parameter, int topLimit = 0, string order = null)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, parameters, topLimit, order);
        }

        public virtual DataTable GetDT(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, parametersList);
        }

        public virtual DataTable GetDT(List<KeyValuePair<string, object>> parameters, int topLimit = 0, string order = null)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, parameters, topLimit, order);
        }

        public virtual DataTable GetDT(List<KeyValuePair<string, object>> parameters, string order)
        {
            return DbCommonLibary.GetDT(DBProvider, this.CurrentTableName, parameters, 0, order);
        }
    }
}