using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayDataItemVoucherTemplete Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataItemVoucherTemplete : AopObject
    {
        /// <summary>
        /// 券使用规则描述
        /// </summary>
        [XmlArray("desc_details")]
        [XmlArrayItem("alipay_data_item_description")]
        public List<AlipayDataItemDescription> DescDetails { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        [XmlElement("discount_rate")]
        public string DiscountRate { get; set; }

        /// <summary>
        /// 外部单品列表
        /// </summary>
        [XmlElement("external_goods_list")]
        public AlipayDataItemGoodsList ExternalGoodsList { get; set; }

        /// <summary>
        /// 使用规则说明
        /// </summary>
        [XmlElement("limit_period_info_list")]
        public AlipayDataItemLimitPeriodInfo LimitPeriodInfoList { get; set; }

        /// <summary>
        /// 商品原金额
        /// </summary>
        [XmlElement("original_amount")]
        public string OriginalAmount { get; set; }

        /// <summary>
        /// 券原折扣
        /// </summary>
        [XmlElement("original_rate")]
        public string OriginalRate { get; set; }

        /// <summary>
        /// 减至金额，代表券可抵扣至多少
        /// </summary>
        [XmlElement("reduce_to_amount")]
        public string ReduceToAmount { get; set; }

        /// <summary>
        /// 起步金额
        /// </summary>
        [XmlElement("threshold_amount")]
        public string ThresholdAmount { get; set; }

        /// <summary>
        /// 起步数量
        /// </summary>
        [XmlElement("threshold_quantity")]
        public string ThresholdQuantity { get; set; }

        /// <summary>
        /// 有效期，单位：分钟
        /// </summary>
        [XmlElement("valid_period")]
        public long ValidPeriod { get; set; }

        /// <summary>
        /// 价值金额  CASH类型为代金券金额  DISCOUNT类型为优惠封顶金额
        /// </summary>
        [XmlElement("value_amount")]
        public string ValueAmount { get; set; }

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
