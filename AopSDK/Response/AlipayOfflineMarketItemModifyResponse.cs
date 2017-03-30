using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOfflineMarketItemModifyResponse.
    /// </summary>
    public class AlipayOfflineMarketItemModifyResponse : AopResponse
    {
        /// <summary>
        /// 支付宝商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 传入的请求id
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
