using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseListening : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ExerciseId { get; set; }

        [CustomRequired]
        public string QuestionText { get; set; } = null!;

        [CustomRequired]
        [CustomMaxLength(200)]
        public string OptionA { get; set; } = null!;

        [CustomRequired]
        [CustomMaxLength(200)]
        public string OptionB { get; set; } = null!;

        [CustomRequired]
        [CustomMaxLength(200)]
        public string OptionC { get; set; } = null!;

        [CustomRequired]
        [CustomMaxLength(200)]
        public string OptionD { get; set; } = null!;

        [CustomRange('A', 'D')]
        public char CorrectOption { get; set; } 

        [CustomMaxLength(1000)]
        public string? Explanation { get; set; }

        [CustomRange(1, 200)]
        public int OrderNumber { get; set; }

        public Exercise Exercise { get; set; } = null!;
    }
}
