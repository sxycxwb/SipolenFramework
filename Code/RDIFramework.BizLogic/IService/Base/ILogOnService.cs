/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-19 16:40:11
 ******************************************************************************/

using System;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// ILogOnService
    /// 登入系统服务
    /// 
    ///修改纪录
    ///     2016-01-30 版本：3.0 新增UserDimission 用户离职接口
    ///     2016-01-16 版本：3.0 增加LockUser、UnLockUser的接口
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.04.19</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface ILogOnService
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
         [OperationContract]
        PiUserLogOnEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>影响行数</returns>
         [OperationContract]
        int Update(UserInfo userInfo, PiUserLogOnEntity entity);

        /// <summary>
        /// 按唯一识别码登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        UserInfo LogOnByOpenId(UserInfo userInfo, string openId, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按用户名登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        UserInfo LogOnByUserName(UserInfo userInfo, string userName, out string statusCode, out string statusMessage);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="openId">单点登录标识</param>
        /// <param name="createOpenId">重新创建单点登录标识</param>
        /// <param name="returnStatusCode">返回状态码</param>
        /// <param name="returnStatusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        UserInfo UserLogOn(UserInfo userInfo, string userName, string password, string openId, bool createOpenId,out string returnStatusCode, out string returnStatusMessage);

        /// <summary>
        /// 获得登录用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDT(UserInfo userInfo);

        /// <summary>
        /// 获得内部员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetStaffUserDT(UserInfo userInfo);

        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        UserInfo AccountActivation(UserInfo userInfo, string openId, out string statusCode, out string statusMessage);
       
        /// <summary>
        /// 用户在线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        [OperationContract(IsOneWay = true)]
        void OnLine(UserInfo userInfo, int onLineState);

        /// <summary>
        /// 用户离线
        /// </summary>
        /// <param name="userInfo">用户</param>
        [OperationContract(IsOneWay = true)]
        void OnExit(UserInfo userInfo);

        /// <summary>
        /// 检查在线状态(服务器专用)
        /// </summary>
        /// <returns>离线人数</returns>
        [OperationContract]
        int ServerCheckOnLine();

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">被设置的用户主键</param>
        /// <param name="password">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetPassword(UserInfo userInfo, string[] userIds, string password, out string statusCode, out string statusMessage);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ChangePassword(UserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage);

        /// <summary>
        /// 锁定指定用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">登录名（用户名）</param>
        /// <returns>大于0锁定成功</returns>
        [OperationContract]
        int LockUser(UserInfo userInfo, string userName);

        /// <summary>
        /// 解锁指定用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">登录名（用户名）</param>
        /// <returns>大于解锁成功</returns>
        [OperationContract]
        int UnLockUser(UserInfo userInfo, string userName);

        /// <summary>
        /// 用户离职
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">离职人员用户名</param>
        /// <param name="dimissionCause">离职原因</param>
        /// <param name="dimissionDate">离职日期</param>
        /// <param name="dimissionWhither">离职去向</param>
        /// <returns>大于0操作成功</returns>
        [OperationContract]
        int UserDimission(UserInfo userInfo, string userName, string dimissionCause, DateTime? dimissionDate, string dimissionWhither = null);
    }
}
