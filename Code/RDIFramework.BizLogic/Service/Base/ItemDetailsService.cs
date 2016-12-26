//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	/// <summary>
	/// CiItemDetailsService
	/// 服务层
	/// 
	/// 修改记录
	/// 
	///		2012-03-02 版本：1.0 EricHu 建立。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class ItemDetailsService : System.MarshalByRefObject, IItemDetailsService
	{
		/// <summary>
		/// 平台连接
		/// </summary>
		private readonly string RDIFrameworkDbConection = SystemInfo.RDIFrameworkDbConection;

		/// <summary>
		/// 新增数据
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="entity">实体</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>受影响的行数</returns>
		public int Add(UserInfo userInfo, CiItemDetailsEntity entity,out string statusMessage)
		{
            int returnValue = 0;
            statusMessage = string.Empty;

            if (this.GetDTByValues(userInfo, new string[] { CiItemDetailsTable.FieldItemId, CiItemDetailsTable.FieldItemName, CiItemDetailsTable.FieldDeleteMark }, new string[] { entity.ItemId.ToString(), entity.ItemName, "0" }).Rows.Count > 0)
            {
                returnValue = 0;
                statusMessage = "已存在相同的明细项！";
            }
            else
            {
                using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
                {
                    try
                    {
                        dbProvider.Open(RDIFrameworkDbConection);
                        var manager = new CiItemDetailsManager(dbProvider, userInfo);
                        returnValue = !string.IsNullOrEmpty(manager.AddEntity(entity)) ?1:0;
                        statusMessage = "成功新增数据！";
                    }
                    catch (Exception ex)
                    {
                        CiExceptionManager.LogException(dbProvider, userInfo, ex);
                        throw ex;
                    }
                    finally
                    {
                        dbProvider.Close();
                    }
                }
            }
			return returnValue;
		}

		/// <summary>
		/// 取得列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <returns>数据表</returns>
		public DataTable GetDT(UserInfo userInfo)
		{
			var dataTable = new DataTable(CiItemDetailsTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                dataTable = manager.GetDT(CiItemDetailsTable.FieldDeleteMark, 0, CiItemDetailsTable.FieldSortCode);
                dataTable.TableName = CiItemDetailsTable.TableName;
            });

			return dataTable;
		}
        

		/// <summary>
		/// 取得实体
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="id">主鍵</param>
		/// <returns>实体</returns>
		public CiItemDetailsEntity GetEntity(UserInfo userInfo, string id)
		{
			CiItemDetailsEntity entity = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                entity = manager.GetEntity(id);
            });

			return entity;
		}

		/// <summary>
		/// 更新实体
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="entity">实体</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>影响行数</returns>
		public int Update(UserInfo userInfo, CiItemDetailsEntity entity, out string statusMessage)
		{

			int returnValue = 0;
            statusMessage = string.Empty;

            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType))
            {
                try
                {
                    dbProvider.Open(RDIFrameworkDbConection);
                   
                    var manager = new CiItemDetailsManager(dbProvider, userInfo);
                    if (manager.IsExisted(entity))
                    {
                        returnValue = 0;
                        statusMessage = "已存在相同的明细项！";
                    }
                    else
                    {
                        returnValue = manager.UpdateEntity(entity);
                        statusMessage = "修改数据成功！";
                    }
                }
                catch (Exception ex)
                {
                    CiExceptionManager.LogException(dbProvider, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }
            
			return returnValue;
		}

		/// <summary>
		/// 依主键数组獲取数据列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主鍵</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
		{
            var dataTable = new DataTable(CiItemDetailsTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                dataTable = manager.GetDT(CiItemDetailsTable.FieldId, ids, CiItemDetailsTable.FieldSortCode);
                dataTable.TableName = CiItemDetailsTable.TableName;
            });

			return dataTable;
		}
		
		/// <summary>
		/// 依條件獲取数据列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="names">字段</param>
		/// <param name="values">值</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values)
		{			
			DataTable dataTable = new DataTable(CiItemDetailsTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                dataTable = manager.GetDT(names, values);
                dataTable.TableName = CiItemDetailsTable.TableName;
            });
			return dataTable;
		}

		/// <summary>
		/// 批次保存数据
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="entites">实体列表</param>
		/// <returns>影响行数</returns>
		public int BatchSave(UserInfo userInfo, List<CiItemDetailsEntity> entites)
		{
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                //returnValue = manager.BatchSave(entites);
            });
			return returnValue;
		}
		
		/// <summary>
		/// 刪除数据
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="id">主鍵</param>
		/// <returns>数据表</returns>
		public int Delete(UserInfo userInfo, string id)
		{   
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                returnValue = manager.Delete(id);
            });
           
			return returnValue;
		}
		
		/// <summary>
		/// 批次刪除数据
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响行数</returns>
		public int BatchDelete(UserInfo userInfo, string[] ids)
		{
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                returnValue = manager.Delete(ids);
            });
			return returnValue;
		}

		/// <summary>
		/// 批次設置刪除标志
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响行数</returns>
		public int SetDeleted(UserInfo userInfo, string[] ids)
		{
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                returnValue = manager.SetDeleted(ids);
            });
			return returnValue;
		}

        /// <summary>
        /// 绑定下列列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">Code</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByCode(UserInfo userInfo, string code)
        {
            var dataTable = new DataTable(CiItemDetailsTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiItemDetailsManager(dbProvider, userInfo);
                dataTable = manager.GetDTByCode(code);
                dataTable.TableName = CiItemDetailsTable.TableName;
            });

            return dataTable;
        }
	}
}
