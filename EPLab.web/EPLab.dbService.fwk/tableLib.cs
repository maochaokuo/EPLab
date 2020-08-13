using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPLab.dbService
{
    public class tableLib : Repository<tables>
    {
        // 不想用ef, 出問題很難查, 就用dapper吧
        // todo (9) 研究一下dynamic parameter,
        //看看能否把各method都抽象化，傳入sql or table name, 然後
        //dynamic parameter array
        public tableLib(string connS) : base(connS)
        {
        }
        public override List<tables> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables ";
                var qry = con.Query<tables>(sql).ToList();
                return qry;
            }
        }
        public List<T> Query<T>(string sql
            , DynamicParameters paras)
        {
            using (var con = GetConn())
            {
                var qry = con.Query<T>(sql, paras).ToList();
                return qry;
            }
        }
        public override tables GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables " +
                    $"where tableId=@tableId";
                var qry = conn.Query<tables>(sql, 
                    new { tableId = gid }).SingleOrDefault();
                return qry;
            }
        }
        public string TableNameById(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables " +
                    $"where tableId=@tableId";
                var qry = conn.Query<tables>(sql,
                    new { tableId = gid }).SingleOrDefault();
                return qry.tableName;
            }
        }
        public tables TableByName(string tableName)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables " +
                    $"where tableName=@tableName";
                var qry = conn.Query<tables>(sql,
                    new { tableName = tableName }).SingleOrDefault();
                return qry;
            }
        }
        public override string Insert(tables rec)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = $"insert into tables " +
                        $"(tableId,tableName,tableDesc) " +
                        $"values (@tableId,@tableName,@tableDesc)";
                    con.Execute(sql,
                        new
                        {
                            tableId = rec.tableId,
                            tableName = rec.tableName,
                            tableDesc = rec.tableDesc
                        });
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
        public override string Update(tables rec)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = $"update tables " +
                        $"set tableDesc=@tableDesc " +
                        $"where tableId=@tableId";
                    con.Execute(sql,
                        new
                        {
                            tableId = rec.tableId,
                            tableDesc = rec.tableDesc
                        });
                }
            }
            catch(Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
        public override string Delete(tables rec)
        {
            string ret = "";
            try
            {
                using (var con = GetConn())
                {
                    string sql = $"delete from tables " +
                        $"where tableId=@tableId";
                    con.Execute(sql, new
                    {
                        tableId = rec.tableId
                    });
                }
            }
            catch(Exception ex)
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
from tables a
join allIdHistory b on a.tableId = uid
where b.tag = @tag";
                    con.Execute(sql, new
                    {
                        tag = tag
                    });
                }
            }
            catch(Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
    }
}
