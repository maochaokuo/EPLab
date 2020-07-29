using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPLab.web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using EPLab.entity.Models;
using System.Configuration;

namespace EPLab.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration _configuration { get; set; }

        public HomeController(ILogger<HomeController> logger
            , IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string conn = _configuration.GetConnectionString("myConn");
            //string conns=configurationm
            //EPLlabDBContext db = new EPLlabDBContext();
            //string conn = ConfigManager.Server;// _configManager.GetConnectionString("Server");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
