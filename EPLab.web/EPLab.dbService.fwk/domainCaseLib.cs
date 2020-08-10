using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPLab.dbService
{
    public class domainCaseLib : Repository<domainCases>
    {
        public domainCaseLib(string connS) : base(connS)
        {
        }

        public override List<domainCases> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domainCases ";
                var qry = con.Query<domainCases>(sql).ToList();
                return qry;
            }
        }

        public override domainCases GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domainCases " +
                    $"where domainCaseId=@domainCaseId";
                var qry = conn.Query<domainCases>(sql,
                    new { domainId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(domainCases rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into domainCases " +
                    $"(domainCaseId,domainId,domainCaseName," +
                    $"rangeMin,rangeMax,domainCaseDescription) " +
                    $"values (@DomainCaseId,@DomainId,@DomainCaseName," +
                    $"@RangeMin,@RangeMax,@DomainCaseDescription)";
                con.Execute(sql,
                    new
                    {
                        domainCaseId = rec.domainCaseId,
                        domainId = rec.domainId,
                        domainCaseName = rec.domainCaseName,
                        rangeMin = rec.rangeMin,
                        rangeMax = rec.rangeMax,
                        domainCaseDescription = rec.domainCaseDescription
                    });
            }
            return ret;
        }

        public override string Update(domainCases rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update domainCases " +
                    $"set domainId=@DomainId, " +
                    $"domainCaseName=@DomainCaseName, " +
                    $"rangeMin=@RangeMin, rangeMax=@RangeMax, " +
                    $"domainCaseDescription=@DomainCaseDescription" +
                    $"where domainCaseId=@DomainCaseId";
                con.Execute(sql,
                    new
                    {
                        domainCaseId = rec.domainCaseId,
                        domainId = rec.domainId,
                        domainCaseName = rec.domainCaseName,
                        rangeMin = rec.rangeMin,
                        rangeMax = rec.rangeMax,
                        domainCaseDescription = rec.domainCaseDescription
                    });
            }
            return ret;
        }
        public override string Delete(domainCases rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from domainCases " +
                    $"where domainCaseId=@DomainCaseId";
                con.Execute(sql, new
                {
                    domainCaseId = rec.domainCaseId
                });
            }
            return ret;
        }
    }
}
