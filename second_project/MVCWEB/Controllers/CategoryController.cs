using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace MVCWEB.Controllers;

public class CategoryController : Controller
{
    private readonly IRepositoryManager _manager;

    public CategoryController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var categories = _manager.Category.FindAll(false);

        return View(categories);
    }
    
    
}