using Microsoft.AspNetCore.Mvc;

namespace MVCWEB.Controllers;

[Route("Error/{statusCode}")]
public class ErrorController : Controller
{
    // launch settingden "environmentVariables": {
    //   "ASPNETCORE_ENVIRONMENT": "Production"
    // }
    // değişmeli - production
    public IActionResult Index(int statusCode)
    {
        int code;
        
        switch (statusCode)
        {
            case 404:
                // böyle kullanılıyormuş viewdata
                //ViewData["Error"] = "Page Not Found";
                code = 404;
                break;
            default:
                code = 500;
                //ViewData["Error"] = "Something Went Wrong";
                break;
        }

        return View("Index",code);
    }
}