using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.merchant.ticket.use
    /// </summary>
    public class AlipayMerchantTicketUseRequest : IAopRequest<AlipayMerchantTicketUseResponse>
    {
        /// <summary>
        /// 业务请求的标识信息
        /// </summary>
        public string BizInfo { get; set; }

        /// <summary>
        /// 红包发放者商户信息，json格式。商户可以传自己的PID，平台商可以传其它商户的PID用于查询指定商户的信息  目前仅支持如下key：  unique：商户唯一标识  unique_type：支持以下1种取值。    PID：商户所在平台商的partner id[唯一]
        /// </summary>
        public string MerchantInfo { get; set; }

        /// <summary>
        /// 商户券的券码，用于标识一张券
        /// </summary>
        public string TicketCode { get; set; }

        #region IAopRequest Members
        private string apiVersion = "1.0";
		private string terminalType;
		private string terminalInfo;
        private string prodCode;
		private string notifyUrl;

		public void SetNotifyUrl(string notifyUrl){
            this.notifyUrl = notifyUrl;
        }

        public string GetNotifyUrl(){
            return this.notifyUrl;
        }

        public void SetTerminalType(String terminalType){
			this.terminalType=terminalType;
		}

    	public string GetTerminalType(){
    		return this.terminalType;
    	}

    	public void SetTerminalInfo(String terminalInfo){
    		this.terminalInfo=terminalInfo;
    	}

    	public string GetTerminalInfo(){
    		return this.terminalInfo;
    	}

        public void SetProdCode(String prodCode){
            this.prodCode=prodCode;
        }

        public string GetProdCode(){
            return this.prodCode;
        }

        public string GetApiName()
        {
            return "alipay.merchant.ticket.use";
        }

        public void SetApiVersion(string apiVersion){
            this.apiVersion=apiVersion;
        }

        public string GetApiVersion(){
            return this.apiVersion;
        }

        public IDictionary<string, string> GetParameters()
        {
            AopDictionary parameters = new AopDictionary();
            parameters.Add("biz_info", this.BizInfo);
            parameters.Add("merchant_info", this.MerchantInfo);
            parameters.Add("ticket_code", this.TicketCode);
            return parameters;
        }

        #endregion
    }
}
