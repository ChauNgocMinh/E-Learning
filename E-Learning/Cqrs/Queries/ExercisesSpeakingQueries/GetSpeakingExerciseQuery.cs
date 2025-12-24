using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Queries.ExercisesSpeakingQueries
{
    public record GetSpeakingExerciseQuery(Guid ExerciseId) : IRequest<SpeakingExercisePageViewModel>;

}
