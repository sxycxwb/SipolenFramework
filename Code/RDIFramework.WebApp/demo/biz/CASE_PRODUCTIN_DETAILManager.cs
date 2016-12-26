using System.Collections.Generic;

namespace RDIFramework.WebApp
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CASE_PRODUCTIN_DETAILManager
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2013-12-18 版本：1.0  创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date>2013-12-18</date>
    /// </author>
    /// </summary>
    public partial class CASE_PRODUCTIN_DETAILManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CASE_PRODUCTIN_DETAILManager()
        {
            base.CurrentTableName = CASE_PRODUCTIN_DETAILTable.TableName;
            base.PrimaryKey = "ID";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CASE_PRODUCTIN_DETAILManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CASE_PRODUCTIN_DETAILManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CASE_PRODUCTIN_DETAILManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CASE_PRODUCTIN_DETAILManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public CASE_PRODUCTIN_DETAILManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cASE_PRODUCTIN_DETAILEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity)
        {
            return this.AddEntity(cASE_PRODUCTIN_DETAILEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cASE_PRODUCTIN_DETAILEntity">实体</param>
        /// <param name="Identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity, bool Identity, bool returnId)
        {
            this.Identity = Identity;
            this.ReturnId = returnId;
            return this.AddEntity(cASE_PRODUCTIN_DETAILEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cASE_PRODUCTIN_DETAILEntity">实体</param>
        public int Update(CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity)
        {
            return this.UpdateEntity(cASE_PRODUCTIN_DETAILEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CASE_PRODUCTIN_DETAILEntity GetEntity(string id)
        {
            CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity = new CASE_PRODUCTIN_DETAILEntity(this.GetDT(new KeyValuePair<string, object>(CASE_PRODUCTIN_DETAILTable.FieldID, id)));
            return cASE_PRODUCTIN_DETAILEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="cASE_PRODUCTIN_DETAILEntity">实体</param>
        public string AddEntity(CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity)
        {
            string sequence = string.Empty;
            this.Identity = false;
            if (cASE_PRODUCTIN_DETAILEntity.ID != null)
            {
                sequence = cASE_PRODUCTIN_DETAILEntity.ID.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CASE_PRODUCTIN_DETAILTable.FieldID);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(cASE_PRODUCTIN_DETAILEntity.ID))
                {
                    sequence = BusinessLogic.NewGuid();
                    cASE_PRODUCTIN_DETAILEntity.ID = sequence;
                }
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldID, cASE_PRODUCTIN_DETAILEntity.ID);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CASE_PRODUCTIN_DETAILTable.FieldID, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CASE_PRODUCTIN_DETAILTable.FieldID, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(cASE_PRODUCTIN_DETAILEntity.ID))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            cASE_PRODUCTIN_DETAILEntity.ID = sequence;
                        }
                        sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldID, cASE_PRODUCTIN_DETAILEntity.ID);
                    }
                }
            }
            this.SetEntity(sqlBuilder, cASE_PRODUCTIN_DETAILEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldCREATEUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldCREATEBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTIN_DETAILTable.FieldCREATEON);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDON);
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
        /// <param name="cASE_PRODUCTIN_DETAILEntity">实体</param>
        public int UpdateEntity(CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, cASE_PRODUCTIN_DETAILEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDON);
            sqlBuilder.SetWhere(CASE_PRODUCTIN_DETAILTable.FieldID, cASE_PRODUCTIN_DETAILEntity.ID);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL发生器(ORM)</param>
        /// <param name="cASE_PRODUCTIN_DETAILEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CASE_PRODUCTIN_DETAILEntity cASE_PRODUCTIN_DETAILEntity)
        {
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldCASE_PRODUCTIN_MAIN_ID, cASE_PRODUCTIN_DETAILEntity.CASE_PRODUCTIN_MAIN_ID);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldSEQUENCE, cASE_PRODUCTIN_DETAILEntity.SEQUENCE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldCATEGORY, cASE_PRODUCTIN_DETAILEntity.CATEGORY);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldCODE, cASE_PRODUCTIN_DETAILEntity.CODE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldFULLNAME, cASE_PRODUCTIN_DETAILEntity.FULLNAME);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldMODEL, cASE_PRODUCTIN_DETAILEntity.MODEL);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldFORMAT, cASE_PRODUCTIN_DETAILEntity.FORMAT);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldUNIT, cASE_PRODUCTIN_DETAILEntity.UNIT);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldAMOUNT, cASE_PRODUCTIN_DETAILEntity.AMOUNT);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldUNITPRICE, cASE_PRODUCTIN_DETAILEntity.UNITPRICE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldTOTALSUM, cASE_PRODUCTIN_DETAILEntity.TOTALSUM);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldDELETEMARK, cASE_PRODUCTIN_DETAILEntity.DELETEMARK);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldSTATE, cASE_PRODUCTIN_DETAILEntity.STATE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_DETAILTable.FieldPEOPLE, cASE_PRODUCTIN_DETAILEntity.PEOPLE);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(CASE_PRODUCTIN_DETAILTable.FieldID, id));
        }
    }
}