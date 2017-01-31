using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipolen.ExcelTools.Model
{
    /// <summary>
    /// 国家模板
    /// </summary>
    public class CountryTemplate
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// 模板编码
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 模板Excel Sheet 名称
        /// </summary>
        public string TemplateSheetName { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryCode { get; set; }
    }
}
