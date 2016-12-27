﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//     RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//     RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
//	框架官网：http://www.rdiframework.net/
//	框架博客：http://blog.rdiframework.net/
//	交流QQ：406590790 
//	邮件交流：406590790@qq.com
//	其他博客：
//    http://www.cnblogs.com/huyong 
//    http://blog.csdn.net/chinahuyong
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由RDIFramework.NET平台代码生成工具自动生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion


using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// QueryEngineManager
    /// 查询引擎主表
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
    public partial class QueryEngineManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public QueryEngineManager()
        {
            base.CurrentTableName = QueryEngineTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public QueryEngineManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public QueryEngineManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public QueryEngineManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public QueryEngineManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public QueryEngineManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="queryEngineEntity">实体</param>
        /// <param name="statusCode">返回代码</param>
        /// <returns>主键</returns>
        public string Add(QueryEngineEntity queryEngineEntity, out string statusCode)
        {
            string returnValue = this.AddEntity(queryEngineEntity);
            statusCode = !string.IsNullOrEmpty(returnValue) ? StatusCode.OKAdd.ToString() : StatusCode.Error.ToString();
            return returnValue;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="queryEngineEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(QueryEngineEntity queryEngineEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(queryEngineEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="queryEngineEntity">实体</param>
        public int Update(QueryEngineEntity queryEngineEntity)
        {
            return this.UpdateEntity(queryEngineEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public QueryEngineEntity GetEntity(string id)
        {
            QueryEngineEntity queryEngineEntity = BaseEntity.Create<QueryEngineEntity>(this.GetDT(new KeyValuePair<string, object>(QueryEngineTable.FieldId, id)));
            return queryEngineEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="queryEngineEntity">实体</param>
        public string AddEntity(QueryEngineEntity queryEngineEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (queryEngineEntity.SortCode == null || queryEngineEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                queryEngineEntity.SortCode = int.Parse(sequence);
            }
            if (queryEngineEntity.Id != null)
            {
                sequence = queryEngineEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, QueryEngineTable.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(queryEngineEntity.Id)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    queryEngineEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(QueryEngineTable.FieldId, queryEngineEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(QueryEngineTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(QueryEngineTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(queryEngineEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            queryEngineEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(QueryEngineTable.FieldId, queryEngineEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, queryEngineEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(QueryEngineTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(QueryEngineTable.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(QueryEngineTable.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(QueryEngineTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(QueryEngineTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(QueryEngineTable.FieldModifiedOn);
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
        /// <param name="queryEngineEntity">实体</param>
        /// <param name="statusCode">返回代码</param>
        /// <returns>受影响的行数</returns>
        public int UpdateEntity(QueryEngineEntity queryEngineEntity, out string statusCode)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, queryEngineEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(QueryEngineTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(QueryEngineTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(QueryEngineTable.FieldModifiedOn);
            sqlBuilder.SetWhere(QueryEngineTable.FieldId, queryEngineEntity.Id);
            int returnValue =  sqlBuilder.EndUpdate();
            statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            return returnValue;
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">sql语句生成器</param>
        /// <param name="queryEngineEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, QueryEngineEntity queryEngineEntity)
        {
            sqlBuilder.SetValue(QueryEngineTable.FieldParentId, queryEngineEntity.ParentId);
            sqlBuilder.SetValue(QueryEngineTable.FieldCode, queryEngineEntity.Code);
            sqlBuilder.SetValue(QueryEngineTable.FieldFullName, queryEngineEntity.FullName);
            sqlBuilder.SetValue(QueryEngineTable.FieldAllowEdit, queryEngineEntity.AllowEdit);
            sqlBuilder.SetValue(QueryEngineTable.FieldAllowDelete, queryEngineEntity.AllowDelete);
            sqlBuilder.SetValue(QueryEngineTable.FieldDeleteMark, queryEngineEntity.DeleteMark);
            sqlBuilder.SetValue(QueryEngineTable.FieldDescription, queryEngineEntity.Description);
            sqlBuilder.SetValue(QueryEngineTable.FieldEnabled, queryEngineEntity.Enabled);
            sqlBuilder.SetValue(QueryEngineTable.FieldSortCode, queryEngineEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(QueryEngineTable.FieldId, id));
        }

        #region public int BatchDelete(string id) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(string[] ids)
        {
            return ids.Sum(t => this.Delete(t));
        }

        #endregion

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, QueryEngineTable.FieldParentId, parentId);
        }
    }
}