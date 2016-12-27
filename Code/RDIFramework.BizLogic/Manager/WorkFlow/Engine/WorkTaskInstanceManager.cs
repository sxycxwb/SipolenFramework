using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using Utilities;

    /// <summary>
    /// WorkTaskInstanceManager
    /// 流程任务实例管理器
    /// 
    /// 修改纪录
    /// 
    ///     2016-02-08 版本：3.0 XuWangBin 针对Mysql版本全部把存储过程改写为Sql语句的形式。
    ///     2014-06-03 版本：1.0 XuWangBin 创建。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-08</date>
    /// </author>
    /// </summary>
    public partial class WorkTaskInstanceManager
    {
        /// <summary>
        /// 创建新任务实例
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Create(WorkTaskInstanceEntity entity)
        {
            string returnString = string.Empty;
            try
            {
                returnString = AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnString;
        }

        /// <summary>
        /// 是否存在指定任务实例
        /// </summary>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public bool Exists(string worktaskInsId)
        {
            return Exists(WorkTaskInstanceTable.FieldWorkTaskInsId, worktaskInsId);
        }

        /// <summary>
        /// 设定任务实例正常结束
        /// </summary>
        /// <param name="operatedDes">处理说明</param>
        /// <param name="worktaskInsId">任务实例Id</param>
        /// <returns></returns>
        public int SetWorkTaskInstanceOver(string operatedDes, string worktaskInsId)
        {
            try
            {
                //1、存储过程方式
                /*
                return this.DBProvider.ExecuteProcedure("SetWorkTaskInstanceOverPro", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("OPERATEDDES", operatedDes),
                    DBProvider.MakeParameter("WORKTASKINSID", worktaskInsId)
                }); 
                 */
                //2、语句方式
                string strSql = string.Empty;
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                         strSql = string.Format(@"UPDATE  WORKTASKINSTANCE
                                        SET     STATUS = '3' ,ENDTIME = {0} ,OPERATEDDES = ISNULL(OPERATEDDES, '') + {1}
                                        WHERE   WORKTASKINSID = {2} AND STATUS <> '3'",
                                        DBProvider.GetDBNow(), DBProvider.GetParameter("OPERATEDDES"), DBProvider.GetParameter("WORKTASKINSID"));
                          break;
                    case CurrentDbType.Oracle:
                        strSql = string.Format(@"UPDATE  WORKTASKINSTANCE
                                        SET     STATUS = '3' ,ENDTIME = {0} ,OPERATEDDES = NVL(OPERATEDDES, '') + {1}
                                        WHERE   WORKTASKINSID = {2} AND STATUS <> '3'",
                                        DBProvider.GetDBNow(), DBProvider.GetParameter("OPERATEDDES"), DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                    case CurrentDbType.MySql:
                        strSql = string.Format(@"UPDATE  WORKTASKINSTANCE
                                        SET     STATUS = '3' ,ENDTIME = {0} ,OPERATEDDES = CONCAT(IFNULL(OPERATEDDES, '') , {1})
                                        WHERE   WORKTASKINSID = {2} AND STATUS <> '3'",
                                        DBProvider.GetDBNow(), DBProvider.GetParameter("OPERATEDDES"), DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                }

                return DBProvider.ExecuteNonQuery(strSql, new[] { DBProvider.MakeParameter("OPERATEDDES", operatedDes), DBProvider.MakeParameter("WORKTASKINSID", worktaskInsId) });
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:设置任务实例为完成失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 设定任务实例成功提交信息
        /// </summary>
        /// <param name="successMsg">任务提交成功信息</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public int SetSuccessMsg(string successMsg, string worktaskInsId)
        {
            //string sql = "update WorkTaskInstance set SuccessMsg=@successMsg where WorkTaskInsId=@worktaskInsId";
            return SetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, worktaskInsId, WorkTaskInstanceTable.FieldSuccessMsg, successMsg);
        }

        /// <summary>
        /// 获得任务实例成功提交信息
        /// </summary>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public string GetTaskToWhoMsg(string worktaskInsId)
        {
            try
            {                
                string result = ""; 
                int taskType; 
                string operContentText = "";
                string sql = string.Format("SELECT * FROM WORKTASKINSTANCEVIEW  WHERE PREVIOUSTASKID= {0} " +
                              " AND (OPERSTATUS='0' OR OPERSTATUS IS NULL) ORDER BY OPERTYPE", DBProvider.GetParameter("worktaskInsId"));                
                DataTable dt = Fill(sql, new[] { DBProvider.MakeParameter("worktaskInsId", worktaskInsId) });   
                if (dt != null & dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        taskType = Convert.ToInt16(dt.Rows[i]["TASKTYPEID"].ToString());
                        switch (taskType)
                        {
                            case 6:
                                operContentText = "进入子流程" + ",";
                                break;
                            case 2:
                                operContentText = "流程正常结束" + ",";
                                break;
                            case 4:
                                operContentText = "控制节点" + ",";
                                break;
                            default:
                                operContentText = dt.Rows[i]["OPERCONTENTTEXT"].ToString() + ",";
                                break;
                        }

                        result = result + operContentText;
                    }
                    result = result.TrimEnd(',');
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务被谁处理
        /// </summary>
        /// <param name="worktaskId">任务id</param>
        /// <param name="workflowInsId">流程实例id</param>
        /// <returns></returns>
        public string GetTaskDoneWhoMsg(string worktaskId, string workflowInsId)
        {
            try
            {
                string result = "";
                string sql = string.Format("SELECT DISTINCT WORKFLOWINSID,WORKTASKID,OPERATEDDES,TASKENDTIME FROM WORKTASKINSTANCEVIEW  WHERE WORKTASKID= {0} " +
                             " AND STATUS=3 AND WORKFLOWINSID={1} ORDER BY TASKENDTIME", 
                             DBProvider.GetParameter("worktaskId"), 
                             DBProvider.GetParameter("workflowInsId")); 
                DataTable dt = Fill(sql, new[] { 
                    DBProvider.MakeParameter("worktaskId", worktaskId),
                    DBProvider.MakeParameter("workflowInsId", workflowInsId)
                });   
                if (dt != null & dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        result = result + dt.Rows[i]["OPERATEDDES"].ToString() + "|";
                    }
                    result = result + dt.Rows[dt.Rows.Count - 1]["OPERATEDDES"].ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断任务是否是由当前用户操作
        /// </summary>
        /// <param name="worktaskInsid">任务实例id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public bool WorkTaskpd(string worktaskInsid, string userId)
        {
            try
            {
                string sql = string.Format("SELECT USERID FROM OPERATORINSTANCE WHERE WORKTASKINSID=(SELECT WORKTASKINSID FROM WORKTASKINSTANCE WHERE WORKTASKINSID={0} AND STATUS=2) AND USERID={1}",
                    DBProvider.GetParameter("worktaskInsid"),
                    DBProvider.GetParameter("userId"));
                object returnValue = ExecuteScalar(sql, new[] 
                    { 
                        DBProvider.MakeParameter("worktaskInsid", worktaskInsid),
                        DBProvider.MakeParameter("userId", userId)
                    });

                return returnValue != null && returnValue.ToString().Trim().Length > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务实例提交后返回信息
        /// </summary>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public string GetResultMsg(string worktaskInsId)
        {
            try
            {
                //string sql = "select SuccessMsg from WorkTaskInstance  where worktaskInsId= @worktaskInsId ";
                return GetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, worktaskInsId, WorkTaskInstanceTable.FieldSuccessMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">认领的任务Id</param>
        /// <returns></returns>
        public string WorkTaskClaim(string userId, string operatorInsId)
        {
            try
            { 
                //1、存储过程方式
                /*
                int i = DBProvider.ExecuteProcedure("WorkTaskClaimPro", new[] 
                { 
                    DBProvider.MakeParameter("USERID", userId),
                    DBProvider.MakeParameter("OPERATORINSTANCEID", operatorInsId)
                    
                });

                return (i > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskClaimErrorCode;   
                 */
                //2、语句方式
                //2.1、取得处理的任务实例
                string workTaskInstanceId = new OperatorInstanceManager(DBProvider).GetProperty(OperatorInstanceTable.FieldOperatorInsId,operatorInsId, OperatorInstanceTable.FieldWorkTaskInsId);

                //2.2、检查是否具有认领权限
                string strSql = string.Format(@"SELECT  COUNT(*)
                                                FROM    ( SELECT    OPERCONTENT ,
                                                                    STATUS ,
                                                                    USERID ,
                                                                    OPERATORINSID ,
                                                                    OPERSTATUS
                                                            FROM      WORKTASKINSTANCEVIEW
                                                            WHERE     ( ( OPERCONTENT IN ( SELECT OPERCONTENT
                                                                                            FROM   OPERCONTENTVIEW
                                                                                            WHERE  USERID = {0} ) )
                                                                        OR ( OPERCONTENT = 'All' )
                                                                    )
                                                                    AND ( OPERSTATUS = '0' )
                                                                    AND ( STATUS = '1' )
                                                                    AND OPERATORINSID = {1}
                                                            UNION
                                                            SELECT    OPERCONTENT ,
                                                                    STATUS ,
                                                                    USERID ,
                                                                    OPERATORINSID ,
                                                                    OPERSTATUS
                                                            FROM      WORKTASKINSACCREDITVIEW
                                                            WHERE     ACCREDITTOUSERID = {2}
                                                                    AND ACCREDITSTATUS = '1'
                                                                    AND STATUS = '1'
                                                        ) A", DBProvider.GetParameter("USERID"), DBProvider.GetParameter("OPERATORINSID"), DBProvider.GetParameter("ACCREDITTOUSERID"));
                int jg = BusinessLogic.ConvertToInt(DBProvider.ExecuteScalar(strSql, new[] { DBProvider.MakeParameter("USERID", userId), DBProvider.MakeParameter("OPERATORINSID", operatorInsId), DBProvider.MakeParameter("ACCREDITTOUSERID", userId) }));

                if (jg < 1)
                {
                    throw new Exception("BizLogicError:认领任务失败,请与管理员联系");
                }

                //2.3、设置任务实例被那个处理者认领
                strSql = string.Format(@"UPDATE  WORKTASKINSTANCE
                                        SET     STATUS = 2 ,
                                                OPERATORINSID = {0}
                                        WHERE   WORKTASKINSID = {1}
                                                AND STATUS = '1'", DBProvider.GetParameter("OPERATORINSID"), DBProvider.GetParameter("WORKTASKINSID"));
                int returnValue = DBProvider.ExecuteNonQuery(strSql, new[] { DBProvider.MakeParameter("OPERATORINSID", operatorInsId), DBProvider.MakeParameter("WORKTASKINSID", workTaskInstanceId) });

                //2.4、设置处理者实例已认领
                strSql = string.Format(@"UPDATE  OPERATORINSTANCE
                                        SET     USERID = {0} ,
                                                OPERSTATUS = '3'
                                        WHERE   OPERATORINSID = {1}
                                                AND OPERSTATUS = '0'", DBProvider.GetParameter("USERID"), DBProvider.GetParameter("OPERATORINSID"));
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { DBProvider.MakeParameter("USERID", userId), DBProvider.MakeParameter("OPERATORINSID", operatorInsId) });
                return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskClaimErrorCode;
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:认领任务失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 放弃认领任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">处理者实例Id</param>
        public string WorkTaskUnClaim(string userId, string operatorInsId)
        {
            try
            {
                //1、存储过程方式
                /*
                int i = this.DBProvider.ExecuteProcedure("WorkTaskAbnegatePro", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("OPERATORINSTANCEID", operatorInsId),
                    DBProvider.MakeParameter("USERID", userId)
                });
                return (i > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskUnClaimErrorCode;
                 */
                //2、语句方式
                string workTaskInstanceId; //放弃的任务实例ID
                string strSql = string.Empty;
                //2.1、取得处理的任务实例
                strSql = string.Format(@"SELECT  WORKTASKINSID FROM  OPERATORINSTANCE WHERE OPERATORINSID = {0}", DBProvider.GetParameter("OPERATORINSID"));
                workTaskInstanceId = BusinessLogic.ConvertToString(DBProvider.ExecuteScalar(strSql, new[] { DBProvider.MakeParameter("OPERATORINSID", operatorInsId) }));
                //2.2、设定任务实例为未认领
                strSql = string.Format(@"UPDATE  WORKTASKINSTANCE
                                        SET     STATUS = 1 ,
                                                OPERATORINSID = NULL
                                        WHERE   WORKTASKINSID = {0}
                                                AND STATUS = '2'", DBProvider.GetParameter("WORKTASKINSID"));
                int returnValue = DBProvider.ExecuteNonQuery(strSql, new[] { DBProvider.MakeParameter("WORKTASKINSID", workTaskInstanceId) });
                //2.3、设定处理者实例为未认领
                strSql = string.Format(@"UPDATE  OPERATORINSTANCE
                                        SET     USERID = NULL ,
                                                OPERSTATUS = '0'
                                        WHERE   OPERATORINSID = {0}
                                                AND ( OPERSTATUS = '3'
                                                        OR OPERSTATUS = '2'
                                                    )", DBProvider.GetParameter("OPERATORINSTANCEID"));
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { DBProvider.MakeParameter("OPERATORINSTANCEID", operatorInsId) });
                return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskUnClaimErrorCode;
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:放弃任务失败,请与管理员联系！Error:" + ex.Message);
            }

        }

        /// <summary>
        /// 指派任务
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="assignUserId">指派人的Id</param>
        /// <param name="operatorInsId">处理人实例Id</param>
        /// <returns></returns>
        public string WorkTaskAssign(string userId, string assignUserId, string operatorInsId)
        {
            try
            {
                int i = DBProvider.ExecuteProcedure("WorkTaskAssignPro", new[] 
                { 
                    DBProvider.MakeParameter("ASSIGNUSERID", assignUserId),
                    DBProvider.MakeParameter("OPERATORINSID", operatorInsId),
                    DBProvider.MakeParameter("USERID", userId)
                });
                return (i > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskAssignErrorCode;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 任务退回
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="operatorInsId">退回的处理实例Id</param>
        /// <param name="backyy">退回原因</param>
        /// <returns></returns>
        public string WorkTaskBack(string userId, string operatorInsId, string backyy)
        {
            try
            {
                //1、存储过程方法
                /*
                int i = this.DBProvider.ExecuteProcedure("WorkTaskSubmitBackPro", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("OPERATORINSTANCEID", operatorInsId),
                    DBProvider.MakeParameter("BACKYY", backyy),
                    DBProvider.MakeParameter("USERID", userId)
                });
                return (i > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskAssignErrorCode;
                 */
                //2、直接语句法
                int returnValue = 0;

                //2.1、取得处理的任务实例
                string workTaskInsId = new OperatorInstanceManager(DBProvider).GetProperty(OperatorInstanceTable.FieldOperatorInsId, operatorInsId, OperatorInstanceTable.FieldWorkTaskInsId);
                //2.2、获取前一任务实例
                string previousTaskId = new WorkTaskInstanceManager(DBProvider).GetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, workTaskInsId, WorkTaskInstanceTable.FieldPreviousTaskId);
                string workFlowInsId = new WorkTaskInstanceManager(DBProvider).GetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, workTaskInsId, WorkTaskInstanceTable.FieldWorkFlowInsId);
                //2.3、设定当前任务结束
                //SetWorkTaskInstanceOver(userId, workTaskInsId);
                SetWorkTaskInstanceOver(GetUserRealNameById(userId), workTaskInsId);
                //2.4、设置当前处理者实例结束
                returnValue += new OperatorInstanceManager(DBProvider).SetOperatorInstanceOver(userId, operatorInsId);
                //2.5、
                string strSql = string.Format(@"
                                        INSERT  INTO WORKFLOWBACK(ID,USERID ,OPERATORINSID ,BACKYY , BACKTIME)
                                        VALUES  ({0} ,{1} ,{2} ,{3}, {4} )",
                                        DBProvider.GetParameter("ID"), 
                                        DBProvider.GetParameter("USERID"), 
                                        DBProvider.GetParameter("OPERATORINSID"),
                                        DBProvider.GetParameter("BACKYY"),
                                        DBProvider.GetDBNow());
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { 
                                                                DBProvider.MakeParameter("ID", BusinessLogic.NewGuid()), 
                                                                DBProvider.MakeParameter("USERID", GetUserRealNameById(userId)), 
                                                                DBProvider.MakeParameter("OPERATORINSID", workFlowInsId), 
                                                                DBProvider.MakeParameter("BACKYY", backyy) });
                //2.6、
                strSql = string.Format(@"
                                        INSERT  INTO AUDITMESSAGE
                                                (AUDITID, WORKFLOWINSID ,MESSAGE ,AUDITUSERID ,AUDITUSERNAME ,AUDITRESULT ,AUDITTIME ,AUDITXYB
                                                )
                                        VALUES  ( {0} ,{1} ,{2} ,{3} ,{4} ,{5} ,{6},{7})",
                                        DBProvider.GetParameter("AUDITID"),
                                        DBProvider.GetParameter("WORKFLOWINSID"),
                                        DBProvider.GetParameter("MESSAGE"),
                                        DBProvider.GetParameter("AUDITUSERID"),
                                        DBProvider.GetParameter("AUDITUSERNAME"),
                                        "'退回'",
                                        DBProvider.GetDBNow(),
                                        0);
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { 
                                                                DBProvider.MakeParameter("AUDITID", BusinessLogic.NewGuid()), 
                                                                DBProvider.MakeParameter("WORKFLOWINSID", workFlowInsId), 
                                                                DBProvider.MakeParameter("MESSAGE", backyy) ,
                                                                DBProvider.MakeParameter("AUDITUSERID", userId),
                                                                DBProvider.MakeParameter("AUDITUSERNAME", GetUserRealNameById(userId))});
                //2.7、退回至提交人 此处与WORKFLOWCONST.TASKBACKMSG对应
                //UPDATE  WORKTASKINSTANCE  SET  SUCCESSMSG = '退回至提交人!'   WHERE   WORKTASKINSID = @WORKTASKINSID
                returnValue += SetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, workTaskInsId, WorkTaskInstanceTable.FieldSuccessMsg, "退回至提交人!");

                //2.8、任务状态重置
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        strSql = string.Format(@"
                                        UPDATE  WORKTASKINSTANCE
                                        SET     ENDTIME = {0} ,STATUS = '2' ,REMINDED = '0' ,OPERATEDDES = ISNULL(OPERATEDDES, '') + ',但被[' + {1} + ']退回,'
                                        WHERE   WORKTASKINSID = {2}  AND STATUS = 3",
                                        DBProvider.GetDBNow(),
                                        DBProvider.GetParameter("UserName"),
                                        DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                    case CurrentDbType.Oracle:
                        strSql = string.Format(@"
                                        UPDATE  WORKTASKINSTANCE
                                        SET     ENDTIME = {0} ,STATUS = '2' ,REMINDED = '0' ,OPERATEDDES = NVL(OPERATEDDES, '') + ',但被[' + {1} + ']退回,'
                                        WHERE   WORKTASKINSID = {2}  AND STATUS = 3",
                                        DBProvider.GetDBNow(),
                                        DBProvider.GetParameter("UserName"),
                                        DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                    case CurrentDbType.MySql:                       
                        strSql = string.Format(@"
                                        UPDATE  WORKTASKINSTANCE
                                        SET     ENDTIME = {0} ,STATUS = '2' ,REMINDED = '0' ,OPERATEDDES = CONCAT(IFNULL(OPERATEDDES, '') ,',但被[',{1}, ']退回,')
                                        WHERE   WORKTASKINSID = {2}  AND STATUS = 3",
                                        DBProvider.GetDBNow(),
                                        DBProvider.GetParameter("UserName"),
                                        DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                }

                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { DBProvider.MakeParameter("UserName", GetUserRealNameById(userId))
                                                                        , DBProvider.MakeParameter("WORKTASKINSID", previousTaskId) });
                return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskAssignErrorCode;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex);
                throw new Exception("BizLogicError:任务退回失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 任务任意退回
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="operatorInsId">退回的处理实例Id</param>
        /// <param name="backyy">退回原因</param>
        /// <param name="workflowInsId">上级</param>
        /// <returns></returns>
        public string WorkTaskBackry(string userId, string operatorInsId, string backyy, string workflowInsId)
        {
            try
            {
                //1、存储过程方法
                /*
                int i = this.DBProvider.ExecuteProcedure("WorkTaskSubmitBackProry", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("OPERATORINSTANCEID", operatorInsId),
                    DBProvider.MakeParameter("BACKYY", backyy),
                    DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId),
                    DBProvider.MakeParameter("USERID", userId)
                });
                return (i > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskAssignErrorCode;
                */
                //2、直接语句法
                int returnValue = 0;

                //2.1、取得处理的任务实例
                string workTaskInsId = new OperatorInstanceManager(DBProvider).GetProperty(OperatorInstanceTable.FieldOperatorInsId, operatorInsId, OperatorInstanceTable.FieldWorkTaskInsId);
                //2.2、获取前一任务实例
                string workFlow = new WorkTaskInstanceManager(DBProvider).GetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, workTaskInsId, WorkTaskInstanceTable.FieldWorkFlowInsId);

                //2.3、设定当前任务结束
                //SetWorkTaskInstanceOver(userId, workTaskInsId);
                SetWorkTaskInstanceOver(GetUserRealNameById(userId), workTaskInsId);
                
                //2.4、设置当前处理者实例结束
                returnValue += new OperatorInstanceManager(DBProvider).SetOperatorInstanceOver(userId, operatorInsId);
                //2.5、
                string strSql = string.Format(@"
                                        INSERT  INTO WORKFLOWBACK(ID, USERID ,OPERATORINSID ,BACKYY , BACKTIME)
                                        VALUES  ( {0} ,{1} ,{2} ,{3},{4} )",
                                        DBProvider.GetParameter("ID"), 
                                        DBProvider.GetParameter("USERID"), 
                                        DBProvider.GetParameter("OPERATORINSID"),
                                        DBProvider.GetParameter("BACKYY"),
                                        DBProvider.GetDBNow());
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { 
                                                                DBProvider.MakeParameter("ID", BusinessLogic.NewGuid()), 
                                                                DBProvider.MakeParameter("USERID", GetUserRealNameById(userId)),
                                                                DBProvider.MakeParameter("OPERATORINSID", workFlow), 
                                                                DBProvider.MakeParameter("BACKYY", backyy) });
                //2.6、
                strSql = string.Format(@"
                                        INSERT  INTO AUDITMESSAGE
                                                ( AUDITID,WORKFLOWINSID ,MESSAGE ,AUDITUSERID ,AUDITUSERNAME ,AUDITRESULT ,AUDITTIME ,AUDITXYB)
                                        VALUES  ( {0} ,{1} ,{2} ,{3} ,{4} ,{5} ,{6},{7})",
                                        DBProvider.GetParameter("AUDITID"),
                                        DBProvider.GetParameter("WORKFLOWINSID"),
                                        DBProvider.GetParameter("MESSAGE"),
                                        DBProvider.GetParameter("AUDITUSERID"),
                                        DBProvider.GetParameter("USERID"),
                                        "'任意退回'",
                                        DBProvider.GetDBNow(),
                                        0);
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { 
                                                                DBProvider.MakeParameter("AUDITID", BusinessLogic.NewGuid()), 
                                                                DBProvider.MakeParameter("WORKFLOWINSID", workFlow), 
                                                                DBProvider.MakeParameter("MESSAGE", backyy) ,
                                                                DBProvider.MakeParameter("AUDITUSERID", userId),
                                                                DBProvider.MakeParameter("USERID", GetUserRealNameById(userId))});
                //2.7、退回至提交人 此处与WORKFLOWCONST.TASKBACKMSG对应
                //UPDATE  WORKTASKINSTANCE  SET  SUCCESSMSG = '任意退回至提交人!'   WHERE   WORKTASKINSID = @WORKTASKINSID
                returnValue += SetProperty(WorkTaskInstanceTable.FieldWorkTaskInsId, workTaskInsId, WorkTaskInstanceTable.FieldSuccessMsg, "任意退回至提交人!");

                //2.8、任务状态重置
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        strSql = string.Format(@"
                                        UPDATE  WORKTASKINSTANCE
                                        SET     ENDTIME = {0} ,STATUS = '2' ,REMINDED = '0' ,OPERATEDDES = ISNULL(OPERATEDDES, '') + ',但被[' + {1} + ']任意退回,'
                                        WHERE   WORKTASKINSID = {2}  AND STATUS = 3",
                                        DBProvider.GetDBNow(),
                                        DBProvider.GetParameter("USERID"),
                                        DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                    case CurrentDbType.Oracle:
                        strSql = string.Format(@"
                                        UPDATE  WORKTASKINSTANCE
                                        SET     ENDTIME = {0} ,STATUS = '2' ,REMINDED = '0' ,OPERATEDDES = NVL(OPERATEDDES, '') + ',但被[' + {1} + ']任意退回,'
                                        WHERE   WORKTASKINSID = {2}  AND STATUS = 3",
                                        DBProvider.GetDBNow(),
                                        DBProvider.GetParameter("USERID"),
                                        DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                    case CurrentDbType.MySql:
                        strSql = string.Format(@"
                                        UPDATE  WORKTASKINSTANCE
                                        SET     ENDTIME = {0} ,STATUS = '2' ,REMINDED = '0' ,OPERATEDDES = CONCAT(IFNULL(OPERATEDDES, '') ,',但被[',{1},']任意退回,')
                                        WHERE   WORKTASKINSID = {2}  AND STATUS = 3",
                                        DBProvider.GetDBNow(),
                                        DBProvider.GetParameter("USERID"),
                                        DBProvider.GetParameter("WORKTASKINSID"));
                        break;
                }
                returnValue += DBProvider.ExecuteNonQuery(strSql, new[] { 
                    DBProvider.MakeParameter("USERID", GetUserRealNameById(userId)), 
                    DBProvider.MakeParameter("WORKTASKINSID", workflowInsId) });
                return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.TaskAssignErrorCode;

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex);
                throw new Exception("BizLogicError:任务退回失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        private string GetUserRealNameById(string userId)
        {
            return RDIFrameworkService.Instance.UserService.GetEntity(UserInfo, userId).RealName;
        }

        /// <summary>
        /// 任务撤回
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        public string WorkTaskRevoke(string userId, string workTaskInsId)
        {
            try
            {
                //法1、存储过程方式
                /*
                object returnValue = this.DBProvider.ExecuteScalar("WorkTaskSubmitchehui"
                                                            , new IDbDataParameter[] { 
                                                                    DBProvider.MakeParameter("WORKTASKINSID", workTaskInsId), 
                                                                    DBProvider.MakeParameter("USERID", userId) }
                                                            , CommandType.StoredProcedure);
                return BusinessLogic.ConvertToString(returnValue);
                */
                //法2
                //2.1、查询当前任务的下一步是否未认领
                string sqlQuery = string.Format(@"SELECT WORKTASKINSID FROM OPERATORINSTANCE 
                                                WHERE   WORKTASKINSID IN (
                                                    SELECT  WORKTASKINSID FROM    WORKTASKINSTANCE
                                                    WHERE   WORKTASKINSID != '{0}'
                                                        AND PREVIOUSTASKID = '{0}'
                                                        AND STATUS = 1 )", workTaskInsId);
                DataTable dtTemp = Fill(sqlQuery);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    //2.2、修改OPERATORINSTANCE中后一任务为取消。OPERSTATUS=3
                   string  sqlQuery1 = string.Format(@" UPDATE  OPERATORINSTANCE
                                                        SET     OPERSTATUS = 3 ,
                                                                OPERDATETIME = {0}
                                                        WHERE   WORKTASKINSID IN (
                                                                SELECT  WORKTASKINSID
                                                                FROM    WORKTASKINSTANCE
                                                                WHERE   WORKTASKINSID != '{1}'
                                                                        AND PREVIOUSTASKID = '{1}' )", DBProvider.GetDBNow(), workTaskInsId);

                   //2.3、修改WORKTASKINSTANCE中后一任务为取消。STATUS=3 
                   string sqlQuery2 = string.Format(@"  UPDATE  WORKTASKINSTANCE
                                                        SET     STATUS = 3 ,
                                                                OPERATEDDES = '已被撤回修改' ,
                                                                ENDTIME = {0}
                                                        WHERE   WORKTASKINSID != '{1}'
                                                                AND PREVIOUSTASKID = '{1}'", DBProvider.GetDBNow(), workTaskInsId);
                   //2.4、修改OPERATORINSTANCE中当前任务为已认领-处理人。STATUS=2 
                   string sqlQuery3 = string.Format(@"  UPDATE  OPERATORINSTANCE
                                                        SET     OPERSTATUS = 1
                                                        WHERE   WORKTASKINSID = '{0}'
                                                                AND USERID =  '{1}'",  workTaskInsId,userId);
                   //2.5、修改WORKTASKINSTANCE中当前任务为已认领。STATUS=2 
                   string sqlQuery4 = string.Format(@"  UPDATE  WORKTASKINSTANCE
                                                        SET     STATUS = 2 ,
                                                                OPERATEDDES = ISNULL(OPERATEDDES, '') + ',[撤回修改],'
                                                        WHERE   WORKTASKINSID = '{0}' ", workTaskInsId);
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlQuery4 = string.Format(@"  UPDATE  WORKTASKINSTANCE
                                                        SET     STATUS = 2 ,
                                                                OPERATEDDES = NVL(OPERATEDDES, '') || ',[撤回修改],' 
                                                        WHERE   WORKTASKINSID = '{0}' ", workTaskInsId);
                    }
                    else if (DBProvider.CurrentDbType == CurrentDbType.MySql)
                    {
                        sqlQuery4 = string.Format(@"  UPDATE  WORKTASKINSTANCE
                                                        SET     STATUS = 2 ,
                                                                OPERATEDDES = CONCAT(IFNULL(OPERATEDDES, '') , ',[撤回修改],')
                                                        WHERE   WORKTASKINSID = '{0}' ", workTaskInsId);
                    }
                    DBProvider.ExecuteNonQuery(sqlQuery1);
                    DBProvider.ExecuteNonQuery(sqlQuery2);
                    DBProvider.ExecuteNonQuery(sqlQuery3);
                    DBProvider.ExecuteNonQuery(sqlQuery4);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得任务实例列表
        /// </summary>
        /// <param name="worktaskInsId">任务实例Id</param>
        /// <returns></returns>
        public DataTable GetTaskInsTable(string worktaskInsId)
        {
            try
            {
                string sql = string.Format("SELECT * FROM WORKTASKINSTANCEVIEW WHERE WORKTASKINSID={0}", DBProvider.GetParameter("WorkTaskInsId"));
                return Fill(sql, new[] { DBProvider.MakeParameter("WorkTaskInsId", worktaskInsId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得加签处理人
        /// </summary>
        /// <param name="workflowId">流程模版id</param>
        /// <param name="worktaskId">任务模版id</param>
        /// <param name="workflowInsId">流程实例id</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public DataTable GetTaskInsNextOperTable(string workflowId, string worktaskId, string workflowInsId, string worktaskInsId)
        {
            try
            {
                string sql = string.Format("SELECT * FROM WORKTASKINSNEXTOPER WHERE WORKFLOWID={0} AND WORKTASKID={1}  AND WORKFLOWINSID={2} AND WORKTASKINSID={3}",
                                         DBProvider.GetParameter("workflowId"),
                                         DBProvider.GetParameter("worktaskId"),
                                         DBProvider.GetParameter("workflowInsId"),
                                         DBProvider.GetParameter("worktaskInsId"));
                return Fill(sql, new[] { 
                                        DBProvider.MakeParameter("workflowId", workflowId) ,
                                        DBProvider.MakeParameter("worktaskId", worktaskId) ,
                                        DBProvider.MakeParameter("workflowInsId", workflowInsId) ,
                                        DBProvider.MakeParameter("worktaskInsId", worktaskInsId) ,
                });
            }
            catch (Exception ex)
            {
                throw new Exception("加签处理人错误," + ex.Message.ToString()); ;
            }
        }       
    }
}
