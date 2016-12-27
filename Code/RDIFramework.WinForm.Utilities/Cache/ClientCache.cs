//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// ClientCache
    /// 客户端缓存功能
    /// 
    /// 修改纪录
    ///
    ///		2010.02.03 版本：1.0 XuWangBin 窗体与数据库连接的分离。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.02.03</date>
    /// </author> 
    /// </summary>
    public class ClientCache
    {
        private static ClientCache instance = null;
        private static object locker = new Object();

        public static ClientCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ClientCache();
                        }
                    }
                }
                return instance;
            }
        }

        // 当前系统中的完整的模块菜单
        private DataTable dtMoule = new DataTable(PiModuleTable.TableName);
        
        /// <summary>
        /// 当前系统中的完整的模块菜单
        /// </summary>
        public DataTable DTMoule
        {
            get
            {
                return this.dtMoule;
            }

            set
            {
                this.dtMoule = value;
            }
        }

        // 当前用户可以访问的模块
        private DataTable dtUserMoule = new DataTable(PiModuleTable.TableName);

        /// <summary>
        /// 当前用户可以访问的模块菜单
        /// </summary>
        public DataTable DTUserMoule
        {
            get
            {
                return this.dtUserMoule;
            }
            set
            {
                this.dtUserMoule = value;
            }
        }

        // 部门数据缓存
        private DataTable dtOrganize;
        
        /// <summary>
        /// 部门缓存数据
        /// </summary>
        public DataTable DTOrganize
        {
            get
            {
                return this.dtOrganize;
            }
            set
            {
                this.dtOrganize = value;
            }
        }

        /// <summary>
        /// 获得部门缓存数据
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>部门数据表</returns>
        public DataTable GetOrganizeDT(UserInfo userInfo)
        {
            if ((this.dtOrganize == null) || (!SystemInfo.ClientCache))
            {
                var service = new RDIFrameworkService();
                this.dtOrganize = service.OrganizeService.GetDT(userInfo);
                if (service.OrganizeService is ICommunicationObject)
                {
                    ((ICommunicationObject)service.OrganizeService).Close();
                }
            }
            this.dtOrganize.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            return this.dtOrganize;
        }

        // 权限数据缓存
        private DataTable dtPermission;

        /// <summary>
        /// 权限缓存数据
        /// </summary>
        public DataTable DTPermission
        {
            get
            {
                return this.dtPermission;
            }
            set
            {
                this.dtPermission = value;
            }
        }

        /// <summary>
        /// 获得权限缓存数据
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>数据表</returns>
        public DataTable GetPermission(UserInfo userInfo)
        {
            if (this.dtPermission == null || (!SystemInfo.ClientCache))
            {
                var service = new RDIFrameworkService();
                this.dtPermission = service.PermissionService.GetPermissionDT(userInfo);
                if (service.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)service.PermissionService).Close();
                }
            }
            return this.dtPermission;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        public void GetUserPermission(UserInfo userInfo)
        {
            //获取模块列表
            var service = new RDIFrameworkService();
            ClientCache.Instance.DTMoule = service.ModuleService.GetDT(userInfo);
            if (service.ModuleService is ICommunicationObject)
            {
                ((ICommunicationObject)service.ModuleService).Close();
            }
            // 获取用户模块访问权限范围
            ClientCache.Instance.DTUserMoule = service.PermissionService.GetModuleDTByUserId(userInfo, userInfo.Id);
            if (service.PermissionService is ICommunicationObject)
            {
                ((ICommunicationObject)service.PermissionService).Close();
            }
            // 获取用户的操作权限
            ClientCache.Instance.DTPermission = null;
            ClientCache.Instance.GetPermission(userInfo);
        }
    }
}