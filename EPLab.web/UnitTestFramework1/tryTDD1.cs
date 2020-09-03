using System;
using System.Threading;
using EPLab.dbService.fwk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFramework1
{
    [TestClass]
    public class tryTDD1
    {
        protected readonly string connS;
        public tryTDD1()
        {
            connS = "data source=.;initial catalog=EPLlabDB;persist security info=True;user id=sa;password=sa;MultipleActiveResultSets=True;App=EntityFramework";
        }
        //[TestMethod]
        //public void generate1stQuery()
        //{
        //    queryExpressionLib qel = new queryExpressionLib(connS);
        //    string sqlOrderBy = "";
        //    string sqlOrderWith = "";
        //    string sql = qel.rowsSql("QohlcBydate", "fwo"
        //        , out sqlOrderBy, out sqlOrderWith);
        //    Thread.Sleep(0);
        //}
        [TestMethod]
        public void finalSql4query()
        {
            queryExpressionLib qel = new queryExpressionLib(connS);
            string sqlCount = "";
            string sql1000 = qel.finalSql4query("QohlcBydate", out sqlCount);
            Thread.Sleep(0);
        }
    }
}
