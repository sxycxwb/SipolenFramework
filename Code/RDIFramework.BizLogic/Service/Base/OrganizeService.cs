/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-3-30 13:02:31
 ******************************************************************************/

using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
    /// OrganizeService
	/// 服务层
	/// 
	/// 修改记录
	///     2015-04-11 V2.9 王进 修改删除组织机构时同步删除员工组织机构关联出现的问题。
    ///     2014-05-29 V2.8 EricHu 更新组织机构时，同步更新用户表的公司、分公司、部门、子部门、工作组。
    ///     2014-05-28 v2.8 EricHu 增加 GetChildrensById方法。
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
	public class OrganizeService : System.MarshalByRefObject, IOrganizeService
	{
        private string serviceName = RDIFrameworkMessage.OrganizeService;

        #region public string Add(UserInfo userInfo, PiOrganizeEntity entity,out string statusCode, out string statusMessage) 新增实体
        /// <summary>
        /// 新增实体 
		/// </summary>
		/// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码信息</param>
		/// <param name="statusMessage">返回狀態訊息</param>
		/// <returns>主鍵</returns>
        public string Add(UserInfo userInfo, PiOrganizeEntity entity,out string statusCode, out string statusMessage)
		{
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_Add);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                returnValue = manager.AddEntity(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public int Update(UserInfo userInfo, PiOrganizeEntity entity, out string statusMessage) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusMessage">返回狀態訊息</param>
        /// <returns>影响的行数</returns>
        public int Update(UserInfo userInfo, PiOrganizeEntity entity, out string statusMessage)
        {
            int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_Update);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                returnValue = manager.Update(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable GetDT(UserInfo userInfo) 取得列表
        /// <summary>
		/// 取得列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <returns>DataTable</returns>
		public DataTable GetDT(UserInfo userInfo)
		{
			var dataTable = new DataTable(PiOrganizeTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                dataTable = manager.GetDT(PiOrganizeTable.FieldDeleteMark, 0, PiOrganizeTable.FieldSortCode);
                dataTable.TableName = PiOrganizeTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public List<PiOrganizeEntity> GetList(UserInfo userInfo)  取得列表
        /// <summary>
        /// 取得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>List</returns>
        public List<PiOrganizeEntity> GetList(UserInfo userInfo)
        {
            List<PiOrganizeEntity> list = new List<PiOrganizeEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = manager.GetList<PiOrganizeEntity>(parameters, PiOrganizeTable.FieldSortCode);
            });
            return list;
        }
        #endregion

        #region public DataTable GetDTByParent(UserInfo userInfo, string parentId) 按父节点获取列表
        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParent(UserInfo userInfo, string parentId)
        {
            var dataTable = new DataTable(PiOrganizeTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_GetDTByParent);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var organizeManager = new PiOrganizeManager(dbProvider, userInfo);
                dataTable = organizeManager.GetDT(PiOrganizeTable.FieldParentId, parentId, PiOrganizeTable.FieldDeleteMark, 0, PiOrganizeTable.FieldSortCode);
                dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
                dataTable.TableName = PiOrganizeTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public List<PiOrganizeEntity> GetListByParent(UserInfo userInfo, string parentId) 按父节点获取列表
        /// <summary>
        /// 按父节点获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点</param>
        /// <returns>List</returns>
        public List<PiOrganizeEntity> GetListByParent(UserInfo userInfo, string parentId)
        {
            List<PiOrganizeEntity> list = new List<PiOrganizeEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_GetDTByParent);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var organizeManager = new PiOrganizeManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldParentId, parentId),
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = organizeManager.GetList<PiOrganizeEntity>(parameters, PiOrganizeTable.FieldSortCode);
            });
            return list;
        }
        #endregion

        #region public PiOrganizeEntity GetEntity(UserInfo userInfo, string id) 取得实体
        /// <summary>
		/// 取得实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主鍵</param>
		/// <returns>实体</returns>
		public PiOrganizeEntity GetEntity(UserInfo userInfo, string id)
		{
			PiOrganizeEntity entity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_GetEntity);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                entity = manager.GetEntity(id);
            });
			return entity;
		}
        #endregion

        #region public DataTable GetDTByIds(UserInfo userInfo, string[] ids) 依主键数组得到数据
        /// <summary> 
		/// 依主键数组得到数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主鍵</param>
		/// <returns>DataTable</returns>
		public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
		{
			var dataTable = new DataTable(PiOrganizeTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_GetDTByIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                dataTable = manager.GetDT(PiOrganizeTable.FieldId, ids, PiOrganizeTable.FieldSortCode);
                dataTable.TableName = PiOrganizeTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values) 依据相应条件获取数据
        /// <summary>
		/// 依据相应条件获取数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="names">字段</param>
		/// <param name="values">值</param>
		/// <returns>DataTable</returns>
		public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values)
		{
			var dataTable = new DataTable(PiOrganizeTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                dataTable = manager.GetDT(names, values);
                dataTable.TableName = PiOrganizeTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public int BatchSave(UserInfo userInfo, DataTable dataTable) 批量保存数据
        /// <summary>
		/// 批量保存数据
		/// </summary>
		/// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
		/// <returns>影响的行数</returns>
        public int BatchSave(UserInfo userInfo, DataTable dataTable)
		{
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_BatchSave);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var organizeManager = new PiOrganizeManager(dbProvider, userInfo);
                returnValue = organizeManager.BatchSave(dataTable);
            });

            return returnValue;
		}
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 物理刪除数据
        /// <summary>
		/// 物理刪除数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主鍵</param>
		/// <returns>DataTable</returns>
		public int Delete(UserInfo userInfo, string id)
		{	
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                returnValue = manager.Delete(id);
            });
			return returnValue;
		}
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量物理删除数据
        /// <summary>
		/// 批量物理删除数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响的行数</returns>
		public int BatchDelete(UserInfo userInfo, string[] ids)
		{
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                if (ids != null) returnValue = manager.Delete(ids);
            });
			return returnValue;
		}
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids) 批量置删除标志
        /// <summary>
		/// 批量置删除标志
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响的行数</returns>
		public int SetDeleted(UserInfo userInfo, string[] ids)
		{
			int returnValue = 0;
            if (ids == null || ids.Length <= 0)
            {
                return returnValue;
            }

            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_SetDeleted);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                for (int pos = 0; pos < ids.Length; pos++)
                {
                    //逻辑删除组织机构
                    returnValue += manager.SetDeleted(ids[pos]);
                    //同步处理用户表组织机构相关数据
                    var userManager = new PiUserManager(dbProvider, userInfo);
                    var parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiUserTable.FieldCompanyId, null),
                        new KeyValuePair<string, object>(PiUserTable.FieldCompanyName, null)
                    };
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldCompanyId, ids[pos]), parameters);
                    parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiUserTable.FieldSubCompanyId, null),
                        new KeyValuePair<string, object>(PiUserTable.FieldSubCompanyName, null)
                    };
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldSubCompanyId, ids[pos]), parameters);
                    parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiUserTable.FieldDepartmentId, null),
                        new KeyValuePair<string, object>(PiUserTable.FieldDepartmentName, null)
                    };
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldDepartmentId, ids[pos]), parameters);
                    parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiUserTable.FieldSubDepartmentId, null),
                        new KeyValuePair<string, object>(PiUserTable.FieldSubDepartmentName, null)
                    };
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldSubDepartmentId, ids[pos]), parameters);
                    parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiUserTable.FieldWorkgroupId, null),
                        new KeyValuePair<string, object>(PiUserTable.FieldWorkgroupName, null)
                    };
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldWorkgroupId, ids[pos]), parameters);
                    //同步处理员工表组织机构相关数据
                    var staffOrganizeManager = new PiStaffOrganizeManager(dbProvider, userInfo);
                    parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiStaffOrganizeTable.FieldOrganizeId, ids[pos])
                    };
                    staffOrganizeManager.SetDeleted(parameters,true);
                }
            });
			return returnValue;
		}
        #endregion

        #region public int MoveTo(UserInfo userInfo, string organizeId, string parentId) 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构</param>
        /// <param name="parentId">父主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(UserInfo userInfo, string organizeId, string parentId)
        {          
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_MoveTo, "组织机构：" + organizeId + "，父节点：" + parentId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var organizeManager = new PiOrganizeManager(dbProvider, userInfo);
                returnValue = organizeManager.MoveTo(organizeId, parentId);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchMoveTo(UserInfo userInfo, string[] organizeIds, string parentId)  批量移动数据
        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">主键数组</param>
        /// <param name="parentId">父节点主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(UserInfo userInfo, string[] organizeIds, string parentId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.OrganizeService_BatchMoveTo, "主键数组：" + BusinessLogic.ArrayToList(organizeIds) + "，父节点：" + parentId);
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var organizeManager = new PiOrganizeManager(dbProvider, userInfo);
                returnValue += organizeIds.Sum(t => organizeManager.MoveTo(t, parentId));
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetChildrensById(UserInfo userInfo, string organizeId) 根据组织机构主键获取其指定分类下的子节点列表
        /// <summary>
        /// 根据组织机构主键获取其指定分类下的子节点列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="organizeId">组织机构主键</param>      
        /// <returns></returns>
        public DataTable GetChildrensById(UserInfo userInfo, string organizeId)
        {
            var dataTable = new DataTable(PiOrganizeTable.TableName);
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiOrganizeManager(dbProvider, userInfo);
                dataTable = manager.GetChildrens(PiOrganizeTable.FieldId, organizeId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldSortCode,false);
                dataTable.TableName = PiOrganizeTable.TableName;
            });
            return dataTable;
        }
        #endregion
    }
}
