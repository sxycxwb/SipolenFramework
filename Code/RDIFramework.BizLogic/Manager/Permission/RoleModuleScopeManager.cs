/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 16:06:01
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

        #region public string[] GetModuleIds(string roleId, string permissionItemCode) 获取角色的模块权限主键数组
        /// <summary>
        /// 获取角色的模块权限主键数组
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetModuleIds(string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiModuleTable.TableName;
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

        #region private string GrantModule(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantModuleId">模块权限主键</param>
        /// <returns>主键</returns>
        private string GrantModule(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiRoleTable.TableName,
                ResourceId = roleId,
                TargetCategory = PiModuleTable.TableName,
                TargetId = grantModuleId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantModule(string roleId, string permissionItemCode, string grantModuleId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantModuleId">授予的模块主键</param>
        /// <returns>主键</returns>
        public string GrantModule(string roleId, string permissionItemCode, string grantModuleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantModule(permissionScopeManager, roleId, permissionItemCode, grantModuleId);
        }
        #endregion

        public int GrantModules(string roleId, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantModuleIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, roleId, permissionItemCode, grantModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] roleIds, string permissionItemCode, string grantModuleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, roleIds[i], permissionItemCode, grantModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] roleIds, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < grantModuleIds.Length; j++)
                {
                    this.GrantModule(permissionScopeManager, roleIds[i], permissionItemCode, grantModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeModule(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeModuleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeModule(PiPermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeModuleId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiModuleTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeModuleId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region  public int RevokeModule(string roleId, string permissionItemCode, string revokeModuleId) 撤销角色的模块授权
        /// <summary>
        /// 撤销角色的模块授权
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeModuleId">待回收（撤销）的模块主键</param>
        /// <returns>主键</returns>
        public int RevokeModule(string roleId, string permissionItemCode, string revokeModuleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeModule(permissionScopeManager, roleId, permissionItemCode, revokeModuleId);
        }
        #endregion

        public int RevokeModules(string roleId, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokeModuleIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, roleId, permissionItemCode, revokeModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] roleIds, string permissionItemCode, string revokeModuleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, roleIds[i], permissionItemCode, revokeModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] roleIds, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < revokeModuleIds.Length; j++)
                {
                    this.RevokeModule(permissionScopeManager, roleIds[i], permissionItemCode, revokeModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
