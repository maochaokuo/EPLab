﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EPLab.web.Controllers
{
    public class FieldController : Controller
    {
        public IActionResult Index()
        {
            // todo !!... (2) field list of a table 
            return View();
        }
    }
}
