namespace E_Learning.ViewModel
{
    public class SpeakingQuestionViewModel
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; } = null!;
        public string? AudioUrl { get; set; }
        public int Part { get; set; }
        public int OrderNumber { get; set; }
    }
}
