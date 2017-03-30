using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AliTrust Data Structure.
    /// </summary>
    [Serializable]
    public class AliTrust : AopObject
    {
        /// <summary>
        /// 是否存在于阿里信用黑名单中
        /// </summary>
        [XmlElement("black")]
        public bool Black { get; set; }

        /// <summary>
        /// 如果在黑名单中, 记录被列入黑名单的日期
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// 被查用户的身份证号
        /// </summary>
        [XmlElement("id_card")]
        public string IdCard { get; set; }

        /// <summary>
        /// 被查用户的姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 是否需要再次发起查询
        /// </summary>
        [XmlElement("re_query")]
        public bool ReQuery { get; set; }

        /// <summary>
        /// 如果在黑名单中, 记录被列入黑名单的原因
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 黑名单来自于哪家机构
        /// </summary>
        [XmlElement("source")]
        public string Source { get; set; }
    }
}
