
namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public partial class DBCodeMaker
    {      
        public string DBSQL()
        {
            bool isKeyword = false;
            this.CodeText.AppendLine(" USE [RDIFrameworkV3.0]");
            //this.CodeText.AppendLine(" -- 数据权限主表里插入表数据");
            //this.CodeText.AppendLine(" DELETE FROM PITABLEPERMISSIONSCOPE WHERE (ItemCode = \'" + this.TableName + "\');");
            //this.CodeText.AppendLine(" INSERT INTO PITABLEPERMISSIONSCOPE(ItemCode, ItemName, ItemValue) VALUES (" + "\'" + this.TableName + "\', \'" + this.description + "\', \'" + this.tableName + "\');");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 先删除重复的数据");
            this.CodeText.AppendLine(" DELETE FROM CITABLECOLUMNS WHERE (TABLECODE = '" + this.TableName + "'); ");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 插入字段说明数据");
            int index = 1;
            foreach (ColumnInfo column in this.GetColumnInfo(TableName))
            {
                string field = column.ColumnName;
                string dataType = GetDataType(column.TypeName);
                string fieldDescription = column.ColDescription;
                string commandText = " INSERT INTO CITABLECOLUMNS (TABLECODE, COLUMNCODE, COLUMNNAME, USECONSTRAINT, DATATYPE, ENABLED , SORTCODE) VALUES (" + "\'" + this.TableName + "\', \'" + field + "\', \'" + fieldDescription + "\', ";
                commandText += isKeyword ? "0" : "1";
                commandText += ", \'" + dataType + "\', ";
                commandText += isKeyword ? "0" : "1";
                commandText += ", " + (index).ToString() + ");";
                index++;
                this.CodeText.AppendLine(commandText);
            }
            this.CodeText.AppendLine("");
            return this.CodeText.ToString();
        }        
    }
}
