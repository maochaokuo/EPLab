using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EPLab.web.Controllers
{
    public class RowController : Controller
    {
        public IActionResult Index()
        {
            // todo !!... (2) row list of a table, including all fields, just like datatable
            return View();
        }
    }
}
