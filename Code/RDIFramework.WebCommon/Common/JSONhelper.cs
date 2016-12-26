﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using RDIFramework.WebCommon.DbHelper.SqlServer;

namespace RDIFramework.WebCommon
{
    /// <summary>
    /// JSON 帮助类
    /// 
    ///     2015-03-31 V2.8 EricHu 新增：Json数据转换为泛型集合(或实体).
    /// </summary>
    public static class JSONhelper
    {
        /// <summary>
        /// 将JSON转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static T ConvertToObject<T>(string json)
        {
            var jsetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            //jsetting.DefaultValueHandling = DefaultValueHandling.Include;
            return JsonConvert.DeserializeObject<T>(json, jsetting);
        }


        /// <summary>
        /// 生成压缩的json 字符串
        /// </summary>
        /// <param name="obj">生成json的对象</param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            return ToJson(obj, false);
        }

        /// <summary>
        /// 生成JSON字符串
        /// </summary>
        /// <param name="obj">生成json的对象</param>
        /// <param name="formatjson">是否格式化</param>
        /// <returns></returns>
        public static string ToJson(object obj, bool formatjson)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            IsoDateTimeConverter idtc = new IsoDateTimeConverter();
            idtc.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(idtc);
            JsonWriter jw = new JsonTextWriter(sw);

            if (formatjson)
            {
                jw.Formatting = Formatting.Indented;
            }

            serializer.Serialize(jw, obj);

            //JsonConvert.SerializeObject(dt, idtc).ToString();

