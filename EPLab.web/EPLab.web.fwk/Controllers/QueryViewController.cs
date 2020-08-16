using EPlab.entity.fwk;
using EPlab.model.fwk;
using EPLab.dbService;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class QueryViewController : ControllerBase
    {
        public QueryViewController(
            ) : base("queryViewViewModel", "query view")
        {
        }
        // todo !!... (1) 接下來query list, then pick 1 query, 輸入查詢欄位, 展示查詢值, 算是execute功能
        public ActionResult Index()
        {
            return View();
        }
    }
}