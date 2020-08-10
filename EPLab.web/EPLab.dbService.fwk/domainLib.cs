using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPLab.dbService
{
    public class domainLib : Repository<domains>
    {
        public domainLib(string connS) : base(connS)
        {
        }

        public override List<domains> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domains ";
                var qry = con.Query<domains>(sql).ToList();
                return qry;
            }
        }

        public override domains GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domains " +
                    $"where domainId=@domainId";
                var qry = conn.Query<domains>(sql,
                    new { domainId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(domains rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into domains " +
                    $"(domainId,domainName,domainDescription," +
                    $"basicType,isDomainCaseId) " +
                    $"values (@domainId,@domainName,@domainDescription," +
                    $"@basicType,@isDomainCaseId)";
                con.Execute(sql,
                    new
                    {
                        domainId = rec.domainId,
                        domainName = rec.domainName,
                        domainDescription = rec.domainDescription,
                        basicType = rec.basicType,
                        isDomainCaseId = rec.isDomainCaseId
                    });
            }
            return ret;
        }

        public override string Update(domains rec)
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
                        domainId = rec.domainId,
                        domainName = rec.domainName,
                        domainDescription = rec.domainDescription,
                        basicType = rec.basicType,
                        isDomainCaseId = rec.isDomainCaseId
                    });
            }
            return ret;
        }
        public override string Delete(domains rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from domains " +
                    $"where domainId=@DomainId";
                con.Execute(sql, new
                {
                    domainId = rec.domainId
                });
            }
            return ret;
        }
    }
}
