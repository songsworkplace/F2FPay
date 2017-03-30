using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOfflineMarketItemCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOfflineMarketItemCreateModel : AopObject
    {
        /// <summary>
        /// 审核规则
        /// </summary>
        [XmlElement("audit_rule")]
        public AlipayItemAuditRule AuditRule { get; set; }

        /// <summary>
        /// 商品首图
        /// </summary>
        [XmlElement("cover")]
        public string Cover { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [XmlArray("descriptions")]
        [XmlArrayItem("alipay_item_description")]
        public List<AlipayItemDescription> Descriptions { get; set; }

        /// <summary>
        /// 商品下架时间
        /// </summary>
        [XmlElement("gmt_end")]
        public string GmtEnd { get; set; }

        /// <summary>
        /// 商品生效时间
        /// </summary>
        [XmlElement("gmt_start")]
        public string GmtStart { get; set; }

        /// <summary>
        /// 商品库存数量
        /// </summary>
        [XmlElement("inventory")]
        public long Inventory { get; set; }

        /// <summary>
        /// 是否自动延期，默认true
        /// </summary>
        [XmlElement("is_auto_expanded")]
        public bool IsAutoExpanded { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [XmlElement("item_type")]
        public string ItemType { get; set; }

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
        /// 商品购买类型 OBTAIN，AUTO_OBTAIN
        /// </summary>
        [XmlElement("purchase_mode")]
        public string PurchaseMode { get; set; }

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
        /// 上架门店id
        /// </summary>
        [XmlArray("shop_list")]
        [XmlArrayItem("string")]
        public List<string> ShopList { get; set; }

        /// <summary>
        /// 商品的标题
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// 券模板信息
        /// </summary>
        [XmlElement("voucher_templete")]
        public AlipayItemVoucherTemplete VoucherTemplete { get; set; }

        /// <summary>
        /// 商品顺序描述
        /// </summary>
        [XmlElement("weight")]
        public long Weight { get; set; }
    }
}
