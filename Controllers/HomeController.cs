using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BinghamRailroad.Models;
using BinghamRailroad.Data;

namespace BinghamRailroad.Controllers
{
    public class HomeController : Controller
    {
        private readonly BingRailContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BingRailContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allStations = (from Station in _context.Set<Station>()
            select Station).ToList();
            ViewData["Stations"] = allStations;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult AccountInfo()
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
