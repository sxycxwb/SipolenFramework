/*******************************************************************************
 * Copyright © 2016 Sipolen.Framework 版权所有
 * Author: Sipolen
 * Description: Sipolen快速开发平台
 * Website：http://www.Sipolen.cn
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Sipolen.Code
{
    /// <summary>
    /// DataTable相关扩展类
    /// </summary>
    public static class ExtDataTable
    {
        /// <summary>
        /// 断言一个DATATABLE数据集是否有效
        /// </summary>
        /// <param name="table">DATATABLE数据集有效</param>
        /// <returns>
        /// 当数据集为NULL或者空或数据集的第一个数据表的行数为0，返回false，否则为true;
        /// </returns>
        public static bool Assert(this DataTable table)
        {
            return !(table == null || table.Rows.Count == 0);
        }

        /// <summary>
        /// DataTable 转换为List 集合
        /// </summary>
        /// <typeparam name="TResult">类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<TResult> ToList<TResult>(this DataTable dt) where TResult : class, new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(TResult);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表 
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            //创建返回的集合
            List<TResult> oblist = new List<TResult>();

            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例
                TResult ob = new TResult();
                //找到对应的数据  并赋值
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                //放入到返回的集合中.
                oblist.Add(ob);
            }
            return oblist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <param name="fn"></param>
        /// em:DataTable dt = query.ToDataTable(rec => new object[] { query }); 
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist, CreateRowDelegate<T> fn)
        {
            DataTable dtReturn = new DataTable();
            // column names
            PropertyInfo[] oProps = null;
            // Could add a check to verify that there is an element 0
            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType; if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow(); foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return (dtReturn);
        }

        public delegate object[] CreateRowDelegate<T>(T t);

        /// <summary>
        /// 转换为一个DataTable
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        ///// <param name="value"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this IEnumerable list)
        {
            //创建属性的集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口
            Type type = list.AsQueryable().ElementType;
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 转换为一个DataTable
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        ///// <param name="value"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<TResult>(this IEnumerable<TResult> value) where TResult : class
        {
            //创建属性的集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口
            Type type = typeof(TResult);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in value)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
