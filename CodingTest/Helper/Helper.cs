using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CodingTest.Helper
{
    public class GenericHelper
    {

        #region Constants
        private const string Date = "{The current date}";
        private const string ToNameFieldValue = "{customer’s full name including Title}";
        private const string DearNameFieldvalue = "{customer’s Title followed by Surname}";
        private const string ProductName = "{Product Name}";
        private const string AnnualPremium = "{Annual Premium}";
        private const string CreditCharge = "{Credit Charge}";
        private const string Payout = "{Payout Amount}";
        private const string IntialMonthly = "{Initial Monthly Payment Amount}";
        private const string OtherPayment = "{Other Monthly Payments Amount}"; 
        #endregion

        /// <summary>
        /// Calculate the variables for a member for a given annual premium.
        /// </summary>
        /// <param name="annualPremium"></param>
        /// <returns></returns>
        // need to rename with a MeaningFullName
        public static RenewalModel CalculatePremiumVariables(Double annualPremium)
        {

           
            //credit charge calculation
            var creditCharge = RoundUp(annualPremium * .05, 2);

            var monthlyInst = ((creditCharge + annualPremium )/ 12).ToString("0.00");

            var totalAmount = RoundUp((creditCharge + annualPremium), 2);

            return new RenewalModel() { CreditCharge = RoundUp(annualPremium * .05, 2).ToString(),
                TotalPremium = RoundUp((creditCharge + annualPremium), 2).ToString(),
                AverageMonthlyPremium = ((creditCharge + annualPremium) / 12).ToString("0.00"),
                IntialMonthlyPremium = RoundUp(totalAmount - (11 * Convert.ToDouble(monthlyInst)),2),
                RemainingMonthlyPremium= (11 * Convert.ToDouble(monthlyInst)).ToString("0.00")
            };
        }

        /// <summary>
        /// Used for round Up to calculate upto req decimal places
        /// </summary>
        /// <param name="input"></param>
        /// <param name="places"></param>
        /// <returns></returns>
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }


        /// <summary>
        /// formatting the template with member details
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="File"></param>
        /// <returns></returns>
        public static string FormattingFile(ViewModel viewModel, StringBuilder File)
        {

            if (File.ToString().Contains(Date))
            {
                File = File.Replace(Date,string.Format("{0:d}", DateTime.Now.ToString("dd/MM/yyyy")));
            }
            if (File.ToString().Contains(ToNameFieldValue))
            {
                File = File.Replace(ToNameFieldValue, viewModel.MemberDetails.Title + " " + viewModel.MemberDetails.FirstName);
            }
            if (File.ToString().Contains(DearNameFieldvalue))
            {
                File = File.Replace(DearNameFieldvalue, viewModel.MemberDetails.Title + " " + viewModel.MemberDetails.SurName);
            }
            if (File.ToString().Contains(ProductName))
            {
                File = File.Replace(ProductName, viewModel.MemberDetails.ProductName);

            }
            if (File.ToString().Contains(AnnualPremium))
            {
                File = File.Replace(AnnualPremium, viewModel.MemberDetails.AnnualPremium.ToString());
            }
            if (File.ToString().Contains(CreditCharge))
            {
                File = File.Replace(CreditCharge, viewModel.RenewDetails.CreditCharge);
            }

            if (File.ToString().Contains(Payout))
            {
                File = File.Replace(Payout, viewModel.RenewDetails.TotalPremium);
            }

            if (File.ToString().Contains(IntialMonthly))
            {
                File = File.Replace(IntialMonthly, viewModel.RenewDetails.IntialMonthlyPremium.ToString());
            }

            if (File.ToString().Contains(OtherPayment))
            {
                File = File.Replace(OtherPayment, viewModel.RenewDetails.IntialMonthlyPremium.ToString());
            }

            return File.ToString();
        }

        ///

        public static bool ValidateStringData(string value)
        {
            bool isValid=false;
            if (value != null && value!= "")
            {
                isValid = true;
            }
            if (value.Length > 2 && value.Length < 100)
            {
                isValid = isValid && true;
            }

            return isValid;
        }

        public static bool ValidateNumberData(string value)
        {
            var numericPattern = new Regex("^[0-9]+$");
            bool isValid = false;
            if (value != null && value != "")
            {
                isValid = true;
            }

            return isValid && numericPattern.IsMatch(value);
        }

        public static bool ValidateFloatNumberData(string value)
        {
            var numericPattern = new Regex("^[.][0-9]+$|[0-9].[0-9]+$");
            bool isValid = false;
            if (value != null && value != "")
            {
                isValid = true;
            }
          
            return isValid && numericPattern.IsMatch(value);
        }

    }
}