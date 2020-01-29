using CodingTest.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CodingTest.Helper
{
    public class Logger : ILogger
    {
        public string filePath = @"D:\IDGLog.txt";

        public void Log(string message)
        {

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }

    }
}
