using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayWapUserAlipayinsideAuthapiResponse.
    /// </summary>
    public class AlipayWapUserAlipayinsideAuthapiResponse : AopResponse
    {
        /// <summary>
        /// 页面接口无同步返回，authCode已notify方式返回，notify地址为商户在开放平台填写的回调地址
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }
    }
}
