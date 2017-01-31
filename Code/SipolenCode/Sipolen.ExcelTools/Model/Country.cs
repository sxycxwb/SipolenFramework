using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipolen.ExcelTools.Model
{
    /// <summary>
    /// 国家实体
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 国家名称
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// 所属洲际编码
        /// </summary>
        public string ContinentCode { get; set; }

        /// <summary>
        /// 货币单位
        /// </summary>
        public string CurrencyUnit { get; set; }

        /// <summary>
        /// 货币单位名称
        /// </summary>
        public string CurrencyUnitName { get; set; }

        /// <summary>
        /// 货币汇率
        /// </summary>
        public string CurrencyExchangeRate { get; set; }
    }
}
