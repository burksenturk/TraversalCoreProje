﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index Sayfası Çağırıldı"); //bunların aşama enumları var unutma Debug = 1,Information = 2,Warning = 3,Error = 4,         
            _logger.LogError("Error log çağırıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime d =Convert.ToDateTime(DateTime.Now.ToLongDateString());
            _logger.LogInformation(d + "Privacy sayfası Çağırıldı");  //output çıktısı
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test Sayfası Çağırıldı");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
