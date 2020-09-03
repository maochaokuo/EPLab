using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using Dapper;
using EPlab.entity.fwk;

namespace EPLab.dbService
{
    public class AdoNet2DataTable : IDisposable
    {
        protected string connS = "";
        protected SqlConnection conn = null;

        //protected tableLib tableL = null;
        //protected fieldLib fieldL = null;
        //protected rowLib rowL = null;
        //protected fieldValueLib fieldValueL = null;

        protected EPLabDBbigger dbBig = null;

        private bool disposedValue;

        // use datatable to deal with
        //general select query, to import to 
        //a new table in generic data
        // dapper does not support
        //so we use pure ado.net

        public AdoNet2DataTable(string connS)
        {
            this.connS = connS;
            dbBig = new EPLabDBbigger(connS);
        }
        protected IDbConnection GetConn()
        {
            if (conn == null || conn.State != ConnectionState.Open)
            {
                conn = new SqlConnection(connS);
                conn.Open();
            }
            return conn;
        }
        public DataTable Select2DataTable(string sqlCount, string sql1000
            , out int recordCount, List<SqlParameter> cmdPara=null)
        {
            // https://stackoverflow.com/questions/23320701/how-to-create-sqlparametercollection-with-multiple-parameters
            DataTable dtCount = new DataTable();
            DataTable dt1000 = new DataTable();

            SqlConnection conn = new SqlConnection(connS);
            conn.Open();

            SqlCommand cmdCount = new SqlCommand(sqlCount, conn);
            if (cmdPara != null && cmdPara.Count > 0)
                cmdCount.Parameters.AddRange(cmdPara.ToArray());
            SqlDataAdapter daCount = new SqlDataAdapter(cmdCount);
            daCount.Fill(dtCount);
            if (dtCount.Rows.Count != 1)
                throw new Exception($"dtCount.Rows.Count={dtCount.Rows.Count}");
            DataRow drCount = dtCount.Rows[0];
            recordCount =int.Parse( drCount["counts"]+"");
            cmdCount.Parameters.Clear();
            cmdCount = null;
            daCount.Dispose();

            SqlCommand cmd1000 = new SqlCommand(sql1000, conn);
            if (cmdPara != null && cmdPara.Count > 0)
                cmd1000.Parameters.AddRange(cmdPara.ToArray());
            SqlDataAdapter da1000 = new SqlDataAdapter(cmd1000);
            da1000.Fill(dt1000);
            da1000.Dispose();

            conn.Close();
            return dt1000;
        }
        protected string DataTableName(DataTable dt)
        {
            string ret = dt.TableName;
            return ret;
        }
        protected List<string> DataTableColumnNames(DataTable dt)
        {
            List<string> ret = new List<string>();
            foreach (DataColumn dc in dt.Columns)
                ret.Add(dc.ColumnName);
            return ret;
        }
        protected List<string> DataTableColumnTypes(DataTable dt)
        {
            List<string> ret = new List<string>();
            foreach (DataColumn dc in dt.Columns)
                ret.Add(dc.DataType.Name);
            return ret;
        }
        protected List<Dictionary<string, string>> DataTableCellValue(DataTable dt)
        {
            List<Dictionary<string, string>> ret = 
                new List<Dictionary<string, string>>();
            foreach(DataRow dr in dt.Rows)
            {
                Dictionary<string, string> rowColumns = 
                    new Dictionary<string, string>();
                foreach (DataColumn dc in dt.Columns)
                    rowColumns.Add(dc.ColumnName, dr[dc.ColumnName]+"");
                ret.Add(rowColumns);
                rowColumns = null;
            }
            return ret;
        }
        protected bool isDataTableExisted(DataTable dt)
        {
            bool ret;
            string tableName = DataTableName(dt);
            ret = dbBig.isDataTableExisted(tableName);
            return ret;
        }
        //protected string deleteDataTable(DataTable dt)
        //{
        //    string ret = "";
        //    string tableName = DataTableName(dt);
        //    return ret;
        //}
        public string ImportDataTableSaveas(DataTable dt
            , string saveAsNewTablename="", bool append=false)
        {
            string ret = "";
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss")+ " ImportDataTableSaveas 1");
            if (saveAsNewTablename == "")
                saveAsNewTablename = DataTableName(dt);
            // import datatable save as new table
            // if new table existed, append false to overwrite

            // delete target table
            if (!append)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 2b");
                dbBig.deleteTag(saveAsNewTablename);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 2");
                dbBig.deleteTable(saveAsNewTablename);
            }

            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 3");
            // write to tables
            tables tbl = new tables();
            tbl.tableName = saveAsNewTablename;
            Guid tableId;
            ret = dbBig.insertTable(tbl, out tableId, 
                saveAsNewTablename);

            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 4");
            // write to fields
            List<string> colNames = DataTableColumnNames(dt);
            List<string> colTypes = DataTableColumnTypes(dt);
            Dictionary<string, Guid> name2id = new Dictionary<string, Guid>();
            for(int i=0; i<colNames.Count && i<colTypes.Count; i++)
            {
                fields fld = new fields();
                fld.fieldName = colNames[i];
                fld.fieldDesc = colTypes[i];
                fld.tableId = tableId;
                fld.defaultOrder = i + 1;
                Guid fieldId = Guid.Empty;
                ret = dbBig.insertField(fld, out fieldId, 
                    saveAsNewTablename);
                name2id.Add(fld.fieldName, fieldId);
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 5 i="+i);
            }

            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 6");
            List<Dictionary<string, string>> dtCells = 
                DataTableCellValue(dt);
            int j = 0;
            foreach(Dictionary<string, string> rowCols in dtCells)
            {
                // write to rows
                Guid rowId = Guid.Empty;
                rows rw = new rows();
                rw.tableId = tableId;
                ret = dbBig.insertRow(rw, out rowId, 
                    saveAsNewTablename);

                if (++j % 10000 == 0)
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + 
                        $" ImportDataTableSaveas 7 [{j}/{dtCells.Count}]" );
                // write to field values
                foreach (KeyValuePair<string, string> pair in rowCols)
                {
                    fieldValues fv = new fieldValues();
                    fv.rowId = rowId;
                    fv.fieldId = name2id[pair.Key];
                    fv.fieldValue = pair.Value;
                    ret = dbBig.insertFieldValue(fv);
                }
            }
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ImportDataTableSaveas 8 end");
            return ret;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TO DO: dispose managed state (managed objects)
                }

                // TO DO: free unmanaged resources (unmanaged objects) and override finalizer
                // TO DO: set large fields to null
                disposedValue = true;
            }
        }

        // // TO DO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ToDataTable()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
