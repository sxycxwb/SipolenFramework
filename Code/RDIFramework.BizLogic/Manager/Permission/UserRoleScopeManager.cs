/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 16:39:43
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户对角色权限域
    /// </summary>
    public partial class UserScopeManager : DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetRoleIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>角色主键数组</returns>
        public string[] GetRoleIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiRoleTable.TableName;
            names[3] = PiPermissionScopeTable.FieldPermissionId;
            values[3] = this.GetIdByCode(permissionItemCode);

            DataTable dataTable = this.GetDT(names, values); 
            returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionScopeTable.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantRole(PiPermissionScopeManager permissionScopeManager, string id, string userId, string grantRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantRoleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantRole(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantRoleId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiUserTable.TableName,
                ResourceId = userId,
                TargetCategory = PiRoleTable.TableName,
                TargetId = grantRoleId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantRole(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantRoleId">授予的角色主键</param>
        /// <returns>主键</returns>
        public string GrantRole(string userId, string permissionItemCode, string grantRoleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantRole(permissionScopeManager, userId, permissionItemCode, grantRoleId);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantRoleIds"></param>
        /// <returns></returns>
        public int GrantRoles(string userId, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantRoleIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, userId, permissionItemCode, grantRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] userIds, string permissionItemCode, string grantRoleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, userIds[i], permissionItemCode, grantRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] userIds, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantRoleIds.Length; j++)
                {
                    this.GrantRole(permissionScopeManager, userIds[i], permissionItemCode, grantRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeRole(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeRoleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeRole(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeRoleId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiRoleTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeRoleId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokeRole(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeRoleId"></param>
        /// <returns>主键</returns>
        public int RevokeRole(string userId, string permissionItemCode, string revokeRoleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeRole(permissionScopeManager, userId, permissionItemCode, revokeRoleId);
        }
        #endregion

        public int RevokeRoles(string userId, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokeRoleIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, userId, permissionItemCode, revokeRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] userIds, string permissionItemCode, string revokeRoleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, userIds[i], permissionItemCode, revokeRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] userIds, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokeRoleIds.Length; j++)
                {
                    this.RevokeRole(permissionScopeManager, userIds[i], permissionItemCode, revokeRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
