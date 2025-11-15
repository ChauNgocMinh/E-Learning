using System.ComponentModel.DataAnnotations;

namespace E_Learning.Helper.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class CustomRequiredAttribute : RequiredAttribute
{
    public CustomRequiredAttribute()
    {
        ErrorMessage = "Trường này là bắt buộc.";
    }
}