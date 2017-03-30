using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeDeviceInfoAddResponse.
    /// </summary>
    public class AlipaySiteprobeDeviceInfoAddResponse : AopResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        [XmlElement("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 返回码描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }
    }
}
