//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// IncomingCallService
    /// 来电处理服务层
    /// 
    /// 修改记录
    /// 
    ///	2012-09-03 版本：1.0 Edward 建立档案。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///	<name>Edward</name>
    ///	<date>2012-09-03</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class IncomingCallService : System.MarshalByRefObject, IIncomingCallService
    {
        private string serviceName = "IncomingCallService";

        /// <summary>
        /// 快速开发整合框架(RDIFramework.NET)连接
        /// </summary>
        private readonly string RDIFrameworkDbConection = SystemInfo.RDIFrameworkDbConection;

        /// <summary>
        /// 业务逻辑数据库连接字符串
        /// </summary>
        private readonly string BusinessDbConnection = SystemInfo.BusinessDbConnection;
        CurrentDbType BusinessDbType = CurrentDbType.SqlServer;

        public IncomingCallService()
        {         
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="businessDbType">当前商业数据库类型</param>
        /// <param name="businessDbConnection">当前商业数据库连接字符串</param>
         public IncomingCallService(CurrentDbType businessDbType, string businessDbConnection)
            : this()
        {
            BusinessDbType       = businessDbType;
            BusinessDbConnection = businessDbConnection;
        }

        #region public string Add(UserInfo userInfo, IncomingCallEntity entity) 新增实体
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>主鍵</returns>
        public string Add(UserInfo userInfo, IncomingCallEntity entity)
        {
            string returnValue = string.Empty;

            using (IDbProvider rdiDbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    rdiDbProvider.Open(RDIFrameworkDbConection);
                    LogManager.Instance.Add(rdiDbProvider, userInfo, this.serviceName, "新增实体", MethodBase.GetCurrentMethod());

                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
                    {
                        try
                        {
                            dbProvider.Open(BusinessDbConnection);
                            IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                            returnValue = manager.AddEntity(entity);
                        }
                        catch (Exception ex)
                        {
                            CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                            throw ex;
                        }
                        finally
                        {
                            dbProvider.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    rdiDbProvider.Close();
                }
            }

            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTable(UserInfo userInfo) 取得数据表
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(UserInfo userInfo)
        {
            DataTable dataTable = new DataTable(IncomingCallTable.TableName);

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    // 取得列表
                    IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                    dataTable = manager.GetDT(new KeyValuePair<string, object>(IncomingCallTable.FieldDeleteMark, 0), IncomingCallTable.FieldSortCode);
                    dataTable.TableName = IncomingCallTable.TableName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }
            return dataTable;
        }
        #endregion      

        #region public IncomingCallEntity GetEntity(UserInfo userInfo, string id) 取得实体
        /// <summary>
        /// 取得实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主鍵</param>
        /// <returns>实体</returns>
        public IncomingCallEntity GetEntity(UserInfo userInfo, string id)
        {
            IncomingCallEntity entity = null;

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                    entity = manager.GetEntity(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }
            return entity;
        }
        #endregion

        #region public int Update(UserInfo userInfo, IncomingCallEntity entity, out string statusCode, out string statusMessage) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, IncomingCallEntity entity, out string statusCode, out string statusMessage)
        {
            int returnValue = 0;
            statusCode = string.Empty;

            using (IDbProvider rdiDbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    rdiDbProvider.Open(RDIFrameworkDbConection);
                    LogManager.Instance.Add(rdiDbProvider, userInfo, this.serviceName, "更新实体", MethodBase.GetCurrentMethod());

                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
                    {
                        try
                        {
                            dbProvider.Open(BusinessDbConnection);
                            IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);                            
                            returnValue = manager.Update(entity, out statusCode);
                            statusMessage = manager.GetStateMessage(statusCode);
                        }
                        catch (Exception ex)
                        {
                            CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                            throw ex;
                        }
                        finally
                        {
                            dbProvider.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    rdiDbProvider.Close();
                }
            }
            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTableByIds(UserInfo userInfo, string[] ids) 根据主键数组获取数据
        /// <summary>
        /// 根据主键数组获取数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主鍵</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByIds(UserInfo userInfo, string[] ids)
        {
            DataTable dataTable = new DataTable(IncomingCallTable.TableName);

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                    dataTable = manager.GetDT(IncomingCallTable.FieldId, ids, IncomingCallTable.FieldSortCode);
                    dataTable.TableName = IncomingCallTable.TableName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }

            return dataTable;
        }
        #endregion       

        #region public int Delete(UserInfo userInfo, string id) 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主鍵</param>
        /// <returns>数据表</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;

            using (IDbProvider rdiDbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    rdiDbProvider.Open(RDIFrameworkDbConection);
                    LogManager.Instance.Add(rdiDbProvider, userInfo, this.serviceName, "删除数据", MethodBase.GetCurrentMethod());

                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
                    {
                        try
                        {
                            dbProvider.Open(BusinessDbConnection);
                            IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                            returnValue = manager.Delete(id);
                        }
                        catch (Exception ex)
                        {
                            CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                            throw ex;
                        }
                        finally
                        {
                            dbProvider.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    rdiDbProvider.Close();
                }
            }
            
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量删除数据
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;

            using (IDbProvider rdiDbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    rdiDbProvider.Open(RDIFrameworkDbConection);
                    LogManager.Instance.Add(rdiDbProvider, userInfo, this.serviceName, "批量删除数据", MethodBase.GetCurrentMethod());

                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
                    {
                        try
                        {
                            dbProvider.Open(BusinessDbConnection);
                            // 开始事务
                            dbProvider.BeginTransaction();
                            IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                            returnValue = manager.Delete(ids);
                            // 提交事务
                            dbProvider.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            // 回滚事务
                            dbProvider.RollbackTransaction();
                            CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                            throw ex;
                        }
                        finally
                        {
                            dbProvider.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    rdiDbProvider.Close();
                }
            }

            return returnValue;
        }
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids) 批量设置删除标志
        /// <summary>
        /// 批量设置删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;

            using (IDbProvider rdiDbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    rdiDbProvider.Open(RDIFrameworkDbConection);
                    LogManager.Instance.Add(rdiDbProvider, userInfo, this.serviceName, "批量设置删除标志", MethodBase.GetCurrentMethod());

                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
                    {
                        try
                        {
                            dbProvider.Open(BusinessDbConnection);
                            IncomingCallManager manager = new IncomingCallManager(dbProvider, userInfo);
                            returnValue = manager.SetDeleted(ids);
                        }
                        catch (Exception ex)
                        {
                            CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                            throw ex;
                        }
                        finally
                        {
                            dbProvider.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CiExceptionManager.LogException(rdiDbProvider, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    rdiDbProvider.Close();
                }
            }
            return returnValue;
        }
        #endregion
    }
}