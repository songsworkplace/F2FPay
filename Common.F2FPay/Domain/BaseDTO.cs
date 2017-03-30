using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.F2FPay.Domain
{
    public abstract class BaseDTO
    {
        /// <summary>
        /// 操作员编号，注：支付宝-operator_id string(30),微信-op_user_id string(32)
        /// </summary>
        public string OperatorId { get; set; }
    }
}
