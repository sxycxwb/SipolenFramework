//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
    /// ModuleService
	/// 服务层
	/// 
	/// 修改记录
	///     2015-06-08 XuWangBin V3.0 增加返回List的方法。
	///     2014-03-18 XuWangBin V2.8 重构。
	///		2012-03-02 版本：1.0 XuWangBin 建立。
	///		
	/// 版本：3.0
	///
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class ModuleService : System.MarshalByRefObject, IModuleService
	{
        private readonly string serviceName = RDIFrameworkMessage.ModuleService;

        #region public DataTable GetDT(UserInfo userInfo):获取模块列表
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetDT);
            var dataTable = new DataTable(PiModuleTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                dataTable = moduleManager.GetDT(PiModuleTable.FieldDeleteMark, 0, PiModuleTable.FieldSortCode);
                dataTable.DefaultView.Sort = PiModuleTable.FieldSortCode;
                dataTable.TableName = PiModuleTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByCondition(UserInfo userInfo, string condition) 通过条件得到模块
        /// <summary>
        /// 通过条件得到模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="condition">条件表达式</param>
        /// <returns>数据库</returns>
        public DataTable GetDTByCondition(UserInfo userInfo, string condition)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(PiModuleTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(condition))
                {
                    condition = PiModuleTable.FieldDeleteMark + " = 0 ";
                }
                else
                {
                    condition += " AND " + PiModuleTable.FieldDeleteMark + " = 0 ";
                }
                dataTable = moduleManager.GetDTByCondition(condition);
                dataTable.DefaultView.Sort = PiModuleTable.FieldSortCode;
                dataTable.TableName = PiModuleTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public List<PiModuleEntity> GetList(UserInfo userInfo) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>列表</returns>
	    public List<PiModuleEntity> GetList(UserInfo userInfo)
	    {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetDT);
            List<PiModuleEntity> entityList = new List<PiModuleEntity>();
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
               var manager = new PiModuleManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiModuleTable.FieldDeleteMark, 0)
                };
                entityList = manager.GetList<PiModuleEntity>(parameters, PiModuleTable.FieldSortCode);
            });
            return entityList;
	    }
        #endregion 

        #region public DataTable GetDTByIds(UserInfo userInfo, string[] ids):按主键数组获取列表
        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">角色主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetDTByIds);
            var dataTable = new DataTable(PiRoleTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                dataTable = moduleManager.GetDT(PiModuleTable.FieldId, ids, PiModuleTable.FieldSortCode);
                dataTable = BusinessLogic.SetFilter(dataTable, PiModuleTable.FieldDeleteMark, "0");
                dataTable.TableName = PiModuleTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public PiModuleEntity GetEntity(UserInfo userInfo, string id):获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public PiModuleEntity GetEntity(UserInfo userInfo, string id)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetEntity);
            PiModuleEntity moduleEntity = null;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                moduleEntity = moduleManager.GetEntity(id);
            });
            return moduleEntity;
        }
        #endregion

        #region public string GetFullNameByCode(UserInfo userInfo, string code):通过编号获取模块名称
        /// <summary>
        /// 通过编号获取模块名称
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>数据表</returns>
        public string GetFullNameByCode(UserInfo userInfo, string code)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetFullNameByCode);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue = moduleManager.GetFullNameByCode(code);
            });
            return returnValue;
        }
        #endregion

        #region public string Add(UserInfo userInfo, PiModuleEntity moduleEntity, out string statusCode, out string statusMessage):添加模块菜单
        /// <summary>
        /// 添加模块菜单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        public string Add(UserInfo userInfo, PiModuleEntity moduleEntity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_Add);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = moduleManager.Add(moduleEntity, out returnCode);
                // 获得状态消息
                returnMessage = moduleManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int Update(UserInfo userInfo, PiModuleEntity moduleEntity, out string statusCode, out string statusMessage):更新模块菜单
        /// <summary>
        /// 更新模块菜单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, PiModuleEntity moduleEntity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_Update);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = moduleManager.Update(moduleEntity, out returnCode);
                // 获得状态消息
                returnMessage = moduleManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable GetDTByParent(UserInfo userInfo, string parentId):按父节点获得列表
        /// <summary>
        /// 按父节点获得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParent(UserInfo userInfo, string parentId)
        {
            var dataTable = new DataTable(PiModuleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetDTByParent);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                dataTable = moduleManager.GetDT(PiModuleTable.FieldDeleteMark, 0, PiModuleTable.FieldParentId, parentId);
                dataTable.DefaultView.Sort = PiModuleTable.FieldSortCode;
                dataTable.TableName = PiModuleTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id):删除模块
        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_Delete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue = moduleManager.Delete(id);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids):批量删除模块
        /// <summary>
        /// 批量删除模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchDelete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue = moduleManager.Delete(ids);
            });
            return returnValue;
        }
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids) 批量打删除标志
        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_SetDeleted);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue = moduleManager.SetDeleted(ids);
                //TODO 清除所有用户对应的模块权限等
            });
            
            return returnValue;
        }
        #endregion

        #region public int MoveTo(UserInfo userInfo, string moduleId, string parentId):移动模块菜单
        /// <summary>
        /// 移动模块菜单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>数据表</returns>
        public int MoveTo(UserInfo userInfo, string moduleId, string parentId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_MoveTo);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
               var moduleManager = new PiModuleManager(dbProvider, userInfo);
               returnValue = moduleManager.SetProperty(moduleId, PiModuleTable.FieldParentId, parentId);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchMoveTo(UserInfo userInfo, string[] moduleIds, string parentId):批量移动数据
        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleIds">模块主键数组</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>数据表</returns>
        public int BatchMoveTo(UserInfo userInfo, string[] moduleIds, string parentId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchMoveTo, "模块主键数组：" + BusinessLogic.ArrayToList(moduleIds) + ",父结点主键:" + parentId);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue += moduleIds.Sum(t => moduleManager.SetProperty(t, PiModuleTable.FieldParentId, parentId));
            });
            
            return returnValue;
        }
        #endregion

        #region public int BatchSave(UserInfo userInfo, DataTable dataTable):
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(UserInfo userInfo, DataTable dataTable)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchSave);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue = moduleManager.BatchSave(dataTable);
            });
            return returnValue;
        }
        #endregion

        #region public int SetSortCode(UserInfo userInfo, string[] ids):保存排序顺序
        /// <summary>
        /// 保存排序顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetSortCode(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_SetSortCode,"主键数组：" + BusinessLogic.ArrayToList(ids));            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (userInfo.IsAdministrator)
                {
                    PiModuleManager moduleManager = new PiModuleManager(dbProvider, userInfo);
                    returnValue = moduleManager.BatchSetSortCode(ids);
                }
            });

            return returnValue;
        }
        #endregion

        #region public DataTable GetPermissionDT(UserInfo userInfo, string moduleId) 获取关联的权限项列表
        /// <summary>
        /// 获取关联的权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetPermissionDT(UserInfo userInfo, string moduleId)
        {
            DataTable dataTable = new DataTable(PiPermissionTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetPermissionDT);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var modulePermissionManager = new PermissionModuleManager(dbProvider, userInfo);
                string[] ids = modulePermissionManager.GetPermissionIds(moduleId);
                var permissionAdminManager = new PiPermissionItemManager(dbProvider, userInfo);
                dataTable = permissionAdminManager.GetDT(ids);
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string[] GetIdsByPermission(UserInfo userInfo, string permissionItemId):菜单主健数组
        /// <summary>
        /// 菜单主健数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetIdsByPermission(UserInfo userInfo, string permissionItemId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_GetIdsByPermission);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var modulePermissionManager = new PermissionModuleManager(dbProvider, userInfo);
                returnValue = modulePermissionManager.GetModuleIds(permissionItemId);
            });

            return returnValue;
        }
        #endregion

        #region public string BatchAddPermissions(UserInfo userInfo, string moduleId, string[] permissionItemIds) 模块批量关联操作权限项
        /// <summary>
        /// 模块批量关联操作权限项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="permissionItemIds">权限主键</param>
        /// <returns>影响行数</returns>
        public int BatchAddPermissions(UserInfo userInfo, string moduleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchAddPermissions);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var modulePermissionManager = new PermissionModuleManager(dbProvider, userInfo);
                returnValue = modulePermissionManager.Add(moduleId, permissionItemIds);
            });
            
            return returnValue;
        }
        #endregion

        #region public int BatchAddModules(UserInfo userInfo, string permissionItemId, string[] moduleIds):操作权限项关联模块菜单
        /// <summary>
        /// 操作权限项关联模块菜单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="moduleIds">模块主键</param>
        /// <returns>影响行数</returns>
        public int BatchAddModules(UserInfo userInfo, string permissionItemId, string[] moduleIds)
        {    
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchAddModules);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var modulePermissionManager = new PermissionModuleManager(dbProvider, userInfo);
                returnValue = modulePermissionManager.Add(moduleIds, permissionItemId);
            });

            return returnValue;
        }
        #endregion

        #region public string BatchDeletePermissions(UserInfo userInfo, string moduleId, string[] permissionItemIds) 撤销模块菜单与操作权限项的关联
        /// <summary>
        /// 撤销模块菜单与操作权限项的关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="permissionItemIds">权限主键</param>
        /// <returns>影响行数</returns>
        public int BatchDeletePermissions(UserInfo userInfo, string moduleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchDletePermissions);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var modulePermissionManager = new PermissionModuleManager(dbProvider, userInfo);
                returnValue = modulePermissionManager.Delete(moduleId, permissionItemIds);
            });

            return returnValue;
        }
        #endregion

        #region public int BatchDeleteModules(UserInfo userInfo, string permissionItemId, string[] modulesIds):撤销操作权限项与模块菜单的关联
        /// <summary>
        /// 撤销操作权限项与模块菜单的关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="modulesIds">模块主键</param>
        /// <returns>影响行数</returns>
        public int BatchDeleteModules(UserInfo userInfo, string permissionItemId, string[] modulesIds)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ModuleService_BatchDleteModules);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var modulePermissionManager = new PermissionModuleManager(dbProvider, userInfo);
                returnValue = modulePermissionManager.Delete(modulesIds, permissionItemId);
            });
            return returnValue;
        }
        #endregion
    }
}
