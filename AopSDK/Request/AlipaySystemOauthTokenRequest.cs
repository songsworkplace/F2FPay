using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.system.oauth.token
    /// </summary>
    public class AlipaySystemOauthTokenRequest : IAopRequest<AlipaySystemOauthTokenResponse>
    {
        /// <summary>
        /// 授权码，用户对应用授权后得到。
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 获取访问令牌的类型，authorization_code表示用授权码换，refresh_token表示用刷新令牌来换。
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// 刷新令牌，上次换取访问令牌时得到。
        /// </summary>
        public string RefreshToken { get; set; }

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
            return "alipay.system.oauth.token";
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
            parameters.Add("code", this.Code);
            parameters.Add("grant_type", this.GrantType);
            parameters.Add("refresh_token", this.RefreshToken);
            return parameters;
        }

        #endregion
    }
}
