//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// LinkManManager
    /// 客户联系人
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
    public partial class LinkManManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LinkManManager()
        {
            base.CurrentTableName = LinkManTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public LinkManManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public LinkManManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public LinkManManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public LinkManManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public LinkManManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="linkManEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(LinkManEntity linkManEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            if (this.Exists(new string[] { LinkManTable.FieldCustomerId,LinkManTable.FieldName,CustomerTable.FieldDeleteMark }, new string[] { linkManEntity.CustomerId.ToString(),linkManEntity.Name, "0" }))
            {
                returnValue = string.Empty;
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(linkManEntity);
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;

           ;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="linkManEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(LinkManEntity linkManEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(linkManEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="linkManEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>影响行数</returns>
        public int Update(LinkManEntity linkManEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查用户名是否重复
            string[] names = { LinkManTable.FieldCustomerId, LinkManTable.FieldName, LinkManTable.FieldDeleteMark, };
            string[] values = { linkManEntity.CustomerId.ToString(), linkManEntity.Name, "0"};
            if (this.Exists(names, values, linkManEntity.Id))
            {
                // 用户名已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.UpdateEntity(linkManEntity);
                
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
        public LinkManEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public LinkManEntity GetEntity(int id)
        {
            return BaseEntity.Create<LinkManEntity>(this.GetDT(LinkManTable.FieldId, id));
        }       

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="linkManEntity">实体</param>
        public string AddEntity(LinkManEntity linkManEntity)
        {
            string sequence = string.Empty;
            if (linkManEntity.SortCode == null || linkManEntity.SortCode == 0)
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                linkManEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, LinkManTable.FieldId);
            if (!this.Identity) 
            {
                sqlBuilder.SetValue(LinkManTable.FieldId, linkManEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(LinkManTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(LinkManTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (linkManEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            linkManEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(LinkManTable.FieldId, linkManEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, linkManEntity);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(LinkManTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(LinkManTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(LinkManTable.FieldCreateOn);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(LinkManTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(LinkManTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(LinkManTable.FieldModifiedOn);
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
        /// <param name="linkManEntity">实体</param>
        public int UpdateEntity(LinkManEntity linkManEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, linkManEntity);
            if (UserInfo != null) 
            {
                sqlBuilder.SetValue(LinkManTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(LinkManTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(LinkManTable.FieldModifiedOn);
            sqlBuilder.SetWhere(LinkManTable.FieldId, linkManEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, LinkManEntity linkManEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="linkManEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, LinkManEntity linkManEntity)
        {
            SetEntityExpand(sqlBuilder, linkManEntity);
            sqlBuilder.SetValue(LinkManTable.FieldCustomerId, linkManEntity.CustomerId);
            sqlBuilder.SetValue(LinkManTable.FieldName, linkManEntity.Name);
            sqlBuilder.SetValue(LinkManTable.FieldSex, linkManEntity.Sex);
            sqlBuilder.SetValue(LinkManTable.FieldPostion, linkManEntity.Postion);
            sqlBuilder.SetValue(LinkManTable.FieldDepartment, linkManEntity.Department);
            sqlBuilder.SetValue(LinkManTable.FieldMainLinkMan, linkManEntity.MainLinkMan);
            sqlBuilder.SetValue(LinkManTable.FieldMobilePhone, linkManEntity.MobilePhone);
            sqlBuilder.SetValue(LinkManTable.FieldTelephone, linkManEntity.Telephone);
            sqlBuilder.SetValue(LinkManTable.FieldShortNumber, linkManEntity.ShortNumber);
            sqlBuilder.SetValue(LinkManTable.FieldIDCard, linkManEntity.IDCard);
            sqlBuilder.SetValue(LinkManTable.FieldOfficeAddress, linkManEntity.OfficeAddress);
            sqlBuilder.SetValue(LinkManTable.FieldOfficeFax, linkManEntity.OfficeFax);
            sqlBuilder.SetValue(LinkManTable.FieldHomePhone, linkManEntity.HomePhone);
            sqlBuilder.SetValue(LinkManTable.FieldEducation, linkManEntity.Education);
            sqlBuilder.SetValue(LinkManTable.FieldSchool, linkManEntity.School);
            sqlBuilder.SetValue(LinkManTable.FieldDegree, linkManEntity.Degree);
            sqlBuilder.SetValue(LinkManTable.FieldHomeZipCode, linkManEntity.HomeZipCode);
            sqlBuilder.SetValue(LinkManTable.FieldHomeAddress, linkManEntity.HomeAddress);
            sqlBuilder.SetValue(LinkManTable.FieldHomeFax, linkManEntity.HomeFax);
            sqlBuilder.SetValue(LinkManTable.FieldNativePlace, linkManEntity.NativePlace);
            sqlBuilder.SetValue(LinkManTable.FieldParty, linkManEntity.Party);
            sqlBuilder.SetValue(LinkManTable.FieldNation, linkManEntity.Nation);
            sqlBuilder.SetValue(LinkManTable.FieldNationality, linkManEntity.Nationality);
            sqlBuilder.SetValue(LinkManTable.FieldMajor, linkManEntity.Major);
            sqlBuilder.SetValue(LinkManTable.FieldEducationalBackground, linkManEntity.EducationalBackground);
            sqlBuilder.SetValue(LinkManTable.FieldBirthdayType, linkManEntity.BirthdayType);
            sqlBuilder.SetValue(LinkManTable.FieldBirthday, linkManEntity.Birthday);
            sqlBuilder.SetValue(LinkManTable.FieldBloodType, linkManEntity.BloodType);
            sqlBuilder.SetValue(LinkManTable.FieldQQ, linkManEntity.QQ);
            sqlBuilder.SetValue(LinkManTable.FieldEmail, linkManEntity.Email);
            sqlBuilder.SetValue(LinkManTable.FieldInterest, linkManEntity.Interest);
            sqlBuilder.SetValue(LinkManTable.FieldDescription, linkManEntity.Description);
            sqlBuilder.SetValue(LinkManTable.FieldDeleteMark, linkManEntity.DeleteMark);
            sqlBuilder.SetValue(LinkManTable.FieldEnabled, linkManEntity.Enabled);
            sqlBuilder.SetValue(LinkManTable.FieldSortCode, linkManEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(LinkManTable.FieldId, id));
        }
    }
}
