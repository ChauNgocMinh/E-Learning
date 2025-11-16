using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Queries.ExercisesReadingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExercisesReadingController(IMediator _mediator) : BaseController
    {
        public async Task<IActionResult> Index(Guid ExerciseId)
        {
            var query = new GetAllExercisesReadingQuery(ExerciseId);
            var result = await _mediator.Send(query);
            return View(result);
        }
    }
}
