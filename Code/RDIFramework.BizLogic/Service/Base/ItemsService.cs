//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
	/// ItemsService
	/// 服务层
	/// 
	/// 修改记录
	/// 
    ///     2015-04-03 版本：2.9 EricHu 新增：GetItemDetailDTByItemId
	///		2012-03-02 版本：1.0 EricHu 建立。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class ItemsService : System.MarshalByRefObject, IItemsService
	{
        private readonly string serviceName = RDIFrameworkMessage.ItemsService;

        #region public DataTable GetDT(UserInfo userInfo) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiItemsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var itemsManager = new CiItemsManager(dbProvider, userInfo);
                // 若是系统管理员，那就返回全部数据
                if (userInfo.IsAdministrator)
                {
                    dataTable = itemsManager.GetDT(CiItemsTable.FieldDeleteMark, 0, CiItemsTable.FieldSortCode);
                }
                else
                {
                    // 按数据权限来过滤数据
                    var permissionScopeManager = new PiPermissionScopeManager(dbProvider, userInfo);
                    string[] ids = permissionScopeManager.GetResourceScopeIds(userInfo.Id, CiItemsTable.TableName, "Resource.ManagePermission");
                    dataTable = itemsManager.GetDT(ids);
                }
                dataTable.TableName = CiItemsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByParent(UserInfo userInfo, string parentId) 按父节点获取列表
        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParent(UserInfo userInfo, string parentId)
        {
            var dataTable = new DataTable(CiItemsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_GetDTByParent);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var itemsManager = new CiItemsManager(dbProvider, userInfo);
                dataTable = itemsManager.GetDTByParent(parentId);
                dataTable.TableName = CiItemsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetItemDetailDTByItemId(UserInfo userInfo, string itemId) 根据数据字典主键得到字典明细数据
        /// <summary>
        /// 根据数据字典主键得到字典明细数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemId">父级主键</param>
        /// <returns>数据表</returns>
        public DataTable GetItemDetailDTByItemId(UserInfo userInfo, string itemId)
        {
            var dataTable = new DataTable(CiItemDetailsTable.TableName);
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var itemsDetailManager = new CiItemDetailsManager(dbProvider, userInfo);
                dataTable = itemsDetailManager.GetDT(CiItemDetailsTable.FieldItemId,itemId,CiItemDetailsTable.FieldDeleteMark,0,CiItemDetailsTable.FieldSortCode);
                dataTable.TableName = CiItemDetailsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public CiItemsEntity GetEntity(UserInfo userInfo, string id) 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiItemsEntity GetEntity(UserInfo userInfo, string id)
        {
            CiItemsEntity itemsEntity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_GetEntity);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var itemsManager = new CiItemsManager(dbProvider, userInfo);
                itemsEntity = itemsManager.GetEntity(id);
            });
            return itemsEntity;
        }
        #endregion

        #region public string Add(UserInfo userInfo, BaseItemsEntity itemsEntity, out string statusCode, out string statusMessage) 添加实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public string Add(UserInfo userInfo, CiItemsEntity itemsEntity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            string returnValue = string.Empty;

            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_Add);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var itemsManager = new CiItemsManager(dbProvider, userInfo) {Identity = true, ReturnId = false};
                returnValue = itemsManager.Add(itemsEntity, out returnCode);
                returnMessage = itemsManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int Update(UserInfo userInfo, BaseItemsEntity itemsEntity, out string statusCode, out string statusMessage) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public int Update(UserInfo userInfo, CiItemsEntity itemsEntity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_Update);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var itemsManager = new CiItemsManager(dbProvider, userInfo);
                returnValue = itemsManager.Update(itemsEntity, out returnCode);
                returnMessage = itemsManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public void CreateTable(UserInfo userInfo, string tableName, out string statusCode, out string statusMessage) 创建数据表
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">表名</param>
        /// <param name="statusCode">状态返回码</param>
        /// <param name="statusMessage">状态返回信息</param>
        public void CreateTable(UserInfo userInfo, string tableName, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;

            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_CreateTable);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var itemsManager = new CiItemsManager(dbProvider, userInfo);
                itemsManager.CreateTable(tableName, out returnCode);
                returnMessage = itemsManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string tableName, string id) 删除
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="id">主键</param>
        /// <returns>影响的行数</returns>
        public int Delete(UserInfo userInfo, string tableName, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ItemsService_Delete);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new CiItemsManager(dbProvider, userInfo, tableName).Delete(id);
            });
            return returnValue;
        }
        #endregion	

        #region public int SetDeleted(UserInfo userInfo, string[] ids) 批量删除标志
        /// <summary>
        /// 批量删除标志
		/// </summary>
		/// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
		/// <returns>受影响的行数</returns>
        public int SetDeleted(UserInfo userInfo, string[] ids)
		{
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "SetDeleted");
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new CiItemsManager(dbProvider, userInfo);
                returnValue = manager.SetDeleted(ids);
            });
			return returnValue;
        }
        #endregion
    }
}
