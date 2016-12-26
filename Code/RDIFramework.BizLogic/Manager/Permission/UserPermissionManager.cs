/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:37:48
 ******************************************************************************/
using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户权限
    /// </summary>
    public partial class UserPermissionManager : DbCommonManager, IDbCommonManager
    {
        public UserPermissionManager()
        {
            base.CurrentTableName = PiPermissionTable.TableName;
        }

        public UserPermissionManager(IDbProvider dbProvider) : this()
        {
            DBProvider = dbProvider;
        }

        public UserPermissionManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        public UserPermissionManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 判断用户是否有有相应的权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>有权限</returns>
        public bool CheckPermission(string userId, string permissionItemCode)
        {
            PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(DBProvider);
            string permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);
            // 没有找到相应的权限
            if (String.IsNullOrEmpty(permissionItemId))
            {
                return false;
            }
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionTable.FieldEnabled;
            values[2] = "1";
            return DbCommonLibary.Exists(DBProvider, this.CurrentTableName, names, values);
        }

        #region public string[] GetPermissionItemIds(string userId) 获取用户的权限主键数组
        /// <summary>
        /// 获取用户的权限主键数组
        /// </summary>
        /// <param name="userId">用户代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string userId)
        {
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionTable.FieldDeleteMark;
            values[1] = "0";
            names[2] = PiPermissionTable.FieldEnabled;
            values[2] = "1";
            names[3] = PiPermissionTable.FieldResourceId;
            values[3] = userId;
            return this.GetIds(names, values, PiPermissionTable.FieldPermissionId);
        }
        #endregion

        #region public string[] GetUserIds(string permissionItemId) 获取用户主键数组
        /// <summary>
        /// 获取用户主键数组
        /// </summary>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string permissionItemId)
        {
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionTable.FieldDeleteMark;
            values[1] = "0";
            names[2] = PiPermissionTable.FieldEnabled;
            values[2] = "1";
            names[3] = PiPermissionTable.FieldPermissionId;
            values[3] = permissionItemId;
            return this.GetIds(names, values, PiPermissionTable.FieldResourceId);
        }
        #endregion

        //
        // 授予权限的实现部分
        //

        #region private string Grant(PiPermissionManager permissionManager, string id, string userId, string permissionItemId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="id">主键</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        private string Grant(PiPermissionManager permissionManager, string id, string userId, string permissionItemId)
        {
            string returnValue = string.Empty;
            PiPermissionEntity resourcePermissionEntity = new PiPermissionEntity
            {
                ResourceCategory = PiUserTable.TableName,
                ResourceId = userId,
                PermissionId = permissionItemId,
                Enabled = 1
            };
            //存在相同的就不要再次重复授予了，以免产生垃圾数据
            if (!this.Exists(new string[] { PiPermissionTable.FieldResourceCategory, PiPermissionTable.FieldResourceId, PiPermissionTable.FieldPermissionId, PiPermissionTable.FieldDeleteMark },
                             new object[] { PiUserTable.TableName,userId, permissionItemId, 0 }))
            {
                returnValue = permissionManager.Add(resourcePermissionEntity);
            }
            return returnValue;
        }
        #endregion

        #region public string Grant(string userId, string permissionItemId) 用户授予权限
        /// <summary>
        /// 用户授予权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        public string Grant(string userId, string permissionItemId)
        {
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            return this.Grant(permissionManager, string.Empty, userId, permissionItemId);
        }
        #endregion

        public int Grant(string userId, string[] permissionItemIds)
        {
            int returnValue = 0;
            CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider);
            string[] sequenceIds = sequenceManager.GetBatchSequence(PiPermissionTable.TableName, permissionItemIds.Length);
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Grant(permissionManager, sequenceIds[i], userId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] userIds, string permissionItemId)
        {
            int returnValue = 0;
            CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider);
            string[] sequenceIds = sequenceManager.GetBatchSequence(PiPermissionTable.TableName, userIds.Length);
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.Grant(permissionManager, sequenceIds[i], userIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] userIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider);
            string[] sequenceIds = sequenceManager.GetBatchSequence(PiPermissionTable.TableName, userIds.Length * permissionItemIds.Length);
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    this.Grant(permissionManager, sequenceIds[i * permissionItemIds.Length + j], userIds[i], permissionItemIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销权限的实现部分
        //

        #region private int Revoke(PiPermissionManager permissionManager, string userId, string permissionItemId) 为了提高撤销的运行速度
        /// <summary>
        /// 为了提高撤销的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        private int Revoke(PiPermissionManager permissionManager, string userId, string permissionItemId)
        {
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionTable.FieldPermissionId;
            values[2] = permissionItemId;
            return permissionManager.Delete(names, values);
        }
        #endregion

        #region public int Revoke(string userId, string permissionItemId) 撤销员工权限
        /// <summary>
        /// 撤销员工权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        public int Revoke(string userId, string permissionItemId)
        {
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            return this.Revoke(permissionManager, userId, permissionItemId);
        }
        #endregion

        public int Revoke(string userId, string[] permissionItemIds)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, userId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Revoke(string[] userIds, string permissionItemId)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, userIds[i], permissionItemId);
            }
            return returnValue;
        }

        /// <summary>
        /// 撤销用户权限
        /// </summary>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="permissionItemIds">权限主键数据</param>
        /// <returns>撤销的数量</returns>
        public int Revoke(string[] userIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    returnValue += this.Revoke(permissionManager, userIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 清除指定用户的所有权限
        /// 
        /// 1.清除用户的角色归属。
        /// 2.清除用户的模块权限。
        /// 3.清除用户的操作权限。
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>大于0回收成功</returns>
        public int ClearUserPermissionByUserId(string userId)
        {
            int returnValue = 0;
            PiUserRoleManager userRoleManager = new PiUserRoleManager(DBProvider, UserInfo);
            returnValue += userRoleManager.EliminateRoleUser(userId);

            var userPermissionManager = new UserPermissionManager(DBProvider, UserInfo);
            returnValue += userPermissionManager.RevokeAll(userId);

            var userPermissionScopeManager = new UserScopeManager(DBProvider, UserInfo);
            returnValue += userPermissionScopeManager.RevokeAll(userId);
            return returnValue;
        }

        #region public int RevokeAll(string userId) 撤销用户全部权限
        /// <summary>
        /// 撤销用户全部权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int RevokeAll(string userId)
        {
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            string[] names = new string[2];
            string[] values = new string[2];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = userId;
            return permissionManager.Delete(names, values);
        }
        #endregion
    }
}
