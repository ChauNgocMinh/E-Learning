
    namespace E_Learning.ViewModel
    {
        public class ListeningExerciseViewModel
        {
            public Guid ExerciseId { get; set; }
            public string ExerciseTitle { get; set; } = "";
            public string? AudioUrl { get; set; }

        public List<ListeningQuestionViewModel> Questions { get; set; } = new();
    }
    public class ListeningQuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; } = "";
        public string OptionA { get; set; } = "";
        public string OptionB { get; set; } = "";
        public string OptionC { get; set; } = "";
        public string OptionD { get; set; } = "";
    }

}
