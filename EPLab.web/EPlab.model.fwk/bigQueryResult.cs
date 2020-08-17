using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPlab.model.fwk
{
    public class bigQueryResult
    {
        public List<string> columnNames { get; set; }
        public List<Dictionary<string, object>> rowsOfColumnValues { get; set; }

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
        protected void init()
        {
            columnNames = new List<string>();
            rowsOfColumnValues = new List<Dictionary<string, object>>();
        }
        public bigQueryResult()
        {
            init();
        }
        public bigQueryResult(DataTable dt)
        {
            init();
            string err = fromDataTable(dt);
            Thread.Sleep(0);
        }
    }
}
