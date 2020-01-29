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
            ////using property injection need
            //_csvReader = new CsvReader();
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

                        //using (TextReader txt = new StreamReader(stream))
                        //{
                        //    using (var csv = new CsvReader(txt))
                        //    {
                        //        var records = csv.Ge
                        //            return records.ToList();
                        //    }
                        //}
                        #region remove before deploying

                        //public int Id { get; set; }
                        //        public string Title { get; set; }
                        //        public string FirstName { get; set; }
                        //        public string SurName { get; set; }
                        //        public string ProductName { get; set; }
                        //        public long PayoutAmount { get; set; }
                        //        public long AnnualPremium { get; set; }
                        //using (TextReader txt = new StreamReader(stream))
                        //{
                        //    using (var csv = new CsvReader(txt))
                        //    {
                        //        var records = csv.
                        //        return records.ToList();
                        //    }
                        //}
                        //if (csvTable.Rows.Count > 0)
                        //{
                        //    var records= csvReader.
                        //    while ()
                        //    { }
                        //}
                        //if (reader.HasRows)
                        //{
                        //    while (reader.Read())
                        //    {
                        //        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        //            reader.GetString(1));
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("No rows found.");
                        //}
                        //reader.Close(); 
                        #endregion

                        return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        private static DataTable ExcelToDataTable(HttpPostedFileBase upload)
        {
            Stream stream = upload.InputStream;
            DataTable csvTable = new DataTable();
            using (StreamReader sr = new StreamReader(stream))
            {
                csvTable = new DataTable();
                string[] headers = sr.ReadLine().Split(',');
                for (int i = 0; i < headers.Count(); i++)
                {
                    csvTable.Columns.Add();
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = csvTable.NewRow();
                    for (int i = 0; i < rows.Count(); i++)
                    {
                        dr[i] = rows[i];
                    }
                    csvTable.Rows.Add(dr);
                }
            }

            return csvTable;
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