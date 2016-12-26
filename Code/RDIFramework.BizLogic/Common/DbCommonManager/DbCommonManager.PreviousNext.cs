//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;

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
        // 记录导航功能
        //

        public string PreviousId = string.Empty; // 上一个记录主键。
        public string NextId = string.Empty; // 下一个记录主键。

        #region public DataTable GetPreviousNextId(bool DeleteMark, string id) 获得主键列表
        /// <summary>
        /// 获得主键列表中的，上一条，小一条记录的主键
        /// </summary>
        /// <param name="DeleteMark">删除标志</param>
        /// <param name="id">主键</param>
        /// <param name="order"></param>
        /// <returns>数据表</returns>
        public DataTable GetPreviousNextId(bool DeleteMark, string id, string order)
        {
            string sqlQuery = " SELECT Id "
                            + " FROM " + this.CurrentTableName
                            + " WHERE (" + BusinessLogic.FieldCreateUserId + " = " + DBProvider.GetParameter(BusinessLogic.FieldCreateUserId)
                            + " AND " + BusinessLogic.FieldDeleteMark + " = " + (DeleteMark ? 1 : 0) + ")"
                            + " ORDER BY " + order;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BusinessLogic.FieldCreateUserId;
            values[0] = UserInfo.Id;
            DataTable dataTable = new DataTable(this.CurrentTableName);
            DBProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
            this.NextId = this.GetNextId(dataTable, id);
            this.PreviousId = this.GetPreviousId(dataTable, id);
            return dataTable;
        }
        #endregion

        #region public void GetPreviousNextId(DataTable dataTable, string id) 获得主键列表
        /// <summary>
        /// 获取下一条、下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">当前记录主键</param>
        public void GetPreviousNextId(DataTable dataTable, string id)
        {
            this.PreviousId = this.GetPreviousId(dataTable, id);
            this.NextId = this.GetNextId(dataTable, id);
        }
        #endregion

        #region private string GetPreviousId(string id) 获取上一条记录主键
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="id">当前记录主键</param>
        /// <returns>上一条记录主键</returns>
        private string GetPreviousId(string id)
        {
            string returnValue = string.Empty;
            string sqlQuery = " SELECT TOP 1 " + BusinessLogic.FieldId
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BusinessLogic.FieldCreateOn + " = (SELECT MAX(" + BusinessLogic.FieldCreateOn + ")"
                            + " FROM " + this.CurrentTableName
                            + " WHERE (" + BusinessLogic.FieldCreateOn + "< (SELECT " + BusinessLogic.FieldCreateOn
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BusinessLogic.FieldId + " = " + DBProvider.GetParameter(BusinessLogic.FieldId) + "))";
            sqlQuery += " AND (" + BusinessLogic.FieldCreateUserId + " = " + DBProvider.GetParameter(BusinessLogic.FieldCreateUserId) + " ) AND ( " + BusinessLogic.FieldDeleteMark + " = 0 )) ";
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = BusinessLogic.FieldId;
            values[0] = id;
            names[1] = BusinessLogic.FieldCreateUserId;
            values[1] = UserInfo.Id;
            object returnObject = DBProvider.ExecuteScalar(sqlQuery, DBProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = returnObject.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public string GetPreviousId(DataTable dataTable, string id) 获取下一条备忘录ID
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">当前记录主键</param>
        /// <returns>上一条记录主键</returns>
        public string GetPreviousId(DataTable dataTable, string id)
        {
            string returnValue = string.Empty;
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                if (dataRowView[BusinessLogic.FieldId].ToString().Equals(id))
                {
                    break;
                }
                returnValue = dataRowView[BusinessLogic.FieldId].ToString();
            }

            return returnValue;
        }
        #endregion

        #region private string GetNextId(string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="id">当前记录主键</param>
        /// <returns>下一条记录主键</returns>
        private string GetNextId(string id)
        {
            string returnValue = string.Empty;
            string sqlQuery = " SELECT TOP 1 " + BusinessLogic.FieldId
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BusinessLogic.FieldCreateOn + " = (SELECT MIN(" + BusinessLogic.FieldCreateOn + ")"
                            + " FROM " + this.CurrentTableName
                            + " WHERE (" + BusinessLogic.FieldCreateOn + "> (SELECT " + BusinessLogic.FieldCreateOn
                            + " FROM " + this.CurrentTableName
                            + " WHERE " + BusinessLogic.FieldId + " = " + DBProvider.GetParameter(BusinessLogic.FieldId) + "))";
            sqlQuery += " AND (" + BusinessLogic.FieldCreateUserId + " = " + DBProvider.GetParameter(BusinessLogic.FieldCreateUserId) + ") AND ( " + BusinessLogic.FieldDeleteMark + " = 0 )) ";
            string[] names = new string[2];
            Object[] values = new Object[2];
            names[0] = BusinessLogic.FieldId;
            values[0] = id;
            names[1] = BusinessLogic.FieldCreateUserId;
            values[1] = UserInfo.Id;
            object returnObject = DBProvider.ExecuteScalar(sqlQuery, DBProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                returnValue = returnObject.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public string GetNextId(DataTable dataTable, string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">当前记录主键</param>
        /// <returns>下一条记录主键</returns>
        public string GetNextId(DataTable dataTable, string id)
        {
            string returnValue = string.Empty;
            bool finded = false;
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                if (finded)
                {
                    returnValue = dataRowView[BusinessLogic.FieldId].ToString();
                    break;
                }
                if (dataRowView[BusinessLogic.FieldId].ToString().Equals(id))
                {
                    finded = true;
                }
            }
            return returnValue;
        }
        #endregion
    }
}