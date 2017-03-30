using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api.Response;
using WeiXinPaySDK;

namespace Beefun.F2FPay.Domain
{
    public class RefundResult:BaseResult
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
        /// 订单金额，支付宝-无， 微信-total_fee
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 退款金额,支付宝- refund_fee  微信-refund_fee
        /// </summary>
        public string RefundAmount { get; set; }
        public override void SetWeixiResult(WeixinDataHelper response)
        {
            base.SetWeixiResult(response);
            if (!IsError)
            {
                this.OnlineTradeNo = response.IsSet("transaction_id") ? response.GetValue("transaction_id").ToString() : "";
                this.OutRefundNo = response.IsSet("out_refund_no") ? response.GetValue("out_refund_no").ToString() : "";
                this.OutTradeNo = response.IsSet("out_trade_no") ? response.GetValue("out_trade_no").ToString() : "";
                this.TotalAmount = response.IsSet("total_fee") ? response.GetValue("total_fee").ToString() : "";
                this.RefundAmount = response.IsSet("refund_fee") ? response.GetValue("refund_fee").ToString() : "";
            }
        }

        public void SetAlipayResult(AlipayTradeRefundResponse response)
        {
            base.SetAlipayResult(response);
            if (!IsError)
            {
                this.OnlineTradeNo = response.TradeNo;
                this.OutTradeNo = response.OutTradeNo;
                this.RefundAmount = response.RefundFee;
            }
        }
    }
}
