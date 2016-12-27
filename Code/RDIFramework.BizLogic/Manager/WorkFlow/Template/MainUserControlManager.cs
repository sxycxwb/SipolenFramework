using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// MainUserControlManager
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class MainUserControlManager
    { 
        /// <summary>
        /// 增加主表单
        /// </summary>
        /// <param name="entity">主表单实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertMainUserCtrl(MainUserControlEntity entity)
        {
            string returnString = string.Empty;
            if (entity.Id.Trim().Length == 0 || entity.Id == null)
                throw new Exception("InsertMainUserCtrl方法错误，Id 不能为空！");

            try
            {
                returnString = this.AddEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnString;
        }

        /// <summary>
        /// 修改一个主表单
        /// </summary>
        /// <param name="entity">主表单实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateMainUserCtrl(MainUserControlEntity entity)
        {
            int returnInt = -1;
            if (entity.Id.Trim().Length == 0 || entity.Id == null)
                throw new Exception("UpdateMainUserCtrl方法错误，Id 不能为空！");

            try
            {
                returnInt = this.UpdateEntity(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnInt;
        }

        /// <summary>
        /// 获得一个主表单
        /// </summary>
        /// <param name="Id">主表单主键</param>
        /// <returns>主表单表</returns>
        public DataTable GetMainUserControl(string Id)
        {
            try
            {
                string tmpStr = string.Format("SELECT * FROM MAINUSERCONTROL WHERE DELETEMARK = 0 AND ID= {0}", DBProvider.GetParameter(MainUserControlTable.FieldId));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter(MainUserControlTable.FieldId, Id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据表单名称获得一个主表单
        /// </summary>
        /// <param name="fullName">表单名称</param>
        /// <returns>主表单列表</returns>
        public DataTable GetMainUserControlByCaption(string fullName)
        {
            try
            {
                string tmpStr = string.Format("SELECT * FROM MAINUSERCONTROL WHERE DELETEMARK = 0 AND FULLNAME LIKE {0}", DBProvider.GetParameter(MainUserControlTable.FieldFullName));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter(MainUserControlTable.FieldFullName, "%" + fullName + "%") });              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除主表单
        /// </summary>
        /// <param name="id">主表单Id</param>
        /// <returns></returns>
        public int DeleteMainUserCtrl(string id)
        {
            int returnInt = -1;
            try
            {
                string sqlStr = string.Format("DELETE MAINUSERCONTROL WHERE ID={0}", DBProvider.GetParameter(MainUserControlTable.FieldId));
                returnInt = this.ExecuteNonQuery(sqlStr, new IDbDataParameter[] { DBProvider.MakeParameter(MainUserControlTable.FieldId, id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnInt;
        }

        /// <summary>
        /// 获得主表单的所有子表单列表
        /// </summary>
        /// <param name="mainUserCtrlId">主表单Id</param>
        /// <returns>子表单列表</returns>
        public DataTable GetAllChildUserControlsById(string mainUserCtrlId)
        {
            try
            {
                string tmpStr = string.Format("SELECT * FROM USERCONTROLSVIEW WHERE  MAINUSERCONTROLID= {0} order by CONTROLORDER", DBProvider.GetParameter("MAINUSERCONTROLID"));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter("MAINUSERCONTROLID", mainUserCtrlId) });     
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得所有主表单
        /// </summary>
        /// <returns>主表单列表</returns>
        public DataTable GetAllMainUserControls()
        {
            try
            {
                const string tmpStr = "SELECT * FROM MAINUSERCONTROL WHERE DELETEMARK = 0 ORDER BY FULLNAME";
                return this.Fill(tmpStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        /// <summary>
        /// 增加子表单
        /// </summary>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <param name="controlOrder">顺序号,以此排序</param>
        /// <param name="controlState">子表单状态</param>
        /// <returns>增加成功返回主键</returns>
        public string AddUserControls(string mainUserCtrlId, string userContrlsId, int controlOrder, string controlState)
        {
            string returnStr = string.Empty;
            try
            {
                var mananger = new UserControlsLinkManager(DBProvider);
                if (controlOrder < 0)
                {
                    object oOrder = mananger.ExecuteScalar(string.Format("SELECT MAX(CONTROLORDER) FROM USERCONTROLSLINK WHERE MAINUSERCONTROLID = {0}" , DBProvider.GetParameter("MAINUSERCONTROLID")), new IDbDataParameter[] { DBProvider.MakeParameter("MAINUSERCONTROLID", mainUserCtrlId)});
                    if (oOrder != null && MathHelper.IsInteger(oOrder.ToString()))
                    {
                        controlOrder = int.Parse(oOrder.ToString()) + 1;
                    }
                }
                var linkEntity = new UserControlsLinkEntity
                {
                    MainUserControlId = mainUserCtrlId,
                    UserControlId = userContrlsId,
                    ControlOrder = controlOrder,
                    ControlState = controlState
                };
                returnStr = mananger.AddEntity(linkEntity);             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnStr;
        }

        /// <summary>
        /// 移除子表单
        /// </summary>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <returns>大于0成功</returns>
        public int MoveUserControls(string mainUserCtrlId, string userContrlsId)
        {
            int returnInt = -1;
            try
            {
                var pairs = new List<KeyValuePair<string,object>>
                {
                    new KeyValuePair<string, object>(UserControlsLinkTable.FieldMainUserControlId, mainUserCtrlId),
                    new KeyValuePair<string, object>(UserControlsLinkTable.FieldUserControlId, userContrlsId)
                };
                returnInt = new UserControlsLinkManager(DBProvider).Delete(pairs);           
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnInt;
        }

        /// <summary>
        /// 修改主表单下指定子表单的状态
        /// </summary>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">子表单id</param>
        /// <param name="controlState">状态</param>
        /// <returns>大于0成功</returns>
        public int EditMainUserControlsState(string mainUserCtrlId, string userContrlsId, string controlState = "查看")
        {
            int returnInt = -1;
            try
            {
                var wherePar = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(UserControlsLinkTable.FieldMainUserControlId, mainUserCtrlId),
                    new KeyValuePair<string, object>(UserControlsLinkTable.FieldUserControlId, userContrlsId)
                };

                var valuePar = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(UserControlsLinkTable.FieldControlState, controlState),
                };

                returnInt = new UserControlsLinkManager(DBProvider).SetProperty(wherePar, valuePar);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnInt;
        }

        /// <summary>
        /// 移除所有子表单
        /// </summary>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <remarks>大于0成功</remarks>
        public int MoveUserControlsOfMain(string mainUserCtrlId)
        {
            int returnInt = -1;
            try
            {
                returnInt = new UserControlsLinkManager(DBProvider).Delete(UserControlsLinkTable.FieldMainUserControlId, mainUserCtrlId); ;    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnInt;
        }

        /// <summary>
        /// 得到工作流所有的工作任务表单
        /// </summary>
        /// <param name="workFlowId">工作流主键</param>
        /// <returns>工作任务表单列表</returns>
        public DataTable GetWorkFlowAllControlsLink(string workFlowId)
        {
            try
            {
                string tmpStr = string.Format("SELECT DISTINCT UL.* FROM USERCONTROLSLINK UL LEFT JOIN WORKTASKCONTROLS WC ON WC.USERCONTROLID=UL.MAINUSERCONTROLID  WHERE WC.WORKFLOWID={0}", DBProvider.GetParameter("WORKFLOWID"));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter("WORKFLOWID", workFlowId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定工作流所有的主表单
        /// </summary>
        /// <param name="workFlowId">工作流主键</param>
        /// <returns>工作流所有的主表单列表</returns>
        public DataTable GetWorkFlowAllMainControls(string workFlowId)
        {
            try
            {
                string tmpStr = string.Format("SELECT DISTINCT MC.* FROM USERCONTROLSLINK UL LEFT JOIN WORKTASKCONTROLS WC ON WC.USERCONTROLID=UL.MAINUSERCONTROLID  LEFT JOIN MAINUSERCONTROL MC ON MC.ID=WC.USERCONTROLID " 
                    + " WHERE WC.WORKFLOWID={0}", DBProvider.GetParameter("WORKFLOWID"));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter("WORKFLOWID", workFlowId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定流程所有的子表单列表
        /// </summary>
        /// <param name="workFlowId">工作流模版主键</param>
        /// <returns>表单列表</returns>
        public DataTable GetWorkFlowAllControls(string workFlowId)
        {
            try
            {
                string tmpStr = string.Format("SELECT DISTINCT CL.* FROM USERCONTROLSLINK UL LEFT JOIN WORKTASKCONTROLS WC ON WC.USERCONTROLID=UL.MAINUSERCONTROLID " 
                    + " LEFT JOIN USERCONTROLS CL ON UL.USERCONTROLID=CL.ID " 
                    + " WHERE WC.WORKFLOWID= {0}", DBProvider.GetParameter("WORKFLOWID"));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter("WORKFLOWID", workFlowId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否存在指定工作任务表单
        /// </summary>
        /// <param name="taskControlId">工作流程Id</param>
        /// <returns>true存在</returns>
        public bool ExistsTaskControls(string taskControlId)
        {
            return new WorkTaskControlsManager(this.DBProvider).Exists(WorkTaskControlsTable.FieldTaskControlId,taskControlId);   
        }

        /// <summary>
        /// 是否存在指定主表单
        /// </summary>
        /// <param name="Id">主表单Id</param>
        /// <returns>true存在</returns>
        public bool ExistsMainControls(string Id)
        {
            return this.Exists(MainUserControlTable.FieldId, Id);           
        }

        /// <summary>
        /// 是否存在指定用户表单
        /// </summary>
        /// <param name="userCtrlId">用户表单id</param>
        /// <returns>true存在</returns>
        public bool ExistsUserControls(string userCtrlId)
        {
            return new UserControlsManager(this.DBProvider).Exists(UserControlsTable.FieldId, userCtrlId);
        }

        /// <summary>
        /// 是否存在指定主子表单关联
        /// </summary>
        /// <param name="ctrlLinkId">关联Id</param>
        /// <returns>true存在</returns>
        public bool ExistsControlsLink(string ctrlLinkId)
        {
            return new UserControlsLinkManager(this.DBProvider).Exists(UserControlsLinkTable.FieldId, ctrlLinkId);        
        }
    }
}
