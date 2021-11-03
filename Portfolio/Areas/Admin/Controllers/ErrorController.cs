using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.Error = "Page is not found";
                    break;

                default:
                    ViewBag.Error = "Undefined error";
                    break;
            }
            return View();
        }
    }
}
