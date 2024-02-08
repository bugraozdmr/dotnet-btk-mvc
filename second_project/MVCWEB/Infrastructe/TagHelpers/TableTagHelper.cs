using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCWEB.Infrastructe.TagHelpers;

[HtmlTargetElement("table")]
public class TableTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // bundan sonra eklenen table'lar özellikle gelirler
        output.Attributes.SetAttribute("class","table table-hover");
    }
}