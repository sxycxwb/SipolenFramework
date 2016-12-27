/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:34:58
 ******************************************************************************/
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IFolderService
    /// 文件夹服务层接口
    /// 
    /// 修改纪录
    /// 
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
    public interface IFolderService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiFolderEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>数据表</returns>
        [OperationContract(Name = "GetDTByValue")]
        DataTable GetDT(UserInfo userInfo, string name, string value);

        /// <summary>
        /// 按目录获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParent(UserInfo userInfo, string id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo,CiFolderEntity folderEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父主键</param>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns></returns>
        [OperationContract]
        string AddByFolderName(UserInfo userInfo, string parentId, string folderName, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新文件夹
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderEntity">文件夹</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, CiFolderEntity folderEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="newName">新名称</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Rename(UserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="searchValue">查询值</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(UserInfo userInfo, string searchValue);

        /// <summary>
        /// 删除
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
        /// 移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="parentId">目标主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string folderId, string parentId);

        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderIds">文件夹主键数组</param>
        /// <param name="parentId">目标主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(UserInfo userInfo, string[] folderIds, string parentId);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);
     }
}
