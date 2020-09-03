using EPLab.dbService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class HomeController : Controller
    {
        protected string connIndices = "";
        protected string connEPLabDB = "";

        public HomeController()
        {
            connIndices = ConfigurationManager.ConnectionStrings["indices2"].ConnectionString;
            connEPLabDB = ConfigurationManager.ConnectionStrings["EPlabContext"].ConnectionString;
        }
        private string import2tables()
        {
            string ret = "";
            AdoNet2DataTable dtdSrc = new AdoNet2DataTable(connIndices);
            AdoNet2DataTable dtdTar = new AdoNet2DataTable(connEPLabDB);
            //            string sql = @"
            //select dealdate+dealtime dealdatetime, dealdate, dealtime, [open], high, low, [close], volume, dealmonth, section
            //from indices2.dbo.ohlc
            //where dealdate between '20180628' and '20200807' and section=1
            //order by dealdate, dealtime
            //            ";
            //            DataTable dt = dtdSrc.Select2DataTable(sql);
            //            string err = dtdTar.ImportDataTableSaveas(dt
            //                , "ohlc");

            string sql2a = @"
SELECT count(*) counts
FROM [indices2].[dbo].[dealdates]
where dealdate between '20180628' and '20200807' 
order by dealdate
";
            string sql2b = @"
SELECT top 1000 dealdate, [close], sVolume, aVolume, lastdate, lastclose, lastSvolume, lastAvolume
FROM [indices2].[dbo].[dealdates]
where dealdate between '20180628' and '20200807' 
order by dealdate
";
            int counts = 0;
            DataTable dt2 = dtdSrc.Select2DataTable(sql2a
                , sql2b, out counts);
            string err2 = dtdTar.ImportDataTableSaveas(dt2
                , "dealdates");

            return ret;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "QueryView");
            //return RedirectToAction("Index", "Table");
            return View();
        }

    }
}