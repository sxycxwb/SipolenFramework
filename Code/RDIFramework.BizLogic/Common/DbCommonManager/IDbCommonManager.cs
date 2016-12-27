//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{

    /// <summary>
    ///	IDbCommonManager
    /// 通用接口部分
    /// 
    /// 
    /// 修改纪录
    ///     2012.02.05 版本：2.2 XuWangBin 增加“List<KeyValuePair<string, object>>”形式参数。
    ///		2011.11.01 版本：1.9 XuWangBin 改进 BUOperatorInfo 去掉这个变量，可以提高性能，提高速度，基类的又一次飞跃。
    ///		2011.05.23 版本：1.8 XuWangBin 修改完善了 对象事件触发器，完善了GetDT, ref 方法部分。
    ///		2011.05.20 版本：1.7 XuWangBin 修改完善了 对象事件触发器，完善了GetDT方法部分。
    ///		2011.05.19 版本：1.6 XuWangBin 修改完善了 Delete，Exists方法部分，累了休息一下下，争取周六周日两天内完成。
    ///		2011.05.18 版本：1.5 XuWangBin 规范了一些接口的标准方法，进行了补充。
    ///		2011.05.17 版本：1.4 XuWangBin 重新调整主键的规范化，整体上又上升了一个层次了。
    ///		2011.02.05 版本：1.3 XuWangBin 重新调整主键的规范化。
    ///		2010.08.19 版本：1.2 XuWangBin 参数进行改进
    ///		2009.07.23 版本：1.1 XuWangBin 增加了接口ClearProperty、GetFromDS 的定义。
    ///		2009.07.21 版本：1.0 XuWangBin 提炼了最基础的方法部分、觉得这些是很有必要的方法。
    ///
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2009.05.23</date>
    /// </author> 
    /// </summary>
    public interface IDbCommonManager
    {
        //
        // 类对应的数据库最终操作
        //
        string AddEntity(object entity);
        int UpdateEntity(object entity);
        int DeleteEntity(object id);
        //DataTable GetEntity(string id);
        //DataTable GetEntity(string name, object value);

        //
        // 对象事件触发器（编写程序的人员，可以不实现这些方法）
        //

        bool AddBefore();
        bool AddAfter();
        bool UpdateBefore();
        bool UpdateAfter();
        bool GetBefore(string id);
        bool GetAfter(string id);
        bool DeleteBefore(string id);
        bool DeleteAfter(string id);

        //
        // 添加逻辑编写
        //
        // string Add();

        //
        // 更新逻辑编写
        //
        // int Update();

        //
        // 批量操作保存
        //
        int BatchSave(DataTable dataTable);

        //
        // 读取一条记录
        //

        object GetFrom(DataTable dataTable);
        object GetFrom(DataTable dataTable, string id);
        object GetFrom(DataRow dataRow);

        //
        // 获得 Id 列表
        //
        string[] GetIds();
        string[] GetIds(string name, Object[] values);
        string[] GetIds(string order);
        string[] GetIds(string name, object value);
        string[] GetIds(string name1, object value1, string name2, object value2);
        string[] GetIds(string name1, object value1, string name2, object value2, string order);
        string[] GetIds(string name1, object value1, string name2, object value2, int topLimit, string order);
        string[] GetIds(string name, object value, string order);
        string[] GetIds(int topLimit, string order);
        string[] GetIds(string name, object value, int topLimit, string order);
        string[] GetIds(string[] names, Object[] values);
        string[] GetIds(string[] names, Object[] values, string order);
        string[] GetIds(string[] names, Object[] values, int topLimit, string order);

        string[] GetIds(KeyValuePair<string, object> parameter);
        string[] GetIds(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2);
        string[] GetIds(List<KeyValuePair<string, object>> parameters);

        string[] GetProperties(string order);
        string[] GetProperties(int topLimit, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter, int topLimit, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, int topLimit, string targetField);
        string[] GetProperties(List<KeyValuePair<string, object>> parameters, string targetField);
        string[] GetProperties(List<KeyValuePair<string, object>> parameters, int topLimit, string targetField);

        //
        // 读取多条记录
        //
        DataTable GetDTById(string id);
        DataTable GetDT();
        DataTable GetDT(string name, Object[] values);
        DataTable GetDT(string order);
        DataTable GetDT(string[] ids);
        DataTable GetDT(string name, object value);
        DataTable GetDT(string name1, object value1, string name2, object value2);
        DataTable GetDT(string name1, object value1, string name2, object value2, string order);
        DataTable GetDT(string name1, object value1, string name2, object value2, int topLimit, string order);
        DataTable GetDT(string name, object value, string order);
        DataTable GetDT(int topLimit, string order);
        DataTable GetDT(string name, object value, int topLimit, string order);
        DataTable GetDT(string[] names, Object[] values);
        DataTable GetDT(string[] names, Object[] values, string order);
        DataTable GetDT(string[] names, Object[] values, int topLimit, string order);

        DataTable GetDT(KeyValuePair<string, object> parameter, string order);
        DataTable GetDT(KeyValuePair<string, object> parameter, int topLimit, string order);
        DataTable GetDT(List<KeyValuePair<string, object>> parameters, string order);
        DataTable GetDT(List<KeyValuePair<string, object>> parameters, int topLimit, string order);

        //
        // 读取多条记录
        //      
        List<T> GetListById<T>(string id) where T : BaseEntity, new();
        List<T> GetListByCategory<T>(string categoryId) where T :BaseEntity,new();
        List<T> GetList<T>(string where, int topLimit = 0, string order = null) where T : BaseEntity, new();
        List<T> GetList<T>(int topLimit = 0, string order = null) where T : BaseEntity, new();
        List<T> GetList<T>(string where) where T : BaseEntity, new();
        List<T> GetList<T>(string[] ids) where T : BaseEntity, new();
        List<T> GetList<T>(string name, Object[] values, string order = null) where T : BaseEntity, new();
        List<T> GetList<T>(KeyValuePair<string, object> parameter, string order) where T : BaseEntity, new();
        List<T> GetList<T>(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string order) where T : BaseEntity, new();
        List<T> GetList<T>(KeyValuePair<string, object> parameter, int topLimit, string order) where T : BaseEntity, new();
        List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, string order) where T : BaseEntity, new();
        List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, int topLimit, string order) where T : BaseEntity, new();
        List<T> GetList<T>(params KeyValuePair<string, object>[] parameters) where T : BaseEntity, new();

        //
        // 读取属性
        //
        string GetProperty(object id, string targetField);
        string GetProperty(string name1, object value1, string name2, object value2, string targetField);
        string GetProperty(string[] names, object[] values, string targetField);
        string GetId(string name, object value);
        string GetId(string name1, object value1, string name2, object value2);
        string GetId(string[] names, object[] values);

        string GetProperty(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField);
        string GetProperty(List<KeyValuePair<string, object>> parameters, string targetField);
        string GetId(KeyValuePair<string, object> parameter);
        string GetId(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2);
        string GetId(List<KeyValuePair<string, object>> parameters);
        string GetId(params KeyValuePair<string, object>[] parameters);


        //
        // 设置属性
        //
        int SetProperty(object id, string targetField, object targetValue);
        int SetProperty(object id, string[] targetFields, object[] targetValues);
        int SetProperty(string name1, object value1, string name2, object value2, string targetField, object targetValue);
        int SetProperty(object[] ids, string targetField, object targetValue);
        int SetProperty(string[] names, object[] values, string targetField, object targetValue);

        int SetProperty(KeyValuePair<string, object> parameter);
        int SetProperty(object id, KeyValuePair<string, object> parameter);
        int SetProperty(object id, List<KeyValuePair<string, object>> parameters);
        int SetProperty(object[] ids, KeyValuePair<string, object> parameter);
        int SetProperty(object[] ids, List<KeyValuePair<string, object>> parameters);
        int SetProperty(string name, object[] values, KeyValuePair<string, object> parameter);
        int SetProperty(string name, object[] values, List<KeyValuePair<string, object>> parameters);
        int SetProperty(KeyValuePair<string, object> whereParameter1, KeyValuePair<string, object> whereParameter2, KeyValuePair<string, object> parameter);
        int SetProperty(KeyValuePair<string, object> whereParameter, KeyValuePair<string, object> parameter);
        int SetProperty(List<KeyValuePair<string, object>> whereParameters, KeyValuePair<string, object> parameter);
        int SetProperty(KeyValuePair<string, object> whereParameter, List<KeyValuePair<string, object>> parameters);
        int SetProperty(List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters);
        //
        // 判断数据是否存在
        //
        bool Exists(object id);
        bool Exists(object[] ids);
        bool Exists(string name, object value);
        bool Exists(string name, object value, object id);
        bool Exists(string name1, object value1, string name2, object value2);
        bool Exists(string name1, object value1, string name2, object value2, object id);
        bool Exists(string[] names, object[] values);
        bool Exists(params KeyValuePair<string, object>[] parameters);
        bool Exists(KeyValuePair<string, object> parameter, object id);
        bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter);
        bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, object id);
        bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, KeyValuePair<string, object> parameter);
        bool Exists(List<KeyValuePair<string, object>> parameters, object id);
        //
        // 删除数据部分
        // force 是否强制删除关联数据
        //
        int Delete();
        int Delete(object id);
        int Delete(object id, bool force);
        int Delete(object[] ids);
        int Delete(object[] ids, bool force);
        int Delete(string name, object value);
        int Delete(string name, object value, bool force);
        int Delete(string[] names, object[] values);
        int Delete(string[] names, object[] values, bool force);
        int Delete(string name1, object value1, string name2, object value2);
        int Delete(string name1, object value1, string name2, object value2, bool force);
        int Truncate();
        int Delete(params KeyValuePair<string, object>[] parameters);
        int Delete(List<KeyValuePair<string, object>> parameters);
        /// 直接执行一些SQL语句的方法

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string commandText);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters);
        
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>object</returns>
        object ExecuteScalar(string commandText);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters);

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        DataTable Fill(string commandText);

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        DataTable Fill(string commandText, IDbDataParameter[] dbParameters);
    }
}