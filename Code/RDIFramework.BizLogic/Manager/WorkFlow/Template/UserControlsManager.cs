using System;
using System.Data;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// UserControlsManager
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
    public partial class UserControlsManager
    {
        /// <summary>
        /// 新增子表单
        /// </summary>
        /// <param name="entity">子表单实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertUserControl(UserControlsEntity entity)
        {
            string returnString = string.Empty;
            if (entity.Id.Trim().Length == 0 || entity.Id == null)
                throw new Exception("InsertUserControl方法错误，Id 不能为空！");
            if (entity.FullName.Trim().Length == 0 || entity.FullName == null)
                throw new Exception("InsertUserControl方法错误，FullName 不能为空！");
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
        /// 修改一个子表单
        /// </summary>
        /// <param name="entity">子表单实体</param>
        /// <returns>大于0操作成功</returns>
        public int UpdateUserControl(UserControlsEntity entity)
        {
            int returnInt = -1;
            if (entity.Id.Trim().Length == 0 || entity.Id == null)
                throw new Exception("UpdateUserControl方法错误，Id 不能为空！");
            if (entity.FullName.Trim().Length == 0 || entity.FullName == null)
                throw new Exception("InsertUserControl方法错误，FullName 不能为空！");
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
        /// 删除一个子表单
        /// </summary>
        /// <param name="Id">子表单主键</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteUserControl(string Id)
        {
            int returnInt = -1;
            if (Id.Trim().Length == 0 || Id == null)
                throw new Exception("DeleteUserControl方法错误，Id 不能为空！");
            try
            {
                returnInt = this.Delete(UserControlsTable.FieldId, Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnInt;
        }

        /// <summary>
        /// 删除子表单隶属的组关系
        /// </summary>
        /// <param name="userControlId">子表单主键</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteMainCtrlsOfUser(string userControlId)
        {
            if (userControlId.Trim().Length == 0 || userControlId == null)
                throw new Exception("DeleteMainCtrlsOfUser方法错误，userControlId 不能为空！");
            try
            {
                string sqlStr = string.Format("DELETE FROM USERCONTROLSLINK WHERE USERCONTROLID= {0}", DBProvider.GetParameter(UserControlsLinkTable.FieldUserControlId));
                return this.ExecuteNonQuery(sqlStr, new IDbDataParameter[] { DBProvider.MakeParameter(UserControlsLinkTable.FieldUserControlId, userControlId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得所有子表单
        /// </summary>
        /// <returns>子表单列表</returns>
        public DataTable GetAllChildUserControls()
        {
            try
            {
                return this.GetDT(UserControlsTable.FieldDeleteMark,0,UserControlsTable.FieldFullName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得指定子表单
        /// </summary>
        /// <param name="id">子表单主键</param>
        /// <returns>子表单列表</returns>
        public DataTable GetChildUserControl(string id)
        {
            try
            {
                return this.GetDT(UserControlsTable.FieldId, id,UserControlsTable.FieldDeleteMark,0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得子表单隶属的主表单
        /// </summary>
        /// <param name="userControlId">子表单id</param>
        /// <returns>子表单隶属的主表单列表</returns>
        public DataTable GetMainCtrlsOfChild(string userControlId)
        {
            try
            {
                string tmpStr = string.Format("SELECT * FROM USERCONTROLSVIEW WHERE USERCONTROLID={0} ORDER BY FULLNAME", DBProvider.GetParameter(UserControlsLinkTable.FieldUserControlId));
                return this.Fill(tmpStr, new IDbDataParameter[] { DBProvider.MakeParameter(UserControlsLinkTable.FieldUserControlId, userControlId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
