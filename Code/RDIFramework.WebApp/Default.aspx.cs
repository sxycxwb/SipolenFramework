using System;
using System.Data;
using System.Linq;
using RDIFramework.WebCommon;

namespace RDIFramework.WebApp
{
    using BizLogic;
    using Utilities;
    using CommonUtils;

    /// <summary>
    /// 
    /// 修改记录 
    /// 
    /// XuWangBin 2014-01-16 V2.7 增加对Tree导航菜单的加载。
    /// XuWangBin 2013-11-08 V2.7 增加只加载与WebForm相关的模块。
    /// </summary>
    public partial class _Default : BasePage
    {
        public string menuJSON = "";
        public string navContent = "";
        private string parentId = "84CA44CB-8A0F-43A1-BD86-1ED764216C59";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (DateTime.Now.Month == 3 && DateTime.Now.Day > 30)
            //{
            //    Response.Write("<h1>试用期到啦</h2>");
            //    Response.End();
            //}

            if (this.UserInfo == null)
            {
                Response.Redirect("login.htm");
            }

            base.GetModuleDT();
            string navHTML = "Accordion.html";
            if (base.DTModule != null && base.DTModule.Rows.Count > 0)
            {
                UserInfo vUser = Utils.UserInfo;
                var curNavType = RDIFrameworkService.Instance.ParameterService.GetParameter(vUser, "User", vUser.Id, "NavType");
                if (!string.IsNullOrEmpty(curNavType))
                {
                    switch (curNavType)
                    {
                        case "Accordion":
                            menuJSON = GetAccordionJsonByTable(base.DTModule, "Id", "FullName", "ParentId", parentId);
                            navHTML = "Accordion.html";
                            break;
                        case "Tree":
                            menuJSON = GetTreeJsonByTable(base.DTModule, "Id", "FullName", "ParentId", parentId);
                            navHTML = "tree.html";
                            break;
                        case "AccordionTree":
                            menuJSON = GetAccordionTreeJsonByTable(base.DTModule, "Id", "FullName", "ParentId", parentId);
                            navHTML = "Accordion.html";
                            break;
                        default:
                            menuJSON = GetAccordionJsonByTable(base.DTModule, "Id", "FullName", "ParentId", parentId);
                            navHTML = "Accordion.html";
                            break;
                    }
                }
                else
                {
                    menuJSON = GetAccordionTreeJsonByTable(base.DTModule, "Id", "FullName", "ParentId", parentId);
                    navHTML = "Accordion.html";
                }
            }

            if (menuJSON == "")
            {
                menuJSON = "null";
            }

            string themePath = Server.MapPath("~/Content/navtype/");
            NVelocityUtils vel = new NVelocityUtils(themePath);
            vel.Put("username", base.UserInfo.UserName);
            navContent = vel.FileToString(navHTML);
        }

