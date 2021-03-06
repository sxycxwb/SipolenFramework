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
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// QueryEngineDefineManager
    /// 查询引擎定义
    /// 
    /// 修改纪录
    /// 
    /// 2015-09-18 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2015-09-18</date>
    /// </author>
    /// </summary>
    public partial class QueryEngineDefineManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public QueryEngineDefineManager()
        {
            base.CurrentTableName = QueryEngineDefineTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public QueryEngineDefineManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public QueryEngineDefineManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public QueryEngineDefineManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public QueryEngineDefineManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public QueryEngineDefineManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="queryEngineDefineEntity">实体</param>
        /// <param name="statusCode">返回代码</param>
        /// <returns>主键</returns>
        public string Add(QueryEngineDefineEntity queryEngineDefineEntity, out string statusCode)
        {
            string returnValue = this.AddEntity(queryEngineDefineEntity);
            statusCode = !string.IsNullOrEmpty(returnValue) ? StatusCode.OKAdd.ToString() : StatusCode.Error.ToString();
            return returnValue;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="queryEngineDefineEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(QueryEngineDefineEntity queryEngineDefineEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(queryEngineDefineEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="queryEngineDefineEntity">实体</param>
        /// <returns>影响行数</returns>
        public int Update(QueryEngineDefineEntity queryEngineDefineEntity)
        {
            return this.UpdateEntity(queryEngineDefineEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public QueryEngineDefineEntity GetEntity(string id)
        {
            QueryEngineDefineEntity queryEngineDefineEntity = BaseEntity.Create<QueryEngineDefineEntity>(this.GetDT(new KeyValuePair<string, object>(QueryEngineDefineTable.FieldId, id)));
            return queryEngineDefineEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="queryEngineDefineEntity">实体</param>
        public string AddEntity(QueryEngineDefineEntity queryEngineDefineEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (queryEngineDefineEntity.SortCode == null || queryEngineDefineEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                queryEngineDefineEntity.SortCode = int.Parse(sequence);
            }
            if (queryEngineDefineEntity.Id != null)
            {
                sequence = queryEngineDefineEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, QueryEngineDefineTable.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(queryEngineDefineEntity.Id)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    queryEngineDefineEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldId, queryEngineDefineEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(QueryEngineDefineTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(QueryEngineDefineTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(queryEngineDefineEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            queryEngineDefineEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(QueryEngineDefineTable.FieldId, queryEngineDefineEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, queryEngineDefineEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(QueryEngineDefineTable.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(QueryEngineDefineTable.FieldModifiedOn);
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
        /// <param name="queryEngineDefineEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(QueryEngineDefineEntity queryEngineDefineEntity, out string statusCode)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, queryEngineDefineEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(QueryEngineDefineTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(QueryEngineDefineTable.FieldModifiedOn);
            sqlBuilder.SetWhere(QueryEngineDefineTable.FieldId, queryEngineDefineEntity.Id);
            int returnValue = sqlBuilder.EndUpdate();
            statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            return returnValue;
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">sql语句生成器</param>
        /// <param name="queryEngineDefineEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, QueryEngineDefineEntity queryEngineDefineEntity)
        {
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldQueryEngineId, queryEngineDefineEntity.QueryEngineId);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldCode, queryEngineDefineEntity.Code);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldFullName, queryEngineDefineEntity.FullName);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldDataBaseLinkName, queryEngineDefineEntity.DataBaseLinkName);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldDataSourceType, queryEngineDefineEntity.DataSourceType);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldDataSourceName, queryEngineDefineEntity.DataSourceName);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldQueryStringKey, queryEngineDefineEntity.QueryStringKey);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldSelectedField, queryEngineDefineEntity.SelectedField);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldOrderByField, queryEngineDefineEntity.OrderByField);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldQueryString, queryEngineDefineEntity.QueryString);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldAllowEdit, queryEngineDefineEntity.AllowEdit);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldAllowDelete, queryEngineDefineEntity.AllowDelete);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldDeleteMark, queryEngineDefineEntity.DeleteMark);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldDescription, queryEngineDefineEntity.Description);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldEnabled, queryEngineDefineEntity.Enabled);
            sqlBuilder.SetValue(QueryEngineDefineTable.FieldSortCode, queryEngineDefineEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(QueryEngineDefineTable.FieldId, id));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(string[] ids)
        {
            return ids.Sum(t => this.Delete(t));
        }
    }
}
