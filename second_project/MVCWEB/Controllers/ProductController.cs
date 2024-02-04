using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace MVCWEB.Controllers;

//mysql başlamazsa portu değiştir bir arttır yeter
// sonra my.cnf'e git ordan portu hep değiştir
// port bilgisi artık girmen gerek port=3307 diye

public class ProductController : Controller
{
    private readonly IRepositoryManager _manager;
    
    public ProductController(IRepositoryManager manager) // IConfiguration ekledim
    {
        _manager = manager;
    }

    
    // GET
    public IActionResult Index()
    {
        var model = _manager.Product.GetAllProducts(false);

        return View(model);
    }

    
    public IActionResult Get(int id)
    {
        var product = _manager.Product
            .GetOneProduct(id, false);
            

        return View(product);
    }
}