//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IItemsService
    /// 数据字典服务层接口
    /// 
    /// 修改纪录
    /// 
    ///     2015-04-03 版本：2.9 XuWangBin 新增：GetItemDetailDTByItemId
    ///		2012-03-02 版本：1.0 XuWangBin 创建文件。		
    /// 版本：2.9
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IItemsService
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        [OperationContract]
        string Add(UserInfo userInfo, CiItemsEntity itemsEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);
        
        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParent(UserInfo userInfo, string parentId);

        /// <summary>
        /// 根据数据字典主键得到字典明细数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemId">父级主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetItemDetailDTByItemId(UserInfo userInfo, string itemId);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiItemsEntity GetEntity(UserInfo userInfo, string id);
        
         /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Update(UserInfo userInfo, CiItemsEntity itemsEntity, out string statusCode, out string statusMessage);
        
                  
         /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="id">主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string tableName, string id);    
        

        /// <summary>
        /// 批量删除标志
		/// </summary>
		/// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
		/// <returns>受影响的行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string[] ids);
        
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">表名</param>
        /// <param name="statusCode">状态返回码</param>
        /// <param name="statusMessage">状态返回信息</param>
        [OperationContract]
        void CreateTable(UserInfo userInfo, string tableName, out string statusCode, out string statusMessage);
     }
}
