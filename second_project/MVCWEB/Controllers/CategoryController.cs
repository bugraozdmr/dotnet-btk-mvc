
using Microsoft.AspNetCore.Mvc;
using Services.Concrats;

namespace MVCWEB.Controllers;

public class CategoryController : Controller
{
    private readonly IServiceManager _manager;

    public CategoryController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var categories = _manager.CategoryService.GetAllCategories(false);

        return View(categories);
    }
}