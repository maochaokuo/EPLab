using Dapper;
using EPlab.entity.fwk;
using EPlab.model.fwk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace EPLab.dbService.fwk
{
    public class queryExpressionLib 
    {
        protected string connS = "";
        protected AdoNet2DataTable d2dt = null;
        protected EFselect efs = null;

        public queryExpressionLib(string connS)
        {
            this.connS = connS;
            d2dt = new AdoNet2DataTable(connS);
            efs = new EFselect(connS);
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
        protected List<queryWhereRec> whereConditions(string queryName)
        {
            List<queryWhereRec> ret=null;
            string sql; 
//            sql = @"
//select o.operatorName, o.stringInSourceCode, o.isPrefix, o.paraNum
//	, e.paraField1id, f1.fieldName field1Name
//	, e.paraField2id, f2.fieldName field2Name
//    , e.para2externalName, e.subExpression1Id, e.subExpression2Id
//from queries q
//join expressions e on q.whereExpressionId=e.expressionId
//join operators o on e.operatorId=o.operatorId
//join fields f1 on e.paraField1id=f1.fieldId
//left join fields f2 on e.paraField2id=f2.fieldId
//where q.queryName=@queryName
//";
            sql = @"
with expressList
as
(
	select a.*, cast (1 as bit) isWhereExpressId
	from expressions a
	join queries q on a.expressionId=q.whereExpressionId
	where q.queryName=@queryName
	union all
	select b.*, cast (0 as bit) isWhereExpressId
	from expressions b
	join expressList c on c.subExpression1Id=b.expressionId
	where c.subExpression1Id is not null
	union all
	select d.*, cast (0 as bit) isWhereExpressId
	from expressions d
	join expressList e on e.subExpression2Id=d.expressionId
	where e.subExpression2Id is not null
)
select e.isWhereExpressId,
	e.expressionId, o.operatorName, o.stringInSourceCode, o.isPrefix, o.paraNum
	, e.paraField1id, f1.fieldName field1Name
	, e.paraField2id, f2.fieldName field2Name
	, e.para2externalName, e.subExpression1Id, e.subExpression2Id
from expressList e 
join operators o on e.operatorId=o.operatorId
left join fields f1 on e.paraField1id=f1.fieldId
left join fields f2 on e.paraField2id=f2.fieldId
";
            //EF hit as well
            //var qry = efs.select<queryWhereRec>(sql
            //    , new SqlParameter("queryName", queryName));

            DapperSelect<queryWhereRec> dp = new
                DapperSelect<queryWhereRec>(connS);
            DynamicParameters dpara = new DynamicParameters();
            dpara.Add("@queryName", queryName, DbType.String);
            var qry = dp.Select<queryWhereRec>(sql, dpara);
            if (qry.Any())
                ret = qry.ToList();
            return ret;
            // @queryName passed in 
            //List<SqlParameter> para = new List<SqlParameter>
            //{
            //    new SqlParameter
            //    {
            //        ParameterName = "@queryName",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = queryName
            //    }
            //};
            //dt = d2dt.Select2DataTable(sql, para);
            //return dt;
        }
        protected DataTable orderByFields(string queryName)
        {
            DataTable dt;
            string sql = string.Format(@"
select qf.fieldId, f.fieldName,
	case when qf.orderByDesc=0 then 'asc' else 'desc' end ascDesc
	, qf.orderByOrder
from queryFields qf
join queries q on q.queryId=qf.queryId
join fields f on qf.fieldId=f.fieldId and q.tableId=f.tableId
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
        protected static string fieldId2para(string fieldId
            , ref Dictionary<string, int> whereFieldDict)
        {
            string ret = "";
            int fieldNth = 0;
            // fieldId2para
            if (whereFieldDict.ContainsKey(fieldId))
                fieldNth = whereFieldDict[fieldId];
            else
            {
                fieldNth = whereFieldDict.Count + 1;
                whereFieldDict.Add(fieldId, fieldNth);
            }
            ret = $"fv{fieldNth}.fieldValue";
            //ret = $"fv{fieldNth}.fieldId";
            return ret;
        }
        protected static string sqlExpression(
            //queryWhereRec theWhereRec, // no need
            string whereExpressId,
            //string para1, // no need
            Dictionary<string, queryWhereRec> whereDict,
            ref Dictionary<string, int> whereFieldDict
            )
            //string operatorName
            //, string stringInSourceCode, string isPrefix
            //, string paraNum, string para1, string para2)
        {
            string sql = "";
            queryWhereRec rec = whereDict[whereExpressId];

            string para1 = "", para2 = "";
            bool needQuote = false;

            if (!string.IsNullOrWhiteSpace(rec.subExpression1Id.ToString()))
                para1 = sqlExpression(rec.subExpression1Id.ToString(), whereDict, ref whereFieldDict);
            else if (!string.IsNullOrWhiteSpace(rec.paraField1id.ToString()))
            {
                para1 = fieldId2para(rec.paraField1id.ToString(), ref whereFieldDict);
                needQuote = true;
            }
            //else if (!string.IsNullOrWhiteSpace(rec.para2externalName))
            //    para1 = rec.expressionId;
            else
                throw new Exception("para1 not defined!");
            if (!string.IsNullOrWhiteSpace(rec.subExpression2Id.ToString()))
                para2 = sqlExpression(rec.subExpression2Id.ToString(), whereDict, ref whereFieldDict);
            else if (!string.IsNullOrWhiteSpace(rec.paraField2id.ToString()))
                para2 = fieldId2para(rec.paraField2id.ToString(), ref whereFieldDict);
            else if (!string.IsNullOrWhiteSpace(rec.para2externalName))
            {
                para2 ="@"+ rec.para2externalName;
                //if (needQuote)
                //    para2 = $"'{rec.expressionId.ToString()}'";
                //else
                //    para2 = rec.expressionId.ToString();
            }
            else
                throw new Exception("para2 not defined!");

            if (rec.paraNum == 2)
                sql =$"({para1} {rec.stringInSourceCode} {para2})";
            else
            {
                if (rec.isPrefix )//== "1")
                    sql =$"({rec.stringInSourceCode} {para1})";
                else
                    sql =$"({para1} {rec.stringInSourceCode})";
            }
            return sql;
        }
        public static string externalParameter(string paraName)
        {
            string ret = $"@{paraName}";

            return ret;
        }
        protected string rowsSql(string queryName, string orderAlias
            , out string sqlOrderBy, out string sqlOrderWith)
        {
            string sql="", baseSqlFormat;
            string sqlWhereJoin = "", sqlWhereCond = "";
            string sqlOrderJoin = "", orderByFields2query="";
            sqlOrderBy = "";
            sqlOrderWith = "";
            Dictionary<string, int> fieldDict =
                new Dictionary<string, int>();

            // base part
            baseSqlFormat = @"
    select r.rowId{0}
    from [rows] r
    join queries q on r.tableId=q.tableId
    join expressions e on q.whereExpressionId=e.expressionId
";

            // orderBy part
            DataTable dtOrder = orderByFields(queryName);
            int orderFieldNum = 0;
            foreach (DataRow dr in dtOrder.Rows)
            {
                orderFieldNum++;
                string fieldId = dr["fieldId"] + "";
                string ascDesc = dr["ascDesc"] + "";
                if (!fieldDict.ContainsKey(fieldId))
                    fieldDict.Add(fieldId, fieldDict.Count + 1);
                sqlOrderJoin += string.Format(@"
    join queryFields qf{0} on qf{0}.queryId=q.queryId and qf{0}.orderByOrder={0}
    join fieldValues fv{0} on r.rowId=fv{0}.rowId and qf{0}.fieldId=fv{0}.fieldId
", orderFieldNum);
                if (orderFieldNum == 1)
                {
                    sqlOrderBy = $"order by {orderAlias}.fieldValue1 {ascDesc}";
                    sqlOrderWith = ", fieldValue1";
                    orderByFields2query = ", fv1.fieldValue fieldValue1";
                }
                else
                {
                    sqlOrderBy += $",{orderAlias}.fieldValue{orderFieldNum} {ascDesc}";
                    sqlOrderWith += $", fieldValue{orderFieldNum}";
                    orderByFields2query += $", fv{orderFieldNum}.fieldValue fieldValue{orderFieldNum}";
                }
            }

            // where part
            List<queryWhereRec> whereList = whereConditions(queryName);
            if (whereList == null || whereList.Count <= 0)
                throw new Exception("bad where condition");
            // add wheres to dictionary
            Dictionary<string, queryWhereRec> whereExpressDict =
                new Dictionary<string, queryWhereRec>();
            //find whereExpressionId
            string whereExpressId = "";
            queryWhereRec theWhereRec = null;
            foreach (queryWhereRec rec in whereList)
            {
                if (rec.isWhereExpressId)
                {
                    if (!string.IsNullOrWhiteSpace(whereExpressId)
                             && theWhereRec != null)
                        throw new Exception("where expression id already assigned");
                    whereExpressId = rec.expressionId.ToString();
                    theWhereRec = rec;
                }
                whereExpressDict.Add(rec.expressionId.ToString(), rec);
            }
            //get expression by whereExpressionId
            //DataRow drWhere = whereList.Rows[0];
            //string expressionId = drWhere["expressionId"] + "";//new
            //string operatorName = drWhere["operatorName"] + "";
            //string stringInSourceCode = drWhere["stringInSourceCode"] + "";
            //string isPrefix = drWhere["isPrefix"] + "";
            //string paraNum = drWhere["paraNum"] + "";
            //string paraField1id = drWhere["paraField1id"] + "";
            //string field1Name = drWhere["field1Name"] + "";//restored
            //string paraField2id = drWhere["paraField2id"] + "";
            //string field2Name = drWhere["field2Name"] + "";
            //string para2externalName = drWhere["para2externalName"] + "";
            //string subExpression1Id = drWhere["subExpression1Id"] + "";//new
            //string subExpression2Id = drWhere["subExpression2Id"] + "";//new
            //int caseNo = 0;
            //if (!string.IsNullOrWhiteSpace(paraField1id) &&
            //        //!string.IsNullOrWhiteSpace(field1Name) &&
            //        paraField2id.Length == 0 &&
            //        field2Name.Length == 0 &&
            //        !string.IsNullOrWhiteSpace(para2externalName))
            //{
            //    caseNo = 1;
            //    if (paraNum.CompareTo("2") != 0)
            //        throw new Exception($"wrong paraNum {paraNum} (case#{caseNo})");

            string sqlExpr = sqlExpression( whereExpressId, whereExpressDict, ref fieldDict);
            sqlWhereCond = string.Format(@"
    where q.queryName=@queryName and {0}
", sqlExpr);
            foreach(KeyValuePair<string, int> rec in fieldDict)
            {
                if (rec.Value > orderFieldNum)
                {
                    sqlWhereJoin += $@"
    join fieldValues fv{rec.Value} on r.rowId=fv{rec.Value}.rowId and fv{rec.Value}.fieldId='{rec.Key}'
";
                }
            }
            //}
            //else
            //    throw new Exception("where condition not dealing with");

            // final
            sql = string.Format(baseSqlFormat, orderByFields2query) + sqlWhereJoin + sqlOrderJoin + sqlWhereCond;// + sqlOrderBy;
            return sql;
        }
        protected DataTable displayFields(string queryName)
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
            //string 
            dt = d2dt.Select2DataTable(sql, para);
            return dt;
        }
        public string finalSql4query(string queryName)
        {
            string sql = "";

            string sqlOrderBy = "";
            string sqlOrderWith = "";
            string rowsSqlS = rowsSql(queryName, "fwo"
                , out sqlOrderBy, out sqlOrderWith);
            string sqlWithPart = "";
            string sqlSelectPart = "", sqlSelectFields = "";
            string sqlJoinPart = "";

            // with part
            sqlWithPart = string.Format(@"
with rowsWhereOrder(rowId{0})
as
(
    {1}
)
", sqlOrderWith, rowsSqlS);
            // select from with part
            DataTable displayDt = displayFields(queryName);
            int i = 0;
            foreach(DataRow dr in displayDt.Rows)
            {
                i++;
                string fieldId = dr["fieldId"] + "";
                string fieldName = dr["fieldName"] + "";
                string displayOrder = dr["displayOrder"] + "";
                sqlSelectFields += $", f{i}.fieldValue [{fieldName}]";
                // join part
                sqlJoinPart += $@"
join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder={i}
	join fieldValues fv on fv.fieldId=qf.fieldId
) f{i} on fwo.rowId=f{i}.rowId
";
            }
            sqlSelectPart = string.Format(@"
select fwo.rowId{0}
from rowsWhereOrder fwo
", sqlSelectFields);

            // order by part then finalSql4query
            sql = sqlWithPart + sqlSelectPart + sqlJoinPart + sqlOrderBy;
            return sql;
        }
        public List<string> formParameters(string queryName)
        {
            List<string> ret = null;
            string sql = string.Format(@"
with expressList
as
(
	select a.*
	from expressions a
	join queries q on a.expressionId=q.whereExpressionId
	where q.queryName=@queryName
	union all
	select b.*
	from expressions b
	join expressList c on c.subExpression1Id=b.expressionId
	union all
	select d.*
	from expressions d
	join expressList e on e.subExpression2Id=d.expressionId
)
select e.para1externalName externalPara
from expressList e
where e.para1externalName is not null
union
select e.para2externalName externalPara
from expressList e
where e.para2externalName is not null
");
            // formParameters
            DapperSelect<string> dp = new
                DapperSelect<string>(connS);
            DynamicParameters dpara = new DynamicParameters();
            dpara.Add("@queryName", queryName, DbType.String);
            var qry = dp.Select<string>(sql, dpara);
            if (qry.Any())
                ret = qry.ToList();
            return ret;
        }
    }
}
