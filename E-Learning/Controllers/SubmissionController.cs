using E_Learning.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class SubmissionController : Controller
    {
        public IActionResult Result(SubmissionResultViewModel model)
        {
            return View(model);
        }
    }
}
