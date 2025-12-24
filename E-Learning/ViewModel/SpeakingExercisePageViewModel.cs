namespace E_Learning.ViewModel
{

    public class SpeakingExercisePageViewModel
    {

        public int CurrentPart { get; set; } = 1;


        public Guid? CurrentExerciseId { get; set; }


        public Guid? CurrentQuestionId { get; set; }


        public SpeakingQuestionViewModel? CurrentQuestion { get; set; }

 
        public List<SpeakingPartViewModel> Parts { get; set; } = new();


        public string? Note { get; set; }
    }
}
