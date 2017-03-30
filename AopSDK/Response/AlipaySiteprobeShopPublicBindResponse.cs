using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeShopPublicBindResponse.
    /// </summary>
    public class AlipaySiteprobeShopPublicBindResponse : AopResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回码说明
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 服务窗Logo连接
        /// </summary>
        [XmlElement("public_logo")]
        public string PublicLogo { get; set; }

        /// <summary>
        /// 服务窗名称
        /// </summary>
        [XmlElement("public_name")]
        public string PublicName { get; set; }
    }
}
