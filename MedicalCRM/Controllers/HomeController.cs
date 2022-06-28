using GemBox.Document;
using MedicalCRM.Models;
using MedicalCRM.Models.ChatModels;
using Microsoft.AspNetCore.Mvc;
using MedicalCRM.Extensions;
using System.Diagnostics;

namespace MedicalCRM.Controllers {
    public class HomeController : BaseController {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public async Task<IActionResult> Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}