namespace E_Learning.ViewModel
{
    public class ExerciseListeningAnswerViewModel
    {
        public Guid ExerciseId { get; set; }  
        public char SelectedOption { get; set; } 
        public string? Explanation { get; set; }  
    }

    public class ExerciseSubmissionViewModel
    {
        public List<ExerciseListeningAnswerViewModel> Answers { get; set; } = new List<ExerciseListeningAnswerViewModel>();
    }

}
