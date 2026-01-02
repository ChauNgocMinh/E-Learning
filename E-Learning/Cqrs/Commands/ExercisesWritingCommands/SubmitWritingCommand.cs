using MediatR;
using E_Learning.ViewModel;

namespace E_Learning.Cqrs.Commands.ExercisesWritingCommands
{
    public class SubmitWritingCommand : IRequest<SubmissionResultViewModel>
    {
        public Guid ExerciseId { get; set; }
        public Guid UserId { get; set; }

        
        public string EssayText { get; set; } = string.Empty;
    }
}
