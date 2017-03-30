using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AliTrustRiskARUser Data Structure.
    /// </summary>
    [Serializable]
    public class AliTrustRiskARUser : AopObject
    {
        /// <summary>
        /// 担保方式
        /// </summary>
        [XmlElement("assure_type")]
        public string AssureType { get; set; }

        /// <summary>
        /// 加入黑名单原因
        /// </summary>
        [XmlElement("black_reason")]
        public string BlackReason { get; set; }

        /// <summary>
        /// 加入黑名单时间
        /// </summary>
        [XmlElement("create_time_string")]
        public string CreateTimeString { get; set; }

        /// <summary>
        /// 现住址
        /// </summary>
        [XmlElement("current_place")]
        public string CurrentPlace { get; set; }

        /// <summary>
        /// 借款人姓名
        /// </summary>
        [XmlElement("customer_name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// 是否在安融风险名单
        /// </summary>
        [XmlElement("is_black")]
        public bool IsBlack { get; set; }

        /// <summary>
        /// 最后一次逾期日期
        /// </summary>
        [XmlElement("lastoverdate")]
        public string Lastoverdate { get; set; }

        /// <summary>
        /// 借款地点
        /// </summary>
        [XmlElement("loan_address")]
        public string LoanAddress { get; set; }

        /// <summary>
        /// 借款开始日期
        /// </summary>
        [XmlElement("loan_start_date")]
        public string LoanStartDate { get; set; }

        /// <summary>
        /// 借款类型
        /// </summary>
        [XmlElement("loan_type")]
        public string LoanType { get; set; }

        /// <summary>
        /// 最长逾期天数
        /// </summary>
        [XmlElement("max_days")]
        public string MaxDays { get; set; }

        /// <summary>
        /// 户籍地址
        /// </summary>
        [XmlElement("native_place")]
        public string NativePlace { get; set; }

        /// <summary>
        /// 逾期期数
        /// </summary>
        [XmlElement("over_count")]
        public string OverCount { get; set; }

        /// <summary>
        /// 借款人身份证号
        /// </summary>
        [XmlElement("paper_number")]
        public string PaperNumber { get; set; }

        /// <summary>
        /// 黑名单来源
        /// </summary>
        [XmlElement("source_organ")]
        public string SourceOrgan { get; set; }

        /// <summary>
        /// 欠款总额
        /// </summary>
        [XmlElement("sum_money")]
        public string SumMoney { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [XmlElement("telephone")]
        public string Telephone { get; set; }
    }
}
