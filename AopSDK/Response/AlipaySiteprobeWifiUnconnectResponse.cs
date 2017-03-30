using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeWifiUnconnectResponse.
    /// </summary>
    public class AlipaySiteprobeWifiUnconnectResponse : AopResponse
    {
        /// <summary>
        /// 请求响应码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 请求响应描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }
    }
}
