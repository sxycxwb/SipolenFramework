﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//	RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//	RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
// 官方博客：http://www.cnblogs.com/huyong
//           http://blog.csdn.net/chinahuyong
//    Email：80368704@qq.com
//       QQ：80368704
//------------------------------------------------------------------------------
// <auto-generated>
//	此代码由RDIFramework.NET平台代码生成工具自动生成。
//	运行时版本:4.0.30319.1
//
//	对此文件的更改可能会导致不正确的行为，并且如果
//	重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion

using System.Collections.Generic;


namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class CiMessageManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// CiMessageManager
        /// 信息服务管理器
        /// 
        /// 修改纪录
        /// 
        /// 2014-02-27 版本：2.8 创建主键。
        /// 
        /// 版本：2.8
        /// 
        /// <author>
        /// <name>XuWangBin</name>
        /// <date>2014-02-27</date>
        /// </author>
        /// </summary>
        public CiMessageManager()
        {
            base.CurrentTableName = CiMessageTable.TableName;
            base.PrimaryKey = "ID";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CiMessageManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CiMessageManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CiMessageManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CiMessageManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public CiMessageManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cIMESSAGEEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CiMessageEntity cIMESSAGEEntity)
        {
            return this.AddEntity(cIMESSAGEEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cIMESSAGEEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CiMessageEntity cIMESSAGEEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(cIMESSAGEEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cIMESSAGEEntity">实体</param>
        public int Update(CiMessageEntity cIMESSAGEEntity)
        {
            return this.UpdateEntity(cIMESSAGEEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CiMessageEntity GetEntity(string id)
        {
            //CiMessageEntity cIMESSAGEEntity = new CiMessageEntity(this.GetDT(new KeyValuePair<string, object>(CiMessageTable.FieldId, id)));
            //return cIMESSAGEEntity;
            return BaseEntity.Create<CiMessageEntity>(this.GetDT(new KeyValuePair<string, object>(CiMessageTable.FieldId, id)));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="cIMESSAGEEntity">实体</param>
        public string AddEntity(CiMessageEntity cIMESSAGEEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (cIMESSAGEEntity.SortCode == null || cIMESSAGEEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                cIMESSAGEEntity.SortCode = int.Parse(sequence);
            }
           
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CiMessageTable.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(cIMESSAGEEntity.Id)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    cIMESSAGEEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(CiMessageTable.FieldId, cIMESSAGEEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CiMessageTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CiMessageTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(cIMESSAGEEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            cIMESSAGEEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(CiMessageTable.FieldId, cIMESSAGEEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, cIMESSAGEEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(CiMessageTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiMessageTable.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(CiMessageTable.FieldCreateOn);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(CiMessageTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiMessageTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(CiMessageTable.FieldModifiedOn);
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
        /// <param name="cIMESSAGEEntity">实体</param>
        public int UpdateEntity(CiMessageEntity cIMESSAGEEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, cIMESSAGEEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(CiMessageTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(CiMessageTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiMessageTable.FieldId, cIMESSAGEEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="cIMESSAGEEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiMessageEntity cIMESSAGEEntity)
        {
            sqlBuilder.SetValue(CiMessageTable.FieldParentId, cIMESSAGEEntity.ParentId);
            sqlBuilder.SetValue(CiMessageTable.FieldFunctionCode, cIMESSAGEEntity.FunctionCode);
            sqlBuilder.SetValue(CiMessageTable.FieldCategoryCode, cIMESSAGEEntity.CategoryCode);
            sqlBuilder.SetValue(CiMessageTable.FieldObjectId, cIMESSAGEEntity.ObjectId);
            sqlBuilder.SetValue(CiMessageTable.FieldTitle, cIMESSAGEEntity.Title);
            sqlBuilder.SetValue(CiMessageTable.FieldMSGContent, cIMESSAGEEntity.MSGContent);
            sqlBuilder.SetValue(CiMessageTable.FieldReceiverId, cIMESSAGEEntity.ReceiverId);
            sqlBuilder.SetValue(CiMessageTable.FieldReceiverRealName, cIMESSAGEEntity.ReceiverRealName);
            sqlBuilder.SetValue(CiMessageTable.FieldIsNew, cIMESSAGEEntity.IsNew);
            sqlBuilder.SetValue(CiMessageTable.FieldReadCount, cIMESSAGEEntity.ReadCount);
            if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue(CiMessageTable.FieldReadDate, cIMESSAGEEntity.ReadDate != null ? BusinessLogic.GetOracleDateFormat(System.DateTime.Parse(cIMESSAGEEntity.ReadDate.ToString()), "yyyy-mm-dd hh24:mi:ss") : cIMESSAGEEntity.ReadDate);
            }
            else
            {
                sqlBuilder.SetValue(CiMessageTable.FieldReadDate, cIMESSAGEEntity.ReadDate);
            }
            
            sqlBuilder.SetValue(CiMessageTable.FieldTargetURL, cIMESSAGEEntity.TargetURL);
            sqlBuilder.SetValue(CiMessageTable.FieldIPAddress, cIMESSAGEEntity.IPAddress);
            sqlBuilder.SetValue(CiMessageTable.FieldDeleteMark, cIMESSAGEEntity.DeleteMark);
            sqlBuilder.SetValue(CiMessageTable.FieldEnabled, cIMESSAGEEntity.Enabled);
            sqlBuilder.SetValue(CiMessageTable.FieldDescription, cIMESSAGEEntity.Description);
            sqlBuilder.SetValue(CiMessageTable.FieldSortCode, cIMESSAGEEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(CiMessageTable.FieldId, id));
        }
    }
}
