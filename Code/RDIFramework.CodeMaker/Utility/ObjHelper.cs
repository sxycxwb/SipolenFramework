
namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 对象接口创建辅助类
    /// </summary>
    class ObjHelper
    {
        public ObjHelper()
        {
        }

        //创建数据库信息类接口
        public static IDbObject CreatDbObj(string longservername)
        {
            DbSettings dbset = DbConfig.GetSetting(longservername);
            IDbObject dbobj = DBOMaker.CreateDbObj(dbset.DbType);
            dbobj.DbConnectStr = dbset.ConnectStr;
            return dbobj;
        }

        //创建脚本接口
        public static IDbScriptBuilder CreatDsb(string longservername)
        {
            DbSettings dbset = DbConfig.GetSetting(longservername);
            IDbScriptBuilder dsb = DBOMaker.CreateScript(dbset.DbType);
            dsb.DbConnectStr = dbset.ConnectStr;
            return dsb;
        }

        /*
        //创建代码生成类接口
        public static CodeBuild.CodeBuilders CreatCB(string longservername)
        {
            //DbSettings dbset = DbConfig.GetSetting(longservername);
            CodeBuild.CodeBuilders cb = newCodeBuild.CodeBuilders(CreatDbObj(longservername));// LTP.CodeBuild.CodeBuilders(dbset.DbType);
            //cb.DbConnectStr = dbset.ConnectStr;
            return cb;
        }
        */
    }
}
