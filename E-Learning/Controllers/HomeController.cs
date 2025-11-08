using E_Learning.Controllers.SystemControllers;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
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

        public IActionResult Courses()
        {
            return View();
        }
    }
}
