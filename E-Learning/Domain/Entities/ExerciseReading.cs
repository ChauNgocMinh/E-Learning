using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseReading : BaseEntity
    {
        public Guid ExerciseId { get; set; }

        [CustomRequired]
        [CustomMaxLength(50)]
        public string QuestionType { get; set; } = null!;
         

        [CustomRequired]
        public string QuestionText { get; set; } = null!;

        public string? OptionsJson { get; set; }
        

        [CustomRequired]
        public string CorrectAnswer { get; set; } = null!;

        [CustomMaxLength(1000)]
        public string? Explanation { get; set; }

        [CustomRange(1, 200)]
        public int OrderNumber { get; set; }

 
        public Exercise Exercise { get; set; } = null!;
    }
}
