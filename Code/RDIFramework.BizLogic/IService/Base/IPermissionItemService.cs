/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-18 9:24:12
 ******************************************************************************/


using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IPermissionItemService
    /// 操作权限项定义服务层接口
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
    public interface IPermissionItemService
    {
        /// <summary>
        /// 取得操作权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 获取权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<PiPermissionItemEntity> GetList(UserInfo userInfo);

        /// <summary>
        /// 依父节点取得操作权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父亲节点主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParent(UserInfo userInfo, string parentId);

        /// <summary> 
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<PiPermissionItemEntity> GetListByParent(UserInfo userInfo, string parentId);

        /// <summary>
        /// 新增操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemEntity">权限实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>数据表</returns>
        [OperationContract]
        string Add(UserInfo userInfo,PiPermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按明细添加一个操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddByDetail(UserInfo userInfo, string code, string fullName, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取一个操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiPermissionItemEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 依编号取得操作权限项实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiPermissionItemEntity GetEntityByCode(UserInfo userInfo, string code);

        /// <summary>
        /// 依主键数组取得操作权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByIds(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 更新操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemEntity">权限实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, PiPermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 移动操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string id, string parentId);

        /// <summary>
        /// 批量移动操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键组</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(UserInfo userInfo, string[] ids, string parentId);

        /// <summary>
        /// 删除操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);

        /// <summary>
        /// 批量删除操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量标示操作权限项删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量保存操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">权限数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 重新产生操作权限项排序码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSetSortCode(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 按模块主键获取操作权限项主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetIdsByModule(UserInfo userInfo, string moduleId);
     }
}
