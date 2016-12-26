/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-25 9:58:19
 ******************************************************************************/
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IPiPlatFormAddInService
    /// 服务层接口
    /// 
    /// 修改纪录
    /// 
    ///		2012-05-25 版本：2.9 EricHu 创建文件。
    ///		
    /// 版本：2.9
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-05-25</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IPlatFormAddInService
    {
        /// <summary>
        /// 新增平台插件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, PiPlatFormAddInEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 取得平台插件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 取得平台插件实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiPlatFormAddInEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 更新平台插件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, PiPlatFormAddInEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 依主键取得平台插件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByIds(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 按条件获取平台插件数据列表
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
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);

         /// <summary>
        /// 批量设置删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 设置可用性
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="enabled">是否可用(1:可用、0：不可用)</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int SetEnabled(UserInfo userInfo, string id, int enabled);
    }
}
