using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MerchantTicketModel Data Structure.
    /// </summary>
    [Serializable]
    public class MerchantTicketModel : AopObject
    {
        /// <summary>
        /// 券当前可用面额
        /// </summary>
        [XmlElement("available_amt")]
        public string AvailableAmt { get; set; }

        /// <summary>
        /// 查询优惠劵类型，取值：  0：商户优惠券  1：商户红包  2：商户兑换券
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 抵扣金额，券初始面额  券优惠金额，可能为空               格式：浮点类型数字   精度：精确到小数点后2位
        /// </summary>
        [XmlElement("discount_amt")]
        public string DiscountAmt { get; set; }

        /// <summary>
        /// 是否可转赠表示  0：不可转赠  1：可转赠
        /// </summary>
        [XmlElement("donate_flag")]
        public string DonateFlag { get; set; }

        /// <summary>
        /// 扩展信息，json格式
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 券有效开始时间
        /// </summary>
        [XmlElement("gmt_active")]
        public string GmtActive { get; set; }

        /// <summary>
        /// 券创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 券有效结束时间
        /// </summary>
        [XmlElement("gmt_expired")]
        public string GmtExpired { get; set; }

        /// <summary>
        /// 券使用说明
        /// </summary>
        [XmlElement("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// 券详情说明
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 商户pid
        /// </summary>
        [XmlElement("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// 券名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 是否可退款标识，取值：  REFUND_VALID：支持退款  REFUND_INVALID：不支持退款
        /// </summary>
        [XmlElement("refund_flag")]
        public string RefundFlag { get; set; }

        /// <summary>
        /// 券状态，取值：  VALID:可使用  WRITED_OFF:已核销  EXPIRED:已过期  CLOSED:已关闭  WAIT_APPLY：待领取
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 券模板编号
        /// </summary>
        [XmlElement("template_no")]
        public string TemplateNo { get; set; }

        /// <summary>
        /// 券id
        /// </summary>
        [XmlElement("ticket_id")]
        public string TicketId { get; set; }

        /// <summary>
        /// 券编号
        /// </summary>
        [XmlElement("ticket_no")]
        public string TicketNo { get; set; }

        /// <summary>
        /// 券类型，现在支持两种类型，代金券MONEY和礼品券GIFT
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 个人用户id
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
