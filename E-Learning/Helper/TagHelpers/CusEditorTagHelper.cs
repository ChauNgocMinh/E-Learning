using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace E_Learning.Helper.TagHelpers
{
    [HtmlTargetElement("cus-editor", Attributes = ForAttributeName)]
    public class CusEditorTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea"; 
            output.TagMode = TagMode.StartTagAndEndTag;

            var fullName = For.Name;
            output.Attributes.SetAttribute("name", fullName);
            output.Attributes.SetAttribute("id", fullName);

            output.Attributes.SetAttribute("class", "ckeditor");

            var modelValue = For.Model?.ToString() ?? "";
            output.Content.SetHtmlContent(modelValue);
        }
    }
}
