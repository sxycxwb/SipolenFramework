//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// ServiceFactory
    /// 本地服务的具体实现接口
    /// 
    /// 修改纪录
    /// 
    ///		2012.03.01 版本：1.0 EricHu 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.03.01</date>
    /// </author> 
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        public void InitService()
        {
        }

        /// <summary>
        /// 创建登录服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ILogOnService CreateLogOnService()
        {
            return new LogOnService();
        }

        /// <summary>
        /// 创建用户服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IUserService CreateUserService()
        {
            return new UserService();
        }

        /// <summary>
        /// 创建组织机构服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IOrganizeService CreateOrganizeService()
        {
            return new OrganizeService();
        }

        /// <summary>
        /// 创建角色服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IRoleService CreateRoleService()
        {
            return new RoleService();
        }

        /// <summary>
        /// 创建模块服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IModuleService CreateModuleService()
        {
            return new ModuleService();
        }

        /// <summary>
        /// 创建权限管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IPermissionItemService CreatePermissionItemService()
        {
            return new PermissionItemService();
        }

        /// <summary>
        /// 创建权限服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IPermissionService CreatePermissionService()
        {
            return new PermissionService();
        }

        /// <summary>
        ///平台插件服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IPlatFormAddInService CreatePlatFormAddInService()
        {
            return new PlatFormAddInService();
        }

        /// <summary>
        /// 创建序列服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ISequenceService CreateSequenceService()
        {
            return new SequenceService();
        }

        /// <summary>
        /// 创建异常服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IExceptionService CreateExceptionService()
        {
            return new ExceptionService();
        }

        /// <summary>
        /// 创建选项服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IItemsService CreateItemsService()
        {
            return new ItemsService();
        }

        /// <summary>
        /// 创建选项明细服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IItemDetailsService CreateItemDetailsService()
        {
            return new ItemDetailsService();
        }

        /// <summary>
        /// 创建日志服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ILogService CreateLogService()
        {
            return new LogService();
        }

       /// <summary>
       /// 创建员工（职员）服务
       /// </summary>
        /// <returns>服务接口</returns>
        public IStaffService CreateStaffService()
        {
            return new StaffService();
        }

        /// <summary>
        /// 创建消息通讯服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IMessageService CreateMessageService()
        {
            return new MessageService();
        }

        /// <summary>
        /// 创建文件服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IFileService CreateFileService()
        {
            return new FileService();
        }

        /// <summary>
        /// 创建目录/文件夹服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IFolderService CreateFolderService()
        {
            return new FolderService();
        }

        /// <summary>
        /// 创建参数服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IParameterService CreateParameterService()
        {
            return new ParameterService();
        }

        /// <summary>
        /// 创建业务数据库服务
        /// </summary>
        /// <returns>数据库服务</returns>
        public IDBProviderService CreateBusinessDBProviderService()
        {
            return new BusinessDBProviderService();
        }

        /// <summary>
        /// 创建RDIFramework.NET框架数据访问层服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IDBProviderService CreateRDIFrameworkDBProviderService()
        {
            return new RDIFrameworkDBProviderService();
        }

        /// <summary>
        /// 表字段结构服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ITableColumnsService CreateTableColumnsService()
        {
            return new TableColumnsService();
        }

        /// <summary>
        /// 数据库连接定义服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IDbLinkDefineService CreateDbLinkDefineService()
        {
            return new DbLinkDefineService();
        }

        /// <summary>
        /// 查询引擎服务
        /// </summary>
        /// <returns></returns>
        public IQueryEngineService CreateQueryEngineService()
        {
            return new QueryEngineService();
        }

        //
        //工作流相关
        //
        

        /// <summary>
        /// 工作流程实例服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowInstanceService CreateWorkFlowInstanceService()
        {
            return new WorkFlowInstanceService();
        }

        /// <summary>
        /// 工作流程辅助帮助服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowHelperService CreateWorkFlowHelperService()
        {
            return new WorkFlowHelperService();
        }

        /// <summary>
        /// 工作流程模版服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowTemplateService CreateWorkFlowTemplateService()
        {
            return new WorkFlowTemplateService();
        }

        /// <summary>
        /// 工作流程用户表单服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowUserControlService CreateWorkFlowUserControlService()
        {
            return new WorkFlowUserControlService();
        }
    }
}