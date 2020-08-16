using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class RowController : ControllerBase
    {
        public RowController(
            ) : base("rowViewModel", "row")
        {
        }

        public ActionResult Index()
        {
            if (Session["tableName"] == null)
                return RedirectToAction("Index", "Table");
            // todo (5) row list of a table, including all fields, just like datatable
            return View();
        }
    }
}
