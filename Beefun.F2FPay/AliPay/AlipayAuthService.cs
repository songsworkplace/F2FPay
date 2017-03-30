using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Beefun.F2FPay.AliPay.Domain;

namespace Beefun.F2FPay.AliPay
{
    /// <summary>
    /// 支付宝授权服务
    /// https://doc.open.alipay.com/doc2/detail.htm?treeId=115&articleId=104110&docType=1
    /// </summary>
    public class AlipayAuthService
    {
        IAopClient client= AlipayClient.CreateInstance();
        private  AlipayConfig config= AlipayConfig.CreateInstance();
        /// <summary>
        /// 获取授权链接
        /// </summary>
        /// <param name="redirectUri"></param>
        /// <returns></returns>
        public string GetAuthUri(string redirectUri)
        {
            var authuri = new StringBuilder("https://openauth.alipay.com/oauth2/appToAppAuth.htm?");
            authuri.AppendFormat("app_id={0}", config.AppId);
            authuri.AppendFormat("&redirect_uri={0}", redirectUri);
            return authuri.ToString();
        }
        /// <summary>
        /// 获取授权码
        /// 当使用app_auth_code换取app_auth_token时，biz_content的内容如下：
        ///{
        ///    "grant_type": "authorization_code",
        ///    "code": "bf67d8d5ed754af297f72cc482287X62"
        ///}
        /// 当要刷新app_auth_token时，需要使用refresh_token，biz_content的内容如下：
        ///{
        ///    "grant_type": "refresh_token",
        ///    "refresh_token": "201510BB0c409dd5758b4d939d4008a525463X62"
        ///}
        /// </summary>
        /// <returns></returns>
        public AlipayOpenAuthTokenAppResponse OpenAuthTokenApp(OpenAuthTokenAppDTO dto)
        {
            AlipayOpenAuthTokenAppRequest request = new AlipayOpenAuthTokenAppRequest();
            request.BizContent = dto.BuildJson();
            AlipayOpenAuthTokenAppResponse response = client.Execute(request);
            return response;
        }
    }
}
