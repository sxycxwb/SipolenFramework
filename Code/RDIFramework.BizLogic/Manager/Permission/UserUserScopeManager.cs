/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 16:41:30
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户对用户的权限域
    /// </summary>
    public partial class UserScopeManager : DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetUserIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var names = new string[4];
            var values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiUserTable.TableName;
            names[3] = PiPermissionScopeTable.FieldPermissionId;
            values[3] = this.GetIdByCode(permissionItemCode);

            var dataTable = this.GetDT(names, values);
            returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionScopeTable.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantUser(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantUserId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限项代码</param>
        /// <param name="grantUserId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantUser(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantUserId)
        {
            var returnValue = string.Empty;

            var names = new string[5];
            var values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiUserTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = grantUserId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            if (!this.Exists(names, values))
            {
                var resourcePermissionScopeEntity = new PiPermissionScopeEntity
                {
                    PermissionId = this.GetIdByCode(permissionItemCode),
                    ResourceCategory = PiUserTable.TableName,
                    ResourceId = userId,
                    TargetCategory = PiUserTable.TableName,
                    TargetId = grantUserId,
                    Enabled = 1,
                    DeleteMark = 0
                };
                return permissionScopeManager.Add(resourcePermissionScopeEntity);
            }

            return returnValue;
        }
        #endregion

        #region public string GrantUser(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="grantUserId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantUser(string userId, string permissionItemCode, string grantUserId)
        {
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantUser(permissionScopeManager, userId, permissionItemCode, grantUserId);
        }
        #endregion

        public int GrantUsers(string userId, string permissionItemCode, string[] grantUserIds)
        {
            var returnValue = 0;
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (var i = 0; i < grantUserIds.Length; i++)
            {
                this.GrantUser(permissionScopeManager, userId, permissionItemCode, grantUserIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantUsers(string[] userIds, string permissionItemCode, string grantUserId)
        {
            var returnValue = 0;
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (var i = 0; i < userIds.Length; i++)
            {
                this.GrantUser(permissionScopeManager, userIds[i], permissionItemCode, grantUserId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantUsers(string[] userIds, string permissionItemCode, string[] grantUserIds)
        {
            var returnValue = 0;
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (var i = 0; i < userIds.Length; i++)
            {
                for (var j = 0; j < grantUserIds.Length; j++)
                {
                    this.GrantUser(permissionScopeManager, userIds[i], permissionItemCode, grantUserIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分(为了提高授权的运行速度)
        //

        #region private int RevokeUser(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeUserId) 为了提高授权的运行速度
        /// <summary>
        /// 用户撤销授权
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeUser(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeUserId)
        {
            var names = new string[5];
            var values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiUserTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeUserId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);
            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokeUser(string userId, string permissionItemCode, string revokeUserId) 员工撤销授权
        /// <summary>
        /// 用户撤销授权
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserId"></param>
        /// <returns>主键</returns>
        public int RevokeUser(string userId, string permissionItemCode, string revokeUserId)
        {
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeUser(permissionScopeManager, userId, permissionItemCode, revokeUserId);
        }
        #endregion

        /// <summary>
        /// 用户撤销授权
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserIds">用户主键数组</param>
        /// <returns></returns>
        public int RevokeUsers(string userId, string permissionItemCode, string[] revokeUserIds)
        {
            var returnValue = 0;
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (var i = 0; i < revokeUserIds.Length; i++)
            {
                this.RevokeUser(permissionScopeManager, userId, permissionItemCode, revokeUserIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        /// <summary>
        /// 用户撤销授权
        /// </summary>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserId">撤销用户主键</param>
        /// <returns>受影响的数量</returns>
        public int RevokeUsers(string[] userIds, string permissionItemCode, string revokeUserId)
        {
            var returnValue = 0;
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (var i = 0; i < userIds.Length; i++)
            {
                this.RevokeUser(permissionScopeManager, userIds[i], permissionItemCode, revokeUserId);
                returnValue++;
            }
            return returnValue;
        }


        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeUserIds">撤销用户主键数组</param>
        /// <returns>受影响的数量</returns>
        public int RevokeUsers(string[] userIds, string permissionItemCode, string[] revokeUserIds)
        {
            var returnValue = 0;
            var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (var i = 0; i < userIds.Length; i++)
            {
                for (var j = 0; j < revokeUserIds.Length; j++)
                {
                    this.RevokeUser(permissionScopeManager, userIds[i], permissionItemCode, revokeUserIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
