using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MVCWEB.Pages;

public class Demo : PageModel
{
    // readonly ifade oldu
    public string? FullName => HttpContext?.Session?.GetString("name") ?? "*_-";

    
    
    public void OnGet()
    {
        
    }

    public void OnPost([FromForm]string name)
    {
        //FullName = name;
        
        HttpContext.Session.SetString("name",name);
    }
}