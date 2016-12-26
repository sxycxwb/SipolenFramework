using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowHelperService
    {
        #region public string InsertAttachment(UserInfo userInfo, AttachmentEntity entity) 增加附件
        /// <summary>
        /// 增加附件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        public string InsertAttachment(UserInfo userInfo, AttachmentEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AttachmentManager(dbProvider, userInfo);
                returnValue = manager.AddEntity(entity);
            });
            return returnValue;
        }
        #endregion

        #region public int UpdateAttachment(UserInfo userInfo, AttachmentEntity entity) 更新任务附件
        /// <summary>
        /// 更新任务附件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateAttachment(UserInfo userInfo, AttachmentEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AttachmentManager(dbProvider, userInfo);
                returnValue = manager.UpdateEntity(entity);
            });
            return returnValue;
        }
        #endregion

        #region  public DataTable GetAttachmentTable(UserInfo userInfo, string id) 依据主键获得附件列表
        /// <summary>
        /// 依据主键获得附件列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>任务附件列表</returns>
        public DataTable GetAttachmentTable(UserInfo userInfo, string id)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(AttachmentTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AttachmentManager(dbProvider, userInfo);
                dataTable = manager.GetDT(AttachmentTable.FieldId, id, AttachmentTable.FieldDeleteMark, 0);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetAttachmentByValues(UserInfo userInfo, string[] names, string[] values) 根据条件获得附件列表
        /// <summary>
        /// 根据条件获得附件列表
	    /// </summary>
	    /// <param name="userInfo">用户</param>
	    /// <param name="names">字段</param>
	    /// <param name="values">值</param>
	    /// <returns>数据表</returns>
	    public DataTable GetAttachmentByValues(UserInfo userInfo, string[] names, string[] values)
		{
			var dataTable = new DataTable(AttachmentTable.TableName);
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);

            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new AttachmentManager(dbProvider, userInfo).GetDT(names, values);
                dataTable.TableName = AttachmentTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public int DeleteAttachment(UserInfo userInfo, string auserId) 根据主键删除附件记录
        /// <summary>
        /// 根据主键删除附件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>大于0成功</returns>
        public int DeleteAttachment(UserInfo userInfo, string id)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AttachmentManager(dbProvider, userInfo);
                returnValue = manager.Delete(id);
            });
            return returnValue;
        }
        #endregion
    }
}
