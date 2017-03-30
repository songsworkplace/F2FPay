using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Common.F2FPay.Domain;
using WeiXinPaySDK;

namespace Common.F2FPay.Weixin
{
    public class WeixinTradeService : IF2FTradeService
    {
        private WeixinPayApi weixinPayApi;
        private string _weixinKey = "";

        public WeixinTradeService()
        {
            string certPath = HttpRuntime.AppDomainAppPath.ToString() + WeixinConfig.SSLCERT_PATH;
            weixinPayApi = new WeixinPayApi(WeixinConfig.IP, WeixinConfig.APPID, WeixinConfig.MCHID, certPath, WeixinConfig.SSLCERT_PASSWORD, WeixinConfig.KEY, WeixinConfig.REPORT_LEVENL);
            _weixinKey = WeixinConfig.KEY;
        }
        /// <summary>
        /// 微信子商户号
        /// </summary>
        /// <param name="authToken"></param>
        public void SetAuthToken(string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new Exception("请重新设置子商户号！");
            }
            weixinPayApi.SetSubMchId(authToken);
        }
        /// <summary>
        /// 扫码支付
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public OrderPayResult OrderPay(OrderPayDTO dto)
        {
            WeixinDataHelper data = new WeixinDataHelper(this._weixinKey);
            data.SetValue("auth_code", dto.AuthCode);//授权码
            data.SetValue("body", dto.Body);//商品描述
            data.SetValue("total_fee", int.Parse(((Convert.ToDouble(dto.TotalAmount))*100).ToString()));//总金额
            data.SetValue("out_trade_no", dto.OutTradeNo);//产生随机的商户订单号
            data.SetValue("spbill_create_ip", dto.TerminalId);//终端ip
            WeixinDataHelper response = weixinPayApi.Micropay(data, 10); //提交被扫支付，接收返回结果
            var result = new OrderPayResult();
            //如果提交被扫支付接口调用失败，则抛异常
            if (!response.IsSet("return_code") || response.GetValue("return_code").ToString() == "FAIL")
            {
                result.SetWeixiResult(response);
                return result;
                //string returnMsg = response.IsSet("return_msg") ? response.GetValue("return_msg").ToString() : "";
                //throw new F2FPayException("Micropay API interface call failure, return_msg : " + returnMsg);
            }

            //签名验证
            response.CheckSign();
            //刷卡支付直接成功
            if (response.GetValue("return_code").ToString() == "SUCCESS" &&
                response.GetValue("result_code").ToString() == "SUCCESS")
            {
                result.SetWeixiResult(response);
                return result;
            }

            /******************************************************************
             * 剩下的都是接口调用成功，业务失败的情况
             * ****************************************************************/
            //1）业务结果明确失败
            if (response.GetValue("err_code").ToString() != "USERPAYING" &&
            response.GetValue("err_code").ToString() != "SYSTEMERROR")
            {
                result.SetWeixiResult(response);
                return result;
            }

            //2）不能确定是否失败，需查单
            //用商户订单号去查单
            string out_trade_no = data.GetValue("out_trade_no").ToString();

            //确认支付是否成功,每隔一段时间查询一次订单，共查询10次
            int queryTimes = 10;//查询次数计数器
            while (queryTimes-- > 0)
            {
                int succResult = 0;//查询结果
                WeixinDataHelper queryResult = Query(out_trade_no, out succResult);
                //如果需要继续查询，则等待2s后继续
                if (succResult == 2)
                {
                    Thread.Sleep(2000);
                    continue;
                }
                //查询成功,返回订单查询接口返回的数据
                else if (succResult == 1)
                {
                    result.SetWeixiResult(queryResult);
                    return result;
                }
                //订单交易失败，直接返回刷卡支付接口返回的结果，失败原因会在err_code中描述
                else
                {
                    result.SetWeixiResult(response);
                    return result;
                }
            }

            //确认失败，则撤销订单
            if (!Cancel(out_trade_no))
            {
                throw new WeixinPayException("撤销订单失败！");
            }
            var errmsg = response.GetValue("err_code_des");
            response.SetValue("err_code_des", errmsg + "(已自动完成了撤销订单)");
            result.SetWeixiResult(response);
            return result;
        }
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public OrderQueryResult OrderQuery(OrderQueryDTO dto)
        {
            WeixinDataHelper data = new WeixinDataHelper(this._weixinKey);
            if (!string.IsNullOrEmpty(dto.OnlineTradeNo))//如果微信订单号存在，则以微信订单号为准
            {
                data.SetValue("transaction_id", dto.OnlineTradeNo);
            }
            else//微信订单号不存在，才根据商户订单号去查单
            {
                data.SetValue("out_trade_no", dto.OutTradeNo);
            }

            WeixinDataHelper response = weixinPayApi.OrderQuery(data);//提交订单查询请求给API，接收返回数据

            var result = new OrderQueryResult();
            result.SetWeixiResult(response);
            return result;
        }
        /// <summary>
        /// 申请退款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RefundResult Refund(RefundDTO dto)
        {
            WeixinDataHelper data = new WeixinDataHelper(this._weixinKey);
            if (!string.IsNullOrEmpty(dto.OnlineTradeNo))//微信订单号存在的条件下，则已微信订单号为准
            {
                data.SetValue("transaction_id", dto.OnlineTradeNo);
            }
            else//微信订单号不存在，才根据商户订单号去退款
            {
                data.SetValue("out_trade_no", dto.OutTradeNo);
            }

            data.SetValue("total_fee", int.Parse(((Convert.ToDouble(dto.TotalFee)) * 100).ToString()));//订单总金额
            data.SetValue("refund_fee", int.Parse(((Convert.ToDouble(dto.RefundFee)) * 100).ToString()));//退款金额
            data.SetValue("out_refund_no", dto.OutRefundNo);//随机生成商户退款单号
            data.SetValue("op_user_id", dto.OperatorId);//操作员，默认为商户号
            WeixinDataHelper respose = weixinPayApi.Refund(data);//提交退款申请给API，接收返回数据
            var result = new RefundResult();
            result.SetWeixiResult(respose);
            return result;
        }
        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RefundQueryResult RefundQuery(RefundDTO dto)
        {
            WeixinDataHelper data = new WeixinDataHelper(this._weixinKey);
            //忽略：微信退款单号，优先级最高data.SetValue("refund_id", refund_id);
            //
            if (!string.IsNullOrEmpty(dto.OutRefundNo))
            {
                data.SetValue("out_refund_no", dto.OutRefundNo);//商户退款单号，优先级第二
            }
            else if (!string.IsNullOrEmpty(dto.OnlineTradeNo))
            {
                data.SetValue("transaction_id", dto.OnlineTradeNo);//微信订单号，优先级第三
            }
            else
            {
                data.SetValue("out_trade_no", dto.OutTradeNo);//商户订单号，优先级最低
            }

            WeixinDataHelper response = weixinPayApi.RefundQuery(data);//提交退款查询给API，接收返回数据
            var result = new RefundQueryResult();
            result.SetWeixiResult(response);
            return result;
        }

        

