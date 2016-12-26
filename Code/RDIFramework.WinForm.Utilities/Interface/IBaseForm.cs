/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-24 9:08:22
 ******************************************************************************/

using System;
using System.Data;

namespace RDIFramework.WinForm.Utilities
{
    public interface IBaseForm
    {
        void FormOnLoad();
        void GetIcon();
        void GetList();
        void GetPermission();
        DataTable GetModuleScope(string permissionItemScopeCode);
        DataTable GetOrganizeScope(string permissionItemScopeCode, bool isInnerOrganize);        
        DataTable GetPermissionItemScop(string permissionItemScopeCode);
        DataTable GetRoleScope(string permissionItemScopeCode);
        DataTable GetUserScope(string permissionItemScopeCode);
        bool IsAuthorized(string permissionItemCode, string permissionItemName = null);
        bool IsModuleAuthorized(string moduleCode);
        void LoadUserParameter(System.Windows.Forms.Form form);
        void Localization(System.Windows.Forms.Form form);
        bool ModuleIsVisible(string moduleCode);
        void ProcessException(Exception ex);
        void WriteException(Exception ex);
    }
}
