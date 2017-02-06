/*******************************************************************************
 * Copyright © 2016 Sipolen.Framework 版权所有
 * Author: Sipolen
 * Description: Sipolen快速开发平台
 * Website：http://www.Sipolen.cn
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Data;
using System.IO;
using System.Reflection;
using NPOI.SS.Formula.Functions;

namespace Sipolen.Code.Excel
{
    public class NPOIExcel
    {
        private string _title;
        private string _sheetName;
        private string _filePath;

        #region DataTable转List

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<T> ConvertTo<T>(DataTable table, bool isChangeHeader = false) where T : class, new()
        {
            if (table == null)
                return null;
            if (isChangeHeader)
                SetDataTableHeader<T>(table, false);

            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
                rows.Add(row);

            return ConvertTo<T>(rows);
        }

        //Convert DataRow into T Object
        public static T CreateItem<T>(DataRow row)
        {
            string columnName;
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    columnName = column.ColumnName;
                    //Get property with same columnName
                    PropertyInfo prop = obj.GetType().GetProperty(columnName);
                    try
                    {
                        //Get value for the column
                        object value = (row[columnName].GetType() == typeof(DBNull))
                        ? null : row[columnName];
                        //Set property value
                        if (prop.CanWrite) //判断其是否可写
                        {
                            //判断时间类型
                            if (prop.PropertyType.FullName.Contains("System.DateTime"))
                            {
                                if (string.IsNullOrEmpty(value.ToString()))
                                    value = null;
                                else
                                    value = Convert.ToDateTime(value);
                            }
                            prop.SetValue(obj, value, null);
                        }

                    }
                    catch
                    {
                        throw;
                        //Catch whatever here
                    }
                }
            }
            return obj;
        }

        public IList<T> ConvertToModel<T>(DataTable dt, bool isChangeHeader = false) where T : class, new()
        {
            if (isChangeHeader)
                SetDataTableHeader<T>(dt, false);

            IList<T> ts = new List<T>();// 定义集合
            Type type = typeof(T); // 获得此模型的类型
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                ts.Add(t);
            }
            return ts;
        }

        #endregion

        #region 为DataTable设置表头
        /// <summary>
        /// 为DataTable设置表头
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">表格</param>
        /// <param name="LetterConvertDescripiton">是否由字母转描述</param>
        private void SetDataTableHeader<T>(DataTable table, bool LetterConvertDescripiton = true) where T : class, new()
        {
            #region 得到实体字段字典escription

            var dic = new Dictionary<string, string>();
            T o = new T();
            //获取指定类型的公共属性
            PropertyInfo[] propertys = o.GetType().GetProperties();
            foreach (var item in propertys)
            {
                var v = (DescriptionAttribute[])item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var descriptionName = v[0].Description;
                var fieldName = item.Name;
                if (LetterConvertDescripiton) //字母转描述
                {
                    table.Columns[fieldName].ColumnName = descriptionName;
                }
                else//描述转字母
                {
                    table.Columns[descriptionName].ColumnName = fieldName;
                }
            }

            #endregion
        }

        private class EnumHelper
        {
            /// <summary>
            /// 获取枚举值上的Description特性的说明
            /// </summary>
            /// <typeparam name="T">枚举类型</typeparam>
            /// <param name="obj">枚举值</param>
            /// <returns>特性的说明</returns>
            public static string GetEnumDescription<T>(T obj)
            {
                var type = obj.GetType();
                FieldInfo field = type.GetField(Enum.GetName(type, obj));
                DescriptionAttribute descAttr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descAttr == null)
                {
                    return string.Empty;
                }

                return descAttr.Description;
            }
        }

        #endregion

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool ToExcel(DataTable table)
        {
            #region 文件夹判断
            var rootPath = _filePath.Substring(0, _filePath.LastIndexOf('\\') + 1);
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath); //不存在就创建文件夹
            }
            #endregion

            FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            IWorkbook workBook = new HSSFWorkbook();
            this._sheetName = this._sheetName.IsEmpty() ? "sheet1" : this._sheetName;
            ISheet sheet = workBook.CreateSheet(this._sheetName);

            //处理表格标题
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue(this._title);
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, table.Columns.Count - 1));
            row.Height = 500;

            ICellStyle cellStyle = workBook.CreateCellStyle();
            IFont font = workBook.CreateFont();
            font.FontName = "微软雅黑";
            font.FontHeightInPoints = 17;
            cellStyle.SetFont(font);
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.Alignment = HorizontalAlignment.Center;
            row.Cells[0].CellStyle = cellStyle;

            //处理表格列头
            row = sheet.CreateRow(1);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                row.CreateCell(i).SetCellValue(table.Columns[i].ColumnName);
                row.Height = 350;
                sheet.AutoSizeColumn(i);
            }

            //处理数据内容
            for (int i = 0; i < table.Rows.Count; i++)
            {
                row = sheet.CreateRow(2 + i);
                row.Height = 250;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(table.Rows[i][j].ToString());
                    sheet.SetColumnWidth(j, 256 * 15);
                }
            }

            //写入数据流
            workBook.Write(fs);
            fs.Flush();
            fs.Close();

            return true;
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="title"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool ToExcel(DataTable table, string title, string sheetName, string filePath)
        {
            this._title = title;
            this._sheetName = sheetName;
            this._filePath = filePath;
            return ToExcel(table);
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="filePath">文件保存路径</param>
        /// <param name="title">Excel标题</param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool ToExcel<T>(DataTable table, string filePath, string title = "", string sheetName = "") where T : class, new()
        {
            this._title = title;
            this._sheetName = sheetName;
            this._filePath = filePath;
            SetDataTableHeader<T>(table);//设置表头
            return ToExcel(table);
        }
    }
}
