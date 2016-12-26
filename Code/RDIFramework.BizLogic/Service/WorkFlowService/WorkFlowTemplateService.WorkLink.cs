using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程连线实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertWorkLink(UserInfo userInfo, WorkLinkEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkLink);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkLinkManager(dbProvider, userInfo);
                returnValue = manager.InsertLink(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 更新流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程连线实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkLink(UserInfo userInfo, WorkLinkEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkLink);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkLinkManager(dbProvider, userInfo);
                returnValue = manager.UpdateLink(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workLinkId">流程连线Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkLine(UserInfo userInfo, string workFlowId, string workLinkId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkLine);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkLinkManager(dbProvider, userInfo);
                returnValue = manager.DeleteLine(workFlowId, workLinkId);
            });
            return returnValue;
        }


        /// <summary>
        /// 获得流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>流程连线列表</returns>
        public DataTable GetWorkLinks(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkLinks);
            var dataTable = new DataTable(WorkLinkTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkLinkManager(dbProvider, userInfo);
                dataTable = manager.GetWorkLinks(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 判断流程连线是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="linkId">流程连线Id</param>
        /// <returns>true存在</returns>
        public bool ExistsWorkLink(UserInfo userInfo, string linkId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_ExistsWorkLink);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkLinkManager(dbProvider, userInfo);
                returnValue = manager.LinkExist(linkId);
            });
            return returnValue;
        }
    }
}
