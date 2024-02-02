using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace Mvc.Controllers;

public class CourseController : Controller
{
    // GET
    public IActionResult Index()
    {
        var model = Repository.Applications;
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Apply()
    {
        return View();
    }
    
    // hangi tarayıcıyla işlem kurduğunu -- daha güvenli olsun diye
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Apply([FromForm]Candidate model)
    {
        if (Repository.Applications.Any(c => c.email.Equals(model.email)))
        {
            ModelState.AddModelError("","This email already has a course.");
        }
        if (!ModelState.IsValid)
        {
            return View("Apply", model);
        }
        Repository.Add(model);
        return View("FeedBack",model);
    }
}