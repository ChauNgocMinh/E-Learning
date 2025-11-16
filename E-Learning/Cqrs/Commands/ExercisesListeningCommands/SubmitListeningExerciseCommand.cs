using E_Learning.Domain.Entities;
using MediatR;

namespace E_Learning.Cqrs.Commands.ExercisesLearningCommands
{
    public record SubmitListeningExerciseCommand(
    Guid ExerciseId,
    Guid UserId,
    Dictionary<Guid, string> Answers) : IRequest<ExerciseSubmission>;
}
