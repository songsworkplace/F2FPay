using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayPcreditUserLevelGetResponse.
    /// </summary>
    public class AlipayPcreditUserLevelGetResponse : AopResponse
    {
        /// <summary>
        /// 花呗额度等级
        /// </summary>
        [XmlElement("amount_level")]
        public string AmountLevel { get; set; }

        /// <summary>
        /// 用户的花呗额度等级
        /// </summary>
        [XmlElement("level")]
        public string Level { get; set; }
    }
}
