/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:23:26
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// RoleScopeManager
    /// 
    /// 角色权限域
    /// </summary>
    public partial class RoleScopeManager: DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetPermissionItemIds(string roleId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="roleId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiPermissionItemTable.TableName;
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

        #region private string GrantPermissionItem(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantPermissionId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantPermissionId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantPermissionItem(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantPermissionId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiRoleTable.TableName,
                ResourceId = roleId,
                TargetCategory = PiPermissionItemTable.TableName,
                TargetId = grantPermissionId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantPermissionItem(string roleId, string permissionItemCode, string grantPermissionId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantPermissionId">构限主键</param>
        /// <returns>主键</returns>
        public string GrantPermissionItem(string roleId, string permissionItemCode, string grantPermissionId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantPermissionItem(permissionScopeManager, roleId, permissionItemCode, grantPermissionId);
        }
        #endregion

        public int GrantPermissionItemes(string roleId, string permissionItemCode, string[] grantPermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantPermissionIds.Length; i++)
            {
                this.GrantPermissionItem(permissionScopeManager, roleId, permissionItemCode, grantPermissionIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantPermissionItemes(string[] roleIds, string permissionItemCode, string grantPermissionId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.GrantPermissionItem(permissionScopeManager, roleIds[i], permissionItemCode, grantPermissionId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantPermissionItems(string[] roleIds, string permissionItemCode, string[] grantPermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < grantPermissionIds.Length; j++)
                {
                    this.GrantPermissionItem(permissionScopeManager, roleIds[i], permissionItemCode, grantPermissionIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokePermissionItem(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokePermissionId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokePermissionId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokePermissionItem(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokePermissionId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiPermissionItemTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokePermissionId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokePermissionItem(string roleId, string permissionItemCode, string revokePermissionId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokePermissionId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokePermissionItem(string roleId, string permissionItemCode, string revokePermissionId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokePermissionItem(permissionScopeManager, roleId, permissionItemCode, revokePermissionId);
        }
        #endregion

        public int RevokePermissionItems(string roleId, string permissionItemCode, string[] revokePermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokePermissionIds.Length; i++)
            {
                this.RevokePermissionItem(permissionScopeManager, roleId, permissionItemCode, revokePermissionIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokePermissionItems(string[] roleIds, string permissionItemCode, string revokePermissionId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.RevokePermissionItem(permissionScopeManager, roleIds[i], permissionItemCode, revokePermissionId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokePermissionItems(string[] roleIds, string permissionItemCode, string[] revokePermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < revokePermissionIds.Length; j++)
                {
                    this.RevokePermissionItem(permissionScopeManager, roleIds[i], permissionItemCode, revokePermissionIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
