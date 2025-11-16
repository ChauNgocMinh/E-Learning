
using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Queries.ExercisesQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExerciseController(IMediator _mediator) : BaseController
    {
        public async Task<IActionResult> Index(GetAllExercisesQuery query)
        {
            var result = await _mediator.Send(query);
            return View(result);
        }
    }
}
