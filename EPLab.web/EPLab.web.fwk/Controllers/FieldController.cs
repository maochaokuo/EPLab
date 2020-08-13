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
            ViewBag.fieldList = ddO.fieldList(Session["tableId"]+"");
            TempData[modelName] = viewModel;
            TempData[PageStatus] = ViewBag.pageStatus;
            return View(viewModel);
        }
        protected string query(ref fieldsViewModel viewModel)
        {
            string ret = "";
            fieldDisp tmpModel = viewModel.editModel;
            fieldLib flib = new fieldLib(connEPLabDB);
            var paras = new Dapper.DynamicParameters();
            paras.Add("tableIdQ", tmpModel.tableIdQ+"", DbType.String);
            paras.Add("fieldName", tmpModel.fieldName + "", DbType.String);
            paras.Add("fieldDesc", tmpModel.fieldDesc + "", DbType.String);
            string sql = @"
select * 
from fields 
where (@tableIdQ='' or tableId=@tableIdQ)
    and (@fieldName='' or fieldName=@fieldName)
    and (@fieldDesc='' or fieldDesc=@fieldDesc)
order by defaultOrder
";
            var qry = flib.Query<fieldDisp>(sql, paras);
            if (qry.Any())
                viewModel.queryResult = qry.ToList();
            else
                viewModel.queryResult = null;
            return ret;
        }
        protected string checkForm(fieldsViewModel viewModel)
        {
            string ret = "";
            if (viewModel.editModel.tableId == Guid.Empty)
                ret = "tableId cannot be empty";
            else if (string.IsNullOrWhiteSpace(viewModel.editModel.fieldName))
                ret = "field name cannot be empty";
            return ret;
        }
        // todo !!... (2) field list of a field 
    }
}
