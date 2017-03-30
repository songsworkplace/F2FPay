using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AliTrustRealNameRegistration Data Structure.
    /// </summary>
    [Serializable]
    public class AliTrustRealNameRegistration : AopObject
    {
        /// <summary>
        /// 用户出生日期
        /// </summary>
        [XmlElement("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// 点击实名制logo跳转链接
        /// </summary>
        [XmlElement("forward_url")]
        public string ForwardUrl { get; set; }

        /// <summary>
        /// 用户性别(M：男性/F：女性)
        /// </summary>
        [XmlElement("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// 实名制logo
        /// </summary>
        [XmlElement("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 当账户为实名制注册时,取值为"T";否则为"F".
        /// </summary>
        [XmlElement("real_name_registered")]
        public string RealNameRegistered { get; set; }
    }
}
