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
        /* spec:
         * 1. index選query or view, 
         * 2. 一開始view list為空, 建一個預設的view, 選取所有欄位
         * 3. execute query with view, 要輸入參數, 然後查詢, 將結果呈現於下方清單
         * 4. 已輸入參數的view便可以另存
         * 5. view也要可以選擇顯示的欄位, 這想一想, 還是在第一頁比較容易做, 第二頁就單純查詢
         * 6. 目前還沒有考慮到多組輸入參數，這可能要調整資料庫。另外view也要存到資料庫
         */
        public ActionResult Index()
        {
            return View();
        }
    }
}