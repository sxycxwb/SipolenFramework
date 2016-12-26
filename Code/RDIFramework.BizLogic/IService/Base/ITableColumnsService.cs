//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// ITableColumnsService
    /// 服务层接口
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：2.9 EricHu 创建文件。
    ///		
    /// 版本：2.9
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface ITableColumnsService
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(UserInfo userInfo, CiTableColumnsEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按表名获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableCode">表名</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByTable(UserInfo userInfo, string tableCode);

        /// <summary>
        /// 得到所有可做表字段控制权限的数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetTablePermissionScope(UserInfo userInfo);

        /// <summary>
        /// 得到所有数据表（用于表字段权限的控制，主要针对PiTablePermissionScope数据表的数据）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetAllTableScope(UserInfo userInfo);

        /// <summary>
        /// 得到所有数据表（表的中文名称与英文名称）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetTableNameAndCode(UserInfo userInfo);

        /// <summary>
        /// 获取约束条件（所有的约束）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetConstraintDT(UserInfo userInfo, string resourceCategory, string resourceId);

        /// <summary>
        /// 设置约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <param name="constraint">约束</param>
        /// <param name="enabled">有效</param>
        /// <returns>主键</returns>
        [OperationContract]
        string SetConstraint(UserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode, string constraint, bool enabled);

        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        [OperationContract]
        string GetConstraint(UserInfo userInfo, string resourceCategory, string resourceId, string tableName);

        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        [OperationContract]
        PiPermissionScopeEntity GetConstraintEntity(UserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode);

        /// <summary>
        /// 批量删除约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteConstraint(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 获取用户的件约束表达式
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">表名</param>
        /// <returns>主键</returns>
        [OperationContract]
        string GetUserConstraint(UserInfo userInfo, string tableName);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDT(UserInfo userInfo);
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiTableColumnsEntity GetEntity(UserInfo userInfo, string id);
        
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(UserInfo userInfo, CiTableColumnsEntity entity, out string statusCode, out string statusMessage);
        
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
        DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values);
                
        /// <summary>
        /// 批量保存数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(UserInfo userInfo, DataTable dataTable);
                
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Delete(UserInfo userInfo, string id);
        
        /// <summary>
        /// 批量删除数据
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
        /// 得到查询字段项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableCode">表名称</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetSearchFields(UserInfo userInfo,string tableCode);

        /// <summary>
        /// 增加可做表权限控制的数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddTablePermissionScope(UserInfo userInfo, PiTablePermissionScopeEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 删除表权限控制表中指定数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="names">字段列表</param>
        /// <param name="values">字段列表值</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int DeleteTablePermissionScope(UserInfo userInfo, string[] names, object[] values);

        /// <summary>
        /// 批量设置表权限控制数据表的刪除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetTablePermissionScopeDeleted(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 取得表权限控制数据表实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">字段名称</param>
        /// <param name="value">字段值</param>
        /// <returns>实体</returns>
        [OperationContract]
        PiTablePermissionScopeEntity GetTablePermissionScopeEntity(UserInfo userInfo, string name, object value);
     }
}
