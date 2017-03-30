using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api;
using Aop.Api.Response;
using WeiXinPaySDK;

namespace Common.F2FPay.Domain
{
    public class OrderPayResult:BaseResult
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 第三方交易订单号，微信-transaction_id string(32)
        /// </summary>
        public string OnlineTradeNo { get; set; }
        /// <summary>
        /// 完成的交易时间，微信-time_end,支付宝- gmt_payment
        /// </summary>
        public DateTime TradeTime { get; set; }

        /// <summary>
        /// 微信结果设置
        /// </summary>
        /// <param name="response"></param>
        public override void SetWeixiResult(WeixinDataHelper response)
        {
            base.SetWeixiResult(response);
            if (!IsError)
            {
                this.OutTradeNo = response.IsSet("out_trade_no") ? response.GetValue("out_trade_no").ToString() : "";
                this.OnlineTradeNo =response.IsSet("transaction_id") ? response.GetValue("transaction_id").ToString():"";
                //在微信中订单生成时间，格式为yyyyMMddHHmmss
                this.TradeTime =response.IsSet("time_end") ? DateTime.ParseExact(response.GetValue("time_end").ToString(), "yyyyMMddHHmmss", null):DateTime.Now;
            }
        }
        /// <summary>
        /// 支付宝结果设置
        /// </summary>
        /// <param name="response"></param>
        public void SetAlipayResult(AlipayTradePayResponse response)
        {
            base.SetAlipayResult(response);
            if (!IsError)
            {
                this.OutTradeNo = response.OutTradeNo;
                this.OnlineTradeNo = response.TradeNo;
                this.TradeTime = Convert.ToDateTime(response.GmtPayment);
            }
        }
    }
}
