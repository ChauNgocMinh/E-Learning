using System.Text.Json;
using E_Learning.Application.Submissions.Snapshots;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListeningCommandHandlers
{
    public class SubmitListeningExerciseCommandHandler(ApplicationDbContext _context)
        : IRequestHandler<SubmitListeningExerciseCommand, SubmissionResultViewModel>
    {
     

        public async Task<SubmissionResultViewModel> Handle(
            SubmitListeningExerciseCommand request,
            CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercises
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.ExerciseId, cancellationToken);

            if (exercise == null)
                throw new Exception("Exercise not found.");

            var questions = await _context.ExerciseListenings
                .Where(x => x.ExerciseId == request.ExerciseId)
                .OrderBy(x => x.OrderNumber)
                .ToListAsync(cancellationToken);

            if (!questions.Any())
                throw new Exception("Listening exercise has no questions.");

            var snapshot = new ListeningSubmissionSnapshot();
            int correctCount = 0;

            foreach (var q in questions)
            {
                request.Answers.TryGetValue(q.Id, out var userAnswer);

                string correctAnswer = q.CorrectOption.ToString();
                bool isCorrect =
                    !string.IsNullOrWhiteSpace(userAnswer) &&
                    userAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);

                if (isCorrect) correctCount++;

                snapshot.Questions.Add(new QuestionResult
                {
                    QuestionId = q.Id,
                    OrderNumber = q.OrderNumber,
                    QuestionText = q.QuestionText,

                    OptionA = q.OptionA,
                    OptionB = q.OptionB,
                    OptionC = q.OptionC,
                    OptionD = q.OptionD,

                    UserAnswer = userAnswer ?? "",
                    CorrectAnswer = correctAnswer,
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
                TotalScore = submission.TotalScore,
                TotalQuestions = snapshot.Questions.Count,
                SubmittedAt = submission.SubmittedAt,

                Details = snapshot.Questions.Select(q => new SubmissionDetailResultViewModel
                {
                    QuestionId = q.QuestionId,
                    OrderNumber = q.OrderNumber,
                    QuestionText = q.QuestionText,
                    Options = new SubmissionOptionSet
                    {
                        A = q.OptionA,
                        B = q.OptionB,
                        C = q.OptionC,
                        D = q.OptionD
                    },
                    UserAnswer = q.UserAnswer,
                    CorrectAnswer = q.CorrectAnswer,
                    IsCorrect = q.IsCorrect,
                    Explanation = q.Explanation
                }).ToList()
            };
        }
    }
}
