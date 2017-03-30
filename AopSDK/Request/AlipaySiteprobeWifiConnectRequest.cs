using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.siteprobe.wifi.connect
    /// </summary>
    public class AlipaySiteprobeWifiConnectRequest : IAopRequest<AlipaySiteprobeWifiConnectResponse>
    {
        /// <summary>
        /// 是否已认证
        /// </summary>
        public Nullable<bool> Auth { get; set; }

        /// <summary>
        /// wifi对应设备的编号
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// wifi设备的mac地址
        /// </summary>
        public string DeviceMac { get; set; }

        /// <summary>
        /// 合作商户的分店ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 分配和合作方的id
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// 上网的令牌，和用户设备mac有一对一的关系
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 连接wifi的设备的mac地址
        /// </summary>
        public string UserMac { get; set; }

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
            return "alipay.siteprobe.wifi.connect";
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
            parameters.Add("auth", this.Auth);
            parameters.Add("device_id", this.DeviceId);
            parameters.Add("device_mac", this.DeviceMac);
            parameters.Add("merchant_id", this.MerchantId);
            parameters.Add("partner_id", this.PartnerId);
            parameters.Add("token", this.Token);
            parameters.Add("user_mac", this.UserMac);
            return parameters;
        }

        #endregion
    }
}
