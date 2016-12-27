//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
	/// StaffService
    /// 员工服务
	/// 
	/// 修改紀錄
    ///     2014-05-29 版本：2.8 XuWangBin 增加:GetDTNotOrganize接口实现。
    ///     2013-08-12 版本：2.5 XuWangBin 增加“GetDTByPage”按分页获取数据，满足Web分页的要求。
	///		2012-03-02 版本：1.0 XuWangBin 建立檔案。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class StaffService : System.MarshalByRefObject, IStaffService
	{
        private readonly string serviceName = RDIFrameworkMessage.StaffService;
		
        #region public string Add(UserInfo userInfo, PiStaffEntity entity, out string statusCode, out string statusMessage, string organizeId = "") 添加员工
        /// <summary>
        /// 添加员工
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回消息</param>
        /// <param name="organizeId">组织机构主键</param>
		/// <returns>主鍵</returns>
        public string Add(UserInfo userInfo, PiStaffEntity entity, out string statusCode, out string statusMessage, string organizeId = "")
		{
			string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_AddStaff);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new PiStaffManager(dbProvider, userInfo);
                returnValue = manager.Add(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);

                if (returnValue.Length > 0 && returnCode == StatusCode.OKAdd.ToString() && !string.IsNullOrEmpty(organizeId.Trim()))
                {
                    var staffOrganizeEntity = new PiStaffOrganizeEntity
                    {
                        StaffId = BusinessLogic.ConvertToString(returnValue),
                        OrganizeId = BusinessLogic.ConvertToString(organizeId),
                        Enabled = 1,
                        DeleteMark = 0
                    };
                    var staffOrganizeManager = new PiStaffOrganizeManager(dbProvider, userInfo);
                    staffOrganizeManager.Add(staffOrganizeEntity);
                }
            });

            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public DataTable GetDT(UserInfo userInfo) 获取员工列表
        /// <summary>
        /// 获取员工列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <returns>数据表</returns>
		public DataTable GetDT(UserInfo userInfo)
		{
			var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiStaffManager(dbProvider, userInfo).GetDT(PiStaffTable.FieldDeleteMark, 0, PiStaffTable.FieldSortCode);
                dataTable.TableName = PiStaffTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "") 获取员工分页列表
        /// <summary>
        /// 获取员工分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有员工数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "")
        {
            var dataTable = new DataTable(PiStaffTable.TableName);
            var returnRecordCount = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiStaffManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(whereConditional))
                {
                    whereConditional = PiStaffTable.FieldDeleteMark + " = 0 ";
                }
                else
                {
                    whereConditional += " AND " + PiStaffTable.FieldDeleteMark + " = 0 ";
                }

                dataTable = manager.GetDTByPage(out returnRecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = PiStaffTable.TableName;
            });
            recordCount = returnRecordCount;
            return dataTable;
        }
        #endregion

        #region public PiStaffEntity GetEntity(UserInfo userInfo, string id) 获取实体
        /// <summary>
        /// 获取实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主鍵</param>
        /// <returns>实体</returns>
		public PiStaffEntity GetEntity(UserInfo userInfo, string id)
		{
			PiStaffEntity entity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_GetEntity);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entity = new PiStaffManager(dbProvider, userInfo).GetEntity(id);
            });
			return entity;
		}
        #endregion

        #region public int UpdateStaff(UserInfo userInfo, PiStaffEntity entity, out string statusCode, out string statusMessage) 更新员工
        /// <summary>
        /// 更新员工
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int UpdateStaff(UserInfo userInfo, PiStaffEntity entity, out string statusCode, out string statusMessage)
		{
			int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_UpdateStaff);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiStaffManager(dbProvider, userInfo);
                returnValue = manager.Update(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public DataTable GetDTByIds(UserInfo userInfo, string[] ids) 获取员工列表
        /// <summary>
        /// 获取员工列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主鍵</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
		{
			var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_GetDTByIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiStaffManager(dbProvider, userInfo).GetDT(PiStaffTable.FieldId, ids, PiStaffTable.FieldSortCode);
                dataTable.TableName = PiStaffTable.TableName;
            });

			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByOrganize(UserInfo userInfo, string organizeId, bool containChildren) 获得员工列表通过组织机构
        /// <summary>
        /// 获得员工列表通过组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>       
        public DataTable GetDTByOrganize(UserInfo userInfo, string organizeId, bool containChildren)
        {
            var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_GetDTByOrganize);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 用户已经不存在的需要整理干净，防止数据不完整。
                string sqlQuery = "UPDATE PISTAFF SET USERID = NULL WHERE (USERID NOT IN (SELECT ID FROM PIUSER))";
                dbProvider.ExecuteNonQuery(sqlQuery);
                var staffManager = new PiStaffManager(dbProvider, userInfo);
                dataTable = containChildren ? staffManager.GetChildrenStaffs(organizeId) : staffManager.GetDTByOrganize(organizeId);
                dataTable.TableName = PiStaffTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTNotOrganize(UserInfo userInfo, string organizeId, bool containChildren) 获得未设置组织机构的员工列表
        /// <summary>
        /// 获得未设置组织机构的员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>       
        public DataTable GetDTNotOrganize(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_GetDTNotOrganize);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {              
                var staffManager = new PiStaffManager(dbProvider, userInfo);
                dataTable = staffManager.GetStaffDTNotOrganzie();
                dataTable.TableName = PiStaffTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public int SetStaffUser(UserInfo userInfo, string staffId, string userId) 员工关联用户
        /// <summary>
        /// 员工关联用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int SetStaffUser(UserInfo userInfo, string staffId, string userId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_SetStaffUser, "员工主键：" + staffId + ",用户主键:" + userId);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var staffManager = new PiStaffManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(userId))
                {
                    returnValue = staffManager.SetProperty(staffId, PiStaffTable.FieldUserId, userId);
                }
                else
                {
                    // 一个用户只能帮定到一个帐户上，检查是否已经绑定过这个用户了。
                    string[] staffIds = staffManager.GetIds(new KeyValuePair<string, object>(PiStaffTable.FieldUserId, userId), new KeyValuePair<string, object>(PiStaffTable.FieldDeleteMark, 0));
                    if (staffIds == null || staffIds.Length == 0)
                    {
                        returnValue = staffManager.SetProperty(staffId, PiStaffTable.FieldUserId, userId);
                        var userManager = new PiUserManager(dbProvider, userInfo);
                        var userEntity = userManager.GetEntity(userId);
                        returnValue = staffManager.SetProperty(staffId, PiStaffTable.FieldUserName, userEntity.UserName);
                    }
                }
            });
            return returnValue;
        }
        #endregion

        #region public int DeleteUser(UserInfo userInfo, string staffId) 删除员工关联的用户
        /// <summary>
        /// 删除员工关联的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <returns>影响行数</returns>
        public int DeleteUser(UserInfo userInfo, string staffId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_DeleteUser, "员工主键：" + staffId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiStaffManager(dbProvider, userInfo).DeleteUser(staffId);
            });

            return returnValue;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 单个删除
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_Delete, "主键：" + id);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiStaffManager(dbProvider, userInfo).Delete(id);
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
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_BatchDelete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiStaffManager(dbProvider, userInfo).BatchDelete(ids);
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
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_SetDeleted);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                var staffManager = new PiStaffManager(dbProvider, userInfo);
                PiStaffEntity staffEntity = null;
                for (int i = 0; i < ids.Length; i++)
                {
                    // 删除相应的用户
                    staffEntity = staffManager.GetEntity(ids[i]);
                    if (staffEntity.UserId != null)
                    {
                        userManager.SetDeleted(staffEntity.UserId);
                    }
                    // 删除职员
                    returnValue += staffManager.SetDeleted(ids[i], true);
                    var staffOrganizeManager = new PiStaffOrganizeManager(dbProvider, userInfo);
                    returnValue += staffOrganizeManager.SetDeleted(new string[] { PiStaffOrganizeTable.FieldStaffId }, new string[] { ids[i] });
                }
            });

            return returnValue;
        }
        #endregion

        #region public int MoveTo(UserInfo userInfo, string id, string organizeId) 移动员工数据到指定组织机构
        /// <summary>
        /// 移动员工数据到指定组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">员工主键</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(UserInfo userInfo, string id, string organizeId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_MoveTo, "员工主键：" + id + ",组织机构主键:" + organizeId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiStaffOrganizeManager(dbProvider, userInfo).SetProperty(PiStaffOrganizeTable.FieldStaffId, id, PiStaffOrganizeTable.FieldOrganizeId, organizeId);
            });

            return returnValue;
        }
        #endregion

        #region public int BatchMoveTo(UserInfo userInfo, string[] ids, string organizeId) 批量移动员工到指定组织机构
        /// <summary>
        /// 批量移动员工到指定组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">员工主键数组</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(UserInfo userInfo, string[] ids, string organizeId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.StaffService_BatchMoveTo);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new PiStaffOrganizeManager(dbProvider, userInfo);
                returnValue += ids.Sum(t => manager.SetProperty(PiStaffOrganizeTable.FieldStaffId, t, PiStaffOrganizeTable.FieldOrganizeId, organizeId));
            });

            return returnValue;
        }
        #endregion

        #region  public string GetId(BaseUserInfo userInfo,string name, object value) 获取主键
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">查询的参数</param>
        /// <param name="value">参数值</param>
        /// <returns>影响行数</returns>
        public string GetId(UserInfo userInfo, string name, object value)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiStaffManager(dbProvider).GetId(new KeyValuePair<string, object>(name, value));
            });

            return returnValue;
        }
        #endregion
	}
}
