using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDIFramework.CodeMaker
{
    public class CodeOptions
    {
        public IDbObject dbObj { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string dbName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// 实体类命名空间后缀
        /// </summary>
        public string ModelSuffix { get; set; }

        /// <summary>
        /// 实体类名
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// 数据层类名称
        /// </summary>
        public string DalName { get; set; }

        /// <summary>
        /// 数据类命名空间后缀
        /// </summary>
        public string DalSuffix { get; set; }

        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string Floder { get; set; }

        /// <summary>
        /// 后台处理数据路径
        /// </summary>
        public string AshxPath { get; set; }

        /// <summary>
        /// 中文字段
        /// </summary>
        public Dictionary<string, string> CHS { get; set; }

        /// <summary>
        /// 列表标题
        /// </summary>
        public Dictionary<string, string> HeadTitles { get; set; }

        /// <summary>
        /// 查询字段
        /// </summary>
        public Dictionary<string, string> Searchfield { get; set; }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StrConv(string str)
        {
            var sb = new StringBuilder(str);
            char cc = Char.ToUpper(sb[0]);
            sb.Replace(str[0], cc, 0, 1);
            return sb.ToString();
        }

        public string GetCName(string columnname)
        {
            return this.CHS[columnname];
        }

        public List<ColumnInfo> GetColumnInfo()
        {
            return dbObj.GetColumnInfoList(this.dbName, tableName);
        }
    }
}
