//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , gt TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

     /// <summary>
     /// PiRoleManager
     /// 系统角色表
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
     public partial class PiRoleManager : DbCommonManager, IDbCommonManager
     {
      /// <summary>
      /// 构造函数
      /// </summary>
      public PiRoleManager()
      {
          base.CurrentTableName = PiRoleTable.TableName;
          base.PrimaryKey = BusinessLogic.FieldId;
      }

      /// <summary>
      /// 构造函数
      /// <param name="tableName">指定表名</param>
      /// </summary>
      public PiRoleManager(string tableName)
      {
          base.CurrentTableName = tableName;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      public PiRoleManager(IDbProvider dbProvider): this()
      {
          DBProvider = dbProvider;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="userInfo">用户信息</param>
      public PiRoleManager(UserInfo userInfo) : this()
      {
          UserInfo = userInfo;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      /// <param name="userInfo">用户信息</param>
      public PiRoleManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
      {
          UserInfo = userInfo;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      /// <param name="userInfo">用户信息</param>
      /// <param name="tableName">指定表名</param>
      public PiRoleManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
      {
          base.CurrentTableName = tableName;
      }

      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="piRoleEntity">实体</param>
      /// <returns>主键</returns>
      public string Add(PiRoleEntity piRoleEntity)
      {
          return this.AddEntity(piRoleEntity);
      }

      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="piRoleEntity">实体</param>
      /// <param name="identity">自增量方式</param>
      /// <param name="returnId">返回主键</param>
      /// <returns>主键</returns>
      public string Add(PiRoleEntity piRoleEntity, bool identity, bool returnId)
      {
          this.Identity = identity;
          this.ReturnId = returnId;
          return this.AddEntity(piRoleEntity);
      }

      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="piRoleEntity">实体</param>
      public int Update(PiRoleEntity piRoleEntity)
      {
          return this.UpdateEntity(piRoleEntity);
      }

      /// <summary>
      /// 获取实体
      /// </summary>
      /// <param name="id">主键</param>
      public PiRoleEntity GetEntity(string id)
      {
          return BaseEntity.Create<PiRoleEntity>(this.GetDT(PiRoleTable.FieldId, id));
      }

      /// <summary>
      /// 添加实体
      /// </summary>
      /// <param name="piRoleEntity">实体</param>
      public string AddEntity(PiRoleEntity piRoleEntity)
      {
          string sequence = string.Empty;
          if (piRoleEntity.SortCode == null || piRoleEntity.SortCode == 0)
          {
              CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
              sequence = sequenceManager.GetSequence(this.CurrentTableName, sequenceManager.DefaultSequence);
              piRoleEntity.SortCode = int.Parse(sequence);
          }
           this.Identity = false;
           SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
           sqlBuilder.BeginInsert(this.CurrentTableName, PiRoleTable.FieldId);
           if (!this.Identity)
           {
               if (String.IsNullOrEmpty(piRoleEntity.Id))
               {
                   sequence = BusinessLogic.NewGuid();
                   piRoleEntity.Id = sequence;
               }
               sqlBuilder.SetValue(PiRoleTable.FieldId, piRoleEntity.Id);
           }
           else
           {
               if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
               {
                   if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                   {
                       sqlBuilder.SetFormula(PiRoleTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                   }
                   if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                   {
                       sqlBuilder.SetFormula(PiRoleTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                   }
               }
               else
               {
                   if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                   {
                       if (piRoleEntity.Id == null)
                       {
                           if (string.IsNullOrEmpty(sequence))
                           {
                               CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                               sequence = sequenceManager.GetSequence(this.CurrentTableName);
                           }
                           piRoleEntity.Id = sequence;
                       }
                       sqlBuilder.SetValue(PiRoleTable.FieldId, piRoleEntity.Id);
                   }
               }
           }
           this.SetEntity(sqlBuilder, piRoleEntity);
           if (UserInfo != null)
           {
               sqlBuilder.SetValue(PiRoleTable.FieldCreateUserId, UserInfo.Id);
               sqlBuilder.SetValue(PiRoleTable.FieldCreateBy, UserInfo.RealName);
           }
           sqlBuilder.SetDBNow(PiRoleTable.FieldCreateOn);
           if (UserInfo != null)
           {
               sqlBuilder.SetValue(PiRoleTable.FieldModifiedUserId, UserInfo.Id);
               sqlBuilder.SetValue(PiRoleTable.FieldModifiedBy, UserInfo.RealName);
           }
           sqlBuilder.SetDBNow(PiRoleTable.FieldModifiedOn);
           if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
           {
                sequence = sqlBuilder.EndInsert().ToString();
           }
           else
           {
               sqlBuilder.EndInsert();
           }
           // 运行成功
           return sequence;
      }

      /// <summary>
      /// 更新实体
      /// </summary>
      /// <param name="roleEntity">实体</param>
      public int UpdateEntity(PiRoleEntity roleEntity)
      {
          SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
          sqlBuilder.BeginUpdate(PiRoleTable.TableName);
          this.SetEntity(sqlBuilder, roleEntity);
          if (UserInfo != null)
          {
              sqlBuilder.SetValue(PiRoleTable.FieldModifiedUserId, UserInfo.Id);
              sqlBuilder.SetValue(PiRoleTable.FieldModifiedBy, UserInfo.RealName);
          }
          sqlBuilder.SetDBNow(PiRoleTable.FieldModifiedOn);
          sqlBuilder.SetWhere(PiRoleTable.FieldId, roleEntity.Id);
          return sqlBuilder.EndUpdate();
      }

      /// <summary>
      /// 设置实体
      /// </summary>
      /// <param name="sqlBuilder">sql语句生成器</param>
      /// <param name="piRoleEntity">实体</param>
      private void SetEntity(SQLBuilder sqlBuilder, PiRoleEntity piRoleEntity)
      {
          sqlBuilder.SetValue(PiRoleTable.FieldSystemId, piRoleEntity.SystemId);
          sqlBuilder.SetValue(PiRoleTable.FieldOrganizeId, piRoleEntity.OrganizeId);
          sqlBuilder.SetValue(PiRoleTable.FieldCategory, piRoleEntity.Category);
          sqlBuilder.SetValue(PiRoleTable.FieldCode, piRoleEntity.Code);
          sqlBuilder.SetValue(PiRoleTable.FieldEnabled, piRoleEntity.Enabled);
          sqlBuilder.SetValue(PiRoleTable.FieldRealName, piRoleEntity.RealName);
          sqlBuilder.SetValue(PiRoleTable.FieldAllowEdit, piRoleEntity.AllowEdit);
          sqlBuilder.SetValue(PiRoleTable.FieldAllowDelete, piRoleEntity.AllowDelete);
          sqlBuilder.SetValue(PiRoleTable.FieldSortCode, piRoleEntity.SortCode);
          sqlBuilder.SetValue(PiRoleTable.FieldDescription, piRoleEntity.Description);
      }
  }
}
