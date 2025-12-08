using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseWriting : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ExerciseId { get; set; }

        [CustomRequired]
        [CustomMaxLength(2000)]
        public string PromptText { get; set; } = null!; // Task 1 or Task 2 prompt

        [CustomMaxLength(500)]
        public string? SampleImageUrl { get; set; } // diagram, chart, map

        [CustomMaxLength(4000)]
        public string? ModelAnswer { get; set; } // high-band sample 

        public string? RubricJson { get; set; } // scoring structure

        // Navigation
        public Exercise Exercise { get; set; } = null!;
    }
}
