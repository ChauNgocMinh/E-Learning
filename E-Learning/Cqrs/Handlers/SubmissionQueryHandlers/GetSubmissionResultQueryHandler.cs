using System.Text.Json;
using E_Learning.Application.Submissions.Snapshots;
using E_Learning.Cqrs.Queries.SubmissionQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.SubmissionQueryHandlers
{
    public class GetSubmissionResultQueryHandler(ApplicationDbContext _context)
        : IRequestHandler<GetSubmissionResultQuery, SubmissionResultViewModel>
    {
       

        public async Task<SubmissionResultViewModel> Handle(
            GetSubmissionResultQuery request,
            CancellationToken cancellationToken)
        {
            var submission = await _context.Submissions
                .AsNoTracking()
                .Include(s => s.Exercise)
                .FirstOrDefaultAsync(s => s.Id == request.SubmissionId, cancellationToken);

            if (submission == null)
                throw new Exception("Submission not found.");

            var snapshot = JsonSerializer.Deserialize<ListeningSubmissionSnapshot>(
                submission.ResultJson!
            );

            if (snapshot == null)
                throw new Exception("Invalid submission snapshot.");

            return new SubmissionResultViewModel
            {
                SubmissionId = submission.Id,
                ExerciseId = submission.ExerciseId,
                ExerciseTitle = submission.Exercise.Title,
                TotalScore = submission.TotalScore,
                TotalQuestions = snapshot.Questions.Count,
                SubmittedAt = submission.SubmittedAt,

                Details = snapshot.Questions
                    .OrderBy(q => q.OrderNumber)
                    .Select(q => new SubmissionDetailResultViewModel
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
                    })
                    .ToList()
            };
        }
    }
}
