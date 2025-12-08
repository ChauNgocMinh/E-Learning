namespace E_Learning.Domain.Entities
{

    public class Submission
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }      // FK → AspNetUsers.Id
        public Guid ExerciseId { get; set; }  // FK → Exercise.Id

        public short TotalScore { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Exercise Exercise { get; set; } = null!;
        public ICollection<SubmissionDetail>? Details { get; set; }
    }
}
