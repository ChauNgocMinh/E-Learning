using E_Learning.Domain.Comon;
using System;
using System.Collections.Generic;

namespace E_Learning.Domain.Entities
{
    public class ExerciseSubmission : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid UserId { get; set; }
        public short TotalScore { get; set; }

        public ICollection<ExerciseSubmissionDetail> Details { get; set; } = new List<ExerciseSubmissionDetail>();

    }
}
