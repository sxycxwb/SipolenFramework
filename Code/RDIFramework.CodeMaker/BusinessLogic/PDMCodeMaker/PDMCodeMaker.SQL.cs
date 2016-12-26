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
        public string DBSQL()
        {
            // this.GetCodeCopyright();
            XmlNode xmlNode = this.GetXmlNode(tableName);
            // 获取主键
            // this.GetPrimaryKey(xmlNode);
            this.DBSQL(xmlNode);
            return this.CodeText.ToString();
        }

        public void DBSQL(XmlNode xmlNode)
        {
            bool isKeyword = false;
            this.CodeText.AppendLine(" USE [RDIFrameworkV3.0]");
            //this.CodeText.AppendLine(" -- 数据权限主表里插入表数据");
            //this.CodeText.AppendLine(" DELETE FROM PITABLEPERMISSIONSCOPE WHERE (ItemCode = \'" + this.tableName + "\');");
            //this.CodeText.AppendLine(" INSERT INTO PITABLEPERMISSIONSCOPE(ItemCode, ItemName, ItemValue) VALUES (" + "\'" + this.tableName + "\', \'" + this.description + "\', \'" + this.tableName + "\');");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 先删除重复的数据");
            this.CodeText.AppendLine(" DELETE FROM CITABLECOLUMNS WHERE (TABLECODE = '" + this.tableName + "'); ");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 插入字段说明数据");
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (!((XmlNode) xmlNode.ChildNodes[i]).LocalName.Equals("Columns")) continue;
                for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                {
                    string field = string.Empty;
                    string fieldName = string.Empty;
                    string fieldDescription = string.Empty;
                    for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                    {
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Name"))
                        {
                            fieldName = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                        }
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                        {
                            field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            // 关键字转换
                            isKeyword = this.IsKeywords(ref field);
                        }
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Comment"))
                        {
                            fieldDescription = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                        }
                    }
                    if (String.IsNullOrEmpty(fieldDescription))
                    {
                        fieldDescription = fieldName;
                    }

                    string dataType = GetColumnDataType(xmlNode, field, true);

                    string commandText = " INSERT INTO CITABLECOLUMNS (TABLECODE, COLUMNCODE, COLUMNNAME, USECONSTRAINT, DATATYPE, ENABLED , SORTCODE) VALUES (" + "\'" + this.tableName + "\', \'" + field + "\', \'" + fieldDescription + "\', ";
                    commandText += isKeyword ? "0" : "1";
                    commandText += ", \'" + dataType + "\', ";
                    commandText += isKeyword ? "0" : "1";
                    commandText += ", " + (j+1).ToString() + ");";

                    this.CodeText.AppendLine(commandText);
                }
                break;
            }
            this.CodeText.AppendLine("");
        }
    }
}