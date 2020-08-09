using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EPLab.web.Controllers
{
    public class TableController : Controller
    //public class TableController : ControllerBase
    {
        //protected const string PageStatus = "pageStatus";
        //protected const string MultiSelect = "multiSelect";
        protected readonly string modelName;
        protected readonly string modelMessage;
        public TableController()//string modelName, string modelMessage)
        {
            this.modelName = "tablesViewModel"; 
            this.modelMessage = "table";
        }
        public IActionResult Index()
        {
            // todo !!... (1) table list and link 
            return View();
        }
    }
}
