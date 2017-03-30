using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeUserInfoGetResponse.
    /// </summary>
    public class AlipaySiteprobeUserInfoGetResponse : AopResponse
    {
        /// <summary>
        /// 商家的广告标识。如果商家需要向客户端返回广告URL，需要将该标识一同返回给客户端。
        /// </summary>
        [XmlElement("adv_key")]
        public string AdvKey { get; set; }

        /// <summary>
        /// 结果码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 支付宝用户绑定身份证号码（需要在ABOSS平台签约的合作商可以选择获得）
        /// </summary>
        [XmlElement("id_card")]
        public string IdCard { get; set; }

        /// <summary>
        /// 结果描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 设备提供商应用中支付宝用户的Id
        /// </summary>
        [XmlElement("open_id_1")]
        public string OpenId1 { get; set; }

        /// <summary>
        /// 店铺绑定服务窗应用中支付宝用户的Id（需在请求参数中包含shop_id方可得到）
        /// </summary>
        [XmlElement("open_id_2")]
        public string OpenId2 { get; set; }

        /// <summary>
        /// 支付宝用户绑定手机号码（需要在ABOSS平台签约的合作商可以选择获得）
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }
    }
}
