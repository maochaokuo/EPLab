using EPLab.entity.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EPLab.dbService
{
    public class EPLabDBbigger
    {
        /* undone (5) EPLabDBbigger, overlap with Dapper2DataTable
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
            AllIdHistory aih = new AllIdHistory();
            aih.Uid = Guid.NewGuid();
            aih.FromTable = tableName;
            aih.CreateBy = "Import";
            if (tag == "")
                tag = tableName;
            aih.Tag = tag;
            allIdHistoryL.Insert(aih);
            // update allIdHistory
            return aih.Uid;
        }
        public string insertTable(Tables newTable, out Guid tableId
            , string tag="")
        {
            string ret;
            newTable.TableId = getNewId("tables", tag);
            tableId = newTable.TableId;
            ret = tableL.Insert(newTable);
            return ret;
        }
        public string insertField(Fields newField, out Guid fieldId
            , string tag = "")
        {
            string ret;
            newField.FieldId = getNewId("fields", tag);
            fieldId = newField.FieldId;
            ret = fieldL.Insert(newField);
            return ret;
        }
        public string insertRow(Rows newRow, out Guid rowId
            , string tag = "")
        {
            string ret;
            newRow.RowId = getNewId("rows", tag);
            rowId = newRow.RowId;
            ret = rowL.Insert(newRow);
            return ret;
        }
        public string insertFieldValue(FieldValues newFieldValue)
        {
            string ret;
            //newFieldValue.FieldValueId = getNewId("fieldValues");
            ret = fieldValueL.Insert(newFieldValue);
            return ret;
        }
    }
}
