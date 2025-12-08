namespace E_Learning.ViewModel
{
    public class ListeningSubmitViewModel
    {
        public Guid ExerciseId { get; set; }

        public Dictionary<Guid, string> Answers { get; set; } = new();
    }
}
