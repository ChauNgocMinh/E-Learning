namespace E_Learning.Domain.Entities
{
    public class SubmissionDetail
    {
        public Guid Id { get; set; }

        public Guid SubmissionId { get; set; }

        public Guid QuestionId { get; set; }  // Listening/Reading/Writing/Speaking question Id

        public int QuestionType { get; set; } // 0 = Listening, 1 = Reading, 2 = Writing, 3 = Speaking

        public string? UserInput { get; set; }

        public int Score { get; set; }

        public bool IsCorrect { get; set; }

        // Navigation
        public Submission Submission { get; set; } = null!;
    }
}
