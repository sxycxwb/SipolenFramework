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
    /// CustomerService
    /// 客户信息服务层
    /// 
    /// 修改记录
    /// 
    ///	2012-08-15 版本：1.0 Edward 建立档案。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///	<name>Edward</name>
    ///	<date>2012-08-15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CustomerService : System.MarshalByRefObject, ICustomerService
    {
        private string serviceName = "Customer";

        /// <summary>
        /// 快速开发整合框架(RDIFramework.NET)连接
        /// </summary>
        private readonly string RDIFrameworkDbConection = SystemInfo.RDIFrameworkDbConection;

        /// <summary>
        /// 业务逻辑数据库连接字符串
        /// </summary>
        public string BusinessDbConnection = SystemInfo.BusinessDbConnection;

        CurrentDbType BusinessDbType = CurrentDbType.SqlServer;

        public CustomerService()
        {         
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="businessDbType">当前商业数据库类型</param>
        /// <param name="businessDbConnection">当前商业数据库连接字符串</param>
        public CustomerService(CurrentDbType businessDbType, string businessDbConnection)
            : this()
        {
            BusinessDbType       = businessDbType;
            BusinessDbConnection = businessDbConnection;
        }


        #region public string Add(UserInfo userInfo, CustomerEntity entity, out string statusCode, out string statusMessage) 新增实体
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态消息</param>
        /// <returns>主鍵</returns>
        public string Add(UserInfo userInfo, CustomerEntity entity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            statusCode = string.Empty;

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
                            CustomerManager manager = new CustomerManager(dbProvider, userInfo);                            
                            returnValue = manager.Add(entity, out statusCode);
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

        #region public DataTable GetDataTable(UserInfo userInfo) 取得数据表
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(UserInfo userInfo)
        {
            DataTable dataTable = new DataTable(CustomerTable.TableName);

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    // 取得列表
                    CustomerManager manager = new CustomerManager(dbProvider, userInfo);
                    dataTable = manager.GetDT(new KeyValuePair<string, object>(CustomerTable.FieldDeleteMark, 0), CustomerTable.FieldSortCode);
                    dataTable.TableName = CustomerTable.TableName;
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

        #region public DataTable GetDataTableByPage(UserInfo userInfo, string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null) 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="searchValue">查询关键字</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(UserInfo userInfo, string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        {
            DataTable dataTable = new DataTable(CustomerTable.TableName);

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    // 取得列表
                    CustomerManager manager = new CustomerManager(dbProvider, userInfo);
                    dataTable = manager.GetDataTableByPage(userId, searchValue, out recordCount, pageIndex, pageSize, sortExpression, sortDire);
                    dataTable.TableName = CustomerTable.TableName;
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

        #region public CustomerEntity GetEntity(UserInfo userInfo, string id) 取得实体
        /// <summary>
        /// 取得实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主鍵</param>
        /// <returns>实体</returns>
        public CustomerEntity GetEntity(UserInfo userInfo, string id)
        {
            CustomerEntity entity = null;

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    CustomerManager manager = new CustomerManager(dbProvider, userInfo);
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

        #region public DataTable GetCustomerContactInfo(UserInfo userInfo, string id) 得到客户-主联系人信息
        /// <summary>
        /// 得到客户-主联系人信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetCustomerContactInfo(UserInfo userInfo, string id)
        {          
            DataTable dataTable = new DataTable();
            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    // 取得列表
                    CustomerManager manager = new CustomerManager(dbProvider, userInfo);
                    dataTable = manager.GetCustomerContactInfo(id);
                    dataTable.TableName = CustomerTable.TableName;
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

        #region public int Update(UserInfo userInfo, CustomerEntity entity, out string statusCode, out string statusMessage) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, CustomerEntity entity, out string statusCode, out string statusMessage)
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
                            CustomerManager manager = new CustomerManager(dbProvider, userInfo);
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

        #region public int UpdateByValues(UserInfo userInfo, List<KeyValuePair<string, object>> whereParameters,List<KeyValuePair<string, object>> parameters):根据条件更新数据
        /// <summary>
        /// 根据条件更新数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="whereParameters">条件键值对</param>
        /// <param name="parameters">键值对</param>
        /// <returns>受影响的行数</returns>
        public int UpdateByValues(UserInfo userInfo, List<KeyValuePair<string, object>> whereParameters,List<KeyValuePair<string, object>> parameters)
        {
            int returnValue = 0;

            using (IDbProvider rdiDbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    rdiDbProvider.Open(RDIFrameworkDbConection);
                    LogManager.Instance.Add(rdiDbProvider, userInfo, this.serviceName, "根据条件更新数据", MethodBase.GetCurrentMethod());

                    using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
                    {
                        try
                        {
                            dbProvider.Open(BusinessDbConnection);
                            // 根据条件获取数据
                            CustomerManager manager = new CustomerManager(dbProvider, userInfo); 
                            returnValue = manager.SetProperty(manager.GetIds(parameters),whereParameters);
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
            DataTable dataTable = new DataTable(CustomerTable.TableName);

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    CustomerManager manager = new CustomerManager(dbProvider, userInfo);
                    dataTable = manager.GetDT(CustomerTable.FieldId, ids, CustomerTable.FieldSortCode);
                    dataTable.TableName = CustomerTable.TableName;
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

        #region public DataTable GetDTByCategory(UserInfo userInfo, string category = "") 根据分类获取数据
        /// <summary>
        /// 根据分类获取数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="category">分类</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByCategory(UserInfo userInfo, string category = "")
        {
            DataTable dataTable = new DataTable(CustomerTable.TableName);

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    // 根据条件获取数据
                    CustomerManager manager = new CustomerManager(dbProvider, userInfo);
                    dataTable = manager.GetDTByCategory(category);
                    dataTable.TableName = CustomerTable.TableName;
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
                            CustomerManager manager = new CustomerManager(dbProvider, userInfo);
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
                            CustomerManager manager = new CustomerManager(dbProvider, userInfo);
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
                            CustomerManager manager = new CustomerManager(dbProvider, userInfo);
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