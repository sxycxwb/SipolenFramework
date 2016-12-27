using System;
using System.Xml;
using System.Text;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    ///	CodeGenerator
    /// 主键生成器
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.13 版本：1.0    XuWangBin 整理。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2011.10.13</date>
    /// </author> 
    /// </summary>
    public partial class PDMCodeMaker
    {
        public string TableToHTML()
        {
            // this.GetCodeCopyright();
            XmlNode xmlNode = this.GetXmlNode(tableName);
            // 获取主键
            // this.GetPrimaryKey(xmlNode);
            return this.TableToHTML(xmlNode);           
        }

        public string TableToHTML(XmlNode xmlNode)
        {
            StringBuilder htmlBody = new StringBuilder();

            #region 产生文档，写入标题
            htmlBody.Append("<div class=\"styledb\">数据库名：" + this.GetPDMName() + "</div>");
            string tabletitle = "表名：" + this.tableName + "（" + this.description + "）";
            #endregion

            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (!((XmlNode) xmlNode.ChildNodes[i]).LocalName.Equals("Columns")) continue;

                //htmlBody.Append("<div class=\"styletab\">" + tabletitle + "</div>");
                htmlBody.Append("<div>" + tabletitle + "</div>");
                htmlBody.Append("<div><table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");
                //网页风格
                htmlBody.Append("<tr><td bgcolor=\"#FBFBFB\">");
                htmlBody.Append("<table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
                htmlBody.Append("<tr bgcolor=\"#F0F0F0\">");

                htmlBody.Append("<td>序号</td>");
                htmlBody.Append("<td>列代码</td>");
                htmlBody.Append("<td>列名称</td>");
                htmlBody.Append("<td>数据类型</td>");
                htmlBody.Append("<td>长度</td>");
                htmlBody.Append("<td>小数位</td>");
                htmlBody.Append("<td>标识</td>");
                htmlBody.Append("<td>主键</td>");
                htmlBody.Append("<td>允许空</td>");
                htmlBody.Append("<td>默认值</td>");
                htmlBody.Append("<td>描述</td>");
                htmlBody.Append("</tr>");

                #region 循环每一个列，产生一行数据
                for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                {
                    string field = "&nbsp;";
                    string fieldDescription = "&nbsp;";
                    string fieldDataType = "&nbsp;";
                    string fieldName = "&nbsp;";
                    string fieldDefaultValue = "&nbsp;";
                    string fieldLength = "&nbsp;";
                    string fieldPrecision = "&nbsp;";
                    string fieldIdentity = "N";
                    string fieldMandatory = "Y";

                    for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                    {
                        string xmlValue = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                        xmlValue = xmlValue == "" ? "&nbsp;" : xmlValue;
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Identity"))
                        {
                            fieldIdentity = xmlValue == "1" ? "Y" : "N";
                        }

                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                        {
                            field = xmlValue == "" ? "&nbsp;" : xmlValue;
                        }

                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Comment"))
                        {
                            fieldDescription = xmlValue == "" ? "&nbsp;" : xmlValue;
                        }
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DataType"))
                        {                              
                            fieldDataType = xmlValue == "" ? "&nbsp;" : xmlValue;
                        }
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Name"))
                        {
                            fieldName = xmlValue == "" ? "&nbsp;" : xmlValue; 
                        }

                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DefaultValue"))
                        {
                            fieldDefaultValue = xmlValue == "" ? "&nbsp;" : xmlValue;
                        }
                            
                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Length"))
                        {
                            fieldLength = xmlValue == "" ? "&nbsp;" : xmlValue;
                        }

                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Precision"))
                        {
                            fieldPrecision = xmlValue == "" ? "&nbsp;" : xmlValue;
                        }

                        if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Mandatory"))
                        {
                            fieldMandatory = xmlValue == "1"  ? "N" : "Y";
                            if (string.IsNullOrEmpty(xmlValue))
                            {
                                fieldMandatory = "Y";
                            }                               
                        }
                    }
                    if (String.IsNullOrEmpty(fieldDescription))
                    {
                        fieldDescription = fieldName;
                    } 
                        
             
                    htmlBody.Append("<tr>");
                    htmlBody.Append("<td>" + (j + 1).ToString() + "</td>");
                    htmlBody.Append("<td>" + field + "</td>");
                    htmlBody.Append("<td>" + fieldName + "</td>");
                    htmlBody.Append("<td>" + fieldDataType + "</td>");
                    htmlBody.Append("<td>" + fieldLength + "</td>");
                    htmlBody.Append("<td>" + fieldPrecision + "</td>");
                    htmlBody.Append("<td>" + fieldIdentity + "</td>");
                    htmlBody.Append("<td>" + fieldIdentity + "</td>");
                    htmlBody.Append("<td>" + fieldMandatory + "</td>");
                    htmlBody.Append("<td>" + fieldDefaultValue + "</td>");
                    htmlBody.Append("<td>" + fieldDescription + "</td>");
                    htmlBody.Append("</tr>");
                }

                htmlBody.Append("</table>");
                htmlBody.Append("</td>");
                htmlBody.Append("</tr>");
                htmlBody.Append("</table>");
                htmlBody.Append("</div>");
                #endregion                  
                break;
            }

            return htmlBody.ToString();
        }
    }
}