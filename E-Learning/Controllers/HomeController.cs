using E_Learning.Controllers.SystemControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
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
