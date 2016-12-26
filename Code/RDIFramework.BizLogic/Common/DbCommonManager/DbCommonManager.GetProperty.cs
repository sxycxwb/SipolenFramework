//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonManager
    /// 通用基类部分
    /// 
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.0 EricHu 进行提炼，把代码进行分组。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonManager
    {
        #region public virtual string GetCodeById(string id) 获取编码
        /// <summary>
        /// 获取编码
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>编号</returns>
        public virtual string GetCodeById(string id)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, id, BusinessLogic.FieldCode);
        }
        #endregion

        #region public virtual string GetIdByCode(string code) 获取主键
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns>主键</returns>
        public virtual string GetIdByCode(string code)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldCode, code, BusinessLogic.FieldId);
        }
        #endregion

        #region public virtual string GetFullNameByCode(string code) 获取名称
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns>名称</returns>
        public virtual string GetFullNameByCode(string code)
        {
            return this.GetProperty(BusinessLogic.FieldCode, code, BusinessLogic.FieldFullName);
        }
        #endregion

        #region public virtual string GetFullNameById(string id) 获取名称
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>名称</returns>
        public virtual string GetFullNameById(string id)
        {
            return this.GetProperty(BusinessLogic.FieldId, id, BusinessLogic.FieldFullName);
        }
        #endregion

        #region public virtual string GetParentId(string id) 获取父级主键
        /// <summary>
        /// 获取父节点主键
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>父级主键</returns>
        public virtual string GetParentId(string id)
        {
            return this.GetProperty(BusinessLogic.FieldId, id, BusinessLogic.FieldParentId);
        }
        #endregion

        #region public virtual string GetParentIdByCode(string code) 获取父节点主键
        /// <summary>
        /// 获取父节点主键
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns>父级主键</returns>
        public virtual string GetParentIdByCode(string code)
        {
            return this.GetProperty(BusinessLogic.FieldCode, code, BusinessLogic.FieldParentId);
        }
        #endregion

        #region public string GetParentIdByCategory(string categoryId, string code) 获取父节点主键
        /// <summary>
        /// 获取父节点主键
        /// </summary>
        /// <param name="categoryId">分类主键</param>
        /// <param name="code">主键</param>
        /// <returns>父级主键</returns>
        public virtual string GetParentIdByCategory(string categoryId, string code)
        {
            return this.GetProperty(BusinessLogic.FieldCategoryId, categoryId, BusinessLogic.FieldCode, code, BusinessLogic.FieldParentId);
        }
        #endregion

        #region public virtual string GetFullNameByCategory(string categoryId, string code) 获取名称
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="categoryId">类别主键</param>
        /// <param name="code">编码</param>
        /// <returns>名称</returns>
        public virtual string GetFullNameByCategory(string categoryId, string code)
        {
            return this.GetProperty(BusinessLogic.FieldCategoryId, categoryId, BusinessLogic.FieldCode, code, BusinessLogic.FieldFullName);
        }
        #endregion

        //
        // 读取属性
        //
        //public virtual string GetProperty(object id, string targetField)
        //{
        //    return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, id, targetField);
        //}

        public virtual string GetProperty(string name, object value, string targetField)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, name, value, targetField);
        }

        public virtual string GetProperty(string name1, object value1, string name2, object value2, string targetField)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, name1, value1, name2, value2, targetField);
        }

        public virtual string GetProperty(string[] names, object[] values, string targetField)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, names, values, targetField);
        }

        public virtual string GetProperty(object id, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(BusinessLogic.FieldId, id)
            };
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetProperty(KeyValuePair<string, object> parameter, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetProperty(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetProperty(List<KeyValuePair<string, object>> parameters, string targetField)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, targetField);
        }


        public virtual string GetId(KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, BusinessLogic.FieldId);
        }

        public virtual string GetId(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                parameter1,
                parameter2
            };
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, BusinessLogic.FieldId);
        }

        public virtual string GetId(List<KeyValuePair<string, object>> parameters)
        {
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameters, BusinessLogic.FieldId);
        }

        public virtual string GetId(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parameterList = parameters.ToList();
            return DbCommonLibary.GetProperty(DBProvider, this.CurrentTableName, parameterList, BusinessLogic.FieldId);
        }
    }
}