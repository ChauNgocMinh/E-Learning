using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseSpeaking : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ExerciseId { get; set; }

        [CustomRequired]
        [CustomMaxLength(2000)]
        public string QuestionText { get; set; } = null!;

        [CustomMaxLength(500)]
        public string? AudioUrl { get; set; } // optional audio prompt

        [CustomRange(1, 3)]
        public int Part { get; set; } // 1, 2, 3

        [CustomRange(1, 200)]
        public int OrderNumber { get; set; }

        // Navigation
        public Exercise Exercise { get; set; } = null!;
    }
}
