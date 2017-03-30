using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipaySecurityRiskFilesuploadingResponse.
    /// </summary>
    public class AlipaySecurityRiskFilesuploadingResponse : AopResponse
    {
        /// <summary>
        /// outputparamtest
        /// </summary>
        [XmlElement("outputparamtest")]
        public string Outputparamtest { get; set; }
    }
}
