using System;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
    /// <summary>
    /// DbCommonManager
    /// 通用基类部分
    /// 
    /// </summary>
    public partial class DbCommonManager
    {
        #region public virtual int SetDeleted() 删除标志当前用户的全部便笺
        /// <summary>
        /// 删除标志当前用户的全部便笺
        /// </summary>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted()
        {
            return this.SetProperty(BusinessLogic.FieldCreateUserId, UserInfo.Id, BusinessLogic.FieldDeleteMark, "1");
        }
        #endregion

        #region public virtual int SetDeleted(object id) 删除标志
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(object id)
        {
            return this.SetProperty(BusinessLogic.FieldId, id, BusinessLogic.FieldDeleteMark, "1");
        }
        #endregion

        #region public virtual int SetDeleted(object[] ids) 批量删除标志
        /// <summary>
        /// 批量删除标志
        /// </summary>
        /// <param name="ids">便笺主键数组</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(object[] ids)
        {
            return this.SetProperty(BusinessLogic.FieldId, ids, BusinessLogic.FieldDeleteMark, "1");
        }
        #endregion

        #region public virtual int SetDeleted(string[] names, object[] values) 批量删除标志
        /// <summary>
        /// 批量删除标志
        /// </summary>
        /// <param name="ids">便笺主键数组</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(string[] names, object[] values)
        {
            return this.SetProperty(names, values, BusinessLogic.FieldDeleteMark, "1");
        }
        #endregion

        #region public virtual int SetDeleted(object id, bool enabled = false, bool modifiedUser = false) 删除标志
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="enabled">有效</param>
        /// <param name="modifiedUser">修改者</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(object id, bool enabled = false, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(BusinessLogic.FieldDeleteMark, 1)
            };
            if (enabled)
            {
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldEnabled, 0));
            }
            if (modifiedUser && this.UserInfo != null)
            {
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldModifiedUserId, this.UserInfo.Id));
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldModifiedOn, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            return this.SetProperty(new KeyValuePair<string, object>(BusinessLogic.FieldId, id), parameters);
        }
        #endregion

        #region public virtual int SetDeleted(object[] ids, bool enabled = false, bool modifiedUser = false) 批量删除标志
        /// <summary>
        /// 批量删除标志
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="enabled">有效</param>
        /// <param name="modifiedUser">修改者</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(object[] ids, bool enabled = false, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(BusinessLogic.FieldDeleteMark, 1)
            };
            if (enabled)
            {
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldEnabled, 0));
            }
            if (modifiedUser && this.UserInfo != null)
            {
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldModifiedUserId, this.UserInfo.Id));
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldModifiedOn, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            return this.SetProperty(ids, parameters);
        }
        #endregion

        #region public virtual int SetDeleted(params KeyValuePair<string, object>[] parameters) 删除标志
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <param name="parameters">更新字段，值</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return this.SetProperty(parametersList, new KeyValuePair<string, object>(BusinessLogic.FieldDeleteMark, 1));
        }
        #endregion

        #region public virtual int SetDeleted(List<KeyValuePair<string, object>> whereParameters, bool modifiedUser = false) 批量删除标志
        /// <summary>
        /// 批量删除标志
        /// </summary>
        /// <param name="whereParameters">条件字段，值</param>
        /// <param name="modifiedUser"></param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(List<KeyValuePair<string, object>> whereParameters, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(BusinessLogic.FieldDeleteMark, 1)
            };
            if (modifiedUser && this.UserInfo != null)
            {
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldModifiedUserId, this.UserInfo.Id));
                parameters.Add(new KeyValuePair<string, object>(BusinessLogic.FieldModifiedOn, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            return this.SetProperty(whereParameters, parameters);
        }
        #endregion
    }
}
