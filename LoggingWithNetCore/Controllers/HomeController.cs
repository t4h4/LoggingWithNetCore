using LoggingWithNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingWithNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // ILogger'ı DI ile controller yapimiza dahil ettik. Loglardan ILogger yapisi sorumlu.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; 
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Index sayfasina girildi.");
            _logger.LogDebug("Index sayfasina girildi.");
            _logger.LogInformation("Index sayfasina girildi.");
            _logger.LogWarning("Index sayfasina girildi.");
            _logger.LogCritical("Index sayfasina girildi.");

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
