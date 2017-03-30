using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMarketingCdpAdvertiseCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingCdpAdvertiseCreateModel : AopObject
    {
        /// <summary>
        /// 行为地址。用户点击广告后，跳转URL地址
        /// </summary>
        [XmlElement("action_url")]
        public string ActionUrl { get; set; }

        /// <summary>
        /// 钱包上开放给商家的广告位
        /// </summary>
        [XmlElement("ad_code")]
        public string AdCode { get; set; }

        /// <summary>
        /// 广告展示规则。该规则用于商家设置对用户是否展示广告的校验条件，目前支持设置城市规则、商家店铺规则。按业务要求应用对应规则即可。
        /// </summary>
        [XmlElement("ad_rules")]
        public string AdRules { get; set; }

        /// <summary>
        /// 广告内容。如果广告类型是H5，则传入H5链接地址；如果类型是图片，则传入图片ID标识
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 广告类型，目前包括HTML5和图片，分别传入：H5和PIC
        /// </summary>
        [XmlElement("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [XmlElement("height")]
        public string Height { get; set; }
    }
}
