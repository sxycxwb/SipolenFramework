//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System.Reflection;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// DbProviderFactory
    /// 数据库服务工厂。
    /// 
    /// 修改纪录
    /// 
    ///     2015-09-10 版本：3.0 EricHu 重新重构。
    ///		2011.10.09 版本：2.1 EricHu 改进直接用数据库连接就可以打开连接的方法。
    ///		2011.10.08 版本：2.0 EricHu 支持多类型的多种数据库。
    ///		2011.09.18 版本：1.4 EricHu 整理代码注释。
    ///		2011.07.23 版本：1.2 EricHu 每次都获取一个新的数据库连接，解决并发错误问题。
    ///		2010.09.23 版本：1.1 EricHu 优化改进为单实例模式。
    ///		2010.08.26 版本：1.0 EricHu 创建数据库服务工厂。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2011.10.09</date>
    /// </author> 
    /// </summary>
    public class DbFactoryProvider
    {
        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbProvider GetProvider(string connectionString)
        {
            return GetProvider(CurrentDbType.SqlServer, connectionString);
        }

        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbProvider GetProvider(CurrentDbType dbType = CurrentDbType.SqlServer, string connectionString = null)
        {
            // 这里是每次都获取新的数据库连接,否则会有并发访问的问题存在
            var dbProviderClass = BusinessLogic.GetDbProviderClass(dbType);
            var dbProvider = (IDbProvider)Assembly.Load(SystemInfo.DbProviderAssmely).CreateInstance(dbProviderClass, true);
            if (!string.IsNullOrEmpty(connectionString) && dbProvider != null)
            {
                dbProvider.ConnectionString = connectionString;
            }
            return dbProvider;
        }
    }
}