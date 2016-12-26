//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// IncomingCallManager
    /// 来电处理
    /// 
    /// 修改纪录
    /// 
    /// 2012-09-03 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-09-03</date>
    /// </author>
    /// </summary>
    public partial class IncomingCallManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IncomingCallManager()
        {
            base.CurrentTableName = IncomingCallTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public IncomingCallManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public IncomingCallManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public IncomingCallManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public IncomingCallManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public IncomingCallManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="incomingCallEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(IncomingCallEntity incomingCallEntity)
        {
            return this.AddEntity(incomingCallEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="incomingCallEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(IncomingCallEntity incomingCallEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(incomingCallEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="incomingCallEntity">实体</param>
        public int Update(IncomingCallEntity incomingCallEntity)
        {
            return this.UpdateEntity(incomingCallEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="incomingCallEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>影响行数</returns>
        public int Update(IncomingCallEntity incomingCallEntity, out string statusCode)
        {
            int returnValue = 0;           
            returnValue = this.UpdateEntity(incomingCallEntity);
            statusCode = returnValue == 0 ? StatusCode.ErrorDeleted.ToString() : StatusCode.OKUpdate.ToString();        

            return returnValue;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public IncomingCallEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public IncomingCallEntity GetEntity(int id)
        {            
            return BaseEntity.Create<IncomingCallEntity>(this.GetDT(IncomingCallTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="incomingCallEntity">实体</param>
        public string AddEntity(IncomingCallEntity incomingCallEntity)
        {
            string sequence = string.Empty;
            if (incomingCallEntity.SortCode == null || incomingCallEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                incomingCallEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, IncomingCallTable.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(IncomingCallTable.FieldId, incomingCallEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(IncomingCallTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(IncomingCallTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (incomingCallEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            incomingCallEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(IncomingCallTable.FieldId, incomingCallEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, incomingCallEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(IncomingCallTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(IncomingCallTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(IncomingCallTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(IncomingCallTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(IncomingCallTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(IncomingCallTable.FieldModifiedOn);
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
        /// <param name="incomingCallEntity">实体</param>
        public int UpdateEntity(IncomingCallEntity incomingCallEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, incomingCallEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(IncomingCallTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(IncomingCallTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(IncomingCallTable.FieldModifiedOn);
            sqlBuilder.SetWhere(IncomingCallTable.FieldId, incomingCallEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder"></param>
        /// <param name="incomingCallEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, IncomingCallEntity incomingCallEntity)
        {
            sqlBuilder.SetValue(IncomingCallTable.FieldCustomerId, incomingCallEntity.CustomerId);
            sqlBuilder.SetValue(IncomingCallTable.FieldCustomerName, incomingCallEntity.CustomerName);
            sqlBuilder.SetValue(IncomingCallTable.FieldCallType, incomingCallEntity.CallType);
            sqlBuilder.SetValue(IncomingCallTable.FieldCallRecord, incomingCallEntity.CallRecord);
            sqlBuilder.SetValue(IncomingCallTable.FieldCallNumber, incomingCallEntity.CallNumber);
            sqlBuilder.SetValue(IncomingCallTable.FieldCallDate, incomingCallEntity.CallDate);
            sqlBuilder.SetValue(IncomingCallTable.FieldHandled, incomingCallEntity.Handled);
            sqlBuilder.SetValue(IncomingCallTable.FieldDescription, incomingCallEntity.Description);
            sqlBuilder.SetValue(IncomingCallTable.FieldDeleteMark, incomingCallEntity.DeleteMark);
            sqlBuilder.SetValue(IncomingCallTable.FieldEnabled, incomingCallEntity.Enabled);
            sqlBuilder.SetValue(IncomingCallTable.FieldSortCode, incomingCallEntity.SortCode);           
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(IncomingCallTable.FieldId, id));
        }
    }
}