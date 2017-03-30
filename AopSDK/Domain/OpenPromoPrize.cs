using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OpenPromoPrize Data Structure.
    /// </summary>
    [Serializable]
    public class OpenPromoPrize : AopObject
    {
        /// <summary>
        /// 消费门槛设置，单位元
        /// </summary>
        [XmlElement("prize_base_rule_amount")]
        public string PrizeBaseRuleAmount { get; set; }

        /// <summary>
        /// 奖品详情说明，默认和活动详情相同
        /// </summary>
        [XmlElement("prize_desc")]
        public string PrizeDesc { get; set; }

        /// <summary>
        /// 周期性使用时段规则
        /// </summary>
        [XmlArray("prize_dimension_time")]
        [XmlArrayItem("open_promo_prize_dimension")]
        public List<OpenPromoPrizeDimension> PrizeDimensionTime { get; set; }

        /// <summary>
        /// 券指定可用有效结束日期，和相对可用时间互斥
        /// </summary>
        [XmlElement("prize_end_time")]
        public string PrizeEndTime { get; set; }

        /// <summary>
        /// 奖品名称，默认和活动名称相同
        /// </summary>
        [XmlElement("prize_name")]
        public string PrizeName { get; set; }

        /// <summary>
        /// 券相可用对时间，和指定可用时间互斥。
        /// </summary>
        [XmlElement("prize_relative_time")]
        public OpenPromoPrizeRelativeTime PrizeRelativeTime { get; set; }

        /// <summary>
        /// 券指定可用开始时间，和相对可用时间互斥
        /// </summary>
        [XmlElement("prize_start_time")]
        public string PrizeStartTime { get; set; }

        /// <summary>
        /// 店铺数据，支持多条
        /// </summary>
        [XmlArray("prize_suitable_shops")]
        [XmlArrayItem("string")]
        public List<string> PrizeSuitableShops { get; set; }

        /// <summary>
        /// 券模板有效结束日期，默认和活动结束时间相同
        /// </summary>
        [XmlElement("prize_template_end_time")]
        public string PrizeTemplateEndTime { get; set; }

        /// <summary>
        /// 券模板有效起始日期，默认和活动开始时间相同
        /// </summary>
        [XmlElement("prize_template_start_time")]
        public string PrizeTemplateStartTime { get; set; }

        /// <summary>
        /// 奖品类型，现在支持VOUCHER_TICKET：表示代金券
        /// </summary>
        [XmlElement("prize_type")]
        public string PrizeType { get; set; }

        /// <summary>
        /// 抵扣金额，单位元。
        /// </summary>
        [XmlElement("prize_worth_amount")]
        public string PrizeWorthAmount { get; set; }
    }
}
