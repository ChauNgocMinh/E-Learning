using E_Learning.Cqrs.Queries.ExercisesReadingQueries;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesReadingQueryHandlers
{
    public class GetAllExercisesReadingHandler(ApplicationDbContext _context) : IRequestHandler<GetAllExercisesReadingQuery, Exercise>
    {
        public async Task<Exercise> Handle(GetAllExercisesReadingQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Exercises
.Include(e => e.ExerciseReadings.OrderBy(r => r.OrderNumber))
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.ExerciseId, cancellationToken);
            return result ?? new Exercise();

        }
    }
}