        #region  private string GetAccordionJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId) 根据DataTable生成AccordionJson树结构
        string result = string.Empty;
        string tmpStr = string.Empty;
        /// <summary>
        /// 根据DataTable生成AccordionJson树结构
        /// </summary>
        /// <param name="tabel">数据源</param>
        /// <param name="idCol">ID列</param>
        /// <param name="txtCol">Text列</param>
        /// <param name="rela">关系字段</param>
        /// <param name="pId">父ID</param>
        /// <returns>返回json数据</returns>
        private string GetAccordionJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId)
        {
            result += tmpStr;
            tmpStr = string.Empty;

            if (tabel.Rows.Count <= 0) return result;

            tmpStr += "[";
            var filer = string.Format("{0}='{1}'", rela, pId);
            var rows = tabel.Select(filer);
            if (rows.Length > 0)
            {
                foreach (var row in from row in rows
                        let moduleType = BusinessLogic.ConvertToNullableInt(row[PiModuleTable.FieldModuleType])
                        let modulePublic = BusinessLogic.ConvertToNullableInt(row[PiModuleTable.FieldIsPublic])
                        where moduleType == null || moduleType == 2 || moduleType == 3 || modulePublic == 1
                        select row)
                {
                    tmpStr += "{\"Id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol]
                          + "\",\"NavigateUrl\":\"" + row[PiModuleTable.FieldNavigateUrl]
                          + "\",\"IconCss\":\"" + row[PiModuleTable.FieldIconCss]
                          + "\",\"FullName\":\"" + row[PiModuleTable.FieldFullName]
                          + "\",\"state\":\"open\"";
                    if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                    {
                        tmpStr += ",\"children\":";
                        GetAccordionJsonByTable(tabel, idCol, txtCol, rela, row[idCol]);
                        result += tmpStr;
                        tmpStr = string.Empty;
                    }
                    result += tmpStr;
                    tmpStr = string.Empty;
                    tmpStr += "},";
                }
                tmpStr = tmpStr.Remove(tmpStr.Length - 1, 1);
            }
            else
            {
                tmpStr = tmpStr.TrimEnd(",\"children\":".ToCharArray());
            }

            tmpStr += "]";
            result += tmpStr;
            tmpStr = string.Empty;
            return result;
        }
        #endregion

        #region private string GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId) 根据DataTable生成Json树结构
        /// <summary>
        /// 根据DataTable生成Json树结构
        /// </summary>
        /// <param name="tabel">数据源</param>
        /// <param name="idCol">ID列</param>
        /// <param name="txtCol">Text列</param>
        /// <param name="rela">关系字段</param>
        /// <param name="pId">父ID</param>
        /// <returns>返回json数据</returns>
        private string GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId)
        {
            result += tmpStr;
            tmpStr = string.Empty;

            if (tabel.Rows.Count <= 0) return result;
            tmpStr += "[";
            var filer = string.Format("{0}='{1}'", rela, pId);
            var rows = tabel.Select(filer);
            if (rows.Length > 0)
            {
                foreach (var row in from row in rows
                        let moduleType = BusinessLogic.ConvertToNullableInt(row[PiModuleTable.FieldModuleType])
                        let modulePublic = BusinessLogic.ConvertToNullableInt(row[PiModuleTable.FieldIsPublic])
                        where moduleType == null || moduleType == 2 || moduleType == 3 || modulePublic == 1
                        select row)
                {
                    tmpStr += "{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol]
                              + "\",\"iconCls\":\"" +
                              BusinessLogic.ConvertToString(row[PiModuleTable.FieldIconCss]).Replace("icon ", "")
                              + "\",\"attributes\":{"
                              + "\"url\":\"" + row[PiModuleTable.FieldNavigateUrl]
                              + "\",\"FullName\":\"" + row[PiModuleTable.FieldFullName]
                              + "\"}";
                    if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                    {
                        tmpStr += PublicMethod.GetInt(row[PiModuleTable.FieldExpand]) == 1
                            ? ",\"state\":\"open\""
                            : ",\"state\":\"closed\"";
                        tmpStr += ",\"children\":";
                        GetTreeJsonByTable(tabel, idCol, txtCol, rela, row[idCol]);
                        result += tmpStr;
                        tmpStr = string.Empty;
                    }
                    result += tmpStr;
                    tmpStr = string.Empty;
                    tmpStr += "},";
                }
                tmpStr = tmpStr.Remove(tmpStr.Length - 1, 1);
            }

            tmpStr += "]";
            result += tmpStr;
            tmpStr = string.Empty;
            return result;
        }
        #endregion

        private string GetAccordionTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId)
        {
            result += tmpStr;
            tmpStr = string.Empty;

            if (tabel.Rows.Count <= 0) return result;
            tmpStr += "[";
            var filer = string.Format("{0}='{1}'", rela, pId);
            var rows = tabel.Select(filer);
            if (rows.Length > 0)
            {
                foreach (var row in from row in rows
                                    let moduleType = BusinessLogic.ConvertToNullableInt(row[PiModuleTable.FieldModuleType])
                                    let modulePublic = BusinessLogic.ConvertToNullableInt(row[PiModuleTable.FieldIsPublic])
                                    where moduleType == null || moduleType == 2 || moduleType == 3 || modulePublic == 1
                                    select row)
                {
                    tmpStr += "{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol]
                              + "\",\"iconCls\":\"" +
                              BusinessLogic.ConvertToString(row[PiModuleTable.FieldIconCss]).Replace("icon ", "")
                              + "\",\"attributes\":{"
                              + "\"url\":\"" + row[PiModuleTable.FieldNavigateUrl]
                              + "\",\"FullName\":\"" + row[PiModuleTable.FieldFullName]
                              + "\"}";
                    if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                    {
                        tmpStr += PublicMethod.GetInt(row[PiModuleTable.FieldExpand]) == 1
                            ? ",\"state\":\"open\""
                            : ",\"state\":\"closed\"";
                        tmpStr += ",\"children\":";
                        GetAccordionTreeJsonByTable(tabel, idCol, txtCol, rela, row[idCol]);

                        result += tmpStr;
                        tmpStr = string.Empty;
                    }
                    result += tmpStr;
                    tmpStr = string.Empty;
                    tmpStr += "},";
                }
                tmpStr = tmpStr.Remove(tmpStr.Length - 1, 1);
            }
            else
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.TrimEnd(",\"children\":]".ToCharArray());
                }
            }

            tmpStr += "]";
            result += tmpStr;
            tmpStr = string.Empty;
            return result;
        }

    }
}