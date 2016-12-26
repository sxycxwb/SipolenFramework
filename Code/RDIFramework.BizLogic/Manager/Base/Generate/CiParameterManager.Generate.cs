//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Aite TECH, Ltd.
//--------------------------------------------------------------------


namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

     /// <summary>
     /// CiParameterManager
     /// 系统参数配置表
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
    public partial class CiParameterManager : DbCommonManager
    {
          /// <summary>
          /// 构造函数
          /// </summary>
          public CiParameterManager()
          {
              base.CurrentTableName = CiParameterTable.TableName;
              base.PrimaryKey = BusinessLogic.FieldId;
          }

          /// <summary>
          /// 构造函数
          /// <param name="tableName">指定表名</param>
          /// </summary>
          public CiParameterManager(string tableName)
          {
              base.CurrentTableName = tableName;
          }

          /// <summary>
          /// 构造函数
          /// </summary>
          /// <param name="dbProvider">数据库连接</param>
          public CiParameterManager(IDbProvider dbProvider): this()
          {
              DBProvider = dbProvider;
          }

          /// <summary>
          /// 构造函数
          /// </summary>
          /// <param name="userInfo">用户信息</param>
          public CiParameterManager(UserInfo userInfo) : this()
          {
              UserInfo = userInfo;
          }

          /// <summary>
          /// 构造函数
          /// </summary>
          /// <param name="dbProvider">数据库连接</param>
          /// <param name="userInfo">用户信息</param>
          public CiParameterManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
          {
              UserInfo = userInfo;
          }

          /// <summary>
          /// 构造函数
          /// </summary>
          /// <param name="dbProvider">数据库连接</param>
          /// <param name="userInfo">用户信息</param>
          /// <param name="tableName">指定表名</param>
          public CiParameterManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
          {
              base.CurrentTableName = tableName;
          }

   
          /// <summary>
          /// 添加
          /// </summary>
          /// <param name="ciParameterEntity">实体</param>
          /// <param name="identity">自增量方式</param>
          /// <param name="returnId">返回主键</param>
          /// <returns>主键</returns>
          public string Add(CiParameterEntity ciParameterEntity, bool identity, bool returnId)
          {
              this.Identity = identity;
              this.ReturnId = returnId;
              return this.AddEntity(ciParameterEntity);
          }

          /// <summary>
          /// 获取实体
          /// </summary>
          /// <param name="id">主键</param>
          public CiParameterEntity GetEntity(string id)
          {
              return BaseEntity.Create<CiParameterEntity>(this.GetDT(CiParameterTable.FieldId, id));
          }

          /// <summary>
          /// 添加实体
          /// </summary>
          /// <param name="ciParameterEntity">实体</param>
          public string AddEntity(CiParameterEntity ciParameterEntity)
          {
              string sequence = string.Empty;
              if (ciParameterEntity.SortCode == null || ciParameterEntity.SortCode == 0)
              {
                  CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                  sequence = sequenceManager.GetSequence(this.CurrentTableName);
                  ciParameterEntity.SortCode = int.Parse(sequence);
              }
              this.Identity = false;
              SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
              sqlBuilder.BeginInsert(this.CurrentTableName, CiParameterTable.FieldId);

              if (!this.Identity)
              {
                  if (string.IsNullOrEmpty(ciParameterEntity.Id))
                  {
                      sequence = BusinessLogic.NewGuid();
                      ciParameterEntity.Id = sequence;
                  }
                  sqlBuilder.SetValue(CiParameterTable.FieldId, ciParameterEntity.Id);
              }
              else
              {
                  if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                  {
                      if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                      {
                          sqlBuilder.SetFormula(CiParameterTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                      }
                      if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                      {
                          sqlBuilder.SetFormula(CiParameterTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                      }
                  }
                  else
                  {
                      if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                      {
                          if (ciParameterEntity.Id == null)
                          {
                              if (string.IsNullOrEmpty(sequence))
                              {
                                  CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                  sequence = sequenceManager.GetSequence(this.CurrentTableName);
                              }
                              ciParameterEntity.Id = sequence;
                          }
                          sqlBuilder.SetValue(CiParameterTable.FieldId, ciParameterEntity.Id);
                      }
                  }
              }

              this.SetEntity(sqlBuilder, ciParameterEntity);
              if (UserInfo != null)
              {
                  sqlBuilder.SetValue(CiParameterTable.FieldCreateUserId, UserInfo.Id);
                  sqlBuilder.SetValue(CiParameterTable.FieldCreateBy, UserInfo.RealName);
              }
              sqlBuilder.SetDBNow(CiParameterTable.FieldCreateOn);
              if (UserInfo != null)
              {
                  sqlBuilder.SetValue(CiParameterTable.FieldModifiedUserId, UserInfo.Id);
                  sqlBuilder.SetValue(CiParameterTable.FieldModifiedBy, UserInfo.RealName);
              } 
              sqlBuilder.SetDBNow(CiParameterTable.FieldModifiedOn);

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
          /// <param name="ciParameterEntity">实体</param>
          public int UpdateEntity(CiParameterEntity ciParameterEntity)
          {
              SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
              sqlBuilder.BeginUpdate(this.CurrentTableName);
              this.SetEntity(sqlBuilder, ciParameterEntity);
              if (UserInfo != null) 
              { 
              sqlBuilder.SetValue(CiParameterTable.FieldModifiedBy, UserInfo.RealName);
              } 
              sqlBuilder.SetDBNow(CiParameterTable.FieldModifiedOn);
              sqlBuilder.SetWhere(CiParameterTable.FieldId, ciParameterEntity.Id);
              return sqlBuilder.EndUpdate();
          }

          /// <summary>
          /// 设置实体
          /// </summary>
          /// <param name="sqlBuilder">SQL语句生成器</param>
          /// <param name="ciParameterEntity">实体</param>
          private void SetEntity(SQLBuilder sqlBuilder, CiParameterEntity ciParameterEntity)
          {
              sqlBuilder.SetValue(CiParameterTable.FieldCategoryKey, ciParameterEntity.CategoryKey);
              sqlBuilder.SetValue(CiParameterTable.FieldParameterId, ciParameterEntity.ParameterId);
              sqlBuilder.SetValue(CiParameterTable.FieldParameterCode, ciParameterEntity.ParameterCode);
              sqlBuilder.SetValue(CiParameterTable.FieldParameterContent, ciParameterEntity.ParameterContent);
              sqlBuilder.SetValue(CiParameterTable.FieldWorked, ciParameterEntity.Worked);
              sqlBuilder.SetValue(CiParameterTable.FieldEnabled, ciParameterEntity.Enabled);
              sqlBuilder.SetValue(CiParameterTable.FieldAllowEdit, ciParameterEntity.AllowEdit);
              sqlBuilder.SetValue(CiParameterTable.FieldAllowDelete, ciParameterEntity.AllowDelete);
              sqlBuilder.SetValue(CiParameterTable.FieldDescription, ciParameterEntity.Description);
              sqlBuilder.SetValue(CiParameterTable.FieldSortCode, ciParameterEntity.SortCode);
              sqlBuilder.SetValue(CiParameterTable.FieldDeleteMark, ciParameterEntity.DeleteMark);
          }

          /// <summary>
          /// 删除实体
          /// </summary>
          /// <param name="id">主键</param>
          /// <returns>影响行数</returns>
          public int Delete(int id)
          {
              return this.Delete(CiParameterTable.FieldId, id);
          }
      }
}
