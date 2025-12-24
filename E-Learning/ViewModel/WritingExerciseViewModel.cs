namespace E_Learning.ViewModel
{
    public class WritingExerciseViewModel
    {
        
            public Guid ExerciseId { get; set; }   
            public string PromptText { get; set; } = null!;  
            public string? SampleImageUrl { get; set; }       
            public string? Title { get; set; }                
        

    }
}
