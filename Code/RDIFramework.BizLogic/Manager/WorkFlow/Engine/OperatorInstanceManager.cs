using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// OperatorInstanceManager
    /// 处理者实例管理器
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-06</date>
    /// </author>
    /// </summary>
    public partial class OperatorInstanceManager
    {
        /// <summary>
        /// 判断处理者实例是否已经存在，避免重复数据
        /// </summary>
        /// <param name="workflowInsId"></param>
        /// <param name="worktaskId"></param>
        /// <param name="operContent"></param>
        /// <param name="operstatus"></param>
        /// <returns></returns>
        private bool OperatorExists(string workflowInsId, string worktaskId, string operContent, int operstatus = 0)
        {
            bool returnValue = false;
            string sql = string.Format("SELECT COUNT(*) FROM OPERATORINSTANCE WHERE WORKFLOWINSID={0} AND WORKTASKID={1} AND OPERCONTENT={2} AND OPERSTATUS={3}",
                            DBProvider.GetParameter(OperatorInstanceTable.FieldWorkFlowInsId),
                            DBProvider.GetParameter(OperatorInstanceTable.FieldWorkTaskId),
                            DBProvider.GetParameter(OperatorInstanceTable.FieldOperContent),
                            DBProvider.GetParameter(OperatorInstanceTable.FieldOperStatus));
            object returnObject =  this.ExecuteScalar(sql, new IDbDataParameter[] 
            { 
                DBProvider.MakeParameter(OperatorInstanceTable.FieldWorkFlowInsId,workflowInsId),
                DBProvider.MakeParameter(OperatorInstanceTable.FieldWorkTaskId,worktaskId),
                DBProvider.MakeParameter(OperatorInstanceTable.FieldOperContent,operContent),
                DBProvider.MakeParameter(OperatorInstanceTable.FieldOperStatus,operstatus)
            });

            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString()) > 0;
            }
            return returnValue;
        }

        /// <summary>
        /// 是否排除该处理人
        /// </summary>
        /// <param name="workFlowId"></param>
        /// <param name="workTaskId"></param>
        /// <param name="operContent"></param>
        /// <param name="InorExclude"></param>
        /// <returns></returns>
        private bool OperatorIsExclude(string workFlowId, string workTaskId, string operContent, int InorExclude = 0)
        {
            bool returnValue = false;
            string sql = string.Format("SELECT * FROM OPERATOR WHERE WORKFLOWID={0} AND WORKTASKID={1} AND INOREXCLUDE={2}  AND OPERCONTENT={3}",
                DBProvider.GetParameter(OperatorTable.FieldWorkFlowId),
                DBProvider.GetParameter(OperatorTable.FieldWorkTaskId),
                DBProvider.GetParameter(OperatorTable.FieldInorExclude),
                DBProvider.GetParameter(OperatorTable.FieldOperContent));
            object returnObject = this.ExecuteScalar(sql, new IDbDataParameter[] 
            { 
                DBProvider.MakeParameter(OperatorTable.FieldWorkFlowId,workFlowId),
                DBProvider.MakeParameter(OperatorTable.FieldWorkTaskId,workTaskId),
                DBProvider.MakeParameter(OperatorTable.FieldInorExclude,InorExclude),
                DBProvider.MakeParameter(OperatorTable.FieldOperContent,operContent)
            });
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString()) > 0;
            }
            return returnValue;
        }

        /// <summary>
        /// 创建处理者实例
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public string Create(OperatorInstanceEntity entity)
        {
            string returnStr = string.Empty;
            try
            {
                if (OperatorExists(entity.WorkFlowInsId, entity.WorkTaskId, entity.OperContent, 0)) 
                    return string.Empty;//不重复添加

                if (OperatorIsExclude(entity.WorkFlowId, entity.WorkTaskId, entity.OperContent, 0))
                    return string.Empty;//排除的在外的处理人不添加
                returnStr = this.AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }

        /// <summary>
        /// 获得一个要处理的信息
        /// </summary>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        public DataTable GetOperatorInstance(string operatorInsId)
        {
            try
            {
                string getSql = string.Format("SELECT * FROM WORKTASKINSTANCEVIEW WHERE OPERATORINSID={0}", DBProvider.GetParameter("operatorInsId"));
                return this.Fill(getSql, new IDbDataParameter[] { DBProvider.MakeParameter("operatorInsId", operatorInsId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设定处理者实例正常结束
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">操作者实例id</param>
        /// <returns></returns>
        public int SetOperatorInstanceOver(string userId, string operatorInsId)
        {
            try
            {
                //1、存储过程方式
                /*
                return this.DBProvider.ExecuteProcedure("SetOperatorInstanceOverPro", new IDbDataParameter[] 
                { 
                    DBProvider.MakeParameter("USERID", userId),
                    DBProvider.MakeParameter("OPERATORINSID", operatorInsId)
                }); 
                 */
                //2、语句方式
                string strSql = string.Format(@"
                                        UPDATE  OPERATORINSTANCE
                                        SET     USERID = {0} ,
                                                OPERDATETIME = {1} ,
                                                OPERSTATUS = '1'
                                        WHERE   OPERATORINSID = {2}", DBProvider.GetParameter("USERID"), DBProvider.GetDBNow(), DBProvider.GetParameter("OPERATORINSID"));
                return this.DBProvider.ExecuteNonQuery(strSql, new IDbDataParameter[] { DBProvider.MakeParameter("USERID", userId), DBProvider.MakeParameter("OPERATORINSID", operatorInsId) });
            }
            catch (Exception ex)
            {
                throw new Exception("BizLogicError:设置处理者实例为完成失败,请与管理员联系！Error:" + ex.Message);
            }
        }
    }
}
