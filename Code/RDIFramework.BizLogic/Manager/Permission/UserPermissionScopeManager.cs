/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:38:31
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户权限域
    /// </summary>
    public partial class UserScopeManager : DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetPermissionItemIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
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

        #region private string GrantPermissionItem(PiPermissionScopeManager permissionScopeManager, string id, string userId, string grantPermissionId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantPermissionId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantPermissionItem(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantPermissionId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiUserTable.TableName,
                ResourceId = userId,
                TargetCategory = PiPermissionItemTable.TableName,
                TargetId = grantPermissionId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantPermissionItem(string userId, string permissionItemCode, string grantPermissionId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantPermissionId">权限主键</param>
        /// <returns>主键</returns>
        public string GrantPermissionItem(string userId, string permissionItemCode, string grantPermissionId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantPermissionItem(permissionScopeManager, userId, permissionItemCode, grantPermissionId);
        }
        #endregion

        public int GrantPermissionItemes(string userId, string permissionItemCode, string[] grantPermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantPermissionIds.Length; i++)
            {
                this.GrantPermissionItem(permissionScopeManager, userId, permissionItemCode, grantPermissionIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantPermissionItemes(string[] userIds, string permissionItemCode, string grantPermissionId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantPermissionItem(permissionScopeManager, userIds[i], permissionItemCode, grantPermissionId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantPermissionItems(string[] userIds, string permissionItemCode, string[] grantPermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantPermissionIds.Length; j++)
                {
                    this.GrantPermissionItem(permissionScopeManager, userIds[i], permissionItemCode, grantPermissionIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokePermissionItem(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokePermissionId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokePermissionId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokePermissionItem(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokePermissionId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiPermissionItemTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokePermissionId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokePermissionItem(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokePermissionId"></param>
        /// <returns>主键</returns>
        public int RevokePermissionItem(string userId, string permissionItemCode, string revokePermissionId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokePermissionItem(permissionScopeManager, userId, permissionItemCode, revokePermissionId);
        }
        #endregion

        public int RevokePermissionItems(string userId, string permissionItemCode, string[] revokePermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokePermissionIds.Length; i++)
            {
                this.RevokePermissionItem(permissionScopeManager, userId, permissionItemCode, revokePermissionIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokePermissionItems(string[] userIds, string permissionItemCode, string revokePermissionId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokePermissionItem(permissionScopeManager, userIds[i], permissionItemCode, revokePermissionId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokePermissionItems(string[] userIds, string permissionItemCode, string[] revokePermissionIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokePermissionIds.Length; j++)
                {
                    this.RevokePermissionItem(permissionScopeManager, userIds[i], permissionItemCode, revokePermissionIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
