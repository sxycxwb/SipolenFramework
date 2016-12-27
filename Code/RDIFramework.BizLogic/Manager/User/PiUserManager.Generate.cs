using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

     /// <summary>
     /// PiUserManager
     /// 用户账户表
     ///
     /// 修改纪录
     ///        2014-05-27 XuWangBin V2.8 增加子公司与子部门的管理。
     ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：1.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
    public partial class PiUserManager : DbCommonManager,IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiUserManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = PiUserTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiUserManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiUserManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiUserManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiUserManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiUserManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiUserEntity entity)
        {
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(PiUserEntity entity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update(PiUserEntity entity)
        {
            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiUserEntity GetEntity(string id)
        {
            //PiUserEntity entity = new PiUserEntity(this.GetDT(PiUserTable.FieldId, id));
            //return entity;
            return BaseEntity.Create<PiUserEntity>(this.GetDT(PiUserTable.FieldId, id));
        }

        public PiUserEntity GetEntityByUserName(string userName)
        {
            PiUserEntity entity = null;
            var parameters = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName),
                new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1),
                new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
            };
            DataTable dt = this.GetDT(parameters, 0, null);
            if (dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<PiUserEntity>(dt);
            }
            return entity;
        }
        
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userEntity">实体</param>
        public string AddEntity(PiUserEntity userEntity)
        {
            string sequence = string.Empty;
            if (userEntity.SortCode == 0 || userEntity.SortCode == null)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName, sequenceManager.DefaultSequence);
                userEntity.SortCode = int.Parse(sequence);
            }
            userEntity.QuickQuery = StringHelper.ToChineseSpell(userEntity.RealName);
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiUserTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(userEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    userEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiUserTable.FieldId, userEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiUserTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiUserTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (userEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            userEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiUserTable.FieldId, userEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, userEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserTable.FieldModifiedOn);
            if (DBProvider.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
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
        /// <param name="entity">实体</param>
        public int UpdateEntity(PiUserEntity entity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiUserTable.FieldId, entity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="entity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiUserEntity entity)
        {
            sqlBuilder.SetValue(PiUserTable.FieldCode, entity.Code);
            sqlBuilder.SetValue(PiUserTable.FieldUserName, entity.UserName);
            sqlBuilder.SetValue(PiUserTable.FieldRealName, entity.RealName);
            sqlBuilder.SetValue(PiUserTable.FieldRoleId, entity.RoleId);
            sqlBuilder.SetValue(PiUserTable.FieldNickName, entity.NickName);
            sqlBuilder.SetValue(PiUserTable.FieldQuickQuery, entity.QuickQuery);
            sqlBuilder.SetValue(PiUserTable.FieldWorkCategory, entity.WorkCategory);
            sqlBuilder.SetValue(PiUserTable.FieldCompanyId, entity.CompanyId);
            sqlBuilder.SetValue(PiUserTable.FieldCompanyName, entity.CompanyName);
            sqlBuilder.SetValue(PiUserTable.FieldSubCompanyId, entity.SubCompanyId);
            sqlBuilder.SetValue(PiUserTable.FieldSubCompanyName, entity.SubCompanyName);
            sqlBuilder.SetValue(PiUserTable.FieldDepartmentId, entity.DepartmentId);
            sqlBuilder.SetValue(PiUserTable.FieldDepartmentName, entity.DepartmentName);
            sqlBuilder.SetValue(PiUserTable.FieldSubDepartmentId, entity.SubDepartmentId);
            sqlBuilder.SetValue(PiUserTable.FieldSubDepartmentName, entity.SubDepartmentName);
            sqlBuilder.SetValue(PiUserTable.FieldWorkgroupId, entity.WorkgroupId);
            sqlBuilder.SetValue(PiUserTable.FieldWorkgroupName, entity.WorkgroupName);
            sqlBuilder.SetValue(PiUserTable.FieldGender, entity.Gender);
            sqlBuilder.SetValue(PiUserTable.FieldMobile, entity.Mobile);
            sqlBuilder.SetValue(PiUserTable.FieldTelephone, entity.Telephone);
            sqlBuilder.SetValue(PiUserTable.FieldBirthday, entity.Birthday);
            sqlBuilder.SetValue(PiUserTable.FieldDuty, entity.Duty);
            sqlBuilder.SetValue(PiUserTable.FieldTitle, entity.Title);
            sqlBuilder.SetValue(PiUserTable.FieldSecurityLevel, entity.SecurityLevel);
            sqlBuilder.SetValue(PiUserTable.FieldQICQ, entity.QICQ);
            sqlBuilder.SetValue(PiUserTable.FieldEmail, entity.Email);
            sqlBuilder.SetValue(PiUserTable.FieldLang, entity.Lang);
            sqlBuilder.SetValue(PiUserTable.FieldTheme, entity.Theme);
            sqlBuilder.SetValue(PiUserTable.FieldIsStaff, entity.IsStaff);
            sqlBuilder.SetValue(PiUserTable.FieldAuditStatus, entity.AuditStatus);
            sqlBuilder.SetValue(PiUserTable.FieldIsVisible, entity.IsVisible);
            sqlBuilder.SetValue(PiUserTable.FieldSignature, entity.Signature);
            sqlBuilder.SetValue(PiUserTable.FieldUserAddress, entity.UserAddress);
            sqlBuilder.SetValue(PiUserTable.FieldHomeAddress, entity.HomeAddress);
            sqlBuilder.SetValue(PiUserTable.FieldIsDimission, entity.IsDimission);
            sqlBuilder.SetValue(PiUserTable.FieldDimissionDate, entity.DimissionDate);
            sqlBuilder.SetValue(PiUserTable.FieldDimissionCause, entity.DimissionCause);
            sqlBuilder.SetValue(PiUserTable.FieldDimissionWhither, entity.DimissionWhither);
            sqlBuilder.SetValue(PiUserTable.FieldDeleteMark, entity.DeleteMark);
            sqlBuilder.SetValue(PiUserTable.FieldEnabled, entity.Enabled);
            sqlBuilder.SetValue(PiUserTable.FieldSortCode, entity.SortCode);
            sqlBuilder.SetValue(PiUserTable.FieldDescription, entity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {            
            return this.Delete(PiUserTable.FieldId, id);            
        }
    }
}
