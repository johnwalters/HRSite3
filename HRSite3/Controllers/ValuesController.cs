using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSite;
using Microsoft.AspNetCore.Mvc;

namespace HRSite3.Controllers
{
    public class ValuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetValues()
        {
            var scraper = new DrfScraper();
            scraper.TestEquibaseHAP();
            return "foo";
        }
    }
}