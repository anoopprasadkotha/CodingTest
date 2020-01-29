using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingTest.Models
{
    /// <summary>
    /// Member Details from the excel file 
    /// </summary>
    public class CustomerDetails
    {
        //need to add validations

        public int Id { get; set; }
     
        public string Title { get; set; }
      
        public string FirstName { get; set; }
    
        public string SurName { get; set; }

        public string ProductName { get; set; }

        public Double PayoutAmount { get; set; }

        public Double AnnualPremium { get; set; }


    }
    
}