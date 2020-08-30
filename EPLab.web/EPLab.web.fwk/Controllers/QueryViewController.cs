using EPlab.entity.fwk;
using EPlab.model.fwk;
using EPLab.dbService;
using EPLab.dbService.fwk;
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
        [HttpPost]
        public ActionResult Index(queryViewViewModel viewModel)
        {
            ActionResult ar;
            viewModel.clearMsg();
            queryExpressionLib qel = new queryExpressionLib(connS);
            switch (viewModel.cmd)
            {
                case "selectChange":
                    // load parameters
                    viewModel.queryPara = qel.formParameters(viewModel.currentQuery.queryName);
                    //todo (2) parameter like dealdate can be a list as well
                    ar = View(viewModel);
                    break;
                case "execute":
                    //todo (1) then type in parameter to execute query
                    string sql = qel.finalSql4query(viewModel.currentQuery.queryName);
                    //DataTable dt = ... 
                        // todo !!...(1)
                    //viewModel.queryResult = dt;
                    ar = View(viewModel);
                    break;
                default:
                    ar = View(viewModel);
                    break;
            }
            return ar;
        }
    }
}