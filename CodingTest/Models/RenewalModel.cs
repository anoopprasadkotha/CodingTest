using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTest.Models
{
    public class RenewalModel
    {
        /// <summary>
        ///gets or sets member details
        /// </summary>
        public CustomerDetails MemberDetails { get; set; }
        /// <summary>
        ///gets or sets CreditCharge
        /// </summary>
        public string CreditCharge { get; set; }
        /// <summary>
        ///gets or sets TotalPremium
        /// </summary>
        public string TotalPremium { get; set; }
        /// <summary>
        ///gets or sets AverageMonthlyPremium
        /// </summary>
        public string AverageMonthlyPremium { get; set; }
        /// <summary>
        ///gets or sets IntialMonthlyPremium
        /// </summary>
        public Double IntialMonthlyPremium { get; set; }
        /// <summary>
        ///gets or sets RemainingMonthlyPremium
        /// </summary>
        public string RemainingMonthlyPremium { get; set; }
    }
}