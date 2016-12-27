using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	
	/// <summary>
    /// PermissionItemService
    /// 权限操作服务
	/// 
	/// 修改记录
	/// 
	///		2012-03-02 版本：1.0 XuWangBin 建立。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class PermissionItemService : System.MarshalByRefObject, IPermissionItemService
	{
        private readonly string serviceName = RDIFrameworkMessage.PermissionItemService;

        /// <summary>
        /// RDIFramework.NET框架数据库连接
        /// </summary>
        private readonly string RDIFrameworkDbConection = SystemInfo.RDIFrameworkDbConection;

        #region public string Add(UserInfo userInfo, PiPermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage) 添加操作权限项
        /// <summary>
        /// 添加操作权限项
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="permissionItemEntity">权限定义实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(UserInfo userInfo, PiPermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_Add);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                returnValue = permissionItemManager.Add(permissionItemEntity, out returnCode);
                returnMessage = permissionItemManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public string AddByDetail(UserInfo userInfo, string code, string fullName, out string statusCode, out string statusMessage) 按详细信息添加
        /// <summary>
        /// 按详细信息添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddByDetail(UserInfo userInfo, string code, string fullName, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "按详细信息添加");

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                returnValue = permissionItemManager.AddByDetail(code, fullName, out returnCode);
                returnMessage = permissionItemManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region  public DataTable GetDT(UserInfo userInfo) 获取权限项列表
        /// <summary>
        /// 获取权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiPermissionItemTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiPermissionItemManager(dbProvider, userInfo).GetDT(PiPermissionItemTable.FieldDeleteMark, 0, PiPermissionItemTable.FieldSortCode);
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region  public List<PiPermissionItemEntity> GetList(UserInfo userInfo) 获取权限项列表
        /// <summary>
        /// 获取权限项列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public List<PiPermissionItemEntity> GetList(UserInfo userInfo)
        {
            List<PiPermissionItemEntity> list = new List<PiPermissionItemEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiPermissionItemManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = manager.GetList<PiPermissionItemEntity>(parameters, PiPermissionItemTable.FieldSortCode);
            });
            return list;
        }
        #endregion

        #region public DataTable GetDTByParent(UserInfo userInfo, string parentId) 按父节点获取列表
        /// <summary> 
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParent(UserInfo userInfo, string parentId)
        {
            var dataTable = new DataTable(PiPermissionItemTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetDTByParent);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiPermissionItemManager(dbProvider, userInfo).GetDT(PiPermissionItemTable.FieldParentId, parentId, PiPermissionItemTable.FieldDeleteMark, 0, PiPermissionItemTable.FieldSortCode);
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public List<PiPermissionItemEntity> GetListByParent(UserInfo userInfo, string parentId) 按父节点获取列表
        /// <summary> 
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>数据表</returns>
        public List<PiPermissionItemEntity> GetListByParent(UserInfo userInfo, string parentId)
        {
            List<PiPermissionItemEntity> list = new List<PiPermissionItemEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetDTByParent);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiPermissionItemManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldParentId, parentId),
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = manager.GetList<PiPermissionItemEntity>(parameters, PiPermissionItemTable.FieldSortCode);
            });
            return list;
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
            var dataTable = new DataTable(PiRoleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetDTByIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiPermissionItemManager(dbProvider, userInfo).GetDT(PiPermissionItemTable.FieldId, ids, PiPermissionItemTable.FieldSortCode);
                dataTable = BusinessLogic.SetFilter(dataTable, PiPermissionItemTable.FieldDeleteMark, "0");
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetLicensedDT(UserInfo userInfo, string userId) 获取授权范围
        /// <summary>
        /// 获取授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetLicensedDT(UserInfo userInfo, string userId)
        {
            var dataTable = new DataTable(PiPermissionItemTable.TableName);
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var permissionAdminManager = new PiPermissionItemManager(dbProvider, userInfo);
                var permissionItemId = permissionAdminManager.GetId(PiPermissionItemTable.FieldDeleteMark, 0, PiPermissionItemTable.FieldCode, "Resource.ManagePermission");
                dataTable = permissionAdminManager.GetDTByUser(userId, permissionItemId);
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public PiPermissionItemEntity GetEntity(UserInfo userInfo, string id) 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public PiPermissionItemEntity GetEntity(UserInfo userInfo, string id)
        {
            var permissionItemEntity = new PiPermissionItemEntity();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetEntity);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                var returnDataTable = new DataTable(PiPermissionItemTable.TableName);
                returnDataTable = permissionItemManager.GetDTById(id);
                permissionItemEntity = BaseEntity.Create<PiPermissionItemEntity>(returnDataTable);
            });
            return permissionItemEntity;
        }
        #endregion

        #region public PiPermissionItemEntity GetEntityByCode(UserInfo userInfo, string code) 按编号获取实体
        /// <summary>
        /// 按编号获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>实体</returns>
        public PiPermissionItemEntity GetEntityByCode(UserInfo userInfo, string code)
        {
            PiPermissionItemEntity permissionItemEntity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_GetEntityByCode);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                permissionItemEntity = BaseEntity.Create<PiPermissionItemEntity>(new PiPermissionItemManager(dbProvider, userInfo).GetDTByCode(code));                
            });
            return permissionItemEntity;
        }
        #endregion

        #region public int Update(UserInfo userInfo, PiPermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, PiPermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage)
        {
            var returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_Update);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                returnValue = permissionItemManager.Update(permissionItemEntity, out returnCode);
                returnMessage = permissionItemManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;

            return returnValue;
        }
        #endregion

        #region public int MoveTo(UserInfo userInfo, string permissionItemId, string parentId) 移动实体
        /// <summary>
        /// 移动实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限项主键</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(UserInfo userInfo, string permissionItemId, string parentId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_MoveTo, "权限项主键：" + permissionItemId + ",父主键:" + parentId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionItemManager(dbProvider, userInfo).MoveTo(permissionItemId, parentId);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchMoveTo(UserInfo userInfo, string[] permissionItemIds, string parentId) 批量移动实体
        /// <summary>
        /// 批量移动实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemIds">权限项主键数组</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(UserInfo userInfo, string[] permissionItemIds, string parentId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_BatchMoveTo);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                returnValue += permissionItemIds.Sum(t => permissionItemManager.MoveTo(t, parentId));
            });

            return returnValue;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_Delete, "主键：" + id);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionItemManager(dbProvider, userInfo).Delete(id);
            });

            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_BatchDelete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionItemManager(dbProvider, userInfo).Delete(ids);
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
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_SetDeleted);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionItemManager(dbProvider, userInfo).SetDeleted(ids);
            });

            return returnValue;
        }
        #endregion

        #region public int BatchSave(UserInfo userInfo, DataTable dataTable) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(UserInfo userInfo, DataTable dataTable)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_BatchSave);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionItemManager(dbProvider, userInfo).BatchSave(dataTable);
            });

            return returnValue;
        }
        #endregion

        #region public int BatchSetSortCode(UserInfo userInfo, string[] ids) 重新生成排序码
        /// <summary>
        /// 重新生成排序码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetSortCode(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionItemService_BatchSetSortCode);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiPermissionItemManager(dbProvider, userInfo).BatchSetSortCode(ids);
            });

            return returnValue;
        }
        #endregion

        #region public string[] GetIdsByModule(UserInfo userInfo, string moduleId)  得到指定模块的操作权限主健数组
        /// <summary>
        /// 得到指定模块的操作权限主健数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <returns>主键数组</returns>
        public string[] GetIdsByModule(UserInfo userInfo, string moduleId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new PermissionModuleManager(dbProvider, userInfo).GetPermissionIds(moduleId);
            });
            return returnValue;
        }
        #endregion
    }
}
