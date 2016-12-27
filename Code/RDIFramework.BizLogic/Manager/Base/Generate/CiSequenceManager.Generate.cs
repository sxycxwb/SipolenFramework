/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-16 15:13:43
 ******************************************************************************/


namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

    /// <summary>
    /// CiSequenceManager
    /// 序列产生器表
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
    public partial class CiSequenceManager : DbCommonManager
    {
        public bool FillZeroPrefix = true;     // 是否前缀补零
        public int DefaultSequence = 1000; // 默认升序序列号
        public int DefaultReduction = 9999999; // 默认降序序列号
        public string DefaultPrefix = "";       // 默认的前缀
        public string DefaultSeparator = "";       // 默认分隔符
        public int DefaultStep = 1;        // 递增或者递减数步调
        public int DefaultSequenceLength = 8;        // 默认的排序码长度
        public int SequenceLength = 8;        // 序列长度
        public bool UsePrefix = true;     // 是否采用前缀，补充0方式

        private static readonly object SequenceLock = new object();

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CiSequenceManager()
        {
            base.CurrentTableName = CiSequenceTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CiSequenceManager(string tableName)
            : this()
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CiSequenceManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CiSequenceManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CiSequenceManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="identity">是否自增</param>
        public CiSequenceManager(IDbProvider dbProvider, bool identity)
            : this()
        {
            this.DBProvider = dbProvider;
            this.Identity = identity;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public CiSequenceManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }
        #endregion

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciSequenceEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CiSequenceEntity ciSequenceEntity)
        {
            return this.AddEntity(ciSequenceEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciSequenceEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <returns>主键</returns>
        public string Add(CiSequenceEntity ciSequenceEntity, bool identity)
        {
            this.Identity = identity;
            return this.AddEntity(ciSequenceEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ciSequenceEntity">实体</param>
        public int Update(CiSequenceEntity ciSequenceEntity)
        {
            return this.UpdateEntity(ciSequenceEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CiSequenceEntity GetEntity(string id)
        {
            //CiSequenceEntity ciSequenceEntity = new CiSequenceEntity(this.GetDT(CiSequenceTable.FieldId, id));
            //return ciSequenceEntity;
            return BaseEntity.Create<CiSequenceEntity>(this.GetDT(CiSequenceTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="ciSequenceEntity">实体</param>
        public string AddEntity(CiSequenceEntity ciSequenceEntity)
        {
            string sequence = string.Empty;
           
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CiSequenceTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(ciSequenceEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    ciSequenceEntity.Id = sequence;
                }
                sqlBuilder.SetValue(CiSequenceTable.FieldId, ciSequenceEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CiSequenceTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CiSequenceTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(ciSequenceEntity.Id.ToString()))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            ciSequenceEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(CiSequenceTable.FieldId, ciSequenceEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, ciSequenceEntity);            
            sqlBuilder.SetDBNow(CiSequenceTable.FieldCreateOn);
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
        /// <param name="ciSequenceEntity">实体</param>
        public int UpdateEntity(CiSequenceEntity ciSequenceEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, ciSequenceEntity);           
            sqlBuilder.SetWhere(CiSequenceTable.FieldId, ciSequenceEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="ciSequenceEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiSequenceEntity ciSequenceEntity)
        {
            sqlBuilder.SetValue(CiSequenceTable.FieldFullName, ciSequenceEntity.FullName);
            sqlBuilder.SetValue(CiSequenceTable.FieldPrefix, ciSequenceEntity.Prefix);
            sqlBuilder.SetValue(CiSequenceTable.FieldSeparate, ciSequenceEntity.Separate);
            sqlBuilder.SetValue(CiSequenceTable.FieldSequence, ciSequenceEntity.Sequence);
            sqlBuilder.SetValue(CiSequenceTable.FieldReduction, ciSequenceEntity.Reduction);
            sqlBuilder.SetValue(CiSequenceTable.FieldStep, ciSequenceEntity.Step);
            sqlBuilder.SetValue(CiSequenceTable.FieldDescription, ciSequenceEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(CiSequenceTable.FieldId, id);
        }
    }
}
