using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.F2FPay.AliPay.Domain
{
    public class OpenAuthTokenAppDTO:AlipayDTO
    {
        public string grant_type { get; set; }
        public string code { get; set; }
        public string refresh_token { get; set; }
    }
}
