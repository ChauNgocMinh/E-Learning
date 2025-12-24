namespace E_Learning.Submissions.Snapshots
{
    public class ReadingSubmissionSnapshot
    {
        public int Version { get; set; } = 1;

        public List<ReadingQuestionResult> Questions { get; set; } = new();
    }

    public class ReadingQuestionResult
    {
        public Guid QuestionId { get; set; }
        public int OrderNumber { get; set; }

        public string QuestionType { get; set; } = "";
        public string QuestionText { get; set; } = "";

        public string? OptionsJson { get; set; }

        public string UserAnswer { get; set; } = "";
        public string CorrectAnswer { get; set; } = "";

        public bool IsCorrect { get; set; }
        public string? Explanation { get; set; }
    }
}
