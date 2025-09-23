using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var lang = RouteData.Values["language"]?.ToString() ?? "en";

        if (lang == "ar")
        {
            ViewData["Layout"] = "_Layout.ar";
            ViewData["Navbar"] = "_Navbar.ar";
            ViewData["FormView"] = "_Form.ar";
            ViewData["Footer"] = "_footer.ar";


        }
        else
        {
            ViewData["Layout"] = "_Layout";
            ViewData["Navbar"] = "_Navbar";
            ViewData["FormView"] = "_Form";
            ViewData["Footer"] = "_footer";

        }

        base.OnActionExecuting(context);
    }
}
