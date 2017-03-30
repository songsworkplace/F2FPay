using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api.Response;
using WeiXinPaySDK;

namespace Beefun.F2FPay.Domain
{
    public class OrderQueryResult:BaseResult
    {
        /// <summary>
        /// 第三方交易号
        /// 注：支付宝-trade_no string(64)，微信-transaction_id string(32) 
        /// </summary>
        public string OnlineTradeNo { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 交易状态
        /// 注：支付宝-trade_status ，交易状态：WAIT_BUYER_PAY（交易创建，等待买家付款）、TRADE_CLOSED（未付款交易超时关闭，或支付完成后全额退款）、TRADE_SUCCESS（交易支付成功）、TRADE_FINISHED（交易结束，不可退款） 
        /// 微信-trade_state ，SUCCESS—支付成功,REFUND—转入退款，NOTPAY—未支付,CLOSED—已关闭，REVOKED—已撤销（刷卡支付）,USERPAYING--用户支付中，PAYERROR--支付失败(其他原因，如银行返回失败)
        /// </summary>
        public string TradeStatus { get; set; }
        /// <summary>
        /// 总金额
        /// 注：支付宝-total_amount 单位：元，两位小数
        /// 微信-total_fee 单位：分，int
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 交易完成时间，注：支付宝-send_pay_date ，微信-time_end 
        /// </summary>
        public DateTime? TradeTime { get; set; }

        public override void SetWeixiResult(WeixinDataHelper response)
        {
            base.SetWeixiResult(response);
            if (!this.IsError)
            {
                this.OnlineTradeNo = response.IsSet("transaction_id") ?response.GetValue("transaction_id").ToString():"";
                this.OutTradeNo = response.IsSet("out_trade_no") ?response.GetValue("out_trade_no").ToString():"";
                this.TradeStatus = response.IsSet("trade_state") ?response.GetValue("trade_state").ToString():"";
                this.TotalAmount = response.IsSet("total_fee") ?response.GetValue("total_fee").ToString():"";
                if (response.IsSet("time_end"))
                {
                    this.TradeTime = DateTime.ParseExact(response.GetValue("time_end").ToString(), "yyyyMMddHHmmss", null);
                } 
            }
        }

        public void SetAlipayResult(AlipayTradeQueryResponse response)
        {
            base.SetAlipayResult(response);
            if (!this.IsError)
            {
                this.OnlineTradeNo = response.TradeNo;
                this.OutTradeNo = response.OutTradeNo;
                this.TradeStatus = response.TradeStatus;
                this.TotalAmount = response.TotalAmount;
                this.TradeTime =Convert.ToDateTime(response.SendPayDate);
            }
        }
    }
}
