using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeShopInfoAddResponse.
    /// </summary>
    public class AlipaySiteprobeShopInfoAddResponse : AopResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回值描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 由支付宝生成的唯一店铺ID，成功时返回
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }
    }
}
