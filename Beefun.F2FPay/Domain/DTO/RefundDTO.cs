using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beefun.F2FPay.Domain
{
    public class RefundDTO : BaseDTO
    {
        /// <summary>
        /// 第三方交易订单号
        /// </summary>
        public string OnlineTradeNo { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 退款订单号，注：支付宝-out_request_no string(64),微信-out_refund_no string(32)
        /// </summary>
        public string OutRefundNo { get; set; }
        /// <summary>
        /// 总金额,注：支付宝无
        /// </summary>
        public string TotalFee { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public string RefundFee { get; set; }
        /// <summary>
        /// 退款原因 注：微信无
        /// </summary>
        public string RefundReason { get; set; }
    }
}
