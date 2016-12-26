//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RDIFramework.BizLogic
{
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
        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="whereConditional">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDTByPage(out int recordCount, int pageIndex, int pageSize, string whereConditional, string order)
        {
            recordCount = DbCommonLibary.GetCount(DBProvider, this.CurrentTableName, whereConditional);
            return DbCommonLibary.GetDTByPage(DBProvider, this.CurrentTableName, this.SelectField, pageIndex, pageSize, whereConditional, order);
        }

        /// <summary>
        /// 分页读取数据
        /// </summary>
        /// <param name="recordCount">页面个数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="tableName">从什么表</param>
        /// <param name="whereConditional">条件</param>
        /// <param name="selectField">选择哪些字段</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDTByPage(out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null, string tableName = null, string whereConditional = null, string selectField = null)
        {
            if (tableName.IndexOf("SELECT", System.StringComparison.OrdinalIgnoreCase) >= 0 || DBProvider.CurrentDbType == RDIFramework.Utilities.CurrentDbType.MySql)
            {
                // 统计总条数
                string commandText = string.Empty;
                if (string.IsNullOrEmpty(tableName))
                {
                    tableName = this.CurrentTableName;
                }
                commandText = tableName;
                if (tableName.IndexOf("SELECT",System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    commandText = "(" + tableName + ") AS T ";
                }
                string whereStatement = string.Empty;
                if (!string.IsNullOrEmpty(whereConditional))
                {
                    whereStatement = string.Format(" WHERE {0} ", whereConditional);
                }

                commandText = string.Format("SELECT COUNT(1) AS recordCount FROM {0} {1}", commandText, whereStatement);
                object returnObject = DBProvider.ExecuteScalar(commandText);
                recordCount = returnObject != null ? int.Parse(returnObject.ToString()) : 0;
                if (DBProvider.CurrentDbType == RDIFramework.Utilities.CurrentDbType.MySql)
                {
                    return DbCommonLibary.GetDTByPage(DBProvider, tableName, recordCount, pageIndex, pageSize, whereConditional, sortExpression, sortDire);
                }
                return DbCommonLibary.GetDTByPage(DBProvider, recordCount, pageIndex, pageSize, tableName, sortExpression, sortDire);
            }
            // 这个是调用存储过程的方法
            return DbCommonLibary.GetDTByPage(DBProvider, out recordCount, pageIndex, pageSize, sortExpression, sortDire, tableName, whereConditional, selectField);
        }
    }
}