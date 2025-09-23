using Data.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BoxingUi.Controllers
{
    public class SuccessController : Controller
    {




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ar()
        {
            return View();
        }



        public IActionResult EnFailed()
        {
            return View();
        }
        public IActionResult ArFailed()
        {
            return View();
        }

    }
}
