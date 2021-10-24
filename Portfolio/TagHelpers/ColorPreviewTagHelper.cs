using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.TagHelpers
{
    public class ColorPreviewTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(AddContent());
        }

        public string Color { get; set; }
        public int Width { get; set; } = 10;
        public int Height { get; set; } = 10;
        public bool IsPx { get; set; } = true;

        private string AddContent()
        {
            return $"<div style=\"background-color: {Color}; width: {Width}{(IsPx ? "px" : "%")}; height: {Height}{(IsPx ? "px" : "%")}; border-radius: 50%\"></div>";
        }
    }
}