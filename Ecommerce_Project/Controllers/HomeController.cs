using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Example()
        {
            return View();
        }
    }
}
