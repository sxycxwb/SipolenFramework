using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Reflection;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace RDIFramework.WinService
{
    using RDIFramework.Utilities;

    public partial class RDIFrameworkWinService : ServiceBase
    {
        ///<summary>
        /// 服务数组
        /// </summary>
        ServiceHost[] serviceHosts = null;

        public RDIFrameworkWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // 是否检查在线状态
            SystemInfo.CheckOnLine = false;
            SystemInfo.EnableCheckPasswordStrength = true;
            // 是否记录日志
            SystemInfo.EnableRecordLog = true;
            // 是否需要注册
            SystemInfo.NeedRegister = false;
            // 读取配置文件
            UserConfigHelper.GetConfig(SystemInfo.StartupPath + "\\" + UserConfigHelper.FileName);

            // 读取配置文件
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            var serviceModelSectionGroup = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
            // 开启每个服务
            var idxService = 0;
            serviceHosts = new ServiceHost[serviceModelSectionGroup.Services.Services.Count];
            foreach (ServiceElement serviceElement in serviceModelSectionGroup.Services.Services)
            {
                var assemblyString = serviceElement.Name.Substring(0, serviceElement.Name.LastIndexOf('.'));
                var serviceHost = new ServiceHost(Assembly.Load(assemblyString).GetType(serviceElement.Name), serviceElement.Endpoints[0].Address);
                //var serviceHost = new ServiceHost(Assembly.Load(assemblyString).GetType(serviceElement.Name));
                serviceHost.Opened += delegate { Console.WriteLine("第{0}个服务：{1}", idxService + 1, serviceHost.BaseAddresses[0]); };
                serviceHost.Open();
                serviceHosts[idxService] = serviceHost;
                idxService++;
            }
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            Trace.WriteLine("Shutting down ServiceHost...");
            if (serviceHosts != null)
            {
                for (var i = serviceHosts.Length - 1; i >= 0; i--)
                {
                    serviceHosts[i].Close();
                    serviceHosts[i] = null;
                }
            }
            base.OnStop();
        }
    }
}
