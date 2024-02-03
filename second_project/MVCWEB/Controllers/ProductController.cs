using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace MVCWEB.Controllers;

//mysql başlamazsa portu değiştir bir arttır yeter
// sonra my.cnf'e git ordan portu hep değiştir
// port bilgisi artık girmen gerek port=3307 diye

public class ProductController : Controller
{
    private readonly RepositoryContext _context;

    public ProductController(RepositoryContext context) // IConfiguration ekledim
    {
        _context = context;
    }

    
    // GET
    public IActionResult Index()
    {
        var model = _context.Products;

        return View(model);
    }

    
    public IActionResult Get(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id.Equals(id));

        return View(product);
    }
}