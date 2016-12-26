using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Windows.Forms;
using RDIFramework.BizLogic;

namespace RDIFramework.ServiceHost
{
    using RDIFramework.Utilities;

    static class AppStart
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemInfo.EnableRecordLog = true;
            SystemInfo.StartupPath = Application.StartupPath;
            UserConfigHelper.GetConfig();
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(@"服务器端正在启动...");
            System.Console.ForegroundColor = ConsoleColor.White;
            // 读取配置文件
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            var serviceModelSectionGroup = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
            // 开启每个服务
            var idxService = 1;
            if (serviceModelSectionGroup != null)
            {
                foreach (var serviceHost in from ServiceElement serviceElement in serviceModelSectionGroup.Services.Services 
                                            let assemblyString = serviceElement.Name.Substring(0, serviceElement.Name.LastIndexOf('.')) 
                                            select new System.ServiceModel.ServiceHost(Assembly.Load(assemblyString).GetType(serviceElement.Name),serviceElement.Endpoints[0].Address))
                {
                    serviceHost.Opened += delegate
                    {
                        Console.WriteLine(@"第{0:00}个服务：{1}", idxService, serviceHost.BaseAddresses[0]);
                    };
                    serviceHost.Open();
                    idxService++;
                }


                /* V2.7版本时的方法
                foreach (ServiceElement serviceElement in serviceModelSectionGroup.Services.Services)
                {
                    var assemblyString = serviceElement.Name.Substring(0, serviceElement.Name.LastIndexOf('.'));
                    var serviceHost =
                        new System.ServiceModel.ServiceHost(Assembly.Load(assemblyString).GetType(serviceElement.Name),
                            serviceElement.Endpoints[0].Address);

                    serviceHost.Opened += delegate
                    {
                        Console.WriteLine(@"第{0:00}个服务：{1}", idxService, serviceHost.BaseAddresses[0]);
                    };
                    serviceHost.Open();
                    idxService++;
                }*/

            }
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(@"服务器端已正常启动...");
            System.Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine();
            System.Console.WriteLine();


            System.Console.WriteLine(@"服务器 当前时间：" + DateTime.Now.ToString(SystemInfo.DateTimeFormat));
            var dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType,SystemInfo.RDIFrameworkDbConection);
            System.Console.WriteLine(@"数据库服务器 当前时间：" + dbProvider.GetDBDateTime());
            System.Console.WriteLine();

            // 写入调试信息
            #if (DEBUG)
            
            var rdiDBProviderService = new RDIFrameworkDBProviderService();
            System.Console.WriteLine(@"RDIFramework.NET ━ .NET快速信息化系统开发框架 数据库服务器数据库连接：");
            System.Console.WriteLine(rdiDBProviderService.ServiceDbConnection);
            System.Console.WriteLine(rdiDBProviderService.ExecuteScalar(SystemInfo.UserInfo, "SELECT GETDATE()").ToString());
            System.Console.WriteLine();

            var bizDBProviderService = new BusinessDBProviderService();
            System.Console.WriteLine(@"业务数据库服务器 数据库连接：");
            System.Console.WriteLine(bizDBProviderService.ServiceDbConnection);
            System.Console.WriteLine(bizDBProviderService.ExecuteScalar(SystemInfo.UserInfo, "SELECT GETDATE()").ToString());
            System.Console.ReadLine();
            #endif
            Application.Run(new FrmServiceHost());
        }
    }

    public class UserNamePasswordValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != SystemInfo.ServiceUserName || password != SystemInfo.ServicePassword)
            {
                throw new System.IdentityModel.Tokens.SecurityTokenException(RDIFrameworkMessage.MSG0800);
            }
        }
    }
}
