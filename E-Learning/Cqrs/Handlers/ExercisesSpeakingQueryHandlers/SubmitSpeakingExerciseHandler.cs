/*using E_Learning.Cqrs.Commands.ExercisesSpeakingCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Services;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class SubmitSpeakingExerciseHandler
    : IRequestHandler<SubmitSpeakingExerciseCommand, SubmissionResultViewModel>
{
    private readonly ApplicationDbContext _context;
    private readonly ISpeakingAiService _ai;

    public SubmitSpeakingExerciseHandler(ApplicationDbContext context, ISpeakingAiService ai)
    {
        _context = context;
        _ai = ai;
    }

    public async Task<SubmissionResultViewModel> Handle(
        SubmitSpeakingExerciseCommand request,
        CancellationToken cancellationToken)
    {
        var exercise = await _context.Exercises.FirstAsync(x => x.Id == request.ExerciseId);

        var aiResult = await _ai.EvaluateSpeaking(request.AudioFileUrl);

        var result = new SubmissionResultViewModel
        {
            SubmissionId = Guid.NewGuid(),
            ExerciseId = exercise.Id,
            ExerciseTitle = exercise.Title,
            TotalScore = (short)Math.Round(aiResult.Overall),
            TotalQuestions = 1,
            SubmittedAt = DateTime.UtcNow
        };

        var submission = new Submission
        {
            Id = result.SubmissionId,
            UserId = request.UserId,
            ExerciseId = request.ExerciseId,
            TotalScore = result.TotalScore,
            ResultJson = JsonSerializer.Serialize(aiResult)
        };

        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();

        return result;
    }
}
*/