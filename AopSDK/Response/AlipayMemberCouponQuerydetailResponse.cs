using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMemberCouponQuerydetailResponse.
    /// </summary>
    public class AlipayMemberCouponQuerydetailResponse : AopResponse
    {
        /// <summary>
        /// 红包信息
        /// </summary>
        [XmlElement("coupon")]
        public Coupon Coupon { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 具体错误原因
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success_code")]
        public string SuccessCode { get; set; }
    }
}
