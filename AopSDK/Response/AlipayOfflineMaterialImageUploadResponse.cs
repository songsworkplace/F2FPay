using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOfflineMaterialImageUploadResponse.
    /// </summary>
    public class AlipayOfflineMaterialImageUploadResponse : AopResponse
    {
        /// <summary>
        /// 图片在商家中心的唯一标识
        /// </summary>
        [XmlElement("image_id")]
        public string ImageId { get; set; }

        /// <summary>
        /// 图片的访问地址
        /// </summary>
        [XmlElement("image_url")]
        public string ImageUrl { get; set; }
    }
}
