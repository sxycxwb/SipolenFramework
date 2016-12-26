/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:32:33
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// RoleScopeManager
    /// 角色权限域
    /// 
    /// </summary>
    public partial class RoleScopeManager : DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetUserIds(string roleId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="roleId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiUserTable.TableName;
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

        #region private string GrantUser(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantUserId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantUserId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantUser(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantUserId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiRoleTable.TableName,
                ResourceId = roleId,
                TargetCategory = PiUserTable.TableName,
                TargetId = grantUserId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantUser(string roleId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantUserId"></param>
        /// <returns>主键</returns>
        public string GrantUser(string roleId, string permissionItemCode, string grantUserId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantUser(permissionScopeManager, roleId, permissionItemCode, grantUserId);
        }
        #endregion

        public int GrantUsers(string roleId, string permissionItemCode, string[] grantUserIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantUserIds.Length; i++)
            {
                this.GrantUser(permissionScopeManager, roleId, permissionItemCode, grantUserIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantUsers(string[] roleIds, string permissionItemCode, string grantUserId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.GrantUser(permissionScopeManager, roleIds[i], permissionItemCode, grantUserId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantUsers(string[] roleIds, string permissionItemCode, string[] grantUserIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < grantUserIds.Length; j++)
                {
                    this.GrantUser(permissionScopeManager, roleIds[i], permissionItemCode, grantUserIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeUser(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeUserId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeUser(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeUserId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiUserTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeUserId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);
            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokeUser(string roleId, string permissionItemCode, string revokeUserId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserId"></param>
        /// <returns>主键</returns>
        public int RevokeUser(string roleId, string permissionItemCode, string revokeUserId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeUser(permissionScopeManager, roleId, permissionItemCode, revokeUserId);
        }
        #endregion

        public int RevokeUsers(string roleId, string permissionItemCode, string[] revokeUserIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokeUserIds.Length; i++)
            {
                this.RevokeUser(permissionScopeManager, roleId, permissionItemCode, revokeUserIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeUsers(string[] roleIds, string permissionItemCode, string revokeUserId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.RevokeUser(permissionScopeManager, roleIds[i], permissionItemCode, revokeUserId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeUsers(string[] roleIds, string permissionItemCode, string[] revokeUserIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < revokeUserIds.Length; j++)
                {
                    this.RevokeUser(permissionScopeManager, roleIds[i], permissionItemCode, revokeUserIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
