//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CustomerManager
    /// 客户信息
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
    public partial class CustomerManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerManager()
        {
            base.CurrentTableName = CustomerTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CustomerManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CustomerManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CustomerManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CustomerManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public CustomerManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="customerEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CustomerEntity customerEntity)
        {
            return this.AddEntity(customerEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="customerClassEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(CustomerEntity customerEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            if (this.Exists(new string[] { CustomerTable.FieldFullName, CustomerTable.FieldDeleteMark }, new string[] { customerEntity.FullName, "0" }))
            {
                returnValue = string.Empty;
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(customerEntity);
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="customerEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(CustomerEntity customerEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(customerEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="customerEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>影响行数</returns>
        public int Update(CustomerEntity customerEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查用户名是否重复
            if (this.Exists(CustomerTable.FieldFullName, customerEntity.FullName, CustomerTable.FieldDeleteMark, "0", customerEntity.Id))
            {
                // 用户名已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.UpdateEntity(customerEntity);
                if (returnValue == 0)
                {
                    statusCode = StatusCode.ErrorDeleted.ToString();
                }
                else
                {
                    statusCode = StatusCode.OKUpdate.ToString();
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public CustomerEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public CustomerEntity GetEntity(int id)
        {            
            return BaseEntity.Create<CustomerEntity>(this.GetDT(CustomerTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="customerEntity">实体</param>
        public string AddEntity(CustomerEntity customerEntity)
        {
            string sequence = string.Empty;
            if (customerEntity.SortCode == null || customerEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                customerEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, CustomerTable.FieldId);
            if (!this.Identity) 
            {
                sqlBuilder.SetValue(CustomerTable.FieldId, customerEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(CustomerTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(CustomerTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (customerEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            customerEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(CustomerTable.FieldId, customerEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, customerEntity);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(CustomerTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CustomerTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CustomerTable.FieldCreateOn);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(CustomerTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(CustomerTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(CustomerTable.FieldModifiedOn);
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
        /// <param name="customerEntity">实体</param>
        public int UpdateEntity(CustomerEntity customerEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, customerEntity);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(CustomerTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(LinkManTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(CustomerTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CustomerTable.FieldId, customerEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, CustomerEntity customerEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="customerEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CustomerEntity customerEntity)
        {
            SetEntityExpand(sqlBuilder, customerEntity);
            sqlBuilder.SetValue(CustomerTable.FieldCode, customerEntity.Code);
            sqlBuilder.SetValue(CustomerTable.FieldCustomerClassID, customerEntity.CustomerClassID);
            sqlBuilder.SetValue(CustomerTable.FieldFullName, customerEntity.FullName);
            sqlBuilder.SetValue(CustomerTable.FieldShortName, customerEntity.ShortName);
            sqlBuilder.SetValue(CustomerTable.FieldCompanyName, customerEntity.CompanyName);
            sqlBuilder.SetValue(CustomerTable.FieldLelvel, customerEntity.Lelvel);
            sqlBuilder.SetValue(CustomerTable.FieldSatisfy, customerEntity.Satisfy);
            sqlBuilder.SetValue(CustomerTable.FieldCredit, customerEntity.Credit);
            sqlBuilder.SetValue(CustomerTable.FieldCompanyAddress, customerEntity.CompanyAddress);
            sqlBuilder.SetValue(CustomerTable.FieldPostalCode, customerEntity.PostalCode);
            sqlBuilder.SetValue(CustomerTable.FieldCompanyPhone, customerEntity.CompanyPhone);
            sqlBuilder.SetValue(CustomerTable.FieldCompanyFax, customerEntity.CompanyFax);
            sqlBuilder.SetValue(CustomerTable.FieldWebAddress, customerEntity.WebAddress);
            sqlBuilder.SetValue(CustomerTable.FieldEstablishDate, customerEntity.EstablishDate);
            sqlBuilder.SetValue(CustomerTable.FieldLicenceNo, customerEntity.LicenceNo);
            sqlBuilder.SetValue(CustomerTable.FieldChieftain, customerEntity.Chieftain);
            sqlBuilder.SetValue(CustomerTable.FieldBankroll, customerEntity.Bankroll);
            sqlBuilder.SetValue(CustomerTable.FieldTurnover, customerEntity.Turnover);
            sqlBuilder.SetValue(CustomerTable.FieldBank, customerEntity.Bank);
            sqlBuilder.SetValue(CustomerTable.FieldBankAccount, customerEntity.BankAccount);
            sqlBuilder.SetValue(CustomerTable.FieldLocalTaxNo, customerEntity.LocalTaxNo);
            sqlBuilder.SetValue(CustomerTable.FieldNationalTaxNo, customerEntity.NationalTaxNo);
            sqlBuilder.SetValue(CustomerTable.FieldStatus, customerEntity.Status);
            sqlBuilder.SetValue(CustomerTable.FieldDescription, customerEntity.Description);
            sqlBuilder.SetValue(CustomerTable.FieldDeleteMark, customerEntity.DeleteMark);
            sqlBuilder.SetValue(CustomerTable.FieldSortCode, customerEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(CustomerTable.FieldId, id));
        }      
    }
}
