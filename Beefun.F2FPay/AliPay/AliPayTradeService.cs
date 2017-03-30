using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Beefun.F2FPay.AliPay.Domain;
using Beefun.F2FPay.AliPay.Model;
using Beefun.F2FPay.Domain;

namespace Beefun.F2FPay.AliPay
{
    public class AliPayTradeService : IF2FTradeService
    {


        IAopClient client = null;
        //private string _appId = "";
        private string _authToken = "";

        public AliPayTradeService()
        {
            client = AlipayClient.CreateInstance();

        }


        //public string AppId
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(this._appId))
        //        {
        //            throw new F2FPayException("未设置AppId");
        //        }
        //        return _appId;
        //    }
        //}



        #region 内部方法
        /// <summary>
        /// 1.返回支付处理中，轮询订单状态
        /// 2.本示例中轮询了6次，每次相隔5秒
        /// </summary>
        /// <param name="biz_content"></param>
        /// <returns></returns>
        private AlipayTradeQueryResponse LoopQuery(string out_trade_no, int count, int interval)
        {
            AlipayTradeQueryResponse queryResult = null;

            for (int i = 1; i <= count; i++)
            {
                Thread.Sleep(interval);
                AlipayTradeQueryResponse queryResponse = sendTradeQuery(out_trade_no);
                if (queryResponse != null && string.Compare(queryResponse.Code, ResultCode.SUCCESS, false) == 0)
                {
                    queryResult = queryResponse;
                    if (queryResponse.TradeStatus == "TRADE_FINISHED"
                        || queryResponse.TradeStatus == "TRADE_SUCCESS"
                        || queryResponse.TradeStatus == "TRADE_CLOSED")
                        return queryResponse;
                }
            }

            return queryResult;

        }


