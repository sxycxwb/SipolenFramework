/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:34:58
 ******************************************************************************/
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IFileService
    /// 文件服务层接口
    /// 
    /// 修改纪录
    ///     2016-01-12 版本：3.0 EricHu 增加GetFileDTByPage接口。
    ///		2012-03-02 版本：2.9 EricHu 创建文件。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IFileService
    {
        /// <summary>
        /// 文件是否已存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <returns>是否已存在</returns>
        [OperationContract]
        bool Exists(UserInfo userInfo, string folderId, string fileName);

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>文件</returns>
        [OperationContract]
        byte[] Download(UserInfo userInfo, string id);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="enabled">是否有效</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Upload(UserInfo userInfo, string folderId, string fileName, byte[] file, bool enabled);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiFileEntity GetEntity(UserInfo userInfo,string id);

        /// <summary>
        /// 按文件夹获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        DataTable GetDTByFolder(UserInfo userInfo, string folderId);

        /// <summary>
        /// 获取分页文件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        /// <returns>列表</returns>
        [OperationContract]
        DataTable GetFileDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "");

        /// <summary>
        /// 按文件夹删除文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int DeleteByFolder(UserInfo userInfo, string folderId);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="description">描述</param>
        /// <param name="category">分类</param>
        /// <param name="enabled">是否有效</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, string folderId, string fileName, byte[] file, string description, string category, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="folderId">文件夹</param>
        /// <param name="fileName">文件名</param>
        /// <param name="description">描述</param>
        /// <param name="enabled">是否有效</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, string id, string folderId, string fileName, string description, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateFile(UserInfo userInfo, string id, string fileName, byte[] file, out string statusCode, out string statusMessage);

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
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(UserInfo userInfo, string id, string folderId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(UserInfo userInfo, string[] ids, string folderId);

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);

        /// <summary>
        /// 批量删除文件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);
     }
}
