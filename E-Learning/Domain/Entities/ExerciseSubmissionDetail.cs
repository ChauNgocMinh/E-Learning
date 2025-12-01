using E_Learning.Domain.Comon;
using System;

namespace E_Learning.Domain.Entities
{
    public class ExerciseSubmissionDetail : BaseEntity
    {
        public Guid SubmissionId { get; set; }
        public Guid? ExerciseListeningId { get; set; }
        public ExerciseListening? ExerciseListening { get; set; }
        public Guid? ExerciseReadingId { get; set; }
        public ExercisesReading? ExerciseReading { get; set; }
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
