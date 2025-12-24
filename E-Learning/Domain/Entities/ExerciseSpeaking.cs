using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseSpeaking : BaseEntity
    {

        public Guid ExerciseId { get; set; }

        [CustomRequired]
        [CustomMaxLength(2000)]
        public string QuestionText { get; set; } = null!;

        [CustomMaxLength(500)]
        public string? AudioUrl { get; set; }  
        [CustomRange(1, 3)]
        public int Part { get; set; }  

        [CustomRange(1, 200)]
        public int OrderNumber { get; set; }

        
        public Exercise Exercise { get; set; } = null!;
    }
}
