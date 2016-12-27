//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// RDIFrameworkService
    /// 
    /// 修改纪录
    ///     
    ///     2014-06-18 版本: 2.8 XuWangBin 新增工作流程服务部分。
    ///     2014-02-28 版本: 2.8 XuWangBin 新增信息通讯服务。
    ///     2013-05-11 版本：2.5 XuWangBin 新增表字段结构服务。
    ///		2010.03.05 版本：1.0 XuWangBin 创建。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.03.05</date>
    /// </author> 
    /// </summary>
    public class RDIFrameworkService : RDIFrameworkServiceFactory
    {
        private static RDIFrameworkService instance = null;
        private static object locker = new Object();
        private static readonly string ServicePath = SystemInfo.Service;
        private static readonly string ServiceFactoryClass = SystemInfo.ServiceFactory;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RDIFrameworkService()
        {
            serviceFactory = GetServiceFactory(ServicePath, ServiceFactoryClass);
        }

        private IServiceFactory serviceFactory = null;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public void InitService()
        {
            serviceFactory.InitService();       
        }

        /// <summary>
        /// 创建RDIFramework.NET框架服务
        /// </summary>
        public static RDIFrameworkService Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new RDIFrameworkService();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 登录服务
        /// </summary>
        public ILogOnService LogOnService
        {
            get
            {
                return serviceFactory.CreateLogOnService();
            }
        }

        /// <summary>
        /// 序列服务
        /// </summary>
        public ISequenceService SequenceService
        {
            get
            {
                return serviceFactory.CreateSequenceService();
            }
        }

        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserService UserService
        {
            get
            {
                return serviceFactory.CreateUserService();
            }
        }

        /// <summary>
        /// 日志服务
        /// </summary>
        public ILogService LogService
        {
            get
            {
                return serviceFactory.CreateLogService();
            }
        }

        /// <summary>
        /// 异常服务
        /// </summary>
        public IExceptionService ExceptionService
        {
            get
            {
                return serviceFactory.CreateExceptionService();
            }
        }

        /// <summary>
        /// 权限项服务
        /// </summary>
        public IPermissionItemService PermissionItemService
        {
            get
            {
                return serviceFactory.CreatePermissionItemService();
            }
        }

        /// <summary>
        /// 组织机构服务
        /// </summary>
        public IOrganizeService OrganizeService
        {
            get
            {
                return serviceFactory.CreateOrganizeService();
            }
        }

        /// <summary>
        /// 选项（数据字典）服务
        /// </summary>
        public IItemsService ItemsService
        {
            get
            {
                return serviceFactory.CreateItemsService();
            }
        }

        /// <summary>
        /// 选项明细（数据字典明细）服务
        /// </summary>
        public IItemDetailsService ItemDetailsService
        {
            get
            {
                return serviceFactory.CreateItemDetailsService();
            }
        }
        
        /// <summary>
        /// 模块（菜单）服务
        /// </summary>
        public IModuleService ModuleService
        {
            get
            {
                return serviceFactory.CreateModuleService();
            }
        }

        /// <summary>
        /// 员工（职员）服务
        /// </summary>
        public IStaffService StaffService
        {
            get
            {
                return serviceFactory.CreateStaffService();
            }
        }

        /// <summary>
        /// 消息通讯服务
        /// </summary>
        public IMessageService MessageService
        {
            get
            {
                return serviceFactory.CreateMessageService();
            }
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleService RoleService
        {
            get
            {
                return serviceFactory.CreateRoleService();
            }
        }

        /// <summary>
        /// 文件服务
        /// </summary>
        public IFileService FileService
        {
            get
            {
                return serviceFactory.CreateFileService();
            }
        }

        /// <summary>
        /// 文件夹服务
        /// </summary>
        public IFolderService FolderService
        {
            get
            {
                return serviceFactory.CreateFolderService();
            }
        }

        /// <summary>
        /// 参数服务
        /// </summary>
        public IParameterService ParameterService
        {
            get
            {
                return serviceFactory.CreateParameterService();
            }
        }

        /// <summary>
        /// 权限服务
        /// </summary>
        public IPermissionService PermissionService
        {
            get
            {
                return serviceFactory.CreatePermissionService();
            }
        }

        /// <summary>
        /// RDIFramework.NET ━ .NET快速信息化系统开发框架数据访问层服务
        /// </summary>
        public IDBProviderService RDIFrameworkDBProviderService
        {
            get
            {
                return serviceFactory.CreateRDIFrameworkDBProviderService();
            }
        }

        /// <summary>
        /// 表字段结构服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ITableColumnsService TableColumnsService
        {
            get
            {
                return serviceFactory.CreateTableColumnsService();
            }
        }

        /// <summary>
        /// 数据库连接定义服务
        /// </summary>
        public IDbLinkDefineService DbLinkDefineService
        {
            get
            {
                return serviceFactory.CreateDbLinkDefineService();
            }
        }

        /// <summary>
        /// 查询引擎服务
        /// </summary>
        public IQueryEngineService QueryEngineService
        {
            get
            {
                return serviceFactory.CreateQueryEngineService();
            }
        }

        /// <summary>
        /// 平台插件服务
        /// </summary>
        public IPlatFormAddInService PlatFormAddInService
        {
            get
            {
                return serviceFactory.CreatePlatFormAddInService();
            }
        }

        /// <summary>
        /// 工作流程实例服务
        /// </summary>
        public IWorkFlowInstanceService WorkFlowInstanceService 
        {
            get
            {
                return serviceFactory.CreateWorkFlowInstanceService();
            }
        }

        /// <summary>
        /// 工作流程辅助帮助服务
        /// </summary>
        public IWorkFlowHelperService WorkFlowHelperService
        {
            get
            {
                return serviceFactory.CreateWorkFlowHelperService();
            }
        }

        /// <summary>
        /// 工作流程模版服务
        /// </summary>
        public IWorkFlowTemplateService WorkFlowTemplateService
        {
            get
            {
                return serviceFactory.CreateWorkFlowTemplateService();
            }
        }

        /// <summary>
        /// 工作流程用户表单服务
        /// </summary>
        public IWorkFlowUserControlService WorkFlowUserControlService
        {
            get
            {
                return serviceFactory.CreateWorkFlowUserControlService();
            }
        }
    }
}