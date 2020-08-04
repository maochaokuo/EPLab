using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class allIdHistoryLib : Repository<AllIdHistory>
    {
        public allIdHistoryLib(string connS) : base(connS)
        {
        }

        public override List<AllIdHistory> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from allIdHistory ";
                var qry = con.Query<AllIdHistory>(sql).ToList();
                return qry;
            }
        }

        public override AllIdHistory GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from allIdHistory " +
                    $"where allIdHistoryId=@allIdHistoryId";
                var qry = conn.Query<AllIdHistory>(sql,
                    new { allIdHistoryId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(AllIdHistory rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into allIdHistory " +
                    $"(uid,fromTable,createBy,modifyBy) " +
                    $"values (@uid,@fromTable,@createBy,@modifyBy)";
                con.Execute(sql,
                    new
                    {
                        uid = rec.Uid,
                        fromTable = rec.FromTable,
                        createBy = rec.CreateBy,
                        modifyBy = rec.ModifyBy
                    });
            }
            return ret;
        }

        public override string Update(AllIdHistory rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update allIdHistory " +
                    $"set fromTable=@fromTable,modifyBy=@modifyBy " +
                    $"where uid=@uid";
                con.Execute(sql,
                    new
                    {
                        uid = rec.Uid,
                        fromTable = rec.FromTable,
                        //createBy = rec.CreateBy,
                        modifyBy = rec.ModifyBy
                    });
            }
            return ret;
        }
        public override string Delete(AllIdHistory rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from allIdHistory " +
                    $"where uid=@uid";
                con.Execute(sql, new
                {
                    uid = rec.Uid
                });
            }
            return ret;
        }

    }
}
