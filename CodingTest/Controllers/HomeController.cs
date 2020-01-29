using CodingTest.Helper;
using CodingTest.Interface;
using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CodingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly  ICsvReader _csvReader ;

        public HomeController()
        {
            //using property injection need
            _csvReader = new CsvReader();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    //need to check and change if we should not use .csv
                    if (upload.FileName.EndsWith(".csv"))
                    {
                        //converting the ccsv file to datatable 
                        DataTable csvTable = _csvReader.ExcelToDataTable(upload);

                        //declaring variables
                        var IndividualMember = new ViewModel();
                        var searchParameters = new List<ViewModel>();
                        for (int i = 0; i < csvTable.Rows.Count; i++)
                        {
                            //used to bind the values and if the row is corrupted  
                            IndividualMember = ModelBinder.Bind(csvTable, i);

                            if ((IndividualMember != null))
                            {
                                searchParameters.Add(IndividualMember);
                            }

                        }

                        foreach (var customer in searchParameters)
                        {

                            GenerateFiles(customer);
                        }

                        return View(csvTable);
                    }
                    else
                    {
                        // displays error if differnt format file is 
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    // displays error if upload 
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }


        /// <summary>
        /// Generate file for individual member
        /// </summary>
        /// <param name="viewModel"></param>
        private void GenerateFiles(ViewModel viewModel)
        {
            // Read the Letter text rom the Content Folder
           var letterStream= FileOperationsHelper.ReadFromTemplate();

            //formating the letter for individual Member
           var formatedLetter=  GenericHelper.FormattingFile(viewModel,letterStream);

            //Store te file in location
            FileOperationsHelper.CreateFile(viewModel,formatedLetter.ToString());
        }



        
    }
}