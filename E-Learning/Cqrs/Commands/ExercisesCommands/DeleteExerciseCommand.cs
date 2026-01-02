using MediatR;
using System;

namespace E_Learning.Cqrs.Commands.ExercisesCommands
{
 
    public class DeleteExerciseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
