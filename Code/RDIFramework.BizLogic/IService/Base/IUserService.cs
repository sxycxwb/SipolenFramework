/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:01
 ******************************************************************************/

using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IUserService
    /// 用户管理服务层接口
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：2.9 XuWangBin 创建文件。
    ///		2015-12-09 版本：3.0 XuWangBin 新增GetCompanyUser、GetDepartmentUser服务接口
    ///     2016-01-17 版本：3.0 XuWangBin 增加新的服务接口：
    ///                      1、GetDepartmentUser(UserInfo userInfo, string departmentId, bool containChildren);
    ///                      2、GetListByDepartment(UserInfo userInfo, string departmentId, bool containChildren);
    ///                      3、GetEntityByUserName(UserInfo userInfo, string userName);
    ///                      4、GetListByRole(UserInfo userInfo, string[] roleIds);
    /// 版本：3.0
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public partial interface IUserService
    {
        /// <summary>
        /// <c>用户名</c>是否重复
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fieldNames">字段列表</param>
        /// <param name="fieldValues">字段值列表</param>
        /// <returns>已存在</returns>
        [OperationContract]
        bool Exists(UserInfo userInfo, string[] fieldNames, object[] fieldValues);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddUser(UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiUserEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 根据用户名获取用户实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名称</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        PiUserEntity GetEntityByUserName(UserInfo userInfo, string userName);

        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 取得分页用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByPage(UserInfo userInfo, string searchValue, string departmentId, string roleId,out int recordCount, int pageIndex = 0, int pageSize = 50, string order = null);

        /*
        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有用户数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "");
        */
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<PiUserEntity> GetList(UserInfo userInfo);

        /// <summary>
        /// 按主键获取用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByIds(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 按主键获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<PiUserEntity> GetListByIds(UserInfo userInfo, string[] ids);
      
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="auditStates">用户状态</param>
        /// <param name="roleIds">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(UserInfo userInfo, string userName, string auditStates, string[] roleIds);

        /// <summary>
        /// 设置用户状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="auditStatus">审核状态</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetUserAuditStates(UserInfo userInfo, string[] ids, AuditStatus auditStatus);

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
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
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);
        
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateUser(UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 得到当前用户所在公司的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetCompanyUser(UserInfo userInfo);

        /// <summary>
        /// 得到当前用户所在部门的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>数据表</returns>
        [OperationContract(Name = "GetAllDepartmentUser")]        
        DataTable GetDepartmentUser(UserInfo userInfo);

        /// <summary>
        /// 得到指定部门包含的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">是否包含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDepartmentUser(UserInfo userInfo, string departmentId, bool containChildren);

        /// <summary>
        /// 得到指定部门包含的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">是否包含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<PiUserEntity> GetListByDepartment(UserInfo userInfo, string departmentId, bool containChildren);
    }
}
