/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-2 11:38:00
 ******************************************************************************/

using System.Globalization;
using System.ServiceModel;

namespace RDIFramework.ServiceClient
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;

    /// <summary>
    /// ServiceFactory
    /// 本地服务实现接口
    ///     
    ///     修改记录 2014-08-01 V2.8 XuWangBin 新增工作流程相关服务。
    ///     修改记录 2014-04-28 V2.8 XuWangBin 重构本地服务实现方法，让代码更加精简。
    ///     修改记录 2012-05-02 V1.0 XuWangBin 创建文件。
    /// </summary>
    public class ServiceFactory:IServiceFactory
    {
        /// <summary>
        /// 主机地址
        /// Host = "192.168.0.13";
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 初始化服务
        /// </summary>
        public void InitService()
        {
        }

        /// <summary>
        /// 动态设定WCF主机地址端口的方法
        /// </summary>
        /// <param name="address">主机地址</param>
        /// <returns>主机地址</returns>
        public EndpointAddress GetHotsUrl(EndpointAddress address)
        {
            // 若当前配置都是空的，就不用生成新的URL了。
            if (string.IsNullOrEmpty(Host) && (Port == 0))
            {
                return address;
            }
            // 判断当前配置的情况
            var endpointAddress = string.Empty;
            if (string.IsNullOrEmpty(Host))
            {
                Host = address.Uri.Host;
            }
            if (Port == 0)
            {
                Port = address.Uri.Port;
            }
            endpointAddress = address.Uri.Scheme + "://" + Host + ":" + Port.ToString(CultureInfo.InvariantCulture) + address.Uri.LocalPath;
            address = new EndpointAddress(endpointAddress);
            return address;
        }

        private TService CreateService<TService>(string serviceName)
        {
            var channelFactory = new ChannelFactory<TService>(serviceName);
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            if (channelFactory.Credentials != null)
            {
                channelFactory.Credentials.UserName.UserName = SystemInfo.ServiceUserName;
                channelFactory.Credentials.UserName.Password = SystemInfo.ServicePassword;
            }
            var proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public TService CreateBizService<TService>(string serviceName)
        {
            return CreateService<TService>("RDIFramework.BizLogic." + serviceName);
        }

        /// <summary>
        /// 创建登录服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ILogOnService CreateLogOnService()
        {
            return CreateBizService<ILogOnService>("LogOnService");
        }

        /// <summary>
        /// 创建用户服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IUserService CreateUserService()
        {
            return CreateBizService<IUserService>("UserService");
        }

        /// <summary>
        /// 创建员工（职员）服务
        /// </summary>
        /// <returns></returns>
        public IStaffService CreateStaffService()
        {
            return CreateBizService<IStaffService>("StaffService");
        }

        /// <summary>
        /// 创建组织机构服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IOrganizeService CreateOrganizeService()
        {
            return CreateBizService<IOrganizeService>("OrganizeService");
        }

        /// <summary>
        /// 创建角色服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IRoleService CreateRoleService()
        {
            return CreateBizService<IRoleService>("RoleService");
        }

        /// <summary>
        /// 创建模块服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IModuleService CreateModuleService()
        {
            return CreateBizService<IModuleService>("ModuleService");
        }

        /// <summary>
        /// 创建权限管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IPermissionItemService CreatePermissionItemService()
        {
            return CreateBizService<IPermissionItemService>("PermissionItemService");
        }

        /// <summary>
        /// 创建权限服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IPermissionService CreatePermissionService()
        {
            return CreateBizService<IPermissionService>("PermissionService");
        }

        /// <summary>
        /// 平台插件服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IPlatFormAddInService CreatePlatFormAddInService()
        {
            return CreateBizService<IPlatFormAddInService>("PlatFormAddInService");
        }

        /// <summary>
        /// 框架消息通讯服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IMessageService CreateMessageService()
        {
            return CreateBizService<IMessageService>("MessageService");
        }

        /// <summary>
        /// 系统异常服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IExceptionService CreateExceptionService()
        {
            return CreateBizService<IExceptionService>("ExceptionService");
        }

        /// <summary>
        /// 创建选项服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IItemsService CreateItemsService()
        {
            return CreateBizService<IItemsService>("ItemsService");
        }

        /// <summary>
        /// 创建选项明细服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IItemDetailsService CreateItemDetailsService()
        {
            return CreateBizService<IItemDetailsService>("ItemDetailsService");
        }

        /// <summary>
        /// 创建日志服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ILogService CreateLogService()
        {
            return CreateBizService<ILogService>("LogService");
        }

        /// <summary>
        /// 创建序列服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ISequenceService CreateSequenceService()
        {
            return CreateBizService<ISequenceService>("SequenceService");
        }

        /// <summary>
        /// 创建框架数据访问层服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IDBProviderService CreateRDIFrameworkDBProviderService()
        {
            return CreateBizService<IDBProviderService>("RDIFrameworkDBProviderService");
        }

        /// <summary>
        /// 创建业务数据库服务
        /// </summary>
        /// <returns>数据库服务</returns>
        public IDBProviderService CreateBusinessDBProviderService()
        {
            return CreateBizService<IDBProviderService>("BusinessDBProviderService");
        }

        /// <summary>
        /// 表字段结构服务
        /// </summary>
        /// <returns>服务接口</returns>
        public ITableColumnsService CreateTableColumnsService()
        {
            return CreateBizService<ITableColumnsService>("TableColumnsService");
        }

        /// <summary>
        /// 创建文件服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IFileService CreateFileService()
        {
            return CreateBizService<IFileService>("FileService");
        }

        /// <summary>
        /// 创建目录/文件夹服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IFolderService CreateFolderService()
        {
            return CreateBizService<IFolderService>("FolderService");
        }

        /// <summary>
        /// 创建参数服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IParameterService CreateParameterService()
        {
            return CreateBizService<IParameterService>("ParameterService");
        }

        /// <summary>
        /// 数据库连接定义服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IDbLinkDefineService CreateDbLinkDefineService()
        {
            return CreateBizService<IDbLinkDefineService>("DbLinkDefineService");
        }

        /// <summary>
        /// 查询引擎服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IQueryEngineService CreateQueryEngineService()
        {
            return CreateBizService<IQueryEngineService>("QueryEngineService");
        }
        

        //2014工作流
        /// <summary>
        /// 工作流程实例服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowInstanceService CreateWorkFlowInstanceService()
        {
            return CreateBizService<IWorkFlowInstanceService>("WorkFlowInstanceService");
        }

        /// <summary>
        /// 工作流程辅助帮助服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowHelperService CreateWorkFlowHelperService()
        {
            return CreateBizService<IWorkFlowHelperService>("WorkFlowHelperService");
        }

        /// <summary>
        /// 工作流程模版服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowTemplateService CreateWorkFlowTemplateService()
        {
            return CreateBizService<IWorkFlowTemplateService>("WorkFlowTemplateService");
        }

        /// <summary>
        /// 工作流程用户表单服务
        /// </summary>
        /// <returns>服务接口</returns>
        public IWorkFlowUserControlService CreateWorkFlowUserControlService()
        {
            return CreateBizService<IWorkFlowUserControlService>("WorkFlowUserControlService");
        }
    }
}
