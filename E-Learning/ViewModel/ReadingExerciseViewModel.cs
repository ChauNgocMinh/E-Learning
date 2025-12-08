using E_Learning.Domain.Entities;

namespace E_Learning.ViewModel
{
    public class ReadingExerciseViewModel
    
        {
    public Guid ExerciseId { get; set; }
        public string ExerciseTitle { get; set; } = "";
        public string? Passage { get; set; }

        public List<ExerciseReading> Questions { get; set; } = new();
    }
}
