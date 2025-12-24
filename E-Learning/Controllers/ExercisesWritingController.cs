using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Queries.ExercisesWritingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExercisesWritingController(IMediator _mediator) : BaseController
    {
        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var vm = await _mediator.Send(new GetWritingExerceQuery(exerciseId));
            return View(vm);
        }
    }
}
