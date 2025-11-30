using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Commands.ExercisesReadingCommands;
using E_Learning.Cqrs.Queries.ExercisesReadingQueries;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class ExercisesReadingController(IMediator _mediator) : BaseController
    {
        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var exercise = await _mediator.Send(new GetAllExercisesReadingQuery(exerciseId));
            return View(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ReadingSubmitViewModel model)
        {
            var userId = Guid.NewGuid();

            var vm = await _mediator.Send(new SubmitReadingExerciseCommand(model, userId));
            return View("Result", vm);
        }
    }
}
