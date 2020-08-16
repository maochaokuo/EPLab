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
            string tableId = Session["tableId"] + "";
            viewModel.editModel.tableId = new Guid(tableId);
            ViewBag.fieldList = ddO.fieldList(tableId);
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
            paras.Add("tableId", tmpModel.tableId, DbType.Guid);
            paras.Add("fieldName", tmpModel.fieldName + "", DbType.String);
            paras.Add("fieldDesc", tmpModel.fieldDesc + "", DbType.String);
            string sql = @"
select * 
from fields 
where (@tableId='00000000-0000-0000-0000-000000000000' or tableId=@tableId)
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
        [HttpPost]
        public ActionResult Index(fieldsViewModel viewModel)
        {
            if (Session["tableName"] == null)
                return RedirectToAction("Index", "Table");
            ActionResult ar;
            string multiSelect = Request.Form[MultiSelect] + "";
            fieldsViewModel tmpVM;
            viewModel.clearMsg();
            ViewBag.pageStatus = TempData[PageStatus];
            if (ViewBag.pageStatus == null)
                ViewBag.pageStatus = (int)PAGE_STATUS.QUERY;
            fieldLib dapperLib = new fieldLib(connEPLabDB);
            EPLabDBbigger bigLib = new EPLabDBbigger(connEPLabDB);
            string tableId=Session["tableId"]+"";
            viewModel.editModel.tableId = new Guid(tableId);
            ViewBag.fieldList = ddO.fieldList(tableId);
            ViewBag.domainList = ddO.domainList();
            fields model;
            switch (viewModel.cmd)
            {
                case "query":
                    if (ViewBag.pageStatus <= (int)PAGE_STATUS.QUERY)
                    {
                        viewModel.errorMsg = query(ref viewModel);
                        ar = View(viewModel);
                    }
                    else
                    {
                        ViewBag.pageStatus = (int)PAGE_STATUS.QUERY;
                        TempData[modelName] = null;
                        TempData[PageStatus] = ViewBag.pageStatus;
                        ar = RedirectToAction("Index");
                        return ar;
                    }
                    break;
                case "add":
                case "addNew":
                    viewModel.editModel = new fieldDisp();
                    ViewBag.pageStatus = (int)PAGE_STATUS.ADD;
                    TempData[modelName] = null;
                    TempData[PageStatus] = ViewBag.pageStatus;
                    ar = RedirectToAction("Index");
                    return ar;
                case "update":
                    model = dapperLib.GetOne(new Guid(viewModel.singleSelect));
                    if (model != null)
                    {
                        tmpVM = new fieldsViewModel();
                        tmpVM.editModel = JsonConvert.DeserializeObject<fieldDisp>(
                            JsonConvert.SerializeObject(model));
                        TempData[PageStatus] = (int)PAGE_STATUS.EDIT;
                        TempData[modelName] = tmpVM;
                        ar = RedirectToAction("Index");
                        return ar;
                    }
                    viewModel.errorMsg = $"error reading this {modelMessage}";
                    ar = View(viewModel);
                    break;
                case "delete":
                    if (string.IsNullOrWhiteSpace(multiSelect))
                        viewModel.errorMsg = $"please select {modelMessage} to delete";
                    else
                    {
                        string[] selected = multiSelect.Split(',');
                        foreach (string recId in selected.ToList())
                        {
                            model = dapperLib.GetOne(new Guid(recId));
                            if (model == null)
                                continue;
                            viewModel.errorMsg += dapperLib.Delete(model);
                        }
                        if (string.IsNullOrWhiteSpace(viewModel.errorMsg))
                        {
                            viewModel.successMsg = "successfully deleted";
                            viewModel.errorMsg = query(ref viewModel);
                        }
                    }
                    ar = View(viewModel);
                    break;
                case "save":
                    string err = checkForm(viewModel);
                    if (err.Length > 0)
                    {
                        viewModel.errorMsg = err;
                        ar = View(viewModel);
                        break;
                    }
                    if (ViewBag.pageStatus == (int)PAGE_STATUS.ADD)
                    {
                        viewModel.editModel.fieldId = bigLib.getNewId("fields");
                        model = JsonConvert.DeserializeObject<fields>(
                            JsonConvert.SerializeObject(viewModel.editModel));
                        viewModel.errorMsg = dapperLib.Insert(model);
                        if (string.IsNullOrWhiteSpace(viewModel.errorMsg))
                        {
                            viewModel.successMsg = $"new {modelMessage} added";
                            ViewBag.pageStatus = (int)PAGE_STATUS.ADDSAVED;
                        }
                    }
                    else if (ViewBag.pageStatus == (int)PAGE_STATUS.EDIT)
                    {
                        var qry = dapperLib.GetOne(viewModel.editModel.fieldId);
                        if (qry != null)
                        {
                            model = JsonConvert.DeserializeObject<fields>(
                                JsonConvert.SerializeObject(viewModel.editModel));
                            viewModel.errorMsg = dapperLib.Update(model);
                            if (string.IsNullOrWhiteSpace(viewModel.errorMsg))
                            {
                                viewModel.successMsg = $"{modelMessage} updated";
                                ViewBag.pageStatus = (int)PAGE_STATUS.SAVED;
                            }
                        }
                        else
                            viewModel.errorMsg = $"{modelMessage} not found";
                    }
                    else
                        viewModel.errorMsg = $"wrong page status {ViewBag.pageStatus}";
                    ar = View(viewModel);
                    break;
                default:
                    ar = View(viewModel);
                    break;
            }
            TempData[modelName] = viewModel;
            TempData[PageStatus] = ViewBag.pageStatus;
            return ar;
        }
    }
}
