namespace E_Learning.ViewModel
{
    public class MySubmissionItemViewModel
    {
        public Guid SubmissionId { get; set; }

        public Guid ExerciseId { get; set; }

        public string ExerciseTitle { get; set; } = string.Empty;

        public short TotalScore { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
