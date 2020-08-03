using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class domainLib : Repository<Domains>
    {
        public domainLib(string connS) : base(connS)
        {
        }

        public override List<Domains> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domains ";
                var qry = con.Query<Domains>(sql).ToList();
                return qry;
            }
        }

        public override Domains GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domains " +
                    $"where domainId=@domainId";
                var qry = conn.Query<Domains>(sql,
                    new { domainId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(Domains rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into domains " +
                    $"(domainId,domainName,domainDescription," +
                    $"basicType,isDomainCaseId) " +
                    $"vales (@domainId,@domainName,@domainDescription," +
                    $"@basicType,@isDomainCaseId)";
                con.Execute(sql,
                    new
                    {
                        domainId = rec.DomainId,
                        domainName = rec.DomainName,
                        domainDescription = rec.DomainDescription,
                        basicType = rec.BasicType,
                        isDomainCaseId = rec.IsDomainCaseId
                    });
            }
            return ret;
        }

        public override string Update(Domains rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update domains " +
                    $"set domainName=@DomainName, " +
                    $"domainDescription=@DomainDescription, " +
                    $"basicType=@BasicType, isDomainCaseId=@IsDomainCaseId" +
                    $"where domainId=@DomainId";
                con.Execute(sql,
                    new
                    {
                        domainId = rec.DomainId,
                        domainName = rec.DomainName,
                        domainDescription = rec.DomainDescription,
                        basicType = rec.BasicType,
                        isDomainCaseId = rec.IsDomainCaseId
                    });
            }
            return ret;
        }
        public override string Delete(Domains rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from domains " +
                    $"where domainId=@DomainId";
                con.Execute(sql, new
                {
                    domainId = rec.DomainId
                });
            }
            return ret;
        }
    }
}
