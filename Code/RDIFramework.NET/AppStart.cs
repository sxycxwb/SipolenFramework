using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace RDIFramework.NET
{
    using CAutoUpdater;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    static class AppStart
    {
        /// <summary>
        /// 即时通讯
        /// </summary>
        public static FrmMsg frmMsg = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var handler = new ThreadExceptionHandler();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += handler.Application_ThreadException;            
            SystemInfo.MainAssembly = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            SystemInfo.StartupPath = Application.StartupPath;
            SystemInfo.AppIco = Path.Combine(Application.StartupPath, SystemInfo.AppIco);

            #region check and download new version program 启动自动升级
            
            //bool bHasError = false;
            //IAutoUpdater autoUpdater = new AutoUpdater();
            //try
            //{
            //     autoUpdater.Update();
            //}
            //catch (WebException ex)
            //{
            //    LogHelper.WriteException(ex);
            //    MessageBoxHelper.ShowErrorMsg("连接自动升级服务器出错，请检查网络连接或联系软件提供商。");
            //    bHasError = true;
            //}
            //catch (XmlException ex)
            //{
            //    LogHelper.WriteException(ex);
            //    bHasError = true;
            //    MessageBoxHelper.ShowErrorMsg("AutoUpdate Error:Download the upgrade file error");
            //}
            //catch (NotSupportedException ex)
            //{
            //    LogHelper.WriteException(ex);
            //    bHasError = true;
            //    MessageBoxHelper.ShowErrorMsg("AutoUpdate Error:Upgrade address configuration error");
            //}
            //catch (ArgumentException ex)
            //{
            //    LogHelper.WriteException(ex);
            //    bHasError = true;
            //    MessageBoxHelper.ShowErrorMsg("AutoUpdate Error:Download the upgrade file error");
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteException(ex);
            //    bHasError = true;
            //    MessageBoxHelper.ShowErrorMsg("AutoUpdate Error:An error occurred during the upgrade process");
            //}

            //finally
            //{
            //    if (bHasError == true)
            //    {
            //        try
            //        {
            //            autoUpdater.RollBack();
            //        }
            //        catch (Exception ex)
            //        {
            //            LogHelper.WriteException(ex);                       
            //        }
            //    }
            //}
            
            #endregion

            // 获取配置信息
            try
            {
                GetConfig();
            }
            catch(Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg(ex.Message);
            }

            SystemInfo.WebHostUrl = ConfigurationManager.AppSettings["WebHostUrl"];

            if (SystemInfo.MultiLanguage)
            {
                try
                {
                    // 多语言国际化加载
                    ResourceManagerWrapper.Instance.LoadResources(Path.Combine(Application.StartupPath,"Resource/Localization/"));
                    // 从当前指定的语言包读取信息
                    RDIFrameworkMessage.GetLanguageResource();
                }
                catch (Exception ex)
                {
                    FileHelper.WriteException(ex,"登录异常.txt");
                }
            }

            // 初始化服务
            RDIFrameworkService.Instance.InitService();           
            Form mainForm = BasePageLogic.GetForm(SystemInfo.MainAssembly, SystemInfo.MainForm);
            Application.Run(mainForm);
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        public static void GetConfig()
        {
            // 读取客户端配置文件
            SystemInfo.ConfigurationFrom = ConfigurationCategory.UserConfig;
            UserConfigHelper.GetConfig();
        }

        #region public static void InitService(UserInfo userInfo) 加载服务
        /// <summary>
        /// 加载服务
        /// </summary>
        public static void InitService(UserInfo userInfo)
        {           
            ClientCache.Instance.DTOrganize = null;
            RDIFrameworkService.Instance.InitService();
            ClientCache.Instance.GetOrganizeDT(userInfo);
        }
        #endregion
   
    }

    #region ThreadExceptionHandler 捕获未处理的异常
    /// <summary>
    /// 捕获未处理的异常
    /// </summary>
    internal class ThreadExceptionHandler
    {
        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var frmException = new FrmException(e.Exception);
                frmException.ShowDialog();
            }
            catch
            {
                try
                {
                    MessageBox.Show("严重错误", "严重错误",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
    #endregion
}
