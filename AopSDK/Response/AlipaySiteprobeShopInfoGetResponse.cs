using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeShopInfoGetResponse.
    /// </summary>
    public class AlipaySiteprobeShopInfoGetResponse : AopResponse
    {
        /// <summary>
        /// public, h5或者na
        /// </summary>
        [XmlElement("adv_type")]
        public string AdvType { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 支付宝店铺Logo
        /// </summary>
        [XmlElement("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// 返回值描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 服务窗名称
        /// </summary>
        [XmlElement("public_name")]
        public string PublicName { get; set; }

        /// <summary>
        /// 支付宝店铺名称
        /// </summary>
        [XmlElement("shop_name")]
        public string ShopName { get; set; }

        /// <summary>
        /// 店铺公告
        /// </summary>
        [XmlElement("shop_notice")]
        public string ShopNotice { get; set; }

        /// <summary>
        /// 第三方店铺名称
        /// </summary>
        [XmlElement("third_party_shop_name")]
        public string ThirdPartyShopName { get; set; }

        /// <summary>
        /// h5 url
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
