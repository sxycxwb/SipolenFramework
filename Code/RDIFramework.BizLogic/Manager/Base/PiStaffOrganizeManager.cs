
namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;


    /// <summary>
    /// PiStaffOrganizeManager
    /// 管理层
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：1.0 XuWangBin 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    public partial class PiStaffOrganizeManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiStaffOrganizeManager()
        {
            base.CurrentTableName = PiStaffOrganizeTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiStaffOrganizeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiStaffOrganizeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiStaffOrganizeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiStaffOrganizeManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiStaffOrganizeManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piStaffOrganizeEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiStaffOrganizeEntity piStaffOrganizeEntity)
        {
            return this.AddEntity(piStaffOrganizeEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piStaffOrganizeEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(PiStaffOrganizeEntity piStaffOrganizeEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(piStaffOrganizeEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="piStaffOrganizeEntity">实体</param>
        public int Update(PiStaffOrganizeEntity piStaffOrganizeEntity)
        {
            return this.UpdateEntity(piStaffOrganizeEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiStaffOrganizeEntity GetEntity(string id)
        {
            //var piStaffOrganizeEntity = new PiStaffOrganizeEntity(this.GetDT(PiStaffOrganizeTable.FieldId, id));
            //return piStaffOrganizeEntity;
            return BaseEntity.Create<PiStaffOrganizeEntity>(this.GetDT(PiStaffOrganizeTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="piStaffOrganizeEntity">实体</param>
        public string AddEntity(PiStaffOrganizeEntity piStaffOrganizeEntity)
        {
            var sequence = string.Empty;
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiStaffOrganizeTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(piStaffOrganizeEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    piStaffOrganizeEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldId, piStaffOrganizeEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiStaffOrganizeTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiStaffOrganizeTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (piStaffOrganizeEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            piStaffOrganizeEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiStaffOrganizeTable.FieldId, piStaffOrganizeEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, piStaffOrganizeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiStaffOrganizeTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(PiStaffOrganizeTable.FieldModifiedOn);
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
        /// 更新实体
        /// </summary>
        /// <param name="piStaffOrganizeEntity">实体</param>
        public int UpdateEntity(PiStaffOrganizeEntity piStaffOrganizeEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, piStaffOrganizeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(PiStaffOrganizeTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(PiStaffOrganizeTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiStaffOrganizeTable.FieldId, piStaffOrganizeEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="piStaffOrganizeEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiStaffOrganizeEntity piStaffOrganizeEntity)
        {
            sqlBuilder.SetValue(PiStaffOrganizeTable.FieldStaffId, piStaffOrganizeEntity.StaffId);
            sqlBuilder.SetValue(PiStaffOrganizeTable.FieldOrganizeId, piStaffOrganizeEntity.OrganizeId);
            sqlBuilder.SetValue(PiStaffOrganizeTable.FieldDescription, piStaffOrganizeEntity.Description);
            sqlBuilder.SetValue(PiStaffOrganizeTable.FieldDeleteMark, piStaffOrganizeEntity.DeleteMark);           
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiStaffOrganizeTable.FieldId, id);
        }
    }
}
