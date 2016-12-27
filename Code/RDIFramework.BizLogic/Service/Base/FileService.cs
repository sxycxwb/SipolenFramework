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
    /// FileService
    /// 文件服务
    /// 
    /// 修改记录
    ///     2016-01-12 版本：3.0 XuWangBin 增加GetFileDTByPage接口。
    ///     2012-06-20 XuWangBin 取消下载文件的日志记录。
    ///		2012-03-02 版本：1.0 XuWangBin 建立文件服务。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FileService : System.MarshalByRefObject, IFileService
    {
        private string serviceName = RDIFrameworkMessage.FileService;

        #region public CiFileEntity GetEntity(UserInfo userInfo, string id):获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiFileEntity GetEntity(UserInfo userInfo, string id)
        {
            CiFileEntity fileEntity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.FileService_GetEntity);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                fileEntity = fileManager.GetEntity(id);
            });
            return fileEntity;
        }
        #endregion

        #region public bool Exists(UserInfo userInfo, string folderId, string fileName):判断是否存在
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <returns>存在</returns>
        public bool Exists(UserInfo userInfo, string folderId, string fileName)
        {
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.FileService_Exists);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.Exists(CiFileTable.FieldFolderId, folderId, CiFileTable.FieldFileName, fileName);
            });
            
            return returnValue;
        }
        #endregion

        #region public byte[] Download(UserInfo userInfo, string id):下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>文件</returns>
        public byte[] Download(UserInfo userInfo, string id)
        {
            byte[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.Download(id);
            });
            
            return returnValue;
        }
        #endregion

        #region public string Upload(UserInfo userInfo, string folderId, string fileName, byte[] file, bool enabled):上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="enabled">有效</param>
        /// <returns>主键</returns>
        public string Upload(UserInfo userInfo, string folderId, string fileName, byte[] file, bool enabled)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.FileService_Upload);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.Upload(folderId, fileName, file, enabled);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetDTByFolder(UserInfo userInfo, string folderId):按文件夹获取文件列表
        /// <summary>
        /// 按文件夹获取文件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>列表</returns>
        public DataTable GetDTByFolder(UserInfo userInfo, string folderId)
        {
            var dataTable = new DataTable(CiFileTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.FileService_GetDTByFolder);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                dataTable = fileManager.GetDTByFolder(folderId);
                dataTable.TableName = CiFolderTable.TableName;
            });

            return dataTable;
        }
        #endregion

        #region public DataTable GetFileDTByPage(UserInfo userInfo, string folderId):获取分页文件列表
        /// <summary>
        /// 获取分页文件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        /// <returns>列表</returns>
        public DataTable GetFileDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "")
        {
            var dataTable = new DataTable(CiFileTable.TableName);
            int myrecordCount = 0;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(whereConditional))
                {
                    whereConditional = CiFileTable.FieldDeleteMark + " = 0 ";
                }
                else
                {
                    whereConditional += " AND " + CiFileTable.FieldDeleteMark + " = 0 ";
                }
                order = string.IsNullOrEmpty(order) ? CiFileTable.FieldSortCode : order;
                dataTable = fileManager.GetFileDTByPage(out myrecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = CiFileTable.TableName;
            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public int DeleteByFolder(UserInfo userInfo, string folderId):按文件夹删除文件
        /// <summary>
        /// 按文件夹删除文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        public int DeleteByFolder(UserInfo userInfo, string folderId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.FileService_DeleteByFolder);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.DeleteByFolder(folderId);
            });

            return returnValue;
        }
        #endregion

        #region public string Add(UserInfo userInfo, string folderId, string fileName, byte[] file, string description, string category, bool enabled, out string statusCode, out string statusMessage):添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="description">描述</param>
        /// <param name="category">分类</param>
        /// <param name="enabled">是否可用</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns></returns>
        public string Add(UserInfo userInfo, string folderId, string fileName, byte[] file, string description, string category, bool enabled, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.Add(folderId, fileName, file, description, category, enabled, out returnCode);
                returnMessage = fileManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int Update(UserInfo userInfo, string id, string folderId, string fileName, string description, bool enabled, out string statusCode, out string statusMessage)
        public int Update(UserInfo userInfo, string id, string folderId, string fileName, string description, bool enabled, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                 var fileManager = new CiFileManager(dbProvider, userInfo);
                 returnValue = fileManager.Update(id, folderId, fileName, description, enabled, out returnCode);
                 returnMessage = fileManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int UpdateFile(UserInfo userInfo, string id, string fileName, byte[] file, out string statusCode, out string statusMessage)
        public int UpdateFile(UserInfo userInfo, string id, string fileName, byte[] file, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.UpdateFile(id, fileName, file, out returnCode);
                returnMessage = fileManager.GetStateMessage(returnCode);
            });

            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int Rename(UserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage):重命名
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
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileEntity = new CiFileEntity();
                var fileManager = new CiFileManager(dbProvider, userInfo);
                var dataTable = fileManager.GetDTById(id);
                fileEntity.GetFrom(dataTable);
                fileEntity.FileName = newName;
                fileEntity.Enabled = enabled ? 1 : 0;
                returnValue = fileManager.Update(fileEntity, out returnCode);
                returnMessage = fileManager.GetStateMessage(returnCode);
            });

            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable Search(UserInfo userInfo, string searchValue):查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="searchValue">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(UserInfo userInfo, string searchValue)
        {
            var dataTable = new DataTable(CiFileTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                dataTable = fileManager.Search(searchValue);
                dataTable.TableName = CiFileTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public int MoveTo(UserInfo userInfo, string id, string folderId) 移动文件到指定文件夹
        /// <summary>
        /// 移动文件到指定文件夹
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">文件主键</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>受影响的行数</returns>
        public int MoveTo(UserInfo userInfo, string id, string folderId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.MoveTo(id, folderId);
            });
            return returnValue;
        }
        #endregion

        #region  public int BatchMoveTo(UserInfo userInfo, string[] ids, string folderId) 批量移动文件到指定文件夹
        /// <summary>
        /// 批量移动文件到指定文件夹
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids"></param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>受影响的行数</returns>
        public int BatchMoveTo(UserInfo userInfo, string[] ids, string folderId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());           

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue += ids.Sum(t => fileManager.MoveTo(t, folderId));
            });
            return returnValue;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 删除指定文件
        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>受影响的行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.Delete(id);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量删除文件列表
        /// <summary>
        /// 批量删除文件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>受影响的行数</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.Delete(ids);
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
        /// <returns>受影响的行数</returns>
        public int BatchSave(UserInfo userInfo, DataTable dataTable)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var fileManager = new CiFileManager(dbProvider, userInfo);
                returnValue = fileManager.BatchSave(dataTable);
            });
            return returnValue;
        }
        #endregion
    }
}
