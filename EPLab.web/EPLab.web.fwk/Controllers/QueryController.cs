﻿using EPlab.entity.fwk;
using EPlab.model.fwk;
using EPLab.dbService;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace EPLab.web.fwk.Controllers
{
    public class QueryController : ControllerBase
    {
        public QueryController(
            ) : base("queriesViewModel", "query")
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}