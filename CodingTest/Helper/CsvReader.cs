﻿using CodingTest.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace CodingTest.Helper
{
    public class CsvReader : ICsvReader
    {
        public DataTable ExcelToDataTable(HttpPostedFileBase upload)
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
    }
}