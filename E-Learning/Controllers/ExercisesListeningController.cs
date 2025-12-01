using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Cqrs.Queries.ExercisesListeningQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Controllers
{
    public class ExercisesListeningController(IMediator _mediator) : BaseController
    {
        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var result = await _mediator.Send(new GetAllExercisesListeningQuery(exerciseId));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ListeningSubmitViewModel model)
        {
            var userId = Guid.NewGuid();
            var vm = await _mediator.Send(new SubmitListeningExerciseCommand(model, userId));
            return View("Result", vm);
        }
    }
}