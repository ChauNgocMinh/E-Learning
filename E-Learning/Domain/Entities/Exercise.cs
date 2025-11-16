using E_Learning.Domain.Comon;
using E_Learning.Domain.Enums;
using E_Learning.Helper.CustomAttributes;

namespace E_Learning.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public Guid Id { get; set; }

        [CustomRequired]
        public SkillType Skill { get; set; }

        [CustomRequired]
        [CustomMaxLength(200)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }
        /// <summary>
        /// for listening exercises, the URL of the audio file
        /// </summary>
        public string? AudioUrl { get; set; }
        /// <summary>
        /// for reading exercises, the passage text
        /// </summary>
        public string? Passage  {get; set; }

        public string? ImageUrl { get; set; }

        [CustomRange(0, 9999)]
        public int AttemptCount { get; set; } = 0;

        public ICollection<ExerciseListening>? ExerciseListenings { get; set; }
        public ICollection<ExercisesReading>? ExerciseReadings { get; set; }
    }
}
