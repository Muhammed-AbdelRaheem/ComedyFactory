using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class TermsAndConditionController : BaseController
    {
        public IActionResult Index(string language = "en")
        {


            if (language == "ar")
                return View("Index.ar");

            return View("Index");
        }
    }
}
