/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-13 10:04:04
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

     /// <summary>
     /// PiUserRoleManager
     /// 系统用户角色表
     ///
     /// 修改纪录
     ///        2013-10-10 版本：2.7 EricHu 修改Sql语句方式。
     ///		2012-03-02 版本：1.0 EricHu 创建主键。
     ///
     /// 版本：1.0
     ///
     /// <author>
     ///		<name>EricHu</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
    public partial class PiUserRoleManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiUserRoleManager()
        {
            base.CurrentTableName = PiUserRoleTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiUserRoleManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiUserRoleManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiUserRoleManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiUserRoleManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiUserRoleManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        public int EliminateRoleUser(string roleId)
        {
            var returnValue = 0;
            var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
            returnValue = userManager.SetProperty(PiUserTable.FieldRoleId, roleId, PiUserTable.FieldRoleId, null);
            
            returnValue += this.Delete(PiUserRoleTable.FieldRoleId, roleId);
            return returnValue;
        }

        public int ClearUserRole(string userId)
        {
            var returnValue = 0;
            var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
            returnValue += userManager.SetProperty(PiUserTable.FieldId, userId, PiUserTable.FieldRoleId, null);

            returnValue += this.Delete(PiUserRoleTable.FieldUserId, userId);
            return returnValue;
        }

        #region public string GetUserFullName(string id) 获取员工名称
        /// <summary>
        /// 获取员工名称
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>主键</returns>
        public string GetUserFullName(string id)
        {
            var userId = this.GetProperty(id, PiUserRoleTable.FieldUserId);
            return DbCommonLibary.GetProperty(DBProvider, PiStaffTable.TableName, PiStaffTable.FieldId, userId, PiStaffTable.FieldRealName);
        }
        #endregion

        #region public string GetRoleName(string id) 获取角色名称
        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>主键</returns>
        public string GetRoleName(string id)
        {
            var roleId = this.GetProperty(id, PiUserRoleTable.FieldRoleId);
            return DbCommonLibary.GetProperty(DBProvider, PiRoleTable.TableName, PiRoleTable.FieldId, roleId, PiRoleTable.FieldRealName);
        }
        #endregion

        public bool UserInRole(string userId, string roleCode)
        {
            var returnValue = false;
            if (string.IsNullOrEmpty(roleCode))
            {
                return false;
            }
            var roleManager = new PiRoleManager(this.DBProvider, this.UserInfo);
            var roleId = roleManager.GetId(PiRoleTable.FieldDeleteMark, 0, PiRoleTable.FieldCode, roleCode);
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            }
            var roleIds = GetAllRoleIds(userId);
            returnValue = BusinessLogic.Exists(roleIds, roleId);
            return returnValue;
        }

        #region public string[] GetRoleIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string userId)
        {
            // 被删除的角色不应该显示出来
            //string sqlQuery = " SELECT RoleId  "
            //                + "   FROM PiUserRole "
            //                + "  WHERE (UserId = " + userId + ") "
            //                + "    AND (RoleId IN (SELECT Id FROM PiRole WHERE (DeleteMark = 0))) AND (DeleteMark = 0) ";
            var sbQuery = new System.Text.StringBuilder();
            sbQuery.Append(" SELECT " + PiUserRoleTable.FieldRoleId + " FROM " + PiUserRoleTable.TableName);
            sbQuery.Append(" WHERE ( " + PiUserRoleTable.FieldUserId + " = '" + userId + "') ");
            sbQuery.Append(" AND ( " + PiUserRoleTable.FieldRoleId + " IN ( SELECT " + PiRoleTable.FieldId );
            sbQuery.Append(" FROM " + PiRoleTable.TableName + " WHERE (" + PiRoleTable.FieldDeleteMark + " = 0))) ");
            sbQuery.Append(" AND ( " + PiUserRoleTable.FieldDeleteMark + " = 0 ) ");
            var dataTable = DBProvider.Fill(sbQuery.ToString());
            return BusinessLogic.FieldToArray(dataTable, PiUserRoleTable.FieldRoleId);
        }
        #endregion

        #region public string[] GetRoleIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetAllRoleIds(string userId)
        {
            if (string.IsNullOrEmpty(userId.Trim()))
            {
                return new string[0];
            }
            else
            {
                // 被删除的角色不应该显示出来
                //string sqlQuery = " SELECT RoleId FROM PiUser WHERE (Id = " + userId + ") AND (DeleteMark = 0) AND (Enabled = 1) "
                //                + " UNION SELECT RoleId FROM PiUserRole WHERE (UserId = " + userId + ") AND (RoleId IN (SELECT Id FROM PiRole WHERE (DeleteMark = 0))) AND (DeleteMark = 0) ";
                var sbQuery = new System.Text.StringBuilder();
                sbQuery.Append(" SELECT " + PiUserTable.FieldRoleId + " FROM " + PiUserTable.TableName);
                sbQuery.Append(" WHERE ( " + PiUserTable.FieldId + " = '" + userId + "' ) AND ( " + PiUserTable.FieldDeleteMark + " = 0 ) AND (" + PiUserTable.FieldEnabled + " = 1) " );
                sbQuery.Append(" UNION SELECT  " + PiUserRoleTable.FieldRoleId + " FROM " + PiUserRoleTable.TableName);
                sbQuery.Append(" WHERE ( " + PiUserRoleTable.FieldUserId + " = '" + userId + "' ) AND ( " + PiUserRoleTable.FieldRoleId + " IN ( SELECT " + PiRoleTable.FieldId );
                sbQuery.Append(" FROM  " + PiRoleTable.TableName + " WHERE ( " + PiRoleTable.FieldDeleteMark + " = 0))) AND (" + PiUserRoleTable.FieldDeleteMark + " = 0 )");

                var dataTable = DBProvider.Fill(sbQuery.ToString());
                return BusinessLogic.FieldToArray(dataTable, PiUserRoleTable.FieldRoleId);
            }
        }
        #endregion

        #region public string[] GetUserIds(string roleId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="roleId">角色代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string roleId)
        {
            // 需要显示未被删除的用户
            //string sqlQuery = " SELECT Id AS USERID FROM PiUser WHERE (RoleId = " + roleId 
            //                + ") AND (DeleteMark = 0) AND (Enabled = 1) "
            //                + " UNION SELECT UserId FROM PiUserRole WHERE (RoleId = " + roleId 
            //                + ") AND (UserId IN (SELECT Id FROM PiUser WHERE (DeleteMark = 0))) AND (DeleteMark = 0) ";
            var sbQuery = new System.Text.StringBuilder();
            sbQuery.Append(" SELECT  " + PiUserTable.FieldId + " AS USERID FROM " + PiUserTable.TableName);
            sbQuery.Append("  WHERE ( " + PiUserTable.FieldRoleId + " = '" + roleId + "' ) AND ( " + PiUserTable.FieldDeleteMark + " = 0 ) ");
            sbQuery.Append("  AND ( " + PiUserTable.FieldEnabled + " = 1) ");
            sbQuery.Append("  UNION SELECT  " + PiUserRoleTable.FieldUserId + " FROM " + PiUserRoleTable.TableName );
            sbQuery.Append("  WHERE ( " + PiUserRoleTable.FieldRoleId + " = '" + roleId + "'");
            sbQuery.Append("  ) AND ( " + PiUserRoleTable.FieldUserId + " IN ( SELECT " + PiUserTable.FieldId );
            sbQuery.Append("  FROM  " + PiUserTable.TableName + " WHERE (" + PiUserTable.FieldDeleteMark + " = 0))) ");
            sbQuery.Append("  AND ( " + PiUserRoleTable.FieldDeleteMark + " = 0)");

            var dataTable = DBProvider.Fill(sbQuery.ToString());
            return BusinessLogic.FieldToArray(dataTable, PiUserRoleTable.FieldUserId);
        }
        #endregion

        public string[] GetUserIds(string[] roleIds)
        {
            string[] userIds = null;
            if (roleIds != null && roleIds.Length > 0)
            {
                // 需要显示未被删除的用户
                //string sqlQuery = " SELECT Id AS USERID FROM PiUser WHERE (RoleId IN ( " + BusinessLogic.ArrayToList(roleIds) + ")) AND (DeleteMark = 0) AND (Enabled = 1) "
                //                + " UNION SELECT UserId FROM PiUserRole WHERE (RoleId IN (" 
                //                + BusinessLogic.ArrayToList(roleIds) 
                //                + ")) AND (UserId IN (SELECT Id FROM PiUser WHERE (DeleteMark = 0))) AND (DeleteMark = 0) ";

                var sbQuery = new System.Text.StringBuilder();
                sbQuery.Append(" SELECT  " + PiUserTable.FieldId + " AS USERID FROM " + PiUserTable.TableName);
                sbQuery.Append(" WHERE ( " + PiUserTable.FieldRoleId + " IN( " + BusinessLogic.ArrayToList(roleIds,"'") + ")) ");
                sbQuery.Append(" AND ( " + PiUserTable.FieldDeleteMark + " = 0) AND (" + PiUserTable.FieldEnabled + " = 1 ) ");
                sbQuery.Append("  UNION SELECT " + PiUserRoleTable.FieldUserId + " FROM " + PiUserRoleTable.TableName );
                sbQuery.Append("  WHERE ( " + PiUserRoleTable.FieldRoleId + " IN( " + BusinessLogic.ArrayToList(roleIds,","));
                sbQuery.Append("  )) AND ( " + PiUserRoleTable.FieldUserId + " IN( SELECT " + PiUserTable.FieldId);
                sbQuery.Append("  FROM  " + PiUserTable.TableName + " WHERE ( " + PiUserTable.FieldDeleteMark + " = 0))) ");
                sbQuery.Append("   AND ( " + PiUserRoleTable.FieldDeleteMark + " = 0)");
                var dataTable = DBProvider.Fill(sbQuery.ToString());
                userIds = BusinessLogic.FieldToArray(dataTable, PiUserRoleTable.FieldUserId);
            }
            return userIds;
        }


        //
        // 加入到角色
        //

        #region public string AddToRole(string userId, string roleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键</returns>
        public string AddToRole(string userId, string roleId)
        {
            var returnValue = string.Empty;
            var userRoleEntity = new PiUserRoleEntity
            {
                UserId = userId,
                RoleId = roleId,
                Enabled = 1,
                DeleteMark = 0
            };
            //已经存在就不要再重复增加了。
            if (!this.Exists(new string[] { PiUserRoleTable.FieldUserId, PiUserRoleTable.FieldRoleId, PiUserRoleTable.FieldEnabled, PiUserRoleTable.FieldDeleteMark },
                             new object[] { userId, roleId, 1, 0 }))
            {
                returnValue = this.Add(userRoleEntity);
            }
            return returnValue;
        }
        #endregion

        public int AddToRole(string userId, string[] roleIds)
        {
            var returnValue = 0;
            foreach (var t in roleIds)
            {
                this.AddToRole(userId, t);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string roleId)
        {
            var returnValue = 0;
            foreach (var t in userIds)
            {
                this.AddToRole(t, roleId);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string[] roleIds)
        {
            var returnValue = 0;
            for (var i = 0; i < userIds.Length; i++)
            {
                for (var j = 0; j < roleIds.Length; j++)
                {
                    this.AddToRole(userIds[i], roleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  从角色中删除员工
        //

        #region public int RemoveFormRole(string userId, string roleId) 撤销角色权限
        /// <summary>
        /// 从角色中删除员工
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int RemoveFormRole(string userId, string roleId)
        {
            var names = new string[2];
            var values = new object[2];
            names[0] = PiUserRoleTable.FieldUserId;
            values[0] = userId;
            names[1] = PiUserRoleTable.FieldRoleId;
            values[1] = roleId;
            return this.Delete(names, values);
        }
        #endregion

        public int RemoveFormRole(string userId, string[] roleIds)
        {
            var returnValue = 0;
            for (var i = 0; i < roleIds.Length; i++)
            {
                returnValue += this.RemoveFormRole(userId, roleIds[i]);
            }
            return returnValue;
        }

        public int RemoveFormRole(string[] userIds, string roleId)
        {
            var returnValue = 0;
            var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
            for (var i = 0; i < userIds.Length; i++)
            {
                // 删除用户角色
                returnValue += this.RemoveFormRole(userIds[i], roleId);
                // 如果该角色是用户默认角色，将用户默认角色置空
                userManager.SetProperty(PiUserTable.FieldId, userIds[i], PiUserTable.FieldRoleId, roleId, PiUserTable.FieldRoleId, null);
            }
            return returnValue;
        }

        public int RemoveFormRole(string[] userIds, string[] roleIds)
        {
            var returnValue = 0;
            for (var i = 0; i < userIds.Length; i++)
            {
                for (var j = 0; j < roleIds.Length; j++)
                {
                    returnValue += this.RemoveFormRole(userIds[i], roleIds[j]);
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piUserRoleEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiUserRoleEntity piUserRoleEntity)
        {
            return this.AddEntity(piUserRoleEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piUserRoleEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(PiUserRoleEntity piUserRoleEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(piUserRoleEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="piUserRoleEntity">实体</param>
        public int Update(PiUserRoleEntity piUserRoleEntity)
        {
            return this.UpdateEntity(piUserRoleEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiUserRoleEntity GetEntity(string id)
        {
            //var piUserRoleEntity = new PiUserRoleEntity(this.GetDT(PiUserRoleTable.FieldId, id));
            //return piUserRoleEntity;
            return BaseEntity.Create<PiUserRoleEntity>(this.GetDT(PiUserRoleTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="piUserRoleEntity">实体</param>
        public string AddEntity(PiUserRoleEntity piUserRoleEntity)
        {
            var sequence = string.Empty;
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiUserRoleTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(piUserRoleEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    piUserRoleEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiUserRoleTable.FieldId, piUserRoleEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiUserRoleTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiUserRoleTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (piUserRoleEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            piUserRoleEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiUserRoleTable.FieldId, piUserRoleEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, piUserRoleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserRoleTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserRoleTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserRoleTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserRoleTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserRoleTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserRoleTable.FieldModifiedOn);
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
        /// <param name="piUserRoleEntity">实体</param>
        public int UpdateEntity(PiUserRoleEntity piUserRoleEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, piUserRoleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiUserRoleTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserRoleTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiUserRoleTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiUserRoleTable.FieldId, piUserRoleEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="piUserRoleEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiUserRoleEntity piUserRoleEntity)
        {
            sqlBuilder.SetValue(PiUserRoleTable.FieldUserId, piUserRoleEntity.UserId);
            sqlBuilder.SetValue(PiUserRoleTable.FieldRoleId, piUserRoleEntity.RoleId);
            sqlBuilder.SetValue(PiUserRoleTable.FieldDescription, piUserRoleEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiUserRoleTable.FieldId, id);
        }

        public int ClearRoleUser(string roleId)
        {
            var returnValue = 0;
            var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
            returnValue = userManager.SetProperty(PiUserTable.FieldRoleId, roleId, PiUserTable.FieldRoleId, null);

            returnValue += this.Delete(PiUserRoleTable.FieldRoleId, roleId);
            return returnValue;
        }        
    }
}
