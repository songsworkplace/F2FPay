using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TodoRemind Data Structure.
    /// </summary>
    [Serializable]
    public class TodoRemind : AopObject
    {
        /// <summary>
        /// 所属产品、即消息标签。如付款、代付
        /// </summary>
        [XmlElement("business_type")]
        public string BusinessType { get; set; }

        /// <summary>
        /// 消息id
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 支付宝账号
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
