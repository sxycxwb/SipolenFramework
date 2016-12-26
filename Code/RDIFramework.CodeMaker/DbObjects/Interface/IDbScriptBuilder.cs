using System.Collections.Generic;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// IDbScriptBuilder 的摘要说明。
	/// </summary>
	public interface IDbScriptBuilder
	{
		#region 属性
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
		string DbConnectStr
		{
			get;
			set;
		}

        /// <summary>
        /// 数据库名称
        /// </summary>
		string DbName
		{
			get;
			set;
		}

        /// <summary>
        /// 表名称
        /// </summary>
		string TableName
		{
			get;
			set;
		}
        	

        /// <summary>
        /// 存储过程前缀
        /// </summary>
        string ProcPrefix
        {
            set;
            get;
        }  
     
        /// <summary>
        /// 项目名称
        /// </summary>
        string ProjectName
        {
            set;
            get;
        }
        /// <summary>
        /// 选择的字段集合
        /// </summary>
        List<ColumnInfo> Fieldlist
        {
            set;
            get;
        }
        /// <summary>
        /// 选择的字段集合字符串
        /// </summary>
        string Fields
        {
            get;
        }
        /// <summary>
        /// 主键或条件字段
        /// </summary>
        List<ColumnInfo> Keys
        {
            set;
            get;
        }
		#endregion	

		#region 生成数据库表创建脚本
        /// <summary>
        /// 生成数据库所有表的创建脚本
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        string CreateDBTabScript(string dbName);
		
        /// <summary>
        /// 生成数据库表创建脚本
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">表名称</param>
        /// <returns>数据库表创建脚本</returns>
		string CreateTabScript(string dbName,string tableName);

        /// <summary>
        /// 根据SQL查询结果 生成数据创建脚本
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="strSql">Sql语句</param>
        /// <returns>数据创建脚本</returns>
        string CreateTabScriptBySQL(string dbName, string strSql);

        /// <summary>
        /// 生成数据库表创建脚本到文件
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">表名称</param>
        /// <param name="filename">文件名</param>
        /// <param name="progressBar">进度条</param>
		void CreateTabScript(string dbName,string tableName,string filename,System.Windows.Forms.ProgressBar progressBar);
        		
		#endregion

		#region 创建存储过程

		string CreatPROCGetMaxID();

        string CreatPROCIsHas();

		string CreatPROCADD();

		string CreatPROCUpdate();

        string CreatPROCDelete();

        string CreatPROCGetEntity();

		string CreatPROCGetList();
		
		/// <summary>
		/// 得到某个表的存储过程（选择生成的方法）
		/// </summary>
		/// <param name="Maxid"></param>
		/// <param name="Ishas"></param>
		/// <param name="Add"></param>
		/// <param name="Update"></param>
		/// <param name="Delete"></param>
        /// <param name="GetEntity"></param>
		/// <param name="List"></param>
		/// <param name="dtColumn">表的所有列信息</param>
		/// <returns></returns>
        string GetPROCCode(bool Maxid, bool Ishas, bool Add, bool Update, bool Delete, bool GetEntity, bool List);
		
		/// <summary>
		/// 得到某个表的存储过程
		/// </summary>
		/// <param name="dbName">库名</param>
		/// <param name="tableName">表名</param>
		/// <returns></returns>
		string GetPROCCode(string dbName,string tableName);
		/// <summary>
		/// 得到一个库下所有表的存储过程
		/// </summary>
		/// <param name="DbName"></param>
		/// <returns></returns>
		string GetPROCCode(string dbName);
		#endregion

        #region 生成SQL查询语句

        /// <summary>
        /// 生成Select查询语句
        /// </summary>
        /// <param name="dbName">库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        string GetSQLSelect(string dbName, string tableName);
       

        /// <summary>
        /// 生成update查询语句
        /// </summary>
        /// <param name="dbName">库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        string GetSQLUpdate(string dbName, string tableName);
        
        /// <summary>
        /// 生成update查询语句
        /// </summary>
        /// <param name="dbName">库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        string GetSQLDelete(string dbName, string tableName);

        /// <summary>
        /// 生成INSERT查询语句
        /// </summary>
        /// <param name="dbName">库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        string GetSQLInsert(string dbName, string tableName);

        /// <summary>
        /// 生成数据库对象Drop语句
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="dbObjectName">数据库对象名称</param>
        /// <param name="dbobjType">数据库对象类型（表、视图、存储过程、函数等）</param>
        /// <returns></returns>
        string GetSqlDrop(string dbName, string dbObjectName,DBObjectType dbobjType);
        #endregion
	}
}