            return sb.ToString();
        }

        public static DateTime JsonToDateTime(string jsonDate)
        {
            string value = jsonDate.Substring(6, jsonDate.Length - 8);
            DateTimeKind kind = DateTimeKind.Utc;
            int index = value.IndexOf('+', 1);
            if (index == -1)
                index = value.IndexOf('-', 1);
            if (index != -1)
            {
                kind = DateTimeKind.Local;
                value = value.Substring(0, index);
            }
            long javaScriptTicks = long.Parse(value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
            long InitialJavaScriptDateTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
            DateTime utcDateTime = new DateTime((javaScriptTicks * 10000) + InitialJavaScriptDateTicks, DateTimeKind.Utc);
            DateTime dateTime;
            switch (kind)
            {
                case DateTimeKind.Unspecified:
                    dateTime = DateTime.SpecifyKind(utcDateTime.ToLocalTime(), DateTimeKind.Unspecified);
                    break;
                case DateTimeKind.Local:
                    dateTime = utcDateTime.ToLocalTime();
                    break;
                default:
                    dateTime = utcDateTime;
                    break;
            }
            return dateTime;
        }

        /// <summary>
        /// 将数据源转换为JQGRID的JSON格式
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页尺寸</param>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        public static string ConvertTojQgridJSON<T>(int pageindex, int pagesize, IList<T> list)
        {
            int recordcount = list.Count;
            int pagecount = SqlEasy.GetDataPages(pagesize, recordcount);
            IList<T> _list = list.Skip<T>((pageindex - 1) * pagesize).Take<T>(pagesize).ToList<T>();

            string json = FormatJSONForJQgrid(pagecount, pageindex, recordcount, _list);

            return json;
        }

        /// <summary>
        /// 获取指定表的数据，并转换为jqgrid 的JSON格式。适用于sql2000 以上版本
        /// </summary>
        /// <param name="pageindex">当前第几页</param>
        /// <param name="pagesize">每页记录条数</param>
        /// <param name="orderfield">排序字段 如：id asc,name desc</param>
        /// <param name="key">主键</param>
        /// <param name="where">筛选条件</param>
        /// <param name="tbname">表或视图名</param>
        /// <returns></returns>
        public static string GetJsonforjQgrid(int pageindex, int pagesize, string orderfield, string key, string where, string tbname)
        {
            return GetJsonforjQgrid("*", pageindex, pagesize, orderfield, key, where, tbname);
        }

        /// <summary>
        /// 获取指定表的数据，并转换为jqgrid 的JSON格式。适用于sql2000 以上版本
        /// </summary>
        /// <param name="fields">要选取的列，以逗号隔开</param>
        /// <param name="pageindex">当前第几页</param>
        /// <param name="pagesize">每页记录条数</param>
        /// <param name="orderfield">排序</param>
        /// <param name="key">关键字</param>
        /// <param name="where">条件</param>
        /// <param name="tbname">表名或视图名</param>
        /// <returns></returns>
        public static string GetJsonforjQgrid(string fields,int pageindex, int pagesize, string orderfield, string key, string where, string tbname)
        {
            int recordcount = 0;


            DataTable dt = SqlEasy.GetDataByPager2000(fields, tbname, where, orderfield, key, pageindex, pagesize, out recordcount);
            int pagecount = SqlEasy.GetDataPages(pagesize, recordcount);

            string json = FormatJSONForJQgrid(pagecount, pageindex, recordcount, dt);

            return json;
        }

        public static string FormatJSONForJQgrid(int totalpages, int pageindex, int recordcount, object list)
        {
            var json = new { total = totalpages, page = pageindex, records = recordcount, rows = list };
            return ToJson(json);
        }


        /// <summary>
        /// 获取easyui datagrid 所需要的JSON数据
        /// </summary>
        /// <param name="pageindex">第几页</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="keyfield">主键字段名</param>
        /// <param name="where">条件</param>
        /// <param name="sort">排序字段</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static string GetJsonForEasyuiDatagrid(int pageindex, int pagesize, string keyfield, string where, string sort, string tablename)
        {
            return GetJsonForEasyuiDatagrid("*", pageindex, pagesize, keyfield, where, sort, tablename);
        }

        /// <summary>
        /// 获取easyui datagrid 所需要的JSON数据
        /// </summary>
        /// <param name="fields">字段列表，以逗号隔开</param>
        /// <param name="pageindex">第几页</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="keyfield">主键字段名</param>
        /// <param name="where">条件</param>
        /// <param name="sort">排序字段</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static string GetJsonForEasyuiDatagrid(string fields, int pageindex, int pagesize, string keyfield, string where, string sort, string tablename)
        {
            int recordcount = 0;

            DataTable dt = SqlEasy.GetDataByPager2000(fields, tablename, where, sort, keyfield, pageindex, pagesize, out recordcount);

            string s = FormatJSONForEasyuiDataGrid(recordcount, ToJson(dt));
            return s;
        }

        /// <summary>
        /// 格式化EASYUI DATAGRID JSON
        /// </summary>
        /// <param name="recordcount">总记录数</param>
        /// <param name="rowsList">每页记录的JSON格式</param>
        /// <returns></returns>
        public static string FormatJSONForEasyuiDataGrid(int recordcount, object rowsList)
        {
            return ToJson(new { total = recordcount, rows = rowsList });
        }

        #region Json数据转换为泛型集合(或实体)

        /// <summary>
        /// 单条json数据转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">字符串（格式为{a:'',b:''}）</param>
        /// <returns></returns>
        public static T ConvertToEntity<T>(string str)
        {
            Type t = typeof(T);
            object obj = Activator.CreateInstance(t);
            var properties = t.GetProperties();
            string m = str.Trim('{').Trim('}');
            string[] arr = m.Split(',');
            for (int i = 0; i < arr.Count(); i++)
            {
                for (int k = 0; k < properties.Count(); k++)
                {
                    string Name = arr[i].Substring(0, arr[i].IndexOf(":"));
                    object Value = arr[i].Substring(arr[i].IndexOf(":") + 1);
                    if (properties[k].Name.Equals(Name))
                    {
                        if (properties[k].PropertyType.Equals(typeof(int)))
                        {
                            properties[k].SetValue(obj, Convert.ToInt32(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(string)))
                        {
                            properties[k].SetValue(obj, Convert.ToString(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(long)))
                        {
                            properties[k].SetValue(obj, Convert.ToInt64(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(decimal)))
                        {
                            properties[k].SetValue(obj, Convert.ToDecimal(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(double)))
                        {
                            properties[k].SetValue(obj, Convert.ToDouble(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(Nullable<int>)))
                        {
                            properties[k].SetValue(obj, Convert.ToInt32(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(Nullable<decimal>)))
                        {
                            properties[k].SetValue(obj, Convert.ToDecimal(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(Nullable<long>)))
                        {
                            properties[k].SetValue(obj, Convert.ToInt64(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(Nullable<double>)))
                        {
                            properties[k].SetValue(obj, Convert.ToDouble(Value), null);
                        }
                        if (properties[k].PropertyType.Equals(typeof(Nullable<DateTime>)))
                        {
                            properties[k].SetValue(obj, Convert.ToDateTime(Value), null);
                        }

                    }
                }

            }
            return (T)obj;
        }

        /// <summary>
        /// 多条Json数据转换为泛型数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonArr">字符串（格式为[{a:'',b:''},{a:'',b:''},{a:'',b:''}]）</param>
        /// <returns></returns>
        public static List<T> ConvertTolist<T>(this string jsonArr)
        {
            if (!string.IsNullOrEmpty(jsonArr) && jsonArr.StartsWith("[") && jsonArr.EndsWith("]"))
            {
                Type t = typeof(T);
                var proPerties = t.GetProperties();
                List<T> list = new List<T>();
                string recive = jsonArr.Trim('[').Trim(']').Replace("'", "").Replace("\"", "");
                string[] reciveArr = recive.Replace("},{", "};{").Split(';');
                foreach (var item in reciveArr)
                {
                    T obj = ConvertToEntity<T>(item);
                    list.Add(obj);
                }
                return list;
            }
            return null;

        }
        #endregion
    }
}
