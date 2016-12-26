
namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public partial class DBCodeMaker
    {
        /// <summary>
        /// 生成实体
        /// </summary>
        /// <param name="outputDirectory">输出目录</param>
        /// <param name="overwrite">覆盖</param>
        /// <param name="twoTier">分层目录</param>
        /// <returns></returns>
        public bool BuilderEntity(string outputDirectory, bool overwrite, bool twoTier = true)
        {
            this.postfix = "Entity";
            string fileName = outputDirectory + "\\" + this.project + ".BizLogic\\" + (!twoTier ? this.project + ".Entity" : this.className) + "\\" + this.className + "Entity.cs";
            fileName = outputDirectory + "\\" + this.project + ".BizLogic\\Entity\\" + this.className + "Entity.cs";

            string code = this.BuilderEntity();
            return WriteCode(fileName, overwrite, code);
        }

        public string BuilderEntity()
        {
            this.GetCodeCopyright();
            this.GetCodeUsing();
            this.GetCodeNamespace("Model");
            this.GetCodeRemark();
            this.GetCodeClassName();
            this.GetCodeEntityColumn(this.GetColumnInfo(this.TableName));
            this.GetCodeEntity();
            this.GetCodeEntityForDataRow(this.TableName);
            //this.GetCodeEntityForDataReader(this.TableName);
            this.GetCodeEnd();

            return this.CodeText.ToString();
        }

        private void GetCodeEntity()
        {
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "()");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            /*
            //V3.0开始取消下面的方法
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataRow\">数据行</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(DataRow dataRow)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetFrom(dataRow);");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataReader\">数据流</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(IDataReader dataReader)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetFrom(dataReader);");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataTable\">数据表</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(DataTable dataTable)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetSingle(dataTable);");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据表读取");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataTable\">数据表</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + " GetSingle(DataTable dataTable)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            if ((dataTable == null) || (dataTable.Rows.Count == 0))");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                return null;");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            foreach (DataRow dataRow in dataTable.Rows)");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                this.GetFrom(dataRow);");
            this.CodeText.AppendLine("                break;");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            return this;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据表读取返回实体列表");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataTable\">数据表</param>");
            this.CodeText.AppendLine("        public List<" + this.className + this.postfix + ">  GetList(DataTable dataTable)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            List<" + this.className + this.postfix + "> entities=new List<" + this.className + this.postfix + ">();");
            this.CodeText.AppendLine("            foreach(DataRow dataRow in dataTable.Rows)");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                " + this.className + this.postfix + " entity = new " + this.className + this.postfix + "().GetFrom(dataRow);");
            this.CodeText.AppendLine("                entities.Add(entity);");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            return entities;");
            this.CodeText.AppendLine("        }");
            */
        }

        private void GetCodeEntityForDataRow(string tableName)
        {
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据行读取");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataRow\">数据行</param>");
            //this.CodeText.AppendLine("        public " + this.className + this.postfix + " GetFrom(DataRow dataRow)");
            this.CodeText.AppendLine("        protected override BaseEntity GetFrom(IDataRow dataRow)");
            this.CodeText.AppendLine("        {");
            //this.CodeText.AppendLine("            this.GetFromExpand(dataRow);");

            string tableClassName = this.className + "Table";

            foreach (ColumnInfo column in this.GetColumnInfo(tableName))
            {
                string field = column.ColumnName;
                string fieldDataType = column.TypeName;
                string convertFunction = string.Empty;
                // 关键字转换
                this.IsKeywords(ref field);
                convertFunction = GetConvertFunction(fieldDataType);
                this.CodeText.AppendLine("            this." + field + " = BusinessLogic.Convert" + convertFunction + "(dataRow[" + tableClassName + ".Field" + field + "]);");
            }
            
            this.CodeText.AppendLine("            return this;");
            this.CodeText.AppendLine("        }");
        }

        private void GetCodeEntityForDataReader(string tableName)
        {
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据流读取");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataReader\">数据流</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + " GetFrom(IDataReader dataReader)");
            this.CodeText.AppendLine("        {");
            //this.CodeText.AppendLine("            this.GetFromExpand(dataReader);;");

            string tableClassName = this.className + "Table";


            foreach (ColumnInfo column in this.GetColumnInfo(tableName))
            {
                string field = column.ColumnName;
                string fieldDataType = column.TypeName;
                string convertFunction = string.Empty;
                // 关键字转换
                this.IsKeywords(ref field);
                convertFunction = GetConvertFunction(fieldDataType);
                this.CodeText.AppendLine("            this." + field + " = BusinessLogic.Convert" + convertFunction + "(dataReader[" + tableClassName + ".Field" + field + "]);");
            }

            this.CodeText.AppendLine("            return this;");
            this.CodeText.AppendLine("        }");
        }
    }
}
