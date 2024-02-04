using Microsoft.AspNetCore.Mvc;
using Services.Concrats;

namespace MVCWEB.Components;

public class CategoriesMenuViewComponent : ViewComponent
{
    private readonly IServiceManager _manager;

    public CategoriesMenuViewComponent(IServiceManager manager)
    {
        _manager = manager;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _manager.CategoryService.GetAllCategories(false);
        return View(categories);
    }
}