using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TradeFundBill Data Structure.
    /// </summary>
    [Serializable]
    public class TradeFundBill : AopObject
    {
        /// <summary>
        /// 该支付工具类型所使用的金额
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 支付所使用的渠道
        /// </summary>
        [XmlElement("fund_channel")]
        public string FundChannel { get; set; }
    }
}
