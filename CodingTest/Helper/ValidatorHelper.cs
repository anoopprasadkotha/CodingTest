//using CodingTest.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Web;

//namespace CodingTest.Helper
//{
//    public static class ValidatorHelper
//    {
//        public static bool ValidateCustomerDetails(CustomerDetails model)
//        {
//            bool IsValid;
//            IsValid = ValidateNumberData(model.Id)

//        }

//        public static bool ValidateStringData(string value)
//        {
//            bool isValid = false;
//            if (value != null && value != "")
//            {
//                isValid = true;
//            }
//            if (value.Length > 2 && value.Length < 100)
//            {
//                isValid = isValid && true;
//            }

//            return isValid;
//        }

//        public static bool ValidateNumberData(string value)
//        {
//            var numericPattern = new Regex("^[0-9]+$");
//            bool isValid = false;
//            if (value != null && value != "")
//            {
//                isValid = true;
//            }

//            return isValid && numericPattern.IsMatch(value);
//        }

//        public static bool ValidateFloatNumberData(string value)
//        {
//            var numericPattern = new Regex("^[.][0-9]+$|[0-9].[0-9]+$");
//            bool isValid = false;
//            if (value != null && value != "")
//            {
//                isValid = true;
//            }

//            return isValid && numericPattern.IsMatch(value);
//        }

//    }
//}