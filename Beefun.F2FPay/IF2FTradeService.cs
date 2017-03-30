using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beefun.F2FPay.Domain;

namespace Beefun.F2FPay
{
    public interface IF2FTradeService
    {
        /// <summary>
        /// 支付宝-授权码，微信-子商户号
        /// </summary>
        /// <param name="authToken"></param>
        void SetAuthToken(string authToken);
        /// <summary>
        /// 订单扫码支付
        /// </summary>
        /// <returns></returns>
        OrderPayResult OrderPay(OrderPayDTO dto);
        /// <summary>
        /// 交易查询
        /// </summary>
        /// <returns></returns>
        OrderQueryResult OrderQuery(OrderQueryDTO dto);
        /// <summary>
        /// 交易退款
        /// </summary>
        /// <returns></returns>
        RefundResult Refund(RefundDTO dto);
        /// <summary>
        /// 退款查询
        /// </summary>
        /// <returns></returns>
        RefundQueryResult RefundQuery(RefundDTO dto);
    }
}
