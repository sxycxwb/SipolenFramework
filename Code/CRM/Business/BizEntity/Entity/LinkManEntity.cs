//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// LinkManEntity
    /// 客户联系人
    /// 
    /// 修改纪录
    /// 
    /// 2016-01-08 版本：3.0 XuWangBin 针对3.0版本的基础业务实体BaseEntity重构。
    /// 2012-08-15 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-15</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class LinkManEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 客户主键
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Postion { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 是否是主联系人
        /// </summary>
        public int? MainLinkMan { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 短号
        /// </summary>
        public string ShortNumber { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 办公地址
        /// </summary>
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 办公传真
        /// </summary>
        public string OfficeFax { get; set; }

        /// <summary>
        /// 住宅电话
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// 最高学历
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        /// 毕业院校
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// 最高学位
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// 家庭住址邮编
        /// </summary>
        public string HomeZipCode { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        public string HomeAddress { get; set; }

        /// <summary>
        /// 家庭传真
        /// </summary>
        public string HomeFax { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Party { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Major { get; set; }

        /// <summary>
        /// 教育背景、学历
        /// </summary>
        public string EducationalBackground { get; set; }

        /// <summary>
        /// 生日类型（公历生日取值为1、农历生日取值为2），默认为1。
        /// </summary>
        public int? BirthdayType { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 血型
        /// </summary>
        public string BloodType { get; set; }

        /// <summary>
        /// QQ号码，多个用英语逗号隔开。
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 电子邮箱，多个用英语逗号隔开。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 兴趣
        /// </summary>
        public string Interest { get; set; }

        /// <summary>
        /// 描述、备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public LinkManEntity()
        {
            ModifiedOn = null;
            CreateOn = DateTime.Now;
            Birthday = null;
            SortCode = null;
            Enabled = 1;
            DeleteMark = 0;
            Birthday = null;
            BirthdayType = 1;
            MainLinkMan = 0;
            CustomerId = null;
            Id = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldId]);
            this.CustomerId = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldCustomerId]);
            this.Name = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldName]);
            this.Sex = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldSex]);
            this.Postion = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldPostion]);
            this.Department = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldDepartment]);
            this.MainLinkMan = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldMainLinkMan]);
            this.MobilePhone = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldMobilePhone]);
            this.Telephone = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldTelephone]);
            this.ShortNumber = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldShortNumber]);
            this.IDCard = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldIDCard]);
            this.OfficeAddress = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldOfficeAddress]);
            this.OfficeFax = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldOfficeFax]);
            this.HomePhone = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldHomePhone]);
            this.Education = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldEducation]);
            this.School = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldSchool]);
            this.Degree = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldDegree]);
            this.HomeZipCode = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldHomeZipCode]);
            this.HomeAddress = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldHomeAddress]);
            this.HomeFax = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldHomeFax]);
            this.NativePlace = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldNativePlace]);
            this.Party = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldParty]);
            this.Nation = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldNation]);
            this.Nationality = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldNationality]);
            this.Major = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldMajor]);
            this.EducationalBackground = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldEducationalBackground]);
            this.BirthdayType = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldBirthdayType]);
            this.Birthday = BusinessLogic.ConvertToDateTime(dataRow[LinkManTable.FieldBirthday]);
            this.BloodType = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldBloodType]);
            this.QQ = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldQQ]);
            this.Email = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldEmail]);
            this.Interest = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldInterest]);
            this.Description = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldDescription]);
            this.DeleteMark = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldDeleteMark]);
            this.Enabled = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldEnabled]);
            this.SortCode = BusinessLogic.ConvertToInt(dataRow[LinkManTable.FieldSortCode]);
            this.CreateOn = BusinessLogic.ConvertToDateTime(dataRow[LinkManTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToDateTime(dataRow[LinkManTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[LinkManTable.FieldModifiedBy]);
            return this;
        }
    }
}
