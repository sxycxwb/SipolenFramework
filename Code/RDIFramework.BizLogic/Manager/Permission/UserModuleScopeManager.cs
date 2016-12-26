/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:33:29
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户模块权限域
    /// UserScopeManager
    /// 
    /// </summary>
    public partial class UserScopeManager : DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetModuleIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetModuleIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
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

        #region private string GrantModule(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantModuleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantModule(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity();
            string permissionId = this.GetIdByCode(permissionItemCode);
            if (string.IsNullOrEmpty(permissionId))
            {
                return string.Empty;
            }
            resourcePermissionScopeEntity.PermissionId = permissionId;
            resourcePermissionScopeEntity.ResourceCategory = PiUserTable.TableName;
            resourcePermissionScopeEntity.ResourceId = userId;
            resourcePermissionScopeEntity.TargetCategory = PiModuleTable.TableName;
            resourcePermissionScopeEntity.TargetId = grantModuleId;
            resourcePermissionScopeEntity.Enabled = 1;
            resourcePermissionScopeEntity.DeleteMark = 0;
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantModule(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantModuleId"></param>
        /// <returns>主键</returns>
        public string GrantModule(string userId, string permissionItemCode, string grantModuleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantModule(permissionScopeManager, userId, permissionItemCode, grantModuleId);
        }
        #endregion

        public int GrantModules(string userId, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantModuleIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, userId, permissionItemCode, grantModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] userIds, string permissionItemCode, string grantModuleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, userIds[i], permissionItemCode, grantModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] userIds, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantModuleIds.Length; j++)
                {
                    this.GrantModule(permissionScopeManager, userIds[i], permissionItemCode, grantModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeModule(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeModuleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeModule(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeModuleId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiModuleTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeModuleId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokeModule(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeModuleId"></param>
        /// <returns>主键</returns>
        public int RevokeModule(string userId, string permissionItemCode, string revokeModuleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeModule(permissionScopeManager, userId, permissionItemCode, revokeModuleId);
        }
        #endregion

        public int RevokeModules(string userId, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokeModuleIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, userId, permissionItemCode, revokeModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] userIds, string permissionItemCode, string revokeModuleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, userIds[i], permissionItemCode, revokeModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] userIds, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokeModuleIds.Length; j++)
                {
                    this.RevokeModule(permissionScopeManager, userIds[i], permissionItemCode, revokeModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
