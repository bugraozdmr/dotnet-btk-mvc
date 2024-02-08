using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Concrats;

namespace MVCWEB.Infrastructe.TagHelpers;

// bir çok yerde kullanacağın bir kod bloğu varsa onu çevir

[HtmlTargetElement("div",Attributes = "products")]
public class LatestProductTagHelper : TagHelper
{
    private readonly IServiceManager _manager;
    
    // number artık bir attribute oldu
    [HtmlAttributeName("number")]
    public int? Number { get; set; }
    
    public LatestProductTagHelper(IServiceManager manager)
    {
        _manager = manager;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder div = new TagBuilder("div");
        div.Attributes.Add("class","mt3");
        
        TagBuilder h6 = new TagBuilder("h6");
        h6.Attributes.Add("class","lead");

        TagBuilder icon = new TagBuilder("i");
        icon.Attributes.Add("class","fa fa-box text-secondary");

        // içini doldurma
        h6.InnerHtml.AppendHtml(icon);
        h6.InnerHtml.AppendHtml(" Latest Products");

        TagBuilder ul = new TagBuilder("ul");
        ul.Attributes.Add("style","list-style-type: none;");
        // null gelebileceğini düşünerek metodlar düzenlendi
        var products = _manager.ProductService.getLatestProducts(Number, false);

        foreach (var item in products)
        {
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");
            
            a.Attributes.Add("href",$"/product/get/{item.Id}");
            a.InnerHtml.AppendHtml(item.ProductName);
            
            li.InnerHtml.AppendHtml(a);

            ul.InnerHtml.AppendHtml(li);
        }
        
        
        div.InnerHtml.AppendHtml(h6);
        div.InnerHtml.AppendHtml(ul);
        
        
        output.Content.AppendHtml(div);
    }
}