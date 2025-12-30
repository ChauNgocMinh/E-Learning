using System.Text.Json;
using AutoMapper;
using E_Learning.Application.Submissions.Snapshots;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Domain.Entities;
using E_Learning.Domain.Enums;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListeningCommandHandlers
{
    public class SubmitListeningExerciseCommandHandler(ApplicationDbContext _context, IMapper _mapper)
        : IRequestHandler<SubmitListeningExerciseCommand, SubmissionResultViewModel>
    {
        public async Task<SubmissionResultViewModel> Handle(
            SubmitListeningExerciseCommand request,
            CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercises
                .Include(x => x.ExerciseListenings)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.ExerciseId) && x.Skill.Equals(SkillType.Listening), cancellationToken);

            if (exercise == null || exercise.ExerciseListenings is null)
                throw new Exception("Exercise not found.");

            var snapshot = new ListeningSubmissionSnapshot();
            int correctCount = 0;

            foreach (var q in exercise.ExerciseListenings)
            {
                request.Answers.TryGetValue(q.Id, out var userAnswer);

                string correctAnswer = q.CorrectOption.ToString();
                bool isCorrect =
                    !string.IsNullOrWhiteSpace(userAnswer) &&
                    userAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);

                if (isCorrect) correctCount++;

                var result = _mapper.Map<QuestionResult>(q);

                result.UserAnswer = userAnswer ?? "";
                result.CorrectAnswer = correctAnswer;
                result.IsCorrect = isCorrect;

                snapshot.Questions.Add(result);


            }

            short totalScore = (short)Math.Round(
                (double)correctCount / exercise.ExerciseListenings.Count * 100
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

            exercise.AttemptCount++;
            _context.Exercises.Update(exercise);
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
