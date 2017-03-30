using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.F2FPay.AliPay.Model;

namespace Common.F2FPay.AliPay.Domain
{
    public class AlipayTradeBarcodeDTO : AlipayDTO
    {
        
        public string out_trade_no {get;set;}
        public string scene { get; set; }
        public string auth_code { get; set; }
        public string total_amount { get; set; }
        public string subject { get; set; }

        public string body { get; set; }
        public string operator_id { get; set; }

        public string store_id { get; set; }

        public string terminal_id { get; set; }

        public string timeout_express { get; set; }

    }
}
