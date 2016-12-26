using System;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	/// <summary>
    /// ServiceUtil
	/// 委托加匿名函数进行服务的统一调用。
	///	
	/// </summary>
	public class ServiceUtil
	{
		public delegate void ProcessFunDelegate(IDbProvider dbProvider);
        
		public delegate bool ProcessFunWithLockDelegate(IDbProvider dbProvider, bool getOnLine);

        public static void ProcessRDIReadDb(UserInfo userInfo, ParameterUtil parameter, ProcessFunDelegate fun)
		{
            if(SystemInfo.IsAuthorized(userInfo)){
			    ProcessDb(parameter, fun, DbType.RDIDbRead);
            }
		}

        public static void ProcessRDIWriteDb(UserInfo userInfo,ParameterUtil parameter, ProcessFunDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                ProcessDb(parameter, fun, DbType.RDIDbWrite);
            }
		}

		public static void ProcessRDIDb(UserInfo userInfo,ParameterUtil parameter, ProcessFunDelegate fun)
		{
		    if (SystemInfo.IsAuthorized(userInfo))
		    {
		        ProcessDb(parameter, fun, DbType.RDIDb);
		    }
		}

        public static void ProcessRDIWriteDbWithLock(UserInfo userInfo, ParameterUtil parameter, object locker, ProcessFunWithLockDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                int milliStart = Begin(parameter.UserInfo, parameter.CurrentMethod);
                bool getOnLine = false;
                lock (locker)
                {
                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(GetDbType(DbType.RDIDbWrite)))
                    {
                        try
                        {
                            dbProvider.Open(GetDbConnection(DbType.RDIDbWrite));
                            getOnLine = fun(dbProvider, getOnLine);
                            AddLog(dbProvider, parameter);
                        }
                        catch (Exception ex)
                        {
                            CiExceptionManager.LogException(dbProvider, parameter.UserInfo, ex);
                            throw;
                        }
                        finally
                        {
                            dbProvider.Close();
                        }
                    }
                }
                End(milliStart, parameter.CurrentMethod, getOnLine);
            }
		}

        public static void ProcessRDIWriteDbWithLock(UserInfo userInfo, ParameterUtil parameter, object locker, ProcessFunDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                int milliStart = Begin(parameter.UserInfo, parameter.CurrentMethod);
                lock (locker)
                {
                    ProcessDbProvider(parameter, fun, DbType.RDIDbWrite, false);
                }
                End(milliStart, parameter.CurrentMethod);
            }
		}

        public static void ProcessRDIWriteDbWithTran(UserInfo userInfo,ParameterUtil parameter, ProcessFunDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                ProcessDb(parameter, fun, DbType.RDIDbWrite, true);
            }
		}

        public static void ProcessBusinessDb(UserInfo userInfo, ParameterUtil parameter, ProcessFunDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                ProcessDb(parameter, fun, DbType.Business);
            }
		}

        public static void ProcessWorkFlowDb(UserInfo userInfo, ParameterUtil parameter, ProcessFunDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                ProcessDb(parameter, fun, DbType.WorkFlow);
            }
		}

        public static void ProcessWorkFlowDbWithTransaction(UserInfo userInfo, ParameterUtil parameter, ProcessFunDelegate fun)
		{
            if (SystemInfo.IsAuthorized(userInfo))
            {
                ProcessDb(parameter, fun, DbType.WorkFlow, true);
            }
		}

		/// <summary>
		/// 数据库类型
		/// </summary>
		private enum DbType
		{
            RDIDbRead = 0x0001,
            RDIDbWrite = 0x0002,
            RDIDb = 0x0003,
            Business = 0x0004,
            WorkFlow = 0x0005
		}

		private static CurrentDbType GetDbType(DbType dbType)
		{
			switch(dbType)
			{
                case DbType.RDIDbRead:
                case DbType.RDIDbWrite:
                case DbType.RDIDb:
                    return SystemInfo.RDIFrameworkDbType;
				case DbType.Business:
					return SystemInfo.BusinessDbType;
				case DbType.WorkFlow:
					return SystemInfo.WorkFlowDbType;
                default:
                    return SystemInfo.RDIFrameworkDbType;
			}
		}

		private static string GetDbConnection(DbType dbType)
		{
			switch(dbType)
			{
				default:
                    return SystemInfo.RDIFrameworkDbConection;
                case DbType.RDIDbRead:
                case DbType.RDIDbWrite:
                case DbType.RDIDb:
                    return SystemInfo.RDIFrameworkDbConection; //.RDIFramework.NET ━ .NET快速信息化系统开发框架数据库连接
				case DbType.Business:
					return SystemInfo.BusinessDbConnection;
				case DbType.WorkFlow:
					return SystemInfo.WorkFlowDbConnection;
			}
		}

        private static void ProcessDb(ParameterUtil parameter, ProcessFunDelegate fun, DbType dbType, bool inTransaction = false)
		{
            int milliStart = Begin(parameter.UserInfo, parameter.CurrentMethod);
			ProcessDbProvider(parameter, fun, dbType, inTransaction);
            End(milliStart, parameter.CurrentMethod);
		}

		private static void ProcessDbProvider(ParameterUtil sup, ProcessFunDelegate fun, DbType dbType, bool inTransaction)
		{
			using(IDbProvider dbProvider = DbFactoryProvider.GetProvider(GetDbType(dbType)))
			{
				try
                {
                    dbProvider.Open(GetDbConnection(dbType));
                    if (inTransaction)
                    {
                        dbProvider.BeginTransaction();
                    }
                    fun(dbProvider);
                    AddLog(dbProvider,sup);
                    if (inTransaction)
                    {
                        dbProvider.CommitTransaction();
                    }
                }
				catch(Exception ex)
				{
                    if (inTransaction)
                    {
                        dbProvider.RollbackTransaction();
                    }
					CiExceptionManager.LogException(dbProvider, sup.UserInfo, ex);
					throw;
				}
				finally
				{
					dbProvider.Close();
				}
			}
		}

        private static void AddLog(IDbProvider dbProvider,ParameterUtil sup)
		{
		    if (!sup.IsAddLog) return;
		    if(sup.RDIFrameworkMessage.Length == 0)
		    {
		        LogManager.Instance.Add(dbProvider,sup.UserInfo, sup.ServiceName,sup.CurrentMethod.Name ,sup.CurrentMethod);
		    }
            else if (sup.RDIFrameworkMessage.Length > 0 || !string.IsNullOrEmpty(sup.Parameter))
		    {
		        LogManager.Instance.Add(dbProvider,sup.UserInfo, sup.ServiceName, sup.RDIFrameworkMessage, sup.CurrentMethod,sup.Parameter);
		    }
		}

	    private static int Begin(UserInfo userInfo, MethodBase currentMethod)
		{
			int milliStart = 0;
			// 写入调试信息
			#if (DEBUG)
                milliStart = BusinessLogic.StartDebug(userInfo, currentMethod);
            #endif

            // 加强安全验证防止未授权匿名调用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif
			return milliStart;
		}

		private static void End(int milliStart, MethodBase currentMethod)
		{
			// 写入调试信息
			#if (DEBUG)
				BusinessLogic.EndDebug(currentMethod, milliStart);
			#endif
		}

		private static void End(int milliStart, MethodBase currentMethod, bool getOnLine)
		{
			// 写入调试信息
			#if (DEBUG)
			if(getOnLine)
			{
				BusinessLogic.EndDebug(currentMethod, milliStart);
			}
			#endif
		}
	}
}
