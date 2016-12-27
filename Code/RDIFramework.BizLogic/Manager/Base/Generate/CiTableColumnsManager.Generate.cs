//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , TECH, Ltd.
//--------------------------------------------------------------------
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CiTableColumnsManager
    /// 表字段结构定义说明
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
    public partial class TableColumnsManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TableColumnsManager()
        {
            base.CurrentTableName = CiTableColumnsTable.TableName;
            base.PrimaryKey = CiTableColumnsTable.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public TableColumnsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public TableColumnsManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public TableColumnsManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public TableColumnsManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public TableColumnsManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciTableColumnsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CiTableColumnsEntity ciTableColumnsEntity)
        {
            return this.AddEntity(ciTableColumnsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciTableColumnsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CiTableColumnsEntity ciTableColumnsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(ciTableColumnsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ciTableColumnsEntity">实体</param>
        public int Update(CiTableColumnsEntity ciTableColumnsEntity)
        {
            return this.UpdateEntity(ciTableColumnsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CiTableColumnsEntity GetEntity(string id)
        {
            //CiTableColumnsEntity ciTableColumnsEntity = new CiTableColumnsEntity(this.GetDT(CiTableColumnsTable.FieldId, id));
            //return ciTableColumnsEntity;
            return BaseEntity.Create<CiTableColumnsEntity>(this.GetDT(CiTableColumnsTable.FieldId, id));
        }

        #region public string AddEntity(CiTableColumnsEntity ciTableColumnsEntity) 添加实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="ciTableColumnsEntity">实体</param>
        public string AddEntity(CiTableColumnsEntity ciTableColumnsEntity)
        {
            string sequence = string.Empty;
            if (ciTableColumnsEntity.SortCode == null || ciTableColumnsEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                ciTableColumnsEntity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CiTableColumnsTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(ciTableColumnsEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    ciTableColumnsEntity.Id = sequence;
                }
                sqlBuilder.SetValue(CiTableColumnsTable.FieldId, ciTableColumnsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CiTableColumnsTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CiTableColumnsTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (ciTableColumnsEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            ciTableColumnsEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(CiTableColumnsTable.FieldId, ciTableColumnsEntity.Id);
                    }
                }
            }

            this.SetEntity(sqlBuilder, ciTableColumnsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiTableColumnsTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiTableColumnsTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiTableColumnsTable.FieldCreateBy, UserInfo.RealName);
                sqlBuilder.SetValue(CiTableColumnsTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiTableColumnsTable.FieldCreateOn);
            sqlBuilder.SetDBNow(CiTableColumnsTable.FieldModifiedOn);

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

        #region public int UpdateEntity(CiTableColumnsEntity ciTableColumnsEntity) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="ciTableColumnsEntity">实体</param>
        public int UpdateEntity(CiTableColumnsEntity ciTableColumnsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, ciTableColumnsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiTableColumnsTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(CiTableColumnsTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(CiTableColumnsTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiTableColumnsTable.FieldId, ciTableColumnsEntity.Id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public int Delete(string id) 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(CiTableColumnsTable.FieldId, id);
        }
        #endregion

        #region private void SetEntity(SQLBuilder sqlBuilder, CiTableColumnsEntity entity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity">SQL语句生成器</param>
        /// <param name="entity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiTableColumnsEntity entity)
        {
            sqlBuilder.SetValue(CiTableColumnsTable.FieldTableCode, entity.TableCode);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldTableName, entity.TableName);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnCode, entity.ColumnCode);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnName, entity.ColumnName);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldIsPublic, entity.IsPublic);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnAccess, entity.ColumnAccess);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnEdit, entity.ColumnEdit);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnDeney, entity.ColumnDeney);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldUseConstraint, entity.UseConstraint);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldDataType, entity.DataType);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldTargetTable, entity.TargetTable);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldIsSearchColumn, entity.IsSearchColumn);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldIsExhibitColumn, entity.IsExhibitColumn);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldEnabled, entity.Enabled);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldAllowEdit, entity.AllowEdit);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldAllowDelete, entity.AllowDelete);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldSortCode, entity.SortCode);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldDescription, entity.Description);
        }
        #endregion

        #region public int BatchDelete(string id) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(string[] ids)
        {
            return ids.Sum(t => this.Delete(t));
        }

        #endregion
    }
}
