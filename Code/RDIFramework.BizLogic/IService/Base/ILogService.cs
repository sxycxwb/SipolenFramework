//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// ILogService
    /// 服务层接口
    /// 
    /// 修改纪录
    ///
    ///     2013-08-13 版本：2.5 XuWangBin 增加“GetDTByPage”按分页获取数据，满足Web分页的要求。
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
    public interface ILogService
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="processId">服务</param>
        /// <param name="processName">服务名称</param>
        /// <param name="methodId">操作</param>
        /// <param name="methodName">操作名称</param>
        [OperationContract(IsOneWay = true)]
        void WriteLog(UserInfo userInfo, string processId, string processName, string methodId, string methodName);

        /// <summary>
        /// 离开时的日志记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="logId">日志主键</param>
        [OperationContract(IsOneWay = true)]
        void WriteExit(UserInfo userInfo, string logId);

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetLogGeneral(UserInfo userInfo);

        /// <summary>
        /// 按日期获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleId">模块主键</param> 
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByDate(UserInfo userInfo, string beginDate, string endDate, string userId, string moduleId);

        /// <summary>
        /// 按模块获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByModule(UserInfo userInfo, string moduleId, string beginDate, string endDate);

        /// <summary>
        /// 按员工获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByUser(UserInfo userInfo, string userId, string beginDate, string endDate);

        /// <summary>
        /// 获取系统操作日志分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "");

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);

        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        void Truncate(UserInfo userInfo);

        /// <summary>
        /// 按日期获取日志（业务）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTApplicationByDate(UserInfo userInfo, string beginDate, string endDate);

        /// <summary>
        /// 批量删除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteApplication(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 清除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        void TruncateApplication(UserInfo userInfo);  
     }
}
