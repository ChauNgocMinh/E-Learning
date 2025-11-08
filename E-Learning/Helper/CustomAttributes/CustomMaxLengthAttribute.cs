using System.ComponentModel.DataAnnotations;

namespace E_Learning.Helper.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class CustomMaxLengthAttribute : MaxLengthAttribute
{
    public CustomMaxLengthAttribute(int length) : base(length)
    {
        ErrorMessage = $"Độ dài tối đa là {length} ký tự.";
    }
}
