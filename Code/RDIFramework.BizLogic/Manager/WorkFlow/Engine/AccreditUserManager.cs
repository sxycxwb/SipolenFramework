using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// AccreditUserManager
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 EricHu 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>EricHu</name>
    /// <date>2014-06-09</date>
    /// </author>
    /// </summary>
    public partial class AccreditUserManager
    {
        /// <summary>
        /// 增加AccreditUser
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        public string Insert(AccreditUserEntity entity)
        {
            string returnStr = string.Empty;
            try
            {
                if (!accreditExists(entity.AccreditFromUserId, entity.AccreditToUserId, entity.AcWorkflowId, entity.AcWorktaskId)) //有效的授权是否存在
                {
                    returnStr = this.AddEntity(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }

        /// <summary>
        /// 有效的授权是否存在
        /// </summary>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <param name="AcWorkflowId"></param>
        /// <param name="AcWorktaskId"></param>
        /// <returns></returns>
        private bool accreditExists(string fromUserId,string toUserId,string AcWorkflowId,string AcWorktaskId)
        {
            //string sql = "select * from AccreditUser where AccreditFromUserId=@fromUserId and " +
            //             " AccreditToUserId=@toUserId and AcWorkflowId=@AcWorkflowId and " +
            //              "AcWorktaskId=@AcWorktaskId and AccreditStatus='1'";//有效的授权是否存在
            KeyValuePair<string,object>[] pameters = {
                                                     new KeyValuePair<string, object>(AccreditUserTable.FieldAccreditFromUserId, fromUserId),
                                                     new KeyValuePair<string,object>(AccreditUserTable.FieldAccreditToUserId,toUserId),
                                                     new KeyValuePair<string,object>(AccreditUserTable.FieldAcWorkflowId,AcWorkflowId),
                                                     new KeyValuePair<string,object>(AccreditUserTable.FieldAcWorktaskId,AcWorktaskId),
                                                     new KeyValuePair<string,object>(AccreditUserTable.FieldAccreditStatus,"1")
                                                 };
            return this.Exists(pameters);          
        }

        /// <summary>
        /// 判断用户是否是该任务节点的操作者，如果不是不允许授权该任务，
        /// 对于根据处理者策略获取的处理者类型，需要在流程模板中单独增加
        /// 该处理人才能授权。
        //
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public bool IsTaskOperator(string userId, string workflowId, string worktaskId)
        {
            string sql =  string.Format("SELECT  * FROM WORKTASKVIEW  WHERE (" +
                        "(OPERCONTENT IN (SELECT OPERCONTENT FROM OPERCONTENTVIEW WHERE USERID={0}) OR OPERCONTENT='ALL' ) AND " +
                        " WORKFLOWID={1} AND WORKTASKID={2})",
                        DBProvider.GetParameter("userId"),
                        DBProvider.GetParameter("workflowId"),
                        DBProvider.GetParameter("worktaskId"));
            DataTable dt = this.Fill(sql, new IDbDataParameter[] 
            { 
                DBProvider.MakeParameter("userId", userId),
                DBProvider.MakeParameter("workflowId", workflowId),
                DBProvider.MakeParameter("worktaskId", worktaskId)
            });   

            return dt!= null && dt.Rows.Count > 0;         
        }

        /// <summary>
        /// 判断用户是否是该任务节点的操作者
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool isTaskOperator(AccreditUserEntity entity)
        {
            return IsTaskOperator(entity.AccreditFromUserId, entity.AcWorkflowId, entity.AcWorktaskId);
        }

        /// <summary>
        /// 更新AccreditUser
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int UpdateAccreditUser(AccreditUserEntity entity)
        {
            int returnInt = -1;
            if (entity.AUserId.Trim().Length == 0 || entity.AUserId == null)
                throw new Exception("Update方法错误，AUserId不能为空！");

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
        /// 获得AccreditUser表
        /// </summary>
        /// <param name="auserid">主键</param>
        /// <returns></returns>
        public DataTable GetAccreditUserTable(string auserid)
        {
            try
            {
                return this.GetDT(AccreditUserTable.FieldAUserId, auserid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 已授出的任务授权列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public DataTable GetToAccreditTable(string userId)
        {
            string sql = string.Format("SELECT DISTINCT FLOWCAPTION,TASKCAPTION,WORKFLOWID," +
                        "AUSERID,WORKTASKID,ACCREDITFROMUSERID,ACCREDITTOUSERID,USERNAME " +
                        " FROM WORKTASKACCREDITVIEW WHERE ACCREDITSTATUS='1' AND ACCREDITFROMUSERID={0} " +
                          " ORDER BY FLOWCAPTION,TASKCAPTION", DBProvider.GetParameter("userId"));
            return this.Fill(sql, new IDbDataParameter[] { DBProvider.MakeParameter("userId", userId) });   
        }


        /// <summary>
        /// 被授予的任务授权列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public DataTable GetHaveAccreditTable(string userId)
        {
            string sql = string.Format("SELECT DISTINCT FLOWCAPTION,TASKCAPTION,WORKFLOWID," +
                        "AUSERID,WORKTASKID,ACCREDITFROMUSERID,ACCREDITTOUSERID,FROMUSERNAME " +
                        " FROM WORKTASKACCREDITVIEW WHERE ACCREDITSTATUS='1' AND ACCREDITTOUSERID={0} " +
                          " ORDER BY FLOWCAPTION,TASKCAPTION", DBProvider.GetParameter("userId"));
            return this.Fill(sql, new IDbDataParameter[] { DBProvider.MakeParameter("userId", userId) });   
        }

       /// <summary>
       /// 移除任务授权
       /// </summary>
       /// <param name="auserId">主键</param>
       /// <returns>大于0成功</returns>
        public int MoveAccredit(string auserId)
        {
            string sql = string.Format("UPDATE ACCREDITUSER SET ACCREDITSTATUS='0' WHERE AUSERID={0}", DBProvider.GetParameter("auserid"));
            return this.ExecuteNonQuery(sql, new IDbDataParameter[] { DBProvider.MakeParameter("auserid", auserId) });   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auserid"></param>
        /// <returns></returns>
        public AccreditUserEntity GetAccreditUserInfo(string auserid)
        {
            AccreditUserEntity entity = null;
            DataTable dt = GetAccreditUserTable(auserid);
            if (dt != null && dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<AccreditUserEntity>(dt);
            }
            return entity;
        }

        /// <summary>
        /// 根据主键删除任务授权记录
        /// </summary>
        /// <param name="aUserid">主键</param>
        /// <returns></returns>
        public int DeleteAccreditUser(string aUserid)
        {
            try
            {
                return this.Delete(AccreditUserTable.FieldAUserId, aUserid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
