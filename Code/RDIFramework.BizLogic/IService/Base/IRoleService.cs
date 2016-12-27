//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IPiRoleService
    /// 服务层接口
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：2.9 XuWangBin 创建文件。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IRoleService
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        string Add(UserInfo userInfo, PiRoleEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 取得角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<PiRoleEntity> GetList(UserInfo userInfo);

        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有角色数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "");

        /// <summary>
        /// 按组织机构获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="showUser">显示用户</param>
        /// <returns>角色列表</returns>
        [OperationContract]
        DataTable GetDTByOrganize(UserInfo userInfo, string organizeId, bool showUser = true);

        /// <summary>
        /// 获取业务角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>业务角色列表</returns>
        [OperationContract]
        DataTable GetApplicationRole(UserInfo userInfo);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiRoleEntity GetEntity(UserInfo userInfo, string id);
        
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, PiRoleEntity entity, out string statusCode, out string statusMessage);
        
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
        DataTable GetDTByValues(UserInfo userInfo, string[] names, string[] values);
                
        /// <summary>
        /// 批量保存数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entites">实体列表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, List<PiRoleEntity> entites);
                
        /// <summary>
        /// 物理删除角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);
        
        /// <summary>
        /// 物理批量删除角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 逻辑批量删除角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 移除角色用户关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int EliminateRoleUser(UserInfo userInfo, string roleId);

        /// <summary>
        /// 获得角色中的用户主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>用户主键</returns>
        [OperationContract]
        string[] GetRoleUserIds(UserInfo userInfo, string roleId);

        /// <summary>
        /// 用户添加到角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="addUserIds">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int AddUserToRole(UserInfo userInfo, string roleId, string[] addUserIds);

        /// <summary>
        /// 将用户从角色中移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="userIds">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int RemoveUserFromRole(UserInfo userInfo, string roleId, string[] userIds);

        /// <summary>
        /// 清除角色用户关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ClearRoleUser(UserInfo userInfo, string roleId);

        /// <summary>
        /// 设置角色中的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色</param>
        /// <param name="userIds">用户主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetUsersToRole(UserInfo userInfo, string roleId, string[] userIds);

        /// <summary>
        /// 重置角色排序码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ResetSortCode(UserInfo userInfo, string organizeId);

        /// <summary>
        /// 移动角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="targetOrganizeId">目标组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string id, string targetOrganizeId);
    }
}
