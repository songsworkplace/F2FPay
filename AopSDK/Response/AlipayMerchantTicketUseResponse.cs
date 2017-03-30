using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMerchantTicketUseResponse.
    /// </summary>
    public class AlipayMerchantTicketUseResponse : AopResponse
    {
        /// <summary>
        /// 请求时传入的业务幂等号（外部订单号）
        /// </summary>
        [XmlElement("biz_no")]
        public string BizNo { get; set; }

        /// <summary>
        /// 错误码，错误代码，参见"7  错误码"。  当出现重复请求，但幂等处理成功时，也会有表示幂等重复请求的错误码
        /// </summary>
        [XmlElement("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 具体错误原因，当出现重复请求，但幂等处理成功时，也会有表示幂等重复
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 是否成功,整个业务处理成功时  返回T否则返回F。  具体的错误码和 信息科参考error_code和error_msg信息
        /// </summary>
        [XmlElement("success_code")]
        public string SuccessCode { get; set; }

        /// <summary>
        /// 核销券的详细信息
        /// </summary>
        [XmlElement("ticket")]
        public Ticket Ticket { get; set; }
    }
}
