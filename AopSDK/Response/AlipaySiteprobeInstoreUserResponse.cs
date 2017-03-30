using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySiteprobeInstoreUserResponse.
    /// </summary>
    public class AlipaySiteprobeInstoreUserResponse : AopResponse
    {
        /// <summary>
        /// 结果码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 结果描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 到店用户数据
        /// </summary>
        [XmlArray("users")]
        [XmlArrayItem("instore_user")]
        public List<InstoreUser> Users { get; set; }
    }
}
