using System.Data;
using System.ServiceModel;
using RDIFramework.Utilities;

namespace RDIFramework.BizLogic
{
    //IWorkFlowUserControlService.UserControls接口部分：子表单管理接口

    public partial interface IWorkFlowUserControlService
    {
        /// <summary>
        /// 新增子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子表单实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertUserControl(UserInfo userInfo, UserControlsEntity entity);

        /// <summary>
        /// 修改一个子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子表单实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateUserControl(UserInfo userInfo, UserControlsEntity entity);

        /// <summary>
        /// 删除一个子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteUserControl(UserInfo userInfo, string userControlId);

        /// <summary>
        /// 逻辑删除子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">主表单Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int SetDeletedUserControl(UserInfo userInfo, string userControlId);

        /// <summary>
        /// 删除子表单隶属的组关系
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteMainCtrlsOfUser(UserInfo userInfo, string userControlId);

        /// <summary>
        /// 获得所有子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>子表单列表</returns>
        [OperationContract]
        DataTable GetAllChildUserControls(UserInfo userInfo);

        /// <summary>
        /// 获得主表单分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserControlByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0,int pageSize = 50, string order = null);

        /// <summary>
        /// 获得指定子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单主键</param>
        /// <returns>子表单列表</returns>
        [OperationContract]
        DataTable GetChildUserControl(UserInfo userInfo, string userControlId);

        /// <summary>
        /// 获得子表单隶属的主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单id</param>
        /// <returns>子表单隶属的主表单列表</returns>
        [OperationContract]
        DataTable GetMainCtrlsOfChild(UserInfo userInfo, string userControlId);

    }
}
