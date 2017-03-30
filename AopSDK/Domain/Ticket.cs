using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// Ticket Data Structure.
    /// </summary>
    [Serializable]
    public class Ticket : AopObject
    {
        /// <summary>
        /// 可优惠面额，  券初始优惠金额  格式：浮点类型数字  精度：精确到小数点后2位
        /// </summary>
        [XmlElement("available_amount")]
        public string AvailableAmount { get; set; }

        /// <summary>
        /// 是否可转赠标识，  1 支持退款  0 不支持退款
        /// </summary>
        [XmlElement("donate_flag")]
        public string DonateFlag { get; set; }

        /// <summary>
        /// 扩展信息，以json形式存储
        /// </summary>
        [XmlElement("ext_prop")]
        public string ExtProp { get; set; }

        /// <summary>
        /// 有效期开始时间，格式为yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("gmt_active")]
        public string GmtActive { get; set; }

        /// <summary>
        /// 创建(领取)时间，格式为yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 有效期结束时间，格式为yyyy-MM-dd HH:mm:ss
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
        /// 商户id，券所属商户，  在支付宝的partnerId
        /// </summary>
        [XmlElement("merchant_uniq_id")]
        public string MerchantUniqId { get; set; }

        /// <summary>
        /// 券名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 是否可退款标识，  标识：  1 支持退款  0 不支持退款
        /// </summary>
        [XmlElement("refund_flag")]
        public string RefundFlag { get; set; }

        /// <summary>
        /// 券状态信息，  目前状态主要有以下几种：   VALID：可使用   WRITED_OFF：已核销,   EXPIRED：已过期   CLOSED：已关闭
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 券模板编号
        /// </summary>
        [XmlElement("template_no")]
        public string TemplateNo { get; set; }

        /// <summary>
        /// 券编号
        /// </summary>
        [XmlElement("ticket_no")]
        public string TicketNo { get; set; }

        /// <summary>
        /// 券类型，  表示券的种类：   TICKET：优惠券   EXCANGE：兑换券
        /// </summary>
        [XmlElement("ticket_type")]
        public string TicketType { get; set; }
    }
}
