using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayItemOperationContext Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayItemOperationContext : AopObject
    {
        /// <summary>
        /// 商品创建者
        /// </summary>
        [XmlElement("creator")]
        public string Creator { get; set; }

        /// <summary>
        /// 操作角色类型
        /// </summary>
        [XmlElement("op_role")]
        public string OpRole { get; set; }

        /// <summary>
        /// 商户ID，如果商户传入此值，将以此商户ID作为业务主体
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }
    }
}
