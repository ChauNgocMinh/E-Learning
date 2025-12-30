using E_Learning.Cqrs.Commands.ExercisesWritingCommands;
using E_Learning.Cqrs.Queries.ExercisesWritingQueries;
using E_Learning.Cqrs.Queries.SubmissionQueries;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class ExercisesWritingController : Controller
{
    private readonly IMediator _mediator;

    public ExercisesWritingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(Guid exerciseId)
    {
        var vm = await _mediator.Send(new GetWritingExerceQuery(exerciseId));
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(WritingSubmitViewModel model)
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

        var submissionResult = await _mediator.Send(
            new SubmitWritingCommand
            {
                ExerciseId = model.ExerciseId,
                UserId = userId,
                EssayText = model.EssayText
            }
        );

    
        return RedirectToAction(
            "Result",
            new { submissionId = submissionResult.SubmissionId }
        );
    }

 public async Task<IActionResult> Result(Guid submissionId)
{
    var result = await _mediator.Send(
        new GetWritingSubmissionResultQuery(submissionId));

    if (result == null)
        return RedirectToAction(nameof(MySubmissions));

    return View(result);
}

    public async Task<IActionResult> MySubmissions()
    {
        Guid userId;

        if (User.Identity?.IsAuthenticated == true)
        {
            userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }
        else
        {
            userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        }

        var list = await _mediator.Send(
     new GetMySubmissionsQuery(userId));


        return View(list);
    }

}
