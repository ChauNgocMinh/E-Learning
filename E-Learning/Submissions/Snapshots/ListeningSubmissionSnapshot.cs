namespace E_Learning.Application.Submissions.Snapshots
{
    internal class ListeningSubmissionSnapshot
    {
        public int Version { get; set; } = 1;

        public List<QuestionResult> Questions { get; set; } = new();
    }

    internal class QuestionResult
    {
        public Guid QuestionId { get; set; }
        public int OrderNumber { get; set; }

        public string QuestionText { get; set; } = "";

        public string OptionA { get; set; } = "";
        public string OptionB { get; set; } = "";
        public string OptionC { get; set; } = "";
        public string OptionD { get; set; } = "";

        public string UserAnswer { get; set; } = "";
        public string CorrectAnswer { get; set; } = "";

        public bool IsCorrect { get; set; }

        public string? Explanation { get; set; }
    }
}
