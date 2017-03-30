using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Beefun.F2FPay.AliPay
{
    public class AlipayConfig
    {
        //public static string alipay_public_key = HttpRuntime.AppDomainAppPath.ToString() + "Demo\\alipay_rsa_public_key.pem";
        ////这里要配置没有经过PKCS8转换的原始私钥
        //public static string merchant_private_key = HttpRuntime.AppDomainAppPath.ToString() + "Demo\\rsa_private_key.pem";
        //public static string merchant_public_key = HttpRuntime.AppDomainAppPath.ToString() + "Demo\\rsa_public_key.pem";
        //public static string appId = "2016052501441139";//此处请填写你当面付的APPID
        //public static string serverUrl = "https://openapi.alipay.com/gateway.do";
        //public static string mapiUrl = "https://mapi.alipay.com/gateway.do";
        //public static string monitorUrl = "http://mcloudmonitor.com/gateway.do";
        //public static string pid = "2088102584577711";//此处请填写你的PID（partner）


        //public static string charset = "utf-8";//"utf-8";
        //public static string sign_type = "RSA";
        //public static string version = "1.0";
        //private string _rsakeypath = HttpRuntime.AppDomainAppPath.ToString() + "bin\\AliPay\\RSAkey\\";
        private string _rsakeypath = "";
        public string AppId { get { return this.Items["appid"]; } }
        public string Pid { get { return this.Items["pid"]; } }
        public string Charset { get { return this.Items["charset"]; } }

        public string SignType { get { return this.Items["sign_type"]; } }

        public string Version { get { return this.Items["version"]; } }

        public string ServerUrl { get { return this.Items["serverUrl"]; } }

        public string AlipayRsaPublicKey { get { return this._rsakeypath + this.Items["alipay_rsa_public_key"]; } }

        public string RsaPrivateKey { get { return this._rsakeypath + this.Items["rsa_private_key"]; } }

        public string RedirectUri { get { return this.Items["redirectUri"]; } }
        //public static string getMerchantPublicKeyStr()
        //{
        //    StreamReader sr = new StreamReader(merchant_public_key);
        //    string pubkey = sr.ReadToEnd();
        //    sr.Close();
        //    if (pubkey != null)
        //    {
        //        pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
        //        pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
        //        pubkey = pubkey.Replace("\r", "");
        //        pubkey = pubkey.Replace("\n", "");
        //    }
        //    return pubkey;
        //}

        //public static string getMerchantPriveteKeyStr()
        //{
        //    StreamReader sr = new StreamReader(merchant_private_key);
        //    string pubkey = sr.ReadToEnd();
        //    sr.Close();
        //    if (pubkey != null)
        //    {
        //        pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
        //        pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
        //        pubkey = pubkey.Replace("\r", "");
        //        pubkey = pubkey.Replace("\n", "");
        //    }
        //    return pubkey;
        //}


        private static string _fileName = "AliPay\\alipayconfig.xml";
        private static AlipayConfig config = null;
        private static object _lock = new Object();
        private ReadXmlConfigHelper _readXml = null;
        private AlipayConfig()
        {
            _readXml = new ReadXmlConfigHelper(_fileName);
        }
        /// <summary>
        /// 文件时间
        /// </summary>
        public DateTime RecordFileTime { get { return _readXml.GetFileCreateTime(); } }
        /// <summary>
        /// 配置项数据集
        /// </summary>
        public Dictionary<string,string> Items { get { return this._readXml.ReadXmlConfig(); }}

        /// <summary>
        /// 单例初始
        /// </summary>
        /// <returns></returns>
        public static AlipayConfig CreateInstance()
        {
            if (config == null)
            {
                lock (_lock)
                {
                    config = new AlipayConfig();
                }
            }
            else
            {
                ReadXmlConfigHelper readXml = new ReadXmlConfigHelper(_fileName);
                if (readXml.GetFileCreateTime() != config.RecordFileTime)
                {
                    config = new AlipayConfig();
                }
            }
            return config;
        }
       
    }
}
