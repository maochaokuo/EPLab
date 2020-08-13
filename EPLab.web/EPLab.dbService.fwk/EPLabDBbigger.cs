using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EPLab.dbService
{
    public class EPLabDBbigger
    {
        /* undone (3) EPLabDBbigger, overlap with Dapper2DataTable
         * query/insert./update delete for whole table, bigger view
         */
        protected string connS = "";
        protected SqlConnection conn = null;

        protected tableLib tableL = null;
        protected fieldLib fieldL = null;
        protected rowLib rowL = null;
        protected fieldValueLib fieldValueL = null;
        protected allIdHistoryLib allIdHistoryL = null;

        public EPLabDBbigger(string connS)
        {
            this.connS = connS;
            tableL = new tableLib(connS);
            fieldL = new fieldLib(connS);
            rowL = new rowLib(connS);
            fieldValueL = new fieldValueLib(connS);
            allIdHistoryL = new allIdHistoryLib(connS);
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

        public bool isDataTableExisted(string tableName)
        {
            bool ret = false;
            tables tbl = tableL.TableByName(tableName);
            if (tbl != null)
                ret = true;
            // isDataTableExisted
            return ret;
        }
        public string deleteTable(string tableName)
        {
            string ret = "";
            tables tbl = tableL.TableByName(tableName);
            if (tbl == null)
                return ret;
            List<rows> rows = rowL.RowsByTableId(tbl.tableId);
            foreach (rows rec in rows)
            {
                List<fieldValues> fieldValues = fieldValueL.FieldValueByRowId(rec.rowId);
                foreach (fieldValues rec2 in fieldValues)
                    fieldValueL.Delete(rec2);
                rowL.Delete(rec);
            }
            tableL.Delete(tbl);
            return ret;
        }
        public string deleteTag(string tag)
        {
            string ret = "";
            ret = tableL.DeleteByTag(tag);
            ret = fieldL.DeleteByTag(tag);
            ret = rowL.DeleteByTag(tag);
            ret = fieldValueL.DeleteByTag(tag);
            ret = allIdHistoryL.DeleteByTag(tag);
            return ret;
        }
        public Guid getNewId(string tableName, string tag="")
        {
            allIdHistory aih = new allIdHistory();
            aih.uid = Guid.NewGuid();
            aih.fromTable = tableName;
            aih.createBy = "Import";
            if (tag == "")
                tag = tableName;
            aih.tag = tag;
            allIdHistoryL.Insert(aih);
            // update allIdHistory
            return aih.uid;
        }
        public string insertTable(tables newTable, out Guid tableId
            , string tag="")
        {
            string ret;
            newTable.tableId = getNewId("tables", tag);
            tableId = newTable.tableId;
            ret = tableL.Insert(newTable);
            return ret;
        }
        public string insertField(fields newField, out Guid fieldId
            , string tag = "")
        {
            string ret;
            newField.fieldId = getNewId("fields", tag);
            fieldId = newField.fieldId;
            ret = fieldL.Insert(newField);
            return ret;
        }
        public string insertRow(rows newRow, out Guid rowId
            , string tag = "")
        {
            string ret;
            newRow.rowId = getNewId("rows", tag);
            rowId = newRow.rowId;
            ret = rowL.Insert(newRow);
            return ret;
        }
        public string insertFieldValue(fieldValues newFieldValue)
        {
            string ret;
            //newFieldValue.FieldValueId = getNewId("fieldValues");
            ret = fieldValueL.Insert(newFieldValue);
            return ret;
        }
    }
}