        #region 内部方法
        /**
	    * 
	    * 查询订单情况
	    * @param string out_trade_no  商户订单号
	    * @param int succCode         查询订单结果：0表示订单不成功，1表示订单成功，2表示继续查询
	    * @return 订单查询接口返回的数据，参见协议接口
	    */
        private WeixinDataHelper Query(string out_trade_no, out int succCode)
        {
            WeixinDataHelper queryOrderInput = new WeixinDataHelper(this._weixinKey);
            queryOrderInput.SetValue("out_trade_no", out_trade_no);
            WeixinDataHelper result = weixinPayApi.OrderQuery(queryOrderInput);

            if (result.GetValue("return_code").ToString() == "SUCCESS"
                && result.GetValue("result_code").ToString() == "SUCCESS")
            {
                //支付成功
                if (result.GetValue("trade_state").ToString() == "SUCCESS")
                {
                    succCode = 1;
                    return result;
                }
                //用户支付中，需要继续查询
                else if (result.GetValue("trade_state").ToString() == "USERPAYING")
                {
                    succCode = 2;
                    return result;
                }
            }

            //如果返回错误码为“此交易订单号不存在”则直接认定失败
            if (result.GetValue("err_code").ToString() == "ORDERNOTEXIST")
            {
                succCode = 0;
            }
            else
            {
                //如果是系统错误，则后续继续
                succCode = 2;
            }
            return result;
        }

        /**
	    * 
	    * 撤销订单，如果失败会重复调用10次
	    * @param string out_trade_no 商户订单号
	    * @param depth 调用次数，这里用递归深度表示
        * @return false表示撤销失败，true表示撤销成功
	    */
        private  bool Cancel(string out_trade_no, int depth = 0)
        {
            if (depth > 10)
            {
                return false;
            }

            WeixinDataHelper reverseInput = new WeixinDataHelper(this._weixinKey);
            reverseInput.SetValue("out_trade_no", out_trade_no);
            WeixinDataHelper result = weixinPayApi.Reverse(reverseInput);

            //接口调用失败
            if (result.GetValue("return_code").ToString() != "SUCCESS")
            {
                return false;
            }

            //如果结果为success且不需要重新调用撤销，则表示撤销成功
            if (result.GetValue("result_code").ToString() != "SUCCESS" && result.GetValue("recall").ToString() == "N")
            {
                return true;
            }
            else if (result.GetValue("recall").ToString() == "Y")
            {
                return Cancel(out_trade_no, ++depth);
            }
            return false;
        }
        #endregion
    }
}
