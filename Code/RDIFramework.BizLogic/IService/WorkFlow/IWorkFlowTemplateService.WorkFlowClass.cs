using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.WorkFlowClass接口部分：流程分类管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 新增流程分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">分类实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertWorkFlowClass(UserInfo userInfo, WorkFlowClassEntity entity);

        /// <summary>
        /// 修改流程分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">分类实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateWorkFlowClass(UserInfo userInfo, WorkFlowClassEntity entity);

        /// <summary>
        /// 删除指定流程分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowClassId">流程分类Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteWorkFlowClass(UserInfo userInfo, string workFlowClassId);

        /// <summary>
        /// 获得流程分类的所有子分类列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fatherClassId">父分类id</param>
        /// <returns>分类列表</returns>
        [OperationContract]
        DataTable GetChildWorkFlowClass(UserInfo userInfo, string fatherClassId);

        /// <summary>
        /// 获得流程分类下的所有流程列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="classId">流程分类Id</param>
        /// <returns>流程分类列表</returns>
        [OperationContract]
        DataTable GetWorkFlowsByClassId(UserInfo userInfo, string classId);

        /// <summary>
        /// 获得流程分类实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="classId">流程分类Id</param>
        /// <returns>分类实体</returns>
        [OperationContract]
        WorkFlowClassEntity GetWorkFlowClassInfo(UserInfo userInfo, string classId);
    }
}
