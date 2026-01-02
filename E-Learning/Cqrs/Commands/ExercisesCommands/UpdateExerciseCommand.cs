using E_Learning.Domain.Enums;
using MediatR;
using System;

namespace E_Learning.Cqrs.Commands.ExercisesCommands
{
  
    public class UpdateExerciseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public SkillType Skill { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? AudioUrl { get; set; }
    }
}
