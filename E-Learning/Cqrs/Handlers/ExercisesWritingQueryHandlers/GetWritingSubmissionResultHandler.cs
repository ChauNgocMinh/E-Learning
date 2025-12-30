using E_Learning.Cqrs.Queries.ExercisesWritingQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Submissions.Snapshots;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_Learning.Cqrs.Handlers.ExercisesWritingQueryHandlers
{
    public class GetWritingSubmissionResultHandler
     : IRequestHandler<GetWritingSubmissionResultQuery, WritingResultViewModel>
    {
        private readonly ApplicationDbContext _context;

        public GetWritingSubmissionResultHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WritingResultViewModel> Handle(
            GetWritingSubmissionResultQuery request,
            CancellationToken cancellationToken)
        {
            var submission = await _context.Submissions
                .Include(x => x.Exercise)
                .FirstOrDefaultAsync(x => x.Id == request.SubmissionId, cancellationToken);
            if (submission == null)
                return null!;

            var snapshot = JsonSerializer.Deserialize<WritingSubmissionSnapshot>(
                submission.ResultJson!
            ) ?? throw new Exception("Invalid writing snapshot.");

            return new WritingResultViewModel
            {
                SubmissionId = submission.Id,
                ExerciseId = submission.ExerciseId,
                ExerciseTitle = submission.Exercise.Title,
                TotalScore = submission.TotalScore,
                SubmittedAt = submission.SubmittedAt,
                EssayText = submission.EssayText ?? "",
                Band = snapshot.Band,
                TaskResponse = snapshot.TaskResponse,
                CoherenceCohesion = snapshot.CoherenceCohesion,
                LexicalResource = snapshot.LexicalResource,
                GrammarRangeAccuracy = snapshot.GrammarRangeAccuracy,
                Strengths = snapshot.Strengths,
                Weaknesses = snapshot.Weaknesses,
                Suggestions = snapshot.Suggestions
            };
        }
    }

}
