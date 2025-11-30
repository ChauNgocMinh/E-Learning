namespace E_Learning.ViewModel;
public class SubmissionResultViewModel
{
    public Guid SubmissionId { get; set; }
    public int TotalScore { get; set; }
    public List<SubmissionDetailViewModel> Details { get; set; } = new();
 

}

public class SubmissionDetailViewModel
{
    public string Question { get; set; } = null!;
    public string OptionA { get; set; } = null!;
    public string OptionB { get; set; } = null!;
    public string OptionC { get; set; } = null!;
    public string OptionD { get; set; } = null!;
    public char SelectedOption { get; set; }
    public char CorrectOption { get; set; }
    public bool IsCorrect { get; set; }
    public int OrderNumber { get; set; }  
}
