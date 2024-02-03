using Microsoft.AspNetCore.Mvc;

namespace MVCWEB.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}