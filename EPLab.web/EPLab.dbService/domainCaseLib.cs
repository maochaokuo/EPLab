using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class domainCaseLib : Repository<DomainCases>
    {
        public domainCaseLib(string connS) : base(connS)
        {
        }

        public override List<DomainCases> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domainCases ";
                var qry = con.Query<DomainCases>(sql).ToList();
                return qry;
            }
        }

        public override DomainCases GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from domainCases " +
                    $"where domainCaseId=@domainCaseId";
                var qry = conn.Query<DomainCases>(sql,
                    new { domainId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(DomainCases rec)
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
                        domainCaseId = rec.DomainCaseId,
                        domainId = rec.DomainId,
                        domainCaseName = rec.DomainCaseName,
                        rangeMin = rec.RangeMin,
                        rangeMax = rec.RangeMax,
                        domainCaseDescription = rec.DomainCaseDescription
                    });
            }
            return ret;
        }

        public override string Update(DomainCases rec)
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
                        domainCaseId = rec.DomainCaseId,
                        domainId = rec.DomainId,
                        domainCaseName = rec.DomainCaseName,
                        rangeMin = rec.RangeMin,
                        rangeMax = rec.RangeMax,
                        domainCaseDescription = rec.DomainCaseDescription
                    });
            }
            return ret;
        }
        public override string Delete(DomainCases rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from domainCases " +
                    $"where domainCaseId=@DomainCaseId";
                con.Execute(sql, new
                {
                    domainCaseId = rec.DomainCaseId
                });
            }
            return ret;
        }

    }
}
