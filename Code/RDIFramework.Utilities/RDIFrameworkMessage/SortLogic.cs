//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System.Data;

namespace RDIFramework.Utilities
{
    /// <summary>
    ///	BaseSortLogic
    /// 通用排序逻辑基类（程序OK）
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.09 版本：   1.4 XuWangBin 更新函数名为*Id。
    ///		2010.12.10 版本：   1.3 XuWangBin 改进 序列产生码的长度问题。
    ///		2010.11.01 版本：   1.2 XuWangBin 改进 BUOperatorInfo 去掉这个变量，可以提高性能，提高速度，基类的又一次飞跃。
    ///		2010.03.01 版本：   1.0 XuWangBin 将主键从 BUBusinessLogic 类分离出来。
    ///	
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.12.10</date>
    /// </author> 
    /// </summary>
    public class SortLogic
    {
        //
        // 排序操作在内存中的运算方式定义
        //

        #region public static string GetNextId(DataTable dataTable, string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">当前表</param>
        /// <param name="id">当前主键</param>
        /// <returns>主键</returns>
        public static string GetNextId(DataTable dataTable, string id)
        {
            return GetNextId(dataTable.DefaultView, id, BusinessLogic.FieldId);
        }       

        public static string GetNextId(DataView dataView, string id)
        {
            return GetNextId(dataView, id, BusinessLogic.FieldId);
        }

        public static string GetNextId(DataTable dataTable, string id, string field)
        {
            return GetNextId(dataTable.DefaultView, id, field);
        }

        public static string GetNextId(DataView dataView, string id, string field)
        {
            string returnValue = string.Empty;
            bool find = false;
            foreach (DataRowView dataRow in dataView)
            {
                if (find)
                {
                    returnValue = dataRow[field].ToString();
                    break;
                }
                if (dataRow[field].ToString().Equals(id))
                {
                    find = true;
                }
            }
            return returnValue;
        }

        public static string GetNextIdDyn(dynamic lstT, string id)
        {
            return GetNextIdDyn(lstT, id, BusinessLogic.FieldId);
        }
        public static string GetNextIdDyn(dynamic lstT, string id, string field)
        {
            string returnValue = string.Empty;
            bool find = false;
            foreach (dynamic t in lstT)
            {
                if (find)
                {
                    returnValue = ReflectHelper.GetProperty(t, field).ToString();
                    break;
                }
                if (ReflectHelper.GetProperty(t, field).ToString().Equals(id))
                {
                    find = true;
                }
            }
            return returnValue;
        }      
       
        #endregion

        #region public static string GetPreviousId(DataTable dataTable, string id) 获取上一条记录主键
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">当前表</param>
        /// <param name="id">当前主键</param>
        /// <returns>主键</returns>
        public static string GetPreviousId(DataTable dataTable, string id)
        {
            return GetPreviousId(dataTable.DefaultView, id, BusinessLogic.FieldId);
        }        

        public static string GetPreviousId(DataView dataView, string id)
        {
            return GetPreviousId(dataView, id, BusinessLogic.FieldId);
        }
      
        public static string GetPreviousId(DataTable dataTable, string id, string field)
        {
            return GetPreviousId(dataTable.DefaultView, id, field);
        }        

        public static string GetPreviousId(DataView dataView, string id, string field)
        {
            string returnValue = string.Empty;
            foreach (DataRowView dataRow in dataView)
            {
                if (dataRow[field].ToString().Equals(id))
                {
                    break;
                }
                returnValue = dataRow[field].ToString();
            }
            return returnValue;
        }

        public static string GetPreviousIdDyn(dynamic lstT, string id)
        {
            return GetPreviousIdDyn(lstT, id, BusinessLogic.FieldId);
        }

        public static string GetPreviousIdDyn(dynamic lstT, string id, string field)
        {
            string returnValue = string.Empty;
            foreach (dynamic t in lstT)
            {
                if (ReflectHelper.GetProperty(t, field).ToString().Equals(id))
                {
                    break;
                }
                returnValue = ReflectHelper.GetProperty(t, field).ToString().ToString();
            }
            return returnValue;
        }
        #endregion

        #region public static int Swap(DataTable dataTable, string id, string targetId) 两条记录交换排序顺序
        /// <summary>
        /// 两条记录交换排序顺序
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">要移动的记录主键</param>
        /// <param name="targetId">目标记录主键</param>
        /// <returns>影响行数</returns>
        public static int Swap(DataTable dataTable, string id, string targetId)
        {
            int returnValue = 0;
            string sortCode = BusinessLogic.GetProperty(dataTable, id, BusinessLogic.FieldSortCode);
            string targetSortCode = BusinessLogic.GetProperty(dataTable, targetId, BusinessLogic.FieldSortCode);
            returnValue = BusinessLogic.SetProperty(dataTable, id, BusinessLogic.FieldSortCode, targetSortCode);           
            returnValue += BusinessLogic.SetProperty(dataTable, targetId, BusinessLogic.FieldSortCode, sortCode);
            return returnValue;
        }

        public static int SwapDyn(dynamic lstT, string id, string targetId)
        {
            int returnValue = 0;
            string sortCode = BusinessLogic.GetPropertyDyn(lstT, id, BusinessLogic.FieldSortCode);
            string targetSortCode = BusinessLogic.GetPropertyDyn(lstT, targetId, BusinessLogic.FieldSortCode);
            returnValue = BusinessLogic.SetPropertyDyn(lstT, id, BusinessLogic.FieldSortCode, targetSortCode);
            returnValue += BusinessLogic.SetPropertyDyn(lstT, targetId, BusinessLogic.FieldSortCode, sortCode);
            return returnValue;
        }
        #endregion        
    }
}