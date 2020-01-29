using CodingTest.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CodingTest.Helper
{
    public class Logger : ILogger
    {
        public string filePath = ConfigurationManager.AppSettings["Invalid_data_Log_File_Path"];

        public void Log(string message)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                streamWriter.BaseStream.Seek(0, System.IO.SeekOrigin.End);
                streamWriter.WriteLine(message);
                streamWriter.WriteLine("-------------------------------------------------------------------------------------------------------------");
                streamWriter.Close();
            }
        }

    }
}
