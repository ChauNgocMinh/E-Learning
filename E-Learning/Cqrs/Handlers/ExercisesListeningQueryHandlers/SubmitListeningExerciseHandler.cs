using AutoMapper;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListeningQueryHandlers
{
    public class SubmitListeningExerciseHandler(IMapper _mapper, ApplicationDbContext _context)
        : IRequestHandler<SubmitListeningExerciseCommand, SubmissionResultViewModel>
    {
        public async Task<SubmissionResultViewModel> Handle(SubmitListeningExerciseCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            var questions = await _context.ExerciseListenings
                .Where(q => q.ExerciseId == model.ExerciseId)
                .OrderBy(q => q.OrderNumber)
                .ToListAsync(cancellationToken);

            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                ExerciseId = model.ExerciseId,
                UserId = request.UserId,
                SubmittedAt = DateTime.UtcNow,
                Details = new List<SubmissionDetail>()
            };

            foreach (var question in questions)
            {
                model.Answers.TryGetValue(question.Id, out var userAnswer);

                var selected = (userAnswer ?? "").Trim().ToUpper();
                bool isCorrect = selected == question.CorrectOption.ToString();

                submission.Details.Add(new SubmissionDetail
                {
                    Id = Guid.NewGuid(),
                    SubmissionId = submission.Id,
                    QuestionId = question.Id,
                    QuestionType = 0,
                    UserInput = selected,
                    Score = isCorrect ? 1 : 0,
                    IsCorrect = isCorrect
                });
            }

            submission.TotalScore = (short)submission.Details.Sum(x => x.Score);

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync(cancellationToken);

            // Load lại submission + details
            var saved = await _context.Submissions
                .Include(s => s.Details)
                .FirstAsync(s => s.Id == submission.Id, cancellationToken);

            var exercise = await _context.Exercises.FirstAsync(e => e.Id == saved.ExerciseId, cancellationToken);

            var result = _mapper.Map<SubmissionResultViewModel>(saved);
            result.ExerciseTitle = exercise.Title;
            result.TotalQuestions = questions.Count;

            // Map tuple detail + question vào ViewModel
            result.Details = saved.Details
                .Join(questions, d => d.QuestionId, q => q.Id,
                    (d, q) => _mapper.Map<SubmissionDetailResultViewModel>((d, q)))
                .OrderBy(x => x.OrderNumber)
                .ToList();

            return result;
        }
    }
}
