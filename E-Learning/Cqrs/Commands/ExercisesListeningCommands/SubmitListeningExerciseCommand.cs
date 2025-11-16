using E_Learning.ViewModel;
using MediatR;
namespace E_Learning.Cqrs.Commands.ExercisesListeningCommands;
public record SubmitListeningExerciseCommand(
    ListeningSubmitViewModel Model,
    Guid UserId
) : IRequest<SubmissionResultViewModel>;
