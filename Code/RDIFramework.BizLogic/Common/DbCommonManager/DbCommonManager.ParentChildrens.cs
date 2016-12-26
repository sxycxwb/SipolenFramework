//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace RDIFramework.BizLogic
{

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
        //
        // 树型结构的算法，递归算法
        //

        #region public DataTable GetParentsByCode(string fieldCode, string code, string order) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetParentsByCode(string fieldCode, string code, string order)
        {
            return DbCommonLibary.GetParentsByCode(DBProvider, this.CurrentTableName, fieldCode, code, order);
        }
        #endregion

        #region public DataTable GetChildrens(string fieldId, string id, string fieldParentId, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public DataTable GetChildrens(string fieldId, string id, string fieldParentId, string order, bool idOnly = true)
        {
            return DbCommonLibary.GetChildrens(DBProvider, this.CurrentTableName, fieldId, id, fieldParentId, order,idOnly);
        }
        #endregion


        #region public DataTable GetChildrensByCode(string fieldCode, string code, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetChildrensByCode(string fieldCode, string code, string order)
        {
            return DbCommonLibary.GetChildrensByCode(DBProvider, this.CurrentTableName, fieldCode, code, order);
        }
        #endregion

        #region public DataTable GetParentChildrensByCode(string fieldCode, string code, string order) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetParentChildrensByCode(string fieldCode, string code, string order)
        {
            return DbCommonLibary.GetParentChildrensByCode(DBProvider, this.CurrentTableName, fieldCode, code, order);
        }
        #endregion


        #region public string[] GetParentsIdByCode(string fieldCode, string code) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <returns>主键数组</returns>
        public string[] GetParentsIdByCode(string fieldCode, string code)
        {
            return DbCommonLibary.GetParentsIDByCode(DBProvider, this.CurrentTableName, fieldCode, code, string.Empty);
        }
        #endregion

        #region public string[] GetChildrensId(string fieldId, string id, string fieldParentId) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <returns>主键数组</returns>
        public string[] GetChildrensId(string fieldId, string id, string fieldParentId)
        {
            return DbCommonLibary.GetChildrensId(DBProvider, this.CurrentTableName, fieldId, id, fieldParentId, string.Empty);
        }
        #endregion

        #region public string[] GetMySqlChildrensId(string fieldId, string id, string fieldParentId) 获取MySql子节点列表
        /// <summary>
        /// 获取MySql子节点列表
        /// </summary>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <returns>主键数组</returns>
        public string[] GetMySqlChildrensId(string fieldId, string id, string fieldParentId)
        {
            return DbCommonLibary.GetMySqlChildrensId(DBProvider, this.CurrentTableName, fieldId, id, fieldParentId);
        }
        #endregion

        #region public string[] GetChildrensByIdCode(string fieldCode, string code) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <returns>主键数组</returns>
        public string[] GetChildrensIdByCode(string fieldCode, string code)
        {
            return DbCommonLibary.GetChildrensIdByCode(DBProvider, this.CurrentTableName, fieldCode, code, string.Empty);
        }
        #endregion

        #region public string[] GetParentChildrensIdByCode(string fieldCode, string code) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <returns>主键数组</returns>
        public string[] GetParentChildrensIdByCode(string fieldCode, string code)
        {
            return DbCommonLibary.GetParentChildrensIdByCode(DBProvider, this.CurrentTableName, fieldCode, code, string.Empty);
        }
        #endregion

        #region public string GetParentIdByCode(string fieldCode, string code) 获取父节点
        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编号</param>
        /// <returns>主键</returns>
        public string GetParentIdByCode(string fieldCode, string code)
        {
            return DbCommonLibary.GetParentIdByCode(DBProvider, this.CurrentTableName, fieldCode, code);
        }
        #endregion
    }
}