using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowUserControlService
    {
        /// <summary>
        /// 新增子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子表单实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertUserControl(UserInfo userInfo, UserControlsEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_InsertUserControl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                returnValue = manager.InsertUserControl(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改一个子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子表单实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateUserControl(UserInfo userInfo, UserControlsEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_UpdateUserControl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                returnValue = manager.UpdateUserControl(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除一个子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteUserControl(UserInfo userInfo, string userControlId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_DeleteUserControl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                returnValue = manager.DeleteUserControl(userControlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 逻辑删除子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">主表单Id</param>
        /// <returns>大于0成功</returns>
        public int SetDeletedUserControl(UserInfo userInfo, string userControlId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_SetDeletedUserControl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                returnValue = manager.SetDeleted(userControlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除子表单隶属的组关系
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteMainCtrlsOfUser(UserInfo userInfo, string userControlId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_DeleteMainCtrlsOfUser);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                returnValue = manager.DeleteMainCtrlsOfUser(userControlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得所有子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>子表单列表</returns>
        public DataTable GetAllChildUserControls(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(UserControlsTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                dataTable = manager.GetAllChildUserControls();
            });
            return dataTable;
        }

        /// <summary>
        /// 获得主表单分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetUserControlByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0, int pageSize = 50, string order = null)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                string whereExpression = UserControlsTable.FieldDeleteMark + " = 0 ";
                if (!string.IsNullOrEmpty(search))
                {
                    whereExpression += " AND " + search;
                }
                order = string.IsNullOrEmpty(order) ? UserControlsTable.FieldSortCode : order;

                dataTable = manager.GetDTByPage(out myrecordCount, pageIndex, pageSize, whereExpression, order);
            });
            recordCount = myrecordCount;
            return dataTable;
        }

        /// <summary>
        /// 获得指定子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单主键</param>
        /// <returns>子表单列表</returns>
        public DataTable GetChildUserControl(UserInfo userInfo, string userControlId)
        {
            var dataTable = new DataTable(UserControlsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetChildUserControl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                dataTable = manager.GetChildUserControl(userControlId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得子表单隶属的主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userControlId">子表单id</param>
        /// <returns>子表单隶属的主表单列表</returns>
        public DataTable GetMainCtrlsOfChild(UserInfo userInfo, string userControlId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(UserControlsTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new UserControlsManager(dbProvider, userInfo);
                dataTable = manager.GetMainCtrlsOfChild(userControlId);
            });
            return dataTable;
        }
    }
}
