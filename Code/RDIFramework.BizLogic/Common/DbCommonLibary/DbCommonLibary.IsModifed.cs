//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonLibary
    /// 通用基类
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.05 版本：1.0	EricHu 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.05</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonLibary
    {
        //
        // 判断数据是否已被更改
        //

        #region public static bool IsModifed(IDbProvider dbProvider, string tableName, Object id, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">主键</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        public static bool IsModifed(IDbProvider dbProvider, string tableName, Object id, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            return IsModifed(dbProvider, tableName, BusinessLogic.FieldId, id, oldModifiedUserId, oldModifiedOn);
        }
        #endregion

        #region public static bool IsModifed(IDbProvider dbProvider, string tableName, string fieldName, Object fieldValue, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">值</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        public static bool IsModifed(IDbProvider dbProvider, string tableName, string fieldName, Object fieldValue, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT " + BusinessLogic.FieldId
                            + "," + BusinessLogic.FieldCreateUserId
                            + "," + BusinessLogic.FieldCreateOn
                            + "," + BusinessLogic.FieldModifiedUserId
                            + "," + BusinessLogic.FieldModifiedOn
                            + " FROM " + tableName
                            + " WHERE " + fieldName + " = " + dbProvider.GetParameter(fieldName);
            DataTable dataTable = dbProvider.Fill(sqlQuery, new IDbDataParameter[] { dbProvider.MakeParameter(fieldName, fieldValue)});
            returnValue = IsModifed(dataTable, oldModifiedUserId, oldModifiedOn);
            return returnValue;
        }
        #endregion

        #region private static bool IsModifed(DataTable dataTable, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        private static bool IsModifed(DataTable dataTable, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            bool returnValue = false;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                returnValue = IsModifed(dataRow, oldModifiedUserId, oldModifiedOn);
            }
            return returnValue;
        }
        #endregion

        #region public static bool IsModifed(DataRow dataRow, string oldModifiedUserId, DateTime? oldModifiedOn) 数据是否已经被别人修改了
        /// <summary>
        /// 数据是否已经被别人修改了
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="oldModifiedUserId">最后修改者</param>
        /// <param name="oldModifiedOn">最后修改时间</param>
        /// <returns>已被修改</returns>
        public static bool IsModifed(DataRow dataRow, string oldModifiedUserId, DateTime? oldModifiedOn)
        {
            bool returnValue = false;
            if ((dataRow[BusinessLogic.FieldModifiedUserId] == DBNull.Value) || ((dataRow[BusinessLogic.FieldModifiedOn] == DBNull.Value)))
            {
                returnValue = false;
                return returnValue;
            }
            DateTime newModifiedOn = DateTime.Parse(dataRow[BusinessLogic.FieldModifiedOn].ToString());
            //不允许不同的人同时进行编辑
            if (!dataRow[BusinessLogic.FieldModifiedUserId].ToString().Equals(oldModifiedUserId) && oldModifiedOn == newModifiedOn)
            {
                returnValue = true;
                return returnValue;
            }
            return returnValue;
        }
        #endregion
    }
}