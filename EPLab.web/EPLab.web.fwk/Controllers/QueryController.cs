using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class QueryController : Controller
    {
        // todo !!... (1) 接下來query list, then pick 1 query, 輸入查詢欄位, 展示查詢值, 算是execute功能
        public ActionResult Index()
        {
            return View();
        }
    }
}