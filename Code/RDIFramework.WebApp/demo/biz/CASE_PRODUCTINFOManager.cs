using System.Collections.Generic;

namespace RDIFramework.WebApp
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CASE_PRODUCTINFOManager
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
    public partial class CASE_PRODUCTINFOManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CASE_PRODUCTINFOManager()
        {
            base.CurrentTableName = CASE_PRODUCTINFOTable.TableName;
            base.PrimaryKey = "ID";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CASE_PRODUCTINFOManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CASE_PRODUCTINFOManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CASE_PRODUCTINFOManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CASE_PRODUCTINFOManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public CASE_PRODUCTINFOManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cASE_PRODUCTINFOEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CASE_PRODUCTINFOEntity cASE_PRODUCTINFOEntity)
        {
            return this.AddEntity(cASE_PRODUCTINFOEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cASE_PRODUCTINFOEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CASE_PRODUCTINFOEntity cASE_PRODUCTINFOEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(cASE_PRODUCTINFOEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cASE_PRODUCTINFOEntity">实体</param>
        public int Update(CASE_PRODUCTINFOEntity cASE_PRODUCTINFOEntity)
        {
            return this.UpdateEntity(cASE_PRODUCTINFOEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CASE_PRODUCTINFOEntity GetEntity(string id)
        {
            return BaseEntity.Create<CASE_PRODUCTINFOEntity>(this.GetDT(new KeyValuePair<string, object>(CASE_PRODUCTINFOTable.FieldID, id)));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="cASE_PRODUCTINFOEntity">实体</param>
        public string AddEntity(CASE_PRODUCTINFOEntity cASE_PRODUCTINFOEntity)
        {
            string sequence = string.Empty;
            this.Identity = false;
            if (cASE_PRODUCTINFOEntity.ID != null)
            {
                sequence = cASE_PRODUCTINFOEntity.ID;
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CASE_PRODUCTINFOTable.FieldID);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(cASE_PRODUCTINFOEntity.ID))
                {
                    sequence = BusinessLogic.NewGuid();
                    cASE_PRODUCTINFOEntity.ID = sequence;
                }
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldID, cASE_PRODUCTINFOEntity.ID);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CASE_PRODUCTINFOTable.FieldID, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CASE_PRODUCTINFOTable.FieldID, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(cASE_PRODUCTINFOEntity.ID))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            cASE_PRODUCTINFOEntity.ID = sequence;
                        }
                        sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldID, cASE_PRODUCTINFOEntity.ID);
                    }
                }
            }
            this.SetEntity(sqlBuilder, cASE_PRODUCTINFOEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldCREATEUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldCREATEBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTINFOTable.FieldCREATEON);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldMODIFIEDUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldMODIFIEDBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTINFOTable.FieldMODIFIEDON);
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
        /// <param name="cASE_PRODUCTINFOEntity">实体</param>
        public int UpdateEntity(CASE_PRODUCTINFOEntity cASE_PRODUCTINFOEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, cASE_PRODUCTINFOEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldMODIFIEDUSERID, UserInfo.Id);
                sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldMODIFIEDBY, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CASE_PRODUCTINFOTable.FieldMODIFIEDON);
            sqlBuilder.SetWhere(CASE_PRODUCTINFOTable.FieldID, cASE_PRODUCTINFOEntity.ID);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="cASE_PRODUCTINFOEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CASE_PRODUCTINFOEntity cASE_PRODUCTINFOEntity)
        {
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTCODE, cASE_PRODUCTINFOEntity.PRODUCTCODE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTNAME, cASE_PRODUCTINFOEntity.PRODUCTNAME);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTMODEL, cASE_PRODUCTINFOEntity.PRODUCTMODEL);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTSTANDARD, cASE_PRODUCTINFOEntity.PRODUCTSTANDARD);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTCATEGORY, cASE_PRODUCTINFOEntity.PRODUCTCATEGORY);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTUNIT, cASE_PRODUCTINFOEntity.PRODUCTUNIT);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTDESCRIPTION, cASE_PRODUCTINFOEntity.PRODUCTDESCRIPTION);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldMIDDLERATE, cASE_PRODUCTINFOEntity.MIDDLERATE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldREFERENCECOEFFICIENT, cASE_PRODUCTINFOEntity.REFERENCECOEFFICIENT);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPRODUCTPRICE, cASE_PRODUCTINFOEntity.PRODUCTPRICE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldWHOLESALEPRICE, cASE_PRODUCTINFOEntity.WHOLESALEPRICE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldPROMOTIONPRICE, cASE_PRODUCTINFOEntity.PROMOTIONPRICE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldINTERNALPRICE, cASE_PRODUCTINFOEntity.INTERNALPRICE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldSPECIALPRICE, cASE_PRODUCTINFOEntity.SPECIALPRICE);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldENABLED, cASE_PRODUCTINFOEntity.ENABLED);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldDESCRIPTION, cASE_PRODUCTINFOEntity.DESCRIPTION);
            sqlBuilder.SetValue(CASE_PRODUCTINFOTable.FieldDELETEMARK, cASE_PRODUCTINFOEntity.DELETEMARK);            
        }

        /// <summary>
        /// 物理删除产品数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(CASE_PRODUCTINFOTable.FieldID, id));
        }       
    }
}