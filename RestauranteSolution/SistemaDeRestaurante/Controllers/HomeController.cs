using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Logs;
using SistemaDeRestaurante.Models;
using System.Diagnostics;

namespace SistemaDeRestaurante.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISystemLog _log;

        public HomeController(ILogger<HomeController> logger, ISystemLog systemLog)
        {
            _logger = logger;
            _log = systemLog;
        }

        public IActionResult Index()
        {
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
