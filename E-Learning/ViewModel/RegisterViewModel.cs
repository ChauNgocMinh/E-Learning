using System.ComponentModel.DataAnnotations;

namespace E_Learning.ViewModel;
public class RegisterViewModel
{
    [Required]
    public string FullName { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
