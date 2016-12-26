using System;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public class WorkFlowHelperManager : DbCommonManager
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkFlowHelperManager()
        {           
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public WorkFlowHelperManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public WorkFlowHelperManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public WorkFlowHelperManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }
        #endregion    
        
        #region private string CreateOperInstance(string userId, string oldWorktaskInsId, string oldworktaskId, string workFlowId, string workTaskId,string workFlowInstanceId, string WorkTaskInstanceId, OperParameter operParam) 创建处理者实例
        /// <summary>
        /// 创建处理者实例
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="oldWorktaskInsId"></param>
        /// <param name="oldworktaskId"></param>
        /// <param name="workFlowId"></param>
        /// <param name="workTaskId"></param>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="WorkTaskInstanceId"></param>
        /// <param name="operParam"></param>
        /// <returns></returns>
        private string CreateOperInstance(string userId, string oldWorktaskInsId, string oldworktaskId, string workFlowId, string workTaskId,string workFlowInstanceId, string WorkTaskInstanceId, OperParameter operParam)
        {
            int operType;   //处理类型
            string operContent;//处理者id
            int OperRelation;//处理者关系
            var OperContentText = "";//处理者的名称
            
            //动态指定下一任务处理人
            DataTable tmpDyDt = new WorkTaskInstanceManager(this.DBProvider,this.UserInfo).GetTaskInsNextOperTable(workFlowId, oldworktaskId, workFlowInstanceId, oldWorktaskInsId);
            foreach (DataRow dr in tmpDyDt.Rows)
            {
                operContent = dr[WorkTaskInsNextOperTable.FieldUserId].ToString();
                if (string.IsNullOrEmpty(operContent)) continue;
                var userName = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString),this.UserInfo).GetEntity(operContent).RealName;
                operParam.OperContent = operContent;
                operParam.OperContenText = userName;
                operParam.OperRelation = 0;
                operParam.OperType = 3;
                new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
            }

            DataTable tmpTeDt = new WorkTaskManager(this.DBProvider, this.UserInfo).GetTaskOperator(workFlowId, workTaskId);
            //如果没有处理者
            if ((tmpTeDt == null || tmpTeDt.Rows.Count <= 0) && (tmpDyDt.Rows.Count <= 0))
            {
                return WorkFlowConst.NoFoundOperatorCode;
            }

            foreach (DataRow dr in tmpTeDt.Rows)
            {
                operType = System.Convert.ToInt16(dr[OperatorTable.FieldOperType].ToString());
                operContent = dr[OperatorTable.FieldOperContent].ToString();
                OperRelation = Convert.ToInt16(dr[OperatorTable.FieldRelation]);
                OperContentText = dr[OperatorTable.FieldOperDisplay].ToString();
                operParam.OperType = operType;
                operParam.OperContent = operContent;
                operParam.OperRelation = OperRelation;
                operParam.OperContenText = OperContentText;
                switch (operType)
                {   //在此函数中加入处理者策略
                    case 1://流程启动者
                        var startflowUser = new InstanceTypeManager(this.DBProvider, this.UserInfo).GetStartWorkflowUser(workFlowInstanceId);
                        var startflowUserName = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString), this.UserInfo).GetEntity(startflowUser).UserName;
                        operParam.OperContent = startflowUser;
                        operParam.OperContenText = startflowUserName;
                        if (OperRelation == 0)//无处理这关系
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 2://某一任务实际处理者
                        var dtTaskUser = new InstanceTypeManager(this.DBProvider, this.UserInfo).GetTaskInstanceUser(workFlowInstanceId, operContent);
                        foreach (DataRow drUser in dtTaskUser.Rows)
                        {
                            var rlUserId = drUser["USERID"].ToString();
                            var rlUserName = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString), this.UserInfo).GetEntity(rlUserId).RealName;
                            operParam.OperContent = rlUserId;
                            operParam.OperContenText = rlUserName;
                            if (OperRelation == 0)//无处理这关系
                                new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            else
                                new InstanceTypeManager(this.DBProvider, this.UserInfo).UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        }
                        break;
                    case 3://指定人员
                        if (OperRelation == 0)
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 4://部门
                        if (OperRelation == 0)
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).ArchRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 5://角色
                        new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignGroup(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 6://岗位
                        new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 7://从变量中获取
                        var varUser = GetWorkTaskVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, OperContentText);
                        if (varUser.Length > 2)
                        {
                            varUser = varUser.Substring(1, varUser.Length - 2);

                            var varUserName = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString), this.UserInfo).GetEntity(varUser).UserName;
                            if (string.IsNullOrEmpty(varUserName) || varUserName == "'")
                            {
                                return WorkFlowConst.IsNullUserIdCode;//如果用户取不到就报错
                            }
                            operParam.OperContent = varUser;
                            operParam.OperContenText = varUserName;
                        }
                        else
                        {
                            return WorkFlowConst.IsNullUserIdCode;//如果用户取不到就报错
                        }
                        if (OperRelation == 0)//无处理者关系
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            new InstanceTypeManager(this.DBProvider, this.UserInfo).UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        break;
                    case 8://某一任务选择的处理者
                        throw new Exception("无此类型");
                        break;
                    case 9://所有人
                        new InstanceTypeManager(this.DBProvider, this.UserInfo).AssignAll(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 10://指派
                        throw new Exception("无此类型");
                        break;
                    case 11://授权
                        throw new Exception("无此类型");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            return WorkFlowConst.SuccessCode;
        }
        #endregion

        #region private string GetExpressResult(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string condition) 得到表达式结果
        /// <summary>
        /// 得到表达式结果
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">任务模版Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        private string GetExpressResult(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string condition)
        {
            var varName = "";//变量名<%当前用户%>
            var varValue = "";
            var expressText = "";//解析前表达式
            var len = 0;//表达式长度
            char firstchar;
            char secendchar;
            var startVar = '2';//0开始取变量的，1 取变量结束，2空闲
            expressText = condition;//解析前表达式
            len = expressText.Length;
            if (expressText.Trim().Length == 0) { expressText = "1=1"; }//无条件
            else
                for (var i = 0; i < len - 1; i++)
                {

                    firstchar = expressText[i];
                    secendchar = i + 1 < len ? expressText[i + 1] : firstchar;

                    if (firstchar == '<' && secendchar == '%') startVar = '0';
                    else
                        if (firstchar == '%' && secendchar == '>') startVar = '1';

                    switch (startVar)
                    {
                        case '0':
                            varName = varName + firstchar;
                            break;
                        case '1':
                        {
                            var varflag = "";
                            varName = varName + firstchar + secendchar;
                            if (varName.Length >= 6)
                            {
                                varflag = varName.Substring(2, 4);
                            }
                            varValue = varflag == WorkFlowConst.SYS_VarFlag 
                                                ? getSysVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, varName) 
                                                : GetWorkTaskVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, varName);
                            expressText = expressText.Replace(varName, varValue);
                            return GetExpressResult(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, expressText);
                        }
                    }
                }
            return expressText;

        }
        #endregion

        #region private bool ExpressPass(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string condition) 返回一个表达式的值
        /// <summary>
        /// 返回一个表达式的值
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">任务模版Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="condition">表达式</param>
        /// <returns></returns>
        private bool ExpressPass(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string condition)
        {
            try
            {
                var expressText = GetExpressResult(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, condition);
                //WriteErrorLog("条件"+condition+":" + expressText, workFlowInstanceId);
                var sqlStr = "";
                if (this.DBProvider.CurrentDbType == CurrentDbType.Oracle || this.DBProvider.CurrentDbType == CurrentDbType.MySql)
                {
                    sqlStr = "select 1 from dual where " + expressText;
                }
                else
                {
                    sqlStr = "select 1 where " + expressText;
                }
                //LogHelper.WriteLog(sqlStr);
                var dtTemp = this.DBProvider.Fill(sqlStr);
                return dtTemp != null && dtTemp.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                //WriteErrorLog(string.Format(WorkFlowConst.ExpressErrorMsg, condition, ex.Message), workFlowInstanceId);
                throw new Exception(string.Format(WorkFlowConst.ExpressErrorMsg, condition, ex.Message));
            }
        }
        #endregion

        #region private string getSysVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string varName) 取系统变量值
        /// <summary>
        /// 取系统变量值
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="workFlowId"></param>
        /// <param name="workTaskId"></param>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="WorkTaskInstanceId"></param>
        /// <param name="varName"></param>
        /// <returns></returns>
        private string getSysVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string varName)
        {
            var result = "";
            return result;
        }
        #endregion

        #region private string GetWorkTaskVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string varName) 取流程变量或者任务变量值，两者的变量名不能重复
        /// <summary>
        /// 取流程变量或者任务变量值，两者的变量名不能重复
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">任务模版Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="varName">变量名称</param>
        /// <returns></returns>
        private string GetWorkTaskVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string varName)
        {
            var varDataBase = "";
            var varTableName = "";
            var varFieldName = "";
            var varInitValue = "";
            var varAccessType = "";//变量类型
            var varType = "";
            var varSql = "";
            var resultValue = "";
            var tmpVarName = "";
            var paixu = "";//排序
            tmpVarName = varName.Substring(2, varName.Length - 4);//去掉两头的<%%>
            var dt = new TaskVarManager(this.DBProvider, this.UserInfo).GetTaskVarByName(workFlowId, tmpVarName);
            if (dt != null && dt.Rows.Count > 0)
            {
                varDataBase = dt.Rows[0][TaskVarTable.FieldDataBaseName].ToString();
                varTableName = dt.Rows[0][TaskVarTable.FieldTableName].ToString();
                varFieldName = dt.Rows[0][TaskVarTable.FieldTableField].ToString();
                varInitValue = dt.Rows[0][TaskVarTable.FieldInitValue].ToString();
                varAccessType = dt.Rows[0][TaskVarTable.FieldAccessType].ToString();
                varType = dt.Rows[0][TaskVarTable.FieldVarType].ToString();
                paixu = dt.Rows[0][TaskVarTable.FieldSortField].ToString();
            }
            switch (varAccessType)
            {
                case WorkFlowConst.Access_WorkFlow:
                    varSql = string.Format("SELECT " + varFieldName + " FROM " + varTableName + " WHERE WORKFLOWID={0} AND WORKFLOWINSID={1}",
                        DBProvider.GetParameter("workflowId"),
                        DBProvider.GetParameter("workFlowInstanceId"));
                    if (paixu != "" && paixu != "请选择...")
                    {
                        varSql = varSql + " ORDER BY " + paixu + " DESC";
                    }

                    resultValue=BusinessLogic.ConvertToString(
                        this.DBProvider.ExecuteScalar(varSql, new IDbDataParameter[] { 
                            DBProvider.MakeParameter("workflowId", workFlowId),
                            DBProvider.MakeParameter("workFlowInstanceId", workFlowInstanceId)
                        }));
                    
                    if (varType == "string")
                    {
                        resultValue = "'" + resultValue + "'";
                    }
                    break;
                case WorkFlowConst.Access_WorkTask:
                    varSql = string.Format("SELECT " + varFieldName + " FROM " + varTableName + " WHERE WORKFLOWID={0} AND WORKFLOWINSID={1} " +
                             " AND WORKTASKINSID={2} ",
                             DBProvider.GetParameter("workflowId"),
                             DBProvider.GetParameter("workFlowInstanceId"),
                             DBProvider.GetParameter("WorkTaskInsId"));
                    if (paixu != "" && paixu != "请选择...")
                    {
                        varSql = varSql + " ORDER BY " + paixu + " DESC";
                    }
                    resultValue = BusinessLogic.ConvertToString(
                        this.DBProvider.ExecuteScalar(varSql, new IDbDataParameter[] { 
                            DBProvider.MakeParameter("workflowId", workFlowId),
                            DBProvider.MakeParameter("workFlowInstanceId", workFlowInstanceId),
                            DBProvider.MakeParameter("WorkTaskInsId", WorkTaskInstanceId)
                        }));
                    if (varType == "string")
                    {
                        resultValue = "'" + resultValue + "'";
                    }
                    break;
            }

            if (string.IsNullOrEmpty(resultValue)) resultValue = varInitValue;
            //if (varType == WorkFlowConst.SYSVarType_string) resultValue = "'" + resultValue + "'";//字符型要加单引号
            //if (string.IsNullOrEmpty(resultValue)) resultValue = "'" + resultValue + "'";//默认返回带引号的空字符串
            return resultValue;
        }
        #endregion

        #region private DataTable GetLineEndTasks(string workFlowId, string workTaskId, string commandName) 取得连线末端的任务列表table
        /// <summary>
        ///  取得连线末端的任务列表table
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">起始端任务模板Id</param>
        /// <param name="commandName">所属命令</param>
        /// <returns></returns>
        private DataTable GetLineEndTasks(string workFlowId, string workTaskId, string commandName)
        {
            try
            {
                string sqlStr = string.Format("SELECT * FROM WORKTASKLINKVIEW  WHERE COMMANDNAME={0} AND STARTTASKID={1} AND WORKFLOWID={2} ORDER BY PRIORITY",
                                      DBProvider.GetParameter("CommandName"),
                                      DBProvider.GetParameter("WorkflowTaskId"),
                                      DBProvider.GetParameter("WorkFlowId"));
                return this.DBProvider.Fill(sqlStr, new IDbDataParameter[] { 
                    DBProvider.MakeParameter("CommandName", commandName),
                    DBProvider.MakeParameter("WorkflowTaskId", workTaskId),
                    DBProvider.MakeParameter("WorkFlowId", workFlowId)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region private DataTable GetLineStartTasks(string workFlowId, string workTaskId) 取得连线前端的任务列表table
        /// <summary>
        /// 取得连线前端的任务列表table
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">末端任务模板Id</param>
        /// <returns></returns>
        private DataTable GetLineStartTasks(string workFlowId, string workTaskId)
        {
            try
            {
                string sqlStr = string.Format("SELECT * FROM WORKTASKLINKVIEW  WHERE  ENDTASKID={0} AND WORKFLOWID={1} ORDER BY PRIORITY",
                                DBProvider.GetParameter("workTaskId"),
                                DBProvider.GetParameter("WorkFlowId"));
                return this.DBProvider.Fill(sqlStr, new IDbDataParameter[] { 
                    DBProvider.MakeParameter("workTaskId", workTaskId),
                    DBProvider.MakeParameter("WorkFlowId", workFlowId)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public string CreateNextTaskInstance(string userId, string workFlowId, string workTaskId,string workFlowInstanceId, string workTaskInstanceId, string operatorInstanceId, string commandName) 创建所有符合条件的任务实例
        /// <summary>
        /// 创建所有符合条件的任务实例
        /// </summary>
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
        public string CreateNextTaskInstance(string userId, string workFlowId, string workTaskId,string workFlowInstanceId, string workTaskInstanceId, string operatorInstanceId, string commandName)
        {
            var userName = new PiUserManager(DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString),this.UserInfo).GetEntity(userId).UserName;
            
            var dt = GetLineEndTasks(workFlowId, workTaskId, commandName);
            if (dt != null && dt.Rows.Count > 0)
            {
                var condition = "";//条件
                var priority = "";//优先级，只执行优先级最高的分支，如果优先级相同 那么同时执行。
                var endTaskId = "";//后续任务节点Id
                var endoperRule = "";//新任务处理者策略
                var startoperRule = "";//当前任务处理者策略  
                var taskType = "";//节点类型
                var endTaskTypeAndOr = "";//控制节点专用，表示and/or
                var operParam = new OperParameter();//创建处理者参数

                #region 配置了后续节点
                var l = dt.Rows.Count;
                var branchPriority = dt.Rows[0]["PRIORITY"].ToString();//优先级
                //遍历满足条件的所有任务节点
                for (var i = 0; i < l; i++)
                {
                    var dr = dt.Rows[i];
                    condition = dr["CONDITION"].ToString();
                    priority = dr["PRIORITY"].ToString();
                    endTaskId = dr["ENDTASKID"].ToString();
                    endoperRule = dr["ENDOPERRULE"].ToString();
                    startoperRule = dr["STARTOPERRULE"].ToString();
                    taskType = dr["ENDTASKTYPEID"].ToString();
                    endTaskTypeAndOr = dr["ENDTASKTYPEANDOR"].ToString();
                    operParam.OperRule = endoperRule;
                    operParam.IsJumpSelf = Convert.ToBoolean(dr["ISJUMPSELF"]);
                    if (priority != branchPriority) break;//只执行优先级最高的分支
                    if (ExpressPass(userId, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, condition))//满足条件的任务节点
                    {
                        switch (taskType)
                        {
                            case "2"://结束节点
                                {
                                    #region 结束节点
                                    //产生一个结束节点的实例
                                    var newEndTaskId = BusinessLogic.NewGuid();//新任务处理者实例Id
                                    var endWorktaskIns = new WorkTaskInstanceEntity
                                    { 
                                        WorkFlowId = workFlowId,
                                        WorkTaskId = endTaskId,
                                        WorkFlowInsId = workFlowInstanceId,
                                        WorkTaskInsId = newEndTaskId,
                                        PreviousTaskId = workTaskInstanceId,
                                        TaskInsCaption = new WorkTaskManager(this.DBProvider, this.UserInfo).GetTaskCaption(endTaskId),
                                        Status = "2"//结束节点不需要再处理,但此处不能为3,设置结束实例会修改该值=3
                                    };
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).Create(endWorktaskIns);                                    
                                    
                                    //设置处理者实例正常结束
                                    new OperatorInstanceManager(this.DBProvider, this.UserInfo).SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetWorkTaskInstanceOver(userName, workTaskInstanceId);
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetWorkTaskInstanceOver(userName, newEndTaskId);//结束节点实例 结束
                                    //设置流程实例正常结束
                                    new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).SetWorkflowInstanceOver(workFlowInstanceId);
                                    //设定流程实例的当前位置
                                    new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetSuccessMsg(WorkFlowConst.WorkflowOverMsg, workTaskInstanceId);//结束节点单独处理,任务提交给谁了
                                    //检查是否子流程调用
                                    DataTable operInfo = new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).GetWorkflowInstance(workFlowInstanceId);
                                    if (operInfo != null && operInfo.Rows.Count > 0)
                                    {
                                        var isSubWorkflow = false;//是否是子流程调用
                                        var mainWorkflowInsId = "";
                                        var mainWorktaskId = "";
                                        var mainWorkflowId = "";
                                        var mainWorktaskInsId = "";
                                        isSubWorkflow = BusinessLogic.ConvertIntToBoolean(operInfo.Rows[0][WorkFlowInstanceTable.FieldIsSubWorkflow]);
                                        mainWorkflowInsId = operInfo.Rows[0][WorkFlowInstanceTable.FieldMainWorkflowInsId].ToString();//主流程实例Id
                                        mainWorktaskId = operInfo.Rows[0][WorkFlowInstanceTable.FieldMainWorktaskId].ToString();//子流程节点模板Id
                                        mainWorkflowId = operInfo.Rows[0][WorkFlowInstanceTable.FieldMainWorkflowId].ToString();//主流程模板Id
                                        mainWorktaskInsId = operInfo.Rows[0][WorkFlowInstanceTable.FieldMainWorktaskInsId].ToString();//主任务实例Id，进入子节点前的任务节点实例
                                        if (isSubWorkflow)
                                        {
                                            //创建一个子流程节点实例痕迹，表示子流程节点处理完成
                                            var newTaskId = BusinessLogic.NewGuid();//新任务处理者实例Id
                                            var workTaskInstance = new WorkTaskInstanceEntity { 
                                                WorkFlowId = mainWorkflowId,
                                                WorkTaskId = mainWorktaskId,
                                                WorkFlowInsId = mainWorkflowInsId,
                                                WorkTaskInsId = newTaskId,
                                                PreviousTaskId = mainWorktaskInsId,
                                                TaskInsCaption = "子流程",
                                                Status = "3"
                                            };
                                            new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).Create(workTaskInstance);                                           
                                            var result = CreateNextTaskInstance(userId, mainWorkflowId, mainWorktaskId, mainWorkflowInsId, newTaskId, operatorInstanceId, "提交");
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                    }
                                    #endregion
                                    break;
                                }
                            case "3":
                                {
                                    #region 交互节点
                                    switch (endoperRule)
                                    {
                                        case "1":
                                        {
                                            //创建一个任务实例
                                            var newTaskId = BusinessLogic.NewGuid();//新任务处理者实例Id
                                            var workTaskInstance = new WorkTaskInstanceEntity
                                            { 
                                                WorkFlowId = workFlowId,
                                                WorkTaskId = endTaskId,
                                                WorkFlowInsId = workFlowInstanceId,
                                                WorkTaskInsId = newTaskId,
                                                PreviousTaskId = workTaskInstanceId,
                                                TaskInsCaption = new WorkTaskManager(this.DBProvider, this.UserInfo).GetTaskCaption(endTaskId),
                                                Status = "1"
                                            };
                                            new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).Create(workTaskInstance);
                                            //创建多个处理人
                                            var result = CreateOperInstance(userId, workTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, operParam);//创建处理者实例
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                        break;
                                        case "2":
                                        {
                                            //创建任务实例和处理人
                                            var result = CreateOperInstance(userId, workTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                        break;
                                    }
                                    
                                    //设置处理者实例正常结束
                                    new OperatorInstanceManager(this.DBProvider, this.UserInfo).SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetWorkTaskInstanceOver(userName, workTaskInstanceId);
                                    //设定流程实例的当前位置
                                    new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //设定任务实例成功提交信息
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetSuccessMsg(WorkFlowConst.SuccessMsg, workTaskInstanceId);
                                    #endregion
                                    break;
                                }
                            case "4"://控制节点
                                {
                                    #region 控制节点
                                    //设置处理者实例正常结束
                                    new OperatorInstanceManager(this.DBProvider, this.UserInfo).SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetWorkTaskInstanceOver(userName, workTaskInstanceId);
                                    //设定流程实例的当前位置
                                    new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //设定任务实例成功提交信息
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetSuccessMsg(WorkFlowConst.SuccessMsg, workTaskInstanceId);
                                    //******start检查判断节点前面的所以节点的任务实例是否都完成


                                    //取控制节点前端所以节点,进行逐个判断
                                    var dtstart = GetLineStartTasks(workFlowId, endTaskId);
                                    var allPass = true;//全部通过
                                    foreach (DataRow dr1 in dtstart.Rows)
                                    {
                                        var taskId = dr1["STARTTASKID"].ToString();
                                        if (endTaskTypeAndOr == WorkConst.Command_Or)//or分支
                                        {
                                            if (IsPassJudge(workFlowId, workFlowInstanceId, taskId, endTaskTypeAndOr))//判断每个节点实例是否完成
                                            {
                                                allPass = true;
                                                break;//如果有一个通过即可。
                                            }
                                            allPass = false;
                                        }
                                        else//and分支
                                        {
                                            if (!IsPassJudge(workFlowId, workFlowInstanceId, taskId, endTaskTypeAndOr))//判断每个节点实例是否完成
                                            {
                                                allPass = false;
                                                break;//如果有一个未完成的，不产生新的实例，流程等待。
                                            }
                                        }
                                    }

                                    //********end检查判断节点前面的所以节点的任务实例结束

                                    //如果判断节点前面的流程实例全部完成，自动进行递归，创建下一任务实例。
                                    if (allPass)
                                    {
                                        //创建一个判断节点实例
                                        var newTaskId = BusinessLogic.NewGuid();//新任务处理者实例Id
                                        var workTaskInstance = new WorkTaskInstanceEntity
                                        {
                                            WorkFlowId = workFlowId,
                                            WorkTaskId = endTaskId,
                                            WorkFlowInsId = workFlowInstanceId,
                                            WorkTaskInsId = newTaskId,
                                            PreviousTaskId = workTaskInstanceId,
                                            TaskInsCaption = endTaskTypeAndOr,
                                            Status = "3"
                                        };
                                        new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).Create(workTaskInstance);
                                        var result = CreateNextTaskInstance(userId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, operatorInstanceId, "提交");
                                        if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    #endregion
                                    break;
                                }
                            case "5"://查看节点
                                {
                                    #region 查看节点
                                    switch (endoperRule)
                                    {
                                        case "1":
                                        {
                                            //创建一个任务实例
                                            var newTaskId = BusinessLogic.NewGuid();//新任务处理者实例Id
                                            var workTaskInstance = new WorkTaskInstanceEntity
                                            {
                                                WorkFlowId = workFlowId,
                                                WorkTaskId = endTaskId,
                                                WorkFlowInsId = workFlowInstanceId,
                                                WorkTaskInsId = newTaskId,
                                                PreviousTaskId = workTaskInstanceId,
                                                TaskInsCaption = new WorkTaskManager(this.DBProvider, this.UserInfo).GetTaskCaption(endTaskId),
                                                Status = "1"
                                            };
                                            new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).Create(workTaskInstance);

                                            //创建多个处理人
                                            var result = CreateOperInstance(userId, workTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, operParam);//创建任务实例
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                            break;
                                        case "2":
                                        {
                                            //创建任务实例和处理人

                                            var result = CreateOperInstance(userId, workTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, workTaskInstanceId, operParam);
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                            break;
                                    }
                                    //设置处理者实例正常结束
                                    new OperatorInstanceManager(this.DBProvider, this.UserInfo).SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetWorkTaskInstanceOver(userName, workTaskInstanceId);
                                    //设定流程实例的当前位置
                                    new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //设定任务实例成功提交信息
                                    new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetSuccessMsg(WorkFlowConst.SuccessMsg, workTaskInstanceId);
                                    #endregion
                                    break;
                                }
                            case "6"://子流程节点
                                {
                                    #region 子流程节点
                                    var subWf = new SubWorkFlowManager(this.DBProvider, this.UserInfo).GetSubWorkflowTable(workFlowId, endTaskId);
                                    if (subWf != null && subWf.Rows.Count > 0)
                                    {
                                        var subWorkflowId = subWf.Rows[0][SubWorkFlowTable.FieldSubWorkFlowId].ToString();
                                        var subStartTaskId = subWf.Rows[0][SubWorkFlowTable.FieldSubStartTaskId].ToString();
                                        var subWorkflowCaption = subWf.Rows[0][SubWorkFlowTable.FieldSubWorkFlowCaption].ToString();
                                        //*******进入子流程
                                        var wfruntime = new WorkFlowRuntime
                                        {
                                            UserId = userId,
                                            WorkFlowId = subWorkflowId,
                                            WorkTaskId = subStartTaskId,
                                            WorkFlowInstanceId = BusinessLogic.NewGuid(),
                                            WorkTaskInstanceId = BusinessLogic.NewGuid(),
                                            IsSubWorkflow = true,
                                            MainWorkflowId = workFlowId,
                                            MainWorkflowInsId = workFlowInstanceId,
                                            MainWorktaskId = endTaskId,
                                            MainWorktaskInsId = workTaskInstanceId,//记录进入子流程之前的任务实例
                                            WorkFlowNo = "subWorkflow",
                                            CommandName = "提交",
                                            WorkflowInsCaption = subWorkflowCaption,
                                            IsDraft = true//开始节点需要交互，草稿状态，暂不提交
                                        };
                                        wfruntime.Start();
                                        //设置处理者实例正常结束
                                        new OperatorInstanceManager(this.DBProvider, this.UserInfo).SetOperatorInstanceOver(userId, operatorInstanceId);
                                        //设置任务实例正常结束
                                        new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetWorkTaskInstanceOver(userName, workTaskInstanceId);
                                        //设定流程实例的当前位置
                                        new WorkFlowInstanceManager(this.DBProvider, this.UserInfo).SetCurrTaskId(workFlowInstanceId, endTaskId);
                                        //设定任务实例成功提交信息
                                        new WorkTaskInstanceManager(this.DBProvider, this.UserInfo).SetSuccessMsg(WorkFlowConst.SuccessMsg, workTaskInstanceId);
                                    }
                                    #endregion
                                    break;
                                }
                        }
                    }
                }
                #endregion
            }
            else
            {   //未配置后续节点
                return WorkFlowConst.NoFoundTaskCode;
            }
            return WorkFlowConst.SuccessCode;
        }
        #endregion

        #region public bool IsPassJudge(string workFlowId, string workFlowInstanceId, string judgeTaskId, string taskTypeAndOr) 判断节点实例是否都完成
        /// <summary>
        /// 判断节点实例是否都完成
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workFlowInstanceId">工作流实例Id</param>
        /// <param name="judgeTaskId">待判断力的节点Id</param>
        /// <param name="taskTypeAndOr">节点类型：and、or</param>
        /// <returns></returns>
        public bool IsPassJudge(string workFlowId, string workFlowInstanceId, string judgeTaskId, string taskTypeAndOr)
        {
            var result = true;
            try
            {
                if (taskTypeAndOr == WorkConst.Command_And)//and 分支
                {
                    string sql = string.Format("SELECT * FROM WORKTASKINSTANCE WHERE WORKFLOWINSID={0} AND WORKTASKID={1}",
                                DBProvider.GetParameter("WorkFlowId"),
                                DBProvider.GetParameter("workTaskId"));      
                    var dt = this.DBProvider.Fill(sql, new IDbDataParameter[] { 
                        DBProvider.MakeParameter("WorkFlowId", workFlowInstanceId),
                        DBProvider.MakeParameter("workTaskId", judgeTaskId)
                    });   

                    if (dt == null || dt.Rows.Count == 0) result = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Status"].ToString() != "3")
                        { 
                            result = false; 
                            break; 
                        }
                    }
                }
                else//or分支
                {
                    var sql = string.Format("SELECT * FROM WORKTASKINSTANCE WHERE WORKFLOWINSID={0} AND WORKTASKID={1}",
                                            DBProvider.GetParameter("workFlowInstanceId"),
                                            DBProvider.GetParameter("judgeTaskId"));
                    var dt = this.DBProvider.Fill(sql, new IDbDataParameter[] { 
                        DBProvider.MakeParameter("workFlowInstanceId", workFlowInstanceId),
                        DBProvider.MakeParameter("judgeTaskId", judgeTaskId)
                    });   

                    if (dt == null || dt.Rows.Count == 0) result = false;
                    if (dt.Rows.Cast<DataRow>().Any(dr => dr["STATUS"].ToString() == "3"))
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public bool IsTaskInsCompleted(string worktaskInsId) 判断任务实例是否已完成,以此来判断避免重复提交
        /// <summary>
        /// 判断任务实例是否已完成,以此来判断避免重复提交
        /// </summary>
        /// <param name="worktaskInsId">任务实例Id</param>
        /// <returns></returns>
        public bool IsTaskInsCompleted(string worktaskInsId)
        {
            string sql = string.Format("SELECT * FROM WORKTASKINSTANCE WHERE WORKTASKINSID={0} AND STATUS='3'", DBProvider.GetParameter("worktaskInsId"));
            var dt = this.DBProvider.Fill(sql, new IDbDataParameter[] { 
                DBProvider.MakeParameter("worktaskInsId", worktaskInsId)
            });   
            return dt != null && dt.Rows.Count > 0;
        }
        #endregion
    }
}
