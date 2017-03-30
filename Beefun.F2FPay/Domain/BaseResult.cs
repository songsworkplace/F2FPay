using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api;
using WeiXinPaySDK;

namespace Common.F2FPay.Domain
{
    public abstract class BaseResult
    {
        private string _apiType = "";
        private string _responsebody = "";
        private bool? _isError;
        private string _errMsg = "";
        private string _errCode = "";
        private string _requestUrl = "";
        private string _httpMethod = "";
        private string _elapsedTime = "0ms";
        private string _requestContent = "";
        /// <summary>
        /// 请求结果值
        /// </summary>
        public bool IsError
        {
            get
            {
                if (!_isError.HasValue)
                {
                    throw new F2FPayException("未设置接口类型（IsError）数据，在BaseResult类中");
                }
                return _isError.Value;
            }
        }

        /// <summary>
        /// 错误编码
        /// </summary>
        public string ErrCode { get { return _errCode; } }

        /// <summary>
        /// 请求结果错误内容
        /// </summary>
        public string ErrMessage
        {
            get { return _errMsg; }
        }

        /// <summary>
        /// 请求返回结果
        /// </summary>
        public string ResponseBody
        {
            get
            {
                if (string.IsNullOrEmpty(_responsebody))
                {
                    throw new F2FPayException("未设置接口类型（ResponseBody）数据，在BaseResult类中");
                }
                return _responsebody;
            }
        }

        /// <summary>
        /// 接口类型，alipay,weixin
        /// </summary>
        public string ApiType
        {
            get
            {
                if (string.IsNullOrEmpty(_apiType))
                {
                    throw new F2FPayException("未设置接口类型（ApiType）数据，在BaseResult类中");
                }
                return _apiType;
            }
        }

        /// <summary>
        /// http请求
        /// </summary>
        public string RequestUrl { get { return _requestUrl; } }
        
        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpMethod { get { return this._httpMethod; } }
        /// <summary>
        /// 耗费时间
        /// </summary>
        public string ElapsedTime { get { return this._elapsedTime; } }
        /// <summary>
        /// 请求内容
        /// </summary>
        public string RequestContent { get { return this._requestContent; } }
        /// <summary>
        /// 微信设置
        /// </summary>
        /// <param name="response"></param>
        public virtual void SetWeixiResult(WeixinDataHelper response)
        {
            var returnCode = !response.IsSet("return_code") || response.GetValue("return_code").ToString() == "FAIL" ? "FAIL" : response.GetValue("return_code").ToString();
            var resultCode =!response.IsSet("result_code") || response.GetValue("result_code").ToString() == "FAIL" ? "FAIL":response.GetValue("result_code").ToString();


            var isSuccess = returnCode.ToUpper().Contains("SUCCESS") && resultCode.ToUpper().Contains("SUCCESS");

            this._isError = !isSuccess;
            this._errCode = response.IsSet("err_code") ? response.GetValue("err_code").ToString() : "";

            if (!isSuccess)
            {
                var errMsg = response.IsSet("return_msg") ? response.GetValue("return_msg").ToString() : ""; 
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = response.IsSet("err_code_des") ? response.GetValue("err_code_des").ToString() : "";
                }
                this._errMsg=errMsg;
            }
            this._responsebody = response.ToJson();
            this._apiType = "weixinpay";
            this._requestUrl = response.IsSet("requestUrl") ? response.GetValue("requestUrl").ToString() : "";
            this._elapsedTime = response.IsSet("elapsedTime") ? response.GetValue("elapsedTime").ToString() : "";
            this._httpMethod = response.IsSet("httpMethod") ? response.GetValue("httpMethod").ToString() : "";
            this._requestContent = response.IsSet("requestContent") ? response.GetValue("requestContent").ToString() : ""; 

        }
        /// <summary>
        /// 支付宝结果设置
        /// </summary>
        /// <param name="response"></param>
        public virtual void SetAlipayResult<T>(T response) where T : AopResponse
        {
            this._isError = response.IsError;
            this._errCode = string.Format("{0}-{1}",response.Code,response.SubCode);
            this._errMsg =string.Format("{0}-{1}",response.Msg, response.SubMsg);
            this._responsebody = response.Body;
            this._apiType = "alipay";
            this._requestUrl = response.RequestUrl;
            this._elapsedTime = response.ElapsedTime;
            this._httpMethod = response.HttpMethod;
            this._requestContent = response.RequestContent;
        }
    }
}
