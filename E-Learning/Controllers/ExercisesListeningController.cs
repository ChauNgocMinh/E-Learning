using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Cqrs.Queries.ExercisesListeningQueries;
using E_Learning.Cqrs.Queries.SubmissionQueries;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers
{
 
    public class ExercisesListeningController(IMediator _mediator) : BaseController
    {
        public async Task<IActionResult> Index(Guid exerciseId)
        {
            var result = await _mediator.Send(new GetListeningExerciseQuery(exerciseId));
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Submit(ListeningSubmitViewModel model)
        {
            Guid userId;

            if (User.Identity?.IsAuthenticated == true)
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                userId = Guid.Parse(userIdClaim!);
            }
            else
            {
              
                userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            }

            var result = await _mediator.Send(
                new SubmitListeningExerciseCommand(
                    model.ExerciseId,
                    userId,
                    model.Answers
                )
            );

            return RedirectToAction(nameof(Result), new { submissionId = result.SubmissionId });
        }


        [HttpGet]
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