//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// IServiceFactory
    /// 服务工厂接口定义
    /// 
    /// 修改纪录
    /// 
    ///	    2013.05.07 版本：2.5 EricHu 整理目录结构。
    ///	    2011.04.30 版本：2.0 EricHu 修改注释。
    ///	    2010.01.30 版本：1.0 EricHu 创建。
    ///	    
    /// 版本：2.7
    /// <author>
    ///     <name>EricHu</name>
    ///     <date>2010.01.30</date>
    /// </author> 
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// 初始化服务
        /// </summary>
        void InitService();

        /// <summary>
        /// 创建登录服务
        /// </summary>
        /// <returns>服务接口</returns>
        ILogOnService CreateLogOnService();

        /// <summary>
        /// 创建用户服务
        /// </summary>
        /// <returns>服务接口</returns>
        IUserService CreateUserService();

        /// <summary>
        /// 创建员工服务
        /// </summary>
        /// <returns>服务接口</returns>
        IStaffService CreateStaffService();

        /// <summary>
        /// 创建日志服务
        /// </summary>
        /// <returns>服务接口</returns>
        ILogService CreateLogService();

        /// <summary>
        /// 创建异常服务
        /// </summary>
        /// <returns>服务接口</returns>
        IExceptionService CreateExceptionService();

        /// <summary>
        /// 创建权限管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        IPermissionItemService CreatePermissionItemService();

        /// <summary>
        /// 创建组织机构服务
        /// </summary>
        /// <returns>服务接口</returns>
        IOrganizeService CreateOrganizeService();

        /// <summary>
        /// 创建选项服务
        /// </summary>
        /// <returns>服务接口</returns>
        IItemsService CreateItemsService();

        /// <summary>
        /// 创建选项明细服务
        /// </summary>
        /// <returns>服务接口</returns>
        IItemDetailsService CreateItemDetailsService();

        /// <summary>
        /// 创建模块服务
        /// </summary>
        /// <returns>服务接口</returns>
        IModuleService CreateModuleService();

        /// <summary>
        /// 创建角色服务
        /// </summary>
        /// <returns>服务接口</returns>
        IRoleService CreateRoleService();

        /// <summary>
        /// 创建文件服务
        /// </summary>
        /// <returns>服务接口</returns>
        IFileService CreateFileService();

        /// <summary>
        /// 创建目录/文件夹服务
        /// </summary>
        /// <returns>服务接口</returns>
        IFolderService CreateFolderService();

        /// <summary>
        /// 创建参数服务
        /// </summary>
        /// <returns>服务接口</returns>
        IParameterService CreateParameterService();

        /// <summary>
        /// 创建权限服务
        /// </summary>
        /// <returns>服务接口</returns>
        IPermissionService CreatePermissionService();

        /// <summary>
        /// 创建RDIFramework.NET ━ .NET快速信息化系统开发框架数据访问层服务
        /// </summary>
        /// <returns>服务接口</returns>
        IDBProviderService CreateRDIFrameworkDBProviderService();

        /// <summary>
        /// 创建序列服务
        /// </summary>
        /// <returns>服务接口</returns>
        ISequenceService CreateSequenceService();

        /// <summary>
        /// 表字段结构
        /// </summary>
        /// <returns>服务接口</returns>
        ITableColumnsService CreateTableColumnsService();

        /// <summary>
        /// 数据库连接定义服务
        /// </summary>
        /// <returns>服务接口</returns>
        IDbLinkDefineService CreateDbLinkDefineService();

        /// <summary>
        /// 框架插件服务
        /// </summary>
        /// <returns>服务接口</returns>
        IPlatFormAddInService CreatePlatFormAddInService();

        /// <summary>
        /// 框架消息通讯服务
        /// </summary>
        /// <returns>服务接口</returns>
        IMessageService CreateMessageService();

        /// <summary>
        /// 查询引擎服务
        /// </summary>
        /// <returns>服务接口</returns>
        IQueryEngineService CreateQueryEngineService();


         //2014工作流
        /// <summary>
        /// 工作流程实例服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowInstanceService CreateWorkFlowInstanceService();

        /// <summary>
        /// 工作流程辅助帮助服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowHelperService CreateWorkFlowHelperService();

        /// <summary>
        /// 工作流程模版服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowTemplateService CreateWorkFlowTemplateService();

        /// <summary>
        /// 工作流程用户表单服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowUserControlService CreateWorkFlowUserControlService();
    }
}