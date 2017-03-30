using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayItemVoucherTemplete Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayItemVoucherTemplete : AopObject
    {
        /// <summary>
        /// 延迟生效时间
        /// </summary>
        [XmlElement("delay_minute")]
        public long DelayMinute { get; set; }

        /// <summary>
        /// 券使用规则描述
        /// </summary>
        [XmlArray("desc_details")]
        [XmlArrayItem("alipay_item_description")]
        public List<AlipayItemDescription> DescDetails { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        [XmlElement("discount_rate")]
        public long DiscountRate { get; set; }

        /// <summary>
        /// 外部单品列表
        /// </summary>
        [XmlElement("external_goods_list")]
        public AlipayItemGoodsList ExternalGoodsList { get; set; }

        /// <summary>
        /// 使用规则说明
        /// </summary>
        [XmlArray("limit_period_info_list")]
        [XmlArrayItem("alipay_item_limit_period_info")]
        public List<AlipayItemLimitPeriodInfo> LimitPeriodInfoList { get; set; }

        /// <summary>
        /// 商品原金额
        /// </summary>
        [XmlElement("original_amount")]
        public long OriginalAmount { get; set; }

        /// <summary>
        /// 券原折扣
        /// </summary>
        [XmlElement("original_rate")]
        public long OriginalRate { get; set; }

        /// <summary>
        /// 减至金额，代表券可抵扣至多少
        /// </summary>
        [XmlElement("reduce_to_amount")]
        public long ReduceToAmount { get; set; }

        /// <summary>
        /// 折扣金额取整规则
        /// </summary>
        [XmlElement("rounding_rule")]
        public string RoundingRule { get; set; }

        /// <summary>
        /// 起步金额
        /// </summary>
        [XmlElement("threshold_amount")]
        public long ThresholdAmount { get; set; }

        /// <summary>
        /// 起步数量，用于指定可享受优惠的起步单品购买数量
        /// </summary>
        [XmlElement("threshold_quantity")]
        public long ThresholdQuantity { get; set; }

        /// <summary>
        /// 有效期，单位：分钟
        /// </summary>
        [XmlElement("valid_period")]
        public long ValidPeriod { get; set; }

        /// <summary>
        /// 价值金额  CASH类型为代金券金额  DISCOUNT类型为优惠封顶金额
        /// </summary>
        [XmlElement("value_amount")]
        public long ValueAmount { get; set; }

        /// <summary>
        /// 券的描述信息
        /// </summary>
        [XmlElement("voucher_desc")]
        public string VoucherDesc { get; set; }

        /// <summary>
        /// 券类型
        /// </summary>
        [XmlElement("voucher_type")]
        public string VoucherType { get; set; }
    }
}
