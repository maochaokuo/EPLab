﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPLab.web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using EPLab.entity.Models;
using System.Configuration;
using EPLab.dbService;
using System.Data;

namespace EPLab.web.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected IConfiguration _configuration { get; set; }
        protected string connIndices = "";
        protected string connEPLabDB = "";

        public HomeController(ILogger<HomeController> logger
            , IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            connIndices = _configuration.GetConnectionString("indices2");
            connEPLabDB = _configuration.GetConnectionString("EPLlabDB");
        }

        public IActionResult Index()
        {
            Dapper2DataTable dtdSrc = new Dapper2DataTable(connIndices);
            Dapper2DataTable dtdTar = new Dapper2DataTable(connEPLabDB);
            //            string sql = @"
            //select dealdate, dealtime, [open], high, low, [close], volume, dealmonth, section
            //from indices2.dbo.ohlc
            //where dealdate<='20180630'
            //order by dealdate, dealtime
            //";
            //            DataTable dt = dtd.Select2DataTable(sql);

            string sql2 = @"
SELECT dealdate, dealtime, [close], sVolume, aVolume, lastdate, lastclose, lastSvolume, lastAvolume
FROM [indices2].[dbo].[dealdates]
where dealdate<='20180731'
order by dealdate
";
            DataTable dt2 = dtdSrc.Select2DataTable(sql2);
            string err = dtdTar.ImportDataTableSaveas(dt2
                , "dealdates");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
