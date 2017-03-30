using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayStockPortfolioAllGetResponse.
    /// </summary>
    public class AlipayStockPortfolioAllGetResponse : AopResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回码的描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 股票代码列表
        /// </summary>
        [XmlArray("symbol_list")]
        [XmlArrayItem("string")]
        public List<string> SymbolList { get; set; }
    }
}
