using System.ServiceProcess;

namespace RDIFramework.WinService
{
    static class AppStart
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            RDIFramework.Utilities.SystemInfo.StartupPath = System.Windows.Forms.Application.StartupPath;

            var servicesToRun = new ServiceBase[] 
            { 
                new RDIFrameworkWinService() 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
