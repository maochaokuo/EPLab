using EPlab.entity.fwk;
using EPlab.model.fwk;
using EPLab.dbService;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace EPLab.web.Controllers
{
    public class FieldController : ControllerBase
    {
        public FieldController(
            ) : base("fieldsViewModel", "field")
        {
        }

        public ActionResult Index()
        {
            if (Session["tableName"] == null)
                return RedirectToAction("Index", "Table");
            fieldsViewModel viewModel;
            var queryModel = TempData[modelName];
            if (queryModel == null)
                viewModel = new fieldsViewModel();
            else
                viewModel = (fieldsViewModel)queryModel;
            ViewBag.pageStatus = TempData[PageStatus];
            if (ViewBag.pageStatus == null)
                ViewBag.pageStatus = (int)PAGE_STATUS.QUERY;
            //todo .... ViewBag.tableList = ddO.tableList();
            TempData[modelName] = viewModel;
            TempData[PageStatus] = ViewBag.pageStatus;
            return View(viewModel);
        }
            // todo !!... (2) field list of a field 
    }
}
