using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EPLab.web.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            // todo !!... (2) table list and link 
            return View();
        }
    }
}
