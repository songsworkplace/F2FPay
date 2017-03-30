using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InstoreUser Data Structure.
    /// </summary>
    [Serializable]
    public class InstoreUser : AopObject
    {
        /// <summary>
        /// 是否当天生日
        /// </summary>
        [XmlElement("is_birthday")]
        public bool IsBirthday { get; set; }

        /// <summary>
        /// 支付宝用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
