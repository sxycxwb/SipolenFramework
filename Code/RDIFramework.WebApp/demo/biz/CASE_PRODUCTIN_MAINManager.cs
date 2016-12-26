using System.Collections.Generic;
using System.Data;

namespace RDIFramework.WebApp
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CASE_PRODUCTIN_MAINManager
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
    public partial class CASE_PRODUCTIN_MAINManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CASE_PRODUCTIN_MAINManager()
        {
            base.CurrentTableName = CASE_PRODUCTIN_MAINTable.TableName;
            base.PrimaryKey = "ID";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CASE_PRODUCTIN_MAINManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CASE_PRODUCTIN_MAINManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CASE_PRODUCTIN_MAINManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CASE_PRODUCTIN_MAINManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public CASE_PRODUCTIN_MAINManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cASE_PRODUCTIN_MAINEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity)
        {
            return this.AddEntity(cASE_PRODUCTIN_MAINEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cASE_PRODUCTIN_MAINEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(cASE_PRODUCTIN_MAINEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cASE_PRODUCTIN_MAINEntity">实体</param>
        public int Update(CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity)
        {
            return this.UpdateEntity(cASE_PRODUCTIN_MAINEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CASE_PRODUCTIN_MAINEntity GetEntity(string id)
        {
            CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity = new CASE_PRODUCTIN_MAINEntity(this.GetDT(new KeyValuePair<string, object>(CASE_PRODUCTIN_MAINTable.FieldID, id)));
            return cASE_PRODUCTIN_MAINEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="cASE_PRODUCTIN_MAINEntity">实体</param>
        public string AddEntity(CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity)
        {
            string sequence = string.Empty;
            this.Identity = false;
            if (cASE_PRODUCTIN_MAINEntity.ID != null)
            {
                sequence = cASE_PRODUCTIN_MAINEntity.ID.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CASE_PRODUCTIN_MAINTable.FieldID);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(cASE_PRODUCTIN_MAINEntity.ID))
                {
                    sequence = BusinessLogic.NewGuid();
                    cASE_PRODUCTIN_MAINEntity.ID = sequence;
                }
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldID, cASE_PRODUCTIN_MAINEntity.ID);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CASE_PRODUCTIN_MAINTable.FieldID, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CASE_PRODUCTIN_MAINTable.FieldID, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(cASE_PRODUCTIN_MAINEntity.ID))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            cASE_PRODUCTIN_MAINEntity.ID = sequence;
                        }
                        sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldID, cASE_PRODUCTIN_MAINEntity.ID);
                    }
                }
            }
            this.SetEntity(sqlBuilder, cASE_PRODUCTIN_MAINEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldCREATEUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldCREATEBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTIN_MAINTable.FieldCREATEON);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldMODIFIEDUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldMODIFIEDBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTIN_MAINTable.FieldMODIFIEDON);
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
        /// <param name="cASE_PRODUCTIN_MAINEntity">实体</param>
        public int UpdateEntity(CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, cASE_PRODUCTIN_MAINEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldMODIFIEDUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldMODIFIEDBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTIN_MAINTable.FieldMODIFIEDON);
            sqlBuilder.SetWhere(CASE_PRODUCTIN_MAINTable.FieldID, cASE_PRODUCTIN_MAINEntity.ID);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="cASE_PRODUCTIN_MAINEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CASE_PRODUCTIN_MAINEntity cASE_PRODUCTIN_MAINEntity)
        {
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldCODE, cASE_PRODUCTIN_MAINEntity.CODE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldINDATE, cASE_PRODUCTIN_MAINEntity.INDATE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldINTYPE, cASE_PRODUCTIN_MAINEntity.INTYPE);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldDEPOT, cASE_PRODUCTIN_MAINEntity.DEPOT);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldCUSTODIAN, cASE_PRODUCTIN_MAINEntity.CUSTODIAN);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldSUPPLIERNAME, cASE_PRODUCTIN_MAINEntity.SUPPLIERNAME);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldDESCRIPTION, cASE_PRODUCTIN_MAINEntity.DESCRIPTION);
            sqlBuilder.SetValue(CASE_PRODUCTIN_MAINTable.FieldDELETEMARK, cASE_PRODUCTIN_MAINEntity.DELETEMARK);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(CASE_PRODUCTIN_MAINTable.FieldID, id));
        }
    }
}