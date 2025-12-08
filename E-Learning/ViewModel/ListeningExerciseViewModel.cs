using E_Learning.Domain.Entities;

namespace E_Learning.ViewModel
{
    public class ListeningExerciseViewModel
    {
        public Guid ExerciseId { get; set; }
        public string ExerciseTitle { get; set; } = "";
        public string? AudioUrl { get; set; }

        public List<ExerciseListening> Questions { get; set; } = new();
    }
}
