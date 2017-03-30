using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOfflineMarketShopBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOfflineMarketShopBatchqueryModel : AopObject
    {
        /// <summary>
        /// 页码，留空标示第一页，默认500个结果为一页
        /// </summary>
        [XmlElement("page_no")]
        public string PageNo { get; set; }
    }
}
