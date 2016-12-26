/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-18 10:41:47
 ******************************************************************************/

using System;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  
    /// <summary>
    /// PiStaffManager
    /// 员工（职员）表
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
    public partial class PiStaffManager : DbCommonManager
    {
       /// <summary>
        /// 构造函数
        /// </summary>
        public PiStaffManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = PiStaffTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiStaffManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiStaffManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiStaffManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiStaffManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiStaffManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="staffEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiStaffEntity staffEntity)
        {
            return this.AddEntity(staffEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="staffEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(PiStaffEntity staffEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(staffEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="staffEntity">实体</param>
        public int Update(PiStaffEntity staffEntity)
        {
            return this.UpdateEntity(staffEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiStaffEntity GetEntity(string id)
        {
            //PiStaffEntity staffEntity = new PiStaffEntity(this.GetDT(PiStaffTable.FieldId, id));
            //return staffEntity;
            return BaseEntity.Create<PiStaffEntity>(this.GetDT(PiStaffTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="staffEntity">实体</param>
        public string AddEntity(PiStaffEntity staffEntity)
        {
            string sequence = string.Empty;
            if (staffEntity.SortCode == 0 || staffEntity.SortCode == null)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                staffEntity.SortCode = int.Parse(sequence);
            }
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(PiStaffTable.TableName, PiStaffTable.FieldId);
            if (!this.Identity)
            {
                if (String.IsNullOrEmpty(staffEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    staffEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiStaffTable.FieldId, staffEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiStaffTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiStaffTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (staffEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            staffEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiStaffTable.FieldId, staffEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, staffEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiStaffTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiStaffTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiStaffTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiStaffTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiStaffTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiStaffTable.FieldModifiedOn);
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
        /// <param name="staffEntity">实体</param>
        public int UpdateEntity(PiStaffEntity staffEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(PiStaffTable.TableName);
            this.SetEntity(sqlBuilder, staffEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiStaffTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiStaffTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiStaffTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiStaffTable.FieldId, staffEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">Sql语句生成器</param>
        /// <param name="staffEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiStaffEntity staffEntity)
        {
            //staffEntity.GetType().GetProperty("Birthday").PropertyType
            sqlBuilder.SetValue(PiStaffTable.FieldUserId, staffEntity.UserId);
            sqlBuilder.SetValue(PiStaffTable.FieldUserName, staffEntity.UserName);
            sqlBuilder.SetValue(PiStaffTable.FieldRealName, staffEntity.RealName);
            sqlBuilder.SetValue(PiStaffTable.FieldCode, staffEntity.Code);
            sqlBuilder.SetValue(PiStaffTable.FieldGender, staffEntity.Gender);
            sqlBuilder.SetValue(PiStaffTable.FieldDutyId, staffEntity.DutyId);
            sqlBuilder.SetValue(PiStaffTable.FieldIdentificationCode, staffEntity.IdentificationCode);
            sqlBuilder.SetValue(PiStaffTable.FieldIDCard, staffEntity.IDCard);
            sqlBuilder.SetValue(PiStaffTable.FieldBankCode, staffEntity.BankCode);
            sqlBuilder.SetValue(PiStaffTable.FieldEmail, staffEntity.Email);
            sqlBuilder.SetValue(PiStaffTable.FieldMobile, staffEntity.Mobile);
            sqlBuilder.SetValue(PiStaffTable.FieldShortNumber, staffEntity.ShortNumber);
            sqlBuilder.SetValue(PiStaffTable.FieldTelephone, staffEntity.Telephone);
            sqlBuilder.SetValue(PiStaffTable.FieldQICQ, staffEntity.QICQ);
            sqlBuilder.SetValue(PiStaffTable.FieldOfficePhone, staffEntity.OfficePhone);
            sqlBuilder.SetValue(PiStaffTable.FieldOfficeZipCode, staffEntity.OfficeZipCode);
            sqlBuilder.SetValue(PiStaffTable.FieldOfficeAddress, staffEntity.OfficeAddress);
            sqlBuilder.SetValue(PiStaffTable.FieldOfficeFax, staffEntity.OfficeFax);
            sqlBuilder.SetValue(PiStaffTable.FieldHomePhone, staffEntity.HomePhone);
            sqlBuilder.SetValue(PiStaffTable.FieldAge, staffEntity.Age);
            sqlBuilder.SetValue(PiStaffTable.FieldEducation, staffEntity.Education);
            sqlBuilder.SetValue(PiStaffTable.FieldSchool, staffEntity.School);
            sqlBuilder.SetValue(PiStaffTable.FieldDegree, staffEntity.Degree);
            sqlBuilder.SetValue(PiStaffTable.FieldTitle, staffEntity.Title);
            sqlBuilder.SetValue(PiStaffTable.FieldTitleLevel, staffEntity.TitleLevel);
            sqlBuilder.SetValue(PiStaffTable.FieldHomeZipCode, staffEntity.HomeZipCode);
            sqlBuilder.SetValue(PiStaffTable.FieldHomeAddress, staffEntity.HomeAddress);
            sqlBuilder.SetValue(PiStaffTable.FieldHomeFax, staffEntity.HomeFax);
            //sqlBuilder.SetValue(PiStaffTable.FieldCarCode, staffEntity.CarCode);
            //sqlBuilder.SetValue(PiStaffTable.FieldEmergencyContact, staffEntity.EmergencyContact);
            sqlBuilder.SetValue(PiStaffTable.FieldNativePlace, staffEntity.NativePlace);
            sqlBuilder.SetValue(PiStaffTable.FieldParty, staffEntity.Party);
            sqlBuilder.SetValue(PiStaffTable.FieldNation, staffEntity.Nation);
            sqlBuilder.SetValue(PiStaffTable.FieldNationality, staffEntity.Nationality);
            sqlBuilder.SetValue(PiStaffTable.FieldMajor, staffEntity.Major);
            sqlBuilder.SetValue(PiStaffTable.FieldWorkingProperty, staffEntity.WorkingProperty);
            sqlBuilder.SetValue(PiStaffTable.FieldCompetency, staffEntity.Competency);
            sqlBuilder.SetValue(PiStaffTable.FieldIsDimission, staffEntity.IsDimission);
            sqlBuilder.SetValue(PiStaffTable.FieldDimissionCause, staffEntity.DimissionCause);
            sqlBuilder.SetValue(PiStaffTable.FieldDimissionWhither, staffEntity.DimissionWhither);
            sqlBuilder.SetValue(PiStaffTable.FieldEnabled, staffEntity.Enabled);
            sqlBuilder.SetValue(PiStaffTable.FieldDeleteMark, staffEntity.DeleteMark);
            sqlBuilder.SetValue(PiStaffTable.FieldSortCode, staffEntity.SortCode);
            sqlBuilder.SetValue(PiStaffTable.FieldDescription, staffEntity.Description);
            if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue(PiStaffTable.FieldBirthday,staffEntity.Birthday != null ? BusinessLogic.GetOracleDateFormat(staffEntity.Birthday): staffEntity.Birthday);
                sqlBuilder.SetValue(PiStaffTable.FieldTitleDate, staffEntity.TitleDate != null ? BusinessLogic.GetOracleDateFormat(staffEntity.TitleDate) : staffEntity.TitleDate);
                sqlBuilder.SetValue(PiStaffTable.FieldWorkingDate, staffEntity.WorkingDate != null ? BusinessLogic.GetOracleDateFormat(staffEntity.WorkingDate) : staffEntity.WorkingDate);
                sqlBuilder.SetValue(PiStaffTable.FieldJoinInDate, staffEntity.JoinInDate != null ? BusinessLogic.GetOracleDateFormat(staffEntity.JoinInDate) : staffEntity.JoinInDate);
                sqlBuilder.SetValue(PiStaffTable.FieldDimissionDate, staffEntity.DimissionDate != null ? BusinessLogic.GetOracleDateFormat(staffEntity.DimissionDate) : staffEntity.DimissionDate);
            }
            else
            {
                sqlBuilder.SetValue(PiStaffTable.FieldBirthday, staffEntity.Birthday);
                sqlBuilder.SetValue(PiStaffTable.FieldTitleDate, staffEntity.TitleDate);
                sqlBuilder.SetValue(PiStaffTable.FieldWorkingDate, staffEntity.WorkingDate);
                sqlBuilder.SetValue(PiStaffTable.FieldJoinInDate, staffEntity.JoinInDate);
                sqlBuilder.SetValue(PiStaffTable.FieldDimissionDate, staffEntity.DimissionDate);
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiStaffTable.FieldId, id);
        }    
    }
}
