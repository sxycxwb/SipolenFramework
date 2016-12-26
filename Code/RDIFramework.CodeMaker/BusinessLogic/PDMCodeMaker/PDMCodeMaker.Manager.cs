
using System;
using System.Xml;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    ///	CodeGenerator
    /// 主键生成器
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.13 版本：1.0    EricHu 整理。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2011.10.13</date>
    /// </author> 
    /// </summary>
    public partial class PDMCodeMaker
    {
        public bool BuilderManager(string outputDirectory, bool overwrite, string dataBase = null, bool twoTier=true)
        {
            this.postfix = "Manager";
            string fileName = outputDirectory + "\\" + this.project + ".BizLogic\\" +
                              (!twoTier ? this.project + ".Manager\\Manager.Generate\\" : this.className + "\\") +
                              this.className + "Manager.Generate.cs";

            fileName = outputDirectory + "\\" + this.project + ".BizLogic\\Manager\\Generate\\" + this.className + "Manager.Generate.cs";
            string code = this.BuilderManager(dataBase);
            return WriteCode(fileName, overwrite, code);
        }

        public string BuilderManager(string currentDB = null)
        {
            this.GetCodeCopyright();
            this.GetCodeUsing();
            this.GetCodeNamespace("Manager");
            this.GetCodeRemark();
            this.GetCodeClassName();
            XmlNode xmlNode = this.GetXmlNode(tableName);
            // 获取主键
            this.GetPrimaryKey(xmlNode);
            this.GetCodeClassManager(xmlNode, currentDB);
            // this.GetTableColumns(xmlNode);
            this.GetCodeEnd();
            return this.CodeText.ToString();
        }

        private void GetCodeClassManager(XmlNode xmlNode, string currentDB = null)
        {
            bool sortCode = false;
            sortCode = this.ColumnsExists(xmlNode, "SortCode");

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "()");
            this.CodeText.AppendLine("        {");
            if (!string.IsNullOrEmpty(currentDB))
            {
                this.CodeText.AppendLine("            if (base.dbHelper == null)");
                this.CodeText.AppendLine("            {");
                this.CodeText.AppendLine("                base.dbHelper = DBProviderFactory.GetHelper(SystemInfo." + currentDB + "Type, SystemInfo." + currentDB + "Connection);");
                this.CodeText.AppendLine("            }");
            }
            this.CodeText.AppendLine("            base.CurrentTableName = " + this.className + "Table.TableName;");
            // 获取主键
            this.GetPrimaryKey(xmlNode);
            this.CodeText.AppendLine("            base.PrimaryKey = \"" + this.PrimaryKey + "\";");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// <param name=\"tableName\">指定表名</param>");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(string tableName)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            base.CurrentTableName = tableName;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dbProvider\">数据库连接</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(IDbProvider dbProvider): this()");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            DBProvider = dbProvider;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"userInfo\">用户信息</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(UserInfo userInfo) : this()");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            UserInfo = userInfo;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dbProvider\">数据库连接</param>");
            this.CodeText.AppendLine("        /// <param name=\"userInfo\">用户信息</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            UserInfo = userInfo;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dbProvider\">数据库连接</param>");
            this.CodeText.AppendLine("        /// <param name=\"userInfo\">用户信息</param>");
            this.CodeText.AppendLine("        /// <param name=\"tableName\">指定表名</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            base.CurrentTableName = tableName;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 添加");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"" + this.ClassEntity + "\">实体</param>");
            this.CodeText.AppendLine("        /// <returns>主键</returns>");
            this.CodeText.AppendLine("        public string Add(" + this.className + "Entity " + this.ClassEntity + ")");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            return this.AddEntity(" + this.ClassEntity + ");");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 添加");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"" + this.ClassEntity + "\">实体</param>");
            this.CodeText.AppendLine("        /// <param name=\"identity\">自增量方式</param>");
            this.CodeText.AppendLine("        /// <param name=\"returnId\">返回主键</param>");
            this.CodeText.AppendLine("        /// <returns>主键</returns>");
            this.CodeText.AppendLine("        public string Add(" + this.className + "Entity " + this.ClassEntity + ", bool identity, bool returnId)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.Identity = identity;");
            this.CodeText.AppendLine("            this.ReturnId = returnId;");
            this.CodeText.AppendLine("            return this.AddEntity(" + this.ClassEntity + ");");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 更新");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"" + this.ClassEntity + "\">实体</param>");
            this.CodeText.AppendLine("        public int Update(" + this.className + "Entity " + this.ClassEntity + ")");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            return this.UpdateEntity(" + this.ClassEntity + ");");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 获取实体");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"id\">主键</param>");

            // 是否采用了自增量方式？
            bool identity = false;
            if (this.ColumnsExists(xmlNode, this.PrimaryKey))
            {
                string pk = GetColumnDataType(xmlNode, this.PrimaryKey);
                identity = pk.ToUpper().Equals("INT")
                    || pk.ToUpper().Equals("INTEGER")
                    || pk.ToUpper().Equals("LONG")
                    || GetColumnDataType(xmlNode, this.PrimaryKey).Equals("int?");
            }
            if (identity)
            {
                this.CodeText.AppendLine("        public " + this.className + "Entity GetEntity(string id)");
                this.CodeText.AppendLine("        {");
                this.CodeText.AppendLine("            return GetEntity(int.Parse(id));");
                this.CodeText.AppendLine("        }");
                this.CodeText.AppendLine(string.Empty);

                this.CodeText.AppendLine("        public " + this.className + "Entity GetEntity(int id)");
            }
            else
            {
                this.CodeText.AppendLine("        public " + this.className + "Entity GetEntity(string id)");
            }
            this.CodeText.AppendLine("        {");
            /*
            this.CodeText.AppendLine("            " + this.className + "Entity " + this.ClassEntity + " = new " + this.className + "Entity(this.GetDT(new KeyValuePair<string, object>(" + this.className + "Table.Field" + this.PrimaryKey + ", id)));");
            this.CodeText.AppendLine("            return " + this.ClassEntity + ";");
             */
            this.CodeText.AppendLine("            return BaseEntity.Create<" + this.className + "Entity>(this.GetDT(" + this.className + "Table.Field" + this.PrimaryKey + ", id))");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 添加实体");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"" + this.ClassEntity + "\">实体</param>");
            this.CodeText.AppendLine("        public string AddEntity(" + this.className + "Entity " + this.ClassEntity + ")");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            string sequence = string.Empty;");

            /*
            if (this.Identity && this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle))
            {
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                sequence = sequenceManager.GetSequence(UserByIntTable.TableName);
                userByIntEntity.UserId = int.Parse(sequence);
            }
            */

            // 这里判断是否为自增量模式
            if (!identity)
            {
                // 字符串的主键不会是自增量
                // this.CodeText.AppendLine("  if (" + this.ClassEntity + "." + this.PrimaryKey + " is string)");
                // this.CodeText.AppendLine("  { ");
                this.CodeText.AppendLine("            this.Identity = false; ");
                // this.CodeText.AppendLine("  } ");
            }

            if (sortCode)
            {
                this.CodeText.AppendLine("            if (" + this.ClassEntity + ".SortCode == null || " + this.ClassEntity + ".SortCode == 0)");
                this.CodeText.AppendLine("            {");
                this.CodeText.AppendLine("                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);");
                this.CodeText.AppendLine("                sequence = sequenceManager.GetSequence(this.CurrentTableName);");
                this.CodeText.AppendLine("                " + this.ClassEntity + ".SortCode = int.Parse(sequence);");
                this.CodeText.AppendLine("            }");
            }

            if (!identity)
            {
                this.CodeText.AppendLine("            if (" + this.ClassEntity + "." + this.PrimaryKey + " != null)");
                this.CodeText.AppendLine("            {");
                this.CodeText.AppendLine("                sequence = " + this.ClassEntity + "." + this.PrimaryKey + ".ToString();");
                this.CodeText.AppendLine("            }");
            }

            this.CodeText.AppendLine("            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);");
            this.CodeText.AppendLine("            sqlBuilder.BeginInsert(this.CurrentTableName, " + this.className + "Table.Field" + this.PrimaryKey + ");");

            this.CodeText.AppendLine("            if (!this.Identity) ");
            this.CodeText.AppendLine("            {");

            if (!identity)
            {
                this.CodeText.AppendLine("                if (string.IsNullOrEmpty(" + this.ClassEntity + "." + this.PrimaryKey + ")) ");
                this.CodeText.AppendLine("                { ");
                this.CodeText.AppendLine("                    sequence = BusinessLogic.NewGuid(); ");
                this.CodeText.AppendLine("                    " + this.ClassEntity + "." + this.PrimaryKey + " = sequence ;");
                this.CodeText.AppendLine("                }");
            }

            this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.Field" + this.PrimaryKey + ", " + this.ClassEntity + "." + this.PrimaryKey + ");");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            else");
            this.CodeText.AppendLine("            {");

            this.CodeText.AppendLine("                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))");
            this.CodeText.AppendLine("                {");
            this.CodeText.AppendLine("                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)");
            this.CodeText.AppendLine("                    {");
            this.CodeText.AppendLine("                        sqlBuilder.SetFormula(" + this.className + "Table.Field" + this.PrimaryKey + ", \"SEQ_\" + this.CurrentTableName.ToUpper() + \".NEXTVAL \");");
            this.CodeText.AppendLine("                    }");
            this.CodeText.AppendLine("                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)");
            this.CodeText.AppendLine("                    {");
            this.CodeText.AppendLine("                        sqlBuilder.SetFormula(" + this.className + "Table.Field" + this.PrimaryKey + ", \"NEXT VALUE FOR SEQ_\" + this.CurrentTableName.ToUpper());");
            this.CodeText.AppendLine("                    }");
            this.CodeText.AppendLine("                }");
            this.CodeText.AppendLine("                else");
            this.CodeText.AppendLine("                {");
            this.CodeText.AppendLine("                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))");
            this.CodeText.AppendLine("                    {");

            // 这里是若没主键，先生成主键的方法
            if (identity)
            {
                // 这里是数值型的
                this.CodeText.AppendLine("                        if (" + this.ClassEntity + "." + this.PrimaryKey + " == null)");
            }
            else
            {
                this.CodeText.AppendLine("                        if (string.IsNullOrEmpty(" + this.ClassEntity + "." + this.PrimaryKey + "))");
            }
            this.CodeText.AppendLine("                        {");
            this.CodeText.AppendLine("                            if (string.IsNullOrEmpty(sequence))");
            this.CodeText.AppendLine("                            {");
            this.CodeText.AppendLine("                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);");
            this.CodeText.AppendLine("                                sequence = sequenceManager.GetSequence(this.CurrentTableName);");
            this.CodeText.AppendLine("                            }");
            if (identity)
            {
                // 这里是数值型的
                this.CodeText.AppendLine("                            " + this.ClassEntity + "." + this.PrimaryKey + " = int.Parse(sequence);");
            }
            else
            {
                this.CodeText.AppendLine("                            " + this.ClassEntity + "." + this.PrimaryKey + " = sequence;");
            }
            this.CodeText.AppendLine("                        }");

            this.CodeText.AppendLine("                        sqlBuilder.SetValue(" + this.className + "Table.Field" + this.PrimaryKey + ", " + this.ClassEntity + "." + this.PrimaryKey + ");");
            this.CodeText.AppendLine("                    }");
            this.CodeText.AppendLine("                }");

            this.CodeText.AppendLine("            }");

            this.CodeText.AppendLine("            this.SetEntity(sqlBuilder, " + this.ClassEntity + ");");

            bool createUserId = false;
            createUserId = this.ColumnsExists(xmlNode, "CreateUserId");
            bool createBy = false;
            createBy = this.ColumnsExists(xmlNode, "CreateBy");
            bool createOn = false;
            createOn = this.ColumnsExists(xmlNode, "CreateOn");

            if (createUserId || createBy)
            {
                this.CodeText.AppendLine("            if (UserInfo != null) ");
                this.CodeText.AppendLine("            { ");
            }
            if (createUserId)
            {
                this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.FieldCreateUserId, UserInfo.Id);");
            }
            if (createBy)
            {
                this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.FieldCreateBy, UserInfo.RealName);");
            }
            if (createUserId || createBy)
            {
                this.CodeText.AppendLine("            } ");
            }
            if (createOn)
            {
                this.CodeText.AppendLine("            sqlBuilder.SetDBNow(" + this.className + "Table.FieldCreateOn);");
            }
            bool modifiedUserId = false;
            modifiedUserId = this.ColumnsExists(xmlNode, "ModifiedUserId");
            bool modifiedBy = false;
            modifiedBy = this.ColumnsExists(xmlNode, "ModifiedBy");
            bool modifiedOn = false;
            modifiedOn = this.ColumnsExists(xmlNode, "ModifiedOn");

            if (modifiedUserId || modifiedBy)
            {
                this.CodeText.AppendLine("            if (UserInfo != null) ");
                this.CodeText.AppendLine("            { ");
            }
            if (modifiedUserId)
            {
                this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.FieldModifiedUserId, UserInfo.Id);");
            }
            if (modifiedBy)
            {
                this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.FieldModifiedBy, UserInfo.RealName);");
            }
            if (modifiedUserId || modifiedBy)
            {
                this.CodeText.AppendLine("            } ");
            }
            if (modifiedOn)
            {
                this.CodeText.AppendLine("            sqlBuilder.SetDBNow(" + this.className + "Table.FieldModifiedOn);");
            }
            // 返回值处理
            this.CodeText.AppendLine("            if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                sequence = sqlBuilder.EndInsert().ToString();");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            else");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                sqlBuilder.EndInsert();");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            return sequence;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 更新实体");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"" + this.ClassEntity + "\">实体</param>");
            this.CodeText.AppendLine("        public int UpdateEntity(" + this.className + "Entity " + this.ClassEntity + ")");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);");
            this.CodeText.AppendLine("            sqlBuilder.BeginUpdate(this.CurrentTableName);");
            this.CodeText.AppendLine("            this.SetEntity(sqlBuilder, " + this.ClassEntity + ");");
            if (modifiedUserId || modifiedBy)
            {
                this.CodeText.AppendLine("            if (UserInfo != null) ");
                this.CodeText.AppendLine("            { ");
            }
            if (modifiedUserId)
            {
                this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.FieldModifiedUserId, UserInfo.Id);");
            }
            if (modifiedBy)
            {
                this.CodeText.AppendLine("                sqlBuilder.SetValue(" + this.className + "Table.FieldModifiedBy, UserInfo.RealName);");
            }
            if (modifiedUserId || modifiedBy)
            {
                this.CodeText.AppendLine("            } ");
            }
            if (modifiedOn)
            {
                this.CodeText.AppendLine("            sqlBuilder.SetDBNow(" + this.className + "Table.FieldModifiedOn);");
            }
            this.CodeText.AppendLine("            sqlBuilder.SetWhere(" + this.className + "Table.Field" + this.PrimaryKey + ", " + this.ClassEntity + "." + this.PrimaryKey + ");");
            this.CodeText.AppendLine("            return sqlBuilder.EndUpdate();");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            //this.CodeText.AppendLine("        // 这个是声明扩展方法");
            //this.CodeText.AppendLine("        partial void SetEntityExpand(SQLBuilder sqlBuilder, " + this.className + "Entity " + this.ClassEntity + ");");
            //this.CodeText.AppendLine("        ");

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 设置实体");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"sqlBuilder\">sql语句生成器</param>");
            this.CodeText.AppendLine("        /// <param name=\"" + this.ClassEntity + "\">实体</param>");
            this.CodeText.AppendLine("        private void SetEntity(SQLBuilder sqlBuilder, " + this.className + "Entity " + this.ClassEntity + ")");
            this.CodeText.AppendLine("        {");
            //this.CodeText.AppendLine("            SetEntityExpand(sqlBuilder, " + this.ClassEntity + ");");
            this.GetCodeEntityManager(xmlNode);
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 删除实体");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"id\">主键</param>");
            this.CodeText.AppendLine("        /// <returns>影响行数</returns>");
            if (identity)
            {
                this.CodeText.AppendLine("        public int Delete(int id)");
            }
            else
            {
                this.CodeText.AppendLine("        public int Delete(string id)");
            }
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            return this.Delete(new KeyValuePair<string, object>(" + this.className + "Table.Field" + this.PrimaryKey + ", id));");
            this.CodeText.AppendLine("        }");
        }
    }
}