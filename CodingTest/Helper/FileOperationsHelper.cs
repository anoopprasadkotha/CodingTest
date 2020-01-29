using CodingTest.Models;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace CodingTest.Helper
{
    public static class FileOperationsHelper
    {
        /// <summary>
        /// Method used to read from template
        /// </summary>
        /// <returns></returns>
        public static StringBuilder ReadFromTemplate()
        {
            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(@"~/Content/templateDoc.txt"));
            string streamData = sr.ReadToEnd();
            sr.Close();
            return new StringBuilder(streamData);
        }

        /// <summary>
        /// Method use to create files in the Location
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="file"></param>
        public static void CreateFile(ViewModel viewModel,string file)
        {
            // C: \Users\Anoop Prasad Kotha\source\repos\CodingTest\CodingTest\Models\CustomerDetails.cs
            string path = "D:/" + viewModel.MemberDetils.Id + viewModel.MemberDetils.FirstName + ".txt";

            //Create the file only if it doesnt exists.
            if (!System.IO.File.Exists(path))
            {
                //System.IO.File.Delete(path);
                using (FileStream fs = System.IO.File.Create(path))
                {
                    AddText(fs, file);
                }
            }

        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

    }
}