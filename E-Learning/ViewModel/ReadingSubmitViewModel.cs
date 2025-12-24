namespace E_Learning.ViewModel
{
    public class ReadingSubmitViewModel
    {
        public Guid ExerciseId { get; set; }

    
        public Dictionary<Guid, string> Answers { get; set; } = new();
    }
}
