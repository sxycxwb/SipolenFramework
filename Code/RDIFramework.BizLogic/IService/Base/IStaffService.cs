//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IStaffService
    /// 服务层接口
    /// 
    /// 修改纪录
    ///     2014-05-29 版本：2.8 XuWangBin 增加:GetDTNotOrganize接口。
    ///     2013-08-12 版本：2.5 XuWangBin 增加“GetDTByPage”按分页获取数据，满足Web分页的要求。
    ///		2012-03-02 版本：2.9 XuWangBin 创建文件。
    ///		
    /// 版本：2.9
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IStaffService
    {
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, PiStaffEntity entity, out string statusCode, out string statusMessage, string organizeId = "");

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);
        
        /// <summary>
        /// 获取员工分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有员工数</param>
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
        PiStaffEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByIds(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 获得员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByOrganize(UserInfo userInfo, string organizeId, bool containChildren);
        
        /// <summary>
        /// 获得未设置组织机构的员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>       
        [OperationContract]
        DataTable GetDTNotOrganize(UserInfo userInfo);

        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateStaff(UserInfo userInfo, PiStaffEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 设置员工关联的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetStaffUser(UserInfo userInfo, string staffId, string userId);


        /// <summary>
        /// 删除员工关联的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int DeleteUser(UserInfo userInfo, string staffId);

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
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string id, string organizeId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(UserInfo userInfo, string[] ids, string organizeId);

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">查询的参数</param>
        /// <param name="value">参数值</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        string GetId(UserInfo userInfo, string name, object value);
    }
}
