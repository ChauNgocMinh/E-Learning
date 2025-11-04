namespace E_Learning.Helper.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class RequiredAttribute : Attribute
{
    public string? ErrorMessage { get; }

    public RequiredAttribute(string? errorMessage = null)
    {
        ErrorMessage = errorMessage ?? "Đây là trường bắt buộc";
    }
}
