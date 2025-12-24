using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Commands.ExercisesWritingCommands
{
    public record SubmitWritingExerciseCommand(
       Guid ExerciseId,
       Guid UserId,
       string EssayText
   ) : IRequest<SubmissionResultViewModel>;
}
