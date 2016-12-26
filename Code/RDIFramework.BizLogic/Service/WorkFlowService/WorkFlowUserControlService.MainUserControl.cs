using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowUserControlService
    {
        /// <summary>
        /// 增加主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">主表单实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertMainUserCtrl(UserInfo userInfo, MainUserControlEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_InsertMainUserCtrl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.InsertMainUserCtrl(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 更新主表单知
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">主表单实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateMainUserCtrl(UserInfo userInfo, MainUserControlEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_UpdateMainUserCtrl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.UpdateMainUserCtrl(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得一个主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主表单主键</param>
        /// <returns>主表单表</returns>
        public DataTable GetMainUserControl(UserInfo userInfo, string id)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetMainUserControl);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetMainUserControl(id);
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
        public DataTable GetMainUserControlByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0, int pageSize = 50, string order = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetMainUserControlByPage);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                string whereExpression = MainUserControlTable.FieldDeleteMark + " = 0 ";
                if (!string.IsNullOrEmpty(search))
                {
                    whereExpression += " AND " + search;
                }
                order = string.IsNullOrEmpty(order) ? MainUserControlTable.FieldSortCode : order;

                dataTable = manager.GetDTByPage(out myrecordCount, pageIndex, pageSize, whereExpression, order);
            });
            recordCount = myrecordCount;
            return dataTable;
        }

        /// <summary>
        /// 根据表单名称获得一个主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">表单名</param>
        /// <returns>主表单列表</returns>
        public DataTable GetMainUserControlByFullName(UserInfo userInfo, string fullName)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetMainUserControlByFullName);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetMainUserControlByCaption(fullName);
            });
            return dataTable;
        }

        /// <summary>
        /// 删除主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主表单Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteMainUserCtrl(UserInfo userInfo, string id)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_DeleteMainUserCtrl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.DeleteMainUserCtrl(id);
            });
            return returnValue;
        }

        /// <summary>
        /// 逻辑删除主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主表单Id</param>
        /// <returns>大于0成功</returns>
        public int SetDeletedMainUserCtrl(UserInfo userInfo, string id)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_SetDeletedMainUserCtrl);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.SetDeleted(id);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得主表单的所有子表单列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单Id</param>
        /// <returns>子表单列表</returns>
        public DataTable GetAllChildUserControlsById(UserInfo userInfo, string mainUserCtrlId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetAllChildUserControlsById);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetAllChildUserControlsById(mainUserCtrlId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得所有主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>主表单列表</returns>
        public DataTable GetAllMainUserControls(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetAllMainUserControls);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetAllMainUserControls();
            });
            return dataTable;
        }

        /// <summary>
        /// 增加子表单到主表单中
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <param name="controlOrder">顺序号,以此排序</param>
        /// <param name="controlState">子表单状态</param>
        /// <returns>增加成功返回主键</returns>
        public string AddUserControls(UserInfo userInfo, string mainUserCtrlId, string userContrlsId, int controlOrder, string controlState)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_AddUserControls);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.AddUserControls(mainUserCtrlId, userContrlsId, controlOrder, controlState);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <returns>大于0成功</returns>
        public int MoveUserControls(UserInfo userInfo, string mainUserCtrlId, string userContrlsId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_MoveUserControls);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.MoveUserControls(mainUserCtrlId,userContrlsId);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改主表单下指定子表单的状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <param name="controlState">状态</param>
        /// <returns>大于0成功</returns>
        public int EditMainUserControlsState(UserInfo userInfo, string mainUserCtrlId, string userContrlsId,string controlState = "查看")
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_EditMainUserControlsState);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.EditMainUserControlsState(mainUserCtrlId, userContrlsId, controlState);
            });
            return returnValue;
        }

        /// <summary>
        /// 移除所有子表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <returns>大于0成功</returns>
        public int MoveUserControlsOfMain(UserInfo userInfo, string mainUserCtrlId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_MoveUserControlsOfMain);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.MoveUserControlsOfMain(mainUserCtrlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 得到工作流所有的工作任务表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版主键</param>
        /// <returns>工作任务表单列表</returns>
        public DataTable GetWorkFlowAllControlsLink(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetWorkFlowAllControlsLink);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllControlsLink(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到指定工作流所有的主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版主键</param>
        /// <returns>工作流所有的主表单列表</returns>
        public DataTable GetWorkFlowAllMainControls(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetWorkFlowAllMainControls);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllMainControls(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到指定流程所有的子表单列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版主键</param>
        /// <returns>表单列表</returns>
        public DataTable GetWorkFlowAllControls(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_GetWorkFlowAllControls);
            var dataTable = new DataTable(MainUserControlTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllControls(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 是否存在指定工作任务表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskControlId">工作流程Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        public bool ExistsTaskControls(UserInfo userInfo, string taskControlId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var returnValue = false;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.ExistsTaskControls(taskControlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 是否存在指定主表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="mainUserCtrlId">主表单Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        public bool ExistsMainControls(UserInfo userInfo, string mainUserCtrlId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var returnValue = false;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.ExistsMainControls(mainUserCtrlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 是否存在指定用户表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userCtrlId">用户表单Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        public bool ExistsUserControls(UserInfo userInfo, string userCtrlId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var returnValue = false;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.ExistsUserControls(userCtrlId);
            });
            return returnValue;
        }

        /// <summary>
        /// 是否存在指定主子表单关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ctrlLinkId">关联Id</param>
        /// <returns>
        /// true：存在
        /// false:不存在 
        /// </returns>
        public bool ExistsControlsLink(UserInfo userInfo, string ctrlLinkId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var returnValue = false;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new MainUserControlManager(dbProvider, userInfo);
                returnValue = manager.ExistsControlsLink(ctrlLinkId);
            });
            return returnValue;
        }
    }
}
