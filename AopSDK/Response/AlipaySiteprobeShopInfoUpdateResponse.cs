using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeShopInfoUpdateResponse.
    /// </summary>
    public class AlipaySiteprobeShopInfoUpdateResponse : AopResponse
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
    }
}
