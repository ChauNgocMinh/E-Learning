using E_Learning.Cqrs.Queries.ExercisesReadingQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesReadingQueryHandlers
{
    public class GetReadingExerciseHandler(ApplicationDbContext _context)
        : IRequestHandler<GetReadingExerciseQuery, ReadingExerciseViewModel>
    {
         

        public async Task<ReadingExerciseViewModel> Handle(
            GetReadingExerciseQuery request,
            CancellationToken cancellationToken)
        {
            var questions = await _context.ExerciseReadings
                .Where(x => x.ExerciseId == request.ExerciseId)
                .OrderBy(x => x.OrderNumber)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (!questions.Any())
                throw new Exception("Reading exercise has no questions.");

            var exercise = await _context.Exercises
                .AsNoTracking()
                .FirstAsync(x => x.Id == request.ExerciseId, cancellationToken);

            return new ReadingExerciseViewModel
            {
                ExerciseId = exercise.Id,
                ExerciseTitle = exercise.Title,
                Passage = exercise.Passage,
                Questions = questions.Select(q => new ReadingQuestionViewModel
                {
                    QuestionId = q.Id,
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType,
                    OptionsJson = q.OptionsJson
                }).ToList()
            };
        }
    }
}
