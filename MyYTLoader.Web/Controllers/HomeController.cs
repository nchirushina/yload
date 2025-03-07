using Microsoft.AspNetCore.Mvc;
using MyYTLoader.Domain;
using MyYTLoader.Web.Models;
using System.Diagnostics;

namespace MyYTLoader.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogsProvider _logsProvider;

        public HomeController(ILogger<HomeController> logger, ILogsProvider logsProvider)
        {
            _logger = logger;
            _logsProvider = logsProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Logs = _logsProvider.GetLogs();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
