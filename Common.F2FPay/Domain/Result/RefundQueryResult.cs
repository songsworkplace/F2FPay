using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api.Response;
using WeiXinPaySDK;

namespace Common.F2FPay.Domain
{
    public class RefundQueryResult:BaseResult
    {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string OnlineTradeNo { get; set; }
        /// <summary>
        /// 创建交易传入的商户订单号
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 本笔退款对应的退款请求号
        /// </summary>
        public string OutRefundNo { get; set; }
        /// <summary>
        /// 退款原因,微信-无
        /// </summary>
        public string RefundReason { get; set; }
        /// <summary>
        /// 该笔退款所对应的交易的订单金额
        /// </summary>
        public string TotalAmout { get; set; }
        /// <summary>
        /// 本次退款请求，对应的退款金额
        /// </summary>
        public string RefundAmount { get; set; }
        /// <summary>
        /// 退款状态
        ///微信：
        ///退款状态退款状态：
        ///SUCCESS—退款成功，FAIL—退款失败，PROCESSING—退款处理中，
        ///NOTSURE—未确定，需要商户原退款单号重新发起
        ///CHANGE—转入代发，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，资金回流到商户的现金帐号，需要商户人工干预，通过线下或者财付通转账的方式进行退款。
        /// 支付宝：无
        /// </summary>
        public string RefundStatus { get; set; }

        public override void SetWeixiResult(WeixinDataHelper response)
        {
            base.SetWeixiResult(response);
            if (!IsError)
            {
                this.OnlineTradeNo = response.IsSet("transaction_id") ? response.GetValue("transaction_id").ToString() : "";
                this.OutTradeNo = response.IsSet("out_trade_no") ? response.GetValue("out_trade_no").ToString() : "";
                this.TotalAmout = response.IsSet("total_fee") ? response.GetValue("total_fee").ToString() : "";
                //this.RefundReason =;//微信不支持
                //请完成一次退款
                //这里不处理部分退款，https://pay.weixin.qq.com/wiki/doc/api/micropay_sl.php?chapter=9_5
                this.RefundAmount = response.IsSet("refund_fee_1") ? response.GetValue("refund_fee_1").ToString() : "";
                this.RefundStatus = response.IsSet("refund_status_1") ? response.GetValue("refund_status_1").ToString() : "";
                this.OutRefundNo = response.IsSet("out_refund_no_1") ? response.GetValue("out_refund_no_1").ToString() : "";
            }
        }

        public void SetAlipayResult(AlipayTradeFastpayRefundQueryResponse response)
        {
            base.SetAlipayResult(response);
            if (!IsError)
            {
                this.OnlineTradeNo = response.TradeNo;
                this.OutRefundNo = response.OutRequestNo;
                this.OutTradeNo = response.OutTradeNo;
                this.RefundReason =response.RefundReason;
                this.TotalAmout = response.TotalAmout;
                this.RefundAmount = response.RefundAmount;
                this.RefundStatus = "SUCCESS";//支付宝不支持
            }
        }
    }
}
