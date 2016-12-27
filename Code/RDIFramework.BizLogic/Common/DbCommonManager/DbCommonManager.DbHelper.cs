//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

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
    ///		2012.02.04 版本：1.0 XuWangBin 进行提炼，把代码进行分组。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonManager
    {
        /// 直接执行一些SQL语句的方法

        #region public virtual int ExecuteNonQuery(string commandText)
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>影响行数</returns>
        public virtual int ExecuteNonQuery(string commandText)
        {
            return DBProvider.ExecuteNonQuery(commandText);
        }
        #endregion

        #region public virtual int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters) 执行查询语句
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        public virtual int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters)
        {
            return DBProvider.ExecuteNonQuery(commandText, dbParameters);
        }
        #endregion

        #region public virtual object ExecuteScalar(string commandText) 执行查询语句
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>object</returns>
        public virtual object ExecuteScalar(string commandText)
        {
            return DBProvider.ExecuteScalar(commandText);
        }
        #endregion

        #region public virtual object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters) 执行查询语句
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        public virtual object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters)
        {
            return DBProvider.ExecuteScalar(commandText, dbParameters);
        }
        #endregion

        #region public virtual DataTable Fill(string commandText) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        public virtual DataTable Fill(string commandText)
        {
            return DBProvider.Fill(commandText);
        }
        #endregion

        #region public virtual DataTable Fill(string commandText, IDbDataParameter[] dbParameters) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        public virtual DataTable Fill(string commandText, IDbDataParameter[] dbParameters)
        {
            return DBProvider.Fill(commandText, dbParameters);
        }
        #endregion
    }
}