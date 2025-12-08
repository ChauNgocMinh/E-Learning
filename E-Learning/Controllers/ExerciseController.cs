
using E_Learning.Controllers.SystemControllers;
using E_Learning.Domain.Entities;
using E_Learning.Repositories.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExerciseController(ICommonRepository<Exercise> _repo) : BaseController
    {
        public async Task<IActionResult> Index(short? page, short? pageSize)
        {
            var result = await _repo.GetAllAsync(page, pageSize);
            return View(result);
        }
    }
}
