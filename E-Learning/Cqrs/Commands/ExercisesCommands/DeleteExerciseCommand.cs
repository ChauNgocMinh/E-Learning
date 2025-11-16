using MediatR;
using System;

namespace E_Learning.Cqrs.Commands.ExercisesCommands
{
    // Command dùng để xóa bài tập theo Id
    public class DeleteExerciseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
