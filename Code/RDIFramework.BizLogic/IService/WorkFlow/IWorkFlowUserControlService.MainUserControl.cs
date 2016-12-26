using System.Data;
using System.ServiceModel;
using RDIFramework.Utilities;

namespace RDIFramework.BizLogic
{
    //IWorkFlowUserControlService.MainUserControl接口部分：主表单管理接口

    public partial interface IWorkFlowUserControlService
    {
        /// <summary>
        /// 增加主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">主表单实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertMainUserCtrl(UserInfo userInfo, MainUserControlEntity entity);

        /// <summary>
        /// 更新主表单知
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">主表单实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateMainUserCtrl(UserInfo userInfo, MainUserControlEntity entity);

        /// <summary>
        /// 获得一个主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主表单主键</param>
        /// <returns>主表单表</returns>
        [OperationContract]
        DataTable GetMainUserControl(UserInfo userInfo, string id);

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
        DataTable GetMainUserControlByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0,int pageSize = 50, string order = null);

        /// <summary>
        /// 根据表单名称获得一个主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">表单名</param>
        /// <returns>主表单列表</returns>
        [OperationContract]
        DataTable GetMainUserControlByFullName(UserInfo userInfo, string fullName);

        /// <summary>
        /// 删除主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主表单Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteMainUserCtrl(UserInfo userInfo, string id);

        /// <summary>
        /// 逻辑删除主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主表单Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int SetDeletedMainUserCtrl(UserInfo userInfo, string id);

        /// <summary>
        /// 获得主表单的所有子表单列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单Id</param>
        /// <returns>子表单列表</returns>
        [OperationContract]
        DataTable GetAllChildUserControlsById(UserInfo userInfo, string mainUserCtrlId);

        /// <summary>
        /// 获得所有主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>主表单列表</returns>
        [OperationContract]
        DataTable GetAllMainUserControls(UserInfo userInfo);

        /// <summary>
        /// 增加子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <param name="controlOrder">顺序号,以此排序</param>
        /// <param name="controlState">子表单状态</param>
        /// <returns>增加成功返回主键</returns>
        [OperationContract]
        string AddUserControls(UserInfo userInfo, string mainUserCtrlId, string userContrlsId, int controlOrder, string controlState);

        /// <summary>
        /// 删除主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int MoveUserControls(UserInfo userInfo, string mainUserCtrlId, string userContrlsId);

        /// <summary>
        /// 移除所有子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int MoveUserControlsOfMain(UserInfo userInfo, string mainUserCtrlId);

        /// <summary>
        /// 修改主表单下指定子表单的状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <param name="controlState">状态</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int EditMainUserControlsState(UserInfo userInfo, string mainUserCtrlId, string userContrlsId,string controlState = "查看");

        /// <summary>
        /// 得到工作流所有的工作任务表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版主键</param>
        /// <returns>工作任务表单列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllControlsLink(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 得到指定工作流所有的主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版主键</param>
        /// <returns>工作流所有的主表单列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllMainControls(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 得到指定流程所有的子表单列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版主键</param>
        /// <returns>表单列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllControls(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 是否存在指定工作任务表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskControlId">工作流程Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        [OperationContract]
        bool ExistsTaskControls(UserInfo userInfo, string taskControlId);

        /// <summary>
        /// 是否存在指定主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        [OperationContract]
        bool ExistsMainControls(UserInfo userInfo, string mainUserCtrlId);

        /// <summary>
        /// 是否存在指定用户表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userCtrlId">用户表单Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        [OperationContract]
        bool ExistsUserControls(UserInfo userInfo, string userCtrlId);

        /// <summary>
        /// 是否存在指定主子表单关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ctrlLinkId">关联Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        [OperationContract]
        bool ExistsControlsLink(UserInfo userInfo, string ctrlLinkId);

    }
}
