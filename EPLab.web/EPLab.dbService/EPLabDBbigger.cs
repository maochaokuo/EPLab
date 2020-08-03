﻿using EPLab.entity.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EPLab.dbService
{
    public class EPLabDBbigger
    {
        protected string connS = "";
        protected SqlConnection conn = null;

        protected tableLib tableL = null;
        protected fieldLib fieldL = null;
        protected rowLib rowL = null;
        protected fieldValueLib fieldValueL = null;

        public EPLabDBbigger(string connS)
        {
            this.connS = connS;
            tableL = new tableLib(connS);
            fieldL = new fieldLib(connS);
            rowL = new rowLib(connS);
            fieldValueL = new fieldValueLib(connS);
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
        /* undone (2) !!...EPLabDBbigger, overlap with Dapper2DataTable
         * query/insert./update delete for whole table, bigger view
         */

        public bool isDataTableExisted(string tableName)
        {
            bool ret = false;
            Tables tbl = tableL.TableByName(tableName);
            if (tbl != null)
                ret = true;
            // isDataTableExisted
            return ret;
        }
        public string deleteTable(string tableName)
        {
            string ret = "";

            Tables tbl = tableL.TableByName(tableName);
            if (tbl == null)
                return ret;
            List<Rows> rows = rowL.RowsByTableId(tbl.TableId);
            foreach (Rows rec in rows)
            {
                List<FieldValues> fieldValues = fieldValueL.FieldValueByRowId(rec.RowId);
                foreach (FieldValues rec2 in fieldValues)
                    fieldValueL.Delete(rec2);
                rowL.Delete(rec);
            }
            tableL.Delete(tbl);
            return ret;
        }
        //public string insertTable(string table)
    }
}
