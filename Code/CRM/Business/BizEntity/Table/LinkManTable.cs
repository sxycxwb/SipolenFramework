//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    /// <summary>
    /// LinkManTable
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
    public partial class LinkManTable
    {
        ///<summary>
        /// 客户联系人
        ///</summary>
        [NonSerialized]
        public static string TableName = "LinkMan";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 客户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCustomerId = "CustomerId";

        ///<summary>
        /// 联系人名称
        ///</summary>
        [NonSerialized]
        public static string FieldName = "Name";

        ///<summary>
        /// 性别
        ///</summary>
        [NonSerialized]
        public static string FieldSex = "Sex";

        ///<summary>
        /// 职位
        ///</summary>
        [NonSerialized]
        public static string FieldPostion = "Postion";

        ///<summary>
        /// 部门
        ///</summary>
        [NonSerialized]
        public static string FieldDepartment = "Department";

        ///<summary>
        /// 是否是主联系人
        ///</summary>
        [NonSerialized]
        public static string FieldMainLinkMan = "MainLinkMan";

        ///<summary>
        /// 手机号码
        ///</summary>
        [NonSerialized]
        public static string FieldMobilePhone = "MobilePhone";

        ///<summary>
        /// 电话
        ///</summary>
        [NonSerialized]
        public static string FieldTelephone = "Telephone";

        ///<summary>
        /// 短号
        ///</summary>
        [NonSerialized]
        public static string FieldShortNumber = "ShortNumber";

        ///<summary>
        /// 身份证号码
        ///</summary>
        [NonSerialized]
        public static string FieldIDCard = "IDCard";

        ///<summary>
        /// 办公地址
        ///</summary>
        [NonSerialized]
        public static string FieldOfficeAddress = "OfficeAddress";

        ///<summary>
        /// 办公传真
        ///</summary>
        [NonSerialized]
        public static string FieldOfficeFax = "OfficeFax";

        ///<summary>
        /// 住宅电话
        ///</summary>
        [NonSerialized]
        public static string FieldHomePhone = "HomePhone";

        ///<summary>
        /// 最高学历
        ///</summary>
        [NonSerialized]
        public static string FieldEducation = "Education";

        ///<summary>
        /// 毕业院校
        ///</summary>
        [NonSerialized]
        public static string FieldSchool = "School";

        ///<summary>
        /// 最高学位
        ///</summary>
        [NonSerialized]
        public static string FieldDegree = "Degree";

        ///<summary>
        /// 家庭住址邮编
        ///</summary>
        [NonSerialized]
        public static string FieldHomeZipCode = "HomeZipCode";

        ///<summary>
        /// 家庭住址
        ///</summary>
        [NonSerialized]
        public static string FieldHomeAddress = "HomeAddress";

        ///<summary>
        /// 家庭传真
        ///</summary>
        [NonSerialized]
        public static string FieldHomeFax = "HomeFax";

        ///<summary>
        /// 籍贯
        ///</summary>
        [NonSerialized]
        public static string FieldNativePlace = "NativePlace";

        ///<summary>
        /// 政治面貌
        ///</summary>
        [NonSerialized]
        public static string FieldParty = "Party";

        ///<summary>
        /// 国籍
        ///</summary>
        [NonSerialized]
        public static string FieldNation = "Nation";

        ///<summary>
        /// 民族
        ///</summary>
        [NonSerialized]
        public static string FieldNationality = "Nationality";

        ///<summary>
        /// 专业
        ///</summary>
        [NonSerialized]
        public static string FieldMajor = "Major";

        ///<summary>
        /// 教育背景、学历
        ///</summary>
        [NonSerialized]
        public static string FieldEducationalBackground = "EducationalBackground";

        ///<summary>
        /// 生日类型（公历生日取值为1、农历生日取值为2），默认为1。
        ///</summary>
        [NonSerialized]
        public static string FieldBirthdayType = "BirthdayType";

        ///<summary>
        /// 生日
        ///</summary>
        [NonSerialized]
        public static string FieldBirthday = "Birthday";

        ///<summary>
        /// 血型
        ///</summary>
        [NonSerialized]
        public static string FieldBloodType = "BloodType";

        ///<summary>
        /// QQ号码，多个用英语逗号隔开。
        ///</summary>
        [NonSerialized]
        public static string FieldQQ = "QQ";

        ///<summary>
        /// 电子邮箱，多个用英语逗号隔开。
        ///</summary>
        [NonSerialized]
        public static string FieldEmail = "Email";

        ///<summary>
        /// 兴趣
        ///</summary>
        [NonSerialized]
        public static string FieldInterest = "Interest";

        ///<summary>
        /// 描述、备注
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeleteMark = "DeleteMark";

        ///<summary>
        /// 有效标志
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
