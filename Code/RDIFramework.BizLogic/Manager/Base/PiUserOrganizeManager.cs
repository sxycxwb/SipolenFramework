/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-18 11:27:31
 ******************************************************************************/

using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

    /// <summary>
    /// PiUserOrganizeManager
    /// 用户账户组织关系表
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
    public partial class PiUserOrganizeManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiUserOrganizeManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = PiUserOrganizeTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiUserOrganizeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiUserOrganizeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiUserOrganizeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiUserOrganizeManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiUserOrganizeManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiUserOrganizeEntity entity)
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
        public string Add(PiUserOrganizeEntity entity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update(PiUserOrganizeEntity entity)
        {
            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiUserOrganizeEntity GetEntity(string id)
        {
            //var entity = new PiUserOrganizeEntity(this.GetDT(PiUserOrganizeTable.FieldId, id));
            //return entity;
            return BaseEntity.Create<PiUserOrganizeEntity>(this.GetDT(PiUserOrganizeTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(PiUserOrganizeEntity entity)
        {
            var sequence = string.Empty;
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiUserOrganizeTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(entity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    entity.Id = sequence;
                }
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldId, entity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiUserOrganizeTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiUserOrganizeTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (entity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            entity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiUserOrganizeTable.FieldId, entity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserOrganizeTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserOrganizeTable.FieldModifiedOn);
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
        public int UpdateEntity(PiUserOrganizeEntity entity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserOrganizeTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserOrganizeTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiUserOrganizeTable.FieldId, entity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiUserOrganizeEntity entity)
        {
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldUserId, entity.UserId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldCompanyId, entity.CompanyId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldSubCompanyId, entity.SubCompanyId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldDepartmentId, entity.DepartmentId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldSubDepartmentId, entity.SubDepartmentId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldWorkgroupId, entity.WorkgroupId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldRoleId, entity.RoleId);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldEnabled, entity.Enabled);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldDescription, entity.Description);
            sqlBuilder.SetValue(PiUserOrganizeTable.FieldDeleteMark, entity.DeleteMark);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiUserOrganizeTable.FieldId, id);
        }

        #region public string Add(BaseUserOrganizeEntity userOrganizeEntity, out string statusCode) 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userOrganizeEntity">用户组织机构实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>主键</returns>
        public string Add(PiUserOrganizeEntity userOrganizeEntity, out string statusCode)
        {
            var returnValue = string.Empty;
            // 判断数据是否重复了
            string[] names = { 
                                 PiUserOrganizeTable.FieldDeleteMark, 
                                 PiUserOrganizeTable.FieldEnabled,
                                 PiUserOrganizeTable.FieldCompanyId,
                                 PiUserOrganizeTable.FieldDepartmentId,
                                 PiUserOrganizeTable.FieldWorkgroupId, 
                                 PiUserOrganizeTable.FieldUserId 
                             };
            object[] values =
            {
                0, 
                1, 
                userOrganizeEntity.UserId,
                userOrganizeEntity.CompanyId,
                userOrganizeEntity.DepartmentId,
                userOrganizeEntity.WorkgroupId, 
                userOrganizeEntity.UserId
            };

            if (this.Exists(names, values))
            {
                statusCode = StatusCode.Exist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(userOrganizeEntity);
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public DataTable GetUserOrganizeDT(string userId) 获得用户的组织机构兼职情况
        /// <summary>
        /// 获得用户的组织机构兼职情况
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserOrganizeDT(string userId)
        {
            var sqlQuery = " SELECT PIUSERORGANIZE.* "
                            + "     , PiOrganize1.FULLNAME AS CompanyName "
                            + "     , PiOrganize2.FULLNAME AS SubCompanyName "
                            + "     , PiOrganize3.FULLNAME AS DepartmentName "
                            + "     , PiOrganize4.FULLNAME AS SubDepartmentName "
                            + "     , PiOrganize5.FULLNAME AS WorkGroupName "
                            + " FROM PIUSERORGANIZE LEFT OUTER JOIN "
                            + "     PIORGANIZE PiOrganize1 ON PIUSERORGANIZE.CompanyId = PiOrganize1.Id LEFT OUTER JOIN "
                            + "     PIORGANIZE PiOrganize2 ON PIUSERORGANIZE.SubCompanyId = PiOrganize2.Id LEFT OUTER JOIN "
                            + "     PIORGANIZE PiOrganize3 ON PIUSERORGANIZE.DepartmentId = PiOrganize3.Id LEFT OUTER JOIN "
                            + "     PIORGANIZE PiOrganize4 ON PIUSERORGANIZE.SubDepartmentId = PiOrganize4.Id LEFT OUTER JOIN "
                            + "     PIORGANIZE PiOrganize5 ON PIUSERORGANIZE.WorkgroupId = PiOrganize5.Id  "
                            + " WHERE USERID = '" + userId + "'AND  PIUSERORGANIZE.DELETEMARK = 0 ";
            
            return DBProvider.Fill(sqlQuery);
        }
        #endregion
    }
}
