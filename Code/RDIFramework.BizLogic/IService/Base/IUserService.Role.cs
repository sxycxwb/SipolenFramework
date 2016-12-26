using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial interface IUserService
    {
        /// <summary>
        /// 按角色获取用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByRole(UserInfo userInfo, string roleId);

        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色列表</param>
        /// <returns>用户列表</returns>
        [OperationContract]
        List<PiUserEntity> GetListByRole(UserInfo userInfo, string[] roleIds);

        /// <summary>
        /// 设置用户的默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int SetDefaultRole(UserInfo userInfo, string userId, string roleId);

        /// <summary>
        /// 批量设置用户的默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int BatchSetDefaultRole(UserInfo userInfo, string[] userIds, string roleId);

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetRoleDT(UserInfo userInfo);

        /// <summary>
        /// 用户是否在某个角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleCode">角色编号</param>
        /// <returns>存在</returns>
        [OperationContract]
        bool UserInRole(UserInfo userInfo, string userId, string roleCode);

        /// <summary>
        /// 获取员工角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserRoleIds(UserInfo userInfo, string userId);

        /// <summary>
        /// 批量加入到员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="addToRoleIds">加入角色主键集</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int AddUserToRole(UserInfo userInfo, string userId, string[] addToRoleIds);

        /// <summary>
        /// 批量移出角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="removeRoleIds">移出角色主键集</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RemoveUserFromRole(UserInfo userInfo, string userId, string[] removeRoleIds);

        /// <summary>
        /// 清除用户归属的角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ClearUserRole(UserInfo userInfo, string userId);
    }
}
