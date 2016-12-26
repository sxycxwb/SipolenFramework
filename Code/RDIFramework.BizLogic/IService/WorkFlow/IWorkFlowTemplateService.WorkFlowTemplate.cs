using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;                                                                                                                                                                                                                                                                                                   

    //IWorkFlowTemplateService.WorkFlowTemplate接口部分：流程模版管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 新建 一个流程模板
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程模板实体</param>
        /// <returns>增加成功后的主键</returns>
        [OperationContract]
		string InsertWorkFlow(UserInfo userInfo, WorkFlowTemplateEntity entity);

        /// <summary>
        /// 修改一个流程模板
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程模板实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
		int UpdateWorkFlow(UserInfo userInfo, WorkFlowTemplateEntity entity);
        
        /// <summary>
        /// 删除一个流程模板
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
		int DeleteWorkFlow(UserInfo userInfo, string workFlowId);
        
        /// <summary>
        /// 获得工作流模板信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns></returns>
        [OperationContract]
		DataTable GetWorkFlowTable(UserInfo userInfo, string workFlowId);
       
        /// <summary>
        /// 得到指定工作流程所有的任务表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>指定工作流程所有的任务表单</returns>
        [OperationContract]
		DataTable GetWorkFlowAllControlsTable(UserInfo userInfo, string workFlowId);
                
        /// <summary>
        /// 得到流程模板实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>流程模板实体</returns>
        [OperationContract]
		WorkFlowTemplateEntity GetWorkFlowInfo(UserInfo userInfo, string workFlowId);
        
        /// <summary>
        /// 获得有权限启动的流程
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <returns>有权启动的流程列表</returns>
        [OperationContract]
		DataTable GetAllowStartWorkFlows(UserInfo userInfo, string userId);
        
        /// <summary>
        /// 依据流程模版名称获得流程模板列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowCaption">流程模板名称</param>
        /// <returns>流程模板列表</returns>
        [OperationContract]
		DataTable GetWorkFlowsByCaption(UserInfo userInfo, string workFlowCaption);
        
        /// <summary>
        /// 是否存在指定流程模版
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>true:存在,false:不存在</returns>
        [OperationContract]
		bool WorkFlowExists(UserInfo userInfo, string workFlowId);
        
        /// <summary>
        /// 设置工作流模板状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="status">
        /// 启用：status=1 
        /// 禁用：status=0 
        /// </param>
        /// <returns>大于0设置成功</returns>
        [OperationContract]
		int SetWorkFlowStatus(UserInfo userInfo, string workFlowId, string status);
        
        /// <summary>
        /// 设置流程模版分类
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="wfClassId">流程分类Id</param>
        /// <returns>大于0设置成功</returns>
        [OperationContract]
		int SetWorkFlowClass(UserInfo userInfo, string workFlowId, string wfClassId);    
    }
}
