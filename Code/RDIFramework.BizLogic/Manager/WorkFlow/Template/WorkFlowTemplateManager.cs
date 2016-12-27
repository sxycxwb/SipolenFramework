using System;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowTemplateManager
    /// 工作流程模版管理器
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-05 1.0 XuWangBin 扩展方法
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkFlowTemplateManager
    {
        /// <summary>
        /// 新建 一个流程模板
        /// <param name="entity">流程模板实体</param>
        /// <returns>增加成功后的主键</returns>
        /// </summary>
        public string InsertWorkFlow(WorkFlowTemplateEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.WorkFlowId.Trim().Length == 0 || entity.WorkFlowId == null)
                throw new Exception("InsertWorkFlow方法错误，WorkFlowId 不能为空！");

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

        /// <summary>
        /// 修改一个流程模板
        /// <param name="entity">流程模板实体</param>
        /// <returns>受影响的行数</returns>
        /// </summary>
        public int UpdateWorkFlow(WorkFlowTemplateEntity entity)
        {
            int returnInt = -1;
            if (entity.WorkFlowId.Trim().Length == 0 || entity.WorkFlowId == null)
                throw new Exception("UpdateWorkFlow方法错误，WorkFlowId 不能为空！");

            try
            {
                returnInt = this.UpdateEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnInt;
        }

        /// <summary>
        /// 删除一个流程模板
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns></returns>
        public int DeleteWorkFlow(string workflowId)
        {
            int returnInt = -1;
            if (workflowId.Trim().Length == 0 || workflowId == null)
                throw new Exception("DeleteWorkFlow方法错误，workflowId 不能为空！");

            try
            {
                //1、存储过程方式删除流程模板
                //returnInt = this.DBProvider.ExecuteProcedure("DeleteWorkFlow", new IDbDataParameter[] { DBProvider.MakeParameter(WorkFlowTemplateTable.FieldWorkFlowId, workflowId) });

                /*
                 *  删除的各语句
                    DELETE  WORKFLOW  WHERE   WORKFLOWID = @WORKFLOWID 
                    DELETE  WORKTASK  WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  WORKLINK  WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  TASKVAR   WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  OPERATOR  WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  WORKTASKCOMMANDS  WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  SUBWORKFLOW  WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  WORKTASKCONTROLS WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  WORKFLOWEVENT  WHERE   WORKFLOWID = @WORKFLOWID
                    DELETE  WORKOUTTIME  WHERE   WORKFLOWID = @WORKFLOWID 
                 */
                //2、直接语句方式删除流程模板
                //2.1、删除流程模板
                returnInt += new WorkFlowTemplateManager(DBProvider, this.UserInfo, WorkFlowTemplateTable.TableName).Delete(WorkFlowTemplateTable.FieldWorkFlowId, workflowId);
                //2.2、删除任务节点
                returnInt += new WorkTaskManager(DBProvider, this.UserInfo, WorkFlowTemplateTable.TableName).Delete(WorkTaskTable.FieldWorkFlowId, workflowId);
                //2.3、删除连线
                returnInt += new WorkLinkManager(DBProvider, this.UserInfo, WorkLinkTable.TableName).Delete(WorkLinkTable.FieldWorkFlowId, workflowId);
                //2.4、删除任务节点变量
                returnInt += new TaskVarManager(DBProvider, this.UserInfo, TaskVarTable.TableName).Delete(TaskVarTable.FieldWorkFlowId, workflowId);
                //2.5、删除操作者
                returnInt += new OperatorManager(DBProvider, this.UserInfo, OperatorTable.TableName).Delete(OperatorTable.FieldWorkFlowId, workflowId);
                //2.5、删除任务节点命令
                returnInt += new WorkTaskCommandsManager(DBProvider, this.UserInfo, WorkTaskCommandsTable.TableName).Delete(WorkTaskCommandsTable.FieldWorkFlowId, workflowId);
                //2.6、删除子流程
                returnInt += new SubWorkFlowManager(DBProvider, this.UserInfo, SubWorkFlowTable.TableName).Delete(SubWorkFlowTable.FieldWorkFlowId, workflowId);
                //2.7、删除任务节点表单
                returnInt += new WorkTaskControlsManager(DBProvider, this.UserInfo, WorkTaskControlsTable.TableName).Delete(WorkTaskControlsTable.FieldWorkflowId, workflowId);
                //2.8、删除任务节点事件通知
                returnInt += new WorkFlowEventManager(DBProvider, this.UserInfo, WorkFlowEventTable.TableName).Delete(WorkFlowEventTable.FieldWorkFlowId, workflowId);
                //2.9、删除任务节点工作任务超时设置
                returnInt += new WorkOutTimeManager(DBProvider, this.UserInfo, WorkOutTimeTable.TableName).Delete(WorkOutTimeTable.FieldWorkFlowId, workflowId);
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:删除流程失败,请与管理员联系！Error:" + ex.Message);
            }
            return returnInt;
        }

        /// <summary>
        /// 获得工作流模板信息
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns></returns>
        public DataTable GetWorkflowTable(string workflowId)
        {
            try
            {
                //string tmpStr = "select * from workflow where WorkFlowId=@workflowId";
                return this.GetDT(WorkFlowTemplateTable.FieldWorkFlowId, workflowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定工作流程所有的任务表单
        /// </summary>
        /// <param name="workflowId">流程模版ID</param>
        /// <returns></returns>
        public DataTable GetWorkFlowAllControlsTable(string workflowId)
        {
            try
            {
                //string tmpStr = "select  * from worktaskControls where WorkFlowId=@workflowId";
                return new WorkTaskControlsManager(this.DBProvider).GetDT(WorkTaskControlsTable.FieldWorkflowId, workflowId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到流程模板实体
        /// </summary>
        /// <param name="workflowId">流程模版ID</param>
        /// <returns>流程模板实体</returns>
        public WorkFlowTemplateEntity GetWorkflowInfo(string workflowId)
        {
            DataTable dt = GetWorkflowTable(workflowId);
            WorkFlowTemplateEntity entity = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<WorkFlowTemplateEntity>(dt);
            }
            return entity;
        }

        /// <summary>
        /// 获得有权限启动的流程
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public DataTable GetAllowStartWorkFlows(string userId)
        {
            var dtAllowStartWF = new DataTable(WorkFlowTemplateTable.TableName);
            try
            {
                //1、存储过程方法（oracle下带实现）
                //return DBProvider.ExecuteProcedureForDataTable("WorkTaskSelectStartPro", WorkFlowTemplateTable.TableName, new IDbDataParameter[] { DBProvider.MakeParameter("UserId", userId) });             
                //2、直接语句法
                string sqlQuery = string.Format(@"     SELECT  *
                                                      FROM    ( SELECT  DISTINCT WFCLASSID ,CAPTION , FATHERID ,WORKFLOWID ,FLOWCAPTION ,WORKTASKID ,TASKCAPTION ,CLLEVEL ,MGRURL ,CLMGRURL
                                                      FROM      WORKTASKVIEW
                                                      WHERE     ( ( OPERCONTENT IN ( SELECT OPERCONTENT FROM   OPERCONTENTVIEW WHERE  USERID = '{0}' ) )
                                                                  OR ( OPERCONTENT IN ( SELECT  DEPARTMENTID FROM    V_PIUSER WHERE   ID = '{0}' ) )
                                                                  OR ( OPERCONTENT IN ( SELECT  ROLEID FROM    V_PIUSERROLE WHERE   USERID = '{0}' ) )
                                                                  OR ( OPERCONTENT = 'ALL' )
                                                                  OR EXISTS ( SELECT * FROM   V_PIUSER WHERE  ID = '{0}'
                                                                                        AND ( CODE = 'Administrator' OR USERNAME = 'Administrator' ) )
                                                                )
                                                                AND TASKTYPEID = '1' AND STATUS = '1'
                                                      UNION
                                                      SELECT DISTINCT WFCLASSID ,CAPTION ,FATHERID ,WORKFLOWID ,FLOWCAPTION ,WORKTASKID ,TASKCAPTION ,CLLEVEL ,MGRURL ,CLMGRURL
                                                      FROM      WORKTASKACCREDITVIEW
                                                      WHERE     ACCREDITTOUSERID = '{0}' AND ACCREDITSTATUS = '1' AND TASKTYPEID = '1'              
                                                    ) A   ORDER BY CLLEVEL ,CAPTION", userId);
                dtAllowStartWF = this.Fill(sqlQuery);   
                return dtAllowStartWF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 依据流程模版名称获得流程模板列表
        /// </summary>
        /// <param name="workflowCaption">流程模板名称</param>
        /// <returns></returns>
        public DataTable GetWorkflowsByCaption(string workflowCaption)
        {

            string tmpStr = string.Format("SELECT * FROM WORKFLOW WHERE FLOWCAPTION LIKE {0}", DBProvider.GetParameter(WorkFlowTemplateTable.FieldFlowCaption));
            try
            {
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter(WorkFlowTemplateTable.FieldFlowCaption, "%" + workflowCaption + "%") });            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否存在指定流程模版
        /// </summary>
        /// <param name="workFlowid">流程模版id</param>
        /// <returns></returns>
        public bool Exists(string workFlowid)
        {
            //string tmpSql = "select * from workflow where workflowId=@workFlowid";
            return this.Exists(WorkFlowTemplateTable.FieldWorkFlowId, workFlowid);
        }

        /// <summary>
        /// 设置工作流模板状态。status=1 启用，status=0 禁用
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="status">status=1 启用，status=0 禁用</param>
        /// <returns></returns>
        public int SetWorkflowStatus(string workflowId, string status)
        {
            try
            {
                //string tmpSql = "update workflow set status=@status where WorkFlowId=@workflowId";
                return this.SetProperty(WorkFlowTemplateTable.FieldWorkFlowId, workflowId, WorkFlowTemplateTable.FieldStatus, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置流程模版分类
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="wfclassid">流程分类Id</param>
        /// <returns></returns>
        public int SetWorkflowClass(string workflowId, string wfclassid)
        {
            try
            {
                //string tmpSql = "update workflow set wfclassId=@wfclassid where WorkFlowId=@workflowId";
                return this.SetProperty(WorkFlowTemplateTable.FieldWorkFlowId, workflowId, WorkFlowTemplateTable.FieldWFClassId, wfclassid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

