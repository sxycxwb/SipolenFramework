/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-10 10:40:18
 ******************************************************************************/

using System.Data;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

    /// <summary>
    /// CiFolderManager
    /// 文件夹表
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
    public partial class CiFolderManager : DbCommonManager, IDbCommonManager
    {
         public CiFolderManager()
        {
            base.CurrentTableName = CiFolderTable.TableName;
        }

        public CiFolderManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        public CiFolderManager(UserInfo userInfo): this()
        {
            UserInfo = userInfo;
        }

        public CiFolderManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CiFolderEntity GetEntity(string id)
        {            
            //var folderEntity = new CiFolderEntity(this.GetDTById(id));            
            //return folderEntity;
            return BaseEntity.Create<CiFolderEntity>(this.GetDTById(id));
        }

        #region private void SetEntity(SQLBuilder sqlBuilder, CiFolderTable folderEntity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL生成器</param>
        /// <param name="folderEntity">实体对象</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiFolderEntity folderEntity)
        {
            sqlBuilder.SetValue(CiFolderTable.FieldParentId, folderEntity.ParentId);
            sqlBuilder.SetValue(CiFolderTable.FieldFolderName, folderEntity.FolderName);
            sqlBuilder.SetValue(CiFolderTable.FieldSortCode, folderEntity.SortCode);
            sqlBuilder.SetValue(CiFolderTable.FieldDescription, folderEntity.Description);
            sqlBuilder.SetValue(CiFolderTable.FieldEnabled, folderEntity.Enabled);
        }
        #endregion

        #region public string AddEntity(CiFolderTable folderEntity) 添加
        /// <summary>
        /// Add 添加的主键
        /// </summary>
        /// <param name="folderEntity">文件夹对象</param>
        /// <returns>主键</returns>
        public string AddEntity(CiFolderEntity folderEntity)
        {
            var sequence = string.Empty;
            if (folderEntity.SortCode == null || folderEntity.SortCode == 0)
            {
                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName, sequenceManager.DefaultSequence);
                folderEntity.SortCode = BusinessLogic.ConvertToNullableInt32(sequence);
            }

            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider,this.Identity,this.ReturnId);
            sqlBuilder.BeginInsert(CiFolderTable.TableName,CiFolderTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(folderEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    folderEntity.Id = sequence;
                }
                sqlBuilder.SetValue(CiFolderTable.FieldId, folderEntity.Id);
            }

            this.SetEntity(sqlBuilder, folderEntity);
            sqlBuilder.SetValue(CiFolderTable.FieldCreateUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiFolderTable.FieldCreateBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiFolderTable.FieldCreateOn);
            sqlBuilder.SetValue(CiFolderTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiFolderTable.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiFolderTable.FieldModifiedOn);
            if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }

            return sequence;
        }
        #endregion

        #region public int UpdateEntity(CiFolderTable folderEntity) 更新
        /// <summary>
        /// Update 更新的主键
        /// </summary>
        /// <param name="folderEntity">文件夹对象</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(CiFolderEntity folderEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(CiFolderTable.TableName);
            this.SetEntity(sqlBuilder, folderEntity);
            sqlBuilder.SetValue(CiFolderTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiFolderTable.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiFolderTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiFolderTable.FieldId, folderEntity.Id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public string Add(CiFolderTable folderEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="folderEntity">文件夹的基类表结构定义</param>
        /// <param name="statusCode">状态返回码</param>
        /// <returns>主键</returns>
        public string Add(CiFolderEntity folderEntity, out string statusCode)
        {
            var returnValue = string.Empty;
            // 检查文件夹名是否重复
            if (this.Exists(CiFolderTable.FieldParentId, folderEntity.ParentId, CiFolderTable.FieldFolderName, folderEntity.FolderName))
            {
                // 文件夹名已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(folderEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Update(CiFolderTable folderEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="folderEntity">文件夹的基类表结构定义</param>
        /// <param name="statusCode">状态返回码</param>
        /// <returns>影响行数</returns>
        public int Update(CiFolderEntity folderEntity, out string statusCode)
        {
            var returnValue = 0;
            //if (DbLogic.IsModifed(DBProvider, CiFolderTable.TableName, folderEntity.Id, folderEntity.ModifiedUserId, folderEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 检查文件夹名是否重复
                if (this.Exists(CiFolderTable.FieldParentId, folderEntity.ParentId, CiFolderTable.FieldFolderName, folderEntity.FolderName, folderEntity.Id))
                {
                    // 文件夹名已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(folderEntity);
                    statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
                }
            //}
            return returnValue;
        }
        #endregion

        #region public DataTable Search(string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="searchValue">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(string searchValue)
        {
            var sqlQuery = string.Empty;
            sqlQuery = " SELECT * "
                     + " FROM " + CiFolderTable.TableName
                     + " WHERE " + CiFolderTable.FieldFolderName + " LIKE " + DBProvider.GetParameter(CiFolderTable.FieldFolderName)
                     + " OR " + CiFolderTable.FieldDescription + " LIKE " + DBProvider.GetParameter(CiFolderTable.FieldDescription);
            var dataTable = new DataTable(CiFolderTable.TableName);
            searchValue = searchValue.Trim();
            if (searchValue.IndexOf("%") < 0)
            {
                searchValue = "%" + searchValue + "%";
            }
            var dbParameters = new List<IDbDataParameter>
            {
                DBProvider.MakeParameter(CiFolderTable.FieldFolderName, searchValue),
                DBProvider.MakeParameter(CiFolderTable.FieldDescription, searchValue)
            };
            DBProvider.Fill(dataTable, sqlQuery, dbParameters.ToArray());
            return dataTable;
        }
        #endregion

        #region public int MoveTo(string id, string parentId) 移动
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, CiFolderTable.FieldParentId, parentId);
        }
        #endregion

        #region public override int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            var returnValue = 0;
            var folderEntity = new CiFolderEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    var id = dataRow[CiFolderTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.DeleteEntity(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    var id = dataRow[CiFolderTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        folderEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(folderEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    this.GetFrom(dataRow);
                    returnValue += this.AddEntity(folderEntity).Length > 0 ? 1 : 0;
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
     
    }
}
