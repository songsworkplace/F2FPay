using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// EvercallAlertResult Data Structure.
    /// </summary>
    [Serializable]
    public class EvercallAlertResult : AopObject
    {
        /// <summary>
        /// 签约手机号
        /// </summary>
        [XmlElement("mobile_no")]
        public string MobileNo { get; set; }

        /// <summary>
        /// 预警接收结果
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
