using System.Text;

namespace RDIFramework.CodeMaker
{
    public partial class DBCodeWebUIMaker
    {
        public string primaryKey = "ID";
        /// <summary>
        /// 主键字段
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                // 对主键进行规范化
                if (!string.IsNullOrEmpty(primaryKey))
                {
                    if (primaryKey.Equals("ID"))
                    {
                        primaryKey = "ID";
                    }
                }
                return primaryKey;
            }
            set
            {
                primaryKey = value;
            }
        }

        /// <summary>
        /// 当前表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 当前数据库名称
        /// </summary>
        public string DBName { get; set; }

        /// <summary>
        /// 实体类名
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 数据库访问接口
        /// </summary>
        private IDbObject dbObject = null;
        private StringBuilder CodeText = new StringBuilder();

        public DBCodeWebUIMaker(IDbObject dbAccess, string databaseName, string tabName)
        {
            this.dbObject = dbAccess;
            this.DBName = databaseName;
            this.TableName = tabName;
        }

        public DBCodeWebUIMaker(IDbObject dbAccess, string databaseName, string tableName, string modelName, string nameSpace)
            : this(dbAccess, databaseName, tableName)
        {
            this.ModelName = modelName;
            this.NameSpace = nameSpace;
        }
    }
}
