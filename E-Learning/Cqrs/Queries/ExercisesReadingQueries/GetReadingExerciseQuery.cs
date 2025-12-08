using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Queries.ExercisesReadingQueries
{
    public record GetReadingExerciseQuery(Guid ExerciseId)
       : IRequest<ReadingExerciseViewModel>;
}
