/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:26:56
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

        #region public string[] GetRoleIds(string roleId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="roleId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
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

        #region private string GrantRole(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantRoleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantRole(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantRoleId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiRoleTable.TableName,
                ResourceId = roleId,
                TargetCategory = PiRoleTable.TableName,
                TargetId = grantRoleId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantRole(string roleId, string permissionItemCode, string grantRoleId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantRoleId"></param>
        /// <returns>主键</returns>
        public string GrantRole(string roleId, string permissionItemCode, string grantRoleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantRole(permissionScopeManager, roleId, permissionItemCode, grantRoleId);
        }
        #endregion

        public int GrantRoles(string roleId, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantRoleIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, roleId, permissionItemCode, grantRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] roleIds, string permissionItemCode, string grantRoleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, roleIds[i], permissionItemCode, grantRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] roleIds, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < grantRoleIds.Length; j++)
                {
                    this.GrantRole(permissionScopeManager, roleIds[i], permissionItemCode, grantRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeRole(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeRoleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeRole(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeRoleId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiRoleTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeRoleId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokeRole(string roleId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeRoleId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeRole(string roleId, string permissionItemCode, string revokeRoleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeRole(permissionScopeManager, roleId, permissionItemCode, revokeRoleId);
        }
        #endregion

        public int RevokeRoles(string roleId, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokeRoleIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, roleId, permissionItemCode, revokeRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] roleIds, string permissionItemCode, string revokeRoleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, roleIds[i], permissionItemCode, revokeRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] roleIds, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < revokeRoleIds.Length; j++)
                {
                    this.RevokeRole(permissionScopeManager, roleIds[i], permissionItemCode, revokeRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
