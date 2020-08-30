using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPLab.dbService
{
    public class queryLib : Repository<queries>
    {
        public queryLib(string connS) : base(connS)
        {
        }
        public override List<queries> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from queries ";
                var qry = con.Query<queries>(sql).ToList();
                return qry;
            }
        }
        public override queries GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from queries " +
                    $"where queryId=@queryId";
                var qry = conn.Query<queries>(sql,
                    new { queryId = gid }).SingleOrDefault();
                return qry;
            }
        }
        public string QueryNameById(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from queries " +
                    $"where queryId=@queryId";
                var qry = conn.Query<queries>(sql,
                    new { queryId = gid }).SingleOrDefault();
                return qry.queryName;
            }
        }
        public queries QueryByName(string queryName)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from queries " +
                    $"where queryName=@queryName";
                var qry = conn.Query<queries>(sql,
                    new { queryName = queryName }).SingleOrDefault();
                return qry;
            }
        }
        public override string Insert(queries rec)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = $"insert into queries " +
                        $"(queryId,queryName,queryDesc,tableId" +
                        $",tableAlias,whereExpressionId) " +
                        $"values (@queryId,@queryName,@queryDesc,@tableId" +
                        $",@tableAlias,@whereExpressionId)";
                    con.Execute(sql,
                        new
                        {
                            queryId = rec.queryId,
                            queryName = rec.queryName,
                            queryDesc = rec.queryDesc,
                            tableId = rec.tableId,
                            tableAlias = rec.tableAlias,
                            whereExpressionId = rec.whereExpressionId
                        });
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
        public override string Update(queries rec)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = $"update queries " +
                        $"set queryDesc=@queryDesc,tableId=@tableId" +
                        $",tableAlias=@tableAlias" +
                        $",whereExpressionId=@whereExpressionId " +
                        $"where queryId=@queryId";
                    con.Execute(sql,
                        new
                        {
                            queryId = rec.queryId,
                            queryDesc = rec.queryDesc,
                            tableId = rec.tableId,
                            tableAlias = rec.tableAlias,
                            whereExpressionId = rec.whereExpressionId
                        });
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
        public override string Delete(queries rec)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = $"delete from queries " +
                        $"where queryId=@queryId";
                    con.Execute(sql, new
                    {
                        queryId = rec.queryId
                    });
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
        public override string DeleteByTag(string tag)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = @"
delete a
from queries a
join allIdHistory b on a.queryId = uid
where b.tag = @tag";
                    con.Execute(sql, new
                    {
                        tag = tag
                    });
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
    }
}
