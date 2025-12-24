namespace E_Learning.ViewModel
{
    public class SubmissionResultViewModel
    {
        public Guid SubmissionId { get; set; }
        public Guid ExerciseId { get; set; }
        public string ExerciseTitle { get; set; } = string.Empty;

        public short TotalScore { get; set; }
        public int TotalQuestions { get; set; }

        public DateTime SubmittedAt { get; set; }

        public List<SubmissionDetailResultViewModel> Details { get; set; } = new();
    }

    public class SubmissionDetailResultViewModel
    {
        public Guid QuestionId { get; set; }
        public int OrderNumber { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public SubmissionOptionSet Options { get; set; } = new();  // A/B/C/D

        public string UserAnswer { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }

        public string? Explanation { get; set; }
    }

    public class SubmissionOptionSet
    {
        public string A { get; set; } = string.Empty;
        public string B { get; set; } = string.Empty;
        public string C { get; set; } = string.Empty;
        public string D { get; set; } = string.Empty;
    }
}