        private AlipayTradeQueryResponse sendTradeQuery(string outTradeNo)
        {
            try
            {
                AliPayTradeQueryDTO build = new AliPayTradeQueryDTO();
                build.out_trade_no = outTradeNo;
                AlipayTradeQueryRequest payRequest = new AlipayTradeQueryRequest();
                payRequest.BizContent = build.BuildJson();
                AlipayTradeQueryResponse payResponse = Execute(payRequest);
                return payResponse;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 撤销订单
        /// </summary>
        /// <param name="out_trade_no"></param>
        /// <returns></returns>
        private AlipayTradeCancelResponse CancelAndRetry(string out_trade_no)
        {
            AlipayTradeCancelResponse cancelResponse = null;

            cancelResponse = tradeCancel(out_trade_no);

            //如果撤销失败，新开一个线程重试撤销，不影响主业务
            if (cancelResponse == null || (cancelResponse.Code == ResultCode.FAIL && cancelResponse.RetryFlag == "Y"))
            {
                throw new F2FPayException("订单撤销失败，需人工介入。");
                //todo 这里需要优化
                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(cancelThreadFunc);
                Thread myThread = new Thread(ParStart);
                object o = out_trade_no;
                myThread.Start(o);
            }
            return cancelResponse;
        }
        private AlipayTradeCancelResponse tradeCancel(string outTradeNo)
        {
            try
            {
                AlipayTradeCancelRequest request = new AlipayTradeCancelRequest();
                StringBuilder sb2 = new StringBuilder();
                sb2.Append("{\"out_trade_no\":\"" + outTradeNo + "\"}");
                request.BizContent = sb2.ToString();
                AlipayTradeCancelResponse response = Execute(request);
                return response;
            }
            catch
            {
                return null;
            }

        }

        private void cancelThreadFunc(object o)
        {
            int RETRYCOUNT = 10;
            int INTERVAL = 10000;

            for (int i = 0; i < RETRYCOUNT; ++i)
            {

                Thread.Sleep(INTERVAL);
                AlipayTradeCancelRequest cancelRequest = new AlipayTradeCancelRequest();
                string outTradeNo = o.ToString();
                AlipayTradeCancelResponse cancelResponse = tradeCancel(outTradeNo);

                if (null != cancelResponse)
                {
                    if (cancelResponse.Code == ResultCode.FAIL)
                    {
                        if (cancelResponse.RetryFlag == "N")
                        {
                            break;
                        }
                    }
                    if ((cancelResponse.Code == ResultCode.SUCCESS))
                    {
                        break;
                    }
                }

                if (i == RETRYCOUNT - 1)
                {
                    /** ！！！！！！！注意！！！！！！！！todo
                    处理到最后一次，还是未撤销成功，需要在商户数据库中对此单最标记，人工介入处理*/
                }

            }
        }

        private AlipayTradePayResponse toTradePayResponse(AlipayTradeQueryResponse queryResponse)
        {
            if (queryResponse == null || queryResponse.Code != ResultCode.SUCCESS)
                return null;
            AlipayTradePayResponse payResponse = new AlipayTradePayResponse();

            if (queryResponse.TradeStatus == TradeStatus.WAIT_BUYER_PAY)
            {
                payResponse.Code = ResultCode.INRROCESS;
            }
            if (queryResponse.TradeStatus == TradeStatus.TRADE_FINISHED
                || queryResponse.TradeStatus == TradeStatus.TRADE_SUCCESS)
            {
                payResponse.Code = ResultCode.SUCCESS;
            }
            if (queryResponse.TradeStatus == TradeStatus.TRADE_CLOSED)
            {
                payResponse.Code = ResultCode.FAIL;
            }

            payResponse.Msg = queryResponse.Msg;
            payResponse.SubCode = queryResponse.SubCode;
            payResponse.SubMsg = queryResponse.SubMsg;
            payResponse.Body = queryResponse.Body;
            payResponse.BuyerLogonId = queryResponse.BuyerLogonId;
            payResponse.FundBillList = queryResponse.FundBillList;
            payResponse.OpenId = queryResponse.OpenId;
            payResponse.OutTradeNo = queryResponse.OutTradeNo;
            payResponse.ReceiptAmount = queryResponse.ReceiptAmount;
            payResponse.TotalAmount = queryResponse.TotalAmount;
            payResponse.TradeNo = queryResponse.TradeNo;


            return payResponse;


        }

        #endregion

        #region 接口方法实现

        public void SetAuthToken(string authToken)
        {
            _authToken = authToken;
        }

        public string AuthToken
        {
            get
            {
                //if (string.IsNullOrEmpty(_authToken))
                //{
                //    throw new F2FPayException("支付宝未授权");
                //}
                return _authToken;
            }
        }

        private T Execute<T>(IAopRequest<T> request) where T : AopResponse
        {
            if (string.IsNullOrEmpty(AuthToken))
            {
                return client.Execute(request);
            }
            return client.Execute(request, null, AuthToken);
        }
        /// <summary>
        /// 扫码支付
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public OrderPayResult OrderPay(OrderPayDTO dto)
        {
            OrderPayResult result = new OrderPayResult();
            try
            {
                AlipayTradeBarcodeDTO barcodeDto = new AlipayTradeBarcodeDTO();
                barcodeDto.out_trade_no = dto.OutTradeNo;
                barcodeDto.operator_id = dto.OperatorId;
                barcodeDto.auth_code = dto.AuthCode;
                barcodeDto.scene = "bar_code";
                barcodeDto.total_amount = dto.TotalAmount;
                barcodeDto.subject = dto.Title;
                barcodeDto.body = dto.Body;
                barcodeDto.store_id = dto.StoreId;
                barcodeDto.terminal_id = dto.TerminalId;
                barcodeDto.timeout_express = "30m";//限制30分钟内完成付款

                AlipayTradePayRequest payRequest = new AlipayTradePayRequest();
                payRequest.BizContent = barcodeDto.BuildJson();
                AlipayTradePayResponse payResponse =Execute(payRequest);

                if (payResponse != null)
                {

                    switch (payResponse.Code)
                    {
                        case ResultCode.SUCCESS:
                            break;

                        //返回支付处理中，需要进行轮询
                        case ResultCode.INRROCESS:

                            AlipayTradeQueryResponse queryResponse = LoopQuery(barcodeDto.out_trade_no, 10, 3000);   //用订单号trade_no进行轮询也是可以的。
                            //轮询结束后还是支付处理中，需要调撤销接口
                            if (queryResponse != null)
                            {
                                if (queryResponse.TradeStatus == "WAIT_BUYER_PAY")
                                {
                                    CancelAndRetry(barcodeDto.out_trade_no);
                                    queryResponse.Code = ResultCode.FAIL;
                                    queryResponse.SubMsg = payResponse.SubMsg+"(等待时间过长，已经撤销支付订单)";
                                }
                                payResponse = toTradePayResponse(queryResponse);
                            }
                            break;

                        //明确返回业务失败
                        case ResultCode.FAIL:
                            break;

                        //返回系统异常，需要调用一次查询接口，没有返回支付成功的话调用撤销接口撤销交易
                        case ResultCode.ERROR:

                            AlipayTradeQueryResponse queryResponse2 = sendTradeQuery(barcodeDto.out_trade_no);

                            if (queryResponse2 != null)
                            {

                                if (queryResponse2.TradeStatus == TradeStatus.WAIT_BUYER_PAY)
                                {
                                    AlipayTradeCancelResponse cancelResponse = CancelAndRetry(barcodeDto.out_trade_no);
                                    queryResponse2.Code = ResultCode.FAIL;
                                    queryResponse2.SubMsg = payResponse.SubMsg + "(等待时间过长，已经撤销支付订单)";
                                }
                                payResponse = toTradePayResponse(queryResponse2);
                            }
                            break;

                        default:
                            break;
                    }
                    result.SetAlipayResult(payResponse);
                    return result;
                }
                else
                {
                    AlipayTradeQueryResponse queryResponse3 = sendTradeQuery(barcodeDto.out_trade_no);
                    if (queryResponse3 != null)
                    {
                        if (queryResponse3.TradeStatus == TradeStatus.WAIT_BUYER_PAY)
                        {
                            AlipayTradeCancelResponse cancelResponse = CancelAndRetry(barcodeDto.out_trade_no);
                            queryResponse3.Code = ResultCode.FAIL;
                        }
                        payResponse = toTradePayResponse(queryResponse3);
                    }
                    result.SetAlipayResult(payResponse);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new F2FPayException(e.Message,e);
            }
        }

        public OrderQueryResult OrderQuery(OrderQueryDTO dto)
        {
            OrderQueryResult result = new OrderQueryResult();
            try
            {
                AliPayTradeQueryDTO queryDto = new AliPayTradeQueryDTO();
                queryDto.trade_no = dto.OnlineTradeNo;
                queryDto.out_trade_no = dto.OutTradeNo;
                AlipayTradeQueryRequest payRequest = new AlipayTradeQueryRequest();
                payRequest.BizContent = queryDto.BuildJson();
                AlipayTradeQueryResponse response = Execute(payRequest);
                result.SetAlipayResult(response);
                return result;
            }
            catch (Exception e)
            {
                throw new F2FPayException(e.Message);
            }
        }
        /// <summary>
        /// 退款申请
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RefundResult Refund(RefundDTO dto)
        {
            RefundResult result = new RefundResult();
            try
            {
                AlipayTradeRefundDTO refundDto = new AlipayTradeRefundDTO();
                refundDto.out_request_no = dto.OutRefundNo;
                refundDto.out_trade_no = dto.OutTradeNo;
                refundDto.refund_amount = dto.RefundFee;
                refundDto.refund_reason = dto.RefundReason;
                refundDto.trade_no = dto.OnlineTradeNo;
                AlipayTradeRefundRequest refundRequest = new AlipayTradeRefundRequest();
                refundRequest.BizContent = refundDto.BuildJson();
                AlipayTradeRefundResponse response = Execute(refundRequest);
                result.SetAlipayResult(response);
                return result;
            }
            catch (Exception e)
            {
                throw new F2FPayException(e.Message);
            }
        }
        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RefundQueryResult RefundQuery(RefundDTO dto)
        {
            AlipayTradeRefundQueryDTO refundQueryDto = new AlipayTradeRefundQueryDTO();
            refundQueryDto.trade_no = dto.OnlineTradeNo;
            refundQueryDto.out_trade_no = dto.OutTradeNo;
            refundQueryDto.out_request_no = dto.OutRefundNo;

            AlipayTradeFastpayRefundQueryRequest request = new AlipayTradeFastpayRefundQueryRequest();
            request.BizContent = refundQueryDto.BuildJson();
            AlipayTradeFastpayRefundQueryResponse response = Execute(request);

            var result = new RefundQueryResult();
            result.SetAlipayResult(response);

            return result;
        }
       

        #endregion
    }
}
