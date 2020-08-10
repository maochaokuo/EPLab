using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPLab.dbService
{
    public class allIdHistoryLib : Repository<allIdHistory>
    {
        public allIdHistoryLib(string connS) : base(connS)
        {
        }

        public override List<allIdHistory> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from allIdHistory ";
                var qry = con.Query<allIdHistory>(sql).ToList();
                return qry;
            }
        }

        public override allIdHistory GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from allIdHistory " +
                    $"where allIdHistoryId=@allIdHistoryId";
                var qry = conn.Query<allIdHistory>(sql,
                    new { allIdHistoryId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(allIdHistory rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into allIdHistory " +
                    $"(uid,fromTable,createBy,modifyBy,tag) " +
                    $"values (@uid,@fromTable,@createBy,@modifyBy,@tag)";
                con.Execute(sql,
                    new
                    {
                        uid = rec.uid,
                        fromTable = rec.fromTable,
                        createBy = rec.createBy,
                        modifyBy = rec.modifyBy,
                        tag = rec.tag
                    });
            }
            return ret;
        }

        public override string Update(allIdHistory rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update allIdHistory " +
                    $"set fromTable=@fromTable," +
                    $"modifyBy=@modifyBy,tag=@tag " +
                    $"where uid=@uid";
                con.Execute(sql,
                    new
                    {
                        uid = rec.uid,
                        fromTable = rec.fromTable,
                        //createBy = rec.CreateBy,
                        modifyBy = rec.modifyBy,
                        tag = rec.tag
                    });
            }
            return ret;
        }
        public override string Delete(allIdHistory rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from allIdHistory " +
                    $"where uid=@uid";
                con.Execute(sql, new
                {
                    uid = rec.uid
                });
            }
            return ret;
        }
        public override string DeleteByTag(string tag)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from allIdHistory " +
                    $"where tag=@tag";
                con.Execute(sql, new
                {
                    tag = tag
                });
            }
            return ret;
        }
    }
}
