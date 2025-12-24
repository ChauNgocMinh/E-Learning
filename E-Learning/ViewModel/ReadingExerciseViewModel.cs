using E_Learning.Domain.Entities;

namespace E_Learning.ViewModel
{
    public class ReadingExerciseViewModel
    
        {
    public Guid ExerciseId { get; set; }
        public string ExerciseTitle { get; set; } = "";
        public string? Passage { get; set; }

        public List<ReadingQuestionViewModel> Questions { get; set; } = new();
    }
    public class ReadingQuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; } = "";
        public string QuestionType { get; set; } = "";
        public string? OptionsJson { get; set; }
    }

}
