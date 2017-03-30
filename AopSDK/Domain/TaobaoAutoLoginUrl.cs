using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TaobaoAutoLoginUrl Data Structure.
    /// </summary>
    [Serializable]
    public class TaobaoAutoLoginUrl : AopObject
    {
        /// <summary>
        /// 业务返回状态码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 业务返回描述
        /// </summary>
        [XmlElement("message")]
        public string Message { get; set; }

        /// <summary>
        /// 获取免登url是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 淘宝航旅免登url
        /// </summary>
        [XmlElement("taobao_auto_loginurl")]
        public string TaobaoAutoLoginurl { get; set; }
    }
}
