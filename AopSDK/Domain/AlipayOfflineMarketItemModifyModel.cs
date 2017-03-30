using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOfflineMarketItemModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOfflineMarketItemModifyModel : AopObject
    {
        /// <summary>
        /// 审核规则
        /// </summary>
        [XmlElement("audit_rule")]
        public AlipayItemAuditRule AuditRule { get; set; }

        /// <summary>
        /// 商品失效时间，只能延长，不能缩短
        /// </summary>
        [XmlElement("gmt_end")]
        public string GmtEnd { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [XmlElement("inventory")]
        public long Inventory { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 商户接口异步通知的地址
        /// </summary>
        [XmlElement("operate_notify_url")]
        public string OperateNotifyUrl { get; set; }

        /// <summary>
        /// 商品操作上下文
        /// </summary>
        [XmlElement("operation_context")]
        public AlipayItemOperationContext OperationContext { get; set; }

        /// <summary>
        /// 请求id，必须保证单商户下唯一
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 销售规则
        /// </summary>
        [XmlElement("sales_rule")]
        public AlipayItemSalesRule SalesRule { get; set; }

        /// <summary>
        /// 商品展示权重
        /// </summary>
        [XmlElement("weight")]
        public long Weight { get; set; }
    }
}
