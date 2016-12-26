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
    /// IModuleService
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
    public interface IModuleService
    {
        /// <summary>
        /// 取得模块(菜单)列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 通过条件得到模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="condition">条件表达式</param>
        /// <returns>数据库</returns>
        [OperationContract]
        DataTable GetDTByCondition(UserInfo userInfo, string condition);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>列表</returns>
        [OperationContract]
        List<PiModuleEntity> GetList(UserInfo userInfo);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByIds(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiModuleEntity GetEntity(UserInfo userInfo, string id);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>名称</returns>
        [OperationContract]
        string GetFullNameByCode(UserInfo userInfo, string code);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, PiModuleEntity moduleEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, PiModuleEntity moduleEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParent(UserInfo userInfo, string parentId);

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);

        /// <summary>
        /// 批量删除模块
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

        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string moduleId, string parentId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleIds">模块主键数组</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(UserInfo userInfo, string[] moduleIds, string parentId);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 保存排序顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetSortCode(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 模块权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPermissionDT(UserInfo userInfo, string moduleId);

        /// <summary>
        /// 菜单主健数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetIdsByPermission(UserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="permissionItemIds">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchAddPermissions(UserInfo userInfo, string moduleId, string[] permissionItemIds);

        /// <summary>
        /// 模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="moduleIds">模块主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchAddModules(UserInfo userInfo, string permissionItemId, string[] moduleIds);

        /// <summary>
        /// 撤销模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="permissionItemIds">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeletePermissions(UserInfo userInfo, string moduleId, string[] permissionItemIds);

        /// <summary>
        /// 撤销模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="modulesIds">模块主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteModules(UserInfo userInfo, string permissionItemId, string[] modulesIds);
     }
}
