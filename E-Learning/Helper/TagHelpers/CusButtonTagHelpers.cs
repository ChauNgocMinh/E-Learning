using Microsoft.AspNetCore.Razor.TagHelpers;

namespace E_Learning.Helper.TagHelpers
{
    [HtmlTargetElement("cus-button")]
    public class MyButtonTagHelper : TagHelper
    {
        public string Text { get; set; }
        public string Class { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("class", Class);
            output.Attributes.SetAttribute("type", "button");
            output.Content.SetContent(Text);
        }
    }
}