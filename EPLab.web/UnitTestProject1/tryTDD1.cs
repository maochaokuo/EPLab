using EPlab.entity.fwk;
using EPLab.dbService.fwk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class tryTDD1
    {
        protected readonly string connS;
        public tryTDD1()
        {
            connS = "data source=.;initial catalog=EPLlabDB;persist security info=True;user id=sa;password=sa;MultipleActiveResultSets=True;App=EntityFramework";
        }
        [TestMethod]
        public void generate1stQuery()
        {
            queryExpressionLib qel = new queryExpressionLib(connS);
            qel.rowsSql("QohlcBydate");
            Thread.Sleep(0);
        }
        //private queries GetQuery(string queryName)
        //{
        //    queries ret = null;
        //    // 先hard code, QohlcBydate
        //    queries tmpQohlcBydate = new queries();
        //    tmpQohlcBydate.queryId = Guid.NewGuid();
        //    tmpQohlcBydate.queryName = "QohlcBydate";
        //    tmpQohlcBydate.queryDesc = "query for table ohlc by dealdate";
        //    tmpQohlcBydate.tableId = new Guid("DDC58962-C0AE-4327-9ED9-D9E516244431");
        //    tmpQohlcBydate.tableAlias = "ohlc";
        //    tmpQohlcBydate.whereExpressionId = new Guid("E0D487F4-7F90-47AE-B2CE-A1B9C5FE88B6");

        //    // later read from database
        //    return ret;
        //}
    }
}
