using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeDeviceInfoGetResponse.
    /// </summary>
    public class AlipaySiteprobeDeviceInfoGetResponse : AopResponse
    {
        /// <summary>
        /// 认证ID（可空，白名单必填，OTP不填）
        /// </summary>
        [XmlElement("auth_id")]
        public string AuthId { get; set; }

        /// <summary>
        /// 认证类型
        /// </summary>
        [XmlElement("auth_type")]
        public string AuthType { get; set; }

        /// <summary>
        /// Mac地址
        /// </summary>
        [XmlElement("bssid")]
        public string Bssid { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [XmlElement("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [XmlElement("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 返回码描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 路由器密码
        /// </summary>
        [XmlElement("password")]
        public string Password { get; set; }

        /// <summary>
        /// 店铺Id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// WiFi名称
        /// </summary>
        [XmlElement("ssid")]
        public string Ssid { get; set; }

        /// <summary>
        /// 状态，1-上架，0-下架
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
