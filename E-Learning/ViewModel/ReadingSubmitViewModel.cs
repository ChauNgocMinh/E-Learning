namespace E_Learning.ViewModel
{
    public class ReadingSubmitViewModel
    {
        public Guid ExerciseId { get; set; }

        // key = QuestionId | value = student’s answer
        public Dictionary<Guid, string> Answers { get; set; } = new();
    }
}
