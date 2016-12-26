//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , gt TECH, Ltd.
//--------------------------------------------------------------------


namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

    /// <summary>
    /// CiDbLinkDefineManager
    /// 数据库连接定义
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 EricHu 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class CiDbLinkDefineManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CiDbLinkDefineManager()
        {
            base.CurrentTableName = CiDbLinkDefineTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CiDbLinkDefineManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CiDbLinkDefineManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CiDbLinkDefineManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CiDbLinkDefineManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public CiDbLinkDefineManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CiDbLinkDefineEntity ciDbLinkDefineEntity)
        {
            return this.AddEntity(ciDbLinkDefineEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CiDbLinkDefineEntity ciDbLinkDefineEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(ciDbLinkDefineEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        public int Update(CiDbLinkDefineEntity ciDbLinkDefineEntity)
        {
            return this.UpdateEntity(ciDbLinkDefineEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CiDbLinkDefineEntity GetEntity(string id)
        {
            //var ciDbLinkDefineEntity = new CiDbLinkDefineEntity(this.GetDT(CiDbLinkDefineTable.FieldId, id));
            //return ciDbLinkDefineEntity;
            return BaseEntity.Create<CiDbLinkDefineEntity>(this.GetDT(CiDbLinkDefineTable.FieldId, id));
        }

        #region public string Add(CiDbLinkDefineEntity ciDbLinkDefineEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(CiDbLinkDefineEntity ciDbLinkDefineEntity, out string statusCode)
        {
            var returnValue = string.Empty;
            // 检查名称是否重复
            if (this.Exists(CiDbLinkDefineTable.FieldLinkName, ciDbLinkDefineEntity.LinkName))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(ciDbLinkDefineEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
               
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        public string AddEntity(CiDbLinkDefineEntity ciDbLinkDefineEntity)
        {
            var sequence = string.Empty;
            if (ciDbLinkDefineEntity.SortCode == null || ciDbLinkDefineEntity.SortCode == 0)
            {
                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                ciDbLinkDefineEntity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CiDbLinkDefineTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(ciDbLinkDefineEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    ciDbLinkDefineEntity.Id = sequence;
                }
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldId, ciDbLinkDefineEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CiDbLinkDefineTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CiDbLinkDefineTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (ciDbLinkDefineEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            ciDbLinkDefineEntity.Id =sequence;
                        }
                        sqlBuilder.SetValue(CiDbLinkDefineTable.FieldId, ciDbLinkDefineEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, ciDbLinkDefineEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiDbLinkDefineTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(CiDbLinkDefineTable.FieldModifiedOn);
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

        #region public int Update(CiDbLinkDefineEntity ciDbLinkDefineEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(CiDbLinkDefineEntity ciDbLinkDefineEntity, out string statusCode)
        {
            var returnValue = 0;           
        
            // 检查名称是否重复
            if (this.Exists(CiDbLinkDefineTable.FieldLinkName, ciDbLinkDefineEntity.LinkName, ciDbLinkDefineEntity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.UpdateEntity(ciDbLinkDefineEntity);
                statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            }

            //}
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        public int UpdateEntity(CiDbLinkDefineEntity ciDbLinkDefineEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, ciDbLinkDefineEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(CiDbLinkDefineTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(CiDbLinkDefineTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiDbLinkDefineTable.FieldId, ciDbLinkDefineEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="ciDbLinkDefineEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiDbLinkDefineEntity ciDbLinkDefineEntity)
        {
            sqlBuilder.SetValue(CiDbLinkDefineTable.FieldLinkName, ciDbLinkDefineEntity.LinkName);
            sqlBuilder.SetValue(CiDbLinkDefineTable.FieldLinkType, ciDbLinkDefineEntity.LinkType);
            sqlBuilder.SetValue(CiDbLinkDefineTable.FieldLinkData, ciDbLinkDefineEntity.LinkData);
            sqlBuilder.SetValue(CiDbLinkDefineTable.FieldEnabled, ciDbLinkDefineEntity.Enabled);
            sqlBuilder.SetValue(CiDbLinkDefineTable.FieldSortCode, ciDbLinkDefineEntity.SortCode);
            sqlBuilder.SetValue(CiDbLinkDefineTable.FieldDescription, ciDbLinkDefineEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(CiDbLinkDefineTable.FieldId, id);
        }
    }
}
