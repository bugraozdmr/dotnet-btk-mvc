using Microsoft.AspNetCore.Mvc;
using Services.Concrats;

namespace Presentation.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    // MVc.Core yüklemek lazım -- presentation programa kayıt ettir
    private readonly IServiceManager _manager;

    public ProductsController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _manager.ProductService.GetAllProducts(false);
        return Ok(products);
    }
}