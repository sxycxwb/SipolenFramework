/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-3-30 13:00:39
 ******************************************************************************/

using System;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

     /// <summary>
     /// PiOrganizeManager
     /// 组织机构、部门
     ///
     /// 修改纪录
    ///         2014-06-13 版本：2.8 EricHu 修改客户提出的：GetFullNameDepartment方法，访问多业务时扩展的不方便，不方便SOA的部署，解决了交叉依赖。
     ///        2013-05-12 版本：2.5 EricHu 修改客户提出的“Enabled”字段异常问题。
     ///		2012-03-02 版本：1.0 EricHu 创建主键。
     ///
     /// 版本：1.0
     ///
     /// <author>
     ///		<name>EricHu</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
    public partial class PiOrganizeManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiOrganizeManager()
        {
            base.CurrentTableName = PiOrganizeTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiOrganizeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiOrganizeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiOrganizeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiOrganizeManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiOrganizeManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiOrganizeEntity GetEntity(string id)
        {
            //PiOrganizeEntity piOrganizeEntity = new PiOrganizeEntity(this.GetDT(PiOrganizeTable.FieldId, id));
            //return piOrganizeEntity;
            return BaseEntity.Create<PiOrganizeEntity>(this.GetDT(PiOrganizeTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="piOrganizeEntity">实体</param>
        public string AddEntity(PiOrganizeEntity piOrganizeEntity, out string statusCode)
        {
            string sequence = string.Empty;
            statusCode = string.Empty;
            string[] names = new string[] { PiOrganizeTable.FieldParentId,PiOrganizeTable.FieldFullName,PiOrganizeTable.FieldDeleteMark};
            object[] values = new object[] { piOrganizeEntity.ParentId,piOrganizeEntity.FullName,piOrganizeEntity.DeleteMark};
            if (this.Exists(names, values))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                if (piOrganizeEntity.SortCode == null || piOrganizeEntity.SortCode == 0)
                {
                    CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                    sequence = sequenceManager.GetSequence(this.CurrentTableName, sequenceManager.DefaultSequence);
                    piOrganizeEntity.SortCode = int.Parse(sequence);
                }
                this.Identity = false;
                SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
                sqlBuilder.BeginInsert(this.CurrentTableName, PiOrganizeTable.FieldId);
                if (!this.Identity)
                {
                    if (String.IsNullOrEmpty(piOrganizeEntity.Id))
                    {
                        sequence = BusinessLogic.NewGuid();
                        piOrganizeEntity.Id = sequence;
                    }
                    sqlBuilder.SetValue(PiOrganizeTable.FieldId, piOrganizeEntity.Id);
                }
                else
                {
                    if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                        {
                            sqlBuilder.SetFormula(PiOrganizeTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                        }
                        if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                        {
                            sqlBuilder.SetFormula(PiOrganizeTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                        }
                    }
                    else
                    {
                        if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                        {
                            if (piOrganizeEntity.Id == null)
                            {
                                if (string.IsNullOrEmpty(sequence))
                                {
                                    CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                    sequence = sequenceManager.GetSequence(this.CurrentTableName);
                                }
                                piOrganizeEntity.Id = sequence;
                            }
                            sqlBuilder.SetValue(PiOrganizeTable.FieldId, piOrganizeEntity.Id);
                        }
                    }
                }
                this.SetEntity(sqlBuilder, piOrganizeEntity);
                //if (UserInfo != null)
                //{
                //    sqlBuilder.SetValue(PiOrganizeTable.FieldCreateUserId, UserInfo.Id);
                //    sqlBuilder.SetValue(PiOrganizeTable.FieldCreateBy, UserInfo.RealName);
                //}
                sqlBuilder.SetDBNow(PiOrganizeTable.FieldCreateOn);
                sqlBuilder.SetDBNow(PiOrganizeTable.FieldModifiedOn);
                if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
                {
                    sequence = sqlBuilder.EndInsert().ToString();
                    // 运行成功
                    statusCode = StatusCode.OKAdd.ToString();
                }
                else
                {
                    sqlBuilder.EndInsert();
                    // 运行成功
                    statusCode = StatusCode.OKAdd.ToString();
                }
            }
            return sequence;
        }

        public int Update(PiOrganizeEntity organizeEntity, out string statusCode)
        {
            int returnValue = 0;
            string[] names = { PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, PiOrganizeTable.FieldDeleteMark };
            Object[] values = { organizeEntity.ParentId, organizeEntity.FullName, 0 };

            if (this.Exists(names, values, organizeEntity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                // 检查编号是否重复
                names = new string[] { PiOrganizeTable.FieldCode, PiOrganizeTable.FieldDeleteMark };
                values = new object[] { organizeEntity.Code, 0 };

                if (organizeEntity.Code.Length > 0 && this.Exists(names, values, organizeEntity.Id))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    // 1:更新部门的信息
                    returnValue = this.UpdateEntity(organizeEntity);
                    // 2:更新组织机构时，同步更新用户表的公司、分公司、部门、子部门、工作组
                    var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldCompanyId, organizeEntity.Id), new KeyValuePair<string, object>(PiUserTable.FieldCompanyName, organizeEntity.FullName));
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldSubCompanyId, organizeEntity.Id), new KeyValuePair<string, object>(PiUserTable.FieldSubCompanyName, organizeEntity.FullName));
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldDepartmentId, organizeEntity.Id), new KeyValuePair<string, object>(PiUserTable.FieldDepartmentName, organizeEntity.FullName));
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldSubDepartmentId, organizeEntity.Id), new KeyValuePair<string, object>(PiUserTable.FieldSubDepartmentName, organizeEntity.FullName));
                    userManager.SetProperty(new KeyValuePair<string, object>(PiUserTable.FieldWorkgroupId, organizeEntity.Id), new KeyValuePair<string, object>(PiUserTable.FieldWorkgroupName, organizeEntity.FullName));

                    statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorChanged.ToString();
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="piOrganizeEntity">实体</param>
        public int UpdateEntity(PiOrganizeEntity piOrganizeEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, piOrganizeEntity);
            sqlBuilder.SetDBNow(PiOrganizeTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiOrganizeTable.FieldId, piOrganizeEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="piOrganizeEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiOrganizeEntity piOrganizeEntity)
        {
            sqlBuilder.SetValue(PiOrganizeTable.FieldParentId, piOrganizeEntity.ParentId);
            sqlBuilder.SetValue(PiOrganizeTable.FieldCode, piOrganizeEntity.Code);
            sqlBuilder.SetValue(PiOrganizeTable.FieldShortName, piOrganizeEntity.ShortName);
            sqlBuilder.SetValue(PiOrganizeTable.FieldFullName, piOrganizeEntity.FullName);
            sqlBuilder.SetValue(PiOrganizeTable.FieldCategory, piOrganizeEntity.Category);
            sqlBuilder.SetValue(PiOrganizeTable.FieldOuterPhone, piOrganizeEntity.OuterPhone);
            sqlBuilder.SetValue(PiOrganizeTable.FieldInnerPhone, piOrganizeEntity.InnerPhone);
            sqlBuilder.SetValue(PiOrganizeTable.FieldFax, piOrganizeEntity.Fax);
            sqlBuilder.SetValue(PiOrganizeTable.FieldPostalcode, piOrganizeEntity.Postalcode);
            sqlBuilder.SetValue(PiOrganizeTable.FieldAddress, piOrganizeEntity.Address);
            sqlBuilder.SetValue(PiOrganizeTable.FieldWeb, piOrganizeEntity.Web);
            sqlBuilder.SetValue(PiOrganizeTable.FieldManagerId, piOrganizeEntity.ManagerId);
            sqlBuilder.SetValue(PiOrganizeTable.FieldManager, piOrganizeEntity.Manager);
            sqlBuilder.SetValue(PiOrganizeTable.FieldLayer, piOrganizeEntity.Layer);
            sqlBuilder.SetValue(PiOrganizeTable.FieldAssistantManagerId, piOrganizeEntity.AssistantManagerId);
            sqlBuilder.SetValue(PiOrganizeTable.FieldAssistantManager, piOrganizeEntity.AssistantManager);
            sqlBuilder.SetValue(PiOrganizeTable.FieldIsInnerOrganize, piOrganizeEntity.IsInnerOrganize);
            sqlBuilder.SetValue(PiOrganizeTable.FieldEnabled, piOrganizeEntity.Enabled);
            sqlBuilder.SetValue(PiOrganizeTable.FieldBank, piOrganizeEntity.Bank);
            sqlBuilder.SetValue(PiOrganizeTable.FieldBankAccount, piOrganizeEntity.BankAccount);
            sqlBuilder.SetValue(PiOrganizeTable.FieldSortCode, piOrganizeEntity.SortCode);
            sqlBuilder.SetValue(PiOrganizeTable.FieldDescription, piOrganizeEntity.Description);
            sqlBuilder.SetValue(PiOrganizeTable.FieldModifiedUserId, piOrganizeEntity.ModifiedUserId);
            sqlBuilder.SetValue(PiOrganizeTable.FieldModifiedBy, piOrganizeEntity.ModifiedBy);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiOrganizeTable.FieldId, id);
        }

        public string AddEntity(PiOrganizeEntity entity)
        { 
            string statusCode = string.Empty;
            return this.AddEntity(entity, out statusCode);
        }
    }
}
