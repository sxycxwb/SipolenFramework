using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// WorkFlowClassManager
    /// 流程分类
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 EricHu 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>EricHu</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkFlowClassManager
    {
        /// <summary>
        /// 新建一个流程分类模板
        /// </summary>
        /// <param name="entity">分类实体</param>
        /// <returns>增加成功后的主键</returns>
        public string InsertWorkflowClass(WorkFlowClassEntity entity)
        {
            string returnStr = string.Empty;
            if (entity.WFClassId.Trim().Length == 0 || entity.WFClassId == null)
                throw new Exception("InsertWorkFlowClass方法错误，WorkflowClassId 不能为空！");

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
        /// 修改一个流程分类
        /// </summary>
        /// <param name="entity">分类实体</param>
        /// <returns>受影响的行数</returns>
        public int UpdateWorkflowClass(WorkFlowClassEntity entity)
        {
            int returnInt = -1;
            if (entity.WFClassId.Trim().Length == 0 || entity.WFClassId == null)
                throw new Exception("UpdateWorkflowClass方法错误，WorkflowClassId 不能为空！");

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
        /// 删除指定流程分类
        /// </summary>
        /// <param name="workflowClassId">流程分类Id</param>
        /// <returns></returns>
        public int DeleteWorkflowClass(string workflowClassId)
        {
            try
            {
                //string tmpSql = "delete workflowclass where WFClassId=@WFClassId";
                return this.Delete(WorkFlowClassTable.FieldWFClassId, workflowClassId);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程分类的所有子分类列表
        /// </summary>
        /// <param name="fatherClassId">父分类Id</param>
        /// <returns>子分类table</returns>
        public DataTable GetChildWorkflowClass(string fatherClassId)
        {
            try
            {
                //string tmpStr = "select * from WorkFlowClass where  FatherId=@FatherId";//有效的树信息
                return this.GetDT(WorkFlowClassTable.FieldFatherId, fatherClassId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程分类下的所有流程列表
        /// </summary>
        /// <param name="classId">流程分类Id</param>
        /// <returns>流程分类列表</returns>
        public DataTable GetWorkflowsByClassId(string classId)
        {
            try
            {
               // string tmpStr = "select * from WorkFlow where WFClassId=@classId";
                return new WorkFlowTemplateManager(this.DBProvider).GetDT(WorkFlowTemplateTable.FieldWFClassId, classId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得流程分类实体
        /// </summary>
        /// <param name="classId">流程分类Id</param>
        /// <returns>分类实体</returns>
        public WorkFlowClassEntity GetWorkflowClassInfo(string classId)
        {
            try
            {
                //string tmpStr = "select * from workflowclass where WFClassId='" + classId + "'";
                return this.GetEntity(classId);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
