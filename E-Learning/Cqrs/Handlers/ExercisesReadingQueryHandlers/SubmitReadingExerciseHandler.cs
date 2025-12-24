using E_Learning.Cqrs.Commands.ExercisesReadingCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Submissions.Snapshots;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_Learning.Cqrs.Handlers.ExercisesReadingCommandHandlers
{
    public class SubmitReadingExerciseCommandHandler(ApplicationDbContext _context)
        : IRequestHandler<SubmitReadingExerciseCommand, SubmissionResultViewModel>
    {
       

        public async Task<SubmissionResultViewModel> Handle(
            SubmitReadingExerciseCommand request,
            CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercises
                .AsNoTracking()
                .FirstAsync(x => x.Id == request.ExerciseId, cancellationToken);

            var questions = await _context.ExerciseReadings
                .Where(x => x.ExerciseId == request.ExerciseId)
                .OrderBy(x => x.OrderNumber)
                .ToListAsync(cancellationToken);

            var snapshot = new ReadingSubmissionSnapshot();
            int correctCount = 0;

            foreach (var q in questions)
            {
                request.Answers.TryGetValue(q.Id, out var userAnswer);

                bool isCorrect =
                    !string.IsNullOrWhiteSpace(userAnswer) &&
                    userAnswer.Trim()
                        .Equals(q.CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);

                if (isCorrect) correctCount++;

                snapshot.Questions.Add(new ReadingQuestionResult
                {
                    QuestionId = q.Id,
                    OrderNumber = q.OrderNumber,
                    QuestionType = q.QuestionType,
                    QuestionText = q.QuestionText,
                    OptionsJson = q.OptionsJson,
                    UserAnswer = userAnswer ?? "",
                    CorrectAnswer = q.CorrectAnswer,
                    IsCorrect = isCorrect,
                    Explanation = q.Explanation
                });
            }

            short totalScore = (short)Math.Round(
                (double)correctCount / questions.Count * 100
            );

            var submission = new Submission
            {
                UserId = request.UserId,
                ExerciseId = request.ExerciseId,
                TotalScore = totalScore,
                ResultJson = JsonSerializer.Serialize(snapshot),
                SubmittedAt = DateTime.UtcNow
            };

            _context.Submissions.Add(submission);

            var exerciseToUpdate = await _context.Exercises
                .FirstAsync(x => x.Id == request.ExerciseId, cancellationToken);

            exerciseToUpdate.AttemptCount++;

            await _context.SaveChangesAsync(cancellationToken);

            return new SubmissionResultViewModel
            {
                SubmissionId = submission.Id,
                ExerciseId = exercise.Id,
                ExerciseTitle = exercise.Title,
                TotalScore = totalScore,
                TotalQuestions = snapshot.Questions.Count,
                SubmittedAt = submission.SubmittedAt,
                Details = snapshot.Questions.Select(q => new SubmissionDetailResultViewModel
                {
                    QuestionId = q.QuestionId,
                    OrderNumber = q.OrderNumber,
                    QuestionText = q.QuestionText,
                    UserAnswer = q.UserAnswer,
                    CorrectAnswer = q.CorrectAnswer,
                    IsCorrect = q.IsCorrect,
                    Explanation = q.Explanation
                }).ToList()
            };
        }
    }
}
