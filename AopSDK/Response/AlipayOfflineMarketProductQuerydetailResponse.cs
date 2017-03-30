using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOfflineMarketProductQuerydetailResponse.
    /// </summary>
    public class AlipayOfflineMarketProductQuerydetailResponse : AopResponse
    {
        /// <summary>
        /// 商品首图
        /// </summary>
        [XmlElement("cover")]
        public string Cover { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [XmlArray("descriptions")]
        [XmlArrayItem("alipay_data_item_description")]
        public List<AlipayDataItemDescription> Descriptions { get; set; }

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
        /// 商品状态
        /// </summary>
        [XmlElement("item_status")]
        public string ItemStatus { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [XmlElement("item_type")]
        public string ItemType { get; set; }

        /// <summary>
        /// 图片集，是map转化成的json串，key是图片id,value是图片url
        /// </summary>
        [XmlElement("pic_coll")]
        public string PicColl { get; set; }

        /// <summary>
        /// 商品购买类型 OBTAIN，AUTO_OBTAIN
        /// </summary>
        [XmlElement("purchase_mode")]
        public string PurchaseMode { get; set; }

        /// <summary>
        /// 销售规则
        /// </summary>
        [XmlElement("sales_rule")]
        public AlipayDataItemSalesRule SalesRule { get; set; }

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
        public AlipayDataItemVoucherTemplete VoucherTemplete { get; set; }

        /// <summary>
        /// 商品顺序描述
        /// </summary>
        [XmlElement("weight")]
        public long Weight { get; set; }
    }
}
