using E_Learning.Domain.Enums;
using MediatR;
using System;

namespace E_Learning.Cqrs.Commands.ExercisesCommands
{
    // Command dùng để tạo mới một bài tập
    public class CreateExerciseCommand : IRequest<Guid>
    {
        public SkillType Skill { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? AudioUrl { get; set; }
        public int AttemptCount { get; set; } = 0;
    }
}
