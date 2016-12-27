//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , gt TECH, Ltd.
//--------------------------------------------------------------------

using System.Data;


namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CiItemsManager
    /// 数据字典主表
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
    public partial class CiItemsManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CiItemsManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = CiItemsTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CiItemsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CiItemsManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CiItemsManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CiItemsManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public CiItemsManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Add(CiItemsEntity entity)
        {
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(CiItemsEntity entity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update(CiItemsEntity entity)
        {
            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CiItemsEntity GetEntity(string id)
        {
            //var entity = new CiItemsEntity(this.GetDT(CiItemsTable.FieldId, id));
            //return entity;
            return BaseEntity.Create<CiItemsEntity>(this.GetDT(CiItemsTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(CiItemsEntity entity)
        {
            var sequence = string.Empty;
            if(string.IsNullOrEmpty(entity.SortCode.ToString()) || entity.SortCode == 0)
            {
                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                entity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CiItemsTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(entity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    entity.Id = sequence;
                }
                sqlBuilder.SetValue(CiItemsTable.FieldId, entity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CiItemsTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CiItemsTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(sequence))
                        {
                            var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                            sequence = sequenceManager.GetSequence(this.CurrentTableName);
                        }
                        entity.Id = sequence;
                        sqlBuilder.SetValue(CiItemsTable.FieldId, entity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiItemsTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiItemsTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiItemsTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiItemsTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiItemsTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiItemsTable.FieldModifiedOn);
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
        /// <param name="itemsEntity">实体</param>
        public int UpdateEntity(CiItemsEntity itemsEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, itemsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiItemsTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiItemsTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiItemsTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiItemsTable.FieldId, itemsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="itemsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiItemsEntity itemsEntity)
        {
            sqlBuilder.SetValue(CiItemsTable.FieldParentId, itemsEntity.ParentId);
            sqlBuilder.SetValue(CiItemsTable.FieldCode, itemsEntity.Code);
            sqlBuilder.SetValue(CiItemsTable.FieldFullName, itemsEntity.FullName);
            sqlBuilder.SetValue(CiItemsTable.FieldCategory, itemsEntity.Category);
            sqlBuilder.SetValue(CiItemsTable.FieldTargetTable, itemsEntity.TargetTable);
            sqlBuilder.SetValue(CiItemsTable.FieldIsTree, itemsEntity.IsTree);
            sqlBuilder.SetValue(CiItemsTable.FieldUseItemCode, itemsEntity.UseItemCode);
            sqlBuilder.SetValue(CiItemsTable.FieldUseItemName, itemsEntity.UseItemName);
            sqlBuilder.SetValue(CiItemsTable.FieldUseItemValue, itemsEntity.UseItemValue);
            sqlBuilder.SetValue(CiItemsTable.FieldAllowEdit, itemsEntity.AllowEdit);
            sqlBuilder.SetValue(CiItemsTable.FieldAllowDelete, itemsEntity.AllowDelete);
            sqlBuilder.SetValue(CiItemsTable.FieldDeleteMark, itemsEntity.DeleteMark);
            sqlBuilder.SetValue(CiItemsTable.FieldDescription, itemsEntity.Description);
            sqlBuilder.SetValue(CiItemsTable.FieldEnabled, itemsEntity.Enabled);
            sqlBuilder.SetValue(CiItemsTable.FieldSortCode, itemsEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(CiItemsTable.FieldId, id);
        }  

        #region public string Add(CiItemsEntity itemsEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(CiItemsEntity itemsEntity, out string statusCode)
        {
            var returnValue = string.Empty;
            // 检查编号是否重复
            if (this.Exists(CiItemsTable.FieldCode, itemsEntity.Code,CiItemsTable.FieldDeleteMark,0))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                // 检查名称是否重复
                string[] names = { CiItemsTable.FieldFullName, CiItemsTable.FieldCategory, CiItemsTable.FieldDeleteMark};
                object[] values = { itemsEntity.FullName, itemsEntity.Category,0 };
                if (this.Exists(names, values))
                {
                    // 名称与分类已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    returnValue = this.AddEntity(itemsEntity);
                    // 运行成功
                    statusCode = StatusCode.OKAdd.ToString();
                }
            }
            return returnValue;
        }
        #endregion

        #region public int Update(CiItemsEntity itemsEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(CiItemsEntity itemsEntity, out string statusCode)
        {
            var returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DBProvider, this.CurrentTableName, itemsEntity.Id, itemsEntity.ModifiedUserId, itemsEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 检查编号是否重复
                if (this.Exists(CiItemsTable.FieldCode, itemsEntity.Code, itemsEntity.Id))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    // 检查名称是否重复
                    if (this.Exists(CiItemsTable.FieldFullName, itemsEntity.FullName,CiItemsTable.FieldCategory,itemsEntity.Category, itemsEntity.Id))
                    {
                        // 名称已重复
                        statusCode = StatusCode.ErrorNameExist.ToString();
                    }
                    else
                    {
                        returnValue = this.UpdateEntity(itemsEntity);
                        statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
                    }
                }
            //}
            return returnValue;
        }
        #endregion

        #region public void CreateTable(string tableName, out string statusCode)
        /// <summary>
        /// 创建表结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="statusCode">状态返回码</param>
        public void CreateTable(string tableName, out string statusCode)
        {
            statusCode = StatusCode.Error.ToString();
            var commandText = string.Empty;
            switch (this.DBProvider.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                    commandText = @"
                            CREATE TABLE [dbo].[#tableName#](
	                            [Id] [int] IDENTITY(1,1) NOT NULL,	                           
	                            [Code] [nvarchar](50) NULL,
	                            [FullName] [nvarchar](200)  NULL,
	                            [ItemValue] [nvarchar](100)  NULL,
                                [TargetTable] [nvarchar](50)  NULL,
                                [IsTree] [int] NULL,
                                [UseItemCode] [nvarchar](50)  NULL,
                                [UseItemName] [nvarchar](50)  NULL,
                                [UseItemValue] [nvarchar](50)  NULL,
	                            [Enabled] [int] NOT NULL CONSTRAINT [DF_#tableName#_Enabled]  DEFAULT ((1)),
	                            [AllowEdit] [int] NOT NULL CONSTRAINT [DF_#tableName#_AllowEdit]  DEFAULT ((1)),
	                            [AllowDelete] [int] NOT NULL CONSTRAINT [DF_#tableName#_AllowDelete]  DEFAULT ((1)),
	                            [DeleteMark] [int] NOT NULL CONSTRAINT [DF_#tableName#_DeleteMark]  DEFAULT 0,
	                            [SortCode] [int] NULL,
	                            [Description] [nvarchar](200)  NULL,
	                            [CreateOn] [smalldatetime] NOT NULL CONSTRAINT [DF_#tableName#_CreateOn]  DEFAULT DateTime.Now,
	                            [CreateUserId] [nvarchar](20)  NULL,
	                            [CreateBy] [nvarchar](20)  NULL,
	                            [ModifiedOn] [smalldatetime] NOT NULL CONSTRAINT [DF_#tableName#_ModifiedOn]  DEFAULT DateTime.Now,
	                            [ModifiedUserId] [nvarchar](50)  NULL,
	                            [ModifiedBy] [nvarchar](20)  NULL,
                             CONSTRAINT [PK_#tableName#] PRIMARY KEY CLUSTERED 
                            (
	                            [Id] ASC
                            )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]";
                    commandText = commandText.Replace("#tableName#", tableName);
                    this.DBProvider.ExecuteNonQuery(commandText);
                    statusCode = StatusCode.OK.ToString();
                    break;
                case CurrentDbType.Oracle:
                    commandText = @"
                        create table #tableName# 
                        (
                           Id                 INT                  not null,  
                           Code               NVARCHAR2(50),    
	                       FullName           NVARCHAR2(200),
	                       ItemValue          NVARCHAR2(100),
                           TargetTable        NVARCHAR2(50),
                           IsTree             INT ,                   
                           UseItemCode        NVARCHAR2(200),
                           UseItemName        NVARCHAR2(200)       not null,
                           UseItemValue       NVARCHAR2(200),
                           AllowEdit          INT                  default 1 not null,
                           AllowDelete        INT                  default 1 not null,                          
                           Enabled            INT                  default 1 not null,
                           DeleteMark         INT                  default 0,
                           SortCode           INT,
                           Description        NVARCHAR2(800),
                           CreateOn           DATE,
                           CreateUserId       NVARCHAR2(50),
                           CreateBy           NVARCHAR2(50),
                           ModifiedOn         DATE,
                           ModifiedUserId       NVARCHAR2(50),
                           ModifiedBy         NVARCHAR2(50),
                           constraint PK_#tableName# primary key (Id)
                        )";
                    commandText = commandText.Replace("#tableName#", tableName);
                    this.DBProvider.ExecuteNonQuery(commandText);
                    commandText = "CREATE SEQUENCE SEQ_" + tableName + " MINVALUE 1 MAXVALUE 9999999999999999999 START WITH 1 INCREMENT BY 1 CACHE 20";
                    this.DBProvider.ExecuteNonQuery(commandText);
                    statusCode = StatusCode.OK.ToString();
                    break;
            }
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
            var itemsEntity = new CiItemsEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    var id = dataRow[CiItemsTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0 && itemsEntity.AllowDelete == 1)
                    {
                        returnValue += this.Delete(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    var id = dataRow[CiItemsTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        itemsEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        returnValue += itemsEntity.AllowEdit == 1
                                    ? this.UpdateEntity(itemsEntity)
                                    : this.SetProperty(itemsEntity.Id, CiItemsTable.FieldSortCode, itemsEntity.SortCode);// 不允许编辑，但是排序还是允许的
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    this.GetFrom(dataRow);
                    returnValue += this.AddEntity(itemsEntity).Length > 0 ? 1 : 0;
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
