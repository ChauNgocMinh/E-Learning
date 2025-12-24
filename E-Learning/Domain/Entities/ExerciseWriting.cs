using E_Learning.Domain.Comon;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class ExerciseWriting : BaseEntity
    {
      
        public Guid ExerciseId { get; set; }

        [CustomRequired]
        [CustomMaxLength(2000)]
        public string PromptText { get; set; } = null!; 

        [CustomMaxLength(500)]
        public string? SampleImageUrl { get; set; }  

        [CustomMaxLength(4000)]
        public string? ModelAnswer { get; set; }  

        public string? RubricJson { get; set; }  

      
        public Exercise Exercise { get; set; } = null!;
    }
}
