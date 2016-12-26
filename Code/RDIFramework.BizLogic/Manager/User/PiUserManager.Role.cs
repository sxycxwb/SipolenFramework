using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class PiUserManager : DbCommonManager
    {
        public DataTable GetDTByRole(string roleId)
        {
            var sqlQuery = " SELECT * FROM " + PiUserTable.TableName
                            + " WHERE " + PiUserTable.FieldEnabled + "=1 "
                            + "       AND " + PiUserTable.FieldDeleteMark + "= 0 "
                            + "       AND (" + PiUserTable.FieldRoleId + "='" + roleId + "'"
                            + "            OR " + PiUserTable.FieldId + " IN "
                            + "           (SELECT " + PiUserRoleTable.FieldUserId
                            + "              FROM " + PiUserRoleTable.TableName
                            + "             WHERE " + PiUserRoleTable.FieldRoleId + " = '" + roleId + "'"
                            + "               AND " + PiUserRoleTable.FieldEnabled + " = 1"
                            + "                AND " + PiUserRoleTable.FieldDeleteMark + " = 0)) "
                            + " ORDER BY  " + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }

        public List<PiUserEntity> GetListByRole(string[] roleIds)
        {
            string commandText = "SELECT * FROM " + PiUserTable.TableName 
                               + " WHERE " + PiUserTable.FieldEnabled + " = 1    AND " + PiUserTable.FieldDeleteMark + "= 0   AND ( "
                                        + PiUserTable.FieldId + " IN            (SELECT  " + PiUserRoleTable.FieldUserId + "    FROM " + PiUserRoleTable.TableName
                                        + " WHERE " + PiUserRoleTable.FieldRoleId + " IN (" + string.Join(",", roleIds) + ")               AND " + PiUserRoleTable.FieldEnabled + " = 1                AND " + PiUserRoleTable.FieldDeleteMark + " = 0))  ORDER BY  " + PiUserTable.FieldSortCode;
            IDataReader dr = base.DBProvider.ExecuteReader(commandText);
            return base.GetList<PiUserEntity>(dr);
        }

        public int ClearUser(string roleId)
        {
            var returnValue = 0;
            this.SetProperty(PiUserTable.FieldRoleId, roleId,PiUserTable.FieldRoleId,null);

            var tableName = PiUserRoleTable.TableName;

            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo, tableName);
            returnValue += userRoleManager.Delete(PiUserRoleTable.FieldRoleId,roleId);
            return returnValue;
        }

        public int ClearRole(string userId)
        {
            var returnValue = 0;
            returnValue += this.SetProperty(PiUserTable.FieldId, userId, PiUserTable.FieldRoleId, null);


            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo, PiUserRoleTable.TableName);
            returnValue += userRoleManager.Delete(PiUserRoleTable.FieldUserId, userId);
            return returnValue;
        }

        /// <summary>
        /// 用户是否在某个角色中
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="realName">角色</param>
        /// <returns>存在</returns>
        public bool IsInRole(string userId, string realName)
        {
            var returnValue = false;
            if (string.IsNullOrEmpty(realName))
            {
                return false;
            }
            var roleManager = new PiRoleManager(this.DBProvider, this.UserInfo);
            var roleId = roleManager.GetId(PiRoleTable.FieldDeleteMark,0,PiRoleTable.FieldRealName,realName);
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            }
            var roleIds = GetAllRoleIds(userId);
            returnValue = StringHelper.Exists(roleIds, roleId);
            return returnValue;
        }

        /// <summary>
        /// 用户是否在某个角色中
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="code">角色编号</param>
        /// <returns>存在</returns>
        public bool IsInRoleByCode(string userId, string code)
        {
            var returnValue = false;
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            var roleManager = new PiRoleManager(this.DBProvider, this.UserInfo, PiRoleTable.TableName);
            var roleId = roleManager.GetId(PiRoleTable.FieldDeleteMark,0,PiRoleTable.FieldCode,code);
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            }
            var roleIds = GetAllRoleIds(userId);
            returnValue = StringHelper.Exists(roleIds, roleId);
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
            var sqlQuery = " SELECT ROLEID  "
                            + "   FROM " + PiUserRoleTable.TableName
                            + "  WHERE (USERID = '" + userId + "') "
                            + "    AND (RoleId IN (SELECT Id FROM PIROLE WHERE (DELETEMARK = 0))) AND (DELETEMARK = 0) ";
            var dataTable = DBProvider.Fill(sqlQuery);
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
            var tableName = PiUserRoleTable.TableName;           
            var roleTableName = PiRoleTable.TableName;

            // 被删除的角色不应该显示出来
            var sqlQuery = " SELECT ROLEID "
                            + "   FROM PIUSER "
                            + "  WHERE (DELETEMARK = 0) AND (ENABLED = 1) AND (ID = '" + userId + "') "
                            + "  UNION "
                            + " SELECT ROLEID "
                            + "   FROM " + tableName
                            + "  WHERE (DELETEMARK = 0) AND (ENABLED = 1) AND (USERID = '" + userId + "') AND (ROLEID IN (SELECT ID FROM " + roleTableName + " WHERE (DELETEMARK = 0))) ";
            var dataTable = DBProvider.Fill(sqlQuery);
            return BusinessLogic.FieldToArray(dataTable, PiUserRoleTable.FieldRoleId);
        }
        #endregion

        #region public string[] GetUserIdsInRole(string roleId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="roleId">角色代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIdsInRole(string roleId)
        {
            var tableName = PiUserRoleTable.TableName;          

            // 需要显示未被删除的用户
            var sqlQuery = " SELECT ID AS USERID FROM PIUSER WHERE (ROLEID = '" + roleId + "') AND (DELETEMARK = 0) AND (ENABLED = 1) "
                            + " UNION SELECT USERID FROM " + tableName + " WHERE (ROLEID = '" + roleId + "') AND (USERID IN (SELECT ID FROM PiUser WHERE (DELETEMARK = 0))) AND (DELETEMARK = 0) ";
            var dataTable = DBProvider.Fill(sqlQuery);
            return BusinessLogic.FieldToArray(dataTable, PiUserRoleTable.FieldUserId);
        }
        #endregion

        public string[] GetUserIds(string[] roleIds)
        {
            var tableName = PiUserRoleTable.TableName;          

            string[] userIds = null;
            if (roleIds != null && roleIds.Length > 0)
            {
                // 需要显示未被删除的用户
                var sqlQuery = "SELECT UserId FROM PIUSERROLE WHERE (RoleId IN (" + StringHelper.ArrayToList(roleIds) + ")) "
                                + "  AND (UserId IN (SELECT ID FROM PIUSER WHERE (DELETEMARK = 0))) AND (DeletionStateCode = 0) ";
                var dataTable = DBProvider.Fill(sqlQuery);
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
            var tableName = PiUserRoleTable.TableName;

            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo, tableName);
            return userRoleManager.Add(userRoleEntity);
        }
        #endregion

        public int AddToRole(string userId, string[] roleIds)
        {
            var returnValue = 0;
            for (var i = 0; i < roleIds.Length; i++)
            {
                this.AddToRole(userId, roleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string roleId)
        {
            var returnValue = 0;
            foreach (string t in userIds)
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
            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo, PiUserRoleTable.TableName);
            return userRoleManager.Delete(PiUserRoleTable.FieldUserId,userId,PiUserRoleTable.FieldRoleId,roleId);
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
            for (var i = 0; i < userIds.Length; i++)
            {
                // 删除用户角色
                returnValue += this.RemoveFormRole(userIds[i], roleId);
                // 如果该角色是用户默认角色，将用户默认角色置空
                this.SetProperty(PiUserTable.FieldId, userIds[i], PiUserTable.FieldRoleId, roleId, PiUserTable.FieldRoleId, null);
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
    }
}
