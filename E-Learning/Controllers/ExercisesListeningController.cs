using E_Learning.Controllers.SystemControllers;
using E_Learning.Cqrs.Commands.ExercisesLearningCommands;
using E_Learning.Cqrs.Queries.ExercisesListeningQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Controllers { 
public class ExercisesListeningController(IMediator _mediator, ApplicationDbContext _context) : BaseController
{
    public async Task<IActionResult> Index(Guid exerciseId)
    {
        var result = await _mediator.Send(new GetAllExercisesListeningQuery(exerciseId));
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Submit(ListeningSubmitViewModel model)
    {
        Guid userId = Guid.NewGuid();
        var command = new SubmitListeningExerciseCommand(
            model.ExerciseId,
            userId,
            model.Answers
        );
        var result = await _mediator.Send(command);
        return RedirectToAction("Result", new { submissionId = result.Id });
    }

    public async Task<IActionResult> Result(Guid submissionId)
    {
        var submission = await _context.ExerciseSubmissions
            .Include(x => x.Details)
            .ThenInclude(d => d.ExerciseListening)
            .FirstOrDefaultAsync(s => s.Id == submissionId);
        if (submission == null)
            return NotFound("Không tìm thấy bài đã nộp");
        return View(submission);
    }
}
}