using E_Learning.Domain.Comon;

namespace E_Learning.Domain.Entities
{

    public class Submission : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ExerciseId { get; set; }
        public string? ResultJson { get; set; }
        public short TotalScore { get; set; }
        public string? EssayText { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public Exercise Exercise { get; set; } = null!;
    }
}
