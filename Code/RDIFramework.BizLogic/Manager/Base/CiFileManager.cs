/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-10 10:00:50
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;  

    /// <summary>
    /// CiFileManager
    /// 文件表
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class CiFileManager
    {
        private int UpdateReadCount(string id)
        {
            // 阅读次数要加一
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(CiFileTable.TableName);
            sqlBuilder.SetFormula(CiFileTable.FieldReadCount, CiFileTable.FieldReadCount + " + 1 ");
            sqlBuilder.SetWhere(CiFileTable.FieldId, id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 从数据库中读取文件
        /// </summary>
        /// <param name="id">文件主键</param>
        /// <returns>文件</returns>
        public byte[] Download(string id)
        {
            // 阅读次数要加一
            this.UpdateReadCount(id);
            // 下载文件
            byte[] fileContent = null;
            var sqlQuery = " SELECT " + CiFileTable.FieldFileContent
                            + "   FROM " + CiFileTable.TableName
                            + "  WHERE " + CiFileTable.FieldId + " = " + DBProvider.GetParameter(CiFileTable.FieldId);
            IDataReader dataReader = null;
            try
            {
                dataReader = DBProvider.ExecuteReader(sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(CiFileTable.FieldId, id)});
                if (dataReader.Read())
                {
                    fileContent = (byte[])dataReader[CiFileTable.FieldFileContent];
                }
            }
            catch (System.Exception ex)
            {
                // 在本地记录异常
                CiExceptionManager.LogException(DBProvider, UserInfo, ex);
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
            return fileContent;
        }

        public string Upload(string folderId, string fileName, byte[] file, bool enabled)
        {
            // 检查是否已经存在
            var returnValue = this.GetId(CiFileTable.FieldFolderId, folderId, CiFileTable.FieldFileName, fileName);
            if (!String.IsNullOrEmpty(returnValue))
            {
                // 更新数据
                this.UpdateFile(returnValue, fileName, file);
            }
            else
            {
                // 添加数据
                var fileEntity = new CiFileEntity
                {
                    FolderId = folderId,
                    FileName = fileName,
                    FileContent = file,
                    Enabled = enabled ? 1 : 0
                };
                returnValue = this.AddEntity(fileEntity);
            }
            return returnValue;
        }

        #region public DataTable GetDTByFolder(string id) 获取信息
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByFolder(string id)
        {
            var sqlQuery = string.Empty;
            sqlQuery = " SELECT " + CiFileTable.FieldId
                    + "        ," + CiFileTable.FieldFolderId
                    + "        ," + CiFileTable.FieldFileName
                    + "        ," + CiFileTable.FieldFilePath
                    + "        ," + CiFileTable.FieldFileSize
                    + "        ," + CiFileTable.FieldReadCount
                    + "        ," + CiFileTable.FieldCategory
                    + "        ," + CiFileTable.FieldDescription
                    + "        ," + CiFileTable.FieldEnabled
                    + "        ," + CiFileTable.FieldSortCode
                    + "        ," + CiFileTable.FieldCreateUserId
                    + "        ," + CiFileTable.FieldCreateBy
                    + "        ," + CiFileTable.FieldCreateOn
                    + "        ," + CiFileTable.FieldModifiedUserId
                    + "        ," + CiFileTable.FieldModifiedBy
                    + "        ," + CiFileTable.FieldModifiedOn
                    + "       , (SELECT " + CiFolderTable.FieldFolderName
                                + " FROM " + CiFolderTable.TableName
                                + " WHERE " + CiFolderTable.FieldId + " = '" + CiFileTable.FieldFolderId + "') AS FolderFullName "
                    + " FROM " + CiFileTable.TableName
                    + " WHERE " + CiFileTable.FieldFolderId + " = " + DBProvider.GetParameter(CiFileTable.FieldFolderId);
            var dataTable = new DataTable(CiFileTable.TableName);
            DBProvider.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(CiFileTable.FieldFolderId, id)});
            if (id.Length == 0)
            {
                // 这里注意默认值
                var dataRow = dataTable.NewRow();
                dataRow[CiFileTable.FieldEnabled] = 1;
                dataTable.Rows.Add(dataRow);
                dataTable.AcceptChanges();
            }
            this.GetFrom(dataTable);
            return dataTable;
        }
        #endregion

        public DataTable GetFileDTByPage(out int recordCount, int pageIndex = 1, int pageSize = 20,string whereConditional = "", string order = "")
        {
            this.SelectField = CiFileTable.FieldId
                               + "        ," + CiFileTable.FieldFolderId
                               + "        ," + CiFileTable.FieldFileName
                               + "        ," + CiFileTable.FieldFilePath
                               + "        ," + CiFileTable.FieldFileSize
                               + "        ," + CiFileTable.FieldReadCount
                               + "        ," + CiFileTable.FieldCategory
                               + "        ," + CiFileTable.FieldDescription
                               + "        ," + CiFileTable.FieldEnabled
                               + "        ," + CiFileTable.FieldSortCode
                               + "        ," + CiFileTable.FieldCreateUserId
                               + "        ," + CiFileTable.FieldCreateBy
                               + "        ," + CiFileTable.FieldCreateOn
                               + "        ," + CiFileTable.FieldModifiedUserId
                               + "        ," + CiFileTable.FieldModifiedBy
                               + "        ," + CiFileTable.FieldModifiedOn
                               + "       , (SELECT " + CiFolderTable.FieldFolderName
                               + " FROM " + CiFolderTable.TableName
                               + " WHERE " + CiFolderTable.FieldId + " = '" + CiFileTable.FieldFolderId +
                               "') AS FolderFullName ";
            recordCount = DbCommonLibary.GetCount(DBProvider, this.CurrentTableName, whereConditional);
            return DbCommonLibary.GetDTByPage(DBProvider, this.CurrentTableName, this.SelectField, pageIndex, pageSize, whereConditional, order);
        }

        #region public override int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            var returnValue = 0;
            var fileEntity = new CiFileEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    var id = dataRow[CiFileTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.Delete(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    var id = dataRow[CiFileTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        fileEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        returnValue += this.UpdateEntity(fileEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    fileEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(fileEntity).Length > 0 ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }
        #endregion

        #region public string Add(string folderId, string fileName, byte[] file, string category, bool enabled, out string statusCode) 添加文件
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="category">文件分类</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态</param>
        /// <returns>主键</returns>
        public string Add(string folderId, string fileName, byte[] file, string description, string category, bool enabled, out string statusCode)
        {
            return this.Add(folderId, fileName, null, file, description, category, enabled, out statusCode);
        }
        #endregion

        #region public string Add(string folderId, string fileName, byte[] file, string category, bool enabled, out string statusCode) 添加文件
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="category">文件分类</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态</param>
        /// <returns>主键</returns>
        public string Add(string folderId, string fileName, string file, string description, string category, bool enabled, out string statusCode)
        {
            return this.Add(folderId, fileName, file, null, description, category, enabled, out statusCode);
        }
        #endregion

        #region private string Add(string folderId, string fileName, string file, byte[] byteFile, string category, bool enabled, out string statusCode) 添加文件
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="byteFile"></param>
        /// <param name="description"></param>
        /// <param name="category">文件分类</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态</param>
        /// <returns>主键</returns>
        private string Add(string folderId, string fileName, string file, byte[] byteFile, string description, string category, bool enabled, out string statusCode)
        {
            statusCode = string.Empty;
            var fileEntity = new CiFileEntity
            {
                FolderId = folderId,
                FileName = fileName,
                FileContent = byteFile,
                Description = description,
                Category = category,
                Enabled = enabled ? 1 : 0
            };
            var returnValue = string.Empty;
            // 检查是否重复
            if (this.Exists(CiFileTable.FieldFolderId, fileEntity.FolderId, CiFileTable.FieldFileName, fileEntity.FileName))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(fileEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public string Add(BaseNewsEntity fileEntity, out string statusCode) 添加文件
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileEntity">有效</param>
        /// <param name="statusCode">状态</param>
        /// <returns>主键</returns>
        public string Add(CiFileEntity fileEntity, out string statusCode)
        {
            statusCode = string.Empty;
            var returnValue = string.Empty;
            // 检查是否重复
            string[] names = { CiFileTable.FieldFolderId, CiFileTable.FieldFileName, CiFileTable.FieldDeleteMark };
            Object[] values = { fileEntity.FolderId, fileEntity.FileName, 0 };
            if (this.Exists(names, values))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(fileEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Update(CiFileTable fileEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="fileEntity">文件夹的基类表结构定义</param>
        /// <param name="statusCode">状态返回码</param>
        /// <returns>影响行数</returns>
        public int Update(CiFileEntity fileEntity, out string statusCode)
        {
            var returnValue = 0;
            //if (DbLogic.IsModifed(DBProvider, CiFileTable.TableName, fileEntity.Id, fileEntity.ModifiedUserId, fileEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 检查文件夹名是否重复
                if (this.Exists(CiFileTable.FieldFolderId, fileEntity.FolderId, CiFileTable.FieldFileName, fileEntity.FileName, fileEntity.Id))
                {
                    // 文件夹名已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(fileEntity);
                    statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
                }
            //}
            return returnValue;
        }
        #endregion

        public int Update(string id, string folderId, string fileName, string description, bool enabled, out string statusCode)
        {
            statusCode = string.Empty;
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(CiFileTable.TableName);
            sqlBuilder.SetValue(CiFileTable.FieldFolderId, folderId);
            sqlBuilder.SetValue(CiFileTable.FieldFileName, fileName);
            sqlBuilder.SetValue(CiFileTable.FieldEnabled, enabled);            
            sqlBuilder.SetValue(CiFileTable.FieldDescription, description);
            sqlBuilder.SetValue(CiFileTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiFileTable.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiFileTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiFileTable.FieldId, id);
            var returnValue = sqlBuilder.EndUpdate();
            statusCode = returnValue > 0 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            return returnValue;
        }

        public int UpdateFile(string id, string fileName, byte[] file)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(CiFileTable.TableName);
            sqlBuilder.SetValue(CiFileTable.FieldFileName, fileName);
            if (file != null)
            {
                sqlBuilder.SetValue(CiFileTable.FieldFileContent, file);
                sqlBuilder.SetValue(CiFileTable.FieldFileSize, file.Length);
            }
            sqlBuilder.SetValue(CiFileTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiFileTable.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiFileTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiFileTable.FieldId, id);
            return sqlBuilder.EndUpdate();
        }

        public int UpdateFile(string id, string fileName, byte[] file, out string statusCode)
        {
            statusCode = string.Empty;
            var returnValue = this.UpdateFile(id, fileName, file);
            statusCode = returnValue > 0 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            return returnValue;
        }

        #region public DataTable Search(string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="searchValue">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(string searchValue)
        {
            return this.Search(string.Empty, searchValue);
        }
        #endregion

        public DataTable Search(string userId, string searchValue)
        {
            return this.Search(userId, string.Empty, searchValue);
        }

        #region public DataTable Search(string userId, string categoryCode, string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="category">目录</param>
        /// <param name="searchValue">查询条件</param>
        /// <returns>数据表</returns>
        public DataTable Search(string userId, string category, string searchValue)
        {
            return Search(userId, category, searchValue, null, null);
        }
        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="category">目录</param>
        /// <param name="searchValue">查询条件</param>
        /// <param name="enabled"></param>
        /// <param name="deletionMark"></param>
        /// <returns></returns>
        public DataTable Search(string userId, string category, string searchValue, bool? enabled, bool? deletionMark)
        {
            // 一、这里是将Boolean值转换为int类型。
            var delete = 0;
            if (deletionMark != null)
            {
                delete = (bool)deletionMark ? 1 : 0;
            }

            // 二、这里是开始进行动态SQL语句拼接，字段名、表明都进行了常量定义，表名字段名发生变化时，很容易就知道程序哪里都调用了这些。
            var sqlQuery = string.Empty;
            sqlQuery = " SELECT " + CiFileTable.FieldId
                    + "        ," + CiFileTable.FieldFolderId
                    + "        ," + CiFileTable.FieldCategory
                    + "        ," + CiFileTable.FieldFileName
                    + "        ," + CiFileTable.FieldFilePath
                    + "        ," + CiFileTable.FieldFileSize
                    + "        ," + CiFileTable.FieldReadCount
                    + "        ," + CiFileTable.FieldDescription
                    + "        ," + CiFileTable.FieldEnabled
                    + "        ," + CiFileTable.FieldDeleteMark
                    + "        ," + CiFileTable.FieldSortCode
                    + "        ," + CiFileTable.FieldCreateUserId
                    + "        ," + CiFileTable.FieldCreateBy
                    + "        ," + CiFileTable.FieldCreateOn
                    + "        ," + CiFileTable.FieldModifiedUserId
                    + "        ," + CiFileTable.FieldModifiedBy
                    + "        ," + CiFileTable.FieldModifiedOn
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + CiFileTable.FieldDeleteMark + " = " + delete;

            if (enabled != null)
            {
                var isEnabled = (bool)enabled ? 1 : 0;
                sqlQuery += " AND " + CiFileTable.FieldEnabled + " = " + isEnabled;
            }
            // 三、我们认为 userId 这个查询条件是安全，不是人为输入的参数，所以直接进行了SQL语句拼接
            if (!String.IsNullOrEmpty(userId))
            {
                sqlQuery += " AND " + CiFileTable.FieldCreateUserId + " = '" + userId + "'";
            }

            if (!String.IsNullOrEmpty(category))
            {
                sqlQuery += " AND " + CiFileTable.FieldCategory + " = '" + category + "'";
            }

            // 四、这里是进行参数化的准备，因为是多个不确定的查询参数，所以用了List。
            var dbParameters = new List<IDbDataParameter>();

            // 五、这里看查询条件是否为空
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                // 六、这里是进行支持多种数据库的参数化查询
                sqlQuery += " AND (" + CiFileTable.FieldFileName + " LIKE " + DBProvider.GetParameter(CiFileTable.FieldFileName);
                sqlQuery += " OR " + CiFileTable.FieldCategory + " LIKE " + DBProvider.GetParameter(CiFileTable.FieldCategory);
                sqlQuery += " OR " + CiFileTable.FieldCreateBy + " LIKE " + DBProvider.GetParameter(CiFileTable.FieldCreateBy);
                sqlQuery += " OR " + CiFileTable.FieldFileContent + " LIKE " + DBProvider.GetParameter(CiFileTable.FieldFileContent);
                sqlQuery += " OR " + CiFileTable.FieldDescription + " LIKE " + DBProvider.GetParameter(CiFileTable.FieldDescription) + ")";

                // 七、这里是判断，用户是否已经输入了%
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }

                // 八、这里生成支持多数据库的参数
                dbParameters.Add(DBProvider.MakeParameter(CiFileTable.FieldFileName, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(CiFileTable.FieldCategory, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(CiFileTable.FieldCreateBy, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(CiFileTable.FieldFileContent, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(CiFileTable.FieldDescription, searchValue));
            }
            sqlQuery += " ORDER BY " + CiFileTable.FieldSortCode + " DESC ";

            // 九、这里是将List转换为数组，进行数据库查询
            return DBProvider.Fill(sqlQuery, dbParameters.ToArray());
        }

        /// <summary>
        /// 移动（要考虑文件的覆盖问题，文件名重复了，需要覆盖文件的）
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string folderId)
        {
            // 有重名的文件，需要进行覆盖
            var fileName = this.GetProperty(id, CiFileTable.FieldFileName);
            this.Delete(CiFileTable.FieldFolderId, folderId, CiFileTable.FieldFileName, fileName);
            return this.SetProperty(id, CiFileTable.FieldFolderId, folderId);
        }

        /// <summary>
        /// 按目录删除文件
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        public int DeleteByFolder(string folderId)
        {
            return this.Delete(CiFileTable.FieldFolderId, folderId);
        }

        #region public Double GetSumFileSize() 服务器已用空间(单位Byte)
        /// <summary>
        /// 服务器已用空间(单位Byte)
        /// </summary>
        public Double GetSumFileSize()
        {
            // 已用空间
            var sqlQuery = " SELECT SUM( " + CiFileTable.FieldFileSize + ") FROM  " + CiFileTable.TableName;
            return Double.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public Double GetSumFileSize(string userId)
        /// <summary>
        /// 当前用户已用空间
        /// </summary>
        public Double GetSumFileSize(string userId)
        {
            // 当前用户已用空间
            var sqlQuery = " SELECT SUM( " + CiFileTable.FieldFileSize + ") FROM  " + CiFileTable.TableName 
                            + " WHERE " + CiFileTable.FieldCreateUserId + "='" + userId + "'";
            return Double.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public Double GetSumFileSize(bool enabled) 服务器已用空间(单位Byte)
        /// <summary>
        /// 服务器已用空间(单位Byte)
        /// </summary>
        public Double GetSumFileSize(bool enabled)
        {
            // 已用空间
            var sqlQuery = " SELECT SUM( " + CiFileTable.FieldFileSize + ") FROM  " + CiFileTable.TableName 
                            + " WHERE " + CiFileTable.FieldEnabled + " = ";
            sqlQuery += enabled ? "1" : "0";
            return Double.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public int GetFileCount() 文件数量
        /// <summary>
        /// 文件数量
        /// </summary>
        public int GetFileCount()
        {
            // 文件数量
            var sqlQuery = " SELECT COUNT(*) FROM " + CiFileTable.TableName;
            return int.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public int GetFileCount() 文件数量
        /// <summary>
        /// 文件数量
        /// </summary>
        public int GetFileCount(bool enabled)
        {
            // 文件数量
            var sqlQuery = " SELECT COUNT(*) FROM  " + CiFileTable.TableName
                            + " WHERE " + CiFileTable.FieldEnabled + " = ";
            sqlQuery += enabled ? "1" : "0";
            return int.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public int GetFileCount() 文件数量
        /// <summary>
        /// 文件数量
        /// </summary>
        public int GetFileCount(string userId)
        {
            // 文件数量
            var sqlQuery = " SELECT COUNT(*) FROM  " + CiFileTable.TableName  
                            + " WHERE " + CiFileTable.FieldCreateUserId + "='" + userId + "'";
            return int.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public int GetFlowmeter() 文件总的流量
        /// <summary>
        /// 文件总的流量
        /// </summary>
        public int GetFlowmeter()
        {
            // 文件数量
            var sqlQuery = "SELECT SUM( " + CiFileTable.FieldFileSize + " * " + CiFileTable.FieldReadCount + ") FROM  " + CiFileTable.TableName;
            return int.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public int GetFlowmeter(string userId) 文件总的流量
        /// <summary>
        /// 文件总的流量
        /// </summary>
        public int GetFlowmeter(string userId)
        {
            // 文件数量
            var sqlQuery = "SELECT SUM( " + CiFileTable.FieldFileSize + " * " + CiFileTable.FieldReadCount + ") FROM  " + CiFileTable.TableName
                            + " WHERE " + CiFileTable.FieldCreateUserId + "='" + userId + "'";
            return int.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion

        #region public int GetFileCount(string folderId, string userId) 文件夹中文件数量
        /// <summary>
        /// 文件夹中文件数量
        /// </summary>
        public int GetFileCount(string folderId, string userId)
        {
            // 文件数量
            var sqlQuery = "SELECT SUM( " + CiFileTable.FieldFileSize + " * " + CiFileTable.FieldReadCount + ") FROM  " + CiFileTable.TableName
                            + " WHERE " + CiFileTable.FieldCreateUserId + "='" + userId + "'"
                            + " AND " + CiFolderTable.FieldParentId + " = '" + folderId + "'";
            return int.Parse(DBProvider.ExecuteScalar(sqlQuery).ToString());
        }
        #endregion       
        
    }
}
