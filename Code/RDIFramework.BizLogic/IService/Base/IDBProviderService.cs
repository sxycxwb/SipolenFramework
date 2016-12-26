/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:28:39
 ******************************************************************************/
//-----------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IDbProviderService
    /// 数据库访问通用类标准接口。
    /// 
    /// 修改纪录
    /// 
    ///		2010.08.26 版本：2.0 EricHu 将主键进行精简整理。
    ///		2010.08.25 版本：1.3 EricHu 将标准数据库接口方法进行分离、分离为标准接口方法与扩展接口方法部分。
    ///		2010.06.03 版本：1.2 EricHu 增加 DbParameter[] dbParameters 方法。
    ///		2010.05.07 版本：1.1 EricHu 增加GetWhereString定义。
    ///		2010.03.20 版本：2.9 EricHu 创建标准接口，这次应该算是一次飞跃。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.08.26</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IDBProviderService
    {
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandText">查询</param>
        /// <returns>影响行数</returns>
        [OperationContract(Name = "ExecuteNonQuery")]
        int ExecuteNonQuery(UserInfo userInfo, string commandText);
        
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandText">查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        [OperationContract(Name = "ExecuteNonQuery2")]
        int ExecuteNonQuery(UserInfo userInfo, string commandText, DbParameter[] dbParameters);

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandText">sql查询</param>
        /// <returns>Object</returns>
        [OperationContract(Name = "ExecuteScalar")]
        object ExecuteScalar(UserInfo userInfo, string commandText);
        
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        [OperationContract(Name = "ExecuteScalar2")]
        object ExecuteScalar(UserInfo userInfo, string commandText, DbParameter[] dbParameters);
        
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        [OperationContract(Name = "Fill")]
        DataTable Fill(UserInfo userInfo, string commandText);

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        [OperationContract(Name = "Fill2")]
        DataTable Fill(UserInfo userInfo, string commandText, DbParameter[] dbParameters);
    }
}