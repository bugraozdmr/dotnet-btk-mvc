using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCWEB.Infrastructe.TagHelpers;

[HtmlTargetElement("td",Attributes = "user-role")]
public class UserRoleTagHelper : TagHelper
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    // ordan aldığı değeri direkt burda set ediyor
    [HtmlAttributeName("user-name")]
    public string? UserName { get; set; }
    
    public UserRoleTagHelper(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // bunu admin/index'te td de kullandık ... oraya git
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var user = await _userManager.FindByNameAsync(UserName);
        
        TagBuilder ul = new TagBuilder("ul");
        var roles = _roleManager.Roles.ToList().Select(r => r.Name);

        foreach (var role in roles)
        {
            TagBuilder li = new TagBuilder("li");
            // 8 karakterlik yapı tanımladı -- var mı yok mu kontrol etti // admin : false etc.
            li.InnerHtml.Append($"{role,-8} : {await _userManager.IsInRoleAsync(user, role)}");

            ul.InnerHtml.AppendHtml(li);
        }

        output.Content.AppendHtml(ul);
    }
}