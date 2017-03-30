using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.F2FPay.Domain
{
    /// <summary>
    /// 使用扫码设备读取用户手机支付宝“付款码”,支付宝和微信公共参数
    /// </summary>
    public class OrderPayDTO : BaseDTO
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 总金额 单位：元
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 授权码
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 订单标题，必选，
        /// 注：支付宝-subject string(256)，微信-body string(32)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///门店号，可选，
        /// 注：支付宝-store_id string(32),微信-device_info string(16) 
        /// </summary>
        public string StoreId { get; set; }
        /// <summary>
        /// 商户机具终端编号,必选，
        /// 注：支付宝-terminal_id string(32)，微信-spbill_create_ip String(16)
        /// </summary>
        public string TerminalId { get; set; }
    }
}
