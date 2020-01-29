using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodingTest.Interface
{
    interface ICsvReader
    {
        DataTable ExcelToDataTable(HttpPostedFileBase upload);
    }
}
