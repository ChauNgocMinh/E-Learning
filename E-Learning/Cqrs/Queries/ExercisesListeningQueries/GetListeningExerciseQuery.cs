using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Queries.ExercisesListeningQueries
{
    public record GetListeningExerciseQuery(Guid ExerciseId)
            : IRequest<ListeningExerciseViewModel>;

}
