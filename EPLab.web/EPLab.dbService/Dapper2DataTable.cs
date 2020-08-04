using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using Dapper;
using EPLab.entity.Models;
using Microsoft.Data.SqlClient;

namespace EPLab.dbService
{
    public class Dapper2DataTable : IDisposable
    {
        protected string connS = "";
        protected SqlConnection conn = null;

        //protected tableLib tableL = null;
        //protected fieldLib fieldL = null;
        //protected rowLib rowL = null;
        //protected fieldValueLib fieldValueL = null;

        protected EPLabDBbigger dbBig = null;

        private bool disposedValue;

        //todo (1) !!... use datatable to deal with
        //general select query, to import to 
        //a new table in generic data
        //undone !!... dapper does not support
        //so we use pure ado.net

        public Dapper2DataTable(string connS)
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
        public DataTable Select2DataTable(string sql)
        {
            DataTable dt = new DataTable();
            //using (var con = GetConn())
            //{
            //    dt = (DataTable)con.Query(sql);
            //}
            // change to ado.net to implement

            SqlConnection conn = new SqlConnection(connS);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
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
        protected string deleteDataTable(DataTable dt)
        {
            string ret = "";
            string tableName = DataTableName(dt);
            return ret;
        }
        //public string ImportDataTableAppend(DataTable dt)
        //{
        //    string ret = "";
        //    // todo (1) !!...import datatable append to existed table
        //    return ret;
        //}
        //public string ImportDataTableOverwrite(DataTable dt)
        //{
        //    string ret = "";
        //    // todo (1) !!...import datatable overwrite existed table
        //    return ret;
        //}
        public string ImportDataTableSaveas(DataTable dt
            , string saveAsNewTablename="", bool append=false)
        {
            string ret = "";

            if (saveAsNewTablename == "")
                saveAsNewTablename = DataTableName(dt);
            // todo (1) !!...import datatable save as new table
            // if new table existed, append false to overwrite

            // delete target table
            if (!append)
                dbBig.deleteTable(saveAsNewTablename);

            // write to tables
            Tables tbl = new Tables();
            tbl.TableName = saveAsNewTablename;
            Guid tableId;
            ret = dbBig.insertTable(tbl, out tableId);

            // write to fields
            List<string> colNames = DataTableColumnNames(dt);
            List<string> colTypes = DataTableColumnTypes(dt);
            Dictionary<string, Guid> name2id = new Dictionary<string, Guid>();
            for(int i=0; i<colNames.Count && i<colTypes.Count; i++)
            {
                Fields fld = new Fields();
                fld.FieldName = colNames[i];
                fld.FieldDesc = colTypes[i];
                fld.TableId = tableId;
                Guid fieldId = Guid.Empty;
                ret = dbBig.insertField(fld, out fieldId);
                name2id.Add(fld.FieldName, fieldId);
            }

            List<Dictionary<string, string>> dtCells = DataTableCellValue(dt);
            foreach(Dictionary<string, string> rowCols in dtCells)
            {
                // write to rows
                Guid rowId = Guid.Empty;
                Rows rw = new Rows();
                rw.TableId = tableId;
                ret = dbBig.insertRow(rw, out rowId);

                // write to field values
                foreach (KeyValuePair<string, string> pair in rowCols)
                {
                    FieldValues fv = new FieldValues();
                    fv.RowId = rowId;
                    fv.FieldId = name2id[pair.Key];
                    fv.FieldValue = pair.Value;
                    ret = dbBig.insertFieldValue(fv);
                }
            }
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
