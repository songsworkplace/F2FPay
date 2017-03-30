using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinPaySDK
{
    public class WeixinPayException:Exception
    {
        public WeixinPayException(string message) : base(message)
        {
            
        }
    }
}
