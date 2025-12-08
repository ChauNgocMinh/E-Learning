using E_Learning.ViewModel;
using MediatR;
namespace E_Learning.Cqrs.Commands.ExercisesReadingCommands;
public record SubmitReadingExerciseCommand(
    ReadingSubmitViewModel Model,
    Guid UserId
) : IRequest<SubmissionResultViewModel>;

