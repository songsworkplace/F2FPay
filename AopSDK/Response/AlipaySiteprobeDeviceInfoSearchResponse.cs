using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeDeviceInfoSearchResponse.
    /// </summary>
    public class AlipaySiteprobeDeviceInfoSearchResponse : AopResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 总设备数  &#61548; 设备ID1  &#61550; BSSID  &#61550; SSID  &#61550; 密码（可空）  &#61550; 认证ID（可空，白名单必填，OTP不填）  &#61550; AuthType  &#61550; ShopID  &#61550; 是否上架  &#61548; 设备ID2  &#61548; ….
        /// </summary>
        [XmlElement("devices")]
        public string Devices { get; set; }

        /// <summary>
        /// 返回码描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 店铺路由器总数
        /// </summary>
        [XmlElement("total")]
        public long Total { get; set; }
    }
}
