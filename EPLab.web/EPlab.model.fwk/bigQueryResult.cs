using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EPlab.model.fwk
{
    public class bigQueryResult
    {
        public List<string> columnNames { get; set; }
        public List<object> columnValues { get; set; }

        public string fromDataTable(DataTable dt)
        {
            string ret = "";
            //todo !!...(2)bigQueryResult fromDataTable
            return ret;
        }
        public DataTable toDataTable()
        {
            DataTable ret = null;
            //todo !!...(2)bigQueryResult toDataTable
            return ret;
        }

        public bigQueryResult()
        {
            columnNames = new List<string>();
            columnValues = new List<object>();
        }
    }
}
