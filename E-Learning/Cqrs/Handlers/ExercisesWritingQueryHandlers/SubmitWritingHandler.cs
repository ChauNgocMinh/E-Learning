using E_Learning.Application.Submissions.Snapshots;
using E_Learning.Cqrs.Commands.ExercisesWritingCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Services;
using E_Learning.Submissions.Snapshots;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_Learning.Cqrs.Handlers.ExercisesWritingQueryHandlers
{
    public class SubmitWritingHandler : IRequestHandler<SubmitWritingCommand, SubmissionResultViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IeltsWritingService _ai;

        public SubmitWritingHandler(ApplicationDbContext context, IeltsWritingService ai)
        {
            _context = context;
            _ai = ai;
        }

        public async Task<SubmissionResultViewModel> Handle(
            SubmitWritingCommand request,
            CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercises
                .Include(x => x.ExerciseWritings)
                .FirstOrDefaultAsync(x => x.Id == request.ExerciseId, cancellationToken);

            if (exercise == null || exercise.ExerciseWritings == null)
                throw new Exception("Exercise not found.");

            var writing = exercise.ExerciseWritings.First();

            var aiResult = await _ai.EvaluateAsync(
                writing.PromptText,
                request.EssayText);

            var snapshot = new WritingSubmissionSnapshot
            {
                Band = aiResult.Band,
                TaskResponse = aiResult.TaskResponse,
                CoherenceCohesion = aiResult.CoherenceCohesion,
                LexicalResource = aiResult.LexicalResource,
                GrammarRangeAccuracy = aiResult.GrammarRangeAccuracy,
                Strengths = aiResult.Strengths,
                Weaknesses = aiResult.Weaknesses,
                Suggestions = aiResult.Suggestions
            };

            short totalScore = (short)Math.Round(aiResult.Band * 10);

            var submission = new Submission
            {
                EssayText = request.EssayText,
                UserId = request.UserId,
                ExerciseId = request.ExerciseId,
                TotalScore = totalScore,
                ResultJson = JsonSerializer.Serialize(snapshot),
                SubmittedAt = DateTime.UtcNow
            };

            _context.Submissions.Add(submission);

            exercise.AttemptCount++;
            _context.Exercises.Update(exercise);

            await _context.SaveChangesAsync(cancellationToken);

            return new SubmissionResultViewModel
            {
                SubmissionId = submission.Id,
                ExerciseId = exercise.Id,
                ExerciseTitle = exercise.Title,
                TotalScore = submission.TotalScore,
                TotalQuestions = 1,
                SubmittedAt = submission.SubmittedAt,
                Details = new()
            };
        }
    }
}
