using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CodingTest.Helper
{
    public static class ModelBinder
    {
        public static ViewModel Bind(DataTable csvTable, int i)
        {
            var viewModel = new ViewModel();
            if (ValidateRow(csvTable, i))
            {
                viewModel = new ViewModel()
                {
                    MemberDetils = new CustomerDetails
                    {
                        Id = Convert.ToInt32(RemoveAdditionalChars(csvTable.Rows[i][0].ToString())),
                        Title = RemoveAdditionalChars(csvTable.Rows[i][1].ToString()),
                        FirstName = RemoveAdditionalChars(csvTable.Rows[i][2].ToString()),
                        SurName = RemoveAdditionalChars(csvTable.Rows[i][3].ToString()),
                        ProductName = RemoveAdditionalChars(csvTable.Rows[i][4].ToString()),
                        PayoutAmount = Convert.ToDouble(RemoveAdditionalChars(csvTable.Rows[i][5].ToString())),
                        AnnualPremium = Convert.ToDouble(RemoveAdditionalChars(csvTable.Rows[i][6].ToString()))
                    },
                    RenewDetails = GenericHelper.CalculatePremiumVariables(Convert.ToDouble(csvTable.Rows[i][6]))
                };
            }
            else
            {
                viewModel = null;

            }
            return viewModel;
        }

        private static bool ValidateRow(DataTable csvTable, int i)
        {
            var str = new StringBuilder(String.Format("The data in the row{0} is not valid and fields which are not valid are ", i));

            bool isValid;
            int id;
            float premium;
            isValid = Int32.TryParse((csvTable.Rows[i][0].ToString()), out id);
            if (!Int32.TryParse((csvTable.Rows[i][0].ToString()), out id)) str.Append("ID");
            isValid = isValid && float.TryParse((csvTable.Rows[i][5].ToString()), out premium);
            if (!float.TryParse((csvTable.Rows[i][0].ToString()), out premium)) str.Append("PayoutAmount");
            isValid = isValid && float.TryParse((csvTable.Rows[i][6].ToString()), out premium);
            if (!float.TryParse((csvTable.Rows[i][6].ToString()), out premium)) str.Append("AnnualPremium");
            //after checking the data is invalid log  the stringbuilder in log
            if (!isValid)
            { }
            return isValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string RemoveAdditionalChars(string input)
        {
            if (input == null) input = "";
            return input.Contains("\n") ? input.Replace("\n", "") : input;

        }
    }
}