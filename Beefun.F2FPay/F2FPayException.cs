using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beefun.F2FPay
{
    /// <summary>
    /// 面对面支付模块异常
    /// </summary>
    public class F2FPayException : Exception
    {
        public F2FPayException(string message) : base(message)
        {
            
        }

        public F2FPayException(string message,Exception e)
            : base(message,e)
        {

        }
    }
}
