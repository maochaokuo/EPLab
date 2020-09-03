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
    public class bigQueryResultRow
    {
        public Dictionary<string, object> fields1row { get; set; }
        public bigQueryResultRow()
        {
            fields1row = new Dictionary<string, object>();
        }
    }
    public class bigQueryResult
    {
        public List<string> columnNames { get; set; }
        public List<bigQueryResultRow> rowsOfColumnValues { get; set; }

        public string fromDataTable(DataTable dt)
        {
            string ret = "";
            init();
            Dictionary<string, int> nameIndex = new Dictionary<string, int>();
            int i = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                columnNames.Add(dc.ColumnName);
                nameIndex.Add(dc.ColumnName, i++);
            }
            foreach(DataRow dr in dt.Rows)
            {
                bigQueryResultRow onerow = new bigQueryResultRow();
                foreach (string col in columnNames)
                {
                    int indexOfName = nameIndex[col];
                    object obj = dr[indexOfName];
                    onerow.fields1row.Add(col, obj);
                }
                rowsOfColumnValues.Add(onerow);
            }
            // bigQueryResult fromDataTable
            return ret;
        }
        public DataTable toDataTable()
        {
            DataTable ret = null;
            //todo !!...(5)bigQueryResult toDataTable
            return ret;
        }
        protected void init()
        {
            columnNames = new List<string>();
            rowsOfColumnValues = new List<bigQueryResultRow>();
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
