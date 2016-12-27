/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 15:38:10
 ******************************************************************************/

using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PermissionModuleManager
    /// 模块权限关系管理
    /// </summary>
    public class PermissionModuleManager : DbCommonManager
    {
        public PermissionModuleManager()
        {
            base.CurrentTableName = PiPermissionTable.TableName;
        }

        public PermissionModuleManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        public PermissionModuleManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        public string[] GetModuleIds(string permissionItemId)
        {
            string[] returnValue = null;
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiPermissionTable.TableName;
            names[1] = PiPermissionTable.FieldPermissionId;
            values[1] = permissionItemId;
            names[2] = PiPermissionTable.FieldDeleteMark;
            values[2] = "0";
            DataTable dataTable = this.GetDT(names, values);
            returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionTable.FieldResourceId);
            return returnValue;
        }

        public string[] GetPermissionIds(string moduleId)
        {
            string[] returnValue = null;
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiModuleTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = moduleId;
            names[2] = PiPermissionTable.FieldDeleteMark;
            values[2] = "0";
            DataTable dataTable = this.GetDT(names, values);
            returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionTable.FieldPermissionId);
            return returnValue;
        }

        public int Add(string moduleId, string permissionItemId)
        {
            int returnValue = 0;
            string[] names = new string[4];
            string[] values = new string[4];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = PiModuleTable.TableName;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = moduleId;
            names[2] = PiPermissionTable.FieldPermissionId;
            values[2] = permissionItemId;
            names[3] = PiPermissionTable.FieldDeleteMark;
            values[3] = "0";
            // 检查记录是否重复
            if (!this.Exists(names, values))
            {
                PiPermissionEntity permissionEntity = new PiPermissionEntity
                {
                    ResourceId = moduleId,
                    ResourceCategory = PiModuleTable.TableName,
                    Enabled = 1,
                    DeleteMark = 0,
                    PermissionId = permissionItemId
                };
                PiPermissionManager permissionManager = new PiPermissionManager(this.DBProvider, this.UserInfo);
                permissionManager.AddEntity(permissionEntity);
                returnValue++;
            }
            return returnValue;           
        }

        public int Add(string[] moduleIds, string permissionItemId)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                this.Add(moduleIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Add(string moduleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Add(moduleId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Add(string[] moduleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                for (int j = 0; i < permissionItemIds.Length; i++)
                {
                    this.Add(moduleIds[i], permissionItemIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }

        public int Delete(string moduleId, string permissionItemId)
        {
            int returnValue = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiPermissionTable.FieldResourceCategory, PiModuleTable.TableName),
                new KeyValuePair<string, object>(PiPermissionTable.FieldResourceId, moduleId),
                new KeyValuePair<string, object>(PiPermissionTable.FieldPermissionId, permissionItemId)
            };
            PiPermissionManager manager = new PiPermissionManager(this.DBProvider, this.UserInfo);
            returnValue = manager.Delete(parameters);
            return returnValue;
        }

        public int Delete(string[] moduleIds, string permissionItemId)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                returnValue += this.Delete(moduleIds[i], permissionItemId);
            }
            return returnValue;
        }

        public int Delete(string moduleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Delete(moduleId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Delete(string[] moduleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                for (int j = 0; i < permissionItemIds.Length; i++)
                {
                    returnValue += this.Delete(moduleIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }
    }
}
