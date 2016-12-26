//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonLibary
    /// 通用基类
    /// 
    /// 修改纪录
    ///     2015-11-12 版本：3.0   EricHu  新增MySql数据库递归得到当前节点的所有子节点方法：GetMySqlChildrensId
    ///     2015-06-08 版本：3.0   WoodyLi 修正GetParentChildrensByCode中参数重复问题。
    ///		2012.02.05 版本：1.0   EricHu 分离程序。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.05</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonLibary
    {
        //
        // 树型结构的算法
        //

        #region public static DataTable GetParentsByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetParentsByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order, bool idOnly)
        {
            string sqlQuery = string.Empty;
            sqlQuery = idOnly ? "   SELECT " + BusinessLogic.FieldId : "   SELECT * ";
            sqlQuery += "     FROM " + tableName;
            switch (dbProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlQuery += "    WHERE (LEFT(" + dbProvider.GetParameter(fieldCode) + ", LEN(" + fieldCode + ")) = " + fieldCode + ") ";
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery += "    WHERE (SUBSTR(" + dbProvider.GetParameter(fieldCode) + ", 1, LENGTH(" + fieldCode + ")) = " + fieldCode + ") ";
                    break;
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = fieldCode;
            values[0] = code;
            DataTable dataTable = new DataTable(tableName);
            dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public static DataTable GetChildrens(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId, string order, bool idOnly) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrens(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId, string order, bool idOnly)
        {
            string sqlQuery = string.Empty;
            DataTable dataTable = new DataTable(tableName);
            switch (dbProvider.CurrentDbType)
            {
                case CurrentDbType.Oracle:
                    {
                        sqlQuery = idOnly ? "   SELECT " + fieldId : "   SELECT * ";
                        sqlQuery += "          FROM " + tableName
                                 + "    START WITH " + fieldId + " = " + dbProvider.GetParameter(fieldId)
                                 + "  CONNECT BY PRIOR " + fieldId + " = " + fieldParentId;
                        if (!String.IsNullOrEmpty(order))
                        {
                            sqlQuery += " ORDER BY " + order;
                        }
                        string[] names = new string[1];
                        names[0] = fieldId;
                        Object[] values = new Object[1];
                        values[0] = id;
                        dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(names, values));
                    }
                    break;
                case CurrentDbType.SqlServer:                
                    {
                        sqlQuery = " WITH Tree AS (SELECT " + (idOnly ? BusinessLogic.FieldId : " *");
                        sqlQuery += "       FROM " + tableName
                                 + "       WHERE " + BusinessLogic.FieldId + " IN ('" + id + "') "
                                 + "       UNION ALL "
                                 + "      SELECT " + (idOnly ? "ResourceTree." + BusinessLogic.FieldId : "ResourceTree.*")
                                 + "        FROM " + tableName + " AS ResourceTree INNER JOIN "
                                 + "             Tree AS A ON A." + fieldId + " = ResourceTree." + fieldParentId + ") "
                                 + " SELECT * "
                                 + "   FROM Tree ";
                        dbProvider.Fill(dataTable, sqlQuery);
                    }
                    break;
            }
            return dataTable;
        }
        #endregion

        #region public static DataTable GetChildrens(IDbProvider dbProvider, string tableName, string fieldId, string[] ids, string fieldParentId, string order, bool idOnly) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="ids">主键数组</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrens(IDbProvider dbProvider, string tableName, string fieldId, string[] ids, string fieldParentId, string order, bool idOnly)
        {
            string sqlQuery = string.Empty;
            sqlQuery = idOnly ? "   SELECT " + fieldId : "   SELECT * ";
            sqlQuery += "          FROM " + tableName
                     + "    START WITH " + fieldId + " IN (" + BusinessLogic.ObjectsToList(ids) + ")"
                     + "  CONNECT BY PRIOR " + fieldId + " = " + fieldParentId;
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            return dbProvider.Fill(sqlQuery);
        }
        #endregion

        #region private static DataTable GetChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order, bool idOnly) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        private static DataTable GetChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order, bool idOnly)
        {
            string sqlQuery = string.Empty;
            sqlQuery = idOnly ? "   SELECT " + BusinessLogic.FieldId : "   SELECT * ";
            sqlQuery += "     FROM " + tableName;
            switch (dbProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlQuery += "    WHERE (LEFT(" + fieldCode + ", LEN(" + dbProvider.GetParameter(fieldCode) + ")) = " + dbProvider.GetParameter(fieldCode) + " ) ";
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery += "    WHERE (SUBSTR(" + fieldCode + ", 1, LENGTH(" + dbProvider.GetParameter(fieldCode) + ")) = " + dbProvider.GetParameter(fieldCode) + " ) ";
                    break;
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            string[] names = new string[1];
            names[0] = fieldCode;
            //names[1] = fieldCode;
            Object[] values = new Object[1];
            values[0] = code;
            //values[1] = code;
            DataTable dataTable = new DataTable(tableName);
            dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region private static DataTable GetParentChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order, bool idOnly) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <param name="idOnly">只需要主键</param>
        /// <returns>数据表</returns>
        private static DataTable GetParentChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order, bool idOnly)
        {
            string sqlQuery = string.Empty;
            sqlQuery = idOnly ? "   SELECT " + BusinessLogic.FieldId : "   SELECT * ";
            sqlQuery += "     FROM " + tableName;
            switch (dbProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlQuery += "    WHERE (LEFT(" + fieldCode + ", LEN(" + dbProvider.GetParameter(fieldCode) + ")) = " + dbProvider.GetParameter(fieldCode) + ") ";
                    sqlQuery += "          OR (LEFT(" + dbProvider.GetParameter(fieldCode) + ", LEN(" + fieldCode + ")) = " + fieldCode + ") ";
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery += "    WHERE (SUBSTR(" + fieldCode + ", 1, LENGTH(" + dbProvider.GetParameter(fieldCode) + ")) = " + dbProvider.GetParameter(fieldCode) + ") ";
                    sqlQuery += "          OR (" + fieldCode + " = SUBSTR(" + dbProvider.GetParameter(fieldCode) + ", 1, LENGTH(" + fieldCode + "))) ";
                    break;
            }
            if (!String.IsNullOrEmpty(order))
            {
                sqlQuery += " ORDER BY " + order;
            }
            var names = new string[1];
            names[0] = fieldCode;
           
            var values = new Object[1];
            values[0] = code;
           
            DataTable dataTable = new DataTable("RDIFramework");
            dbProvider.Fill(dataTable, sqlQuery, dbProvider.MakeParameters(names, values));
            return dataTable;
        }
        #endregion


        #region public static DataTable GetParentsByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetParentsByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order)
        {
            return GetParentsByCode(dbProvider, tableName, fieldCode, code, order, false);
        }
        #endregion

        #region public static DataTable GetChildrens(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrens(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId, string order)
        {
            return GetChildrens(dbProvider, tableName, fieldId, id, fieldParentId, order, false);
        }
        #endregion

        #region public static DataTable GetChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order)
        {
            return GetChildrensByCode(dbProvider, tableName, fieldCode, code, order, false);
        }
        #endregion

        #region public static DataTable GetParentChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public static DataTable GetParentChildrensByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order)
        {
            return GetParentChildrensByCode(dbProvider, tableName, fieldCode, code, order, false);
        }
        #endregion


        #region public static string[] GetParentsIDByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取父节点列表
        /// <summary>
        /// 获取父节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetParentsIDByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order)
        {
            return BusinessLogic.FieldToArray(GetParentsByCode(dbProvider, tableName, fieldCode, code, order, true), BusinessLogic.FieldId);
        }
        #endregion

        #region public static string[] GetChildrensId(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetChildrensId(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId, string order)
        {
            if (dbProvider.CurrentDbType == CurrentDbType.MySql)
            {
                //MySql数据库递归得到当前节点的所有子节点
                return GetMySqlChildrensId(dbProvider, tableName, fieldId, id, fieldParentId);
            }
            else
            {
                return BusinessLogic.FieldToArray(GetChildrens(dbProvider, tableName, fieldId, id, fieldParentId, order, true), BusinessLogic.FieldId);
            }
        }
        #endregion

        /// <summary>
        /// MySql数据库递归得到当前节点的所有子节点
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">值</param>
        /// <param name="fieldParentId">父亲节点字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetMySqlChildrensId(IDbProvider dbProvider, string tableName, string fieldId, string id, string fieldParentId) 
        {
            string returnValue = "$";
            while (id != null)
            {
                returnValue = returnValue + "," + id;
                //SELECT GROUP_CONCAT(ID) FROM PIORGANIZE WHERE FIND_IN_SET(PARENTID,'8AB28234-0382-466F-A651-2E7F621997E3') > 0
                string sqlQuery = "SELECT GROUP_CONCAT(" + fieldId + ") FROM " 
                                + tableName 
                                + " WHERE FIND_IN_SET(" 
                                + fieldParentId + ",'" + id + "') > 0";
                id = BusinessLogic.ConvertToString(dbProvider.ExecuteScalar(sqlQuery));
            }
            return returnValue.Replace("$,", "").Split(',');
        }

        #region public static string[] GetChildrensByIDCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取子节点列表
        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetChildrensIdByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order)
        {
            return BusinessLogic.FieldToArray(GetChildrensByCode(dbProvider, tableName, fieldCode, code, order, true), BusinessLogic.FieldId);
        }
        #endregion

        #region public static string[] GetParentChildrensIdByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order) 获取父子节点列表
        /// <summary>
        /// 获取父子节点列表
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编码</param>
        /// <param name="order">排序</param>
        /// <returns>主键数组</returns>
        public static string[] GetParentChildrensIdByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code, string order)
        {
            return BusinessLogic.FieldToArray(GetParentChildrensByCode(dbProvider, tableName, fieldCode, code, order, true), BusinessLogic.FieldId);
        }
        #endregion


        #region public static string GetParentIdByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code) 获取父节点
        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="tableName">目标表名</param>
        /// <param name="fieldCode">编码字段</param>
        /// <param name="code">编号</param>
        /// <returns>主键</returns>
        public static string GetParentIdByCode(IDbProvider dbProvider, string tableName, string fieldCode, string code)
        {
            string parentId = string.Empty;
            string sqlQuery = " SELECT MAX(Id) AS Id "
                            + "    FROM " + tableName
                            + "  WHERE (LEFT(" + dbProvider.GetParameter(fieldCode) + ", LEN(" + fieldCode + ")) = " + fieldCode + ") "
                            + "    AND " + fieldCode + " <>  '" + code + " ' ";
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = fieldCode;
            values[0] = code;
            object returnObject = dbProvider.ExecuteScalar(sqlQuery, dbProvider.MakeParameters(names, values));
            if (returnObject != null)
            {
                parentId = returnObject.ToString();
            }
            return parentId;
        }
        #endregion
    }
}