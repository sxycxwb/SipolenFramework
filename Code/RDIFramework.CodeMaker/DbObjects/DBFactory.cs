using System;
using System.Reflection;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 数据库信息类实例工厂,利用反射动态创建对象。
    /// </summary>
    public class DBOMaker
    {
        private static Cache cache = new Cache();      

        #region 不同程序集反射

        private static object CreateObject(string path, string TypeName)
        {
            object obj = cache.GetObject(TypeName);
            if (obj != null) return obj;
            try
            {
                obj = Assembly.Load(path).CreateInstance(TypeName);
                cache.SaveCache(TypeName, obj);// 写入缓存
            }
            catch (System.Exception ex)
            {
                string str = ex.Message;// 记录错误日志
            }
            return obj;
        }

        /// <summary>
        /// 创建数据库信息类接口
        /// </summary>
        /// <param name="dbTypename">数据库类型名称</param>
        /// <returns></returns>
        public static IDbObject CreateDbObj(string dbTypename)
        {
            string typeName = "RDIFramework.CodeMaker.DbObject";
            //TypeName = dbTypename + ".DbObject";
            switch (dbTypename.ToLower())
            {
                case "sql2008":
                case "sql2005":
                case "sql2000":
                case "sqlserver":
                    typeName = "RDIFramework.CodeMaker.DbObjects.SqlServer.DbObject";
                    break;
                case "oracle":
                    typeName = "RDIFramework.CodeMaker.DbObjects.Oracle.DbObject";
                    break;
               
            }

            object objType = CreateObject("RDIFramework.CodeMaker", typeName);
            return (IDbObject)objType;
        }

        /// <summary>
        /// 创建数据库脚本生成类接口
        /// </summary>
        /// <param name="dbTypename"></param>
        /// <returns></returns>
        public static IDbScriptBuilder CreateScript(string dbTypename)
        {
            //RDIFramework.CodeMaker.DbObjects.Oracle

            string typeName = "RDIFramework.CodeMaker.DbObject";
            //TypeName = dbTypename + ".DbObject";
            switch (dbTypename.ToLower())
            {
                case "sql2008":
                case "sql2005":
                case "sql2000":
                case "sqlserver":
                    typeName = "RDIFramework.CodeMaker.DbObjects.SqlServer.DbScriptBuilder";
                    break;
                case "oracle":
                    typeName = "RDIFramework.CodeMaker.DbObjects.Oracle.DbScriptBuilder";
                    break;
            }
            //string TypeName = dbTypename + ".DbScriptBuilder";
            //TypeName = "RDIFramework.CodeMaker.DbScriptBuilder";

            object objType = CreateObject("RDIFramework.CodeMaker", typeName);
            return (IDbScriptBuilder)objType;
        }

        #endregion
    }

    /// <summary>
    /// 数据库对象类型
    /// </summary>
    public enum DBObjectType
    { 
        TABLE,
        VIEW,
        PROCEDURE,
        FUNCTION,
        USER
    }
}
