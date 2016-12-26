using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;	

    /// <summary>
    /// ParameterService
    /// 参数服务
    /// 
    /// 修改纪录
    /// 
    ///		2015-08-05 版本：3.0 EricHu 新增分页显示、逻辑删除。
    ///		2013-12-21 版本：2.7.0 EricHu 创建文件。
    ///	
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2013-12-21</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ParameterService : System.MarshalByRefObject, IParameterService
    {
        private readonly string serviceName = RDIFrameworkMessage.ParameterService;

        /// <summary>
        /// 获取服务器上的配置信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="key">配置项主键</param>
        /// <returns>配置内容</returns>
        public string GetServiceConfig(UserInfo userInfo, string key)
        {
            return UserConfigHelper.GetValue(key);
        }        

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>参数值</returns>
        public string GetParameter(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_GetParameter);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                returnValue = parameterManager.GetParameter(categoryKey, parameterId, parameterCode);
            });
            return returnValue;
        }

        #region public CiParameterEntity GetEntity(UserInfo userInfo, string id)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiParameterEntity GetEntity(UserInfo userInfo, string id)
        {
            CiParameterEntity sequenceEntity = null;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                sequenceEntity = new CiParameterManager(dbProvider, userInfo).GetEntity(id);
            });

            return sequenceEntity;
        }
        #endregion

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <param name="parameterContent">参数内容</param>
        /// <param name="allowEdit">允许编辑</param>
        /// <param name="allowDelete">允许删除</param>
        /// <returns>影响行数</returns>
        public int SetParameter(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode, string parameterContent,int allowEdit = 0,int allowDelete = 0)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_SetParameter, "分类键值:" + categoryKey + "，参数主键：" + parameterId + ",参数编号：" + parameterCode);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                returnValue = parameterManager.SetParameter(categoryKey, parameterId, parameterCode, parameterContent,allowEdit,allowDelete);
            });
            return returnValue;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParameter(UserInfo userInfo, string categoryKey, string parameterId)
        {
            var dataTable = new DataTable(CiParameterTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_GetDTByParameter);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                dataTable = parameterManager.GetDTByParameter(categoryKey, parameterId);
                dataTable.TableName = CiParameterTable.TableName;
            });
            return dataTable;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <returns>数据表</returns>
        public List<CiParameterEntity> GetListByParameter(UserInfo userInfo, string categoryKey, string parameterId)
        {
            List<CiParameterEntity> list = new List<CiParameterEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_GetDTByParameter);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                    new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId),
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = parameterManager.GetList<CiParameterEntity>(parameters, CiParameterTable.FieldSortCode);
            });
            return list;
        }

        /// <summary>
        /// 按编号获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByParameterCode(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode)
        {
            var dataTable = new DataTable(CiParameterTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_GetDTByParameterCode);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                dataTable = parameterManager.GetDTByParameterCode(categoryKey, parameterId, parameterCode);
                dataTable.TableName = CiParameterTable.TableName;
            });
            return dataTable;
        }

        /// <summary>
        /// 按编号获取参数列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>数据表</returns>
        public List<CiParameterEntity> GetListByParameterCode(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode)
        {
            List<CiParameterEntity> list = new List<CiParameterEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_GetDTByParameterCode);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                    new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId),
                    new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterCode),
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = parameterManager.GetList<CiParameterEntity>(parameters, CiParameterTable.FieldSortCode);
            });
            return list;
        }

        #region public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "") 获取序列分页列表
        /// <summary>
        /// 获取序列分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有角色数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "")
        {
            var dataTable = new DataTable(CiParameterTable.TableName);
            var returnRecordCount = 0;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiParameterManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(whereConditional))
                {
                    whereConditional = CiParameterTable.FieldDeleteMark + " = 0 ";
                }
                else
                {
                    whereConditional += " AND " + CiParameterTable.FieldDeleteMark + " = 0 ";
                }

                dataTable = manager.GetDTByPage(out returnRecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = CiParameterTable.TableName;
            });
            recordCount = returnRecordCount;
            return dataTable;
        }
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string id) 逻辑删除参数
        /// <summary>
        /// 逻辑删除参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_Delete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new CiParameterManager(dbProvider).SetDeleted(id);
            });
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <returns>影响行数</returns>
        public int DeleteByParameter(UserInfo userInfo, string categoryKey, string parameterId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_DeleteByParameter, "分类键值：" + categoryKey + ",参数主键：" + parameterId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                returnValue = parameterManager.DeleteByParameter(categoryKey, parameterId);
            });
            return returnValue;
        }

        /// <summary>
        /// 按参数编号删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryKey">分类键值</param>
        /// <param name="parameterId">参数主键</param>
        /// <param name="parameterCode">参数编号</param>
        /// <returns>影响行数</returns>
        public int DeleteByParameterCode(UserInfo userInfo, string categoryKey, string parameterId, string parameterCode)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_DeleteByParameterCode,"分类键值：" + categoryKey + ",参数主键：" + parameterId + "，参数编号：" + parameterCode);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                returnValue = parameterManager.DeleteByParameterCode(categoryKey, parameterId, parameterCode);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_Delete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                returnValue = parameterManager.Delete(id);
            });
            return returnValue;
        }

        /// <summary>
        /// 批量删除参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ParameterService_BatchDelete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var parameterManager = new CiParameterManager(dbProvider, userInfo);
                returnValue += ids.Sum(t => parameterManager.Delete(t));
            });
            return returnValue;
        }
    }
}
