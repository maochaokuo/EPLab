﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class FieldValueController : ControllerBase
    {
        public FieldValueController(
            ) : base("fieldValueViewModel", "field value")
        {
        }

        // todo (5) FieldValueController
        public ActionResult Index()
        {
            return View();
        }
    }
}