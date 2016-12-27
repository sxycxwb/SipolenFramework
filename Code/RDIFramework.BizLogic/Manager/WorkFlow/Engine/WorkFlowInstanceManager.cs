using System;
using System.Data;
using System.Text;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowInstanceManager
    /// 工作流实例管理器
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-07</date>
    /// </author>
    /// </summary>
    public partial class WorkFlowInstanceManager
    {
        /// <summary>
        /// 创建工作流实例
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public string Create(WorkFlowInstanceEntity entity)
        {
            string returnStr = string.Empty;
            try
            {
                returnStr = this.AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }

        ///// <summary>
        ///// 可启动的流程
        ///// </summary>
        ///// <param name="userId">用户Id</param>
        ///// <returns>可启动的流程列表</returns>
        //public DataTable StartWorkflow(string userId)
        //{
        //    try
        //    {
        //        
        //        sqlItem.CommandText = "WorkTaskSelectStartPro";
        //        sqlItem.CommandType = CommandType.StoredProcedure.ToString();
        //        sqlItem.AppendParameter("@userId", userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 待办任务，包括新任务和已认领任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>返回待办任务列表</returns>
        public DataTable GetToDoWorkTasks(string userId, int topsize)
        {
            DataTable dtToDoTask = new DataTable(WorkTaskTable.TableName);
            try
            {
                //1、存储过程的方式
                //return DBProvider.ExecuteProcedureForDataTable("WorkFlowToDoTasks", SubWorkFlowTable.TableName, new IDbDataParameter[] { 
                //        DBProvider.MakeParameter("USERID", userId),
                //        DBProvider.MakeParameter("TOPSIZE", topsize)
                //    });  
                //2、语句方式
                string sqlQuery = string.Empty;
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = string.Format(@"SELECT TOP {0} * FROM 
                                                (   SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION  
	                                                FROM WORKTASKINSTANCEVIEW  
	                                                WHERE  ((OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW  WHERE USERID='{1}') ) OR  (OPERCONTENT = 'ALL')) AND  (OPERSTATUS='0') AND (STATUS='1') 
		
	                                                UNION   
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSACCREDITVIEW 
	                                                WHERE  ACCREDITTOUSERID='{1}' AND ACCREDITSTATUS='1'AND STATUS='1'
	
	                                                UNION  
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSTANCEVIEW 
	                                                WHERE USERID='{1}' AND (STATUS='1' OR STATUS='2')) A   
                                            ORDER BY STATUS, TASKSTARTTIME DESC", topsize, userId);
                        break;
                    case CurrentDbType.Oracle:
                        sqlQuery = string.Format(@"SELECT * FROM 
                                                (   SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION  
	                                                FROM WORKTASKINSTANCEVIEW  
	                                                WHERE  ((OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW  WHERE USERID='{0}') ) OR  (OPERCONTENT = 'ALL')) AND  (OPERSTATUS='0') AND (STATUS='1') 
		
	                                                UNION   
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSACCREDITVIEW 
	                                                WHERE  ACCREDITTOUSERID='{0}' AND ACCREDITSTATUS='1'AND STATUS='1'
	
	                                                UNION  
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSTANCEVIEW 
	                                                WHERE USERID='{0}' AND (STATUS='1' OR STATUS='2')) A 
                                            WHERE ROWNUM <= {1}
                                            ORDER BY STATUS, TASKSTARTTIME DESC", userId, topsize);
                        break;
                    case CurrentDbType.MySql:
                        sqlQuery = string.Format(@"SELECT * FROM 
                                                (   SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION  
	                                                FROM WORKTASKINSTANCEVIEW  
	                                                WHERE  ((OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW  WHERE USERID='{0}') ) OR  (OPERCONTENT = 'ALL')) AND  (OPERSTATUS='0') AND (STATUS='1') 
		
	                                                UNION   
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSACCREDITVIEW 
	                                                WHERE  ACCREDITTOUSERID='{0}' AND ACCREDITSTATUS='1'AND STATUS='1'
	
	                                                UNION  
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSTANCEVIEW 
	                                                WHERE USERID='{0}' AND (STATUS='1' OR STATUS='2')) A   
                                            ORDER BY STATUS, TASKSTARTTIME DESC limit {1}", userId, topsize);
                        break;
                }
                

                dtToDoTask = this.Fill(sqlQuery);
                return dtToDoTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 未认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>未认领的任务列表</returns>
        public DataTable ClaimWorkTask(string userId, int topsize)
        {
            DataTable dtClamimWorkTask = new DataTable(WorkTaskTable.TableName);

            try
            {
                //1、存储过程的方式
                //return this.DBProvider.ExecuteProcedureForDataTable("WorkTaskSelectClaimPro", WorkTaskTable.TableName, new IDbDataParameter[] { 
                //        DBProvider.MakeParameter("USERID", userId),
                //        DBProvider.MakeParameter("TOPSIZE", topsize)
                //    });  
                //2、语句方式
                string sqlQuery = string.Empty;
                switch (this.DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlQuery = string.Format(@"SELECT TOP {0} * FROM (  
	                                            SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION  
	                                            FROM WORKTASKINSTANCEVIEW  
	                                            WHERE  ((OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW WHERE USERID='{1}') ) OR  (OPERCONTENT = 'All')) AND  (OPERSTATUS='0') AND (STATUS='1') 
	                                            UNION   
	                                            SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                            FROM WORKTASKINSACCREDITVIEW 
	                                            WHERE  ACCREDITTOUSERID='{1}' AND ACCREDITSTATUS='1'AND STATUS='1'  ) A   
                                            ORDER BY TASKSTARTTIME DESC ", topsize, userId);
                        break;
                    case CurrentDbType.Oracle:
                        sqlQuery = string.Format(@"SELECT * FROM (  
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION  
	                                                FROM WORKTASKINSTANCEVIEW  
	                                                WHERE  ((OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW WHERE USERID='{0}') ) OR  (OPERCONTENT = 'All')) AND  (OPERSTATUS='0') AND (STATUS='1') 
	                                                UNION   
	                                                SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                                FROM WORKTASKINSACCREDITVIEW 
	                                                WHERE   ACCREDITTOUSERID='{0}' AND ACCREDITSTATUS='1'AND STATUS='1'  ) A   
                                             WHERE ROWNUM <= {1}
                                             ORDER BY TASKSTARTTIME DESC ", userId, topsize);
                        break;
                    case CurrentDbType.MySql:
                        sqlQuery = string.Format(@"SELECT * FROM (  
	                                            SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION  
	                                            FROM WORKTASKINSTANCEVIEW  
	                                            WHERE  ((OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW WHERE USERID='{1}') ) OR  (OPERCONTENT = 'All')) AND  (OPERSTATUS='0') AND (STATUS='1') 
	                                            UNION   
	                                            SELECT PRIORITY,WORKFLOWNO,TASKSTARTTIME,TASKINSCAPTION,FLOWINSCAPTION,OPERCONTENT,STATUS,FLOWCAPTION,TASKCAPTION,USERID,WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERTYPE,TASKTYPEID,OPERATORINSID,OPERATEDDES,OPERDATETIME,TASKENDTIME,FLOWSTARTTIME,FLOWENDTIME,POPERATEDDES,DESCRIPTION,OPERSTATUS,TASKINSTYPE,TASKINSDESCRIPTION 
	                                            FROM WORKTASKINSACCREDITVIEW 
	                                            WHERE  ACCREDITTOUSERID='{0}' AND ACCREDITSTATUS='1'AND STATUS='1'  ) A   
                                            ORDER BY TASKSTARTTIME DESC limit {1}", userId,topsize );
                        break;
                }

                dtClamimWorkTask = this.Fill(sqlQuery);
                return dtClamimWorkTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 未认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>未认领的任务列表</returns>
        public DataTable GetUnClaimedTaskByPage(string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            try
            {
                this.CurrentTableName = string.Format(@" ( SELECT    PRIORITY ,WORKFLOWNO ,TASKSTARTTIME ,TASKINSCAPTION ,FLOWINSCAPTION ,OPERCONTENT ,STATUS ,
                                                        FLOWCAPTION ,TASKCAPTION ,USERID ,WORKFLOWID ,WORKTASKID ,WORKFLOWINSID ,WORKTASKINSID ,
                                                        OPERTYPE ,TASKTYPEID ,OPERATORINSID ,OPERATEDDES ,OPERDATETIME ,TASKENDTIME ,FLOWSTARTTIME ,
                                                        FLOWENDTIME ,POPERATEDDES ,DESCRIPTION ,OPERSTATUS ,TASKINSTYPE ,TASKINSDESCRIPTION
                                              FROM      WORKTASKINSTANCEVIEW
                                              WHERE     ( ( OPERCONTENT IN ( SELECT OPERCONTENT FROM   OPERCONTENTVIEW WHERE  USERID = '{0}' ) ) OR ( OPERCONTENT = 'ALL' ))
                                                        AND ( OPERSTATUS = '0' )
                                                        AND ( STATUS = '1' )
                                              UNION
                                              SELECT    PRIORITY ,WORKFLOWNO ,TASKSTARTTIME ,TASKINSCAPTION ,FLOWINSCAPTION ,OPERCONTENT ,STATUS ,
                                                        FLOWCAPTION ,TASKCAPTION ,USERID ,WORKFLOWID ,WORKTASKID ,WORKFLOWINSID ,WORKTASKINSID ,
                                                        OPERTYPE ,TASKTYPEID ,OPERATORINSID ,OPERATEDDES ,OPERDATETIME ,TASKENDTIME ,FLOWSTARTTIME ,
                                                        FLOWENDTIME ,POPERATEDDES ,DESCRIPTION ,OPERSTATUS ,TASKINSTYPE ,TASKINSDESCRIPTION
                                              FROM      WORKTASKINSACCREDITVIEW
                                              WHERE     ACCREDITTOUSERID = '{0}' AND ACCREDITSTATUS = '1' AND STATUS = '1'
                                            ) UNCLAIMEDTASKTABLE", userId);
                this.SelectField = "*";
                order = string.IsNullOrEmpty(order) ? " TASKSTARTTIME DESC " : order;
                return GetDTByPage(out recordCount, pageIndex, pageSize, search, order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回本流程中已完成的任务
        /// </summary>
        /// <param name="workflowInsId">工作流程实例id</param>
        /// <param name="taskinscaption">工作任务实例名称</param>
        /// <returns>本流程中已完成的任务列表</returns>
        public DataTable WorkCompleteWorkTask(string workflowInsId, string taskinscaption)
        {
            try
            {
                string sql = string.Format(@"SELECT WORKTASKINSID,TASKINSCAPTION FROM WORKTASKINSTANCE WHERE WORKFLOWINSID={0} and SUCCESSMSG='任务已成功执行' AND TASKINSCAPTION !={1} ORDER  BY ENDTIME DESC"
                    , DBProvider.GetParameter("workflowInsId"), DBProvider.GetParameter("taskinscaption"));

                return this.Fill(sql, new IDbDataParameter[] { 
                    DBProvider.MakeParameter("workflowInsId", workflowInsId),
                    DBProvider.MakeParameter("taskinscaption", taskinscaption)               
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 我参与的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>我参与的任务列表</returns>
        public DataTable WorkflowAllTask(string userId, int topsize)
        {
            try
            {
                /*
                return this.DBProvider.ExecuteProcedureForDataTable("WorkFlowMyTask", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { 
                        DBProvider.MakeParameter("USERID", userId),
                        DBProvider.MakeParameter("FLAG", "ALL"),
                        DBProvider.MakeParameter("TOPSIZE", topsize)
                    });  
                 */
                return WorkFlowMyTask(userId, topsize, "All");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 我参与的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="flag">标志，默认为"All”</param>
        /// <param name="search">条件表达式</param>
        /// <returns>我参与的任务列表</returns>
        public DataTable WorkFlowAllTaskByPage(string userId, out int recordCount, int pageIndex = 0, int pageSize = 100, string flag = "All",string search = "")
        {
            try
            {
                this.CurrentTableName = "WORKTASKINSTANCEVIEW";
                this.SelectField = "*";
                string whereExpression = " USERID='" + userId + "'";
                if (!string.IsNullOrEmpty(flag) && flag.ToLower() == "all")
                {

                }
                else
                {
                    whereExpression += " AND STATUS = '" + flag + "'";
                }

                if (!string.IsNullOrEmpty(search))
                {
                    whereExpression += " AND " + search;
                }

                string order = @" TASKSTARTTIME DESC ";
                return GetDTByPage(out recordCount, pageIndex, pageSize, whereExpression, order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 我已认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>我已认领的任务列表</returns>
        public DataTable WorkflowClaimedTask(string userId, int topsize)
        {
            try
            {
                /*
                return this.DBProvider.ExecuteProcedureForDataTable("WorkFlowMyTask", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { 
                        DBProvider.MakeParameter("USERID", userId),
                        DBProvider.MakeParameter("FLAG", "2"),
                        DBProvider.MakeParameter("TOPSIZE", topsize)
                    }); 
                 */
                return WorkFlowMyTask(userId, topsize, "2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 我已认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>我已认领的任务列表</returns>
        public DataTable GetWorkFlowClaimedTaskByPage(string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            try
            {
                string whereExpression = " USERID='" + userId + "' AND STATUS = '2' ";
                if (!string.IsNullOrEmpty(search))
                {
                    whereExpression += " AND " + search;
                }
                order = string.IsNullOrEmpty(order) ? " TASKSTARTTIME DESC " : order;
                recordCount = DbCommonLibary.GetCount(DBProvider, "WORKTASKINSTANCEVIEW", whereExpression);

                return DbCommonLibary.GetDTByPage(this.DBProvider, "WORKTASKINSTANCEVIEW", pageIndex, pageSize, whereExpression, order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 正在运行的流程实例列表
        /// </summary>
        /// <param name="topsize">显示条数</param>
        /// <returns>正在运行的流程实例列表</returns>
        public DataTable GetWorkFlowInstanceRunning(int topsize)
        {
            try
            {
                //1、存储过程方式
                //return this.DBProvider.ExecuteProcedureForDataTable("WorkFlowInstanceRunning", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { DBProvider.MakeParameter("TOPSIZE", topsize)});
                //2、语句方式
                string strSql = string.Empty;
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        strSql = " SELECT TOP " + topsize + "  *  FROM WORKFLOWINSTANCE  WHERE STATUS='2'  ORDER BY  STARTTIME DESC ";
                        break;
                    case CurrentDbType.Oracle:
                        strSql = " SELECT  *  FROM WORKFLOWINSTANCE  WHERE ROWNUM <= " + topsize + " AND STATUS='2'  ORDER BY  STARTTIME DESC ";
                        break;
                    case CurrentDbType.MySql:
                        strSql = " SELECT  *  FROM WORKFLOWINSTANCE  WHERE STATUS='2'  ORDER BY  STARTTIME DESC limit " + topsize;
                        break;
                }
                return DBProvider.Fill(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 已完成的流程实例
        /// </summary>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>已完成的流程实例列表</returns>
        public DataTable GetWorkFlowInstanceComplete(int topsize)
        {
            try
            {
                //1、存储过程方式
                //return this.DBProvider.ExecuteProcedureForDataTable("WorkFlowInstanceComplete", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { DBProvider.MakeParameter("TOPSIZE", topsize)});
                //2、语句方式
                string strSql = string.Empty;
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        strSql = " SELECT TOP " + topsize +"  *  FROM WORKFLOWINSTANCE  WHERE STATUS='3'  ORDER BY  STARTTIME DESC ";
                        break;
                    case CurrentDbType.Oracle:
                        strSql = " SELECT  *  FROM WORKFLOWINSTANCE  WHERE ROWNUM <= " + topsize + " AND STATUS='3'  ORDER BY  STARTTIME DESC ";
                        break;
                    case CurrentDbType.MySql:
                        strSql = " SELECT  *  FROM WORKFLOWINSTANCE  WHERE STATUS='3'  ORDER BY  STARTTIME DESC limit " + topsize;
                        break;
                }
                return DBProvider.Fill(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 我参与的任务、包括启动的和参与的
        /// </summary>
        /// <param name="userId">当前用户ID</param>
        /// <param name="topsize">返回前多少条记录</param>
        /// <param name="flag">标志</param>
        /// <returns></returns>
        private DataTable WorkFlowMyTask(string userId, int topsize, string flag)
        {
            string strSql = string.Empty;
            if (flag == "All")
            {
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        strSql = string.Format(" SELECT TOP " + topsize + "  *  FROM WORKTASKINSTANCEVIEW  WHERE USERID={0}  ORDER BY TASKSTARTTIME DESC ", DBProvider.GetParameter("USERID"));
                        break;
                    case CurrentDbType.Oracle:
                        strSql = string.Format(" SELECT  *  FROM WORKTASKINSTANCEVIEW  WHERE ROWNUM <= {0} AND USERID={1}  ORDER BY  STARTTIME DESC ",topsize,DBProvider.GetParameter("USERID"));
                        break;
                    case CurrentDbType.MySql:
                        strSql = string.Format(" SELECT  *  FROM WORKTASKINSTANCEVIEW  WHERE USERID={0}  ORDER BY  STARTTIME DESC limit {1}", DBProvider.GetParameter("USERID"), topsize);
                        break;
                }
                return DBProvider.Fill(strSql, new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId)});
            }
            else
            {
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        strSql = string.Format(" SELECT TOP " + topsize + "  *  FROM WORKTASKINSTANCEVIEW  WHERE USERID={0} AND STATUS={1} ORDER BY TASKSTARTTIME DESC ", DBProvider.GetParameter("USERID"), DBProvider.GetParameter("STATUS"));
                        break;
                    case CurrentDbType.Oracle:
                        strSql = string.Format(" SELECT  *  FROM WORKTASKINSTANCEVIEW  WHERE ROWNUM <= {0} AND USERID={1} AND STATUS={2} ORDER BY  STARTTIME DESC ", topsize, DBProvider.GetParameter("USERID"), DBProvider.GetParameter("STATUS"));
                        break;
                    case CurrentDbType.MySql:
                        strSql = string.Format(" SELECT  *  FROM WORKTASKINSTANCEVIEW  WHERE USERID={0}  AND STATUS={1} ORDER BY  STARTTIME DESC limit {2}", DBProvider.GetParameter("USERID"), DBProvider.GetParameter("STATUS"), topsize);
                        break;
                }
                return DBProvider.Fill(strSql, new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId), DBProvider.MakeParameter("STATUS", flag) });
            }
        }

        /// <summary>
        /// 我已完成的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>我已完成的任务表</returns>
        public DataTable WorkflowCompletedTask(string userId, int topsize)
        {
            try
            {
                /*
                return this.DBProvider.ExecuteProcedureForDataTable("WorkFlowMyTask", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { 
                        DBProvider.MakeParameter("USERId", userId),
                        DBProvider.MakeParameter("FLAG", "3"),
                        DBProvider.MakeParameter("TOPSIZE", topsize)
                    });
                 */
                return WorkFlowMyTask(userId, topsize, "3");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 我已完成的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>我已完成的任务表</returns>
        public DataTable WorkFlowCompletedTaskByPage(string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            try
            {
                string whereExpression = " USERID='" + userId + "' AND STATUS = '3' ";
                if (!string.IsNullOrEmpty(search))
                {
                    whereExpression += " AND " + search;
                }
                order = string.IsNullOrEmpty(order) ? " TASKSTARTTIME DESC " : order;
                recordCount = DbCommonLibary.GetCount(DBProvider, "WORKTASKINSTANCEVIEW", whereExpression);

                return DbCommonLibary.GetDTByPage(this.DBProvider, "WORKTASKINSTANCEVIEW", pageIndex, pageSize, whereExpression, order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 异常终止的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>异常终止的任务表</returns>
        public DataTable WorkflowAbnormalTask(string userId, int topsize)
        {
            try
            {
                /*
                 return this.DBProvider.ExecuteProcedureForDataTable("WorkFlowMyTask", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { 
                        DBProvider.MakeParameter("USERID", userId),
                        DBProvider.MakeParameter("FLAG", "4"),
                        DBProvider.MakeParameter("TOPSIZE", topsize)
                    }); 
                 */
                return WorkFlowMyTask(userId, topsize, "4");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得一个流程实例实例的信息
        /// </summary>
        /// <param name="workflowInsId">工作流程实例Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowInstance(string workflowInsId)
        {
            try
            {                
                return this.GetDT(WorkFlowInstanceTable.FieldWorkFlowInsId, workflowInsId);
                //string sqlExpression = "select * from WorkflowInstance where workflowInsId=@workflowInsId";
                //return this.Fill(sqlExpression, new IDbDataParameter[] { DBProvider.MakeParameter("workflowInsId", workflowInsId) });                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 流程历史
        /// </summary>
        /// <param name="workflowinsid">工作流程实例Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowHistory(string workflowinsid)
        {
            try
            {
                string sqlExpression = string.Format(" SELECT DISTINCT WORKFLOWID,WORKTASKID,WORKFLOWINSID,WORKTASKINSID,OPERATORINSID," +
                                      "FLOWCAPTION,TASKCAPTION,OPERATEDDES,TASKENDTIME FROM WORKTASKINSTANCEVIEW  " +
                                      " WHERE STATUS='3' AND WORKFLOWINSID={0}  ORDER BY TASKENDTIME", DBProvider.GetParameter("WORKFLOWINSID"));
                return this.Fill(sqlExpression, new IDbDataParameter[] { DBProvider.MakeParameter("WORKFLOWINSID", workflowinsid) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 加载退回原因
        /// </summary>
        /// <param name="workflowinsid">工作流程实例Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowback(string workflowinsid)
        {
            try
            {
                string sqlExpression = string.Format("SELECT USERID,BACKYY,BACKTIME FROM WORKFLOWBACK WHERE OPERATORINSID={0}", DBProvider.GetParameter("workflowinsid"));
                return this.Fill(sqlExpression, new IDbDataParameter[] { DBProvider.MakeParameter("workflowinsid", workflowinsid) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 设定流程实例正常结束
        /// </summary>
        /// <param name="workflowInsId">工作流程实例Id</param>
        public int SetWorkflowInstanceOver(string workflowInsId)
        {
            try
            {
                //1、存储过程方式
                /*
                return this.DBProvider.ExecuteProcedure("SetWorkFlowInstanceOverPro", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)
                }); 
                 */
                //2、语句方式
                string strSql = string.Format(@"UPDATE  WORKFLOWINSTANCE
                                                SET     STATUS = '3' ,
                                                        ENDTIME = {0}
                                                WHERE   WORKFLOWINSID = {1}", DBProvider.GetDBNow(), DBProvider.GetParameter("WORKFLOWINSID"));
                int returnValue = this.DBProvider.ExecuteNonQuery(strSql,
                                           new IDbDataParameter[] { 
                                                DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)});
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:设置流程实例为完成失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 设定流程实例的当前位置
        /// </summary>
        /// <param name="workflowInsId">实例实例id</param>
        /// <param name="nowtaskId"></param>
        /// <returns></returns>
        public int SetCurrTaskId(string workflowInsId, string nowtaskId)
        {
            try
            {
                string sqlExpression = string.Format("UPDATE WORKFLOWINSTANCE SET NOWTASKID={0} WHERE WORKFLOWINSID={1}", DBProvider.GetParameter("NOWTASKID"), DBProvider.GetParameter("WORKFLOWINSID"));
                return this.ExecuteNonQuery(sqlExpression, new IDbDataParameter[] { 
                    DBProvider.MakeParameter("NOWTASKID", nowtaskId),
                    DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)
                });   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设定流程实例挂起
        /// </summary>
        /// <param name="workflowInsId">实例实例id</param>
        public string SetSuspend(string workflowInsId)
        {
            try
            {
                //1、存储过程方式
                /*
                int i = this.DBProvider.ExecuteProcedure("SetWorkFlowInsSuspend", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)
                });

                return i > 0 ? WorkFlowConst.SuccessCode : WorkFlowConst.WorkFlowSuspendErrorCode;
                 */
                //2、语句方式
                string strSql = string.Format(@"UPDATE  WORKFLOWINSTANCE
                                                SET     SUSPENDSTAUS = STATUS ,
                                                        STATUS = '5' ,
                                                        SUSPENDTIME = {0}
                                                WHERE   WORKFLOWINSID ={1}
                                                        AND STATUS <> '5'", DBProvider.GetDBNow(),DBProvider.GetParameter("WORKFLOWINSID"));
                int returnValue = this.DBProvider.ExecuteNonQuery(strSql,
                                           new IDbDataParameter[] { 
                                                DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)});
                return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.WorkFlowSuspendErrorCode;
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:设置流程实例挂起失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 设定流程实例取消挂起
        /// </summary>
        /// <param name="workflowInsId">实例实例id</param>
        public string SetResume(string workflowInsId)
        {
            try
            {
                //1、存储过程方式
                /*
                int i = this.DBProvider.ExecuteProcedure("SetWorkFlowInsResume", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)
                });

                return i > 0 ? WorkFlowConst.SuccessCode : WorkFlowConst.WorkFlowResumeErrorCode;
                 */
                 //2、语句方式
                string strSql = string.Format(@"UPDATE  WORKFLOWINSTANCE
                                                SET     STATUS = SUSPENDSTAUS
                                                WHERE   WORKFLOWINSID = {0}
                                                        AND STATUS = '5'", DBProvider.GetParameter("WORKFLOWINSID"));
                int  returnValue = this.DBProvider.ExecuteNonQuery(strSql,
                                           new IDbDataParameter[] { 
                                                DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)});
               return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.WorkFlowResumeErrorCode;
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:设置流程实例取消挂起失败,请与管理员联系！Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 设定流程实例异常终止
        /// </summary>
        /// <param name="workflowInsId">流程实例Id</param>
        /// <param name="userId">用户id</param>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        public string SetAbnormal(string workflowInsId, string userId, string msg)
        {
            int returnValue = 0;
            try
            {
                //1、存储过程方式
                /*
                int i = this.DBProvider.ExecuteProcedure("SetWorkFlowInsAbnormal", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId),
                    DBProvider.MakeParameter("USERID", userId),
                    DBProvider.MakeParameter("MSG", msg)
                });
                return (i > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.WorkFlowAbnormalErrorCode;
                 */

                //2、语句方式
                string strSql = string.Format(@"   
                                            UPDATE  WORKFLOWINSTANCE
                                            SET     STATUS = '4'
                                            WHERE   WORKFLOWINSID = {0} ", DBProvider.GetParameter("WORKFLOWINSID"));
                returnValue += this.DBProvider.ExecuteNonQuery(strSql, new IDbDataParameter[] { DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId)});
                strSql = string.Format(@"INSERT  WORKFLOWABNORMAL
                                                ( ABNORMALID,WORKFLOWINSID ,USERID ,ABNORMALMSG
                                                )
                                        VALUES  ( {0} ,{1} , {2} ,{3})",
                                        DBProvider.GetParameter("ABNORMALID"),
                                        DBProvider.GetParameter("WORKFLOWINSID"),
                                        DBProvider.GetParameter("USERID"),
                                        DBProvider.GetParameter("ABNORMALMSG"));
                returnValue += this.DBProvider.ExecuteNonQuery(strSql,
                                            new IDbDataParameter[] { 
                                                DBProvider.MakeParameter("ABNORMALID", BusinessLogic.NewGuid()), 
                                                DBProvider.MakeParameter("WORKFLOWINSID", workflowInsId), 
                                                DBProvider.MakeParameter("USERID", userId), 
                                                DBProvider.MakeParameter("ABNORMALMSG", msg) });
                return (returnValue > 0) ? WorkFlowConst.SuccessCode : WorkFlowConst.WorkFlowAbnormalErrorCode;
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:设置流程实例异常终止失败,请与管理员联系！Error:" + ex.Message);
            }
            
        }

        /// <summary>
        /// 获得流程流水号（暂时不用这种方式）
        /// </summary>
        public string GetWorkflowNO()
        {
            try
            {                
                //sqlItem.CommandText = "CreatAutoCode";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@Auto_Type", WorkConst.WORKFLOW_FLOW);              
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 未认领任务的个数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int GetClaimingTaskCount(string userId)
        {
            /*
            object returnValue = this.DBProvider.ExecuteScalar("GetTaskCountPro"
                                                                , new IDbDataParameter[] {
                                                                    DBProvider.MakeParameter("USERID", userId),
                                                                    DBProvider.MakeParameter("FLAG", 0)}
                                                                , CommandType.StoredProcedure);
            return Int32.Parse(returnValue.ToString());
             */
            return GetTaskCountPro(userId, "0");
        }

        /// <summary>
        /// 待办任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int GetToDoTasksCount(string userId)
        {
            //DataTable dtToDoWork = this.DBProvider.ExecuteProcedureForDataTable("WorkFlowToDoTasks",WorkTaskTable.TableName,new IDbDataParameter[] {DBProvider.MakeParameter("USERID", userId),DBProvider.MakeParameter("TOPSIZE",9999)});
            DataTable dtToDoWork = this.GetToDoWorkTasks(userId, 9999);
            return dtToDoWork == null || dtToDoWork.Rows.Count <= 0 ? 0 : dtToDoWork.Rows.Count;
        }

        /// <summary>
        /// 已认领任务个数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int GetClaimedTaskCount(string userId)
        {
            /*
            object returnValue = this.DBProvider.ExecuteScalar("GetTaskCountPro"
                                                              , new IDbDataParameter[] { 
                                                                    DBProvider.MakeParameter("USERID", userId), 
                                                                    DBProvider.MakeParameter("FLAG", 2) }
                                                              , CommandType.StoredProcedure);
            return Int32.Parse(returnValue.ToString());
             */
            return GetTaskCountPro(userId, "2");
        }

        /// <summary>
        /// 我参与的任务个数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int GetAllTaskCount(string userId)
        {
            /*
            object returnValue = this.DBProvider.ExecuteScalar("GetTaskCountPro"
                                                             , new IDbDataParameter[] { 
                                                                    DBProvider.MakeParameter("USERID", userId), 
                                                                    DBProvider.MakeParameter("FLAG", "ALL") }
                                                             , CommandType.StoredProcedure);
            return Int32.Parse(returnValue.ToString());
             */
            return GetTaskCountPro(userId, "ALL");
        }

        /// <summary>
        /// 我完成的任务个数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int GetCompletedTaskCount(string userId)
        {
            /*
            object returnValue = this.DBProvider.ExecuteScalar("GetTaskCountPro"
                                                             , new IDbDataParameter[] { 
                                                                    DBProvider.MakeParameter("USERID", userId), 
                                                                    DBProvider.MakeParameter("FLAG", "3") }
                                                             , CommandType.StoredProcedure);
            return Int32.Parse(returnValue.ToString());
             */
            return GetTaskCountPro(userId, "3");
        }

        /// <summary>
        /// 我异常终止的任务个数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int GetAbnormalTaskCount(string userId)
        {
            /*object returnValue = this.DBProvider.ExecuteScalar("GetTaskCountPro"
                                                            , new IDbDataParameter[] { 
                                                                    DBProvider.MakeParameter("USERID", userId), 
                                                                    DBProvider.MakeParameter("FLAG", "4") }
                                                            , CommandType.StoredProcedure);
            return Int32.Parse(returnValue.ToString());
             */
            return GetTaskCountPro(userId, "4");
        }

        /// <summary>
        /// 得到未认领的任务/已认领任务/已完成的任务/异常终止的任务/我参与的任务的个数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="flag">
        ///  "0"：未认领的任务
        ///  "2"：已认领任务
        ///  "3"：已完成的任务
        ///  "4"：异常终止的任务
        ///  "All"：我参与的任务
        /// </param>
        /// <returns>任务的个数</returns>
        private int GetTaskCountPro(string userId, string flag)
        {
            int returnCount = 0;
            string strSql = string.Empty;
            if (flag == "0") //未认领的任务
            {
                strSql = string.Format(@"SELECT  COUNT(*)
                                FROM    WORKTASKINSTANCEVIEW
                                WHERE   ( ( OPERCONTENT IN ( SELECT OPERCONTENT
                                                             FROM   OPERCONTENTVIEW
                                                             WHERE  USERID = {0} ) )
                                          OR ( OPERCONTENT = 'All' )
                                        )
                                        AND ( OPERSTATUS = '0' )
                                        AND ( STATUS = '1' ) ", DBProvider.GetParameter("USERID"));
                int count1 = BusinessLogic.ConvertToInt(this.DBProvider.ExecuteScalar(strSql.ToString(), new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId) }));
                strSql = string.Format(@"SELECT  COUNT(*)
                                        FROM    WORKTASKINSACCREDITVIEW
                                        WHERE   ACCREDITTOUSERID = {0}
                                                AND ACCREDITSTATUS = '1'
                                                AND STATUS = '1'", DBProvider.GetParameter("USERID"));
                int count2 = BusinessLogic.ConvertToInt(this.DBProvider.ExecuteScalar(strSql.ToString(), new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId) }));
                returnCount = count1 + count2;
            }
            else if (flag == "2" || flag == "3" || flag == "4") //已认领任务/已完成的任务/异常终止的
            {
                strSql = string.Format(@"SELECT COUNT(*)
                                        FROM    WORKTASKINSTANCEVIEW
                                        WHERE   USERID = {0}
                                                AND STATUS = {1}", DBProvider.GetParameter("USERID"), DBProvider.GetParameter("STATUS"));
                returnCount = BusinessLogic.ConvertToInt(this.DBProvider.ExecuteScalar(strSql.ToString(), new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId), DBProvider.MakeParameter("STATUS", flag) }));

            }
            else if (flag == "All") //我参与的任务
            {
                strSql = string.Format(@"SELECT COUNT(*)
                                        FROM    WORKTASKINSTANCEVIEW
                                        WHERE   USERID = {0}", DBProvider.GetParameter("USERID"));
                returnCount = BusinessLogic.ConvertToInt(this.DBProvider.ExecuteScalar(strSql.ToString(), new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId)}));

            }

            return returnCount;
        }
    }
}
