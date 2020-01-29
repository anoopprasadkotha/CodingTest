using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTest.Models
{
    public class RenewalModel
    {

//        Credit Charge   An additional charge that applies when paying monthly by Direct Debit.  5% of the annual premium, rounded up to a whole number of pounds and pence.
//Total Premium(Direct Debit)    The total amount payable for the year when paying monthly by Direct Debit.The Annual Premium plus the Credit Charge.
//Average Monthly Premium The average amount payable per month when paying monthly by Direct Debit.The Total Premium (Direct Debit) divided by the number of months in a year.
//Initial Monthly Payment Amount  The amount of the first of the monthly payments.Will equal the Average Monthly Premium if that is a whole number of pounds and pence; otherwise will be higher.
//Other Monthly Payments Amount The amount of the other 11 monthly payments.	Will equal the Average Monthly Premium if that is a whole number of pounds and pence; otherwise will be lower.
    public CustomerDetails MemberDetails { get; set; }
        public string CreditCharge { get; set; }
        public string TotalPremium { get; set; }
        public string AverageMonthlyPremium { get; set; }
        public Double IntialMonthlyPremium { get; set; }
        public string RemainingMonthlyPremium { get; set; }
    }
}