using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayStockPortfolioSingleAddResponse.
    /// </summary>
    public class AlipayStockPortfolioSingleAddResponse : AopResponse
    {
        /// <summary>
        /// 操作返回码，调用成功返回200
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回码的描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 本次操作是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
