using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beefun.F2FPay.Domain
{
    /// <summary>
    /// 交易订单查询，支付，微信都支持
    /// </summary>
    public class OrderQueryDTO : BaseDTO
    {
        /// <summary>
        /// 第三方交易号
        /// </summary>
        public string OnlineTradeNo { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
    }
}
