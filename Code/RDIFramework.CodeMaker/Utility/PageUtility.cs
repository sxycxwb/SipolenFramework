using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RDIFramework.CodeMaker
{
    public class PageUtility
    {
        /// <summary> 
        /// 将SQLServer数据类型（如：varchar）转换为.Net类型（如：String） 
        /// </summary> 
        /// <param name="sqlTypeString">Sql server的数据类型</param> 
        /// <returns>相对应的C＃数据类型</returns> 
        public static string SqltoCsharpT(string sqlType)
        {
            string[] SqlTypeNames = new string[] { "int", "varchar","bit" ,"datetime","decimal","float","image","money",
            "ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
            "real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary"};

            string[] CSharpTypes = new string[] {"int", "string","bool" ,"DateTime","Decimal","Double","Byte[]","Single",
            "string","string","DateTime","Int16","string","Int64","Byte[]","string","string","Decimal",
            "Single","Single", "Object","Byte[]","Byte","Guid","Byte[]"};

            int i = Array.IndexOf(SqlTypeNames, sqlType.ToLower());
            return CSharpTypes[i];
        }

        /// <summary>
        /// 当前数据库管理器窗体
        /// </summary>
        public static DbView DbViewForm
        {
            get { return Application.OpenForms["DbView"] == null ? null : (DbView) Application.OpenForms["DbView"]; }
        }

        /// <summary>
        /// 得到当前数据库浏览器选中的服务器名称
        /// </summary>        
        public static string GetDbViewSelServer()
        {
            if (Application.OpenForms["DbView"] == null)
            {
                return "";
            }
            DbView dbviewfrm1 = (DbView)Application.OpenForms["DbView"];
            TreeNode SelNode = dbviewfrm1.treeView1.SelectedNode;
            if (SelNode == null)
                return "";
            string longservername = "";
            switch (SelNode.Tag.ToString())
            {
                case "serverlist":
                    return "";
                case "server":
                    {
                        longservername = SelNode.Text;
                    }
                    break;
                case "db":
                    {
                        longservername = SelNode.Parent.Text;
                    }
                    break;
                case "tableroot":
                case "viewroot":
                    {
                        longservername = SelNode.Parent.Parent.Text;
                    }
                    break;
                case "table":
                case "view":
                    {
                        longservername = SelNode.Parent.Parent.Parent.Text;
                    }
                    break;
                case "column":
                    longservername = SelNode.Parent.Parent.Parent.Parent.Text;
                    break;
            }

            return longservername;
        }

        #region 主界面tabpage控制
        /// <summary>
        /// 增加TabPage
        /// </summary>
        /// <param name="pageTitle">page页标题</param>
        /// <param name="ctrForm">窗体</param>
        /// <param name="mainfrm">主窗体</param>
        public static void AddTabPage(string pageTitle, Control ctrForm, MainForm mainfrm)
        {
            try
            {
                if (mainfrm.tabControlMain.Visible == false)
                {
                    mainfrm.tabControlMain.Visible = true;
                }
                Crownwood.Magic.Controls.TabPage page = new Crownwood.Magic.Controls.TabPage();
                page.Title = pageTitle;
                page.Control = ctrForm;
                mainfrm.tabControlMain.TabPages.Add(page);
                mainfrm.tabControlMain.SelectedTab = page;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        /// <summary>
        /// 创建新的唯一窗体页（不允许重复的）
        /// </summary>
        /// <param name="control">窗体</param>
        /// <param name="Title">page页标题</param>
        /// <param name="mainfrm">主窗体</param>
        public static void AddSinglePage(Control control, string Title, MainForm mainfrm)
        {
            try
            {
                if (mainfrm.tabControlMain.Visible == false)
                {
                    mainfrm.tabControlMain.Visible = true;
                }

                bool showed = false;
                Crownwood.Magic.Controls.TabPage currPage = null;

                foreach (Crownwood.Magic.Controls.TabPage page in mainfrm.tabControlMain.TabPages)
                {
                    if (page.Control.Name != control.Name) continue;
                    showed = true;
                    currPage = page;
                }
                if (!showed)//不存在
                {
                    AddTabPage(Title, control, mainfrm);
                }
                else
                {
                    mainfrm.tabControlMain.SelectedTab = currPage;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }
        #endregion

        public static string ClearHTMLTags(string HTML)
        {
            string[] Regexs ={
                        @"<[^>]+>",
                        @"<script[^>]*?>.*?</script>",
                        @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
                        @"([\r\n])[\s]+",
                        @"&(quot|#34);",
                        @"&(amp|#38);",
                        @"&(lt|#60);",
                        @"&(gt|#62);",
                        @"&(nbsp|#160);",
                        @"&(iexcl|#161);",
                        @"&(cent|#162);",
                        @"&(pound|#163);",
                        @"&(copy|#169);",
                        @"&#(\d+);",
                        @"-->",
                        @"<!--.*\n",
                        @"&lt;"
        };
            string[] Replaces ={
                            "",
                            "",
                            "",
                            "",
                            "\"",
                            "&",
                            "<",
                            ">",
                            " ",
                            "\xa1", //chr(161),
                            "\xa2", //chr(162),
                            "\xa3", //chr(163),
                            "\xa9", //chr(169),
                            "",
                            "\r\n",
                            "",
                            "《"
        };
            string s = HTML;
            for (int i = 0; i < Regexs.Length; i++)
            {
                s = new Regex(Regexs[i], RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(s, Replaces[i]);
            }
            s.Replace("<", "");
            s.Replace(">", "");
            s.Replace("\r\n", "");
            return s;
        }
    }
}
