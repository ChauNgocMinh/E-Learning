using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseReading : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ExerciseId { get; set; }

        [CustomRequired]
        [CustomMaxLength(50)]
        public string QuestionType { get; set; } = null!;
        // ví dụ: "MCQ", "TFNG", "Matching", "ShortAnswer"

        [CustomRequired]
        public string QuestionText { get; set; } = null!;

        public string? OptionsJson { get; set; }
        // dạng JSON cho MCQ, Matching: ["A","B","C","D"]

        [CustomRequired]
        public string CorrectAnswer { get; set; } = null!;

        [CustomMaxLength(1000)]
        public string? Explanation { get; set; }

        [CustomRange(1, 200)]
        public int OrderNumber { get; set; }

        // Navigation
        public Exercise Exercise { get; set; } = null!;
    }
}
