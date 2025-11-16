using E_Learning.Cqrs.Queries.ExercisesListeningQueries;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListeningQueryHandlers
{
    public class GetAllExercisesListeningHandler(ApplicationDbContext _context) : IRequestHandler<GetAllExercisesListeningQuery, Exercise>
    {
        public async Task<Exercise> Handle(GetAllExercisesListeningQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Exercises
                .Include(e => e.ExerciseListenings)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.ExerciseId, cancellationToken);
            return result ?? new Exercise();
        }
    }
}

