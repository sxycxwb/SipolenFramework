using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public class InstanceTypeManager : DbCommonManager
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public InstanceTypeManager()
        {           
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public InstanceTypeManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public InstanceTypeManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public InstanceTypeManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }
        #endregion

        #region public bool AssignUser(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string workTaskInstanceId, OperParameter operParam) 指定处理人
        /// <summary>
        /// 指定处理人
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="workTaskInstanceId">任务实例Id</param>
        /// <param name="operParam">处理者参数</param>
        /// <returns>是否成功</returns>
        public bool AssignUser(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string workTaskInstanceId, OperParameter operParam)
        {
            if (string.IsNullOrEmpty(operParam.OperContent)) return false;

            switch (operParam.OperRule)
            {
                case "1":
                {
                    //创建处理人实例
                    var operInsEntity = new OperatorInstanceEntity(){
                        OperatorInsId = BusinessLogic.NewGuid(),
                        WorkFlowId = workFlowId,
                        WorkTaskId = workTaskId,
                        WorkFlowInsId = workFlowInstanceId,
                        WorkTaskInsId = workTaskInstanceId,//此时是新任务Id
                        UserId = "",
                        OperRealtion = operParam.OperRelation,
                        OperContent = operParam.OperContent,
                        OperContentText = operParam.OperContenText,
                        OperType = operParam.OperType//此处保留原来的处理类型
                    };
                    string successCode = new OperatorInstanceManager(this.DBProvider).Create(operInsEntity);

                    //给处理者发送信息
                    if (!string.IsNullOrEmpty(successCode) && successCode.Length > 0)
                    {
                        var messageEntity = new CiMessageEntity
                        {
                            Id = BusinessLogic.NewGuid(),
                            FunctionCode = MessageFunction.Remind.ToString(),
                            ReceiverId = DefaultRole.Administrator.ToString(),
                            Title = "业务流程消息",
                            MSGContent = "你有一待办任务，请到未认领任务界面认领。",
                            IsNew = 1,
                            ReadCount = 0,
                            Enabled = 1,
                            DeleteMark = 0
                        };

                        var messageManager = new CiMessageManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString),this.UserInfo);
                        messageManager.BatchSend(operInsEntity.OperContent, null, null, messageEntity, false);
                    }   

                    if ((userId == operParam.OperContent) && (operParam.IsJumpSelf))//处理者是提交人，自动处理
                    {
                        var wfrun = new WorkFlowRuntime();
                        wfrun.Run(userId, operInsEntity.OperatorInsId, "提交");
                    }
                }
                break;
                case "2":
                {
                    //创建任务实例
                    var newTaskId = BusinessLogic.NewGuid();//新任务实例Id
                    var workTaskInsEntity = new WorkTaskInstanceEntity()
                    {
                        WorkFlowId = workFlowId,
                        WorkTaskId = workTaskId,
                        WorkFlowInsId = workFlowInstanceId,
                        WorkTaskInsId = newTaskId,
                        PreviousTaskId = workTaskInstanceId,//此时是当前任务Id
                        TaskInsCaption = new WorkTaskManager(this.DBProvider).GetTaskCaption(workTaskId),
                        Status = "1",
                    };
                    new WorkTaskInstanceManager(this.DBProvider).Create(workTaskInsEntity);   
           
                    //创建处理人实例
                    var operInsEntity = new OperatorInstanceEntity()
                    {
                        OperatorInsId = BusinessLogic.NewGuid(),
                        WorkFlowId = workFlowId,
                        WorkTaskId = workTaskId,
                        WorkFlowInsId = workFlowInstanceId,
                        WorkTaskInsId = newTaskId,
                        UserId = "",
                        OperRealtion = operParam.OperRelation,
                        OperContent = operParam.OperContent,
                        OperContentText = operParam.OperContenText,
                        OperType = 3,//此处修改为指定处理人
                    };
                    string successCode = new OperatorInstanceManager(this.DBProvider).Create(operInsEntity);

                    //给处理者发送信息
                    if (!string.IsNullOrEmpty(successCode) && successCode.Length > 0)
                    {
                        var messageEntity = new CiMessageEntity
                        {
                            Id = BusinessLogic.NewGuid(),
                            FunctionCode = MessageFunction.Remind.ToString(),
                            ReceiverId = DefaultRole.Administrator.ToString(),
                            Title = "业务流程消息",
                            MSGContent = "你有一待办任务，请到未认领任务界面认领。",
                            IsNew = 1,
                            ReadCount = 0,
                            Enabled = 1,
                            DeleteMark = 0
                        };

                        var messageManager = new CiMessageManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString),this.UserInfo);
                        messageManager.BatchSend(operInsEntity.OperContent, null, null, messageEntity, false);
                    }
                    if ((userId == operParam.OperContent) && (operParam.IsJumpSelf))//处理者是提交人，自动处理
                    {
                        var wfrun = new WorkFlowRuntime();
                        wfrun.Run(userId, operInsEntity.OperatorInsId, "提交");
                    }
                }
                break;
            }
            return true;
        }
        #endregion

        #region public bool AssignArchitecture(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string WorkTaskInstanceId, OperParameter operParam) 组织机构处理者

        /// <summary>
        /// 组织机构处理者
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="workTaskInstanceId">任务实例Id</param>
        /// <param name="operParam"></param>
        /// <returns>是否成功</returns>
        public bool AssignArchitecture(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string workTaskInstanceId, OperParameter operParam)
        {
            var tmpUser = "";
            var tmpUserName = "";
            if (string.IsNullOrEmpty(operParam.OperContent)) return false;

            switch (operParam.OperRule)
            {
                case "1":
                    AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    break;
                case "2":
                {
                    //var archUser = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetChildrenUsers(operParam.OperContent);
                    var archUser = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType,SystemInfo.RDIFrameworkDbConectionString)).GetDTByRole(operParam.OperContent);
                    if (archUser == null || archUser.Rows.Count <= 0)
                    {
                        throw new Exception("引擎没有找到处理者,请检查是否配置处理者。");                        
                        //WriteErrorLog("部门或者岗位[" + operParam.OperContenText + "]没有配置处理人!!!", workFlowInstanceId);
                    }
                    foreach (DataRow dr in archUser.Rows)
                    {
                        tmpUser = dr[PiUserTable.FieldId].ToString();
                        tmpUserName = dr[PiUserTable.FieldRealName].ToString();
                        operParam.OperContent = tmpUser;
                        operParam.OperContenText = tmpUserName;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    }
                }
                    break;
            }
            return true;
        }
        #endregion

        #region public bool AssignGroup(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string WorkTaskInstanceId, OperParameter operParam) 角色处理者
        /// <summary>
        /// 角色处理者
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="workTaskInstanceId">任务实例Id</param>
        /// <param name="operParam"></param>
        /// <returns>是否成功</returns>
        public bool AssignGroup(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string workTaskInstanceId, OperParameter operParam)
        {
            //WriteErrorLog("AssignGroup处理者类型:operContent= " + operParam.OperContent, workFlowInstanceId);
            var tmpUser = "";
            var tmpUserName = "";
            if (string.IsNullOrEmpty(operParam.OperContent)) return false;
            switch (operParam.OperRule)
            {
                case "1":
                    AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    break;
                case "2":
                {
                    var archUser = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetDTByRole(operParam.OperContent);
                    if (archUser == null || archUser.Rows.Count <= 0)
                    {
                        throw new Exception("引擎没有找到处理者,请检查是否配置处理者。");
                        //WriteErrorLog("角色[" + operParam.OperContenText + "]没有配置处理人!!!", workFlowInstanceId);
                    }
                    foreach (DataRow dr in archUser.Rows)
                    {
                        tmpUser = dr[PiUserTable.FieldId].ToString();
                        tmpUserName = dr[PiUserTable.FieldUserName].ToString();
                        operParam.OperContent = tmpUser;
                        operParam.OperContenText = tmpUserName;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    }
                }
                    break;
            }
            return true;
        }
        #endregion

        #region public bool AssignAll(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string WorkTaskInstanceId, OperParameter operParam) 所有人
        /// <summary>
        /// 所有人
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="workTaskInstanceId">任务实例Id</param>
        /// <param name="operParam"></param>
        /// <returns>是否成功</returns>
        public bool AssignAll(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,string workTaskInstanceId, OperParameter operParam)
        {
            //WriteErrorLog("AssignAll处理者类型:operContent= " + operParam.OperContent, workFlowInstanceId);
            var tmpUser = "";
            var tmpUserName = "";
            if (string.IsNullOrEmpty(operParam.OperContent)) return false;
            switch (operParam.OperRule)
            {
                case "1":
                    operParam.OperContent = "ALL";
                    AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    break;
                case "2":
                {
                    string[] names = { PiUserTable.FieldDeleteMark, PiUserTable.FieldEnabled};
                    Object[] values = { 0,1};
                    var dtAllUser = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetDT(names,values,PiUserTable.FieldSortCode);
                    if (dtAllUser == null || dtAllUser.Rows.Count <= 0)
                    {
                        throw new Exception("引擎没有找到处理者,请检查是否配置处理者。");
                        // WriteErrorLog("所有人" + operParam.OperContenText + "]没有配置处理人!!!", workFlowInstanceId);
                    }
                    foreach (DataRow dr in dtAllUser.Rows)
                    {
                        tmpUser = dr[PiUserTable.FieldId].ToString();
                        tmpUserName = dr[PiUserTable.FieldUserName].ToString();
                        operParam.OperContent = tmpUser;
                        operParam.OperContenText = tmpUserName;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    }
                }
                    break;
            }
            return true;
        }
        #endregion

        #region public string GetStartWorkflowUser(string workFlowInstanceId) 获得流程启动者
        /// <summary>
        /// 获得流程启动者
        /// </summary>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <returns>流程处理者</returns>
        public string GetStartWorkflowUser(string workFlowInstanceId)
        {
            var sql = string.Format("select UserId from WorkTaskInstanceView where WorkFlowInsId={0} and tasktypeid='1'", DBProvider.GetParameter("WorkFlowInsId"));
            return BusinessLogic.ConvertToString(this.DBProvider.ExecuteScalar(sql, new IDbDataParameter[] { DBProvider.MakeParameter("WorkFlowInsId", workFlowInstanceId) }));   
        }
        #endregion

        #region public DataTable GetTaskInstanceUser(string workFlowInstanceId, string worktaskId) 某一任务实际处理者
        /// <summary>
        /// 某一任务实际处理者
        /// </summary>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="worktaskId">任务Id</param>
        /// <returns>某一任务实际处理者</returns>
        public DataTable GetTaskInstanceUser(string workFlowInstanceId, string worktaskId)
        {
            var sql = string.Format("SELECT DISTINCT USERID FROM WORKTASKINSTANCEVIEW WHERE WORKFLOWINSID={0} AND STATUS='3' AND  WORKTASKID={1}",
                DBProvider.GetParameter("WorkFlowInsId"),
                DBProvider.GetParameter("worktaskId"));
            return this.DBProvider.Fill(sql,new IDbDataParameter[] { 
                DBProvider.MakeParameter("WorkFlowInsId", workFlowInstanceId), 
                DBProvider.MakeParameter("worktaskId", worktaskId)
            });            
        }
        #endregion

        public bool UserRelation(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string workTaskInstanceId, OperParameter operParam)
        {
            switch (operParam.OperRelation)
            {
                case 1://本部门领导
                    //获得用户所属部门                    
                    var dtArch = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetDTById(operParam.OperContent);//获得用户所属部门
                    foreach (DataRow drArch in dtArch.Rows)//可能一个人属于多个部门
                    {
                        var archId = BusinessLogic.ConvertToString(drArch[PiUserTable.FieldDepartmentId]);
                        var orgEntity = new PiOrganizeManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetEntity(archId);
                        operParam.OperContent = orgEntity.ManagerId;
                        operParam.OperContenText = orgEntity.Manager;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    }
                    break;
                case 2://所在部门
                    var userEntity = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetEntity(operParam.OperContent);
                    operParam.OperContent = userEntity.DepartmentId;
                    operParam.OperContenText = userEntity.DepartmentName;
                    AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    break;
                case 3://上级部门
                    //ToDo...
                    break;
                case 4://下级部门
                    //ToDo...
                    break;
                case 5://上级领导
                    //ToDo...
                    break;
                case 6://下级领导
                    //ToDo...
                    break;
            }
            return true;
        }

        public bool ArchRelation(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string workTaskInstanceId, OperParameter operParam)
        {
            switch (operParam.OperRelation)
            {
                case 1://本部门领导
                    var orgEntity = new PiOrganizeManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetEntity(operParam.OperContent);
                    var uEntity = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString)).GetEntity(orgEntity.ManagerId);
                    operParam.OperContent = uEntity.Id;
                    operParam.OperContenText = uEntity.UserName;
                    AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                    break;
                case 2://无此情况
                    break;
                case 3://上级部门,一个部门只有一个上级部门
                    //ToDo...
                    break;
                case 4://下级部门
                    //ToDo...
                    break;
                case 5://上级部门领导
                    //ToDo...
                    break;
                case 6://下级部门领导
                    //ToDo...
                    break;
            }
            return true;
        }
    }
}
