//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;
using System.Collections.Generic;

namespace CRM
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IIncomingCallService
    /// 来电处理服务层接口
    /// 
    /// 修改记录
    /// 
    ///	2012-09-03 版本：1.0 Edward 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///	<name>Edward</name>
    ///	<date>2012-09-03</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IIncomingCallService
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, IncomingCallEntity entity);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(UserInfo userInfo);
      
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        IncomingCallEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, IncomingCallEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(UserInfo userInfo, string[] ids);   

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量逻辑删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);
    }
}