using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DishonestyQueryResultInfo Data Structure.
    /// </summary>
    [Serializable]
    public class DishonestyQueryResultInfo : AopObject
    {
        /// <summary>
        /// 住址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 失信记录详情
        /// </summary>
        [XmlArray("detail")]
        [XmlArrayItem("dishonesty_detail_info")]
        public List<DishonestyDetailInfo> Detail { get; set; }

        /// <summary>
        /// 是否有失信数据
        /// </summary>
        [XmlElement("has_dishonesty_record")]
        public bool HasDishonestyRecord { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [XmlElement("id_number")]
        public string IdNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [XmlElement("sex")]
        public string Sex { get; set; }
    }
}
