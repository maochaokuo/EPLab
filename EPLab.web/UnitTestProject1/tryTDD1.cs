using EPlab.entity.fwk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class tryTDD1
    {
        [TestMethod]
        public void generate1stQuery()
        {

        }
        private queries GetQuery(string queryName)
        {
            queries ret = null;
            // 先hard code, QohlcBydate
            queries tmpQohlcBydate = new queries();
            tmpQohlcBydate.queryId = Guid.NewGuid();
            tmpQohlcBydate.queryName = "QohlcBydate";
            tmpQohlcBydate.queryDesc = "query for table ohlc by dealdate";
            tmpQohlcBydate.tableId = new Guid("DDC58962-C0AE-4327-9ED9-D9E516244431");
            tmpQohlcBydate.tableAlias = "ohlc";

            // later read from database
            return ret;
        }
    }
}
