using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IWorkFlowHelperService
    /// 
    /// 
    /// 修改记录
    ///     
    ///     
    ///		2014-06-10 版本：2.8 XuWangBin 建立。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-06-10</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IWorkFlowHelperService
    {
        /// <summary>
        /// 创建所有符合条件的任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">处理人Id</param>
        /// <param name="workFlowId">工作流模板id</param>
        /// <param name="workTaskId">当前任务Id</param>
        /// <param name="workFlowInstanceId">工作流实例Id</param>
        /// <param name="workTaskInstanceId">原任务实例Id</param>
        /// <param name="operatorInstanceId">处理者实例Id</param>
        /// <param name="commandName">命令</param>
        /// <returns>
        /// 000002：没有配置后续任务
        /// 000000：操作成功 
        /// </returns>
        [OperationContract]
        string CreateNextTaskInstance(UserInfo userInfo, string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string workTaskInstanceId, string operatorInstanceId, string commandName);

        /// <summary>
        /// 判断节点实例是否都完成
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workFlowInstanceId">工作流实例Id</param>
        /// <param name="judgeTaskId">待判断力的节点Id</param>
        /// <param name="taskTypeAndOr">节点类型：and、or</param>
        /// <returns></returns>
        [OperationContract]
        bool IsPassJudge(UserInfo userInfo, string workFlowId, string workFlowInstanceId, string judgeTaskId, string taskTypeAndOr);

        /// <summary>
        /// 判断任务实例是否已完成,以此来判断避免重复提交
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskInsId">任务实例Id</param>
        /// <returns></returns>
        [OperationContract]
        bool IsTaskInsCompleted(UserInfo userInfo, string workTaskInsId);


        //-----------------AccreditUser-----------------------

        /// <summary>
        /// 增加任务授权
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        [OperationContract]
        string InsertAccreditUser(UserInfo userInfo, AccreditUserEntity entity);

        /// <summary>
        /// 判断用户是否是该任务节点的操作者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns></returns>
        [OperationContract]
        bool IsTaskOperator(UserInfo userInfo, string userId, string workFlowId, string workTaskId);

        /// <summary>
        /// 更新任务授权
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateAccreditUser(UserInfo userInfo, AccreditUserEntity entity);

        /// <summary>
        /// 依据主键获得任务授权列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="aUserId">主键</param>
        /// <returns>任务授权列表</returns>
        [OperationContract]
        DataTable GetAccreditUserTable(UserInfo userInfo, string aUserId);

        /// <summary>
        /// 已授出的任务授权列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <returns>已授出的任务授权列表</returns>
        [OperationContract]
        DataTable GetToAccreditTable(UserInfo userInfo, string userId);

        /// <summary>
        /// 被授予的任务授权列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <returns>被授予的任务授权列表</returns>
        [OperationContract]
        DataTable GetHaveAccreditTable(UserInfo userInfo, string userId);

        /// <summary>
        /// 移除任务授权
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="auserId">主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int MoveAccredit(UserInfo userInfo, string auserId);

        /// <summary>
        /// 根据主键删除任务授权记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="auserId">主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteAccreditUser(UserInfo userInfo, string auserId);

        //-----------------AuditMessage-----------------------
        /// <summary>
        /// 增加审批信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        [OperationContract]
        string InsertAuditMessage(UserInfo userInfo, AuditMessageEntity entity);

        /// <summary>
        /// 修改审批信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateAuditMessage(UserInfo userInfo, AuditMessageEntity entity);

        /// <summary>
        /// 获得操作实例审批列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorInsId">操作实例Id</param>
        /// <returns>审批列表</returns>
        [OperationContract]
        DataTable GetAuditMessageTableByOper(UserInfo userInfo, string operatorInsId);

        /// <summary>
        /// 获得流程实例的审批列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">流程实例Id</param>
        /// <returns>审批列表</returns>
        [OperationContract]
        DataTable GetAuditMessageTableByFlow(UserInfo userInfo, string workFlowInsId);

        //-----------------Attachment-----------------------

        /// <summary>
        /// 增加附件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        [OperationContract]
        string InsertAttachment(UserInfo userInfo, AttachmentEntity entity);

        /// <summary>
        /// 更新任务附件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateAttachment(UserInfo userInfo, AttachmentEntity entity);

        /// <summary>
        /// 依据主键获得附件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>任务附件列表</returns>
        [OperationContract]
        DataTable GetAttachmentTable(UserInfo userInfo, string id);

        /// <summary>
        /// 根据主键删除附件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteAttachment(UserInfo userInfo, string id);

        /// <summary>
        /// 根据条件获得附件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="names">字段</param>
        /// <param name="values">值</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetAttachmentByValues(UserInfo userInfo, string[] names, string[] values);
    }
}
