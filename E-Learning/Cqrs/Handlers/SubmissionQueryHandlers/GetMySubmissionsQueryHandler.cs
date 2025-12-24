using MediatR;
using Microsoft.EntityFrameworkCore;
using E_Learning.Cqrs.Queries.SubmissionQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;

namespace E_Learning.Cqrs.Handlers.SubmissionQueryHandlers
{
    public class GetMySubmissionsQueryHandler(ApplicationDbContext _context)
        : IRequestHandler<GetMySubmissionsQuery, List<MySubmissionItemViewModel>>
    {
       
        public async Task<List<MySubmissionItemViewModel>> Handle(
            GetMySubmissionsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Submissions
                .Where(x => x.UserId == request.UserId)
                .OrderByDescending(x => x.SubmittedAt)
                .Select(x => new MySubmissionItemViewModel
                {
                    SubmissionId = x.Id,
                    ExerciseId = x.ExerciseId,
                    ExerciseTitle = x.Exercise.Title,
                    TotalScore = x.TotalScore,
                    SubmittedAt = x.SubmittedAt
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
