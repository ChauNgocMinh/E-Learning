using E_Learning.Cqrs.Queries.ExercisesWritingQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesWritingQueryHandlers
{
    public class GetWritingExerciseHandler(ApplicationDbContext _context) :IRequestHandler<GetWritingExerceQuery, WritingExerciseViewModel>
    {
        public async Task<WritingExerciseViewModel> Handle (GetWritingExerceQuery request, CancellationToken cancellationtoken)
        {
            var writing = await _context.ExerciseWritings
              /*  .Where(x=>x.ExerciseId == request.ExerciseId)*/
                .Include(x=>x.Exercise)
                .AsNoTracking()
                .FirstAsync(x=>x.ExerciseId==request.ExerciseId);

           

            return new WritingExerciseViewModel
            {
                ExerciseId = writing.ExerciseId,
                PromptText = writing.PromptText,
                SampleImageUrl = writing.SampleImageUrl,
                Title = writing.Exercise.Title
            };
        }
    }
}
