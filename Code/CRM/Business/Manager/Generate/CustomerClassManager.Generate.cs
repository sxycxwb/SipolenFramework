//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CustomerClassManager
    /// 客户分类
    /// 
    /// 修改纪录
    /// 
    /// 2012-08-15 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-15</date>
    /// </author>
    /// </summary>
    public partial class CustomerClassManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerClassManager()
        {
            base.CurrentTableName = CustomerClassTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CustomerClassManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CustomerClassManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CustomerClassManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CustomerClassManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public CustomerClassManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="customerClassEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CustomerClassEntity customerClassEntity,out string statusCode)
        {
            string returnValue = string.Empty;
            returnValue=this.AddEntity(customerClassEntity);
            statusCode = StatusCode.OKAdd.ToString();
            return returnValue;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="customerClassEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CustomerClassEntity customerClassEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(customerClassEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="customerClassEntity">实体</param>
        public int Update(CustomerClassEntity customerClassEntity)
        {
            return this.UpdateEntity(customerClassEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CustomerClassEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public CustomerClassEntity GetEntity(int id)
        {
            //CustomerClassEntity customerClassEntity = new CustomerClassEntity(this.GetDT(new KeyValuePair<string, object>(CustomerClassTable.FieldId, id)));
            //return customerClassEntity;
            return BaseEntity.Create<CustomerClassEntity>(this.GetDT(CustomerClassTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="customerClassEntity">实体</param>
        public string AddEntity(CustomerClassEntity customerClassEntity)
        {
            string sequence = string.Empty;
            if (customerClassEntity.SortCode == null || customerClassEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                customerClassEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CustomerClassTable.FieldId);
            if (!this.Identity) 
            {
                sqlBuilder.SetValue(CustomerClassTable.FieldId, customerClassEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CustomerClassTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CustomerClassTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (customerClassEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            customerClassEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(CustomerClassTable.FieldId, customerClassEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, customerClassEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(CustomerClassTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CustomerClassTable.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(CustomerClassTable.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(CustomerClassTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(CustomerClassTable.FieldModifiedUserId, UserInfo.Id);
            } 
            sqlBuilder.SetDBNow(CustomerClassTable.FieldModifiedOn);
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
        /// <param name="customerClassEntity">实体</param>
        public int UpdateEntity(CustomerClassEntity customerClassEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, customerClassEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(CustomerClassTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(CustomerClassTable.FieldModifiedUserId, UserInfo.Id);
            } 
            sqlBuilder.SetDBNow(CustomerClassTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CustomerClassTable.FieldId, customerClassEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, CustomerClassEntity customerClassEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="customerClassEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CustomerClassEntity customerClassEntity)
        {
            SetEntityExpand(sqlBuilder, customerClassEntity);
            sqlBuilder.SetValue(CustomerClassTable.FieldParentId, customerClassEntity.ParentId);
            sqlBuilder.SetValue(CustomerClassTable.FieldClassName, customerClassEntity.ClassName);
            sqlBuilder.SetValue(CustomerClassTable.FieldClassCode, customerClassEntity.ClassCode);
            sqlBuilder.SetValue(CustomerClassTable.FieldDescription, customerClassEntity.Description);
            sqlBuilder.SetValue(CustomerClassTable.FieldSortCode, customerClassEntity.SortCode);
            sqlBuilder.SetValue(CustomerClassTable.FieldDeleteMark, customerClassEntity.DeleteMark);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(CustomerClassTable.FieldId, id));
        }       
    }
}
