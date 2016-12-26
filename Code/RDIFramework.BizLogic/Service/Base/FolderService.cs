//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// FolderService
    /// 文件夹服务
    /// 
    /// 修改记录
    /// 
    ///		2012-03-02 版本：1.0 EricHu 建立文件夹服务。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FolderService : System.MarshalByRefObject, IFolderService
    {
        private string serviceName = RDIFrameworkMessage.FolderService;

        #region public CiFolderEntity GetEntity(UserInfo userInfo, string id) 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiFolderEntity GetEntity(UserInfo userInfo, string id)
        {
            CiFolderEntity folderEntity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                folderEntity = folderManager.GetEntity(id);
            });
            return folderEntity;
        }
        #endregion

        #region public DataTable GetDT(UserInfo userInfo, string name, string value) 获取数据表
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo, string name, string value)
        {
            var dataTable = new DataTable(CiFolderTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                dataTable = folderManager.GetDT(name, value);              
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByParent(UserInfo userInfo, string id) 按目录获取列表
        /// <summary>
        /// 按目录获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParent(UserInfo userInfo, string id)
        {
            DataTable dataTable = new DataTable(CiFolderTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                dataTable = folderManager.GetDTByParent(id);
                dataTable.TableName = CiFolderTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string AddByFolderName(UserInfo userInfo, string parentId, string folderName, bool enabled, out string statusCode, out string statusMessage) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父主键</param>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns></returns>
        public string AddByFolderName(UserInfo userInfo, string parentId, string folderName, bool enabled, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
               var folderEntity = new CiFolderEntity();
                    var folderManager = new CiFolderManager(dbProvider, userInfo);
                    folderEntity.ParentId = parentId;
                    folderEntity.FolderName = folderName;
                    folderEntity.Enabled = enabled ? 1: 0;
                    returnValue = folderManager.Add(folderEntity, out returnCode);
                    returnMessage = folderManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public string Add(UserInfo userInfo, CiFolderEntity folderEntity, out string statusCode, out string statusMessage) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(UserInfo userInfo, CiFolderEntity folderEntity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue = folderManager.Add(folderEntity, out returnCode);
                returnMessage = folderManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int Update(UserInfo userInfo, CiFolderEntity folderEntity, out string statusCode, out string statusMessage) 更新文件夹
        /// <summary>
        /// 更新文件夹
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderEntity">文件夹</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, CiFolderEntity folderEntity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue = folderManager.Update(folderEntity, out returnCode);
                returnMessage = folderManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable GetDT(UserInfo userInfo) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiFolderTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                dataTable = folderManager.GetDT(CiFolderTable.FieldSortCode);
                dataTable.DefaultView.Sort = CiFolderTable.FieldSortCode;
                dataTable.TableName = CiFolderTable.TableName;
            });
            
            return dataTable;
        }
        #endregion

        #region public int Rename(UserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage) 重命名
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="newName">新名称</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Rename(UserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderEntity = new CiFolderEntity();
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                DataTable dataTable = folderManager.GetDTById(id);
                folderEntity.GetFrom(dataTable);
                folderEntity.FolderName = newName;
                folderEntity.Enabled = enabled ? 1 : 0;
                returnValue = folderManager.Update(folderEntity, out returnCode);
                returnMessage = folderManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable Search(UserInfo userInfo, string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="searchValue">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(UserInfo userInfo, string searchValue)
        {
            var dataTable = new DataTable(CiFolderTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                dataTable = folderManager.Search(searchValue);
                dataTable.TableName = CiFolderTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "Delete");
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue = folderManager.Delete(id);
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
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "BatchDelete");
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue = folderManager.Delete(ids);
            });
            return returnValue;
        }
        #endregion

        #region  public int MoveTo(UserInfo userInfo, string folderId, string parentId) 移动
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="parentId">目标主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(UserInfo userInfo, string folderId, string parentId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "MoveTo","FolderId:" + folderId + ",ParentId:" + parentId);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue = folderManager.MoveTo(folderId, parentId);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchMoveTo(UserInfo userInfo, string[] folderIds, string parentId) 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderIds">文件夹主键数组</param>
        /// <param name="parentId">目标主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(UserInfo userInfo, string[] folderIds, string parentId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "BatchMoveTo","ParentId:" + parentId);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue += folderIds.Sum(t => folderManager.MoveTo(t, parentId));
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
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, "BatchSave");
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var folderManager = new CiFolderManager(dbProvider, userInfo);
                returnValue = folderManager.BatchSave(dataTable);
            });
            return returnValue;
        }
        #endregion
    }
}
