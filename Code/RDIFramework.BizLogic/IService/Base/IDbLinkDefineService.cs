//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IDbLinkDefineService
    /// 服务层接口
    /// 
    /// 修改纪录
    /// 
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
    public interface IDbLinkDefineService
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, CiDbLinkDefineEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<CiDbLinkDefineEntity> GetList(UserInfo userInfo);

        /// <summary>
        /// 通过连接名称得到数据库连接定义
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="linkName">数据库连接定义名称</param>
        /// <returns>数据库连接定义实体</returns>
        [OperationContract]
        CiDbLinkDefineEntity GetEntityByLinkName(UserInfo userInfo, string linkName);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiDbLinkDefineEntity GetEntity(UserInfo userInfo, string id);
        
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, CiDbLinkDefineEntity entity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 依主键取得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByIds(UserInfo userInfo, string[] ids);
        
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
        /// 删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
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
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);
     }
}
