/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 16:36:17
 ******************************************************************************/
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 用户组织机构权限域
    /// </summary>
    public partial class UserScopeManager : DbCommonManager, IDbCommonManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetOrganizeIds(string userId, string permissionItemCode) 获取指定用户的组织机构权限主键数组
        /// <summary>
        /// 获取指定用户的组织机构权限主键数组
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiOrganizeTable.TableName;
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

        #region private string GrantOrganize(PiPermissionScopeManager permissionScopeManager, string id, string userId, string grantOrganizeId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantOrganizeId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantOrganize(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantOrganizeId)
        {
            string returnValue = string.Empty;

            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiOrganizeTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = grantOrganizeId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);
            // Nick Deng 优化数据权限设置，没有权限和其他任意一种权限互斥
            // 即当没有权限时，该用户对应该数据权限的其他权限都应删除
            // 当该用户拥有对应该数据权限的其他权限时，删除该用户的没有权限的权限
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity();
            DataTable dt = new DataTable();
            if (!this.Exists(names, values))
            {
                resourcePermissionScopeEntity.PermissionId = this.GetIdByCode(permissionItemCode);
                resourcePermissionScopeEntity.ResourceCategory = PiUserTable.TableName;
                resourcePermissionScopeEntity.ResourceId = userId;
                resourcePermissionScopeEntity.TargetCategory = PiOrganizeTable.TableName;
                resourcePermissionScopeEntity.TargetId = grantOrganizeId;
                resourcePermissionScopeEntity.Enabled = 1;
                resourcePermissionScopeEntity.DeleteMark = 0;
                returnValue = permissionScopeManager.Add(resourcePermissionScopeEntity);
                if (grantOrganizeId != ((int)PermissionScope.None).ToString())
                {
                    values[3] = ((int)PermissionScope.None).ToString();
                    if (this.Exists(names, values))
                    {
                        dt = permissionScopeManager.GetDT(names, values);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            permissionScopeManager.DeleteEntity(dt.Rows[0]["Id"].ToString());
                        }
                    }
                }
                else
                {
                    string[] namesForDel = new string[4];
                    string[] valuesForDel = new string[4];
                    namesForDel[0] = names[0];
                    valuesForDel[0] = values[0];
                    namesForDel[1] = names[1];
                    valuesForDel[1] = values[1];
                    namesForDel[2] = names[2];
                    valuesForDel[2] = values[2];
                    namesForDel[3] = names[4];
                    valuesForDel[3] = values[4];
                    dt = permissionScopeManager.GetDT(namesForDel, valuesForDel);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["TargetId"].ToString() != ((int)PermissionScope.None).ToString())
                            permissionScopeManager.DeleteEntity(dt.Rows[0]["Id"].ToString());
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region public string GrantOrganize(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantOrganize(string userId, string permissionItemCode, string grantOrganizeId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.GrantOrganize(permissionScopeManager, userId, permissionItemCode, grantOrganizeId);
        }
        #endregion

        public int GrantOrganizes(string userId, string permissionItemCode, string[] grantOrganizeIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < grantOrganizeIds.Length; i++)
            {
                this.GrantOrganize(permissionScopeManager, userId, permissionItemCode, grantOrganizeIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantOrganizes(string[] userIds, string permissionItemCode, string grantOrganizeId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantOrganize(permissionScopeManager, userIds[i], permissionItemCode, grantOrganizeId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantOrganizes(string[] userIds, string permissionItemCode, string[] grantOrganizeIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantOrganizeIds.Length; j++)
                {
                    this.GrantOrganize(permissionScopeManager, userIds[i], permissionItemCode, grantOrganizeIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeOrganize(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeOrganizeId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeOrganizeId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeOrganize(PiPermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeOrganizeId)
        {
            string[] names = new string[5];
            string[] values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = PiOrganizeTable.TableName;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeOrganizeId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = this.GetIdByCode(permissionItemCode);

            return permissionScopeManager.Delete(names, values);
        }
        #endregion

        #region public int RevokeOrganize(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeOrganizeId"></param>
        /// <returns>主键</returns>
        public int RevokeOrganize(string userId, string permissionItemCode, string revokeOrganizeId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return this.RevokeOrganize(permissionScopeManager, userId, permissionItemCode, revokeOrganizeId);
        }
        #endregion

        public int RevokeOrganizes(string userId, string permissionItemCode, string[] revokeOrganizeIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < revokeOrganizeIds.Length; i++)
            {
                this.RevokeOrganize(permissionScopeManager, userId, permissionItemCode, revokeOrganizeIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeOrganizes(string[] userIds, string permissionItemCode, string revokeOrganizeId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokeOrganize(permissionScopeManager, userIds[i], permissionItemCode, revokeOrganizeId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeOrganizes(string[] userIds, string permissionItemCode, string[] revokeOrganizeIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokeOrganizeIds.Length; j++)
                {
                    this.RevokeOrganize(permissionScopeManager, userIds[i], permissionItemCode, revokeOrganizeIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
