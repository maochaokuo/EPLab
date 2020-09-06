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
            //todo !!...(1) 這啦。所以有幾件事要變更，
            //1. 日後要持續重新匯入，每周更新之後
            //2. 只要匯入一個表，直接算出正確大趨勢，可用sp產新資料表
            //   另外直接帶入pre n pre2 high/low, 只做單筆判斷，先這樣做試試
            string ret = "";
            AdoNet2DataTable dtdSrc = new AdoNet2DataTable(connIndices);
            AdoNet2DataTable dtdTar = new AdoNet2DataTable(connEPLabDB);

            string sql2a = @"
SELECT count(*) counts
FROM [indices2].[dbo].[dealdates]
where dealdate between '20180628' and '20200807' 
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