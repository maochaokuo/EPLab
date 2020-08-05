using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class tableLib : Repository<Tables>
    {
        // 不想用ef, 出問題很難查, 就用dapper吧
        // todo (3) !!... 研究一下dynamic parameter,
        //看看能否把各method都抽象化，傳入sql or table name, 然後
        //dynamic parameter array
        public tableLib(string connS) : base(connS)
        {
        }
        public override List<Tables> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables ";
                var qry = con.Query<Tables>(sql).ToList();
                return qry;
            }
        }
        public override Tables GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables " +
                    $"where tableId=@tableId";
                var qry = conn.Query<Tables>(sql, 
                    new { tableId = gid }).SingleOrDefault();
                return qry;
            }
        }
        public Tables TableByName(string tableName)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from tables " +
                    $"where tableName=@tableName";
                var qry = conn.Query<Tables>(sql,
                    new { tableName = tableName }).SingleOrDefault();
                return qry;
            }
        }
        public override string Insert(Tables rec)
        {
            string ret = "";
            using(var con = GetConn())
            {
                string sql = $"insert into tables " +
                    $"(tableId,tableName,tableDesc) " +
                    $"values (@tableId,@tableName,@tableDesc)";
                con.Execute(sql, 
                    new {
                        tableId = rec.TableId,
                        tableName = rec.TableName, 
                        tableDesc = rec.TableDesc 
                    });
            }
            return ret;
        }
        public override string Update(Tables rec)
        {
            string ret = "";
            using (var con=GetConn())
            {
                string sql = $"update tables " +
                    $"set tableDesc=@tableDesc " +
                    $"where tableId=@tableId";
                con.Execute(sql, 
                    new { tableId = rec.TableId
                    ,tableDesc = rec.TableDesc });
            }
            return ret;
        }
        public override string Delete(Tables rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from tables " +
                    $"where tableId=@tableId";
                con.Execute(sql, new
                {
                    tableId = rec.TableId
                });
            }
            return ret;
        }

        public override string DeleteByTag(string tag)
        {
            string ret = "";
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
            return ret;
        }
    }
}
