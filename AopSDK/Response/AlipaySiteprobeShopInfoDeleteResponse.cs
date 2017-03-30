using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeShopInfoDeleteResponse.
    /// </summary>
    public class AlipaySiteprobeShopInfoDeleteResponse : AopResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回码信息
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }
    }
}
