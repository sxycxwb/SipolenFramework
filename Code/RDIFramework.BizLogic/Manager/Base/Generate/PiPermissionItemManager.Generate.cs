using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class PiPermissionItemManager : DbCommonManager, IDbCommonManager
	{
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiPermissionItemManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = PiPermissionItemTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiPermissionItemManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiPermissionItemManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiPermissionItemManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiPermissionItemManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiPermissionItemManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiPermissionItemEntity permissionItemEntity)
        {
            return this.AddEntity(permissionItemEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(PiPermissionItemEntity permissionItemEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(permissionItemEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        public int Update(PiPermissionItemEntity permissionItemEntity)
        {
            return this.UpdateEntity(permissionItemEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiPermissionItemEntity GetEntity(string id)
        {
            //PiPermissionItemEntity permissionItemEntity = new PiPermissionItemEntity(this.GetDT(PiPermissionItemTable.FieldId, id));
            //return permissionItemEntity;
            return BaseEntity.Create<PiPermissionItemEntity>(this.GetDT(PiPermissionItemTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        public string AddEntity(PiPermissionItemEntity permissionItemEntity)
        {
            string sequence = string.Empty;
            if (permissionItemEntity.SortCode == 0 || permissionItemEntity.SortCode == null)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName, sequenceManager.DefaultSequence);
                permissionItemEntity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(PiPermissionItemTable.TableName, PiPermissionItemTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(permissionItemEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    permissionItemEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiPermissionItemTable.FieldId, permissionItemEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiPermissionItemTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiPermissionItemTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (permissionItemEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            permissionItemEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiPermissionItemTable.FieldId, permissionItemEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, permissionItemEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionItemTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionItemTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionItemTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionItemTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionItemTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionItemTable.FieldModifiedOn);
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
        /// <param name="permissionItemEntity">实体</param>
        public int UpdateEntity(PiPermissionItemEntity permissionItemEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(PiPermissionItemTable.TableName);
            this.SetEntity(sqlBuilder, permissionItemEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionItemTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionItemTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionItemTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiPermissionItemTable.FieldId, permissionItemEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="permissionItemEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiPermissionItemEntity permissionItemEntity)
        {
            sqlBuilder.SetValue(PiPermissionItemTable.FieldParentId, permissionItemEntity.ParentId);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldModuleId, permissionItemEntity.ModuleId);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldCode, permissionItemEntity.Code);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldFullName, permissionItemEntity.FullName);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldCategoryCode, permissionItemEntity.CategoryCode);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldJsEvent, permissionItemEntity.JsEvent);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldIsSplit, permissionItemEntity.IsSplit);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldIsScope, permissionItemEntity.IsScope);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldIsPublic, permissionItemEntity.IsPublic);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldAllowEdit, permissionItemEntity.AllowEdit);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldAllowDelete, permissionItemEntity.AllowDelete);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldLastCall, permissionItemEntity.LastCall);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldEnabled, permissionItemEntity.Enabled);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldDeleteMark, permissionItemEntity.DeleteMark);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldSortCode, permissionItemEntity.SortCode);
            sqlBuilder.SetValue(PiPermissionItemTable.FieldDescription, permissionItemEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiPermissionItemTable.FieldId, id);
        }
	}
}
