//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------


namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiModuleManager
    /// 管理层
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：1.0 EricHu 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    public partial class PiModuleManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiModuleManager()
        {
            base.CurrentTableName = PiModuleTable.TableName;
            base.PrimaryKey       = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiModuleManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiModuleManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiModuleManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiModuleManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiModuleManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        #region public string Add(PiModuleEntity moduleEntity) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiModuleEntity moduleEntity)
        {
            return this.AddEntity(moduleEntity);
        }
        #endregion

        #region public string Add(PiModuleEntity moduleEntity, bool identity, bool returnId) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(PiModuleEntity moduleEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(moduleEntity);
        }
        #endregion

        #region public int Update(PiModuleEntity moduleEntity) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        public int Update(PiModuleEntity moduleEntity)
        {
            return this.UpdateEntity(moduleEntity);
        }
        #endregion

        #region public PiModuleEntity GetEntity(string id) 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiModuleEntity GetEntity(string id)
        {
            //PiModuleEntity moduleEntity = new PiModuleEntity(this.GetDT(PiModuleTable.FieldId,id));
            //return moduleEntity;
            return BaseEntity.Create<PiModuleEntity>(this.GetDT(PiModuleTable.FieldId, id));
        }
        #endregion

        #region public string AddEntity(PiModuleEntity moduleEntity) 添加实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        public string AddEntity(PiModuleEntity moduleEntity)
        {
            string sequence = string.Empty;
            if (moduleEntity.SortCode == null || moduleEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                moduleEntity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiModuleTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(moduleEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    moduleEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiModuleTable.FieldId, moduleEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiModuleTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiModuleTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (moduleEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            moduleEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiModuleTable.FieldId, moduleEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, moduleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiModuleTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiModuleTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiModuleTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiModuleTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiModuleTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiModuleTable.FieldModifiedOn);
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

        #region public int UpdateEntity(PiModuleEntity moduleEntity) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        public int UpdateEntity(PiModuleEntity moduleEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, moduleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiModuleTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiModuleTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiModuleTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiModuleTable.FieldId, moduleEntity.Id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region private void SetEntity(SQLBuilder sqlBuilder, PiModuleEntity moduleEntity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="moduleEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiModuleEntity moduleEntity)
        {
            sqlBuilder.SetValue(PiModuleTable.FieldParentId, moduleEntity.ParentId);
            sqlBuilder.SetValue(PiModuleTable.FieldCode, moduleEntity.Code);
            sqlBuilder.SetValue(PiModuleTable.FieldFullName, moduleEntity.FullName);
            sqlBuilder.SetValue(PiModuleTable.FieldCategory, moduleEntity.Category);
            sqlBuilder.SetValue(PiModuleTable.FieldModuleType, moduleEntity.ModuleType);
            sqlBuilder.SetValue(PiModuleTable.FieldImageIndex, moduleEntity.ImageIndex);
            sqlBuilder.SetValue(PiModuleTable.FieldSelectedImageIndex, moduleEntity.SelectedImageIndex);
            sqlBuilder.SetValue(PiModuleTable.FieldNavigateUrl, moduleEntity.NavigateUrl);
            sqlBuilder.SetValue(PiModuleTable.FieldMvcNavigateUrl, moduleEntity.MvcNavigateUrl);
            sqlBuilder.SetValue(PiModuleTable.FieldIconCss, moduleEntity.IconCss);
            sqlBuilder.SetValue(PiModuleTable.FieldIconUrl, moduleEntity.IconUrl);
            sqlBuilder.SetValue(PiModuleTable.FiledFormName, moduleEntity.FormName);
            sqlBuilder.SetValue(PiModuleTable.FiledAssemblyName, moduleEntity.AssemblyName);            
            sqlBuilder.SetValue(PiModuleTable.FieldTarget, moduleEntity.Target);
            sqlBuilder.SetValue(PiModuleTable.FieldIsPublic, moduleEntity.IsPublic);
            sqlBuilder.SetValue(PiModuleTable.FieldIsMenu, moduleEntity.IsMenu);
            sqlBuilder.SetValue(PiModuleTable.FieldExpand, moduleEntity.Expand);
            sqlBuilder.SetValue(PiModuleTable.FieldPermissionItemCode, moduleEntity.PermissionItemCode);
            sqlBuilder.SetValue(PiModuleTable.FieldPermissionScopeTables, moduleEntity.PermissionScopeTables);
            sqlBuilder.SetValue(PiModuleTable.FieldAllowEdit, moduleEntity.AllowEdit);
            sqlBuilder.SetValue(PiModuleTable.FieldAllowDelete, moduleEntity.AllowDelete);
            sqlBuilder.SetValue(PiModuleTable.FieldSortCode, moduleEntity.SortCode);
            sqlBuilder.SetValue(PiModuleTable.FieldDeleteMark, moduleEntity.DeleteMark);
            sqlBuilder.SetValue(PiModuleTable.FieldEnabled, moduleEntity.Enabled);
            sqlBuilder.SetValue(PiModuleTable.FieldDescription, moduleEntity.Description);
        }
        #endregion 

        #region public int Delete(int id) 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiModuleTable.FieldId, id);
        }
        #endregion
    }
}
