/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-25 10:15:58
 ******************************************************************************/
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PlatFormAddInService
    /// 平台插件服务
    /// 
    /// 修改纪录
    /// 
    ///		2012-05-25 版本：1.0 XuWangBin 建立PlatFormAddInService。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-05-25</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class PlatFormAddInService : System.MarshalByRefObject, IPlatFormAddInService
    {
        private string serviceName = RDIFrameworkMessage.PlatFormAddInService;

        /// <summary>
        /// 新增平台插件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主鍵</returns>
        public string Add(UserInfo userInfo, PiPlatFormAddInEntity entity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiPlatFormAddInManager(dbProvider, userInfo);
                returnValue = manager.Add(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }

        /// <summary>
        /// 取得平台插件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiPlatFormAddInTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiPlatFormAddInManager(dbProvider, userInfo).GetDT(CiDbLinkDefineTable.FieldDeleteMark, 0);
                dataTable.TableName = PiPlatFormAddInTable.TableName;
            });
            return dataTable;
        }

        /// <summary>
        /// 取得平台插件实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主鍵</param>
        /// <returns>实体</returns>
        public PiPlatFormAddInEntity GetEntity(UserInfo userInfo, string id)
        {
            PiPlatFormAddInEntity entity = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entity = new PiPlatFormAddInManager(dbProvider, userInfo).GetEntity(id);
            });
            
            return entity;
        }

        /// <summary>
        /// 更新平台插件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响的行数</returns>
        public int Update(UserInfo userInfo, PiPlatFormAddInEntity entity, out string statusCode, out string statusMessage)
        {
            int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiPlatFormAddInManager(dbProvider, userInfo);
                returnValue = manager.UpdateEntity(entity);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }

        /// <summary>
        /// 依主键取得平台插件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主鍵</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
        {
            var dataTable = new DataTable(PiPlatFormAddInTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiPlatFormAddInManager(dbProvider, userInfo).GetDT(PiPlatFormAddInTable.FieldId, ids);
                dataTable.TableName = PiPlatFormAddInTable.TableName;
            });
            return dataTable;
        }

        /// <summary>
        /// 按条件获取平台插件数据列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="names">字段</param>
        /// <param name="values">值</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values)
        {
            var dataTable = new DataTable(PiPlatFormAddInTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiPlatFormAddInManager(dbProvider, userInfo).GetDT(names, values);
                dataTable.TableName = PiPlatFormAddInTable.TableName;
            });
            return dataTable;
        }        

        /// <summary>
        /// 单个删除平台插件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主鍵</param>
        /// <returns>受影响的行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPlatFormAddInManager(dbProvider, userInfo).Delete(id);
            });
            return returnValue;
        }

        /// <summary>
        /// 批量设置删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>受影响的行数</returns>
        public int SetDeleted(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPlatFormAddInManager(dbProvider, userInfo).SetDeleted(ids);
            });

            return returnValue;
        }

        /// <summary>
        /// 设置可用性
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="enabled">是否可用(1:可用、0：不可用)</param>
        /// <returns>受影响的行数</returns>
        public int SetEnabled(UserInfo userInfo, string id,int enabled)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPlatFormAddInManager(dbProvider, userInfo).SetProperty(id, PiPlatFormAddInTable.FieldEnabled, enabled);
            });

            return returnValue;
        }

        public byte[] GetTheLatestAddIn(UserInfo userInfo,string Id)
        {
            var dtAddIn = new DataTable(PiPlatFormAddInTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dtAddIn = new PiPlatFormAddInManager(dbProvider, userInfo).GetDTById(Id);
            });
            return BusinessLogic.GetBinaryFormatData(dtAddIn);
        }
    }
}
