using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 工作流程运转核心
    /// </summary>
    public class WorkFlowRuntime
    {
        #region 公共变量区域

        /// <summary>
        /// 当前用户
        /// </summary>
        public UserInfo CurrentUser { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 流程模版主键
        /// </summary>
        public string WorkFlowId { get; set; }

        /// <summary>
        /// 任务模版主键
        /// </summary>
        public string WorkTaskId { get; set; }

        /// <summary>
        /// 流程实例主键
        /// </summary>
        public string WorkFlowInstanceId { get; set; }

        /// <summary>
        /// 任务实例主键
        /// </summary>
        public string WorkTaskInstanceId { get; set; }

        /// <summary>
        /// 处理者实例主键
        /// </summary>
        public string OperatorInstanceId { get; set; }

        /// <summary>
        /// 执行的命令名
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// 流程编号
        /// </summary>
        public string WorkFlowNo { get; set; }

        /// <summary>
        /// 流程流程实例的名称
        /// </summary>
        public string WorkflowInsCaption { get; set; }

        /// <summary>
        /// 流程流程实例说明信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 流程流程实例优先级
        /// </summary>
        public string Priority = "1";

        /// <summary>
        /// 流程流程实例状态
        /// </summary>
        public string Status = "2";

        /// <summary>
        /// 流程流程实例当前任务节点
        /// </summary>
        public string NowTaskId { get; set; }

        /// <summary>
        /// 退回原因
        /// </summary>
        public string backyy { get; set; }

        /// <summary>
        /// 是否是子流程
        /// </summary>
        public bool IsSubWorkflow = false;

        /// <summary>
        /// 草稿状态，只保存不提交
        /// </summary>
        public bool IsDraft = false;

        /// <summary>
        /// 主流程实例Id
        /// </summary>
        public string MainWorkflowInsId { get; set; }

        /// <summary>
        /// 主任务模板Id,即子流程任务节点的Id
        /// </summary>
        public string MainWorktaskId { get; set; }

        /// <summary>
        /// 主流程模板Id
        /// </summary>
        public string MainWorkflowId { get; set; }

        /// <summary>
        /// 主任务实例Id，进入子节点前的任务节点实例
        /// </summary>
        public string MainWorktaskInsId { get; set; }

        /// <summary>
        /// 指派任务接受用户Id
        /// </summary>
        public string AssignUserId { get; set; }

        #endregion

        /// <summary>
        /// 执行成功委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void RunSuccessEventHandler(Object sender, WorkFlowEventArgs e);

        /// <summary>
        /// 执行失败委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void RunFailEventHandler(Object sender, WorkFlowEventArgs e);

        /// <summary>
        /// 流程流转成功，流转动作包括提交等
        /// </summary>
        public event RunSuccessEventHandler RunSuccess;

        /// <summary>
        /// 流程流转失败，流转动作包括提交等
        /// </summary>
        public event RunFailEventHandler RunFail;

        /// <summary>
        /// 任务提交
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(WorkFlowId)) return WorkFlowConst.IsNullWorkFlowIdCode;
                if (string.IsNullOrEmpty(WorkTaskId)) return WorkFlowConst.IsNullWorkTaskIdCode;
                if (string.IsNullOrEmpty(WorkFlowInstanceId)) return WorkFlowConst.IsNullWorkFlowInsIdCode;
                if (string.IsNullOrEmpty(WorkTaskInstanceId)) return WorkFlowConst.IsNullWorkTaskInsIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                if (string.IsNullOrEmpty(CommandName)) return WorkFlowConst.IsNullCommandNameCode;

                if (RDIFrameworkService.Instance.WorkFlowHelperService.IsTaskInsCompleted(this.CurrentUser, WorkTaskInstanceId)) return WorkFlowConst.InstanceIsCompletedCode;//流程实例已完成，不能重复提交
                var result = RDIFrameworkService.Instance.WorkFlowHelperService.CreateNextTaskInstance(this.CurrentUser, UserId, WorkFlowId, WorkTaskId, WorkFlowInstanceId, WorkTaskInstanceId, OperatorInstanceId, CommandName);
                if (result != WorkFlowConst.SuccessCode)
                {
                    var e = new WorkFlowEventArgs(this) { ResultMsg = result };
                    OnRunFail(this, e);
                    return result;
                }
                else
                {
                    var e = new WorkFlowEventArgs(this) { ResultMsg = WorkFlowConst.SuccessMsg };
                    OnRunSuccess(this, e);
                }
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                var msg = string.Format(WorkFlowConst.EngineErrorMsg, ex.Message);
                var e = new WorkFlowEventArgs(this) { ResultMsg = msg };
                OnRunFail(this, e);
                return WorkFlowConst.OtherErrorCode;
            }
        }

        /// <summary>
        /// 任务提交
        /// </summary>
        /// <param name="userid">用户Id</param>
        /// <param name="operatorInsId">操作员实例Id</param>
        /// <param name="commandName">命令</param>
        public string Run(string userid, string operatorInsId, string commandName)
        {
            if (string.IsNullOrEmpty(userid)) return WorkFlowConst.IsNullUserIdCode;
            if (string.IsNullOrEmpty(operatorInsId)) return WorkFlowConst.IsNullOperatorInsIdCode;
            if (string.IsNullOrEmpty(commandName)) return WorkFlowConst.IsNullCommandNameCode;
            var operdt = RDIFrameworkService.Instance.WorkFlowInstanceService.GetOperatorInstance(this.CurrentUser,operatorInsId);
            if (operdt != null && operdt.Rows.Count > 0)
            {
                WorkFlowId = operdt.Rows[0][OperatorInstanceTable.FieldWorkFlowId].ToString();
                WorkTaskId = operdt.Rows[0][OperatorInstanceTable.FieldWorkTaskId].ToString();
                WorkFlowInstanceId = operdt.Rows[0][OperatorInstanceTable.FieldWorkFlowInsId].ToString();
                WorkTaskInstanceId = operdt.Rows[0][OperatorInstanceTable.FieldWorkTaskInsId].ToString();
                UserId = userid;
                OperatorInstanceId = operatorInsId;
                CommandName = commandName;
                return Run();
            }
            return WorkFlowConst.NoFoundInstanceCode;
        }

        /// <summary>
        /// 流程启动，草稿和启动两种状态
        /// </summary>
        public string Start()
        {
            try
            {
                if (string.IsNullOrEmpty(WorkFlowInstanceId))
                    WorkFlowInstanceId = BusinessLogic.NewGuid();
                if (string.IsNullOrEmpty(WorkTaskInstanceId))
                    WorkTaskInstanceId = BusinessLogic.NewGuid();
                if (string.IsNullOrEmpty(OperatorInstanceId))
                    OperatorInstanceId = BusinessLogic.NewGuid();
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (CurrentUser == null) return WorkFlowConst.IsNullUser;
                if (string.IsNullOrEmpty(WorkFlowId)) return WorkFlowConst.IsNullWorkFlowIdCode;
                if (string.IsNullOrEmpty(WorkTaskId)) return WorkFlowConst.IsNullWorkTaskIdCode;
                if (string.IsNullOrEmpty(CommandName)) return WorkFlowConst.IsNullCommandNameCode;
                if (string.IsNullOrEmpty(WorkFlowNo)) return WorkFlowConst.IsNullWorkFlowNoCode;
                if (string.IsNullOrEmpty(WorkflowInsCaption)) return WorkFlowConst.IsNullWorkflowInsCaption;

                if (RDIFrameworkService.Instance.WorkFlowHelperService.IsTaskInsCompleted(this.CurrentUser,WorkTaskInstanceId)) 
                    return WorkFlowConst.InstanceIsCompletedCode;//流程实例已完成，不能重复提交

                //检查是否已经保存过草稿。如果已经保存过则不需要再创建实例，只保存业务表单数据,
                //此处的处理与交互节点的处理不同，需要加判断。

                if (RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskInstanceExist(this.CurrentUser, WorkTaskInstanceId) == false)//实例不存在，说明未保存过
                {
                    //创建流程实例
                    var workflowInstance = new WorkFlowInstanceEntity()
                    {
                        WorkFlowId = WorkFlowId,
                        WorkFlowInsId = WorkFlowInstanceId,
                        WorkFlowNo = WorkFlowNo,
                        FlowInsCaption= WorkflowInsCaption,
                        Description = Description,
                        Priority = Priority,
                        Status = Status,
                        NowTaskId = WorkTaskId,//当前流程所处流程模板的位置
                        IsSubWorkflow = IsSubWorkflow ? 1: 0,
                        MainWorkflowInsId = MainWorkflowInsId,
                        MainWorktaskId = MainWorktaskId,
                        MainWorkflowId = MainWorkflowId,
                        MainWorktaskInsId = MainWorktaskInsId
                    };
                   
                    RDIFrameworkService.Instance.WorkFlowInstanceService.CreateWorkFlowInstance(this.CurrentUser,workflowInstance);

                    //创建启动节点的任务实例
                    var workTaskInstance = new WorkTaskInstanceEntity
                    {
                        WorkFlowId = WorkFlowId,
                        WorkTaskId = WorkTaskId,
                        WorkFlowInsId = WorkFlowInstanceId,
                        WorkTaskInsId = WorkTaskInstanceId,
                        TaskInsCaption =RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCaption(this.CurrentUser,WorkTaskId)
                    };

                    if (IsSubWorkflow)//是子流程调用，需要放到未认领任务中
                    {
                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                        workTaskInstance.Status = "1";
                    }
                    else//不是子流程调用,启动节点直接放入已认领任务中
                    {
                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;//开始节点的前一节点等于自己
                        workTaskInstance.Status = "2";
                    }

                    RDIFrameworkService.Instance.WorkFlowInstanceService.CreateWorkTaskInstance(this.CurrentUser,workTaskInstance);

                    //创建启动节点的处理人实例
                    var operatorInstance = new OperatorInstanceEntity
                    {
                        OperatorInsId = OperatorInstanceId,
                        WorkFlowId = WorkFlowId,
                        WorkTaskId = WorkTaskId,
                        WorkFlowInsId = WorkFlowInstanceId,
                        WorkTaskInsId = WorkTaskInstanceId,
                        UserId = UserId,
                        OperRealtion = 0,
                        OperContent = UserId
                    };
                    var userEnity = RDIFrameworkService.Instance.UserService.GetEntity(this.CurrentUser, UserId);
                    var userName = userEnity == null || string.IsNullOrEmpty(userEnity.UserName)
                        ? "未找到处理人"
                        : userEnity.UserName;

                    operatorInstance.OperContentText = userName;
                    operatorInstance.OperType = 3;
                    if (IsSubWorkflow) //是子流程调用，需要放到未认领任务中
                    {
                        operatorInstance.OperStatus = "0";
                    }
                    else //不是子流程调用,启动节点直接放入已认领任务中
                    {
                        operatorInstance.OperStatus = "3";
                    }
                    RDIFrameworkService.Instance.WorkFlowInstanceService.CreateOperatorInstance(this.CurrentUser,operatorInstance);
                }

                if (!IsDraft)//不是草稿状态，提交任务
                {
                    var result = RDIFrameworkService.Instance.WorkFlowHelperService.CreateNextTaskInstance(this.CurrentUser,UserId, WorkFlowId, WorkTaskId, WorkFlowInstanceId, WorkTaskInstanceId, OperatorInstanceId, CommandName);
                    if (result != WorkFlowConst.SuccessCode)
                    {
                        var e = new WorkFlowEventArgs(this) {ResultMsg = result};
                        OnRunFail(this, e);
                        return result;
                    }
                    else
                    {
                        var e = new WorkFlowEventArgs(this) {ResultMsg = WorkFlowConst.SuccessMsg};
                        OnRunSuccess(this, e);
                    }
                }
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                var msg = string.Format(WorkFlowConst.EngineErrorMsg, ex.Message);
                var e = new WorkFlowEventArgs(this) {ResultMsg = msg};
                OnRunFail(this, e);
                return WorkFlowConst.OtherErrorCode;
            }
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnRunSuccess(Object sender, WorkFlowEventArgs e)
        {
            if (RunSuccess != null)
            {
                RunSuccess(this, e); //提交成功后触发成功事件
            }
        }

        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnRunFail(Object sender, WorkFlowEventArgs e)
        {
            if (RunFail != null)
            {
                RunFail(this, e);
            }
        }

        /// <summary>
        /// 任务指派
        /// </summary>
        public string TaskAssign()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId) || this.CurrentUser == null) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(AssignUserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskAssign(this.CurrentUser,UserId, AssignUserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务认领
        /// </summary>
        public string TaskClaim()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId) || this.CurrentUser == null) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskClaim(this.CurrentUser,UserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取消认领任务
        /// </summary>
        public string TaskUnClaim()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskUnClaim(this.CurrentUser,UserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务取回
        /// </summary>
        public void TaskRetake()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 任务退回
        /// </summary>
        public string TaskBack()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskBack(this.CurrentUser,UserId, OperatorInstanceId, backyy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务任意退回
        /// </summary>
        public string TaskBackry()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId) || this.CurrentUser == null) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                //return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskBackry(this.CurrentUser,UserId, OperatorInstanceId, backyy, WorkTaskId);
                return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskBackry(this.CurrentUser, UserId, OperatorInstanceId, backyy,WorkFlowInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务撤回
        /// </summary>
        /// <returns></returns>
        public string TaskRevoke()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId) || this.CurrentUser == null ) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(MainWorktaskInsId)) return WorkFlowConst.IsNullWorkTaskInsIdCode;
                return RDIFrameworkService.Instance.WorkFlowInstanceService.WorkTaskRevoke(this.CurrentUser,UserId, MainWorktaskInsId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 流程挂起
        /// </summary>
        public string SetSuspend(string workflowInsId)
        {
            try
            {
                if (string.IsNullOrEmpty(workflowInsId)) return WorkFlowConst.IsNullWorkFlowInsIdCode;
                return RDIFrameworkService.Instance.WorkFlowInstanceService.SetSuspend(this.CurrentUser,workflowInsId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务授权
        /// </summary>
        /// <param name="fromUserId">授权UserId</param>
        /// <param name="toUserId">被授权UserId</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="worktaskId">任务模板Id</param>
        /// <returns></returns>
        public string AssignAccredit(string fromUserId, string toUserId, string workflowId, string worktaskId)
        {
            try
            {
                var au = new AccreditUserEntity
                {
                    AUserId = BusinessLogic.NewGuid(),
                    AccreditFromUserId = fromUserId,
                    AccreditToUserId = toUserId,
                    AcWorkflowId = workflowId,
                    AcWorktaskId = worktaskId
                };
                return string.IsNullOrEmpty(RDIFrameworkService.Instance.WorkFlowHelperService.InsertAccreditUser(this.CurrentUser, au)) ? WorkFlowConst.OtherErrorCode : WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
