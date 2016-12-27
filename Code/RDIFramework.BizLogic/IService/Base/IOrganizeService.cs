/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-3-30 13:02:58
 ******************************************************************************/

using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IOrganizeService
    /// 组织机构服务层接口
    /// 
    /// 修改纪录
    /// 
    ///		2012-3-30 版本：2.9 XuWangBin 创建文件。
    ///		
    /// 版本：2.9
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-3-30</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IOrganizeService
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码信息</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, PiOrganizeEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, PiOrganizeEntity entity,out string statusMessage);

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
        /// <returns>List</returns>
        [OperationContract]
        List<PiOrganizeEntity> GetList(UserInfo userInfo);

        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParent(UserInfo userInfo, string parentId);

        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点</param>
        /// <returns>List</returns>
        [OperationContract]
        List<PiOrganizeEntity> GetListByParent(UserInfo userInfo, string parentId);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiOrganizeEntity GetEntity(UserInfo userInfo, string id);       
        
        /// <summary>
        /// 按主键数组获取数据列表
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
        /// 批量保存数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);
                
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

        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string organizeId, string parentId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">主键数组</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(UserInfo userInfo, string[] organizeIds, string parentId);

        /// <summary>
        /// 根据组织机构主键获取其指定分类下的子节点列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetChildrensById(UserInfo userInfo, string organizeId);
     }
}
