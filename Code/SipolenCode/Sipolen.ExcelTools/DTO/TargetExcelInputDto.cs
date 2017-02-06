using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipolen.ExcelTools.DTO
{
    public class TargetExcelInputDto
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        [Description()]
        public string ExternalProductId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("brand_name|manufacturer")]
        public string BrandName { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [Description("feed_product_type")]
        public string FeedProductType { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        [Description("")]
        public string CurrencyExchangeRate { get; set; }

        /// <summary>
        /// 货币单位
        /// </summary>
        [Description("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        [Description("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// 条件说明 （此处为交货时长）
        /// </summary>
        [Description("condition_note")]
        public string ConditionNote { get; set; }

        /// <summary>
        /// 货物重量
        /// </summary>
        [Description("website_shipping_weight")]
        public string WebsiteShippingWeight { get; set; }

        /// <summary>
        /// 推荐浏览节点1编号
        /// </summary>
        [Description("recommended_browse_nodes1")]
        public string RecommendedBrowseNodes1 { get; set; }

        /// <summary>
        /// 推荐浏览节点2编号
        /// </summary>
        [Description("recommended_browse_nodes2")]
        public string RecommendedBrowseNodes2 { get; set; }
    }
}
