/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-10 10:00:50
 ******************************************************************************/

using System;
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
    public partial class CiFileManager : DbCommonManager
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CiFileManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = CiFileTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CiFileManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CiFileManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public CiFileManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public CiFileManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        /// <param name="tableName">指定表名</param>
        public CiFileManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }
        #endregion

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fileEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CiFileEntity fileEntity)
        {
            return this.AddEntity(fileEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fileEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(CiFileEntity fileEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(fileEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="fileEntity">实体</param>
        public int Update(CiFileEntity fileEntity)
        {
            return this.UpdateEntity(fileEntity);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="fileEntity">实体</param>
        public string AddEntity(CiFileEntity fileEntity)
        {
            var sequence = string.Empty;
            if (fileEntity.SortCode == null || fileEntity.SortCode == 0)
            {
                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName, sequenceManager.DefaultSequence);
                fileEntity.SortCode = BusinessLogic.ConvertToNullableInt32(sequence);
            }
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, false);
            sqlBuilder.BeginInsert(this.CurrentTableName, CiFileTable.FieldId);
            if (!this.Identity)
            {
                if (String.IsNullOrEmpty(fileEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    fileEntity.Id = sequence;
                }
                sqlBuilder.SetValue(CiFileTable.FieldId, fileEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DBProvider.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(CiFileTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        if (string.IsNullOrEmpty(fileEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            fileEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(CiFileTable.FieldId, fileEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, fileEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiFileTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiFileTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiFileTable.FieldCreateOn);
            /*
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiFileTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiFileTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiFileTable.FieldModifiedOn);
             */
            if (DBProvider.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="fileEntity">实体</param>
        public int UpdateEntity(CiFileEntity fileEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, fileEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiFileTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiFileTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiFileTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiFileTable.FieldId, fileEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder"></param>
        /// <param name="fileEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiFileEntity fileEntity)
        {
            sqlBuilder.SetValue(CiFileTable.FieldFolderId, fileEntity.FolderId);
            sqlBuilder.SetValue(CiFileTable.FieldFileName, fileEntity.FileName);
            sqlBuilder.SetValue(CiFileTable.FieldFilePath, fileEntity.FilePath);
            sqlBuilder.SetValue(CiFileTable.FieldFileContent, fileEntity.FileContent);
            sqlBuilder.SetValue(CiFileTable.FieldFileSize,fileEntity.FileSize != null ? fileEntity.FileContent.Length : fileEntity.FileSize);
            sqlBuilder.SetValue(CiFileTable.FieldImageUrl, fileEntity.ImageUrl);
            sqlBuilder.SetValue(CiFileTable.FieldReadCount, fileEntity.ReadCount);
            sqlBuilder.SetValue(CiFileTable.FieldCategory, fileEntity.Category);
            sqlBuilder.SetValue(CiFileTable.FieldDescription, fileEntity.Description);
            sqlBuilder.SetValue(CiFileTable.FieldSortCode, fileEntity.SortCode);
            sqlBuilder.SetValue(CiFileTable.FieldDeleteMark, fileEntity.DeleteMark);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(CiFileTable.FieldId, id);
        }

         #region public CiFileTable GetEntity(string id) 获取信息
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>数据权限</returns>
        public CiFileEntity GetEntity(string id)
        {
            var sqlQuery = string.Empty;
            sqlQuery = " SELECT " + CiFileTable.FieldId
                    + "        ," + CiFileTable.FieldFolderId
                    + "        ," + CiFileTable.FieldCategory
                    + "        ," + CiFileTable.FieldFileName
                    + "        ," + CiFileTable.FieldFilePath
                    + "        ," + CiFileTable.FieldImageUrl
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
                        + " WHERE " + CiFileTable.FieldId + " = " + DBProvider.GetParameter(CiFileTable.FieldId);
            var dataTable = new DataTable(CiFileTable.TableName);
            DBProvider.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(CiFileTable.FieldId, id) });
            var fileEntity = BaseEntity.Create<CiFileEntity>(dataTable); 
            return fileEntity;
        }
        #endregion
    }
}
