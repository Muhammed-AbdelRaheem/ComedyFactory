using Data.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class SuccessController : BaseController
    {




        public IActionResult Index(string language = "en")
        {
            if (language == "ar")
                return View("Ar");

            return View("Index");
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
