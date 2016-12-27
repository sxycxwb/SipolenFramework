using System.Configuration;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
    /// <summary>
    /// RDIFrameworkServiceFactory
    /// 
    /// 修改纪录
    /// 
    ///     2014-07-18 版本:2.8 再次重构，去掉默认空的构造函数。
    ///     2013-05-15 版本 :2.0 重构。
    ///		2012-03-01 版本：1.0 XuWangBin 创建。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-01</date>
    /// </author> 
    /// </summary>
    public abstract class RDIFrameworkServiceFactory : System.MarshalByRefObject
    {

        /// <summary>
        /// 得到默认的服务工厂
        /// </summary>
        /// <returns></returns>
        public IServiceFactory GetServiceFactory()
        {
            return GetServiceFactory(SystemInfo.Service);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicePath"></param>
        /// <returns></returns>
        public IServiceFactory GetServiceFactory(string servicePath)
        {
            string className = servicePath + "." + SystemInfo.ServiceFactory;
            return (IServiceFactory)Assembly.Load(servicePath).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicePath"></param>
        /// <param name="serviceFactoryClass"></param>
        /// <returns></returns>
        public IServiceFactory GetServiceFactory(string servicePath, string serviceFactoryClass)
        {
            string className = servicePath + "." + serviceFactoryClass;
            return (IServiceFactory)Assembly.Load(servicePath).CreateInstance(className);
        }
    }
}