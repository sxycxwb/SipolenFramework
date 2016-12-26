using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IParameterService
    /// 参数服务接口
    /// 
    /// 修改纪录
    /// 
    ///     2015-08-05 版本：3.0 EricHu 新增分页显示、逻辑删除。
    ///		2013-12-21 版本：2.7.0 EricHu 创建文件。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IParameterService
    {
        /// <summary>
        /// 获取服务器上的配置信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="key">配置项主键</param>
        /// <returns>配置内容</returns>
        [OperationContract]
        string GetServiceConfig(UserInfo userInfo, string key);

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">类别键值</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">编码</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        string GetParameter(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiParameterEntity GetEntity(UserInfo userInfo, string id);

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <param name="parameterContent">参数内容</param>
        /// <param name="allowEdit">允许编辑</param>
        /// <param name="allowDelete">允许删除</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetParameter(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode, string parameterContent, int allowEdit = 0, int allowDelete = 0);

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">类别键值</param>
        /// <param name="parameterId">标志主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParameter(UserInfo userInfo, string categoryKey, string parameterId);

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<CiParameterEntity> GetListByParameter(UserInfo userInfo, string categoryKey, string parameterId);

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">类别键值</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">编码</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByParameterCode(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode);

        /// <summary>
        /// 按编号获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        List<CiParameterEntity> GetListByParameterCode(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode);

        /// <summary>
        /// 获取序列分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有角色数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "");

        /// <summary>
        /// 逻辑删除参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(UserInfo userInfo, string id);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">类别键值</param>
        /// <param name="parameterId">标志主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int DeleteByParameter(UserInfo userInfo, string categoryKey, string parameterId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">类别键值</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">标志编号</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int DeleteByParameterCode(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode);

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
    }
}
