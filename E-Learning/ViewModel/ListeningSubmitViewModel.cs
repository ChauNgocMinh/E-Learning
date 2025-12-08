namespace E_Learning.ViewModel
{
    public class ListeningSubmitViewModel
    {
        public Guid ExerciseId { get; set; }

        // key = QuestionId, value = UserInput ("A","B","C","D")
        public Dictionary<Guid, string> Answers { get; set; } = new();
    }
}
