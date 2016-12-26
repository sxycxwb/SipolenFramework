using System;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public partial class DBCodeMaker
    {
        public bool BuilderTable(string outputDirectory, bool overwrite, bool twoTier = true)
        {
            this.postfix = "Table";
            string fileName = outputDirectory + "\\" + this.project + ".BizLogic\\" + (!twoTier ? this.project + ".Model" : this.className) + "\\" + this.className + "Table.cs";
            fileName = outputDirectory + "\\" + this.project + ".BizLogic\\Entity\\" + this.className + "Table.cs";
            string code = this.BuilderTable();
            return WriteCode(fileName, overwrite, code);
        }

        public string BuilderTable()
        {
            this.GetCodeCopyright();
            this.GetCodeUsing(true);
            this.GetCodeNamespace("Model", true);
            this.GetCodeRemark();
            this.GetCodeClassName();
            this.GetCodeTableColumn(this.TableName);
            this.GetCodeEnd();
            return this.CodeText.ToString();
        }

        private void GetCodeTableColumn(string tableName)
        {
            this.CodeText.AppendLine("        ///<summary>");
            this.CodeText.AppendLine("        /// " + this.description);
            this.CodeText.AppendLine("        ///</summary>");
            this.CodeText.AppendLine("        [NonSerialized]");
            this.CodeText.AppendLine("        public static string TableName = \"" + tableName + "\";");
            foreach (ColumnInfo column in this.GetColumnInfo(tableName))
            {
                string field = column.ColumnName;
                string fieldName = column.ColumnName;
                string fieldDescription = column.ColDescription;
                if (String.IsNullOrEmpty(fieldDescription))
                {
                    fieldDescription = fieldName;
                }
                // 首字母进行强制大写改进
                string fieldKey = field.Substring(0, 1).ToUpper() + field.Substring(1);
                this.CodeText.AppendLine(string.Empty);
                this.CodeText.AppendLine("        ///<summary>");
                this.CodeText.AppendLine("        /// " + fieldDescription);
                this.CodeText.AppendLine("        ///</summary>");
                this.CodeText.AppendLine("        [NonSerialized]");
                this.CodeText.AppendLine("        public static string Field" + fieldKey + " = \"" + field + "\";");
            }
        }
    }
}
