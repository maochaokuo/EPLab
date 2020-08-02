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
        // todo (3) !!... 不想用ef, 出問題很難查, 就用dapper吧
        //  !!... 研究一下dynamic parameter,
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
                    new { tableId = gid }).FirstOrDefault();
                return qry;
            }
        }
        public override string Insert(Tables rec)
        {
            string ret = "";
            using(var con = GetConn())
            {
                string sql = $"insert into tables " +
                    $"(tableName,tableDesc) " +
                    $"vales (@tableName,@tableDesc)";
                con.Execute(sql, 
                    new { tablesName = rec.TableName, 
                    tableDesc = rec.TableDesc });
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
    }
}
