using E_Learning.Domain.Entities;
using MediatR;

namespace E_Learning.Cqrs.Queries.ExercisesListeningQueries
{
    public record GetAllExercisesListeningQuery(Guid ExerciseId)
        : IRequest<List<ExerciseListening>>;
}
