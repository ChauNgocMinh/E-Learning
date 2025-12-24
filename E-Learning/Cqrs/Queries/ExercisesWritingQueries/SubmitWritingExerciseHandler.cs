/*using E_Learning.Cqrs.Commands.ExercisesWritingCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Services;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace E_Learning.Cqrs.Handlers.ExercisesWritingHandlers;
public class SubmitWritingExerciseHandler
    : IRequestHandler<SubmitWritingExerciseCommand, SubmissionResultViewModel>
{
    private readonly ApplicationDbContext _context;
    private readonly IWritingAiService _ai;

    public SubmitWritingExerciseHandler(ApplicationDbContext context, IWritingAiService ai)
    {
        _context = context;
        _ai = ai;
    }

    public async Task<SubmissionResultViewModel> Handle(
        SubmitWritingExerciseCommand request,
        CancellationToken cancellationToken)
    {
        var exercise = await _context.Exercises.FirstAsync(x => x.Id == request.ExerciseId);

        var aiResult = await _ai.EvaluateEssay(request.EssayText);

        var result = new SubmissionResultViewModel
        {
            SubmissionId = Guid.NewGuid(),
            ExerciseId = exercise.Id,
            ExerciseTitle = exercise.Title,
            TotalScore = (short)Math.Round(aiResult.Band),
            TotalQuestions = 1,
            SubmittedAt = DateTime.UtcNow,
            Details = new()
        };

        var submission = new Submission
        {
            Id = result.SubmissionId,
            UserId = request.UserId,
            ExerciseId = request.ExerciseId,
            ResultJson = JsonSerializer.Serialize(new
            {
                exercise.Title,
                aiResult.Band,
                aiResult.Strengths,
                aiResult.Weaknesses,
                aiResult.Suggestions,
                essay = request.EssayText
            }),
            TotalScore = result.TotalScore
        };

        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();

        return result;
    }
}
*/