namespace E_Learning.ViewModel
{
    public class SpeakingTopicViewModel
    {

        public Guid ExerciseId { get; set; }
        public string Title { get; set; } = null!;

        public List<SpeakingQuestionViewModel> Questions { get; set; } = new();

        public int QuestionCount => Questions.Count;
     
    }
}
