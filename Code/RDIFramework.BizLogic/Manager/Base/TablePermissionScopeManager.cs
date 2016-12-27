//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiTablePermissionScopeManager
    /// 表数据范围权限
    /// 
    /// 修改纪录
    /// 
    /// 2013-03-08 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2013-03-08</date>
    /// </author>
    /// </summary>
    public partial class TablePermissionScopeManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TablePermissionScopeManager()
        {
            base.CurrentTableName = PiTablePermissionScopeTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public TablePermissionScopeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public TablePermissionScopeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public TablePermissionScopeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public TablePermissionScopeManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public TablePermissionScopeManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiTablePermissionScopeEntity piTablePermissionScopeEntity)
        {
            return this.AddEntity(piTablePermissionScopeEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(PiTablePermissionScopeEntity piTablePermissionScopeEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(piTablePermissionScopeEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        public int Update(PiTablePermissionScopeEntity piTablePermissionScopeEntity)
        {
            return this.UpdateEntity(piTablePermissionScopeEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiTablePermissionScopeEntity GetEntity(string id)
        {
            //var piTablePermissionScopeEntity = new PiTablePermissionScopeEntity(this.GetDT(new KeyValuePair<string, object>(PiTablePermissionScopeTable.FieldId, id)));
            //return piTablePermissionScopeEntity;
            return BaseEntity.Create<PiTablePermissionScopeEntity>(this.GetDT(new KeyValuePair<string, object>(PiTablePermissionScopeTable.FieldId, id)));
        }

        public PiTablePermissionScopeEntity GetEntity(string name, object value)
        {
            //var piTablePermissionScopeEntity = new PiTablePermissionScopeEntity(this.GetDT(new KeyValuePair<string, object>(name, value), new KeyValuePair<string, object>(PiTablePermissionScopeTable.FieldDeleteMark, 0)));
            //return piTablePermissionScopeEntity;
            return BaseEntity.Create<PiTablePermissionScopeEntity>(this.GetDT(new KeyValuePair<string, object>(name, value), new KeyValuePair<string, object>(PiTablePermissionScopeTable.FieldDeleteMark, 0)));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        public string AddEntity(PiTablePermissionScopeEntity piTablePermissionScopeEntity)
        {
            var sequence = string.Empty;
            if (piTablePermissionScopeEntity.SortCode == null || piTablePermissionScopeEntity.SortCode == 0)
            {
                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName,sequenceManager.DefaultSequence);
                piTablePermissionScopeEntity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiTablePermissionScopeTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(piTablePermissionScopeEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    piTablePermissionScopeEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldId, piTablePermissionScopeEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiTablePermissionScopeTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiTablePermissionScopeTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (piTablePermissionScopeEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            piTablePermissionScopeEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldId, piTablePermissionScopeEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, piTablePermissionScopeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldCreateBy, UserInfo.RealName);
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiTablePermissionScopeTable.FieldCreateOn);
            sqlBuilder.SetDBNow(PiTablePermissionScopeTable.FieldModifiedOn);
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

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>返回</returns>
        public string Add(PiTablePermissionScopeEntity piTablePermissionScopeEntity, out string statusCode)
        {
            var returnValue = string.Empty;
            // 检查名称是否重复
            string[] names = { PiTablePermissionScopeTable.FieldDeleteMark, PiTablePermissionScopeTable.FieldItemCode, PiTablePermissionScopeTable.FieldItemName,PiTablePermissionScopeTable.FieldItemValue };
            object[] values = { 0, piTablePermissionScopeEntity.ItemCode, piTablePermissionScopeEntity.ItemName,piTablePermissionScopeEntity.ItemValue };
            if (this.Exists(names, values))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(piTablePermissionScopeEntity);
                // 添加成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            
            return returnValue;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        public int UpdateEntity(PiTablePermissionScopeEntity piTablePermissionScopeEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, piTablePermissionScopeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiTablePermissionScopeTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiTablePermissionScopeTable.FieldId, piTablePermissionScopeEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, PiTablePermissionScopeEntity piTablePermissionScopeEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder"></param>
        /// <param name="piTablePermissionScopeEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiTablePermissionScopeEntity piTablePermissionScopeEntity)
        {
            SetEntityExpand(sqlBuilder, piTablePermissionScopeEntity);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldParentId, piTablePermissionScopeEntity.ParentId);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldItemCode, piTablePermissionScopeEntity.ItemCode);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldItemName, piTablePermissionScopeEntity.ItemName);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldItemValue, piTablePermissionScopeEntity.ItemValue);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldEnabled, piTablePermissionScopeEntity.Enabled);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldIsPublic, piTablePermissionScopeEntity.IsPublic);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldAllowEdit, piTablePermissionScopeEntity.AllowEdit);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldAllowDelete, piTablePermissionScopeEntity.AllowDelete);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldDeleteMark, piTablePermissionScopeEntity.DeleteMark);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldSortCode, piTablePermissionScopeEntity.SortCode);
            sqlBuilder.SetValue(PiTablePermissionScopeTable.FieldDescription, piTablePermissionScopeEntity.Description);            
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(PiTablePermissionScopeTable.FieldId, id));
        }
    }
}