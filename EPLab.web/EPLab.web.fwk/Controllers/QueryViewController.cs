using EPlab.model.fwk;
using EPLab.dbService;
using EPLab.dbService.fwk;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class QueryViewController : ControllerBase
    {
        protected queryExpressionLib qel;
        protected AdoNet2DataTable a2dt;
        public QueryViewController(
            ) : base("queryViewViewModel", "query view")
        {
            qel = new queryExpressionLib(connS);
            a2dt = new AdoNet2DataTable(connS);
        }
        // todo !!... (2) 接下來query list, then pick 1 query, 輸入查詢欄位, 展示查詢值, 算是execute功能
        /* spec:
         * 1. index選query or view, 
         * 2. 一開始view list為空, 建一個預設的view, 選取所有欄位
         * 3. execute query with view, 要輸入參數, 然後查詢, 將結果呈現於下方清單
         * 4. 已輸入參數的view便可以另存
         * 5. view也要可以選擇顯示的欄位, 這想一想, 還是在第一頁比較容易做, 第二頁就單純查詢
         * 6. 目前還沒有考慮到多組輸入參數，這可能要調整資料庫。另外view也要存到資料庫
         * 7. 原則上view就是查詢欄位，順序? 還有排序欄位, 過濾欄位與值(多欄?)
         * 8. 還是view就乾脆是queue的另存？但要加上多欄過濾條件
         * 9. 若8, 則每query於畫面上要能有顯示所有欄位的選項，實際做法則select與join的所有欄位
         */
        public ActionResult Index()
        {
            queryViewViewModel viewModel = new queryViewViewModel();
            ViewBag.queryIdselected = ddO.queryList();
            return View(viewModel);
        }
        protected string loadCombo4vm(ref queryViewViewModel viewModel)
        {
            string ret = "";
            if (viewModel.queryPara.queryPara.ContainsKey("dealdate"))
            {
                if (viewModel.queryPara.queryPara["dealdate"].comboboxSource == null
                    || viewModel.queryPara.queryPara["dealdate"].comboboxSource.Count == 0)
                {
                    List<string> dealdates = qel.fieldDropdownList(
                        "QohlcBydate", "dealdate", "");
                    //queryParameterViewModel subvm = new queryParameterViewModel();
                    List<KeyValuePair<string, string>> comboSource =
                        new List<KeyValuePair<string, string>>();
                    foreach (string dealdate in dealdates)
                        comboSource.Add(new KeyValuePair<string, string>(dealdate, dealdate));
                    viewModel.queryPara.queryPara["dealdate"].comboboxSource = comboSource;
                    //viewModel.queryPara.queryPara["dealdate"] = subvm;
                    Thread.Sleep(0);
                }
            }
            return ret;
        }
        [HttpPost]
        public ActionResult Index(queryViewViewModel viewModel)
        {
            ActionResult ar;
            if (viewModel.queryPara == null && TempData.ContainsKey("queryPara"))
                viewModel.queryPara = (queryParasViewModel)TempData["queryPara"];
            else
                viewModel.queryPara = new queryParasViewModel();
            viewModel.clearMsg();
            ViewBag.queryIdselected = ddO.queryList();
            switch (viewModel.cmd)
            {
                case "selectChange":
                    if (string.IsNullOrWhiteSpace(viewModel.currentQuery.queryName))
                    {
                        TempData.Remove("queryPara");
                        ar = View(viewModel);
                        return ar;
                    }
                    // load parameters
                    List<string> strLst = qel.formParameters(viewModel.currentQuery.queryName);
                    viewModel.queryPara = new queryParasViewModel ();
                    foreach (string str1 in strLst)
                        viewModel.queryPara.queryPara.Add(str1, 
                            new queryParameterViewModel());
                    string err = loadCombo4vm(ref viewModel);
                    //todo (2) parameter like dealdate can be a list as well
                    ar = View(viewModel);
                    break;
                case "execute":
                    if (string.IsNullOrWhiteSpace(viewModel.currentQuery.queryName))
                    {
                        viewModel.errorMsg = "no query selected";
                        ar = View(viewModel);
                        break;
                    }
                    foreach(string key in Request.Form)
                    {
                        if (key.StartsWith("para_"))
                        {
                            string theValue = Request.Form[key];
                            if (string.IsNullOrWhiteSpace(theValue))
                            {
                                viewModel.errorMsg = $"parameter {key} cannot be empty!";
                                break;
                            }
                            queryParameterViewModel valObj = 
                                new queryParameterViewModel(theValue);
                            string key2 = key.Replace("para_", "");
                            if (viewModel.queryPara.queryPara.ContainsKey(key2))
                                viewModel.queryPara.queryPara[key2] = valObj;
                            else
                                viewModel.queryPara.queryPara.Add(key2, valObj);
                            err = loadCombo4vm(ref viewModel);
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(viewModel.errorMsg))
                    {
                        ar = View(viewModel);
                        break;
                    }
                    // then type in parameter to execute query
                    string sqlCount = "";
                    string sql1000 = qel.finalSql4query(viewModel.currentQuery.queryName
                        , out sqlCount);

                    // @queryName passed in 
                    //undone !!...(1) 這下可好了，本來都做完了，後來想拿掉rowId, dealMonth, section,
                    //從queryfield刪掉第一筆與最後兩筆，失敗後再加回第一筆，就變現在這樣
                    List<SqlParameter> para = new List<SqlParameter>
                    {
                        new SqlParameter
                        {
                            ParameterName = "@queryName",
                            SqlDbType = SqlDbType.NVarChar,
                            Value = viewModel.currentQuery.queryName
                        },
                        new SqlParameter
                        {
                            ParameterName = "@dealdate",
                            SqlDbType = SqlDbType.NVarChar,
                            Value = viewModel.queryPara.queryPara["dealdate"].paraValue
                        }
                    };
                    int tmpRecords = 0;
                    viewModel.queryResult = a2dt.Select2DataTable(sqlCount, sql1000
                        , out tmpRecords, para);
                    viewModel.result2display = new bigQueryResult(
                        viewModel.queryResult);
                    viewModel.totalRecords = tmpRecords;
                        // dt render to view
                    ar = View(viewModel);
                    break;
                default:
                    ar = View(viewModel);
                    break;
            }
            TempData["queryPara"] = viewModel.queryPara;
            return ar;
        }
    }
}