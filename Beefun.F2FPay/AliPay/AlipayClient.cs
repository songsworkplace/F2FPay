using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aop.Api;

namespace Common.F2FPay.AliPay
{
    public class AlipayClient
    {
        private static IAopClient client = null;

        public static IAopClient CreateInstance()
        {
            if (client == null)
            {
                var config = AlipayConfig.CreateInstance();
                client = new DefaultAopClient(config.ServerUrl, config.AppId, config.RsaPrivateKey, "json", config.Version,
            config.SignType, config.AlipayRsaPublicKey, config.Charset);
            }
            return client;
        }
    }
}
