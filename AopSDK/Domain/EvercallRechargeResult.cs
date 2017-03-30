using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// EvercallRechargeResult Data Structure.
    /// </summary>
    [Serializable]
    public class EvercallRechargeResult : AopObject
    {
        /// <summary>
        /// 外部商户订单号
        /// </summary>
        [XmlElement("merchant_order_no")]
        public string MerchantOrderNo { get; set; }

        /// <summary>
        /// 签约手机号
        /// </summary>
        [XmlElement("mobile_no")]
        public string MobileNo { get; set; }

        /// <summary>
        /// 支付宝单据号
        /// </summary>
        [XmlElement("recharge_order_no")]
        public string RechargeOrderNo { get; set; }

        /// <summary>
        /// 充值处理结果
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 支付宝账户号
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
