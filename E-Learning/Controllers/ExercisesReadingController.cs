using E_Learning.Cqrs.Commands.ExercisesReadingCommands;
using E_Learning.Cqrs.Queries.ExercisesReadingQueries;
using E_Learning.Cqrs.Queries.SubmissionQueries;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class ExercisesReadingController : Controller
    {
        private readonly IMediator _mediator;

        public ExercisesReadingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var result = await _mediator.Send(
                new GetReadingExerciseQuery(exerciseId)
            );
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ReadingSubmitViewModel model)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? "11111111-1111-1111-1111-111111111111"
            );

            var result = await _mediator.Send(
                new SubmitReadingExerciseCommand(
                    model.ExerciseId,
                    userId,
                    model.Answers
                )
            );

            return RedirectToAction(nameof(Result),
                new { submissionId = result.SubmissionId });
        }

        public async Task<IActionResult> Result(Guid submissionId)
        {
            var result = await _mediator.Send(
                new GetSubmissionResultQuery(submissionId)
            );

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> MySubmissions()
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? "11111111-1111-1111-1111-111111111111" 
            );

            var submissions = await _mediator.Send(
                new GetMySubmissionsQuery(userId)
            );

            return View(submissions);
        }

    }
}
