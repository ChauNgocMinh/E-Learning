using System.ComponentModel.DataAnnotations;

namespace E_Learning.Helper.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class CustomRangeAttribute : RangeAttribute
{
    public CustomRangeAttribute(int minimum, int maximum)
        : base(minimum, maximum)
    {
        ErrorMessage = $"Giá trị phải nằm trong khoảng {minimum} đến {maximum}.";
    }

    public CustomRangeAttribute(double minimum, double maximum)
        : base(minimum, maximum)
    {
        ErrorMessage = $"Giá trị phải nằm trong khoảng {minimum} đến {maximum}.";
    }
}
