using System;
using System.Collections.Generic;

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

        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;

        public string UserInput { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
        public int Score { get; set; }

        public string? Explanation { get; set; }
    }
}
