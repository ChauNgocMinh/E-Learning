using AutoMapper;
using E_Learning.Cqrs.Commands.ExercisesReadingCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesReadingHandlers
{
    public class SubmitReadingExerciseHandler(ApplicationDbContext _context, IMapper _mapper)
        : IRequestHandler<SubmitReadingExerciseCommand, SubmissionResultViewModel>
    {

        public async Task<SubmissionResultViewModel> Handle(SubmitReadingExerciseCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            // --- 1. Load questions ---
            var questions = await _context.ExerciseReadings
                .Where(q => q.ExerciseId == model.ExerciseId)
                .OrderBy(q => q.OrderNumber)
                .ToListAsync(cancellationToken);

            if (!questions.Any())
                throw new InvalidOperationException("No reading questions found.");

            // --- 2. Create submission ---
            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                ExerciseId = model.ExerciseId,
                UserId = request.UserId,
                SubmittedAt = DateTime.UtcNow,
                Details = new List<SubmissionDetail>()
            };

            // --- 3. Process each question ---
            foreach (var question in questions)
            {
                model.Answers.TryGetValue(question.Id, out var userAnswer);

                string answer = (userAnswer ?? "").Trim();

                bool isCorrect = string.Equals(answer, question.CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);

                submission.Details.Add(new SubmissionDetail
                {
                    Id = Guid.NewGuid(),
                    SubmissionId = submission.Id,
                    QuestionId = question.Id,
                    QuestionType = 1, // Reading
                    UserInput = answer,
                    Score = isCorrect ? 1 : 0,
                    IsCorrect = isCorrect
                });
            }

            submission.TotalScore = (short)submission.Details.Sum(x => x.Score);

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync(cancellationToken);

            // --- 4. Load saved submission + details ---
            var saved = await _context.Submissions
                .Include(s => s.Details)
                .FirstAsync(s => s.Id == submission.Id, cancellationToken);

            var exercise = await _context.Exercises
                .FirstAsync(e => e.Id == model.ExerciseId, cancellationToken);

            // --- 5. Map base submission data ---
            var vm = _mapper.Map<SubmissionResultViewModel>(saved);
            vm.ExerciseTitle = exercise.Title;
            vm.TotalQuestions = questions.Count;

            // --- 6. Map details (detail + question) ---
            vm.Details = saved.Details
                .Join(questions,
                    d => d.QuestionId,
                    q => q.Id,
                    (d, q) => _mapper.Map<SubmissionDetailResultViewModel>((d, q)))
                .OrderBy(x => x.OrderNumber)
                .ToList();

            return vm;
        }
    }
}
