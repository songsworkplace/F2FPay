using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayDataItemLimitPeriodInfo Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataItemLimitPeriodInfo : AopObject
    {
        /// <summary>
        /// 区间范围枚举
        /// </summary>
        [XmlElement("rule")]
        public string Rule { get; set; }

        /// <summary>
        /// 单位描述
        /// </summary>
        [XmlElement("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 区间范围值
        /// </summary>
        [XmlArray("value")]
        [XmlArrayItem("number")]
        public List<long> Value { get; set; }
    }
}
