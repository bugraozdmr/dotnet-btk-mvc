using Microsoft.AspNetCore.Mvc;

namespace MVCWEB.Components;

public class ProductFilterMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}