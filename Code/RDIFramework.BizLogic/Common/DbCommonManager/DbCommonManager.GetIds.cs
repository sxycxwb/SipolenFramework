//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

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
        // 获得主键列表
        //

        /// <summary>
        /// 获得主键
        /// </summary>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>对应的值</returns>
        public virtual string GetId(string name, object value)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, name, value, BusinessLogic.FieldId);
        }

        /// <summary>
        /// 获得主键
        /// </summary>
        /// <param name="name1">字段名1</param>
        /// <param name="value1">字段值1</param>
        /// <param name="name2">字段名2</param>
        /// <param name="value2">字段值2</param>
        /// <returns>对应的值</returns>
        public virtual string GetId(string name1, object value1, string name2, object value2)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, name1, value1, name2, value2, BusinessLogic.FieldId);
        }

        /// <summary>
        /// 获得主键
        /// </summary>
        /// <param name="names">字段数组</param>
        /// <param name="values">字段值数组</param>
        /// <returns>对应的值</returns>
        public virtual string GetId(string[] names, object[] values)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, names, values, BusinessLogic.FieldId);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds()
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="topLimit">取前面多少条数据</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(int topLimit, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, topLimit, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name, object value)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name, value);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name, object value, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name, value, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="topLimit">取前面多少条数据</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name, object value, int topLimit, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name, value, topLimit, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name1">字段名1</param>
        /// <param name="value1">字段值1</param>
        /// <param name="name2">字段名2</param>
        /// <param name="value2">字段值2</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name1, object value1, string name2, object value2)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name1, value1, name2, value2);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name1">字段名1</param>
        /// <param name="value1">字段值1</param>
        /// <param name="name2">字段名2</param>
        /// <param name="value2">字段值2</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name1, object value1, string name2, object value2, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name1, value1, name2, value2, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name1">字段名1</param>
        /// <param name="value1">字段值1</param>
        /// <param name="name2">字段名2</param>
        /// <param name="value2">字段值2</param>
        /// <param name="topLimit">取前面多少条数据</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name1, object value1, string name2, object value2, int topLimit, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name1, value1, name2, value2, topLimit, targetField);
        }

        //public virtual string[] GetIds(string name, Object[] values)
        //{
        //    return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name, values);
        //}

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值数组</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name, Object[] values, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, name, values, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="names">字段名数组</param>
        /// <param name="values">字段值数组</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string[] names, Object[] values)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, names, values);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="names">字段名数组</param>
        /// <param name="values">字段值数组</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string[] names, Object[] values, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, names, values, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="names">字段名数组</param>
        /// <param name="values">字段值数组</param>
        /// <param name="topLimit">取前面多少条数据</param>
        /// <param name="targetField">主键名</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string[] names, Object[] values, int topLimit, string targetField)
        {
            return DbCommonLibary.GetIds(DBProvider, this.CurrentTableName, names, values, topLimit, targetField);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="parameter1">键值对（字段名/字段值）</param>
        /// <param name="parameter2">键值对（字段名/字段值）</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, 0, BusinessLogic.FieldId);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="parameter">键值对（字段名/字段值）</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, 0, BusinessLogic.FieldId);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="name">字段名</param>
        /// <param name="values">字段值数组</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(string name, Object[] values)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, name, values, BusinessLogic.FieldId);
        }

        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="parameters">键值对（字段名/字段值）列表</param>
        /// <returns>主键列表</returns>
        public virtual string[] GetIds(List<KeyValuePair<string, object>> parameters)
        {
            return DbCommonLibary.GetProperties(DBProvider, this.CurrentTableName, parameters, 0, BusinessLogic.FieldId);
        }
    }
}