using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Queries.ExercisesSpeakingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExercisesSpeakingController(IMediator _mediator) : BaseController
    {
        
        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var vm = await _mediator.Send(new GetSpeakingExerciseQuery(exerciseId));
            return View(vm);
        }
    }
}
