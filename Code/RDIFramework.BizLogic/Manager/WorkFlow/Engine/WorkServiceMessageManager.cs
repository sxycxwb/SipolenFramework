using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// WorkServiceMessageManager
    /// 
    /// 
    /// 修改纪录
    /// 
    ///     2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkServiceMessageManager
    {
        /// <summary>
        /// 增加WorkServiceMessage
        /// </summary>
        /// <param name="entity">WorkServiceMessageEntity实体</param>
        /// <returns>增加成功后的主键</returns>
        public string Insert(WorkServiceMessageEntity entity)
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

        /// <summary>
        /// 更新WorkServiceMessage
        /// </summary>
        /// <param name="entity">orkTaskCommandsEntity</param>
        /// <returns>受影响的行数</returns>
        public int UpdateWorkServiceMessage(WorkServiceMessageEntity entity)
        {
            int returnInt = -1;
            if (entity.MessageId.Trim().Length == 0 || entity.MessageId == null)
                throw new Exception("Update方法错误，MessageId不能为空！");
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
        /// 获得WorkServiceMessage表
        /// </summary>
        /// <param name="messageid">主键</param>
        /// <returns>WorkServiceMessage表</returns>
        public DataTable GetWorkServiceMessageTable(string messageid)
        {
            try
            {
                return this.GetDT(WorkServiceMessageTable.FieldMessageId, messageid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到WorkTaskCommandsEntity
        /// </summary>
        /// <param name="messageid">主键</param>
        /// <returns>WorkTaskCommandsEntity</returns>
        public WorkTaskCommandsEntity GetWorkServiceMessageInfo(string messageid)
        {
            WorkTaskCommandsEntity entity = null;
            DataTable dt = GetWorkServiceMessageTable(messageid);
            if (dt != null && dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<WorkTaskCommandsEntity>(dt);
            }

            return entity;
        }

        /// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <param name="messageid">主键</param>
        /// <returns></returns>
        public int DeleteWorkServiceMessage(string messageid)
        {
            try
            {
                return this.Delete(WorkServiceMessageTable.FieldMessageId, messageid);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
