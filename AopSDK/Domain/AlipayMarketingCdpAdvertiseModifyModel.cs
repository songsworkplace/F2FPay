using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMarketingCdpAdvertiseModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingCdpAdvertiseModifyModel : AopObject
    {
        /// <summary>
        /// 行为地址。用户点击广告后，跳转URL地址, 协议必须为HTTPS
        /// </summary>
        [XmlElement("action_url")]
        public string ActionUrl { get; set; }

        /// <summary>
        /// 广告ID,唯一标识一条广告
        /// </summary>
        [XmlElement("ad_id")]
        public string AdId { get; set; }

        /// <summary>
        /// 广告内容。如果广告类型是HTML5，则传入H5链接地址，必须为https协议。最大尺寸不得超过1242px＊242px，小屏幕将按分辨率宽度同比例放大缩小；如果类型是图片，则传入图片ID标识，使用参考图片上传接口：alipay.offline.material.image.upload。图片尺寸为1242px＊290px。图片大小不能超过50kb。
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 当广告类型是H5时，必须传入内容高度，内容高度不能高于钱包要求的展位高度242px
        /// </summary>
        [XmlElement("height")]
        public string Height { get; set; }
    }
}
