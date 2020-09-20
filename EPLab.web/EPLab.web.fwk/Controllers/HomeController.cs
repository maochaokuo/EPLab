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
            //todo (1), 目前趨勢感覺
            //0.安全機制, 單分鐘內劇烈差距, 就立刻決定趨勢
            //1.day high time, low time相比, 哪個晚就是哪個趨勢
            //1.a. 也是有衰減時間，由最後一次破高破低開始算
            //2.其次看high drop/low rise趨勢反轉, 主趨勢衰減才發揮次趨勢
            //2.a. 看(maxHDcount+1)/(maxLRcount+1)
            //2.b. 看先前到之後有沒有劇烈volume變化, 所以這得要照時間衰減
            //3.則是若趨勢反轉發生, 是否會再反向
            //3.a. 先做好1, 2再觀察
            //3.b. 9/9觀察一，發現有20180705	093700起，highdrop/lowrise雙方都沒有創高，原作法失準，此時應照大趨勢
            //3.c. 所以應該沒有所謂趨勢再反轉，只有大趨勢與反轉趨勢，雙方都會衰減，
            //     大趨勢為主，衰減轉反轉趨勢，反轉趨勢也衰減，就返回大趨勢，就這麼簡單
            //3.d. 可能還差一個問題，若high drop/low rise同時發生，那還是應以原趨勢為主
            //3.e. 2018的，要判斷量的變化，大的變化會造成趨勢的遞延，並不只限單一分鐘
            //3.f. 2018/10/5 not solved
            //3.g. 2018 not bad, but 10/11 whole day -400
            //3.h. 大趨勢
            //3.h.1 low/high其中之一是084500 -> 1
            //3.h.2 low/high其中之一變化 -> 2
            //3.h.3 low/high都不變化了 -> 3
            //3.h.4 如此，2與3界線很模糊，可能只能用次數與量來分
            //3.h.5 10/1,2,4 等天，就是084500就已經2開始

            //todo !!...(-1) !!! 感覺上這樣不行，還是把現有資料，補上所有畫面吧
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