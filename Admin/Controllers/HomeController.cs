using Admin.Models;
using IoC.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<SharedResource> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

     

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = _localizer["Overview"];
            ViewData["AvailableBlocks"] = null;
            ViewData["FirstBlock"] = null;

            return RedirectToAction("Index", "PersonalData");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
