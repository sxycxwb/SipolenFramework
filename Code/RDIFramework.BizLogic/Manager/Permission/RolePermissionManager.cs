/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 16:19:25
 ******************************************************************************/

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 角色权限
    /// RolePermissionManager
    /// 
    /// </summary>
    public partial class RolePermissionManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RolePermissionManager()
        {
            base.CurrentTableName = PiPermissionTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public RolePermissionManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public RolePermissionManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public RolePermissionManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public RolePermissionManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public RolePermissionManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        #region public string[] GetPermissionItemIds(string roleId) 获取角色的权限主键数组
        /// <summary>
        /// 获取角色的权限主键数组
        /// </summary>
        /// <param name="roleId">角色代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string roleId)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionTable.FieldDeleteMark;
            values[1] = "0";
            names[2] = PiPermissionTable.FieldEnabled;
            values[2] = "1";
            names[3] = PiPermissionTable.FieldResourceId;
            values[3] = roleId;
            returnValue = this.GetIds(names, values, PiPermissionTable.FieldPermissionId);
            return returnValue;
        }
        #endregion

        #region public string[] GetRoleIds(string permissionItemId) 获取角色主键数组
        /// <summary>
        /// 获取角色主键数组
        /// </summary>
        /// <param name="permissionItemId">操作权限</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string permissionItemId)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionTable.FieldDeleteMark;
            values[1] = "0";
            names[2] = PiPermissionTable.FieldEnabled;
            values[2] = "1";
            names[3] = PiPermissionTable.FieldPermissionId;
            values[3] = permissionItemId;
            returnValue = this.GetIds(names, values, PiPermissionTable.FieldResourceId);
            return returnValue;
        }
        #endregion
        
        //
        // 授予权限的实现部分
        //

        #region private string Grant(PiPermissionManager permissionManager, string roleId, string permissionItemId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        private string Grant(PiPermissionManager permissionManager, string roleId, string permissionItemId)
        {
            string returnValue = string.Empty;
            PiPermissionEntity resourcePermission = new PiPermissionEntity
            {
                ResourceCategory = PiRoleTable.TableName,
                ResourceId = roleId,
                PermissionId = permissionItemId,
                Enabled = 1
            };
            // 防止不允许为NULL的错误发生
            //存在相同的就不要再次重复授予了，以免产生垃圾数据
            if (!this.Exists(new string[] { PiPermissionTable.FieldResourceCategory, PiPermissionTable.FieldResourceId, PiPermissionTable.FieldPermissionId, PiPermissionTable.FieldDeleteMark },
                             new object[] { PiRoleTable.TableName, roleId, permissionItemId, 0 }))
            {
                returnValue = permissionManager.Add(resourcePermission);
            }
            return returnValue;
        }
        #endregion

        #region public string Grant(string roleId, string permissionItemId) 角色授予权限
        /// <summary>
        /// 角色授予权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        public string Grant(string roleId, string permissionItemId)
        {
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            return this.Grant(permissionManager, roleId, permissionItemId);
        }
        #endregion

        public int Grant(string roleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Grant(permissionManager, roleId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] roleIds, string permissionItemId)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.Grant(permissionManager, roleIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] roleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                foreach (string pItemId in permissionItemIds)
                {
                    this.Grant(permissionManager, roleIds[i], pItemId);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销权限的实现部分
        //

        #region private int Revoke(PiPermissionManager permissionManager, string roleId, string permissionItemId) 为了提高撤销的运行速度
        /// <summary>
        /// 为了提高撤销的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        private int Revoke(PiPermissionManager permissionManager, string roleId, string permissionItemId)
        {
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionTable.FieldPermissionId;
            values[2] = permissionItemId;
            return permissionManager.Delete(names, values);
        }
        #endregion

        #region public int Revoke(string roleId, string permissionItemId) 撤销角色权限
        /// <summary>
        /// 撤销角色权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        public int Revoke(string roleId, string permissionItemId)
        {
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            return this.Revoke(permissionManager, roleId, permissionItemId);
        }
        #endregion

        public int Revoke(string roleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, roleId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Revoke(string[] roleIds, string permissionItemId)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, roleIds[i], permissionItemId);
            }
            return returnValue;
        }

        public int Revoke(string[] roleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    returnValue += this.Revoke(permissionManager, roleIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }

        #region public int RevokeAll(string roleId) 撤销角色全部权限
        /// <summary>
        /// 撤销角色全部权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int RevokeAll(string roleId)
        {
            PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
            string[] names = new string[2];
            string[] values = new string[2];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = roleId;
            return permissionManager.Delete(names, values);
        }
        #endregion
    }
}
