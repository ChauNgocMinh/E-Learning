using E_Learning.Domain.Comon;
using System;

namespace E_Learning.Domain.Entities;
public class ExerciseSubmissionDetail : BaseEntity
{
    public Guid Id { get; set; }
    public Guid SubmissionId { get; set; }

    // LISTENING
    public Guid? ExerciseListeningId { get; set; }
    public ExerciseListening? ExerciseListening { get; set; }

    // READING
    public Guid? ExerciseReadingId { get; set; }
    public ExercisesReading? ExerciseReading { get; set; }

    public char SelectedOption { get; set; }
    public bool IsCorrect { get; set; }
}
