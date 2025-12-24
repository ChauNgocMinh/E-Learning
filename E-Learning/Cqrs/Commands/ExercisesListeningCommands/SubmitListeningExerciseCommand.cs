using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Commands.ExercisesListeningCommands
{
    public record SubmitListeningExerciseCommand(
        Guid ExerciseId,
        Guid UserId,
        Dictionary<Guid, string> Answers
    ) : IRequest<SubmissionResultViewModel>;
}
