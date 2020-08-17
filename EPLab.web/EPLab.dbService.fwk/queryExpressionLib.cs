using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EPLab.dbService.fwk
{
    public class queryExpressionLib 
    {
        protected string connS = "";
        protected AdoNet2DataTable d2dt = null;

        public queryExpressionLib(string connS)
        {
            this.connS = connS;
            d2dt = new AdoNet2DataTable(connS);
        }
        protected string MFVIsubSql(int nth)
        {
            string sql =string.Format(@"
    select f{0}.fieldId
    from queries q
    join expressions e on q.whereExpressionId = e.expressionId
    join fields f{0} on e.paraField{0}id = f{0}.fieldId
    where q.queryName = @queryName", nth);
            return sql;
        }
        public DataTable mandatoryFieldValueInsufficient(
            string queryName)
        {
            DataTable dt;
            string sql = string.Format(@"
with fieldsMustHaveValue(mustHaveFieldId)
as
(
	{0}
	union
	{1}
	union
	{2}
	union
	{3}
	union
	{4}
	union
	select qf.fieldId
	from queryFields qf
	join fields f on qf.fieldId=f.fieldId
	join queries q on qf.queryId=q.queryId
	where q.queryName=@queryName and qf.orderByOrder>0
)
select fmhv.mustHaveFieldId, r.rowId
from queries q
join [rows] r on r.tableId=q.tableId and q.queryName=@queryName
join fields f on f.tableId=q.tableId
join fieldsMustHaveValue fmhv on fmhv.mustHaveFieldId=f.fieldId
left join fieldValues fv on fv.rowId=r.rowId and fv.fieldId=fmhv.mustHaveFieldId
where fv.fieldValueId is null
", MFVIsubSql(1), MFVIsubSql(2), MFVIsubSql(3), MFVIsubSql(4), MFVIsubSql(5)
);
            // @queryName passed in 
            List<SqlParameter> para = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@queryName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = queryName
                }
            };
            dt = d2dt.Select2DataTable(sql, para);
            return dt;
        }
        public DataTable whereConditions(string queryName)
        {
            DataTable dt;
            string sql = string.Format(@"
select o.operatorName, e.paraField1id, f1.fieldName field1Name
	, e.paraField2id, f2.fieldName field2Name, e.para2externalName
from queries q
join expressions e on q.whereExpressionId=e.expressionId
join operators o on e.operatorId=o.operatorId
join fields f1 on e.paraField1id=f1.fieldId
left join fields f2 on e.paraField2id=f2.fieldId
where q.queryName=@queryName
");
            // @queryName passed in 
            List<SqlParameter> para = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@queryName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = queryName
                }
            };
            dt = d2dt.Select2DataTable(sql, para);
            return dt;
        }
        public DataTable orderByFields(string queryName)
        {
            DataTable dt;
            string sql = string.Format(@"
select qf.fieldId, qf.orderByOrder
from queryFields qf
join queries q on q.queryId=qf.queryId
where q.queryName=@queryName and orderByOrder>0
order by orderByOrder
");
            // @queryName passed in 
            List<SqlParameter> para = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@queryName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = queryName
                }
            };
            dt = d2dt.Select2DataTable(sql, para);
            return dt;
        }
        public string rowsSql(string queryName)
        {
            string sql;
            // base part
            sql = @"
select r.rowId
from [rows] r
join queries q on r.tableId=q.tableId
join expressions e on q.whereExpressionId=e.expressionId
";
            // where part
            string sqlWhereJoin, sqlWhereCond;
            DataTable dtWhere = whereConditions(queryName);
            if (dtWhere == null || dtWhere.Rows.Count != 1)
                throw new Exception("bad where condition");
            DataRow drWhere = dtWhere.Rows[0];
            string operatorName = drWhere["operatorName"] + "";
            string paraField1id = drWhere["paraField1id"] + "";
            string field1Name = drWhere["field1Name"] + "";
            string paraField2id = drWhere["paraField2id"] + "";
            string field2Name = drWhere["field2Name"] + "";
            string para2externalName = drWhere["para2externalName"] + "";
            int caseNo = 0;
            if (!string.IsNullOrWhiteSpace(paraField1id) &&
                    !string.IsNullOrWhiteSpace(field1Name) &&
                    paraField2id.Length == 0 &&
                    field2Name.Length == 0 &&
                    !string.IsNullOrWhiteSpace(para2externalName))
            {
                caseNo = 1;
            }
            else
                throw new Exception("where condition not dealing with");
            // caseNo 1 ....
            //undone (1) !!...
            // orderBy part
            DataTable dtOrder = orderByFields(queryName);
            // final
            return sql;
        }
        public DataTable displayFields(string queryName)
        {
            DataTable dt;
            string sql = string.Format(@"
select qf.fieldId, f.fieldName, qf.displayOrder
from queryFields qf
join queries q on qf.queryId=q.queryId
join fields f on qf.fieldId=f.fieldId
where q.queryName=@queryName and qf.displayOrder>0
order by qf.displayOrder
");
            // @queryName passed in 
            List<SqlParameter> para = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@queryName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = queryName
                }
            };
            dt = d2dt.Select2DataTable(sql, para);
            return dt;
        }
        public string finalSql4query(string queryName)
        {
            string sql = "";

            return sql;
        }
    }
}
