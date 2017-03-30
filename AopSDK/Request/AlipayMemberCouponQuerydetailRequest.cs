using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.member.coupon.querydetail
    /// </summary>
    public class AlipayMemberCouponQuerydetailRequest : IAopRequest<AlipayMemberCouponQuerydetailResponse>
    {
        /// <summary>
        /// 红包编号
        /// </summary>
        public string CouponNo { get; set; }

        /// <summary>
        /// 红包发放者商户信息，json格式。商户可以传自己的PID，平台商可以传其它商户的PID用于查询指定商户的信息  目前仅支持如下key：   unique：商户唯一标识   unique_type：支持以下1种取值。  PID：商户所在平台商的partner id[唯一]
        /// </summary>
        public string MerchantInfo { get; set; }

        /// <summary>
        /// 劵所有者买家用户信息，必须是支付宝的用户，json格式。  目前仅支持如下key：   unique：用户唯一标识   unique_type：支持以下1种取值。  UID：用户支付宝账户的唯一ID  OPENID：用户支付宝账户在某商户下的唯一ID
        /// </summary>
        public string UserInfo { get; set; }

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
            return "alipay.member.coupon.querydetail";
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
            parameters.Add("coupon_no", this.CouponNo);
            parameters.Add("merchant_info", this.MerchantInfo);
            parameters.Add("user_info", this.UserInfo);
            return parameters;
        }

        #endregion
    }
}
