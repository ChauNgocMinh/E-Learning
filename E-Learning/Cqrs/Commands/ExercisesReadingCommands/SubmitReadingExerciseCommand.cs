using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Commands.ExercisesReadingCommands
{
    public record SubmitReadingExerciseCommand(
        Guid ExerciseId,
        Guid UserId,
        Dictionary<Guid, string> Answers
    ) : IRequest<SubmissionResultViewModel>;
}
