using E_Learning.Cqrs.Queries.ExercisesReadingQueries;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesReadingQueryHandlers
{
    public class GetReadingExerciseHandler(ApplicationDbContext _context)
    : IRequestHandler<GetReadingExerciseQuery, ReadingExerciseViewModel>
    {
        public async Task<ReadingExerciseViewModel> Handle(GetReadingExerciseQuery request, CancellationToken cancellationToken)
        {
            var questions = await _context.ExerciseReadings
                .Where(x => x.ExerciseId == request.ExerciseId)
                .Include(x => x.Exercise)
                .OrderBy(x => x.OrderNumber)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (!questions.Any())
                return new ReadingExerciseViewModel
                {
                    ExerciseId = request.ExerciseId,
                    ExerciseTitle = "Không có câu hỏi",
                    Passage = "",
                    Questions = new List<ExerciseReading>()
                };


            var exercise = questions[0].Exercise;

            return new ReadingExerciseViewModel
            {
                ExerciseId = exercise.Id,
                ExerciseTitle = exercise.Title,
                Passage = exercise.Passage,
                Questions = questions
            };
        }
    }

}
