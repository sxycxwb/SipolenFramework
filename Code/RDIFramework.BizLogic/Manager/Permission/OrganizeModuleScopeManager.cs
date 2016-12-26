using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// OrganizeScopeManage
    /// 组织机构权限域
    /// 
    /// 
    /// </summary>
    public partial class OrganizeScopeManage : DbCommonManager, IDbCommonManager
    { 
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetModuleIds(string organizeId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="organizeId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetModuleIds(string organizeId, string permissionItemCode)
        {
            string[] returnValue = null;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceCategory, PiOrganizeTable.TableName),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceId, organizeId),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldTargetCategory, PiModuleTable.TableName),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldPermissionId,this.GetIdByCode(permissionItemCode))
            };

            DataTable dataTable = this.GetDT(parameters);
            returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionScopeTable.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantModule(PiPermissionScopeManager permissionScopeManager, string organizeId, string permissionItemCode, string grantModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="organizeId">员工主键</param>
        /// <param name="permissionItemCode">SQL语句生成器</param>
        /// <param name="grantModuleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantModule(PiPermissionScopeManager permissionScopeManager, string organizeId, string permissionItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity resourcePermissionScopeEntity = new PiPermissionScopeEntity
            {
                PermissionId = this.GetIdByCode(permissionItemCode),
                ResourceCategory = PiOrganizeTable.TableName,
                ResourceId = organizeId,
                TargetCategory = PiModuleTable.TableName,
                TargetId = grantModuleId,
                Enabled = 1,
                DeleteMark = 0
            };
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantModule(string organizeId, string permissionItemId) 组织机构-模块授予权限
        /// <summary>
        /// 组织机构-模块授予权限
        /// </summary>
        /// <param name="organizeId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="grantModuleId">授予的模块主键</param>
        /// <returns>主键</returns>
        public string GrantModule(string organizeId, string permissionItemCode, string grantModuleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            return this.GrantModule(permissionScopeManager, organizeId, permissionItemCode, grantModuleId);
        }
        #endregion

        public int GrantModules(string organizeId, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            for (int i = 0; i < grantModuleIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, organizeId, permissionItemCode, grantModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] organizeIds, string permissionItemCode, string grantModuleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, organizeIds[i], permissionItemCode, grantModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] organizeIds, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                for (int j = 0; j < grantModuleIds.Length; j++)
                {
                    this.GrantModule(permissionScopeManager, organizeIds[i], permissionItemCode, grantModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeModule(PiPermissionScopeManager permissionScopeManager, string organizeId, string permissionItemCode, string revokeModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeModuleId">回收的模块主键</param>
        /// <returns>主键</returns>
        private int RevokeModule(PiPermissionScopeManager permissionScopeManager, string organizeId, string permissionItemCode, string revokeModuleId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceCategory, PiOrganizeTable.TableName),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceId, organizeId),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldTargetCategory, PiModuleTable.TableName),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldTargetId, revokeModuleId),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldPermissionId,
                    this.GetIdByCode(permissionItemCode))
            };
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokeModule(string organizeId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="organizeId">员工主键</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <param name="revokeModuleId"></param>
        /// <returns>主键</returns>
        public int RevokeModule(string organizeId, string permissionItemCode, string revokeModuleId)
        {
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            return this.RevokeModule(permissionScopeManager, organizeId, permissionItemCode, revokeModuleId);
        }
        #endregion

        public int RevokeModules(string organizeId, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            for (int i = 0; i < revokeModuleIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, organizeId, permissionItemCode, revokeModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] organizeIds, string permissionItemCode, string revokeModuleId)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, organizeIds[i], permissionItemCode, revokeModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] organizeIds, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                for (int j = 0; j < revokeModuleIds.Length; j++)
                {
                    this.RevokeModule(permissionScopeManager, organizeIds[i], permissionItemCode, revokeModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}
