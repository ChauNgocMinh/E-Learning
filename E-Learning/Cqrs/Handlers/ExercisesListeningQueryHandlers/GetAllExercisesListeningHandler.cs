using E_Learning.Cqrs.Queries.ExercisesListeningQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListeningQueryHandlers
{
    public class GetListeningExerciseHandler(ApplicationDbContext _context)
        : IRequestHandler<GetListeningExerciseQuery, ListeningExerciseViewModel>
    {
     
        public async Task<ListeningExerciseViewModel> Handle(GetListeningExerciseQuery request, CancellationToken cancellationToken)
        {
            var questions = await _context.ExerciseListenings
                .Where(x => x.ExerciseId == request.ExerciseId)
                .Include(x => x.Exercise)
                .OrderBy(x => x.OrderNumber)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            
            var exercise = questions[0].Exercise;

            return new ListeningExerciseViewModel
            {
                ExerciseId = request.ExerciseId,
                ExerciseTitle = exercise.Title,
                AudioUrl = exercise.AudioUrl,
                Questions = questions
            };
        }
    }
}
