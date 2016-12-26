/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:34:58
 ******************************************************************************/

using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IExceptionService
    /// 服务层接口
    /// 
    /// 修改纪录
    /// 
    ///     2013-08-13 版本：2.5 EricHu 增加“GetDTByPage”按分页获取数据，满足Web分页的要求。
    ///		2012-03-02 版本：2.9 EricHu 创建文件。
    ///		
    /// 版本：2.9
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IExceptionService
    {
        /// <summary>
        /// 添加异常数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, CiExceptionEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);
        
        /// <summary>
        /// 获取系统异常分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "");

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiExceptionEntity GetEntity(UserInfo userInfo, string id);       
        
        
        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="names">字段</param>
        /// <param name="values">值</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values);

        /// <summary>
        /// 删除异常
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主鍵</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 全部清除异常
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        void Truncate(UserInfo userInfo);
     }
}
