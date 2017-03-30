using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayPcreditUserLevelGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayPcreditUserLevelGetModel : AopObject
    {
        /// <summary>
        /// 请求来源
        /// </summary>
        [XmlElement("request_from")]
        public string RequestFrom { get; set; }

        /// <summary>
        /// 会员编码
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
