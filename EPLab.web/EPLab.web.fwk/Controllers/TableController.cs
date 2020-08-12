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
    public class TableController : ControllerBase
    //public class TableController : ControllerBase
    {
        //move back to framework

        //protected const string PageStatus = "pageStatus";
        //protected const string MultiSelect = "multiSelect";
        //protected readonly string modelName;
        //protected readonly string modelMessage;
        public TableController() : base("tablesViewModel"
            , "table")
        {
            //this.modelName = ; 
            //this.modelMessage = "table";
        }
        public ActionResult Index()
        {
            tablesViewModel viewModel;
            var queryModel = TempData[modelName];
            if (queryModel == null)
                viewModel = new tablesViewModel();
            else
                viewModel = (tablesViewModel)queryModel;
            ViewBag.pageStatus = TempData[PageStatus];
            if (ViewBag.pageStatus == null)
                ViewBag.pageStatus = (int)PAGE_STATUS.QUERY;
            ViewBag.tableList = ddO.tableList();
            TempData[modelName] = viewModel;
            TempData[PageStatus] = ViewBag.pageStatus;
            return View(viewModel);
        }
        protected string query(ref tablesViewModel viewModel)
        {
            string ret = "";
            tableDisp tmpModel = viewModel.editModel;
            tableLib tlib = new tableLib(connEPLabDB);
            var paras = new Dapper.DynamicParameters();
            paras.Add("TableName", tmpModel.tableName+"", DbType.String);
            paras.Add("TableDesc", tmpModel.tableDesc+"", DbType.String);
            string sql = @"
select * 
from tables 
where (@TableName='' or tablename=@TableName)
    and (@TableDesc='' or tableDesc=@TableDesc)
";
            var qry = tlib.Query<tableDisp>(sql, paras);
            if (qry.Any())
                viewModel.queryResult = qry.ToList();
            else
                viewModel.queryResult = null;
            return ret;
        }
        protected string checkForm(tablesViewModel viewModel)
        {
            string ret = "";
            if (string.IsNullOrWhiteSpace(viewModel.editModel.tableName))
                ret = "table name cannot be empty";
            return ret;
        }
        [HttpPost]
        public ActionResult Index(tablesViewModel viewModel)
        {
            ActionResult ar;
            string multiSelect = Request.Form[MultiSelect]+"";
            tablesViewModel tmpVM;
            viewModel.clearMsg();
            ViewBag.pageStatus = TempData[PageStatus];
            if (ViewBag.pageStatus == null)
                ViewBag.pageStatus = (int)PAGE_STATUS.QUERY;
            tableLib dapperLib = new tableLib(connEPLabDB);
            EPLabDBbigger bigLib = new EPLabDBbigger(connEPLabDB);
            string tableId;
            string tableName;
            tables model;
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
                    viewModel.editModel = new tableDisp();
                    ViewBag.pageStatus = (int)PAGE_STATUS.ADD;
                    TempData[modelName] = null;
                    TempData[PageStatus] = ViewBag.pageStatus;
                    ar = RedirectToAction("Index");
                    return ar;
                case "update":
                    model = dapperLib.GetOne(new Guid( viewModel.singleSelect));
                    if (model != null)
                    {
                        tmpVM = new tablesViewModel();
                        tmpVM.editModel = JsonConvert.DeserializeObject<tableDisp>(
                            JsonConvert.SerializeObject(model));
                        TempData[PageStatus] = (int)PAGE_STATUS.EDIT;
                        TempData[modelName] = tmpVM;
                        ar = RedirectToAction("Index");
                        return ar;
                    }
                    viewModel.errorMsg = $"error reading this {modelMessage}";
                    ar = View(viewModel);
                    break;
                case "fields":
                    tableId = viewModel.singleSelect;
                    tableName = dapperLib.TableNameById(new Guid( tableId));
                    if (!string.IsNullOrWhiteSpace(tableName))
                    {
                        Session["tableId"] = tableId;
                        Session["tableName"] = tableName;
                        ar = RedirectToAction("Index", "Field");
                        return ar;
                    }
                    viewModel.errorMsg = $"error reading this {modelMessage}";
                    ar = View(viewModel);
                    break;
                case "rows":
                    tableId = viewModel.singleSelect;
                    tableName = dapperLib.TableNameById(new Guid(tableId));
                    if (!string.IsNullOrWhiteSpace(tableName))
                    {
                        Session["tableId"] = tableId;
                        Session["tableName"] = tableName;
                        ar = RedirectToAction("Index", "Row");
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
                        viewModel.editModel.tableId = 
                            bigLib.getNewId("tables");
                        model = JsonConvert.DeserializeObject<tables>(
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
                        var qry = dapperLib.GetOne(viewModel.editModel.tableId);
                        if (qry != null)
                        {
                            model = JsonConvert.DeserializeObject<tables>(
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
