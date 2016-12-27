using System;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkLinkManager
    /// 流程连线配置
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkLinkManager
    {
        /// <summary>
        /// 增加连线
        /// </summary>
        /// <param name="entity">流程连线实体</param>
        /// <returns>增加成功后的主键</returns>
        public string InsertLink(WorkLinkEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.WorkLinkId.Trim().Length == 0 || entity.WorkLinkId == null)
                throw new Exception("InsertLink方法错误，LinkId 不能为空！");
            if (entity.WorkFlowId.Trim().Length == 0 || entity.WorkFlowId == null)
                throw new Exception("InsertLink方法错误，WorkflowId 不能为空！");
            if (entity.StartTaskId == null)
                throw new Exception("InsertLink方法错误，StartTask 不能为空！");
            if (entity.EndTaskId == null)
                throw new Exception("InsertLink方法错误，EndTask 不能为空！");

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
        /// 修改连线
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateLink(WorkLinkEntity entity)
        {
            int returnInt = -1;
            if (entity.WorkLinkId.Trim().Length == 0 || entity.WorkLinkId == null)
                throw new Exception("UpdateLink方法错误，LinkId 不能为空！");
            if (entity.WorkFlowId.Trim().Length == 0 || entity.WorkFlowId == null)
                throw new Exception("UpdateLink方法错误，WorkflowId 不能为空！");
            if (entity.StartTaskId == null)
                throw new Exception("UpdateLink方法错误，StartTaskId 不能为空！");
            if (entity.EndTaskId == null)
                throw new Exception("UpdateLink方法错误，EndTaskId 不能为空！");
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
        /// 从Worklink表中删除一条连线
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="workLinkId"></param>
        /// <returns></returns>
        public int DeleteLine(string workflowId, string workLinkId)
        {
            try
            {
                //string tmpSql = "delete WorkLink where WorkFlowId=@workflowId and WorkLinkId=@workLinkId";
                return this.Delete(WorkLinkTable.FieldWorkFlowId, workflowId, WorkLinkTable.FieldWorkLinkId, workLinkId);            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程连线
        /// </summary>
        /// <param name="workflowId">流程Id</param>
        /// <returns></returns>
        public DataTable GetWorkLinks(string workflowId)
        {
            try
            {
                string tmpStr = string.Format("SELECT * FROM WORKTASKLINKVIEW WHERE WORKFLOWID = {0}", DBProvider.GetParameter(WorkLinkTable.FieldWorkFlowId));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter(WorkLinkTable.FieldWorkFlowId, workflowId) });              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断流程连线是否存在
        /// </summary>
        /// <param name="linkId">流程连线Id</param>
        /// <returns></returns>
        public bool LinkExist(string linkId)
        {
            if (linkId.Trim().Length == 0 || linkId == null)
                throw new Exception("LinkExist方法错误，linkId 不能为空！");

            //string tmpStr = "select * from WorkLink where WorkLinkId=@WorkLinkId";
            return this.Exists(WorkLinkTable.FieldWorkLinkId, linkId);
        }
    }
}
