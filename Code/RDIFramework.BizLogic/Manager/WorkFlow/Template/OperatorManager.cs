using System;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// OperatorManager
    /// 处理者
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class OperatorManager
    {
        /// <summary>
        /// 增加处理者
        /// </summary>
        /// <param name="entity">处理者实体</param>
        /// <returns></returns>
        public string InsertOperator(OperatorEntity entity)
        {
            string returnString = string.Empty;
            if (entity.OperatorId.Trim().Length == 0 || entity.OperatorId == null)
                throw new Exception("InsertOperator方法错误，OperatorId 不能为空！");
            try
            {
                returnString = this.AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnString;
        }

        /// <summary>
        /// 修改处理者
        /// </summary>
        /// <param name="entity">处理者实体</param>
        public int UpdateOperator(OperatorEntity entity)
        {
            int returnInt = -1;
            if (entity.OperatorId.Trim().Length == 0 || entity.OperatorId == null)
                throw new Exception("UpdateOperator方法错误，OperatorId 不能为空！");
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
        /// 删除一个处理者
        /// </summary>
        /// <param name="operatorId">处理者主键</param>
        /// <returns></returns>
        public int DeleteOperator(string operatorId)
        {
            try
            {
                return this.Delete(OperatorTable.FieldOperatorId, operatorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到处理者表
        /// </summary>
        /// <param name="operId">处理者主键</param>
        /// <returns></returns>
        public DataTable GetOperatorTable(string operId)
        {
            try
            {
                //string tmpStr = "select * from Operator where  OperatorId=@OperatorId";
                return this.GetDT(OperatorTable.FieldOperatorId, operId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定流程模版所有的处理者
        /// </summary>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns></returns>
        public DataTable GetWorkFlowAllOperator(string workFlowId)
        {
            try
            {
                string tmpStr = string.Format("SELECT * FROM OPERATOR WHERE  WORKFLOWID={0}", DBProvider.GetParameter(OperatorTable.FieldWorkFlowId));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter(OperatorTable.FieldWorkFlowId, workFlowId) });   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得模板中的处理者
        /// </summary>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>模板中的处理者</returns>
        public string GetOperContent(string operatorId)
        {
            try
            {
                //string tmpStr = "select OperContent from Operator where OperatorId=@operatorId";
                return this.GetProperty(OperatorTable.FieldOperatorId, operatorId, OperatorTable.FieldOperContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得处理者策略
        /// </summary>
        /// <param name="operatorId">处理者Id</param>
        /// <returns></returns>
        public string GetOperRelation(string operatorId)
        {
            try
            {
                // string tmpStr = "select Relation from WorkTask where OperatorId=@operatorId";
                return this.GetProperty(OperatorTable.FieldOperatorId, operatorId, OperatorTable.FieldRelation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否存在指定处理者
        /// </summary>
        /// <param name="operatorId">处理者主键</param>
        /// <returns></returns>
        public bool Exists(string operatorId)
        {
            //string tmpSql = "select * from operator where OperatorId=@operatorId";
            return this.Exists(OperatorTable.FieldOperatorId, operatorId);           
        }
    }
}
