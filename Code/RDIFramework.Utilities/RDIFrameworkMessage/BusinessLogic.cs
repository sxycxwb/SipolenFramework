//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace RDIFramework.Utilities
{
    /// <summary>
    ///	BusinessLogic
    /// 通用基类
    /// 
    /// 这个类可是修改了很多次啊，已经比较经典了，随着专业的提升，人也会不断提高，技术也会越来越精湛。
    /// 
    /// 修改纪录
    ///     2016-01-23 EricHu V3.0 新增：GetModelByDataRow 通过DataRow 填充实体  
    ///     2015-09-10 EricHu V3.0 把类型转换ConvertTo类型的方便分离到单独的文件，并增加可空与非空各类型转换公共方法。
    ///     2014-03-28 EricHu V2.8 再次重构本基类，代码健壮性再度提升。
    ///	
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2011.08.01</date>
    /// </author> 
    /// </summary>
    public partial class BusinessLogic
    {
        public static string FieldId             = "ID";                // 主键字段
        public static string FieldParentId       = "PARENTID";          // 上级字段
        public static string FieldCode           = "CODE";              // 编号字段
        public static string FieldFullName       = "FULLNAME";          // 名称字段
        public static string FieldCategoryId     = "CATEGORYID";        // 类别字段
        public static string FieldEnabled        = "ENABLED";           // 有效字段
        public static string FieldDeleteMark     = "DELETEMARK";        // 删除标志
        public static string FieldSortCode       = "SORTCODE";          // 排序码
        public static string FieldCreateUserId   = "CREATEUSERID";      // 创建者主键
        public static string FieldCreateOn       = "CREATEON";          // 创建时间
        public static string FieldModifiedUserId = "MODIFIEDUSERID";    // 最后修改者主键
        public static string FieldModifiedOn     = "MODIFIEDON";        // 最后修改时间
        public static string SQLLogicConditional = " AND ";             // 查询逻辑
        public static string SelectedColumn      = "Selected";          // 选择列


        /// <summary>
        /// 检查转移
        /// </summary>
        /// <param name="selectedId">选择的主键</param>
        /// <returns>是否成功</returns>
        public delegate bool CheckMoveEventHandler(string selectedId);

        /// <summary>
        /// 选择主键发生变化
        /// </summary>
        /// <param name="selectedId">选择的主键</param>
        public delegate void SelectedIndexChangedEventHandler(string selectedId);

        #region public static string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public static string SqlSafe(string value)
        {
            value = value.Replace("'", "''");
            // value = value.Replace("%", "'%");
            return value;
        }
        #endregion

        #region public static string NewGuid() 获得 Guid
        /// <summary>
        /// 获得 Guid
        /// </summary>
        /// <returns>主键</returns>
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion

        #region public static string GetDbProviderClass(CurrentDbType dbType):按数据类型获取数据库访问实现类
        /// <summary>
        /// 按数据类型获取数据库访问实现类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库访问实现类</returns>
        public static string GetDbProviderClass(CurrentDbType dbType)
        {
            string returnValue = "RDIFramework.Utilities.SqlProvider";
            switch (dbType)
            {
                case CurrentDbType.SqlServer:
                    returnValue = "RDIFramework.Utilities.SqlProvider";
                    break;
                case CurrentDbType.Oracle:
                    returnValue = "RDIFramework.Utilities.MSOracleProvider";
                    break;
                case CurrentDbType.MySql:
                    returnValue = "RDIFramework.Utilities.MySqlProvider";
                    break;
                case CurrentDbType.DB2:
                    returnValue = "RDIFramework.Utilities.DB2Provider";
                    break;
                case CurrentDbType.SQLite:
                    returnValue = "RDIFramework.Utilities.SqLiteProvider";
                    break;
            }
            return returnValue;
        }
        #endregion

        #region public static bool IsKeywords(string field):判断是否关键字
        /// <summary>
        /// 判断是否关键字
        /// </summary>
        /// <param name="field">字段</param>
        /// <returns>是关键字</returns>
        public static bool IsKeywords(string field)
        {
            bool returnValue = false;
            // 首字母进行强制大写改进
            field = field.Substring(0, 1).ToUpper() + field.Substring(1);
            string[] keywords = { "ID", "SORTCODE", "DELETEMARK", "ENABLED", "CREATEON", "CREATEUSERID", "CREATEBY", "MODIFIEDON", "MODIFIEDUSERID", "MODIFIEDBY" };

            foreach (string tField in keywords.Where(tField => field != null && tField.ToUpper().Equals(field.ToUpper())))
            {
                field = tField;
                returnValue = true;
                break;
            }
            return returnValue;
        }
        #endregion

        #region public static DataTable SetColumnsFilter(DataTable dataTable, string[] columns):过滤表中的字段
        /// <summary>
        /// 过滤表中的字段
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="columns">过滤字段</param>
        /// <returns>过滤后的结果</returns>
        public static DataTable SetColumnsFilter(DataTable dataTable, string[] columns)
        {
            for (int i = dataTable.Columns.Count - 1; i > 0; i--)
            {
                // 不是关键字的才过滤，全过滤了，没法用了
                if (!IsKeywords(dataTable.Columns[i].ColumnName))
                {
                    // 都统一转为大写，比较省事一些，有必要时再改
                    if (!Exists(columns, dataTable.Columns[i].ColumnName))
                    {
                        dataTable.Columns.RemoveAt(i);
                    }
                }
            }
            return dataTable;
        }
        #endregion

        #region public static bool Exists(DataTable dataTable, string fieldName, string fieldValue):判断数据表中指定字段的指定值是否存在
        /// <summary>
        /// 判断数据表中指定字段的指定值是否存在
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns>存在:true；不存在：false</returns>
        public static bool Exists(DataTable dataTable, string fieldName, string fieldValue)
        {
            bool returnValue = false;
            if (dataTable == null)
            {
                return returnValue;
            }
            return dataTable.Rows.Cast<DataRow>().Any(dataRow => dataRow[fieldName].ToString().Equals(fieldValue));
        }
        #endregion

        #region public static bool IsAuthorized(DataTable dataTable, string permissionItemCode) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public static bool IsAuthorized(DataTable dataTable, string permissionItemCode)
        {
            return Exists(dataTable, FieldCode, permissionItemCode);
        }
        #endregion

        #region public static PermissionScope GetPermissionScope(string[] organizeIds):获取权限范围的设置
        /// <summary>
        /// 获取权限范围的设置
        /// </summary>
        /// <param name="organizeIds">有权限的组织机构</param>
        /// <returns>权限范围</returns>
        public static PermissionScope GetPermissionScope(string[] organizeIds)
        {
            return ((PermissionScope[])Enum.GetValues(typeof(PermissionScope))).FirstOrDefault(permissionScope => BusinessLogic.Exists(organizeIds, permissionScope.ToString()));

            //PermissionScope returnValue = PermissionScope.None;
            //foreach (PermissionScope permissionScope in (PermissionScope[])Enum.GetValues(typeof(PermissionScope)))
            //{
            //    if (BusinessLogic.Exists(organizeIds, permissionScope.ToString()))
            //    {
            //        returnValue = permissionScope;
            //        break;
            //    }
            //}
            //return returnValue;
        }
        #endregion

        //
        // WebService 传递参数的专用方法
        //

        #region public static byte[] GetBinaryFormatData(DataTable dataTable):从服务器取数据,转换DataTable为二进制格式
        /// <summary>
        /// 从服务器取数据,转换DataTable为二进制格式
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>二进制格式</returns>
        public static byte[] GetBinaryFormatData(DataTable dataTable)
        {
            byte[] ArrayResult          = null;
            dataTable.RemotingFormat    = SerializationFormat.Binary;
            MemoryStream memoryStream   = new MemoryStream();
            IFormatter IFormatter       = new BinaryFormatter();
            IFormatter.Serialize(memoryStream, dataTable);
            ArrayResult                 = memoryStream.ToArray();
            memoryStream.Close();
            memoryStream.Dispose();
            return ArrayResult;
        }
        #endregion

        #region public static DataTable RetrieveDataSet(byte[] ArrayResult) 客户端接收到byte[]格式的数据,对其进行反序列化,得到数据表,进行客户端操作.
        /// <summary>
        /// 客户端接收到byte[]格式的数据,对其进行反序列化,得到数据表,进行客户端操作.
        /// </summary>
        /// <param name="arrayResult">二进制格式</param>
        /// <returns>数据表</returns>
        public static DataTable RetrieveDataTable(byte[] arrayResult)
        {
            DataTable dataTable = null;
            MemoryStream memoryStream = new MemoryStream(arrayResult);
            IFormatter IFormatter = new BinaryFormatter();
            Object targetObject = IFormatter.Deserialize(memoryStream);
            memoryStream.Close();
            memoryStream.Dispose();
            dataTable = (DataTable)targetObject;
            return dataTable;
        }
        #endregion

        //
        // 非数据库的常用方法
        //

        #region public static string RepeatString(string targetString, int repeatCount) 重复字符串
        /// <summary>
        /// 重复字符串
        /// </summary>
        /// <param name="targetString">目标字符串</param>
        /// <param name="repeatCount">重复次数</param>
        /// <returns>结果字符串</returns>
        public static string RepeatString(string targetString, int repeatCount)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < repeatCount; i++)
            {
                returnValue += targetString;
            }
            return returnValue;
        }
        #endregion

        #region public static string FieldToList(DataTable dataTable) 表格字段转换为字符串列表
        /// <summary>
        /// 表格字段转换为字符串列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>字段值字符串</returns>
        public static string FieldToList(DataTable dataTable)
        {
            return FieldToList(dataTable, FieldId);
        }
        #endregion

        #region public static string FieldToList(DataTable dataTable, string name) 表格字段转换为字符串列表
        /// <summary>
        /// 表格字段转换为字符串列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="name">列名</param>
        /// <returns>字段值字符串</returns>
        public static string FieldToList(DataTable dataTable, string name)
        {
            int rowCount = 0;
            string returnValue = "'";
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    rowCount++;
                    returnValue += dataRow[name] + "', '";
                }
            }
            returnValue = rowCount == 0 ? "''" : returnValue.Substring(0, returnValue.Length - 3);
            return returnValue;
        }
        #endregion

        #region public static string ArrayToList(string[] ids)

        public static string ArrayToList(ArrayList ids)
        {
            if (ids != null && ids.Count > 0)
            {
                var tmpArray = new String[ids.Count];
                for (int idx = 0; idx < ids.Count; idx++)
                {
                    tmpArray[idx] = BusinessLogic.ConvertToString(ids[idx]);
                }
                return ArrayToList(tmpArray, string.Empty);
                
            }
            return string.Empty;
        }

        public static string ArrayToList(string[] ids)
        {
            return ArrayToList(ids, string.Empty);
        }

        public static string ArrayToList(string[] ids, string separativeSign)
        {
            int rowCount = 0;
            string returnValue = string.Empty;
            if (ids != null)
            {
                foreach (string id in ids)
                {
                    rowCount++;
                    returnValue += separativeSign + id + separativeSign + ",";
                }
            }
            returnValue = rowCount == 0 ? "" : returnValue.TrimEnd(',');
            return returnValue;
        }
        #endregion

        #region public static string[] FieldToArray(DataTable dataTable, string name) 表格字段转换为字符串数组
        /// <summary>
        /// 表格字段转换为字符串数组
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="name">列名</param>
        /// <returns>字段值数组</returns>
        public static string[] FieldToArray(DataTable dataTable, string name)
        {
            var returnValue = new string[0];
            var rowCount = 0;
            string stringList = string.Empty;
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows.Cast<DataRow>().Where(dataRow => !string.IsNullOrEmpty(dataRow[name].ToString())))
                {
                    rowCount++;
                    stringList += dataRow[name] + ",";
                }
            }

            if (rowCount > 0)
            {
                stringList = stringList.TrimEnd(',');
                returnValue = stringList.Split(',');
            }
            return returnValue;
        }
        #endregion

        #region public static string ObjectsToList(object ids) 字段值数组转换为字符串列表
        /// <summary>
        /// 字段值数组转换为字符串列表
        /// </summary>
        /// <param name="ids">字段值</param>
        /// <returns>字段值字符串</returns>
        public static string ObjectsToList(Object[] ids)
        {
            string returnValue = string.Empty;
            string stringList = ids.Aggregate("'", (current, t) => current + (t + "', '"));
            returnValue = ids.Length == 0 ? " NULL " : stringList.Substring(0, stringList.Length - 3);
            return returnValue;
        }
        #endregion

        #region public static DataTable SetFilter(DataTable dataTable, string fieldName, string fieldValue, bool equals = false) 对数据表进行过滤
        /// <summary>
        /// 对数据表进行过滤
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="equals">相等</param>
        /// <returns>数据权限</returns>
        public static DataTable SetFilter(DataTable dataTable, string fieldName, string fieldValue, bool equals = false)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 要求把相等的删除掉
                if (equals)
                {
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        if (string.IsNullOrEmpty(dataRow[fieldName].ToString()))
                        {
                            dataRow.Delete();
                        }
                    }
                    else
                    {
                        if (dataRow[fieldName].ToString().Equals(fieldValue))
                        {
                            dataRow.Delete();
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        if (!string.IsNullOrEmpty(dataRow[fieldName].ToString()))
                        {
                            dataRow.Delete();
                        }
                    }
                    else
                    {
                        if (!dataRow[fieldName].ToString().Equals(fieldValue))
                        {
                            dataRow.Delete();
                        }
                    }
                }
            }
            dataTable.AcceptChanges();
            return dataTable;
        }
        #endregion

        #region public static string GetProperty(DataTable dataTable, string id, string targetField) 读取一个属性
        /// <summary>
        /// 读取一个属性
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">主键</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>目标值</returns>
        public static string GetProperty(DataTable dataTable, string id, string targetField)
        {
            return GetProperty(dataTable, FieldId, id, targetField);
        }

        public static string GetPropertyDyn(dynamic lstT, string id, string targetField)
        {
            return GetPropertyDyn(lstT, FieldId, id, targetField);
        }

        public static string GetPropertyDyn(dynamic lstT, string fieldName, string fieldValue, string targetField)
        {
            string returnValue = string.Empty;
            foreach (dynamic t in lstT)
            {
                if (ReflectHelper.GetProperty(t, fieldName).ToString().Equals(fieldValue))
                {
                    returnValue = ReflectHelper.GetProperty(t, targetField).ToString();
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static string GetProperty(DataTable dataTable, string fieldName, string fieldValue, string targetField) 读取一个属性
        /// <summary>
        /// 读取一个属性
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">值</param>
        /// <param name="targetField">目标字段</param>
        /// <returns>目标值</returns>
        public static string GetProperty(DataTable dataTable, string fieldName, string fieldValue, string targetField)
        {
            string returnValue = string.Empty;
            foreach (DataRow dataRow in dataTable.Rows.Cast<DataRow>().Where(dataRow => dataRow[fieldName].ToString().Equals(fieldValue)))
            {
                returnValue = dataRow[targetField].ToString();
                break;
            }
            return returnValue;
        }
        #endregion

        #region public static int SetProperty(DataTable dataTable, string id, string targetField, object targetValue) 设置一个属性
        /// <summary>
        /// 设置一个属性
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">主键</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">目标值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(DataTable dataTable, string id, string targetField, object targetValue)
        {
            return SetProperty(dataTable, FieldId, id, targetField, targetValue);
        }

        public static int SetPropertyDyn(dynamic lstT, string id, string targetField, object targetValue)
        {
            return SetPropertyDyn(lstT, FieldId, id, targetField, targetValue);
        }
        #endregion

        #region public static int SetProperty(DataTable dataTable, string fieldName, string fieldValue, string targetField, object targetValue) 设置一个属性
        /// <summary>
        /// 设置一个属性
        /// </summary>        
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">值</param>
        /// <param name="targetField">更新字段</param>
        /// <param name="targetValue">目标值</param>
        /// <returns>影响行数</returns>
        public static int SetProperty(DataTable dataTable, string fieldName, string fieldValue, string targetField, object targetValue)
        {
            int returnValue = 0;
            foreach (DataRow dataRow in dataTable.Rows.Cast<DataRow>().Where(dataRow => dataRow.RowState != DataRowState.Deleted && dataRow[fieldName].ToString().Equals(fieldValue)))
            {
                dataRow[targetField] = targetValue;
                returnValue++;
                //break;
            }
            return returnValue;
        }

        public static int SetPropertyDyn(dynamic lstT, string fieldName, string fieldValue, string targetField, object targetValue)
        {
            int returnValue = 0;
            for (int i = 0; i < lstT.Count; i++)
            {
                dynamic t = lstT[i];
                if (ReflectHelper.GetProperty(t, fieldName).ToString().Equals(fieldValue))
                {
                    ReflectHelper.SetProperty(t, targetField, targetValue);
                    lstT[i] = t;
                    returnValue++;
                    // break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static int Delete(DataTable dataTable, string id) 删除记录
        /// <summary>
        /// 删除一条记录
        /// </summary>        
        /// <param name="dataTable">数据表名</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public static int Delete(DataTable dataTable, string id)
        {
            return Delete(dataTable, FieldId, id);
        }
        #endregion

        #region public static int Delete(DataTable dataTable, string fieldName, string fieldValue) 删除记录
        /// <summary>
        /// 删除一条记录
        /// </summary>        
        /// <param name="dataTable">数据表名</param>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">值</param>
        /// <returns>影响行数</returns>
        public static int Delete(DataTable dataTable, string fieldName, string fieldValue)
        {
            int returnValue = 0;
            foreach (DataRow dataRow in dataTable.Rows.Cast<DataRow>().Where(dataRow => dataRow[fieldName].ToString().Equals(fieldValue)))
            {
                dataRow.Delete();
                returnValue++;
                break;
            }
            return returnValue;
        }
        #endregion

        #region public static DataRow GetDataRow(DataTable dataTable, string id) 从数据权限读取一行数据
        /// <summary>
        /// 从数据权限读取一行数据
        /// </summary>        
        /// <param name="dataTable">数据表</param>
        /// <param name="id">主键</param>
        /// <returns>数据行</returns>
        public static DataRow GetDataRow(DataTable dataTable, string id)
        {
            return GetDataRow(dataTable, FieldId, id);
        }
        #endregion

        #region public static DataRow GetDataRow(DataTable dataTable, string fieldName, string fieldValue) 从数据权限读取一行数据
        /// <summary>
        /// 从数据权限读取一行数据
        /// </summary>        
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">值</param>
        /// <returns>数据行</returns>
        public static DataRow GetDataRow(DataTable dataTable, string fieldName, string fieldValue)
        {
            return dataTable.Rows.Cast<DataRow>().FirstOrDefault(dataRow => dataRow.RowState != DataRowState.Deleted && dataRow[fieldName].ToString().Equals(fieldValue));

            //DataRow returnValue = null;
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    if (dataRow.RowState != DataRowState.Deleted && dataRow[fieldName].ToString().Equals(fieldValue))
            //    {
            //        returnValue = dataRow;
            //        break;
            //    }
            //}
            //return returnValue;
        }

        #endregion

        #region private static int SetClassValue(object sourceObject, string field, object targetObject) 设置对象的属性
        /// <summary>
        /// 设置对象的属性
        /// </summary>
        /// <param name="sourceObject">目标对象</param>
        /// <param name="field">属性名称</param>
        /// <param name="targetValue">目标值</param>
        /// <returns>影响的属性个数</returns>
        private static int SetClassValue(object sourceObject, string field, object targetValue)
        {
            int returnValue = 0;
            Type currentType = sourceObject.GetType();
            FieldInfo[] fieldInfo = currentType.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo currentFieldInfo;
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                if (field.Equals(fieldInfo[i].Name))
                {
                    currentFieldInfo = currentType.GetField(field);
                    currentFieldInfo.SetValue(sourceObject, targetValue);
                    // FieldInfo[i].SetValue(TargetObject, value);
                    returnValue++;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static object CopyObjectValue(object sourceObject, object targetObject) 复制类对象的对应的值
        /// <summary>
        /// 复制类对象的对应的值
        /// </summary>
        /// <param name="sourceObject">当前对象</param>
        /// <param name="targetObject">目标对象</param>
        /// <returns>对象</returns>
        public static object CopyObjectValue(object sourceObject, object targetObject)
        {
            int returnValue = 0;
            string name = string.Empty;
            Type type = sourceObject.GetType();
            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo currentFieldInfo;
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                name = fieldInfo[i].Name;
                currentFieldInfo = fieldInfo[i];
                returnValue = SetClassValue(targetObject, name, currentFieldInfo.GetValue(sourceObject));
            }
            return targetObject;
        }
        #endregion

        #region public static object CopyObjectProperties(object sourceObject, object targetObject)
        /// <summary>
        /// 复制属性
        /// </summary>
        /// <param name="sourceObject">类</param>
        /// <param name="targetObject">目标类</param>
        /// <returns>类</returns>
        public static object CopyObjectProperties(object sourceObject, object targetObject)
        {
            Type typeSource = sourceObject.GetType();
            Type typeTarget = targetObject.GetType();
            PropertyInfo[] PropertyInfoSource = typeSource.GetProperties();
            PropertyInfo[] PropertyInfoTarget = typeTarget.GetProperties();
            for (int i = 0; i < PropertyInfoTarget.Length; i++)
            {
                for (int j = 0; j < PropertyInfoSource.Length; j++)
                {
                    if (PropertyInfoTarget[i].Name.Equals(PropertyInfoSource[j].Name))
                    {
                        if (PropertyInfoTarget[i].CanWrite)
                        {
                            object pValue = PropertyInfoSource[j].GetValue(sourceObject, null);
                            PropertyInfoTarget[i].SetValue(targetObject, pValue, null);
                        }
                        break;
                    }
                }
            }
            return targetObject;
        }
        #endregion

        #region public static string GetSearchString(string searchValue) 获取查询字符串
        /// <summary>
        /// 获取查询字符串
        /// </summary>
        /// <param name="searchValue">查询字符</param>
        /// <returns>字符串</returns>
        public static string GetSearchString(string searchValue)
        {
            searchValue = searchValue.Trim();
            searchValue = SqlSafe(searchValue);
            if (searchValue.Length > 0)
            {
                searchValue = searchValue.Replace('[', '_');
                searchValue = searchValue.Replace(']', '_');
            }
            if (searchValue == "%")
            {
                searchValue = "[%]";
            }
            if ((searchValue.Length > 0) && (searchValue.IndexOf('%') < 0) && (searchValue.IndexOf('_') < 0))
            {
                searchValue = "%" + searchValue + "%";
            }
            return searchValue;
        }
        #endregion

        #region public static bool Exists(string[] ids, string targetString) 判断是否包含的方法
        /// <summary>
        /// 判断是否包含的方法
        /// </summary>
        /// <param name="ids">数组</param>
        /// <param name="targetString">目标值</param>
        /// <returns>包含</returns>
        public static bool Exists(string[] ids, string targetString)
        {
            bool returnValue = false;
            if (ids != null && !string.IsNullOrEmpty(targetString))
            {
                if (ids.Any(t => t.Equals(targetString)))
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static string[] Concat(string[] ids, string id) 合并数据
        /// <summary>
        /// 合并数组
        /// </summary>
        /// <param name="ids">数组</param>
        /// <param name="id">新值</param>
        /// <returns>数组</returns>
        public static string[] Concat(string[] ids, string id)
        {
            return Concat(ids, new string[] { id });
        }        

        /// <summary>
        /// 合并数组
        /// </summary>
        /// <param name="ids">数组</param>
        /// <returns>数组</returns>
        public static string[] Concat(params string[][] ids)
        {
            // 进行合并
            Hashtable hashValues = new Hashtable();
            if (ids != null)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != null)
                    {
                        for (int j = 0; j < ids[i].Length; j++)
                        {
                            if (ids[i][j] != null)
                            {
                                if (!hashValues.ContainsKey(ids[i][j]))
                                {
                                    hashValues.Add(ids[i][j], ids[i][j]);
                                }
                            }
                        }
                    }
                }
            }
            // 返回合并结果
            string[] returnValues = new string[hashValues.Count];
            IDictionaryEnumerator enumerator = hashValues.GetEnumerator();
            int key = 0;
            while (enumerator.MoveNext())
            {
                returnValues[key] = (string)(enumerator.Key.ToString());
                key++;
            }
            return returnValues;
        }
        #endregion

        #region  public static string[] Remove(string[] ids, string id) 从目标数组中去除某个值
        /// <summary>
        /// 从目标数组中去除某个值
        /// </summary>
        /// <param name="ids">数组</param>
        /// <param name="id">目标值</param>
        /// <returns>数组</returns>
        public static string[] Remove(string[] ids, string id)
        {
            // 进行合并
            Hashtable hashValues = new Hashtable();
            if (ids != null)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != null && (!ids[i].Equals(id)))
                    {
                        if (!hashValues.ContainsKey(ids[i]))
                        {
                            hashValues.Add(ids[i], ids[i]);
                        }
                    }
                }
            }
            // 返回合并结果
            string[] returnValues = new string[hashValues.Count];
            IDictionaryEnumerator enumerator = hashValues.GetEnumerator();
            int key = 0;
            while (enumerator.MoveNext())
            {
                returnValues[key] = (string)(enumerator.Key.ToString());
                key++;
            }
            return returnValues;
        }
        #endregion

        #region public static object GetOracleDateFormat(DateTime date) 将.NET日期时间类型转化为Oracle兼容的日期时间格式字符串
        /// <summary>
        /// 将.NET日期时间类型转化为Oracle兼容的日期时间格式字符串
        /// </summary>
        /// <param name="date">.NET日期时间类型对象</param>
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2014-01-22','yyyy-mm-dd')）</returns>
        public static object GetOracleDateFormat(DateTime date)
        {
            return DateTimeHelper.IsDate(date.ToString())
                ? "TO_DATE('" + date.ToString("yyyy-MM-dd") + "','yyyy-mm-dd')"
                : null;
        }

        /// <summary>
        /// 将.NET日期时间类型转化为Oracle兼容的日期时间格式字符串
        /// </summary>
        /// <param name="date">.NET日期时间类型对象</param>
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2014-01-22','yyyy-mm-dd')）</returns>
        public static object GetOracleDateFormat(DateTime? date)
        {
            return date != null && DateTimeHelper.IsDate(date.ToString())
                ? ("TO_DATE('" + ConvertToDateToString(date) + "','yyyy-mm-dd')").Clone()
                : null;
        }

        /// <summary>
        /// 将.NET日期时间类型转化为Oracle兼容的日期格式字符串
        /// </summary>
        /// <param name="date">.NET日期时间类型对象</param>
        /// <param name="format">Oracle日期时间类型格式化限定符</param>
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2014-01-22','yyyy-mm-dd hh24:mi:ss'）</returns>
        public static object GetOracleDateFormat(DateTime date, string format)
        {
            if (format == null || format.Trim() == "") format = "yyyy-mm-dd";
            return DateTimeHelper.IsDate(date.ToString())
                ? "TO_DATE('" + date.ToString("yyyy-MM-dd HH:mm:ss")  + "','" + format + "')"
                : null;
        }
        #endregion

        #region public static T GetModelByDataRow<T>(System.Data.DataRow dr) where T : new() 通过DataRow 填充实体
        /// <summary>  
        /// 通过DataRow 填充实体  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="dr">System.Data.DataRow</param>  
        /// <returns></returns>  
        public static T GetModelByDataRow<T>(System.Data.DataRow dr) where T : new()
        {
            T model = new T();
            foreach (PropertyInfo pInfo in model.GetType().GetProperties())
            {
                object val = GetValueByColumnName(dr, pInfo.Name);
                pInfo.SetValue(model, val, null);
            }
            return model;
        }

        /// <summary>
        /// 返回DataRow 中对应的列的值
        /// </summary>
        /// <param name="dr">System.Data.DataRow</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
 
        public static object GetValueByColumnName(System.Data.DataRow dr, string columnName)
        {
            if (dr.Table.Columns.IndexOf(columnName) >= 0)
            {
                if (dr[columnName] == DBNull.Value)
                    return null;
                return dr[columnName];
            }
            return null;
        }
        #endregion

        #region 调试信息

        /// <summary>
        /// 写入开始调试信息
        /// </summary>
        /// <param name="methodBase">提供有关方法和构造函数的信息</param>
        /// <returns>启动经过的毫秒数</returns>
        public static int StartDebug(MethodBase methodBase)
        {
            // 输出访问日志
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) + " :Begin: " + methodBase.ReflectedType.Name + "." + methodBase.Name);
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) + " :Begin: " + methodBase.ReflectedType.Name + "." + methodBase.Name);
            #endif

            return Environment.TickCount;
        }

        /// <summary>
        /// 写入开始调试信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="methodBase">提供有关方法和构造函数的信息</param>
        /// <returns>启动经过的毫秒数</returns>
        //[Conditional("DEBUG")]
        public static int StartDebug(UserInfo userInfo, MethodBase methodBase)
        {
            // 写入访问日志
            // userInfo.OperationId = MethodBase.Name;
            // userInfo.Description = MethodBase.ReflectedType.Name;
            // 输出访问日志
            #if (DEBUG)
                if (userInfo != null)
                {
                    Console.WriteLine("User: " + userInfo.RealName + " IP: " + userInfo.IPAddress);
                    Console.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) + " :Begin: " + methodBase.ReflectedType.Name + "." + methodBase.Name);
                    Trace.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) + " :Begin: " + methodBase.ReflectedType.Name + "." + methodBase.Name);
                }
            #endif

            return Environment.TickCount;
        }

        /// <summary>
        /// 写入结束调试信息
        /// </summary>
        /// <param name="methodBase">提供有关方法和构造函数的信息</param>
        /// <param name="milliStart">开始启动时的毫秒数</param>
        /// <param name="consoleColor">定义控制台前/背景色</param>
        /// <returns>执行所耗的毫秒数</returns>
        public static int EndDebug(MethodBase methodBase, int milliStart, ConsoleColor consoleColor)
        {
            int milliEnd = Environment.TickCount;
            
            #if (DEBUG)
            Console.Write(DateTime.Now.ToString("MM-dd HH:mm:ss") + " : " 
                    + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() 
                    + " : ");
                Console.ForegroundColor = consoleColor;
                Console.Write(methodBase.ReflectedType.Name + "." + methodBase.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);

                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) 
                    + " : " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() 
                    + " : " + methodBase.ReflectedType.Name + "." + methodBase.Name);
            #endif

            return milliEnd - milliStart;
        }

        /// <summary>
        /// 写入结束调试信息
        /// </summary>
        /// <param name="methodBase">提供有关方法和构造函数的信息</param>
        /// <param name="milliStart">开始启动时的毫秒数</param>
        /// <returns>执行所耗的毫秒数</returns>
        public static int EndDebug(MethodBase methodBase, int milliStart)
        {
            return EndDebug(methodBase, milliStart, ConsoleColor.White);
        }

        /// <summary>
        /// 写入调试信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="methodBase">提供有关方法和构造函数的信息</param>
        public static void WriteDebug(UserInfo userInfo, MethodBase methodBase)
        {
            #if (DEBUG)
                Console.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) + " " + userInfo.IPAddress + methodBase.ReflectedType.Name + "." + methodBase.Name);
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.DateTimeFormat) + " " + userInfo.IPAddress + methodBase.ReflectedType.Name + "." + methodBase.Name);
            #endif
        }
        #endregion

        #region public static string GetFriendlyFileSize(double fileSize) 有善的文件大小现实方式
        /// <summary>
        /// 有善的文件大小现实方式
        /// </summary>
        /// <param name="fileSize">文件大小</param>
        /// <returns>现实方式</returns>
        public static string GetFriendlyFileSize(double fileSize)
        {
            string returnValue = string.Empty;
            if (fileSize < 1024)
            {
                returnValue = fileSize.ToString("F1") + "Byte";
            }
            else
            {
                fileSize = fileSize / 1024;
                if (fileSize < 1024)
                {
                    returnValue = fileSize.ToString("F1") + "KB";
                }
                else
                {
                    fileSize = fileSize / 1024;
                    if (fileSize < 1024)
                    {
                        returnValue = fileSize.ToString("F1") + "M";
                    }
                    else
                    {
                        fileSize = fileSize / 1024;
                        returnValue = fileSize.ToString("F1") + "GB";
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region public static int GetLanguageResource(object targetObject) 从当前指定的语言包读取信息
        /// <summary>
        /// 从当前指定的语言包读取信息
        /// </summary>
        /// <returns>设置多语言的属性个数</returns>
        public static int GetLanguageResource(object targetObject)
        {
            int returnValue = 0;
            string name = string.Empty;
            Type type = targetObject.GetType();
            // Type type = typeof(TargetObject);
            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo currentFieldInfo;
            string messages = string.Empty;
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                name = fieldInfo[i].Name;
                currentFieldInfo = fieldInfo[i];
                messages = ResourceManagerWrapper.Instance.Get(name);
                if (messages.Length > 0)
                {
                    currentFieldInfo.SetValue(targetObject, messages);
                    returnValue++;
                }
            }
            return returnValue;
        }
        #endregion

        ///----------------------------
        ///Image、Byte[]、Bitmap相互转换

        #region Image、Byte[]、Bitmap相互转换
        /// <summary>
        /// 将图片Image转换成Byte[]
        /// </summary>
        /// <param name="Image">image对象</param>
        /// <param name="imageFormat">后缀名</param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image Image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
           if (Image == null) { return null; }
           byte[] data = null;
           using (MemoryStream ms= new MemoryStream())
            {
                using (Bitmap Bitmap = new Bitmap(Image))
                {
                    Bitmap.Save(ms, imageFormat);
                   ms.Position = 0;
                    data = new byte[ms.Length];
                   ms.Read(data, 0, Convert.ToInt32(ms.Length));
                   ms.Flush();
               }
           }
           return data;
       }
 
 
        /// <summary>
        /// byte[]转换成Image
        /// </summary>
        /// <param name="byteArrayIn">二进制图片流</param>
        /// <returns>Image</returns>
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                ms.Flush();
                return returnImage;
            }
        }
 
        //Image转换Bitmap
        //Bitmap img = new Bitmap(imgSelect.Image);
        //Bitmap bmp = (Bitmap)pictureBox1.Image;
 
        /// <summary>
        /// byte[] 转换 Bitmap
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static Bitmap BytesToBitmap(byte[] Bytes) 
        { 
            MemoryStream stream = null; 
            try 
            { 
                stream = new MemoryStream(Bytes); 
                return new Bitmap((Image)new Bitmap(stream)); 
            } 
            catch (ArgumentNullException ex) 
            { 
                throw ex; 
            } 
            catch (ArgumentException ex) 
            { 
                throw ex; 
            } 
            finally 
            { 
                stream.Close(); 
            } 
        }  
 
        /// <summary>
        /// Bitmap转byte[] 
        /// </summary>
        /// <param name="Bitmap"></param>
        /// <returns></returns> 
        public static byte[] BitmapToBytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
        ///----------------------------------
        #endregion
    }
}