using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Cqrs.Queries.ExercisesListeningQueries;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExercisesListeningController(IMediator _mediator) : BaseController
    {
   
        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var vm = await _mediator.Send(new GetListeningExerciseQuery(exerciseId));
            return View(vm);
        }
        
        [HttpPost]
        public async Task<IActionResult> Submit(ListeningSubmitViewModel model)
        {
            var userId = GetUserId() ?? Guid.Empty;

            var result = await _mediator.Send(
                new SubmitListeningExerciseCommand(model, userId)
            );

            return View("Result", result);
        }

    }
}
