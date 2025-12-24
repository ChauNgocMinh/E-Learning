using E_Learning.ViewModel;
using MediatR;
namespace E_Learning.Cqrs.Commands.ExercisesSpeakingCommands;
public record SubmitSpeakingExerciseCommand(
    Guid ExerciseId,
    Guid UserId,
    string AudioFileUrl
) : IRequest<SubmissionResultViewModel>;
